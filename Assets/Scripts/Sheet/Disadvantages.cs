using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Sheet
{
    public class Disadvantages
    {
        private Character character;
        private List<int> disadvantageList;

        public void Init(Character character, List<int> disadvantageList)
        {
            this.character = character;
            this.disadvantageList = disadvantageList;
            character.disadvantages = this;
        }

        public void ApplyAll()
        {
            Type thisType = this.GetType();
            foreach (int methodNumber in disadvantageList)
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
            character.staminaRegenMult = 0.5;
        }
        // consciousness loss
        private void Apply5()
        {
            character.resistanceStun -= 3;
        }
        // invertebrate
        private void Apply6()
        {
            character.weightMult = 0.25;
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
