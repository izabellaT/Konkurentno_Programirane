using System;
using System.Threading;

namespace Task6
{
    class Program
    {
        static Random random = new Random();
        static void Player1()
        {
            int currentPoints = 0;
            int endPoints = 100;
            while (currentPoints <= endPoints)
            {
                currentPoints += random.Next(1, 10);
                Console.WriteLine($"Player 1 points : {currentPoints}");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("Player 1 finished!");
        }
        static void Player2()
        {
            int currentPoints = 0;
            int endPoints = 100;
            while (currentPoints <= endPoints)
            {
                currentPoints += random.Next(1, 10);
                Console.WriteLine($"Player 2 points : {currentPoints}");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("Player 2 finished!");
        }
        static void Main(string[] args)
        {
            Thread player1 = new Thread(Player1);
            Thread player2 = new Thread(Player2);
            player1.Start(); player2.Start();
        }
    }
}
