<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Jupiter.SignUp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    
       <p class="col-lg-10">Sign Up</p>
       <form id="FormSignUp" runat="server">
           
           <label class="col-xs-11">First Name:</label>
           <asp:TextBox ID="TextBoxFirstName" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
           <label  class="col-xs-11">Last Name:</label>
           <asp:TextBox ID="TextBoxLastName" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
           <label  class="col-xs-11">Email:</label>
           <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
           <label  class="col-xs-11">Password:</label>
           <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
           <label  class="col-xs-11">Confrim Password:</label>
            <asp:TextBox ID="TextBoxConfirmPassword" runat="server" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
           <asp:Label runat="server" CssClass="col-xs-11">User Image</asp:Label>
           <asp:FileUpload runat="server" ID="FileUploadProfilePic" BackColor="Gainsboro" />
           <br />

           <asp:Button runat="server" Text="Submit" CssClass="btn btn-success btn-lg" OnClick="Button_OnClick_Submit" ID="Button_Submit" />
           <asp:Label ID="LabelWarningMessage" runat="server" Text=" " CssClass="text-warning"></asp:Label>

       </form>

    
</asp:Content>
