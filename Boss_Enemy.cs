using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    /// <summary>
    /// Represents the boss enemy in the game.
    /// </summary>
    public class Boss_Enemy : Enemy
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        public Boss_Enemy() : base("Big Boss")
        {
            //Set the boss enemies health.
            Health = 150;
        }
    }
}
