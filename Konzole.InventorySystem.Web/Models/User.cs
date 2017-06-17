using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Konzole.InventorySystem.Web.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public Role Roles { get; set; }

        public int? RoleId { get; set; }
    }
}