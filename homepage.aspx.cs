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
        if (!Page.IsPostBack)
        {
            string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
            con = new SqlConnection(path);
            con.Open();
            string s = "select * from posts;";

            string curr_username = Request.Cookies["curr_username"].Value;

            ad = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();

            ad.Fill(ds);

            R1.DataSource = ds;
            R1.DataBind();
            for (int i = 0; i < R1.Items.Count; i++)
            {
                LinkButton l = R1.Items[i].FindControl("like") as LinkButton;
                Label l1 = R1.Items[i].FindControl("likeCount") as Label;
                HiddenField h1 = R1.Items[i].FindControl("h1") as HiddenField;

                if ((ds.Tables[0].Rows[i][0]).ToString() == curr_username)
                {
                    Panel p = R1.Items[i].FindControl("show_delete_button") as Panel;
                    p.Visible = true;
                }

                string s1 = "select * from user_like_post where liker_username='" + Request.Cookies["curr_username"].Value + "' and post_id=" + h1.Value + "";
                ad = new SqlDataAdapter(s1, con);
                DataSet ds1 = new DataSet();

                ad.Fill(ds1);
                if (ds1.Tables[0].Rows.Count == 0)
                {
                    l.Text = "Like";
                }
                else
                {
                    int a = Convert.ToInt16(ds1.Tables[0].Rows[0][2]);

                    if (a == 0)
                    {
                        l.Text = "Like";
                    }
                    else
                    {
                        l.Text = "Unlike";
                    }
                }


            }



            con.Close();
        }
    }
    protected void LinkButton2_Click(object sender, CommandEventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();

        //get post id of the liked/unliked post
        Int64 post_id = Convert.ToInt64(e.CommandName); //??how to not use Cnvert here
        string curr_username = Request.Cookies["curr_username"].Value;

        string s = "select like_status from user_like_post where post_id=" + post_id + "and liker_username='" + curr_username + "';";
        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        
        if (ds.Tables[0].Rows.Count == 0)
        {
            s = "insert into user_like_post (post_id, liker_username, like_status) values (" + post_id + ",'" + curr_username + "'," + 1 + ")";
            cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }
        LinkButton l = (LinkButton)sender;
        if (l.Text == "Like")
        {
            

            string s1 = "update posts set likes=likes+1 where post_id=" + post_id + ";";
            cmd = new SqlCommand(s1, con);
            cmd.ExecuteNonQuery();
           
            string s2 = "update user_like_post set like_status=1 where  post_id=" + post_id + "and liker_username= '"+curr_username+"';";
            cmd = new SqlCommand(s2, con);
            cmd.ExecuteNonQuery();
           
            //Response.Redirect("homepage.aspx");
        }
        else 
        {
            
            string s1 = "update posts set likes=likes-1 where post_id=" + post_id + ";";
            cmd = new SqlCommand(s1, con);
            cmd.ExecuteNonQuery();

            string s2 = "update user_like_post set like_status=0 where  post_id=" + post_id + "and liker_username= '" + curr_username + "';";
            cmd = new SqlCommand(s2, con);
            cmd.ExecuteNonQuery();            

            //Response.Redirect("homepage.aspx");
        }
        con.Close();
   }

    protected void LinkButton1_Click(object sender, CommandEventArgs e)
    {
        string username = Convert.ToString(e.CommandName);
        Response.Redirect("display_profile.aspx?username="+username);
    }

    protected void uploadComment_Click(object sender, CommandEventArgs e)
    {
       
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        string curr_username = Request.Cookies["curr_username"].Value;

        LinkButton button = (LinkButton)sender;
        Int16 post_id = Convert.ToInt16(button.CommandArgument);

        TextBox t = (TextBox)button.Parent.FindControl("comment_box");

        if (t.Text != "")
        {

            string s = "insert into comments (post_id, comment, username) values (" + post_id + ",'" + t.Text + "','" + curr_username + "');";
            cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }
        con.Close();


    }

    protected void delete_Click(object sender, CommandEventArgs e)
    {
         string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        LinkButton l1 = (LinkButton)sender;
        Int16 post_id = Convert.ToInt16(l1.CommandArgument);
        string s1 = "delete from comments where post_id=" + post_id + ";";
        cmd = new SqlCommand(s1, con);
        cmd.ExecuteNonQuery();
        string s2 = "delete from user_like_post where post_id=" + post_id + ";";
        cmd = new SqlCommand(s2, con);
        cmd.ExecuteNonQuery();
        string s3 = "delete from posts where post_id=" + post_id + ";";
        cmd = new SqlCommand(s3, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void comment2_Click(object sender, CommandEventArgs e)
    {
        LinkButton button = (LinkButton)sender;
        string panelID = "show_comment_box";
        RepeaterItem item = (RepeaterItem)button.NamingContainer;
        Panel panel = (Panel)item.FindControl(panelID);
        panel.Visible = true;

       // display comments under this
        string panelID2 = "display_comments";
        Panel panel2 = (Panel)item.FindControl(panelID2);
        panel2.Visible = true;

    }
    protected void R1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
        RepeaterItem item = e.Item;
        
        
        Repeater repeaterComments = (Repeater)item.FindControl("repeaterComments");

        HiddenField h1 = (HiddenField)item.FindControl("h1");

        Int16 post_id = Convert.ToInt16(h1.Value);

        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        string s = "select * from comments where post_id=" + post_id+ ";";

        string curr_username = Request.Cookies["curr_username"].Value;

        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();

        ad.Fill(ds);

        repeaterComments.DataSource = ds;
        repeaterComments.DataBind();

        for (int i = 0; i < repeaterComments.Items.Count; i++)
        {
            if ((ds.Tables[0].Rows[i][1]).ToString() == curr_username)
            {
                Panel p = repeaterComments.Items[i].FindControl("show_delete_button") as Panel;
                p.Visible = true;
            }

        }

        con.Close();
    }

    protected void delete_comment_Click(object sender, CommandEventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        LinkButton l1 = (LinkButton)sender;
        Int16 post_id = Convert.ToInt16(l1.CommandArgument);

        Label l = (Label)l1.Parent.Parent.FindControl("fetched_comment");
        string comment = l.Text;
        string s1 = "delete from comments where post_id=" + post_id + " and comment='"+comment+"';";
        cmd = new SqlCommand(s1, con);
        cmd.ExecuteNonQuery();
        
        
        con.Close();
        Response.Write("<script> alert('Comment deleted successfully')</script >");

    }
  
}