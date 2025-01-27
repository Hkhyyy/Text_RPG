using System.Runtime.InteropServices.JavaScript;

namespace TextRPG
{
    class Program
    {
        static GameIntro gameIntro = new GameIntro();
        static Town town = new Town();
        
        private static void Main(string[] args)
        {
            gameIntro.Start();
            town.Start();
        }
    }
}