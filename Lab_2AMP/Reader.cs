using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace Lab_2AMP
{
   public class Reader : Man, IAccount, IPhone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CardNumber { get; set; }
        public Reader(string name, string surname, int card)
        {
            Orders = new List<Order>();
            Name = name;
            Surname = surname;
            CardNumber = card;
            Orders = new List<Order>();

        }
        
        public Reader() { }
        public void MakeOrder(int id)
        {
            BookContext db = new BookContext();
            Book book = db.Books.Find(id);
            book.Status = "Ordered";
            db.SaveChanges();
            Order or = new Order { Reader = this, BookName = book.Title };
            or.GetSum(1, book.Price);
            db.Orders.AddRange(new List<Order> { or });
            db.SaveChanges();
        }
        public ICollection<Order> Orders { get; set; }


        //Interface IAccount

        private int _sum;
        public int CurrentSum { get; }
        public void Put(int sum) => this._sum += sum;
        //{
        //    this._sum += sum;
        //}
        public void Withdraw(int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;
            }
        }
        //

        //Interface IPhone
        public int Phone { get; set; }
        public int this[int index]
        {
            get { return Phone; }
            set { Phone = value; }
        }
        //

    }
}
