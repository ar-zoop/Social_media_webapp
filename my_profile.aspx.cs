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
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        
        string s = " select * from user_details where username='" + Request.Cookies["curr_username"].Value + "'; ";
        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        username.Text = ds.Tables[0].Rows[0][0].ToString();
        name.Text=ds.Tables[0].Rows[0][1].ToString();
        email.Text=ds.Tables[0].Rows[0][2].ToString();
        bio.Text=ds.Tables[0].Rows[0][3].ToString();
        contact_number.Text = ds.Tables[0].Rows[0][4].ToString();
        con.Close();
        /*
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
         */
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        string curr_username = Request.Cookies["curr_username"].Value;
        
        string s = "update user_details set name= '" + name.Text + "' , email = '" + email.Text + "', bio= '" + bio.Text + "', contact_number='" + contact_number.Text + "' where username= '" + curr_username + "';";
        cmd = new SqlCommand(s, con);
        cmd.ExecuteNonQuery();
        Response.Write("<script> alert('Profile successfully updated.')</script >");
        con.Close();
      
    }
}