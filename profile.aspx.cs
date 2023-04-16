using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class profile : System.Web.UI.Page
{
    SqlConnection con; 
    SqlDataAdapter ad;
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        string s = " select * from user_details where username='" + username.Text + "'; ";
        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        string ip_username = ds.Tables[0].Rows[0][0].ToString();
        string ip_pswd = ds.Tables[0].Rows[0][5].ToString();
        if (username.Text == ip_username && ip_pswd == password.Text)
        {
            Response.Cookies["curr_username"].Value = username.Text;
            Response.Redirect("homepage.aspx");
        }
        else
        {
            Response.Write("<script> alert('Invalid credentials')</script >");
        }
    }
}