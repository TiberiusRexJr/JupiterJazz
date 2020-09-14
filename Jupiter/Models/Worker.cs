using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jupiter.Models
{
    public class Worker
    {
        
        #region Variables
        #endregion
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Required")]
        [Display(Name ="First Name")]
        [DataType(DataType.Text)]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Text)]
        public string UserType { get; set; }

        [DataType(DataType.Text)]
        public string StorageContainerUri { get; set; }
        [DataType(DataType.Text)]
        public string StorageContainerName { get; set; }
        [DataType(DataType.Text)]
        public string ProfilePictureFileName { get; set; }

        public List<Worker> ShowAllWorkers { get; set; }
        #endregion
        #region Implementations
        #endregion
        #region Constructor
        public Worker()
        {
        }

        public Worker(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public Worker(int id, string firstName, string lastName, string email, string password, string userType, string storageContainerUri, string storageContainerName, string profilePictureFileName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserType = userType;
            StorageContainerUri = storageContainerUri;
            StorageContainerName = storageContainerName;
            ProfilePictureFileName = profilePictureFileName;
        }
        #endregion
        #region Functions
        #endregion
    }
}
