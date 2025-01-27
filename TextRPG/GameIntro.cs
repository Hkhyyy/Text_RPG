namespace TextRPG;

public class GameIntro
{
    public string playerNmae;
    public int playerJob;
    
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
        playerNmae = name;
    }

    void Job()
    {
        Console.WriteLine("Select your job!");
        Console.WriteLine("1. Warrior");
        Console.WriteLine("2. Mage");
        Console.WriteLine("3. Archer");
        Console.WriteLine("4. Thief");
        int job = Convert.ToInt32(Console.ReadLine());
        // input validation
        if (job < 1 || job > 4)
        {
            Console.WriteLine("잘못된 입력입니다.");
            Job();
        }
        else
        {
            switch (job)
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
        playerJob = job;
    }
}