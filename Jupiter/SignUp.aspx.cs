using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Jupiter.DataLayer;
using Jupiter.Models;
using System.Drawing;
using Azure.Storage.Blobs;
using System.IO;
using System.Data;
using Jupiter.Services;
using System.Threading.Tasks;

namespace Jupiter
{
    public partial class SignUp : System.Web.UI.Page
    {
        private DataBase db = new DataBase();
        BlobShit b = new BlobShit();
   
        protected void Page_Load(object sender, EventArgs e)
        {
           
             
        }

        protected void Button_OnClick_Submit(object sender,EventArgs eventArgs)
        {
            bool response = false;
            if (CheckFieldForNulls() && CheckPassword())
            {
               var responseTupleCreateUserContainer = b.CreateUserContainer(TextBoxEmail.Text);

                Worker worker = new Worker { FirstName = TextBoxFirstName.Text, LastName = TextBoxLastName.Text, Email = TextBoxEmail.Text, Password = TextBoxPassword.Text,StorageContainerUri= responseTupleCreateUserContainer.ContainerURI,StorageContainerName= responseTupleCreateUserContainer.ContainerName };//PFUA
                if (response = db.Create(worker)) //possible fuck up area
                {
                    Session["firstName"] = worker.FirstName;
                    Session["lastName"] = worker.LastName;
                    Session["email"] = worker.Email;
                    Session["password"] = worker.Password;

                    LabelWarningMessage.Text = string.Empty;
                    LabelWarningMessage.ForeColor = Color.Red;
                }
                else
                {
                    LabelWarningMessage.Text = "Error!"+response.ToString();
                    LabelWarningMessage.ForeColor = Color.Empty;

                }

            }
            if (response) //PFUA
            {
                Response.Redirect("/Users/UserDashBoard.aspx");
                /*if (FileUploadProfilePic.HasFile)
                {
                    string fileuploadStatus = string.Empty;
                    //get stream,get filename (from picdata),
                    var responseTupleGetPicData = GetPicData();
                    //get user container name
                    Worker worker=db.RetrieveByEmail(Session["email"].ToString()); //PFUA

                    fileuploadStatus= b.InsertIntoUserContainer(worker.StorageContainerName, responseTupleGetPicData.profilePicName, responseTupleGetPicData.picStream);
                    LabelWarningMessage.Text = fileuploadStatus;
                   *//* if (fileuploadStatus)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    { 
                    LabelWarningMessage.Text = fileuploadStatus.ToString();
                    
                    }*//*
                }*/
            }
            //Response.Redirect("Login.aspx");
        }
  
        private bool CheckFieldForNulls()
        {
            bool valid = false;
            if (TextBoxFirstName.Text!= string.Empty && TextBoxLastName.Text != string.Empty && TextBoxEmail.Text != string.Empty && TextBoxPassword.Text != string.Empty && TextBoxConfirmPassword.Text != string.Empty)
            {
                TextBoxFirstName.BorderColor = System.Drawing.Color.Empty;
                TextBoxLastName.BorderColor = System.Drawing.Color.Empty;
                TextBoxEmail.BorderColor = System.Drawing.Color.Empty;
                TextBoxPassword.BorderColor = System.Drawing.Color.Empty;
                TextBoxConfirmPassword.BorderColor = System.Drawing.Color.Empty;

                LabelWarningMessage.Text = string.Empty;

                valid = true;



            }
            else
            {
                TextBoxFirstName.BorderColor = System.Drawing.Color.Red;
                TextBoxLastName.BorderColor = System.Drawing.Color.Red;
                TextBoxEmail.BorderColor = System.Drawing.Color.Red;
                TextBoxPassword.BorderColor = System.Drawing.Color.Red;
                TextBoxConfirmPassword.BorderColor = System.Drawing.Color.Red;
                LabelWarningMessage.Text = "All Feilds are required";
                LabelWarningMessage.ForeColor = System.Drawing.Color.Empty;



            }
            return valid;
        }
        private bool CheckPassword()
        {
            bool valid = false;
            if (TextBoxPassword.Text == TextBoxConfirmPassword.Text)
            {

                /*LabelWarningMessage.Text = "Welcome!" + worker.FirstName + "!"+response.ToString();*/
                /*   LabelWarningMessage.ForeColor = System.Drawing.Color.Green;*/

                TextBoxPassword.BorderColor = System.Drawing.Color.Empty;
                TextBoxConfirmPassword.BorderColor = System.Drawing.Color.Empty;
                LabelWarningMessage.Text = string.Empty;
                valid = true;
            }

            else
            {
                TextBoxPassword.BorderColor = System.Drawing.Color.Red;
                TextBoxConfirmPassword.BorderColor = System.Drawing.Color.Red;
                LabelWarningMessage.Text = "Passwords do not match";
           
            }
            return valid;
            }      
        private (Stream picStream,string profilePicName) GetPicData()
        {
            
            string profilePicName = null;
            Stream picStream = null;
            string randomSequence = new Guid().ToString();

            if (FileUploadProfilePic.HasFile)
            {

                profilePicName = Path.GetFileName(FileUploadProfilePic.PostedFile.FileName);
                

                picStream = FileUploadProfilePic.PostedFile.InputStream;

            }
            return (picStream, profilePicName);
        }

    }
}