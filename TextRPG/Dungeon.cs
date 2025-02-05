namespace TextRPG;

public class Dungeon
{
    public static Town _town = new Town();
    Player player = GameState.CurrentPlayer;
    public void Start()
    {
        // 던전 클리어 횟수
        int Count = player.Exp;
        // 레벨
        int Level = player.playerLevel;
        Console.WriteLine("던전에 입장했습니다.");
        Console.WriteLine("던전을 클리어하여 경험치를 획득하세요.\n");
        
        Console.WriteLine("현재 레벨: " + Level);
        
        Console.WriteLine("\n1. 전투 시작");
        Console.WriteLine("0. 뒤로 가기");
        
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        
        string input = Console.ReadLine();
        
        switch(input)
        {
            case "1":
                Battle();
                break;
            case "0":
                _town.Start();
                break;
            default:
                Console.WriteLine("잘못된 입력입니다.\n");
                Start();
                break;
        }
    }

    void Battle()
    {
        // 전투 시작
        Console.WriteLine("전투 시작");
        Console.WriteLine("전투 중입니다.");
        Console.WriteLine("전투가 종료되면 던전으로 돌아갑니다.\n");

        // 로딩 바 구현
        Console.WriteLine("전투 시작");
        for (int i = 0; i < 30; i++)
        {
            System.Threading.Thread.Sleep(150); // 150ms 마다 한 번씩 진행
            Console.Write("#"); 
        }
        Console.WriteLine();  

        Console.WriteLine("전투가 종료되었습니다.\n");
        
        player.Exp += 1;
        Console.WriteLine("경험치를 획득했습니다. (현재 경험치: {0})", player.Exp);
        
        if (player.Exp > player.playerLevel)
        {
            player.Exp = 0;
            player.playerLevel += 1;
            Console.WriteLine("레벨업 하였습니다. (현재 레벨: {0})", player.playerLevel);
            player.Attack += 0.5f;
            player.Defense += 1;
        }
        Start();
    }

}