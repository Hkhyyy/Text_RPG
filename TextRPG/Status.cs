namespace TextRPG;

public class Status
{
    public void ShowStatus()
    {
        Console.WriteLine("Lv. 01");
        Console.WriteLine("{0} ( {1} )", Global.GameIntro.playerName, Global.GameIntro.playerJob.Values.First());
        Console.WriteLine("ATK: 10");
        Console.WriteLine("DEF: 5");
        Console.WriteLine("H P: 50");
        Console.WriteLine("Gold: 1500G");
    }
}
