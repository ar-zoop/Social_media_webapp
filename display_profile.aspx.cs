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
    SqlDataAdapter ad, ad2;
    SqlCommand cmd;
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
            username.Text = ds.Tables[0].Rows[0][0].ToString();
            name.Text = ds.Tables[0].Rows[0][1].ToString();
            email.Text = ds.Tables[0].Rows[0][2].ToString();
            bio.Text = ds.Tables[0].Rows[0][3].ToString();
            contact_number.Text = ds.Tables[0].Rows[0][4].ToString();

            // text to show follow or unfollow
            string curr_username = Request.Cookies["curr_username"].Value;
            string s1 = " select * from followers where username='" + username_to_display + "' AND follower_name='" +curr_username + "'; ";
            ad2 = new SqlDataAdapter(s1, con);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2);

            

            if (ds2.Tables[0].Rows.Count == 0)
            {
                followId.Text = "Follow";
            }
            else
            {
                followId.Text = "Unfollow";
                //string a = ds2.Tables[0].Rows[0][1].ToString();
                //Response.Write("<script> alert(a)</script>");
                //if (a == username_to_display)
                //{
                //    followId.Text = "Unfollow";
                //}
                //else
                //{
                //    followId.Text = "dfghj";
                //}
            }


            // -------------------------------------------------------Lot of mess-------------------------------------------------------------------------
            if (!Page.IsPostBack)
            {
            s = "select * from posts where username='" + username_to_display + "';";
            ad = new SqlDataAdapter(s, con);
            ds = new DataSet();

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

                string s2 = "select * from user_like_post where liker_username='" + curr_username + "' and post_id=" + h1.Value + "";
                ad = new SqlDataAdapter(s2, con);
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

            }



            // -------------------------------------------------------Lot of mess-------------------------------------------------------------------------

        

    }
    protected void followId_Click(object sender, EventArgs e)
    {
        string username_to_display = Request.QueryString["username"].ToString();
        string curr_username = Request.Cookies["curr_username"].Value ;

        //string username_to_display = Request.QueryString["username"].ToString();
        // select to check if already exists
        string s = " select * from followers where username='" + username_to_display + "' AND follower_name='" + curr_username + "'; ";
        ad = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        //Response.Write("<script> alert(username_to_display, follower_name) </script>");
        
        if (ds.Tables[0].Rows.Count == 0)
        {
            string ins = "insert into followers (username,follower_name) values ('" + username_to_display + "','" + curr_username + "');";
            cmd = new SqlCommand(ins, con);
            cmd.ExecuteNonQuery();
        }
        else
        {
            string my_user = (ds.Tables[0].Rows[0][1]).ToString();
            string display_user = (ds.Tables[0].Rows[0][0]).ToString();
            string del = "delete from followers where username= '" + display_user + "' AND follower_name= '"+my_user+"'";
            cmd = new SqlCommand(del, con);
            cmd.ExecuteNonQuery();
        }
        // depending we either delete or insert 


        con.Close();
    }



    //-----------------------------------------------------------------------------------------------
    protected void LinkButton5_Command1(object sender, CommandEventArgs e)
    {
        string username = Convert.ToString(e.CommandName);
        if (username == Request.Cookies["curr_username"].Value)
        {
            Response.Redirect("my_profile.aspx");
        }
        else Response.Redirect("display_profile.aspx?username=" + username);
    }
    protected void like_Command(object sender, CommandEventArgs e)
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

            string s2 = "update user_like_post set like_status=1 where  post_id=" + post_id + "and liker_username= '" + curr_username + "';";
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
    protected void comment2_Command(object sender, CommandEventArgs e)
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
    protected void delete_Command(object sender, CommandEventArgs e)
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
    protected void commentor_Command(object sender, CommandEventArgs e)
    {
        string username = Convert.ToString(e.CommandName);
        if (username == Request.Cookies["curr_username"].Value)
        {
            Response.Redirect("my_profile.aspx");
        }
        else Response.Redirect("display_profile.aspx?username=" + username);
    }
    protected void delete_comment_Command(object sender, CommandEventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        LinkButton l1 = (LinkButton)sender;
        Int16 post_id = Convert.ToInt16(l1.CommandArgument);

        Label l = (Label)l1.Parent.Parent.FindControl("fetched_comment");
        string comment = l.Text;
        string s1 = "delete from comments where post_id=" + post_id + " and comment='" + comment + "';";
        cmd = new SqlCommand(s1, con);
        cmd.ExecuteNonQuery();


        con.Close();
        Response.Write("<script> alert('Comment deleted successfully')</script >");

    }



}