 using Omran.Sama.Models;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          

namespace Omran.Sama.Tests
{
    public static class Extensions
    {

        public static string GetBankNameAndRouting(this Bank bank) 
        {
            return bank.Name +" "+ bank.RoutingNumber;
        
        }


        public static string GetAccountNumerAndBalance( this Account account)
        {

            return account.Number+""+account.Balance;

        }
    }
}
