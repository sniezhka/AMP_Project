using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab_2AMP
{
   public class Order
    {
        [Key]

        public int Id { get; set; }
        public int TotalSum { get; set; }
        public string BookName { get; set; }
        public Order() { }
        delegate int Operation(int x, int y);
        public int GetSum(int bookCount, int price)
        {
            Operation op = (x, y) => x * y;
            TotalSum = op(bookCount, price);
            return TotalSum;
        }
        public int? ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}
