using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Sheet
{
    public class Costs
    {
        private Character character;
        public int total;
        public int st;
        public int dx;
        public int iq;
        public int ht;
        

        public Costs(Character c)
        {
            character = c;
        }

        public void CalcAll()
        {
            st = (character.st - 10) * 10;
            dx = (character.dx - 10) * 20;
            iq = (character.iq - 10) * 20;
            ht = (character.ht - 10) * 10;
            total = st + dx + iq + ht;
        }
    }
}
