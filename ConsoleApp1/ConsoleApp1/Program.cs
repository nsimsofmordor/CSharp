using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            bool play, stopgame;

            play = Play();

            // Game starts //
            while (play)
            {

                int p1_pos = 1, p2_pos = 1, p1_roll = 0, p2_roll = 0;

                Console.WriteLine("Game in progress");
                Instructions();

                while (p1_pos != 100 && p2_pos != 100)
                {
                    // Player 1 Turn
                    Console.WriteLine("-------Player 1's turn-------");
                    p1_roll = Roll();
                    Console.WriteLine($"Player 1 rolled a {p1_roll}");

                    // Does the roll + pos exceed 100 -- if so overide with new position
                    p1_pos = OverCheck(p1_pos, p1_roll);

                    // Does the roll + pos == 100? -- if so stop the game
                    stopgame = WinCheck(p1_pos, p1_roll);
                    if (stopgame)
                    {
                        goto end;
                    }

                    // Include function to check for snakes -- return and output to player new position
                    // Include function to check for ladders-- return and output to player new position

                    // otherwise add the roll to the position and let player 2 roll
                    p1_pos += p1_roll;
                    Console.WriteLine($"Player 1 lands on {p1_pos}");

                    ////////////////////////////////////////////////////////////////

                    // Player 2 Turn
                    p2_roll = Roll();
                    Console.WriteLine("-------Player 2's turn-------");


                    Console.WriteLine($"Player 2 rolled a {p1_roll}");

                    // Does the roll + pos exceed 100 -- if so overide with new position
                    p2_pos = OverCheck(p2_pos, p2_roll);

                    // Does the roll + pos == 100? -- if so stop the game
                    stopgame = WinCheck(p2_pos, p2_roll);
                    if (stopgame)
                    {
                        goto end;
                    }

                    // Include function to check for snakes
                    // Include function to check for ladders

                    // otherwise add the roll to the position and let player 2 roll
                    p2_pos += p2_roll;

                }



















            end:
                Console.WriteLine("Game finishes");
                Console.WriteLine("Play again?");
                play = Play();
            }
        }


        static bool Play()


        {
            Console.WriteLine("Wanna Play? 1 for yes, 2 for no");
            int x = Convert.ToInt32(Console.ReadLine());
            while (x != 1 && x != 2) // if user enters invalid
            {
                Console.WriteLine("Wanna Play? 1 for yes, 2 for no"); // keep asking for correct input
                x = Convert.ToInt32(Console.ReadLine());
            }
            if (x == 1)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Thanks for playing");
                return false;
            }
        }
        /* Asks the player if they wish to play
         * If player wants to, return bool true
         * If not return bool false 
         */

        static void Instructions()
        {
            Console.WriteLine("Enter instructions and rules here...");
        }
        /*Prints out game instructions*/

        static int Roll()
        {
            Random rnd = new Random();
            int roll = rnd.Next(1, 7);
            return roll;
        }
        /* returns a dice roll (1-6) */

        static int OverCheck(int player_pos, int player_roll)
        {
            int sum = player_pos + player_roll;
            int new_position;

            if (sum > 100)
            {
                Console.WriteLine("You have exceeded board position 100");
                new_position = player_pos - (sum - 100);
                Console.WriteLine($"Your new position is: {new_position}");
                return new_position;
            }
            else
            {
                return player_pos;
            }

        }
        /* Checks to see if player rolls past 100
         * If so, bounce back remaining roll and return new position
         * Otherwise return position back */

        static bool WinCheck(int player_pos, int player_roll)
        {
            int sum = player_pos + player_roll;
            if (sum == 100)
            {
                Console.WriteLine("You have Won!!!");
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
