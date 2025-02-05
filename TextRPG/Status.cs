namespace TextRPG;

public class Status
{
    static Town _town = new Town();
    public void ShowStatus(Player player)
    {

        float addAtk = 0;
        float addDef = 0;
        float playerAtk = player.Attack;
        float playerDef = player.Defense;
        
        string addAtkStr = "";
        string addDefStr = "";
        
        addAtk += player.AddAttack;
        addDef += player.AddDefense;

        if (addAtk > 0)
        {
            addAtkStr = string.Format("(+{0})", addAtk);
            playerAtk += addAtk;
        }
        
        if (addDef > 0)
        {
            addDefStr = string.Format("(+{0})", addDef);
            playerDef += addDef;
        }
        
        Console.WriteLine("Lv. {0}", player.playerLevel);
        Console.WriteLine("{0} ( {1} )", player.playerName, player.playerJob.Values.First());
        Console.WriteLine("ATK: {0} {1}", playerAtk, addAtkStr);
        Console.WriteLine("DEF: {0} {1}", playerDef, addDefStr);
        Console.WriteLine("H P: {0}", player.HP);
        Console.WriteLine("Gold: {0}G", player.Gold);
        Console.WriteLine("\n0. Back");
        
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        string _input = Console.ReadLine();
        
        if (_input == "0")
        {
            _town.Start();
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            ShowStatus(player);
        }
    }
}
