using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int Order { get; set; } // Порядок отображения
        public int DataId { get; set; }

        // Навигационные свойства
        public Data Data { get; set; } = new Data();
        public List<Section> Sections { get; set; } = new List<Section>();
    }
}
