using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
  
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Request.Cookies["curr_username"].Value = null;
        Response.Redirect("login.aspx");
    }
    
    /*
    protected void Page_Load(object sender, EventArgs e)
{
    if(!String.IsNullOrEmpty(Request.QueryString["srch"])
    {
        //perform search and display results
    }
}
     */

}
