using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [Column("varchar")]
        public string ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Alias { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
