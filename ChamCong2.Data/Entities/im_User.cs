using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamCong2.Data.Entities
{
    [Table("im_User")]
    public class im_User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(50)]
        [Required]
        public string Username { get; set; }
        [StringLength(50)]
        [Required]
        public int Phonenumber { get; set; }
        [StringLength(50)]
        [Required]
        public int EmployId { get; set; }
        [StringLength(50)]
        [Required]
        public string Passwword { get; set; }
        [StringLength(50)]
        [Required]
        public DateTime LastLoginDate { get; set; }
    }
}
