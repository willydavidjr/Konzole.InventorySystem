using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem
{
    [Table("Supplier", Schema = "IV")]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int EWTId { get; set; }
        public int VATtypeId { get; set; }
        public int Terms { get; set; }
        public string Recuser { get; set; }
        public DateTime ? Recdate { get; set; }
        public int Moduser { get; set; }
        public DateTime? ModDate { get; set; }
        public string Taxcode { get; set; }
        public int Status { get; set; }

    }
}
