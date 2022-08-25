using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    /// <summary>
    /// This class represents the playable character.
    /// </summary>
    public class Player
    {
        //Will make the narrator's text a different color.
        void ChangeColorGreen(string PrintText)
        {
            Console.WriteLine(PrintText, Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// This represents the players health values.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Determines if this enemy is dead.
        /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        /// Determines if the player is guarded
        /// </summary>
        public bool IsGuarding { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Player()
        {
            //Set the health value to 100.
            Health = 100;
        }

        /// <summary>
        /// This gets called when the enemy is hit.
        /// </summary>
        /// <param name="hit_value">The amount of damage the player will take</param>
        public void GetsHit(int hit_value)
        {
            //Check if the player was guarding.
            if (IsGuarding)
            {
                //Write out that  the player guarded the attack.
                ChangeColorGreen(Name + " dodged the attack, taking no damage!\n");

                //Remove the guard.
                IsGuarding = false;
            }
            else
            {
                //Subtract the hit value from the health.
                Health = Health - hit_value;

                //Write out that the player got hit.
                ChangeColorGreen(Name + " was hit for " + hit_value + " damage! You now have " + Health + " HP remaining!\n");
            }

            //Check if the player is dead.
            if (Health <= 0)
            {
                //The player is dead
                Die();
            }
        }

        /// <summary>
        /// Heals the player with the amount to heal.
        /// </summary>
        /// <param name="amount_to_heal">The number amount to heal the player</param>
        public void Heal(int amount_to_heal)
        {
            //Heal the player by adding the amount to heal to the player's health.
            Health = (Health + amount_to_heal > 100) ? 100 : (Health + amount_to_heal);

            //Let the player know his new health value
            ChangeColorGreen(Name + " has healed " + amount_to_heal + " HP! You now have " + Health + " HP remaining!\n");
        }

        /// <summary>
        /// Called when the player is supposed to die.
        /// </summary>
        private void Die()
        {
            //Write to the console that the player is dead.
            ChangeColorGreen(Name + " has died!\n");

            //Set the boolean that this player has died.
            IsDead = true;
        }
    }
}
