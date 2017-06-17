using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Konzole.InventorySystem.Web.Models
{
    public class User
    {
        public int Id { get; set; }

        public int UserName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Role Roles { get; set; }

        public int RoleId { get; set; }
    }
}