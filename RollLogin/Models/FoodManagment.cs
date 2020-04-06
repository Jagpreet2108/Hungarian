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
        public int MyProperty { get; set; }
    }
}
