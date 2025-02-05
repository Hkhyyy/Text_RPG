namespace TextRPG;

public class Town
{
    public static Status _status = new Status();
    public static Inventory _Inventory = new Inventory();
    public static Shop _shop = new Shop();
    public static Dungeon _dungeon = new Dungeon();
    public void Start()
    {
        if (GameState.CurrentPlayer == null)
        {
            Console.WriteLine("현재 플레이어가 없습니다. 게임을 초기화 해주세요.");
            return;
        }
        
        Player player = GameState.CurrentPlayer;
        Console.WriteLine("Welcome to the Sparta Town!");
        Console.WriteLine("Select your action!\n");
        Console.WriteLine("1. Show Status");
        Console.WriteLine("2. Inventory");
        Console.WriteLine("3. Go to Shop");
        Console.WriteLine("4. Rest");
        Console.WriteLine("5. Go to Dungeon");
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        try 
        {
            int action = Convert.ToInt32(Console.ReadLine());
            
            switch (action)
            {
                case 1:
                    ShowStatus(player);
                    break;
                case 2:
                    Inventory();
                    break;
                case 3:
                    GoToShop();
                    break;
                case 4:
                    Rest();
                    break;
                case 5:
                    Dungeon();
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

    void ShowStatus(Player player)
    {
        _status.ShowStatus(player);
    }

    void Inventory()
    {
        _Inventory.ShowInventory();
    }
    
    void GoToShop()
    {
        _shop.Start();
    }

    void Rest()
    {
        Player player = GameState.CurrentPlayer;
        
        Console.WriteLine("휴식하기");
        Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다. (현재 체력: {0}, 보유 골드: {1})", player.HP, player.Gold);
        Console.WriteLine("\n1. 휴식하기");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");

        int input = Convert.ToInt32(Console.ReadLine());
        
        if (input == 0)
        {
            Start();
        }
        else if (input == 1)
        {
            if (player.Gold >= 500)
            {
                if (player.HP == 100) {
                    Console.WriteLine("이미 체력이 가득 찼습니다.\n");
                    Rest();
                }
                player.Gold -= 500;
                player.HP = 100;
                Console.WriteLine("체력이 회복되었습니다. (현재 체력: {0}, 보유 골드: {1})", player.HP, player.Gold);
                Rest();
            } else {
                Console.WriteLine("골드가 부족합니다.\n");
                Rest();
            }
        }
    }
    
    void Dungeon()
    {
        _dungeon.Start();
    }
}