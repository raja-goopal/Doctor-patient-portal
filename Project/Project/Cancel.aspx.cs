﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class Cancel : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=database-1.cpzv1qsvleu4.us-east-1.rds.amazonaws.com;Initial Catalog=DoctorApp;User ID=admin;Password=Beasttamer1998;Connection Timeout=60;");

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Select UId from App where AId = '" + TextBox1.Text + "' And UId='" + Session["Id"].ToString() + "'", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            con.Close();
            
            cmd = new SqlCommand("Delete from App where AId = '" + TextBox1.Text + "' And UId='" + Session["Id"].ToString() + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Booking Deleted Successfully');", true);

            string senderEmail = "rajagopalpeddi1998@gmail.com";
            string smtpUserName = "AKIAXKLQEZ5GNDC6U6AD";
            string smtpPass = "BFPgyJf9gmU8j5vwPSU8lL9LRWBMrkoQJf7ySNozA1qF";

            string umail = Session["email"].ToString();
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("email-smtp.us-east-1.amazonaws.com", 587);
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(umail);
            mail.Subject = "Doctor Appointment Alert";
            mail.Body = "Your Appointment AId: '"+TextBox1.Text+"' has been Cancled";
                
            SmtpServer.Port = 587;
            SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPass);
            SmtpServer.Send(mail);
            TextBox1.Text = "";
        }
        else
        {
            con.Close();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Invalid Id');", true);
        }
        
        

    }
}