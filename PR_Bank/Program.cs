 using PR_Bank;
class Program
 {
     public static void Main(string[] args)
     {
         Bank acc1 = new Bank();
         Bank acc2 = new Bank();
         List<Bank> Banks = new List<Bank>() {acc1, acc2};
         
         acc1.Menu(Banks);
         acc2.Menu(Banks);
     }
 }