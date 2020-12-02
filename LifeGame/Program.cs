using System;

namespace JeuDeLaVie
{
    static class Program
    {

        static void Main()
        {

            Game game = new Game(11, 50);
            game.RunGameConsole();
        }
    }
}
