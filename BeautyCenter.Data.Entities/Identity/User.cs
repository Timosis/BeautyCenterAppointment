using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Identity
{
    public class User : Entity
    {
        public Guid UniqueId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public PasswordHashAlgorithm PasswordHashAlgorithm { get; set; }
        public UserStatus UserStatus { get; set; }
        public UserType UserType { get; set; }


        public List<UserRole> UserRoles { get; set; }
        public List<ResetPassword> ResetPasswords { get; set; }
        public List<TwoFactorAuth> TwoFactorAuths { get; set; }
        public List<UserSession> UserSessions { get; set; }
    }
}
