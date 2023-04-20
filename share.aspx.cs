using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter ad;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(5000);
        string opath = "";
      
        if (FileUpload1.HasFile)
        {

            String ext = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (ext == ".png" || ext == ".jpeg" || ext == ".jpg" || ext == ".PNG" || ext == ".JPEG" || ext == ".JPG")
            {
                long len = FileUpload1.FileContent.Length;
                if (len <= (1024 * 1024 * 5))
                {
                    String path = Server.MapPath("~/photo/" + FileUpload1.FileName);
                    opath = "~/photo/" + FileUpload1.FileName;
                    FileUpload1.SaveAs(path);
                    string s = "insert into posts(username, image_file, date_time, likes) values('" + Request.Cookies["curr_username"].Value+"','"+ opath + "','" + DateTime.Now.ToString() + "',"+ 0+")";
                    cmd = new SqlCommand(s, con);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Image successfully shared.')</script>");
                    /*
                    string s1 = "select sfile from file";
                    ad = new SqlDataAdapter(s1, con);
                    ad.Fill(ds);
                    Image1.ImageUrl = ds.Tables[0].Rows[0][0].ToString();
                     */
                }
                else
                {
                    Response.Write("<script>alert('File size extended.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('File format incorrect.')<script>");
            }
        }
        else
        {
            Response.Write("<script>alert('File not selected.')</script>");
        }
    }
}
