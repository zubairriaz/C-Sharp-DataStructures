using System;
using System.Collections.Generic;
using System.Text;

namespace NullableProject
{
    class IIronDefense : SpecialDefence
    {
        public override int CalculateDamageReduction(int totalDamage)
        {
            return 5;
        }
    }
}
