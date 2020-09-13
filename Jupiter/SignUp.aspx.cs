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
            string email = "random";
            var result = b.CreateUserContainer(email);
            LabelWarningMessage.Text = result.ContainerURI + result.ContainerName + result.SuccessStatus.ToString();
             
        }


        /*private async Task<BlobContainerClient>  CreateUserContainer(string email)
        {
            var result=await b.CreateUserContainer(email);
            return result;
        }*/
        protected void Button_OnClick_Submit(object sender,EventArgs eventArgs)
        {
            bool response = false;
            if (CheckFieldForNulls() && CheckPassword())
            {
                Worker worker = new Worker { FirstName = TextBoxFirstName.Text, LastName = TextBoxLastName.Text, Email = TextBoxEmail.Text, Password = TextBoxPassword.Text };
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
                if (FileUploadProfilePic.HasFile)
                {
                    var _ = GetPicData();
                    bool statusforupload = false;
                    Worker w = db.RetrieveByEmail(Session["email"].ToString());
                    Console.WriteLine(Session["email"].ToString());

                    Console.WriteLine(w.Id.ToString());
                    UserProfilePicture picture = new UserProfilePicture(_.filename,w.Id, _.contentType, _.picData);
                    statusforupload= db.UploadProfilePic(picture);
                    LabelWarningMessage.Text = statusforupload.ToString();
                    
                }
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
        private (string filename,string contentType,byte[] picData) GetPicData()
        {
            
            string filename=null;
            string contentType=null;
            byte[] picData = null;

            if (FileUploadProfilePic.HasFile)
            {

                filename = Path.GetFileName(FileUploadProfilePic.PostedFile.FileName);
               
                contentType = FileUploadProfilePic.PostedFile.ContentType;
                Stream fs = FileUploadProfilePic.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                picData = br.ReadBytes((Int32)fs.Length);

            }
            return (filename,contentType,picData);
        }
      /*  protected bool UploadPicture(string fileName, string contentType, byte[] picData, string email)
        {
            bool responseStatus = false;
            responseStatus = db.UploadProfilePic(fileName, contentType, picData, email);
            return responseStatus;
        }*/

    }
}