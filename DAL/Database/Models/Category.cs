using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database.Models
{
    public class Category
    {
        [Key]
        public int Category_ID { get; set; }

        [Required]
        public string Name { get; set; }

        // Relationship => One to Many with News. One-Side = Category
        public virtual ICollection<News> Newses { get; set; }

        public Category()
        {
            Newses = new List<News>();

        }
    }
}
