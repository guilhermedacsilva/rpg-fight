using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assets.Scripts.Sheet
{
    public class Advantages
    {
        private Character character;
        private List<int> list;

        public Advantages(Character character)
        {
            this.character = character;
            list = new List<int>();
        }

        public void ApplyAll()
        {
            Type thisType = this.GetType();
            foreach (int methodNumber in list)
            {
                thisType.GetMethod("Apply" + methodNumber).Invoke(this, null);
            }
        }

        // amplified dodge
        private void Apply0()
        {
            character.dodgePlus += 1;
        }
        // amplified block
        private void Apply1()
        {
            character.blockPlus += 1;
        }
        // amplified parry
        private void Apply2()
        {
            character.parryPlus += 1;
        }
        // amplified movement
        private void Apply3()
        {
            character.movementPlus += 2.5f;
        }
        // damage reduction
        private void Apply4()
        {
            character.damageReductionPlus += 2;
        }
        // fast regeneration
        private void Apply5()
        {
            character.lifeRegen += 1;
        }
        // obscure
        private void Apply6()
        {
            character.hardToTarget += 3;
        }
        // consciousness recovery
        private void Apply7()
        {
            character.resistanceStun += 3;
        }
        // die resistance
        private void Apply8()
        {
            character.resistanceDie += 2;
        }
        // healthy
        private void Apply9()
        {
            character.resistanceStun += 1;
            character.staminaRegenPlus += 1;
        }
        // combat reflexes
        private void Apply10()
        {
            character.dodgePlus += 1;
            character.blockPlus += 1;
            character.parryPlus += 1;
        }
    }
}
