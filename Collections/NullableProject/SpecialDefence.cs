using System;
using System.Collections.Generic;
using System.Text;

namespace NullableProject
{
    public abstract class SpecialDefence
    {
        public abstract int CalculateDamageReduction(int totalDamage);
        public static NullDefence Null { get; } = new NullDefence();





        public class NullDefence : SpecialDefence
        {
            public override int CalculateDamageReduction(int totalDamage)
            {
                return 0;
            }
        }
    }
}
