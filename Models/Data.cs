using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int Progress { get; set; }

        // Навигационное свойство
        public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
    }
}
