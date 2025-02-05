namespace TextRPG;

public class Shop
{
    public Town _town = new Town();
    Player player = GameState.CurrentPlayer;
    public List<Item> ItemList { get; set; }
    public void Start()
    {
        if (ItemList == null)
        {
            SetItems();   
        }
        
        Console.WriteLine("상점");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
        Console.WriteLine("[보유 골드]");
        Console.WriteLine(player.Gold + " G\n");
        Console.WriteLine("[아이템 목록]");
        
        ShowItems();
        
        Console.WriteLine("\n1. 아이템 구매");
        Console.WriteLine("2. 아이템 판매");
        Console.WriteLine("0. back");
        
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        
        int input = Convert.ToInt32(Console.ReadLine());

        if (input == 1)
        {
            BuyItem();
        }
        else if (input == 2)
        {
            SellItem();
        }
        else if (input == 0)
        {
            _town.Start();
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            Start();
        }
    }

    void SetItems()
    {
        ItemList = new List<Item>();
        
        Armor armor = new Armor
        {
            Idx = 0,
            Name = "수련자 갑옷",
            Type = "방어구",
            Information = "수련에 도움을 주는 갑옷입니다.",
            BuyPrice = 1000,
            Defense = 5
        };
        
        Armor armor2 = new Armor()
        {
            Idx = 1,
            Name = "무쇠갑옷",
            Type = "방어구",
            Information = "무쇠로 만들어져 튼튼한 갑옷입니다.",
            BuyPrice = 2000,
            Defense = 9
        };
        
        Armor armor3 = new Armor()
        {
            Idx = 7,
            Name = "스파르타의 갑옷",
            Type = "방어구",
            Information = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
            BuyPrice = 3500,
            Defense = 15
        };
        
        Weapon weapon = new Weapon
        {
            Idx = 10,
            Name = "낡은 검",
            Type = "무기",
            Information = "쉽게 볼 수 있는 낡은 검 입니다.",
            BuyPrice = 600,
            Attack = 2
        };
        
        Weapon weapon2 = new Weapon()
        {
            Idx = 4,
            Name = "청동 도끼",
            Type = "무기",
            Information = "어디선가 사용됐던거 같은 도끼입니다.",
            BuyPrice = 1500,
            Attack = 5
        };
        
        Weapon weapon3 = new Weapon()
        {
            Idx = 5,
            Name = "스파르타의 창",
            Type = "무기",
            Information = "스파르타의 전사들이 사용했다는 전설의 창입니다.",
            BuyPrice = 3000,
            Attack = 7
        };
        
        ItemList.AddRange(new Item[]
        {
            armor,
            armor2,
            armor3,
            weapon,
            weapon2,
            weapon3
        });
    }
    
    void ShowItems(bool type = false)
    {
        foreach (var item in ItemList.Select((val, index) => (val, index)))
        {
            var val = item.val;
            var index = type ? (item.index + 1).ToString() : "";
            
            string price = val.IsSellable ? "구매완료" : val.BuyPrice + " G";
            if (val.Type == "무기")
            {
                Console.WriteLine("- "+ index + " " + val.Name + "  | 공격력 +" + ((Weapon)val).Attack + "  |  " + val.Information + "  |  " + price);
            }
            else if (val.Type == "방어구")
            {
                Console.WriteLine("- " + index + " " + val.Name + "  | 방어력 +" + ((Armor)val).Defense + "  |  " + val.Information + "  |  " + price);
            }
        }
    }
    
    void BuyItem()
    {
        Console.WriteLine("상점");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
        Console.WriteLine("[보유 골드]");
        Console.WriteLine(player.Gold + " G\n");
        Console.WriteLine("[아이템 목록]");
        
        ShowItems(true);
        
        Console.WriteLine("0. back");
        
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        
        int input = Convert.ToInt32(Console.ReadLine());
        
        Item item = ItemList[--input];
        
        if (item.IsSellable)
        {
            Console.WriteLine("이미 구매한 아이템입니다.\n");
            BuyItem();
        }
        
        if (player.Gold < item.BuyPrice)
        {
            Console.WriteLine("골드가 부족합니다.\n");
            Start();
        }
        else
        {
            player.Gold -= item.BuyPrice;
            player.GetItem(item);
            item.IsSellable = true;
            Console.WriteLine(item.Name + "을(를) 구매했습니다.\n");
            Start();
        }
    }
    
    void SellItem()
    {
        Console.WriteLine("상점 - 아이템 판매");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
        Console.WriteLine("[보유 골드]");
        Console.WriteLine(player.Gold + " G\n");
        Console.WriteLine("[아이템 목록]");
        
        List<Item> _inventory = player.Inventory;
        foreach (var item in _inventory.Select((val, index) => (val, index)))
        {
            var val = item.val;
            var index = item.index;
            
            Console.WriteLine("- " + (index + 1) + " " + val.Name + "  |  " + val.Information + "  |  " + val.BuyPrice * 0.85 + " G");
        }
        
        Console.WriteLine("0. back");
        
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        
        string input = Console.ReadLine();
        
        if (input == "0")
        {
            Start();
        } else if (int.TryParse(input, out int index))
        {
            Item item = _inventory[--index];
            player.Gold += item.BuyPrice * 0.85f;
            player.SellItem(item);
            item.IsSellable = false;
            Console.WriteLine(item.Name + "을(를) 판매했습니다.\n");
            SellItem();
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.\n");
            SellItem();
        }
    }
}