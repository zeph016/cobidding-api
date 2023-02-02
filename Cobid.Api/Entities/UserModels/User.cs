using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.UserModel
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NameExtension { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[] { };
        public byte[] PasswordSalt { get; set; } = new byte[] { };
        public int UserTypeId { get; set; }
        public DateTime CreatedTimeSpan { get; set; } = DateTime.Now;
        public DateTime UpdatedTimeSpan { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ShipppingAddress { get; set; } = string.Empty;
        public int ValidationId { get; set; }
        public int CommunityId { get; set; }
        public string UserProfilePic { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string CompleteName
        {
            get
            {
                var _completeName = "";
                if (!string.IsNullOrWhiteSpace(NameExtension))
                    _completeName = FirstName + " " + LastName + " " + NameExtension;
                else
                    _completeName = FirstName + " " + LastName;
                return _completeName;
            }
        }
        public List<UserValidationImage> ValidationIds { get; set; } = new List<UserValidationImage>();
        [NotMapped]
        public bool IsEdit { get; set; }
        [NotMapped]
        public bool IsNew { get; set; }
    }
}
