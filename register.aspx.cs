using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class register : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter ad;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
         
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = "select * from user_details where username='" + username.Text + "'";
        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            s = "insert into user_details (username,email, password ) values ('" + username.Text + "','" + email.Text + "','" + password.Text + "');";
            cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("login.aspx");
        }
        else
        {
            Response.Write("<script>alert('Username already exists, login or register with a new username.') </script>");
        }
        
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}