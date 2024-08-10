using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class News_to_CategoryDTO : NewsDTO
    {
        public CategoryDTO Category { get; set; }
    }
}
