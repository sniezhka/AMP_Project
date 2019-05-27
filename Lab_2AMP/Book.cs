using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab_2AMP
{
    public static class StringExtension//14 extension method
    {
        public static int WordCount(this Book book)
        {
            int counter = 0;
            for (int i = 0; i < book.Title.Length; i++)
            {
                counter++;
            }
            return counter;
        }
    }
    //class BookContext : DbContext
    //{
    //    public BookContext()
    //        : base("DbConnection")
    //    { }

    //    public DbSet<Book> Books { get; set; }
    //}
   public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Status { get; set; } = "Available";
        public string Photo { get; set; }
        public Book(string t, string a, int p, string h)
        {
            Title = t;
            Author = a;
            Price = p;
            Photo = h;
            Genres = new List<Genre>();
        }
        public Book() { }
        public virtual void ScoreBook(ref string title, out int price, int id = 00001)
        {
            price = 180;
        }
        public ICollection<Genre> Genres { get; set; }
    }
}
