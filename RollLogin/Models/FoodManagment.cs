using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RollLogin.Models
{
    [Table("FoodMag")]
    public class FoodManagment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string FId { get; set; }
        [Key]
        public string Fcode { get; set; }
        public string FName { get; set; }
        public float FPrice { get; set; }
        public string FDisc { get; set; }
        public int Quantity { get; set; }
        public string Atri { get; set; }
        public DateTime Date { get; set; }
        public DateTime ODate { get; set; }

    }
}
