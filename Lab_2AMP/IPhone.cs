using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2AMP
{
    interface IPhone
    {
        int Phone { get; set; }
        int this[int index] { get; set;}
    }
}
