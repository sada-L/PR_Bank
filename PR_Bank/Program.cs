using PR_Bank;

class Program
{
    public static void Main(string[] args)
    {
        AccStore accStore = new AccStore();

        while (true)
        {
            Console.WriteLine("Чтобы продолжить, нажмите Enter"); 
            ConsoleKeyInfo c = Console.ReadKey();
            if (c.Key == ConsoleKey.Enter)
            { 
                Bank schBank = accStore.AccMenu();
                schBank.Menu(accStore.Acc);
            }
            else
            {
                return;
            }
        }
        
    }
}