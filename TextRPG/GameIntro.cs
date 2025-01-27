namespace TextRPG;

public class GameIntro
{
    public string playerName { get; set; }
    // playerJob 는 키 벨류 형태
    public Dictionary<int, string> playerJob { get; set; }
    
    public void Start()
    {
        Name();
        Job();
    }

    void Name()
    {
        Console.WriteLine("Welcome to the Sparta Dungeon!");
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!", name);
        playerName = name;
    }

    void Job()
    {
        // 직업 리스트
        List<string> jobs = new List<string> { "Warrior", "Mage", "Archer", "Thief" };
        
        Console.WriteLine("Select your job!");
        foreach (var job in jobs)
        {
            Console.WriteLine("{0}. {1}", jobs.IndexOf(job) + 1, job);
        }
        int _selectJob = Convert.ToInt32(Console.ReadLine());
        // input validation
        if (_selectJob < 1 || _selectJob > 4)
        {
            Console.WriteLine("잘못된 입력입니다.");
            Job();
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
        playerJob = new Dictionary<int, string> { { (_selectJob - 1), jobs[_selectJob - 1] } };
        
    }
}