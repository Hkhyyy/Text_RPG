namespace TextRPG;

public class Inventory
{
    static Town _town = new Town();
    
    public void ShowInventory()
    {
        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
        Console.WriteLine("[아이템 목록]");

        ItemList();
        
        Console.WriteLine("\n1. 장착관리");
        Console.WriteLine("0. 나가기");
        
        string input = Console.ReadLine();
        switch(input)
        {
            case "1":
                // 장착하는거
                EquipItem();
                break;
            case "0":
                // 나가기
                _town.Start();
                break;
            default:
                Console.WriteLine("잘못된 입력입니다.\n");
                ShowInventory();
                break;
        }
    }
    
    void EquipItem()
    {
        List<Item>_inventory = Player.Inventory;
        Console.WriteLine("인벤토리 - 장착관리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
        Console.WriteLine("[아이템 목록]");
        
        ItemList(true);
        
        Console.WriteLine("\n0. 나가기");
        
        int input = Convert.ToInt32(Console.ReadLine());
        
        if (input == 0)
        {
            ShowInventory();
        }
        
        // input validation
        if (input < 0 || input >= _inventory.Count + 1)
        {
            Console.WriteLine("잘못된 입력입니다.\n");
            EquipItem();
        }

        input--;
        
        if (_inventory[input]["isEquipped"])
        {
            _inventory[input]["isEquipped"] = false;
            Console.WriteLine("{0}을(를) 해제했습니다.\n", _inventory[input]["info"]["name"]);
            ShowInventory();
        }
        else
        {
            _inventory[input]["isEquipped"] = true;
            Console.WriteLine("{0}을(를) 장착했습니다.\n", _inventory[input]["info"]["name"]);
            ShowInventory();
        }
    }

    void ItemList(bool type = false)
    {
        List<Dictionary<string, dynamic>>_inventory = Global.GameIntro.playerInventory;
        foreach (var item in _inventory)
        {
            string Equ = "";
            if (item["isEquipped"])
            {
                Equ = "[E]";
            }
            
            if (item["info"]["type"] == "무기")
            {
                if (type)
                {
                    Console.WriteLine("- {0} {1}{2} | ATK +{3} | {4}", item["idx"] + 1, Equ, item["info"]["name"], item["info"]["atk"], item["info"]["information"]);
                }
                else
                {
                    Console.WriteLine("- {0}{1} | ATK +{2} | {3}", Equ, item["info"]["name"], item["info"]["atk"], item["info"]["information"]);
                }
                
            } else if (item["info"]["type"] == "방어구")
            {
                if (type)
                {
                    Console.WriteLine("- {0} {1}{2} | DEF +{3} | {4}", item["idx"] + 1, Equ, item["info"]["name"], item["info"]["def"], item["info"]["information"]);
                }
                else
                {
                    Console.WriteLine("- {0}{1} | DEF +{2} | {3}",Equ, item["info"]["name"], item["info"]["def"], item["info"]["information"]);
                }
            }
        }
    }
}