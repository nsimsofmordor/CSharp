using System;

// TODO:
// 1. implement snakes and ladders
// 2. Fix the random rolls being the same for each player
// 3. Fix pos 2 adding with its rolls incorrectly

namespace SnakesAndLaddersGame
{
    class Game
    {
        static void Main(string[] args)
        {

            bool play, stopgame; //game control

            play = Play();


            Random rnd = new Random();



            // Game starts //
            while (play)
            {
                
                int p1_pos = 1, p2_pos = 1, p1_roll = 0, p2_roll = 0; // reset variables

                Console.WriteLine("Game in progress");
                Instructions();

                while (p1_pos != 25 && p2_pos != 25)
                {

                    // Player 1 Turn
                    Console.WriteLine("\n-------Player 1's turn-------");
                    Console.WriteLine($"Player 1 sits at position: {p1_pos}");
                    Console.WriteLine("\n(Hit the enter key to roll)");

                    p1_roll = rnd.Next(1, 7);

                    Console.ReadLine();
                    Console.WriteLine($"Player 1 rolled a {p1_roll}");

                    // Does the roll + pos exceed 25 -- if so overide with new position
                    p1_pos = OverCheck(p1_pos, p1_roll);

                    // Does the roll + pos == 25? -- if so stop the game
                    stopgame = WinCheck(p1_pos, p1_roll);
                    if (stopgame)
                    {
                        goto end;
                    }

                    // Include function to check for snakes -- return and output to player new position
                    // Include function to check for ladders-- return and output to player new position

                    // otherwise add the roll to the position and let player 2 roll
                    p1_pos += p1_roll;
                    Console.WriteLine($"\nPlayer 1 lands on {p1_pos}");

                    ////////////////////////////////////////////////////////////////

                    // Player 2 Turn
                    Console.WriteLine("\n-------Player 2's turn-------");
                    Console.WriteLine($"Player 2 sits at position: {p2_pos}");

                    Console.WriteLine("\n(Hit the enter key to roll)");
                    p2_roll = rnd.Next(1, 7);
                    Console.ReadLine();
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

                    // otherwise add the roll to the position and let player 1 roll
                    p2_pos += p2_roll;
                    Console.WriteLine($"\nPlayer 2 lands on {p2_pos}");
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
            Console.WriteLine("\nEnter instructions and rules here...\n");
        }
        /*Prints out game instructions*/


        static int OverCheck(int player_pos, int player_roll)
        {
            int sum = player_pos + player_roll;
            int new_position;

            if (sum > 25)
            {
                Console.WriteLine($"Whoops! You landed on: {sum} ");
                Console.WriteLine("You have exceeded board position 25");
                new_position = player_pos - (sum - 25);
                Console.WriteLine($"Looks like your have to bounce back {sum - 25} positions");
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
            if (sum == 25)
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
