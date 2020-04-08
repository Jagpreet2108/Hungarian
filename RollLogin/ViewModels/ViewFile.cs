using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RollLogin.ViewModels
{
    [Table("FoodMag")]
    public class ViewFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string FId { get; set; }

        public string Fcode { get; set; }
        public string FName { get; set; }
        public float FPrice { get; set; }
        public string FDisc { get; set; }
        public int Quantity { get; set; }
        
        [Required]
        public IFormFile formFile { get; set; }
        public DateTime Date { get; set; }
        public DateTime ODate { get; set; }


    }
}
