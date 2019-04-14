using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Model.Models
{
    [Table("SystemConfigs")]

    public class SystemConfig
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string ValueString { get; set; }
        public int? ValueCode { get; set; }

    }
}
