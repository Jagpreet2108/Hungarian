using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RollLogin.Models
{[Table("Feedback")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Enter Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Your Contact Number"), RegularExpression(@"^([0-9]{10})$")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Write Your FeedBack Here!!!")]
        [StringLength(50)]
         public string Message { get; set; }
        

    }
}
