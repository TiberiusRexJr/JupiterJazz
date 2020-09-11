using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jupiter.Models
{
    public class UserProfilePicture
    {
        
        #region Properties
        public string FileName { get; set; }
        public int OwnerId { get; set; }
        public string ContentType { get; set; }
        public byte[] PicData { get; set; }

        #endregion
        #region Constructor
        public UserProfilePicture(string fileName, int ownerId, string contentType, byte[] picData)
        {
            FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            OwnerId = ownerId;
            ContentType = contentType ?? throw new ArgumentNullException(nameof(contentType));
            PicData = picData ?? throw new ArgumentNullException(nameof(picData));
        }
        public UserProfilePicture()
        { 
        }
        #endregion
    }
}