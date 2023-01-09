using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Film
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }

        public int ScenaristId { get; set; }
        public int GenreId { get; set; }
        public int TypeId { get; set; }
        public FType? Type { get; set; }
        public Genre? Genre { get; set; }
        public Scenarist? Scenarist { get; set; }
    }
}
