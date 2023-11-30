using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class Donar_Reg : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=database-1.cpzv1qsvleu4.us-east-1.rds.amazonaws.com;Initial Catalog=DoctorApp;User ID=admin;Password=Beasttamer1998;Connection Timeout=60;");

    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Text = Session["id"].ToString();
        Label5.Text = Session["name"].ToString();
        Label7.Text = Session["mob"].ToString();
        Label9.Text = Session["bg"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.Text != "--Select--")
        {
            SqlCommand cmd = new SqlCommand("Insert into Organ(Id,Name,Mobile,Organ,Bg) Values ('" + Label3.Text + "','" + Label5.Text + "','" + Label7.Text + "','" + DropDownList1.Text + "','" + Label9.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Donation Registered');", true);

            string senderEmail = "rajagopalpeddi1998@gmail.com";
            string smtpUserName = "AKIAXKLQEZ5GNDC6U6AD";
            string smtpPass = "BFPgyJf9gmU8j5vwPSU8lL9LRWBMrkoQJf7ySNozA1qF";

            string umail = Session["email"].ToString();
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("email-smtp.us-east-1.amazonaws.com", 587);
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(umail);
            mail.Subject = "Doctor Appointment Alert";
            mail.Body = "You have registered for Organ Donation at " + DateTime.Now.ToString()+"  Thank You _/\\_ ";

            SmtpServer.Port = 587;
            SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPass);
            SmtpServer.Send(mail);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please Select an Organ');", true);
        }
    }
}