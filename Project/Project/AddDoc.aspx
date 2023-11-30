<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddDoc.aspx.cs" Inherits="AddDoc" %>

<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="doctor-registration-container">
        <br />
        <asp:Label ID="LblHeading" runat="server" Font-Size="X-Large" Font-Underline="True" ForeColor="#FF9900" Text="Doctor Registration"></asp:Label>
        <br />
        <br />

        <asp:Label ID="LblDocId" runat="server" CssClass="label" Text="Doctor ID:"></asp:Label>
        <asp:TextBox ID="TxtDocId" runat="server" ReadOnly="True" CssClass="textbox"></asp:TextBox>
        <br />
        
        <asp:Label ID="LblPwd" runat="server" CssClass="label" Text="Password:"></asp:Label>
        <asp:TextBox ID="TxtPWD" runat="server" CssClass="textbox"></asp:TextBox>
        <br />

        <asp:Label ID="LblName" runat="server" CssClass="label" Text="Name:"></asp:Label>
        <asp:TextBox ID="TxtName" runat="server" CssClass="textbox"></asp:TextBox>
        <br />

        <asp:Label ID="LblAddress" runat="server" CssClass="label" Text="Address:"></asp:Label>
        <asp:TextBox ID="TxtAddress" runat="server" Height="36px" TextMode="MultiLine" CssClass="textbox"></asp:TextBox>
        <br />

        <asp:Label ID="LblMobile" runat="server" CssClass="label" Text="Mobile No:"></asp:Label>
        <asp:TextBox ID="TxtMobile" runat="server" CssClass="textbox"></asp:TextBox>
        <br />

        <asp:Label ID="LblEmail" runat="server" CssClass="label" Text="Email:"></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server" CssClass="textbox"></asp:TextBox>
        <br />

        <asp:Label ID="LblCategory" runat="server" CssClass="label" Text="Category:"></asp:Label>
        <asp:DropDownList ID="DdlCategory" runat="server" CssClass="textbox">
            <asp:ListItem>--Select--</asp:ListItem>
            <asp:ListItem>General Physician</asp:ListItem>
            <asp:ListItem>Bone</asp:ListItem>
            <asp:ListItem>Heart</asp:ListItem>
            <asp:ListItem>Dentist</asp:ListItem>
            <asp:ListItem>Neurologist</asp:ListItem>
            <asp:ListItem>Kidney</asp:ListItem>
            <asp:ListItem>Cardiologist</asp:ListItem>
            <asp:ListItem>Plastic Surgeon</asp:ListItem>
        </asp:DropDownList>
        <br />

        <asp:Button ID="BtnSubmit" runat="server" onclick="BtnSubmit_Click" Text="Submit" CssClass="button" />
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" />
        <br />
    </div>
</asp:Content>
