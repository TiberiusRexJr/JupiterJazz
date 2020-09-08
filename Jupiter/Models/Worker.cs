using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jupiter.Models
{
    public class Worker
    {
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

        public List<Worker> ShowAllWorkers { get; set; }
        #endregion
        #region Implementations
        #endregion
        #region Constructor

        #endregion
        #region Functions
        #endregion
    }
}
