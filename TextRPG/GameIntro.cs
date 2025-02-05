namespace TextRPG;

public class GameIntro
{
    public void Start()
    {
        string name = Name();
        Player player = new Player(name);
        Job(player);
    }

    string Name()
    {
        Console.WriteLine("Welcome to the Sparta Dungeon!");
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!", name);
        return name;
    }

    void Job(Player player)
    {
        // 직업 리스트
        List<string> jobs = new List<string> { "Warrior", "Mage", "Archer", "Thief" };
        
        Console.WriteLine("Select your job!");
        foreach (var job in jobs)
        {
            Console.WriteLine("{0}. {1}", jobs.IndexOf(job) + 1, job);
        }

        try
        {
            int _selectJob = Convert.ToInt32(Console.ReadLine());
            // input validation
            if (_selectJob < 1 || _selectJob > 4)
            {
                Console.WriteLine("잘못된 입력입니다.\n");
                Job(player);
            }
            else
            {
                switch (_selectJob)
                {
                    case 1:
                        Console.WriteLine("You are a Warrior!");
                        break;
                    case 2:
                        Console.WriteLine("You are a Mage!");
                        break;
                    case 3:
                        Console.WriteLine("You are an Archer!");
                        break;
                    case 4:
                        Console.WriteLine("You are a Thief!");
                        break;
                }
            }
            // 위에서 선택한 값이 playerJob에 저장됨
            Dictionary<int, string> playerJob = new Dictionary<int, string> { { (_selectJob - 1), jobs[_selectJob - 1] } };
            player.Setjob(playerJob);
            
            Weapon weapon = new Weapon
            {
                Idx = 0,
                Name = "낡은 검",
                Type = "무기",
                Attack = 10,
                Information = "어쩌구 저쩌구",
                BuyPrice = 100,
            };
            
            Armor armor = new Armor
            {
                Idx = 1,
                Name = "낡은 방패",
                Type = "방어구",
                Defense = 5,
                Information = "어쩌구 저쩌구",
                BuyPrice = 50,
            };
            
            player.GetItem(weapon);
            player.GetItem(armor);
            
            GameState.CurrentPlayer = player;
        }
        catch (Exception e)
        {
            Job(player);
        }
    }
}