using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskProyecto
{
    class Program
    {

        static void Main(string[] args)
        {
            int turno = 1;
            bool fin = false;
            Services.Init();
            String continuar = "S";
            do
            {
                Console.WriteLine("Turno jugador: "+ turno );
                Services.TurnBeggining(turno);


                do
                {
                    Services.Attack(turno);
                    Console.WriteLine("Seguir atacando? S/N");
                    continuar = Console.ReadLine();


                } while (continuar == "S");
                fin = Services.Chek();
                if (fin == true)
                {
                    Services.ganador(turno);
                }
                else {
                    Services.Reassing(turno);
                    turno = Services.turno(turno);
                }
                
                
            } while (!fin);


       
          
        }
    }
}
