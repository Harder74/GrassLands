using System;

namespace GrassLands
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GrassLands())
                game.Run();
        }
    }
}
