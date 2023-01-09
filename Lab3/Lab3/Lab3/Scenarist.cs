using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Scenarist
    {
        public int Id { get; set; }
        public string Names { get; set; } = null!;
        public string? Years { get; set; }
        public List<Film> Films { get; set; } = new();

        public override string ToString()
        {
            return Names;
        }
    }
}
