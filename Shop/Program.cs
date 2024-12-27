using App_Domain_AppService.Bank;
using App_Domain_Core.Bank.Cards.AppServices;
using App_Domain_Core.Bank.Cards.Services;
using App_Domain_Core.Bank.contract;
using quiz.Entities;
using quiz.Services;


IAuthnticationAppService auth = new AuthnticationAppService();
ITransferAppService Service = new TransferAppService();
 


bool end = false;
bool stop = false;

while (end == false)
{
    try
    {
        int options = 0;
        Console.Clear();
        Console.WriteLine("1- Login");
        Console.WriteLine("3- Exit");
        options = Convert.ToInt32(Console.ReadLine());
        switch (options)
        {
            case 1:
                Console.Clear();
                Console.Write("please enter your cards number : ");
                string cardnum = Console.ReadLine();
                if (cardnum.Length!=16) { throw new Exception("something is wrong"); }
                Console.Write("please enter your password : ");
                string password = Console.ReadLine();
                var acc = auth.Login(cardnum, password);
                if (acc == null) { throw new Exception("User does not exist"); }      
                
                CardMenu(acc);

                Console.ReadKey();
                break;

            case 2:
                Console.Clear();
                end = true;
                Console.ReadKey();
                break;

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
    }

}



void CardMenu(Card c)
{
    stop = false;
    while (stop == false)
    {
        try
        {


            int option = 0;
            Console.Clear();
            Console.WriteLine("1- transfer");
            Console.WriteLine("2- show reports");
            Console.WriteLine("3- show balance");
            Console.WriteLine("4- Change Password");
            Console.WriteLine("5- Exit");

            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.Clear();

                    Console.Write("please enter the receivers cards number : ");
                    string reccardnum = Console.ReadLine();
                    if (reccardnum.Length != 16 ) { throw new Exception("something is wrong"); }
                    if (reccardnum== c.CardNumber) { throw new Exception("you cant send yourself money"); }
                    Console.Write("please enter the amount : ");
                    float amount = float.Parse(Console.ReadLine());
                    if (amount <=0) { throw new Exception("you cant do that"); }
                    Console.WriteLine($"To : {Service.RecieversInfo(reccardnum)}\n {amount}$");
                    Console.Write("are you sure?(y/n) : ");
                    string op = Console.ReadLine();
                    if (op == "n") { throw new Exception("going back..."); }
                    else if(op=="y") { Console.WriteLine(Service.transfer(c, reccardnum, amount)); }
                    else { throw new Exception("Incorrect Input"); }

                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();

                    List<Transaction> tranlist=Service.Reports(c.CardNumber);
                    foreach (Transaction t in tranlist) { Console.WriteLine($"{t.Id}) {t.SourceCardNumber} => {t.DestinationCardNumber}-     |{t.TransferDate}    {t.Amount}$ |"); }
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine($"{c.HolderName} ({c.CardNumber})\n Balance={Service.CheckBalance(c.CardNumber)}$");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("please enter the receivers cards number : ");
                    string OldPassword = Console.ReadLine();
                    Console.Write("please enter the receivers cards number : ");
                    string NewPassword = Console.ReadLine();
                    Console.WriteLine(Service.ChangePassword(c.CardNumber,OldPassword,NewPassword));
                    Console.ReadKey();
                    break;
                case 5:
                    stop=false;
                    break;
                default:

                    Console.WriteLine("idont know what you are saying");
                    break;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
}