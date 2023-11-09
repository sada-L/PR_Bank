namespace PR_Bank;

public class AccStore
{
    private List<Bank> _acc = new List<Bank>();
    public List<Bank> Acc
    {
        get { return _acc; }
    }
    //Добавление счета
    void AddAcc()
    {
        _acc.Add(new Bank());
        Console.WriteLine("Cчёт добавлен");
    }
    //Удаление счета
    void DelAcc()
    {
        Console.Write("Какой счет хотите удалить: ");
        int index = Convert.ToInt32(Console.ReadLine());
        if (index >= 0 && index < _acc.Count)
            _acc.RemoveAt(index);
    }
    //Выбор счета
    Bank GetAcc()
    {
        Console.Write("Введите индекс счета: ");
        int index = Convert.ToInt32(Console.ReadLine());
        if (index >= 0 && index < _acc.Count)
            return _acc[index];
        return null;
    }
    //Вывод информации
    void Info()
    {
        for(int i = 0; i < _acc.Count; i++)
        {
            Console.WriteLine($"Индекс счета: {i}, Номер: {_acc[i].AccNumber}, ФИО: {_acc[i].AccName}");
        }
    }
    //Интефейс управления счетами
    public Bank AccMenu()
    {
        while (true)
        {
            Console.Write
            ("------------------------------\n" +
             "Выберете необходимое действие:\n" +
             "0. Просмореть доступные счета\n" +
             "1. Добавить счёт\n" +
             "2. Удалить счёт\n" +
             "3. Выбрать счёт\n" +
             "4. Выход\n" +
             ">");
            int ans = Convert.ToInt32(Console.ReadLine());
            switch (ans)
            {
                case 0: Info(); break;
                case 1: AddAcc(); break;
                case 2: DelAcc(); break;
                case 3: return GetAcc(); 
                case 4: return null;
            }
        }
    }
}