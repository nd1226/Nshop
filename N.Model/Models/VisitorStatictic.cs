using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Model.Models
{
    [Table("VisitorStatictics")]
    public class VisitorStatictic
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [MaxLength(50)]
        public string IpAddress { get; set; }
    }
}
