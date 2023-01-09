using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class FType
    {
        public int Id { get; set; }
        public string View { get; set; } = null!;
        public List<Film> Films { get; set; } = new();
        public override string ToString()
        {
            return View;
        }
    }
}