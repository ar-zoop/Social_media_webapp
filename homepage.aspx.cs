using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Homepage : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter ad;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        string s = "select username, image, likes, post_id from posts;";

        ad = new SqlDataAdapter(s,con);
        DataSet ds = new DataSet();

        ad.Fill(ds);
        
        R1.DataSource = ds;
        R1.DataBind();
       
    }
    protected void like_Click(object sender, EventArgs e){
    
        /*
        Button btn = (Button)sender;
        int post_id= Convert.ToInt16(btn.CommandName);
         * */
        int post_id=1;
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        string s = "select likes from posts where post_id = '"+ post_id+"';";
        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        int like= Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());        
        like++;
        s = "update posts set likes="+ like+ "where post_id=" + post_id;
        cmd = new SqlCommand(s, con);
        cmd.ExecuteNonQuery();
        Response.Redirect("homepage.aspx");
    }
}