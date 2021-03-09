using System;
using System.Collections.Generic;

namespace SoftwareEngineeringProject.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public sbyte IsLocked { get; set; }
        public int FailedAttempts { get; set; }
        public bool IsAdmin { get; set; }
    }
}
