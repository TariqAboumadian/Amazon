using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; }
        public string Type { get; set; }= string.Empty;
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Product? Product { get; set; } = default!;
        public virtual Category? Category { get; set; } = default!;
    }
}
