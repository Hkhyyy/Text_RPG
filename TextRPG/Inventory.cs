namespace TextRPG;

public class Inventory
{
    static Town _town = new Town();
    public Player player = GameState.CurrentPlayer;
    public void ShowInventory()
    {
        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
        Console.WriteLine("[아이템 목록]");

        ItemList();
        
        Console.WriteLine("\n1. 장착관리");
        Console.WriteLine("0. 나가기");
        
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
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
        List<Item>_inventory = player.Inventory;
        
        Console.WriteLine(_inventory.Count);
        
        Console.WriteLine("인벤토리 - 장착관리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
        Console.WriteLine("[아이템 목록]");
        
        ItemList(true);
        
        Console.WriteLine("\n0. 나가기");
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        
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
        
        Item selectedItem = _inventory[input];
        
        if (selectedItem.IsEquipped)
        {
            // 아이템 해제
            player.UnequipItem(selectedItem);
            Console.WriteLine("{0}을(를) 해제했습니다.\n", selectedItem.Name);
        }
        else
        {
            // 아이템 장착
            player.EquipItem(selectedItem);
            Console.WriteLine("{0}을(를) 장착했습니다.\n", selectedItem.Name);
        }
        
        ShowInventory();
    }

    void ItemList(bool type = false)
    {
        List<Item> _inventory = player.Inventory;
        foreach (var item in _inventory.Select((val, index) => (val, index)))
        {
            var val = item.val;
            var index = item.index;
            
            string Equ = "";
            if (val.IsEquipped)
            {
                Equ = "[E]";
            }

            if (val.Type == "무기")
            {
                Weapon weapon = val as Weapon;  // Weapon 타입으로 캐스팅

                if (weapon != null)  // Weapon 타입일 경우
                {
                    if (type)
                    {
                        // type이 true일 경우 더 자세한 정보를 출력
                        Console.WriteLine("- {0} {1}{2} | ATK +{3} | {4}", index + 1, Equ, weapon.Name, weapon.Attack, weapon.Information);
                    }
                    else
                    {
                        // type이 false일 경우 간단히 출력
                        Console.WriteLine("- {0}{1} | ATK +{2} | {3}", Equ, weapon.Name, weapon.Attack, weapon.Information);
                    }
                }
            }
            else if (val.Type == "방어구")
            {
                Armor armor = val as Armor;  // Armor 타입으로 캐스팅

                if (armor != null)  // Armor 타입일 경우
                {
                    if (type)
                    {
                        // type이 true일 경우 더 자세한 정보를 출력
                        Console.WriteLine("- {0} {1}{2} | DEF +{3} | {4}", index + 1, Equ, armor.Name, armor.Defense, armor.Information);
                    }
                    else
                    {
                        // type이 false일 경우 간단히 출력
                        Console.WriteLine("- {0}{1} | DEF +{2} | {3}", Equ, armor.Name, armor.Defense, armor.Information);
                    }
                }
            }
        }
    }

}