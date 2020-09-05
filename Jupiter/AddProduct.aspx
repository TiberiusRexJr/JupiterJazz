<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Jupiter.AddProduct" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <form runat="server">

    <h2>Add Products</h2>
    <hr />
        <div class="container">
            <div class="form-horizontal">
    <div class="form-group">
        <asp:Label runat="server" ID="LabelName" CssClass="col-md-2 control-label" Text="Name"></asp:Label>
        <div class="col-md-3">
            <asp:TextBox ID="TextBoxName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValidatorName" ControlToValidate="TextBoxName" runat="server" ErrorMessage="Required Field" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" ID="LabelPrice" CssClass="col-md-2 control-label" Text="Price"></asp:Label>
        <div class="col-md-3">
            <asp:TextBox ID="TextBoxPrice" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValidatorPrice" runat="server" ControlToValidate="TextBoxPrice" ErrorMessage="Required Field" CssClass="text-danger"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="ValidatorPriceDecimals" ControlToValidate="TextBoxPrice"  ErrorMessage="Please enter valid decimal number with any decimal place" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ></asp:RegularExpressionValidator>

        </div>

            </div>
        </div>
    </div>
    
  
   <div class="form-group">
        <asp:Label runat="server" ID="label4" CssClass="col-md-2 control-label" Text="WeaponType"></asp:Label>
        <div class="col-md-3">
            <asp:DropDownList ID="Weapons" runat="server"></asp:DropDownList>
<%--            <asp:requiredfieldvalidator id="validatorforweapontype" runat="server" errormessage="required field" cssclass="text-danger"></asp:requiredfieldvalidator>--%>
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" ID="label1" CssClass="col-md-2 control-label" Text="Size"></asp:Label>
        <div class="col-md-3">
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
<%--            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" CssClass="text-danger"></asp:RequiredFieldValidator>--%>
        </div>
    </div>
    </form>
</asp:Content>

