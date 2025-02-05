namespace TextRPG;

public class Player
{
    public int playerLevel { get; set; }
    public string playerName { get; set; }
    public Dictionary<int, string> playerJob { get; set; }
    public float Attack { get; set; }
    public float AddAttack { get; set; }
    public float Defense { get; set; }
    public float AddDefense { get; set; }
    public int HP { get; set; }
    public int AddHP { get; set; }
    public float Gold { get; set; }
    public int Exp { get; set; }
    public List<Item> Inventory { get; set; }

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
        Exp = 0;
        Inventory = new List<Item>();
    }

    public void Setjob(Dictionary<int, string> job)
    {
        playerJob = job;
    }

    // 아이템 획득
    public void GetItem(Item item)
    {
        Inventory.Add(item);
    }
    
    // 아이템 장착
    public void EquipItem(Item item)
    {
        // 기존에 장착된 아이템중 동일한 타입의 아이템이 있다면 해제하고 장착
        foreach (var i in Inventory)
        {
            if (i.Type == item.Type && i.IsEquipped)
            {
                UnequipItem(i);
            }
        }
        item.IsEquipped = true;
        item.ApplyEffect(this);
    }

    // 아이템 해제
    public void UnequipItem(Item item)
    {
        item.IsEquipped = false;
        item.ApplyEffect(this);
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
