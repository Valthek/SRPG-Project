using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities.Attributes
{
    public class Health
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public int Heal(int healValue)
        {
            if (CurrentHealth + healValue < MaxHealth)
            {
                CurrentHealth += healValue;
                return healValue;
            }
            healValue = MaxHealth - CurrentHealth;
            CurrentHealth = MaxHealth;
            return healValue;
        }

        public int Damage(int damageValue)
        {
            if (CurrentHealth - damageValue > 0)
            {
                CurrentHealth -= damageValue;
                return damageValue;
            }
            damageValue = CurrentHealth;
            CurrentHealth = 0;
            return damageValue;
        }
    }
}
