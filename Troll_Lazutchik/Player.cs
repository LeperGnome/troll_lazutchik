using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troll_Lazutchik
{
    class Player
    {
        public const int ID = 0 ;
        public bool Alive = true;

        public int Health = 100;
        public int Armor = 0;
        public int Damage;
        public int DodgeChance = 10;

        public int DamageCurrentTime(int inputOppositeArmor, int inputOppositeDodgeChance)
        {
            if(Damage != 8)
            {
                return Optional.GetDamage(Damage, true, inputOppositeArmor, inputOppositeDodgeChance);
            }
            else
            {
                return Optional.GetDamage(Damage, false, inputOppositeArmor, inputOppositeDodgeChance);
            }
        }        
    }
}
