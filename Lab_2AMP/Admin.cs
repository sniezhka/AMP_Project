using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_2AMP
{
    sealed class Admin: Man, IAccount, IPhone//7
    {
       new public string Name { get; set; }//5
       new public string Surname { get; set; }
       new public int CardNumber { get; set; }
        public int Wallet { get; set; }
        delegate void Do();//2
        public Admin()
        { }
        public Admin(string name, string surname, int cardnumber)
        {
            Do smth = doSmth;//2  
            Name = name;
            Surname = surname;
            CardNumber = cardnumber;
            smth();
        }
        //public void AddBook(Book book)
        //{
        //    using (BookContext db = new BookContext())
        //    {
        //        db.Books.Add(book);
        //        db.SaveChanges();
        //    }
        //}
        public void AddBook(Book book)
        {
            using (BookContext db = new BookContext())
            {
                Genre g = db.Genres.FirstOrDefault(ge => ge.Name == "Other");
                db.Books.Add(book);
                g.Books.Add(book);
                db.Genres.Add(g);
                db.SaveChanges();
            }
        }
        public void AddBook(Book book, string genre)
        {
            using (BookContext db = new BookContext())
            {
                Genre g = db.Genres.FirstOrDefault(ge => ge.Name == genre);//
                int lenght = book.WordCount();//extension method 14
                db.Books.AddRange(new List<Book> { book });
                g.Books.Add(book);
                db.Genres.Add(g);
                db.SaveChanges();
            }
        }
        public void AddGenre(string genre)
        {
            using (BookContext db = new BookContext())
            {
                Genre g = new Genre();
                g.Name = genre;
                db.Genres.Add(g);
                db.SaveChanges();
            }
        }
        public void DeletedBook()
        {
            using (BookContext db = new BookContext())
            {
                Book b1 = db.Books.FirstOrDefault();
                if (b1 != null)
                {
                    db.Books.Remove(b1);
                    db.SaveChanges();
                }
            }
        }

        //Interfaca IAccount
        private int _sum;
        public void Withdraw(int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;
            }
        }
        public int CurrentSum { get; }
        public void Put(int sum)
        {
            this._sum += sum;
        }
        //

        //Interface IPhone
        public int Phone { get; set; }
        public int this[int index] {
            get { return Phone; }
            set { Phone = value; }
        }
        //

        public override void doSmth()//8
        {
            base.doNothing();//6
            { }
        }
        
}
}
