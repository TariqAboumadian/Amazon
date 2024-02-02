using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public Category? Parent { get; set; } = default!;
        public virtual ICollection<Category>? ChildCategories { get; set; } =
            new HashSet<Category>();
        public virtual ICollection<Product>? Products { get; set; }=
            new HashSet<Product>();
        public virtual ICollection<Image>? Images { get; set; } =
            new HashSet<Image>();
    }
}
