using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RollLogin.Models
{
    [Table("Emps")]
    public class Emps
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EId { get; set; }
        [Required]
        public string Ename { get; set; }
        [Required]
        public float Salary { get; set; }
        [Required]
        public string Desingnation { get; set; }
    }
}
