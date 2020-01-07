using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskProyecto
{
    class Dados
    {
        public static void DiceRoll(int natk, int ndef, out int lossatk, out int lossdef)
        {
            int[] atk = new int[natk];
            int[] def = new int[ndef];
            lossatk = 0;
            lossdef = 0;

            Random r = new Random();
            for (int i = 0; i < natk; i++)
            {
                atk[i] = r.Next(1, 7);
            }
            for (int i = 0; i < ndef; i++)
            {
                def[i] = r.Next(1, 7);
            }
            Array.Sort(atk);
            Array.Reverse(atk);
            Array.Sort(def);
            Array.Reverse(def);

            for (int i = 0; i < ndef && i < natk; i++)
            {
                if (atk[i] > def[i]) lossdef++;
                else lossatk++;
            }

        }
    }

}