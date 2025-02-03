namespace TextRPG;

public class Player
{
    public static int playerLevel { get; set; }
    public static string playerName { get; set; }
    public static Dictionary<int, string> playerJob { get; set; }
    public static float Attack { get; set; }
    public static float AddAttack { get; set; }
    public static float Defense { get; set; }
    public static float AddDefense { get; set; }
    public static int HP { get; set; }
    public static int AddHP { get; set; }
    public static int Gold { get; set; }
    public static List<Item> Inventory { get; set; }

    public Player(string name)
    {
        playerLevel = 1;
        playerName = name;
        Attack = 10;
        AddAttack = 0;
        Defense = 5;
        AddDefense = 0;
        HP = 50;
        AddHP = 0;
        Gold = 1500;
        Inventory = new List<Item>();
    }

    public void Setjob(Dictionary<int, string> job)
    {
        playerJob = job;
    }

    // 아이템 획득
    public void GetItem(Item item)
    {
        item.ApplyEffect(this);
        Inventory.Add(item);
    }
    
    // 아이템 장착
    public void EquipItem(Item item)
    {
        item.IsEquipped = true;
        item.ApplyEffect(this);
    }

    // 아이템 해제
    public void UnequipItem(Item item)
    {
        item.IsEquipped = false;
        item.ApplyEffect(this);
        Inventory.Remove(item);
    }

    // 아이템 판매
    public void SellItem(Item item)
    {
        item.IsEquipped = false;
        item.ApplyEffect(this);
        Inventory.Remove(item);
    }

    // 아이템 구매
    public void BuyItem(Item item)
    {
        Inventory.Add(item);
        item.ApplyEffect(this);
    }
}
