using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

public partial class upload : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string fileName = Path.GetFileName(oFile.PostedFile.FileName);
        string filePath = Server.MapPath("./") + fileName;
        oFile.PostedFile.SaveAs(filePath);
        byte[] fileData = File.ReadAllBytes(filePath);

        string curr_user= Request.Cookies["curr_username"].Value;
        string s = "insert into posts (username, image, likes) values ('" + curr_user + "','"+fileData+"',"+0+")";
        cmd = new SqlCommand(s, con);        
        cmd.ExecuteNonQuery();

        

        // Display a message indicating that the file was successfully uploaded
        lblUploadResult.Text = fileName + " has been successfully uploaded.";
        Response.Redirect("homepage.aspx");
        /*
        string strFileName;
        string strFilePath;
        string strFolder;
        strFolder = Server.MapPath("./");
        // Retrieve the name of the file that is posted.
        strFileName = oFile.PostedFile.FileName;
        strFileName = Path.GetFileName(strFileName);
        if (oFile.Value != "")
        {
            // Create the folder if it does not exist.
            if (!Directory.Exists(strFolder))
            {
                Directory.CreateDirectory(strFolder);
            }
            // Save the uploaded file to the server.
            strFilePath = strFolder + strFileName;
           
            oFile.PostedFile.SaveAs(strFilePath);
         
            lblUploadResult.Text = strFileName + " has been successfully uploaded.";
            
        }
        else
        {
            lblUploadResult.Text = "Click 'Browse' to select the file to upload.";
        }
        
        // Display the result of the upload.
        frmConfirmation.Visible = true;
         * */
    }
}