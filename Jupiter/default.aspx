<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Jupiter._default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
  
    <!--carousel-->
    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
         <!--Indicators-->
    <ol class="carousel-indicators">
        <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
        <li data-target="#carousel-example-generic" data-slide-to="1" ></li>
        <li data-target="#carousel-example-generic" data-slide-to="2" ></li>
        <li data-target="#carousel-example-generic" data-slide-to="3" ></li>

    </ol>
        <!--Wrapper for slides-->
    <div class="carousel-inner" role="listbox">
        <div class="item active">
            <img src="/images/gundam.jpg" alt="" />
            <div class="carousel-caption">
               <p><a class="btn btn-lg btn-primary" href="#" role="button">Get in the Gundam</a></p>
            </div>
        </div>
      
           <div class="item">
            <img src="images/thunderbolt.jpg" alt="" />
            <div class="carousel-caption">
               <p><a class="btn btn-lg btn-primary" href="#" role="button">Find out why thunderbolt is the best</a></p>
            </div>
        </div>
        <div class="item">
            <img src="images/ts.jpeg" alt="" />
            <div class="carousel-caption">
              <p><a class="btn btn-lg btn-primary" href="#" role="button">Bang them hoes!</a></p>
            </div>
        </div>
        <div class="item">
            <img src="images/ippo.png" alt=""/>
            <div class="carousel-caption">
                <asp:HyperLink runat="server" ID="LinkSignUp" NavigateUrl="~/SignUp.aspx" Text="Signup"></asp:HyperLink>
              <p><a class="btn btn-lg btn-primary" href="SignUp.aspx" role="button">Join Today</a></p>
            </div>
        </div>
        
    </div>
    <!--Wrapper for slides-->
         <!--controls-->
    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a> 
    <!--controls-->
    </div>
   
    
   


</asp:Content>
