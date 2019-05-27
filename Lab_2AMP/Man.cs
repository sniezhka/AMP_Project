using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2AMP
{
    public class Man
    {
        public string Name { get; set; }

        public Man(string a)
        {
            Name = a;
        }
        public Man() { }
        public void doNothing() { }
        virtual public void doSmth() { }
    }
}
