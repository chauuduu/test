using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCrud.Models
{
    public class AppUser:IdentityUser
    {
        public AppUser()
        {
        }
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; private set; }
        [Range(16, 100, ErrorMessage = "Age must be above 16")]
        public int Age { get; private set; }
        public void SetName (string name)
        {
            FullName = name.Trim();
        }

    }
}
