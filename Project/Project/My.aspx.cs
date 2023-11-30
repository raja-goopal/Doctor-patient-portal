using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class My : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=database-1.cpzv1qsvleu4.us-east-1.rds.amazonaws.com;Initial Catalog=DoctorApp;User ID=admin;Password=Beasttamer1998;Connection Timeout=60;");
    
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Select * from Cust where UId='"+Session["id"].ToString()+"'",con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        TextBox1.Text = dr[0].ToString();
        TextBox2.Text = dr[1].ToString();
        TextBox3.Text = dr[2].ToString();
        TextBox4.Text = dr[3].ToString();
        TextBox5.Text = dr[4].ToString();
        con.Close();

        string s = "SELECT * FROM History where UId='" + TextBox1.Text + "'";
        SqlDataAdapter da = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {

    }
}