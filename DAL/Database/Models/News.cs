using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database.Models
{
    public class News
    {
        [Key]
        public int News_ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        // Relationship => Many to One with Category. Many Side = News

        [ForeignKey("Category")]
        // Here int? is for Null Allowed
        public int Category_ID { get; set; }
        public virtual Category Category { get; set; }
    }
}
