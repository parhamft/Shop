using App_Domain_Core.Bank.Cards.Services;
using quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Domain_Core.Bank.contract
{
    public interface ITransferService
    {
        public bool CheckLimit(Card cs, float Amount);
        public float GetFee(float Amount);
        public Card ValidateCard(string DestinationCardNumber);
        public bool CheckBalance(Card cs, float Fee, float Amount);
        public bool TempPassword();
        public List<Transaction> Reports(string cardnum);
        public string ChangePassword(string cardnum, string OldPassword, string password);
        public float CheckBalance(string cardnum);
        public string RecieversInfo(string cardnum);

    }
}
