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
        if (!Page.IsPostBack)
        {
            string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
            con = new SqlConnection(path);
            con.Open();

            string s = " select * from user_details where username='" + Request.Cookies["curr_username"].Value + "'; ";
            ad = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            username.Text = ds.Tables[0].Rows[0][0].ToString();
            name.Text = ds.Tables[0].Rows[0][1].ToString();
            email.Text = ds.Tables[0].Rows[0][2].ToString();
            bio.Text = ds.Tables[0].Rows[0][3].ToString();
            contact_number.Text = ds.Tables[0].Rows[0][4].ToString();
            con.Close();
        }
      
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        
        string curr_username = Request.Cookies["curr_username"].Value;

        string nameValue = name.Text; // Accessing the value of the name TextBox control
        string emailValue = email.Text; // Accessing the value of the email TextBox control
        string bioValue = bio.Text; // Accessing the value of the bio TextBox control
        string contactNumberValue = contact_number.Text; // Accessing the value of the contact_number TextBox control

        //Response.Write("<script> alert(name.Text)</script >");
        string s1 = "update user_details set name= '" + nameValue + "' , email = '" + emailValue + "', bio= '" + bioValue + "', contact_number='" + contactNumberValue + "' where username= '" + curr_username + "';";
        cmd = new SqlCommand(s1, con);
        cmd.ExecuteNonQuery();
        Response.Write("<script> alert('Profile successfully updated.')</script >");
        //Response.Redirect("my_profile.aspx");
        con.Close();
      
    }


    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        string s = "select * from followers where username='" + Request.Cookies["curr_username"].Value + "' ";
        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();

        ad.Fill(ds);

        followersRepeater.DataSource = ds;
        followersRepeater.DataBind();

        LinkButton button = (LinkButton)sender;
        string panelID2 = "followersRepeater";
        //RepeaterItem item = (RepeaterItem)button.NamingContainer;
        //Panel panel2 = (Panel)item.FindControl(panelID2);
        //panel2.Visible = true;
      
        followersPanel.Visible = true;
        repeaterPanel.Visible = true;

        followingPanel.Visible = false;
        repeaterPanel1.Visible = false;
    }
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        string s = "select * from followers where follower_name='" + Request.Cookies["curr_username"].Value + "' ";
        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();

        ad.Fill(ds);

        followingRepeater.DataSource = ds;
        followingRepeater.DataBind();

        LinkButton button = (LinkButton)sender;
        string panelID2 = "followingRepeater";
        //RepeaterItem item = (RepeaterItem)button.NamingContainer;
        //Panel panel2 = (Panel)item.FindControl(panelID2);
        //panel2.Visible = true;

        followingPanel.Visible = true;
        repeaterPanel1.Visible = true;

        followersPanel.Visible = false;
        repeaterPanel.Visible =  false;
    }
    protected void LinkButton3_Command(object sender, CommandEventArgs e)
    {
        string username = Convert.ToString(e.CommandName);
        if (username == Request.Cookies["curr_username"].Value)
        {
            Response.Redirect("my_profile.aspx");
        }
        else Response.Redirect("display_profile.aspx?username=" + username);
    }
    protected void LinkButton4_Command1(object sender, CommandEventArgs e)
    {
        string username = Convert.ToString(e.CommandName);
        if (username == Request.Cookies["curr_username"].Value)
        {
            Response.Redirect("my_profile.aspx");
        }
        else Response.Redirect("display_profile.aspx?username=" + username);
    }
}