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
        string s = "select * from posts;";

        ad = new SqlDataAdapter(s,con);
        DataSet ds = new DataSet();

        ad.Fill(ds);
        
        R1.DataSource = ds;
        R1.DataBind();
        for(int i=0;i<R1.Items.Count;i++)
        {
            LinkButton l=R1.Items[i].FindControl("like") as LinkButton;
            Label l1 = R1.Items[i].FindControl("likeCount") as Label;
            HiddenField h1 = R1.Items[i].FindControl("h1") as HiddenField;

       //string s1="select * from posts where username='"+Request.Cookies["curr_username"].Value+"' and post_id="+h1.Value+"";
       string s1 = "select * from user_like_post where liker_username='" + Request.Cookies["curr_username"].Value + "' and post_id=" + h1.Value + "";
        ad = new SqlDataAdapter(s1,con);
        DataSet ds1 = new DataSet();

        ad.Fill(ds1);
           if(ds.Tables[0].Rows.Count==0)
           {
               l.Text="like";
           }
           else

           {
               int a= Convert.ToInt16(ds.Tables[0].Rows[0][2]);
               if(a==0){
                   l.Text="like";
               }
               else{
               l.Text="unlike";
               }
           }


        }
        con.Close();
    }
    protected void LinkButton2_Click(object sender, CommandEventArgs e)
    {
        ////get info if there exists a row in the table. if there is no table then that means that the user is liking the picture for the first time
        //string s = "select * from user_like_post where post_id=" + post_id + " and liker_username='" + curr_username + "';";
        //ad = new SqlDataAdapter(s, con);
        //DataSet ds = new DataSet();
        //ad.Fill(ds);
        //Int64 total_like_count = 0;

        ////the flag keeps a track if the post was liked or unliked. liked= true. unliked= false
        //bool flag = false;
        //if (ds.Tables[0].Rows.Count == 0)
        //{
        //    s = "insert into user_like_post (post_id, liker_username, like_status) values (" + post_id + ",'" + curr_username + "'," + 1 + ")";
        //    cmd = new SqlCommand(s, con);
        //    cmd.ExecuteNonQuery();
        //    flag = true;
             
        //}

        ////if user is not liking the picture for the first timw then change the like_status to the oppposite of what it is and mark the flag as true or false accordingly
        //else
        //{
        //    Int64 status = Convert.ToInt64(ds.Tables[0].Rows[0][2]);
        //    s = "update user_like_post set like_status= case when like_status= " + 1 + " then " + 0 + " else " + 1 + " end where post_id=" + post_id + "and liker_username='" + curr_username + "';";
        //    cmd = new SqlCommand(s, con);
        //    cmd.ExecuteNonQuery();
        //    if (status == 1) flag = false;
        //    else flag = true;
        //}

        //// get info of total count of likes on the post
        //s = "select likes from posts where post_id=" + post_id + ";";
        //ad = new SqlDataAdapter(s, con);
        //DataSet ds2 = new DataSet();
        //ad.Fill(ds2);
        //total_like_count = Convert.ToInt64(ds2.Tables[0].Rows[0][0]);

        ////increase the count by 1
        //if (flag == true)
        //{           
        //    total_like_count++;
            
        //}

        ////decrease the count by 1
        //else
        //{
        //    total_like_count--;
        //}

        //s = "update posts set likes=" + total_like_count + "where post_id=" + post_id + ";";
        //cmd = new SqlCommand(s, con);
        //cmd.ExecuteNonQuery();
        //Response.Redirect("homepage.aspx");
        
        // con.Close();

        //make connection

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

   }

    protected void LinkButton1_Click(object sender, CommandEventArgs e)
    {
        string username = Convert.ToString(e.CommandName);
        Response.Redirect("display_profile.aspx?username="+username);
    }
    

}