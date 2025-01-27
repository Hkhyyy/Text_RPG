namespace TextRPG
{
    class Program
    {
        static Town _town = new Town();
        
        private static void Main(string[] args)
        {
            if (Global.GameIntro.playerName == null)
            {
                Global.GameIntro.Start();
            }
            _town.Start();
        }
    }
}