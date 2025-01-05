using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public int Order { get; set; } // Порядок отображения
        public int ChapterId { get; set; }

        // Навигационное свойство
        public Chapter Chapter { get; set; } = new();
        public ICollection<UserProgress> UserProgresses { get; set; } = new List<UserProgress>();
    }
}
