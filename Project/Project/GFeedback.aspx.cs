using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class GFeedback : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=database-1.cpzv1qsvleu4.us-east-1.rds.amazonaws.com;Initial Catalog=DoctorApp;User ID=admin;Password=Beasttamer1998;Connection Timeout=60;");
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Insert Into Feedback(UId,Feed,Date) Values('"+Session["id"].ToString()+"','"+TextBox1.Text+"','"+DateTime.Now.ToShortDateString()+"')",con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Thank You For The Feedback');", true);
        TextBox1.Text = "";
    }
}