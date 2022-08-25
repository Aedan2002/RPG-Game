using System;

namespace RPG_Game
{
    class Program
    {
        /// <summary>
        /// This is the game.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Will make the narrator's text a different color.
            void ChangeColorGreen(string PrintText)
            {
                Console.WriteLine(PrintText, Console.ForegroundColor = ConsoleColor.Green);
                Console.ForegroundColor = ConsoleColor.White;
            }

            try
            {
                List<int> intList = new List<int>();

                intList.Add(1);
                intList.Add(2); 
                intList.Add(3);
                intList.Add(4);
                intList.Add(5);
                intList.Add(6);

                for (int i = 0; i < intList.Count; i++)
                {
                    Console.WriteLine(intList[i]);
                }


                //Create and score the random class.
                Random random = new Random();

                //Output the text stating that we want the players name.
                ChangeColorGreen("What is your name?\n");

                //Create the player character and stores their name.
                Player player = new Player()
                {
                    Name = Console.ReadLine()
                };

                //Let the player know their name.
                ChangeColorGreen("\nThank you for entering your name, " + player.Name + ".\n");

                //Create a variable to track if the first enemy.
                Enemy firstEnemy = new Enemy("Outer Heaven Soldier");

                //Perform the battle game loop.
                GameLoop(firstEnemy, random, player, 50, 25, 25, 25);

                //Check if the player was the one who died.
                if (!player.IsDead)
                {
                    //Create the boss character.
                    Boss_Enemy boss = new Boss_Enemy();

                    //Perform the battle game loop.
                    GameLoop(boss, random, player, 50, 25, 45, 40);

                    //Check if the player was the one who died.
                    if (!player.IsDead)
                    {
                        //The player won the game!
                        ChangeColorGreen("MISSION ACCOMPLISHED. Excellent " + player.Name + "!");
                    }
                    else
                    {
                        //The player is dead. Let the user know the game is over.
                        GameOver();
                    }
                }
                else
                {
                    //The player is dead. Let the user know the game is over.
                    GameOver();
                }
            }
            catch (Exception e)
            {
                //Log the error to the console.
                ChangeColorGreen(e.Message);
            }
        }

        /// <summary>
        /// Writes out what happens when the game is over
        /// </summary>
        private static void GameOver()
        {
            //Will make the narrator's text a different color.
            void ChangeColorGreen(string PrintText)
            {
                Console.WriteLine(PrintText, Console.ForegroundColor = ConsoleColor.Green);
                Console.ForegroundColor = ConsoleColor.White;
            }

            //The player is dead. Let the user know the game is over.
            ChangeColorGreen("GAME OVER");
        }

        /// <summary>
        /// The main game loop that allows the player to make actions during combat
        /// </summary>
        /// <param name="enemy">The enemy that player will attack.</param>
        /// <param name="random">The random number generator we will use to generate random numbers.</param>
        /// <param name="player">The player we are playing as.</param>
        /// <param name="player_max_stun_power">The max amount the player can stun for.</param>
        /// <param name="player_max_attack_power">The max amount the player can attack for.</param>
        /// <param name="max_heal">The max amount the player can heal.</param>
        /// <param name="max_attack_power">The max amount the enemy can attack for.</param>
        private static void GameLoop(Enemy enemy, Random random, Player player, int player_max_stun_power, int player_max_attack_power, int max_heal, int max_attack_power)
        {
            //Will make the narrator's text a different color.
            void ChangeColorGreen(string PrintText)
            {
                Console.WriteLine(PrintText, Console.ForegroundColor = ConsoleColor.Green);
                Console.ForegroundColor = ConsoleColor.White;
            }

            //Write out to the screen about the enemy attack.
            ChangeColorGreen(player.Name + ", you have encountered a " + enemy.Name + "!\n");

            //While the first enemy is not dead or stunned, repeat the playable cycle.
            while (!enemy.IsDead && !enemy.IsStunned && !player.IsDead)
            {
                //Write out to the screen your options.
                Console.WriteLine("What would you like to do?\n1.) Perform CQC\n2.) Fire Rifle\n3.) Defend\n4.) Perform first aid.\n");

                //Store what action the player chose.
                string playersAction = Console.ReadLine();

                //Check what action the player took.
                switch (playersAction)
                {
                    case "1":
                        //Write out the we chose 1.
                        ChangeColorGreen("\nYou chose to hit " + enemy.Name + " once!\n");

                        //Apply the attack damage to the enemy.
                        enemy.GetsStun(random.Next(15, player_max_stun_power));

                        break;
                    case "2":
                        //Write out the we chose 1.
                        ChangeColorGreen("\nYou chose to fire at the " + enemy.Name + " with your rifle!\n");

                        //Apply the attack damage to the enemy.
                        for (int i = 0; i < 3; i++)
                        {
                            enemy.GetsHit(random.Next(10, player_max_attack_power));
                        }

                        break;
                    case "3":
                        //Write out the we chose 3.
                        ChangeColorGreen("\nYou chose to defend against attacks!\n");

                        //Set that the player is guarding.
                        player.IsGuarding = true;

                        break;
                    case "4":
                        //Write out the we chose 4.
                        ChangeColorGreen("\nYou chose to perform first aid!\n");

                        //Apply the heal value to the player.
                        player.Heal(random.Next(20, max_heal));

                        break;
                    default:
                        //What happens when the player makes an invalid choice.
                        ChangeColorGreen("You froze up, unable to decide what to do.\n");

                        break;
                }

                //Make sure the enemy is not dead.
                if (!enemy.IsDead)
                {
                    //Have the enemy attack the player.
                    player.GetsHit(random.Next(10, max_attack_power));
                }
            }
        }
    }
}