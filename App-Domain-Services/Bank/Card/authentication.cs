using App_Domain_Core.Bank.Cards.Services;
using quiz.Contracts;
using quiz.Entities;
using quiz.reposetories;

namespace quiz.Services
{
    public class authentication : Iauthentication
    {
        ICardReposetory CRepo= new CardReposetory();
        public Card Login(string cardnum,string password)
        {
             Card c= CRepo.GetById(cardnum);

            if (c==null ) { throw new Exception("card number is incorrect"); }
            if (c.IsActive==false) { throw new Exception("card is no longer activce"); }
            if (c.Password != password) { 
                c.tries += 1;
                CRepo.update(c);
                if (c.tries==3) { c.IsActive = false; CRepo.update(c); throw new Exception("password is incorrect! card has been deactivated"); }
                throw new Exception("password is incorrect"); 
            }
            return c;


        }
    }
}
