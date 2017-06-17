using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem
{
    public class Person
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        [RegularExpression("^[0-9 -]+$", ErrorMessage = "Invalid Phone Number.")]
        [Column(TypeName = "varchar")]
        public string Phone { get; set; }

        /// <summary>
        /// Now considering how we have another ASPNET auth table that holds the 
        /// email addresses, and that is also their 'username'... We have much 
        /// more work to do to keep things in sync.
        /// </summary>
        [StringLength(255)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$", ErrorMessage = "Invalid email address.")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        [Column(TypeName = "varchar")]
        public string State { get; set; }

        [Required]
        [StringLength(11)]
        [Column(TypeName = "varchar")]
        public string PostalCode { get; set; }

        public int IsActive { get; set; }

        public void SetIsActivate(bool isActive)
        {
            this.IsActive = isActive ? 1 : 0;
        }
    }
}
