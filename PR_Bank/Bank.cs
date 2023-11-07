namespace PR_Bank;
public class Bank
{
    private int _accNumber;
    private string _accName;
    private float _accSum;
    //Ввод информации
    void Info()
    {
        Console.WriteLine($"Введите ноиер счета и ФИО: \n" +
                          $">");
        string[] s = Console.ReadLine().Split(',', ' ', ';');
        _accNumber = Int32.Parse(s[0]);
        _accName = s[1];
    }
    //вывод информации о счете
    public void Out()
    {
        Console.WriteLine($"Номер счета: {_accNumber}, Имя: {_accName}, Сумма на счете: {_accSum}");
    }
    //пополнение счета
    void Dob()
    {
        Console.Write("Ввидите сумму пополнения: ");
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
        Console.Write("Ввидите суммы вывода: ");
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
        Console.Write("Вы точно хотите снять всю сумму: ДА/НЕТ" +
                          ">");
        string ans = Console.ReadLine();
        if (ans == "ДА")
        {
            _accSum = 0;
        }
        else if(ans == "НЕТ")
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
    Bank Search(int nom, List<Bank> banks) 
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
    void Transfer(List<Bank> Banks)
    {
        Console.Write("Ввидите номер счета получателя: ");
        int nom = Convert.ToInt32(Console.ReadLine());
        Bank srhBank = Search(nom, Banks);
        if (srhBank == null)
        {
            Console.WriteLine("Получатель не найден, попробуйте еще раз");
            Transfer(Banks);
        }
        Console.Write("Ввидите сумму перевода: ");
        float sum = Convert.ToInt32(Console.ReadLine());
        if (sum > 0)
        {
            if (sum > _accNumber)
            {
                _accSum -= sum;
                srhBank._accSum += sum;
            }
            else
            {
                Console.WriteLine("Недостаточно суммы на счете, попробуйте еще раз");
                Transfer(Banks);
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ввода, попробуйте еще раз");
            Transfer(Banks);
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }
    //Интерфейс пользователя
    public void Menu(List<Bank> Banks)
    {
        while (true)
        {
            Console.WriteLine
            ("Выберете необходимое действие:\n" +
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
                case 5: Transfer(Banks); break;
                case 6: return;
            }
        }
    }
}