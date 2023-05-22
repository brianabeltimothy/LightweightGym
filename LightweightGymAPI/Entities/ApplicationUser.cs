﻿using Microsoft.AspNetCore.Identity;

namespace LightweightGymAPI.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MembershipId { get; set; }
    }
}
