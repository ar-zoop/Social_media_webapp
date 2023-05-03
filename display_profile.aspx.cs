using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class display_profile : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter ad;
    protected void Page_Load(object sender, EventArgs e)
    {
        string username_to_display = Request.QueryString["username"].ToString();
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
       
        
        string s = " select * from user_details where username='" + username_to_display + "';";
        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        username.Text=ds.Tables[0].Rows[0][0].ToString();
        name.Text = ds.Tables[0].Rows[0][1].ToString();
        email.Text = ds.Tables[0].Rows[0][2].ToString();
        bio.Text = ds.Tables[0].Rows[0][3].ToString();
        contact_number.Text = ds.Tables[0].Rows[0][4].ToString();
         
    }
}