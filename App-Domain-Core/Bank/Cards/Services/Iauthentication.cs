using quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Domain_Core.Bank.Cards.Services
{
    public interface Iauthentication
    {
        public Card Login(string cardnum, string password);
    }
}
