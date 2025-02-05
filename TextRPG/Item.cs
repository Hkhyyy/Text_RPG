namespace TextRPG;

public abstract class Item
{
    public int Idx { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Information { get; set; }
    public int BuyPrice { get; set; }
    public bool IsSellable { get; set; } = false;
    public bool IsEquipped { get; set; }

    // 아이템 사용 시 플레이어 스탯에 영향을 미치는 메서드
    public abstract void ApplyEffect(Player player);
}

public class Weapon : Item
{
    public int Attack { get; set; }
    
    public override void ApplyEffect(Player player)
    {
        if (IsEquipped)
        {
            player.AddAttack += Attack;
        }
        else
        {
            player.AddAttack -= Attack;
        }
    }
}

public class Armor : Item
{
    public int Defense { get; set; }
    
    public override void ApplyEffect(Player player)
    {
        if (IsEquipped)
        {
            player.AddDefense += Defense;
        }
        else
        {
            player.AddDefense -= Defense;
        }
    }
}
