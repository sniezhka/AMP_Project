using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab_2AMP
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } // название команды

        public ICollection<Book> Books { get; set; }
        public Genre()
        {
            Books = new List<Book>();
        }
    }
}