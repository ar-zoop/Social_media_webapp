using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class login : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter ad;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = " select * from user_details where username='" + username.Text + "'; ";
        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script> alert('User does not exist')</script >");
        }
        else
        {

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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
}