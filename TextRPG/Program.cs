namespace TextRPG
{
    class Program
    {
        static Town _town = new Town();
        
        private static void Main(string[] args)
        {
            Global.GameIntro.Start();
            _town.Start();
        }
    }
}