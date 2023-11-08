namespace PR_Bank;
public class Bank
{
    private int _accNumber; //номер счета
    private string _accName;//ФИО
    private float _accSum;  //Сумма на счете
    //Ввод информации
    void Info()
    {
        Console.Write($"Введите номер счета и ФИО:\n" +
                      $">");
        string[] s = Console.ReadLine().Split(',',' ',';');
        _accNumber = Int32.Parse(s[0]);
        _accName = s[1];
    }
    //вывод информации о счете
    void Out()
    {
        Console.WriteLine($"----------------------------\n" +
                          $"Номер счета: {_accNumber}\n" +
                          $"Имя: {_accName}\n" +
                          $"Сумма на счете: {_accSum}\n" +
                          $"----------------------------\n");
    }
    //пополнение счета
    void Dob()
    {
        Console.Write("Введите сумму пополнения: ");
        float sum = Convert.ToInt32(Console.ReadLine());
        if (sum > 0)
        {
            _accSum += sum;
        }
        else
        {
            Console.WriteLine("Неверный формат ввода, попробуйте еще раз");
            Dob();
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }
    //снять со счета
    void Umen()
    {
        Console.Write("Введите суммы вывода: ");
        float sum = Convert.ToInt32(Console.ReadLine());
        if (sum > 0)
        {
            if (sum <= _accSum)
            {
                _accSum -= sum;
            }
            else
            {
                Console.WriteLine("Недостаточно суммы на счете, попробуйте еще раз");
                Umen();
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ввода, попробуйте еще раз");
            Umen();
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }
    //снятие всей суммы со счета
    void Obmul()
    {
        Console.Write("Вы точно хотите снять всю сумму: +/-\n" +
                      ">");
        string ans = Console.ReadLine();
        if (ans == "+")
        {
            _accSum = 0;
        }
        else if(ans == "-")
        {
            Console.WriteLine("Спасибо, что вы с нами");
        }
        else
        {
            Console.WriteLine("Неверный формат ввода, попробуйте еще раз");
            Obmul();
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }
    //поиск счета по номеру
    Bank Search(int nom, Bank[] banks) 
    {
        foreach (Bank bank in banks)
        {
            if (nom == bank._accNumber)
            {
                return bank;
            }
        }
        return null;
    }
    //перевод между счетами
    void Transfer(Bank[] banks)
    {
        Console.Write("Введите номер счета получателя: ");
        int nom = Convert.ToInt32(Console.ReadLine());
        Bank srhBank = Search(nom, banks);
        if (srhBank == null)
        {
            Console.WriteLine("Получатель не найден, попробуйте еще раз");
            Transfer(banks);
        }
        Console.Write("Введите сумму перевода: ");
        float sum = Convert.ToInt32(Console.ReadLine());
        if (sum > 0)
        {
            if (sum > _accSum)
            {
                _accSum -= sum;
                srhBank._accSum += sum;
            }
            else
            {
                Console.WriteLine("Недостаточно суммы на счете, попробуйте еще раз");
                Transfer(banks);
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ввода, попробуйте еще раз");
            Transfer(banks);
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }
    //Интерфейс пользователя
    public void Menu(Bank[] banks)
    {
        while (true)
        {
            Console.Write
            ("------------------------------\n" +
             "Выберете необходимое действие:\n" +
             "0. Ввести данные\n" +
             "1. Показать данные счета\n" +
             "2. Пополнить счет\n" +
             "3. Снять со счета\n" +
             "4. Снять всю сумму со счета\n" +
             "5. Перевести на другой счет\n" +
             "6. Выход\n" +
             ">");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0: Info(); break;
                case 1: Out(); break;
                case 2: Dob(); break;
                case 3: Umen(); break;
                case 4: Obmul(); break;
                case 5: Transfer(banks); break;
                case 6: return;
            }
        }
    }
}