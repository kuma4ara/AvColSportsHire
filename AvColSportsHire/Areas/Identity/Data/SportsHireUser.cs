using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvColSportsHire.Models;
using Microsoft.AspNetCore.Identity;

namespace AvColSportsHire.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SportsHireUser class
public class SportsHireUser : IdentityUser
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsStaff { get; set; }

   

}

