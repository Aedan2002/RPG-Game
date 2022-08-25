using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    /// <summary>
    /// Represent the base elements of an enemy
    /// </summary>
    public class Enemy
    {
        //Will make the narrator's text a different color.
        void ChangeColorGreen(string PrintText)
        {
            Console.WriteLine(PrintText, Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// The health value of the enemy.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// The stun value of the enemy.
        /// </summary>
        public int Stun { get; set; }

        /// <summary>
        /// The name of the enemy.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Determines if this enemy is dead.
        /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        /// Determines if this enemy is stunned.
        /// </summary>
        public bool IsStunned { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="name">The name we want to give to this enemy.</param>
        public Enemy(string name)
        {
            //Set the enemies health.
            Health = 100;

            //Set the enemies stun meter.
            Stun = 100;

            //Set the enemy name.
            Name = name;
        }

        /// <summary>
        /// This gets called when the enemy is hit.
        /// </summary>
        /// <param name="stun_value">The amount of stun damage the enemy will take</param>
        public void GetsStun(int stun_value)
        {
            //Subtract the hit value from the health.
            Stun = Stun - stun_value;


            //Write out that the enemy got hit.
            ChangeColorGreen(Name + " was hit for " + stun_value + " damage! They now have " + Stun + " HP remaining!\n");

            //Check if the enemy is stunned.
            if (Stun <= 0)
            {
                //The enemy is stunned.
                Stunned();
            }
        }

        /// <summary>
        /// This gets called when the enemy is hit.
        /// </summary>
        /// <param name="hit_value">The amount of damage the enemy will take</param>
        public void GetsHit (int hit_value)
        {
            //Subtract the hit value from the health.
            Health = Health - hit_value;


            //Write out that the enemy got hit.
            ChangeColorGreen(Name + " was hit for " + hit_value + " damage! They now have " + Health + " HP remaining!\n");

            //Check if the enemy is dead.
            if (Health <= 0)
            {
                //The enemy is dead
                Die();
            }
        }

        /// <summary>
        /// Called when the enemy is supposed to die.
        /// </summary>
        private void Die()
        {
            //Write to the console that the enemy is dead.
            ChangeColorGreen(Name + " has died!\n");

            //Set the boolean that this enemy has died.
            IsDead = true;
        }

        private void Stunned()
        {
            //Write to the console that the enemy is dead.
            ChangeColorGreen(Name + " is unconcious!\n");

            //Set the boolean that this enemy has died.
            IsStunned = true;
        }
    }
}
