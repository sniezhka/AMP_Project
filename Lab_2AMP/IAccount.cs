using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2AMP
{
    interface IAccount
    {
        int CurrentSum { get; }  // Перевірити
        void Put(int sum);      // Покласти
        void Withdraw(int sum); // Взяти
    }
}
