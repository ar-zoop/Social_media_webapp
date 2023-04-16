using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class register : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
         
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string s = "insert into user_details (username,email, password ) values ('" + username.Text + "','" + email.Text + "','" + password.Text +  "');";
        cmd = new SqlCommand(s, con);
        cmd.ExecuteNonQuery();
        Response.Redirect("login.aspx");
        
    }
}