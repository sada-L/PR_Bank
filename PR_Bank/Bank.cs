using System.Diagnostics.Tracing;
using System.Reflection.Emit;

namespace PR_Bank;
public class Bank
{
    private int _accNumber; //номер счета
    private float _accSum;  //Сумма на счете
    private string _accName;//ФИО
    public int AccNumber
    {
        get { return _accNumber; }
    }
    public string AccName
    {
        get { return _accName; }
    }
    //Ввод информации
    public Bank(List<Bank> banks)
    {
        Info(banks);
    }
    void Info(List<Bank> banks)
    {
        while (true)
        {
            Label:
            Console.Write
            ("Введите номер счета и ФИО:\n" + ">");
            string[] s = Console.ReadLine().Split(',', ' ', ';');
            foreach (Bank bank in banks)
            {
                if (Int32.Parse(s[0]) == bank._accNumber)
                {
                    Console.WriteLine("Такой счет уже существует, попробуйте еще раз");
                    goto Label;
                }
            }
            _accNumber = Int32.Parse(s[0]);
            _accName = s[1];
            return;
        }
    }
    //вывод информации о счете
    void Out()
    {
        Console.WriteLine
        ($"----------------------------\n" +
         $"Номер счета: {_accNumber}\n" +
         $"Имя: {_accName}\n" +
         $"Сумма на счете: {_accSum}\n" +
         $"----------------------------\n");
    }
    //пополнение счета
    void Dob()
    {
        bool exit = true;
        while (exit)
        {
            Console.Write("Введите сумму пополнения: ");
            float sum = Convert.ToInt32(Console.ReadLine());
            if (sum >= 0)
            {
                _accSum += sum;
                exit = false;
            }
            else
            {
                Console.WriteLine("Неверный формат ввода, попробуйте еще раз");
            }
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }
    //снять со счета
    void Umen()
    {
        bool exit = true;
        while (exit)
        {
            Console.Write("Введите суммы вывода: ");
            float sum = Convert.ToInt32(Console.ReadLine());
            if (sum >= 0)
            {
                if (sum <= _accSum)
                {
                    _accSum -= sum;
                    exit = false;
                }
                else
                {
                    Console.WriteLine("Недостаточно суммы на счете, попробуйте еще раз");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ввода, попробуйте еще раз");
            }
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }
    //снятие всей суммы со счета
    void Obmul()
    {
        bool exit = true;
        while (exit)
        {
            Console.Write("Вы точно хотите снять всю сумму: +/-\n" +
                          ">");
            string ans = Console.ReadLine();
            if (ans == "+")
            {
                _accSum = 0;
                exit = false;
            }
            else if(ans == "-")
            {
                Console.WriteLine("Спасибо, что вы с нами");
                exit = false;
            }
            else
            {
                Console.WriteLine("Неверный формат ввода, попробуйте еще раз");
            }
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }
    //поиск счета по номеру
    Bank Search(List<Bank> banks) 
    {
        while (true)
        {
            Console.Write("Введите номер счета получателя: ");
            int nom = Convert.ToInt32(Console.ReadLine());
            foreach (Bank bank in banks)
            {
                if (nom == bank._accNumber)
                {
                    return bank;
                }
            }
            return null;
        }
    }
    //перевод между счетами
    void Transfer(List<Bank> banks)
    {
        bool exit = true;
        while (exit)
        {
            Bank srhBank = Search(banks);
            if (srhBank == null)
            {
                Console.WriteLine("Получатель не найден, попробуйте еще раз");
                srhBank = Search(banks);
            }
            Console.Write("Введите сумму перевода: ");
            float sum = Convert.ToInt32(Console.ReadLine());
            if (sum >= 0)
            {
                if (sum <= _accSum)
                {
                    _accSum -= sum;
                    srhBank._accSum += sum;
                    exit = false;
                }
                else
                {
                    Console.WriteLine("Недостаточно суммы на счете, попробуйте еще раз");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ввода, попробуйте еще раз");
            }
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }
    //Интерфейс пользователя
    public void Menu(List<Bank> banks)
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
                case 0: Info(banks); break;
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