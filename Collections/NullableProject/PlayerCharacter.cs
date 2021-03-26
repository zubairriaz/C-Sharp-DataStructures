using System;
using System.Collections.Generic;
using System.Text;

namespace NullableProject
{
    class PlayerCharacter
    {

        private SpecialDefence specialDefence;

        public PlayerCharacter(SpecialDefence specialDefence)
        {
            this.specialDefence = specialDefence;
        }
        public string Name { get; set; }

        public int? DaysSinceLastLogin { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? IsNew { get; set; }

        public int Health { get; set; } = 100;


        public void Hit (int damage)
        {
            
            var damageReduction = specialDefence.CalculateDamageReduction(damage);

            int totalDamageTaken = damage - damageReduction;

            Health -= totalDamageTaken;

            Console.WriteLine($"Heatlth is now at {Health}");



        }
    }
}
