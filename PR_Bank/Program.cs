 using PR_Bank;

class Program
 {
     public static void Main(string[] args)
     {
         Bank acc1 = new Bank(111, "Bob", 0);
         Bank acc2 = new Bank(222, "Bill", 0);
         acc1.Banks = new List<Bank>() {acc1, acc2};
         
         acc1.Menu();
         acc2.Menu();
     }
 }