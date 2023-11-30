using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class AddDoc : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=database-1.cpzv1qsvleu4.us-east-1.rds.amazonaws.com;Initial Catalog=DoctorApp;User ID=admin;Password=Beasttamer1998;Connection Timeout=60;");

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmd;
        string query = "SELECT TOP 1 DId FROM Doctor ORDER BY DId DESC;";
        con.Open();
        cmd = new SqlCommand(query, con);
        object count = cmd.ExecuteScalar();
        if (count != null)
        {
            int latestId = Convert.ToInt32(count) + 1;
            TxtDocId.Text = latestId.ToString();
        }
        else
        {
            TxtDocId.Text = "1110";
        }
        con.Close();
    }

    public string ValidateInputs()
    {
        if (TxtName.Text == "")
        {
            return "Name";
        }
        else if (TxtPWD.Text == "")
        {
            return "Password";
        }
        else if (TxtAddress.Text == "")
        {
            return "Address";
        }
        else if (TxtMobile.Text == "")
        {
            return "Mobile No";
        }
        else
        {
            return "OK";
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (ValidateInputs() == "OK")
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Doctor(DId, Name, Address, Mobile, Cate, Pass, Email) VALUES (@DId, @Name, @Address, @Mobile, @Cate, @Pass, @Email);", con);
            cmd.Parameters.AddWithValue("@DId", TxtDocId.Text);
            cmd.Parameters.AddWithValue("@Name", TxtName.Text);
            cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);
            cmd.Parameters.AddWithValue("@Mobile", TxtMobile.Text);
            cmd.Parameters.AddWithValue("@Cate", DdlCategory.Text);
            cmd.Parameters.AddWithValue("@Pass", TxtPWD.Text);
            cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Doctor Registered');", true);
            TxtName.Text = "";
            TxtAddress.Text = "";
            TxtMobile.Text = "";
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please Enter " + ValidateInputs() + "');", true);
        }
    }
}
