using System.Reflection.Metadata.Ecma335;

namespace PR_Bank;

public class Bank
{
    private int _accNumber;
    private string _accName;
    private float _accSum;
    public List<Bank> Banks;

    public Bank(int accNumber, string accName, float accSum)
    {
        _accNumber = accNumber; 
        _accName = accName;
        _accSum = accSum;
    }

    public void Out()
    {
        Console.WriteLine($"Номер счета: {_accNumber}, Имя: {_accName}, Сумма на счете: {_accSum}");
    }

    public void Dob()
    {
        Console.Write("Ввидите сумму пополнения: ");
        float sum = Convert.ToInt32(Console.ReadLine());
        if (sum > 0)
        {
            _accSum += sum;
        }
        else
        {
            Console.WriteLine("Не верный формат ввода, попробуйте еще раз");
            Dob();
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }

    public void Umen()
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
            Console.WriteLine("Не верный формат ввода, попробуйте еще раз");
            Umen();
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }

    public void Obmul()
    {
        Console.WriteLine("Вы точно хотите снять всю сумму: ДА/НЕТ");
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
            Console.WriteLine("Не верный формат ввода, попробуйте еще раз");
            Obmul();
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }

    private Bank Search(int nom, List<Bank> banks) 
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

    public void Transfer()
    {
        Console.Write("Ввидите номер счета получателя: ");
        int nom = Convert.ToInt32(Console.ReadLine());
        Bank srhBank = Search(nom, Banks);
        if (srhBank == null)
        {
            Console.WriteLine("Получатель не найден, попробуйте еще раз");
            Transfer();
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
                Transfer();
            }
        }
        else
        {
            Console.WriteLine("Не верный формат ввода, попробуйте еще раз");
            Transfer();
        }
        Console.WriteLine($"Сумма на счете: {_accSum}");
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("Выберете необходимое действие:\n" +
                              "1. Показать данные счета\n" +
                              "2. Пополнить счет\n" +
                              "3. Снять со счета\n" +
                              "4. Снять всю сумму со счета\n" +
                              "5. Перевести на другой счет\n" +
                              "6. Выход");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1: Out(); break;
                case 2: Dob(); break;
                case 3: Umen(); break;
                case 4: Obmul(); break;
                case 5: Transfer(); break;
                case 6: return;
            }
        }
    }
}