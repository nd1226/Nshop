using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NShop.Web.Models
{
    public class TagViewModel
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Type { get; set; }
        public virtual ICollection<PostTagViewModel> PostTags { get; set; }
        public virtual ICollection<ProductTagViewModel> ProductTags { get; set; }
    }
}