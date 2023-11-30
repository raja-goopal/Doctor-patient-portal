using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ViewDoc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=database-1.cpzv1qsvleu4.us-east-1.rds.amazonaws.com;Initial Catalog=DoctorApp;User ID=admin;Password=Beasttamer1998;Connection Timeout=60;");

        SqlDataAdapter da = new SqlDataAdapter("Select DId,Name,Address,Mobile,Cate from Doctor", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}