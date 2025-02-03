namespace TextRPG;

public class Status
{
    static Town _town = new Town();
    public void ShowStatus()
    {
        // List<Dictionary<string, dynamic>>_inventory = Global.GameIntro.playerInventory;
        // 착용중인 아이템이 있으면 맞는 스텟이 추가되어야 함
        // ex) ATK: 10 (+5)
        // 각 스텟 별 추가 능력치 변수 설정 
        int addATK = 0;
        int addDEF = 0;
        int addHP = 0;

        // foreach (var item in _inventory)
        // {
        //     item["info"][""]
        // }
        
        Console.WriteLine("Lv. {0}", Player.playerLevel);
        Console.WriteLine("{0} ( {1} )", Player.playerName, Player.playerJob.Values.First());
        Console.WriteLine("ATK: {0}", Player.Attack);
        Console.WriteLine("DEF: {0}", Player.Defense);
        Console.WriteLine("H P: {0}", Player.HP);
        Console.WriteLine("Gold: {0}", Player.Gold);
        Console.WriteLine("\n0. Back");
        
        string _input = Console.ReadLine();
        
        if (_input == "0")
        {
            _town.Start();
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            ShowStatus();
        }
    }
}
