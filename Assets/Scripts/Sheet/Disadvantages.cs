using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Sheet
{
    public class Disadvantages
    {
        private Character character;
        private List<int> list;

        public Disadvantages(Character character)
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

        // jumbled
        private void Apply0()
        {
            character.dxActual -= 1;
        }
        // beastly
        private void Apply1()
        {
            character.iqActual -= 1;
        }
        // disabled leg
        private void Apply2()
        {
            character.movementPlus -= 1;
        }
        // defective sight
        private void Apply3()
        {
            character.dxActual -= 1;
            character.sightPlus -= 1;
        }
        // overweight
        private void Apply4()
        {
            character.resistanceStun -= 1;
            character.staminaRegenMult = 0.5f;
        }
        // consciousness loss
        private void Apply5()
        {
            character.resistanceStun -= 3;
        }
        // invertebrate
        private void Apply6()
        {
            character.weightMult = 0.25f;
        }
        // weak hand
        private void Apply7()
        {
            character.blockPlus -= 1;
            character.parryPlus -= 1;
            character.dxAttackClosePlus -= 1;
            character.dxAttackFarPlus -= 1;
        }
        // one-eyed
        private void Apply8()
        {
            character.dxAttackClosePlus -= 1;
            character.dxAttackFarPlus -= 3;
        }
    }
}
