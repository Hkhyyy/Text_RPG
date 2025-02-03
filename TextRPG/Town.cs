namespace TextRPG;

public class Town
{
    public static Status _status = new Status();
    public static Inventory _Inventory = new Inventory();
    public void Start()
    {
        Console.WriteLine("Welcome to the Sparta Town!");
        Console.WriteLine("Select your action!\n");
        Console.WriteLine("1. Show Status");
        Console.WriteLine("2. Inventory");
        Console.WriteLine("3. Go to Shop");
        try 
        {
            int action = Convert.ToInt32(Console.ReadLine());
            
            switch (action)
            {
                case 1:
                    ShowStatus();
                    break;
                case 2:
                    Inventory();
                    break;
                case 3:
                    GoToShop();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.\n");
                    Start();
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("잘못된 입력입니다.\n");
            Start();
        }
    }

    void ShowStatus()
    {
        _status.ShowStatus();
    }

    void Inventory()
    {
        _Inventory.ShowInventory();
    }
    
    void GoToShop()
    {
        Console.WriteLine("Shop");
    }
}