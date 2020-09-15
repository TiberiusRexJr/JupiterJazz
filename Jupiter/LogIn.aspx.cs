using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jupiter.DataLayer;
using Jupiter.Models;
using Jupiter.Services;

namespace Jupiter
{
    public partial class LogIn : System.Web.UI.Page
    {
        DataBase db = new DataBase();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["email"] != null && Session["password"]!= null)
                {
                    TextBoxEmail.Text = Session["email"].ToString();
                    TextBoxPassword.Attributes["value"] = Session["password"].ToString(); 
                    CheckBoxRememberPassword.Checked = true;
                }
            }

            /*LabelWarning.Text = ConfigurationManager.AppSettings.Get("ConnectionStrings--JupiterJazzStorageKey");*/
            /*if (Session["password"] != null)
            {
                TextBoxPassword.Text = Session["password"].ToString();
            }*/
        }

        protected void ButtonEnter_Click(object sender, EventArgs e)
        {
            bool valid = db.Validate(TextBoxEmail.Text, TextBoxPassword.Text);
            if (!valid)
            {
                LabelWarning.Text = "Invalid Credentials!";

            }
            else
            {
                Worker worker = db.RetrieveByEmail(TextBoxEmail.Text);
                /*LabelWarning.Text = "Welcome" +worker.FirstName;*/

                Session["email"] = worker.Email;
                Session["password"] = worker.Password;
                Session["firstName"] = worker.FirstName;
                Session["lastName"] = worker.LastName;
                Session["usertype"] = worker.UserType;

                if (CheckBoxRememberPassword.Checked)
                {

                    Session["email"] = worker.Email;
                    Session["password"] = worker.Password;
                    Session["firstName"] = worker.FirstName;
                    Session["lastName"] = worker.LastName;
                    Session["usertype"] = worker.UserType;

                }
                else
                {

                    Session["email"] = null;
                    Session["password"] = null;
                    Session["firstName"] = null;
                    Session["lastName"] = null;
                    Session["usertype"] = null;

                }

                if (worker.UserType == "u")
                {
                    Response.Redirect("/Users/UserDashBoard.aspx");
                }
                else if (worker.UserType == "a")
                {
                    Response.Redirect("AdminHome.aspx");
                }
                
            }



                

            }
            /*   if (db.ValidateEmail(TextBoxEmail.Text))
               {
                   LabelWarning.Text = "duh";

               }
               else
               {
                   LabelWarning.Text = "fuck";

               }*/


        }
    }
