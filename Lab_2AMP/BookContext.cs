using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab_2AMP
{
   public class BookContext : DbContext
    {
        public BookContext()
           : base("DbConnection")
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Order> Orders{ get; set; }
    }
}