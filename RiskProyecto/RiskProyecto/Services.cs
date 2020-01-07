using System;
using System.Collections.Generic;
using System.Linq;

namespace RiskProyecto
{

    class Services
    {
       

        static  Context ctx = new Context();

        public static void Init()
        {
            //Contientes
            var Africa = new Continente() { Nombre = "Africa", BonusTropas = 2 };
            var Europa = new Continente() { Nombre = "Europa", BonusTropas = 3 };
            //Jugadores
            var toni = new Jugador() { OrdrenTirada = 1 };
            var oscar = new Jugador() { OrdrenTirada = 2 };

            //Regiones Africa
            var Congo = new Region() { Nombre = "Congo", NTropas = 10 };
            var Madagascar = new Region() { Nombre = "Madadgascar", NTropas = 1 };
            var Egipto = new Region() { Nombre = "Egipto", NTropas = 10 };
            //Regiones Europa
            var Escandinavia = new Region() { Nombre = "Escandinavia", NTropas = 10 };
            var Islandia = new Region() { Nombre = "Islandia", NTropas = 2 };
            var Ucrania = new Region() { Nombre = "Ucrania", NTropas = 2 };

            //Asignacion regiones a continentes Africa
            Africa.Regions.Add(Congo);
            Africa.Regions.Add(Madagascar);
            Africa.Regions.Add(Egipto);
            
            //Asignacion regiones a continentes Europa
            Europa.Regions.Add(Escandinavia);
            Europa.Regions.Add(Islandia);
            Europa.Regions.Add(Ucrania);
            
            //Vecino Congo
            Congo.Regions.Add(Madagascar);

            //Vecino Madagascar
            Madagascar.Regions.Add(Congo);
            Madagascar.Regions.Add(Egipto);
            Madagascar.Regions.Add(Escandinavia);

            //Vecino Egipto
            Egipto.Regions.Add(Madagascar);

            //Vecnio Islandia
            Islandia.Regions.Add(Escandinavia);
            Islandia.Regions.Add(Ucrania);

            //Vecnio Ecandinavia
            Escandinavia.Regions.Add(Islandia);
            Escandinavia.Regions.Add(Madagascar);
            
            //Vecnio Ucrania
            Ucrania.Regions.Add(Islandia);

            //Regiones j1
            toni.Regions.Add(Congo);
            toni.Regions.Add(Egipto);
            toni.Regions.Add(Escandinavia);

            //Regiones j2
            oscar.Regions.Add(Islandia);
            oscar.Regions.Add(Ucrania);
            oscar.Regions.Add(Madagascar);

            toni.CantRegiones = toni.Regions.Count();
            oscar.CantRegiones = toni.Regions.Count();
            //toni.Continentes.Add(Africa);

            ctx.Continente.Add(Africa);
            ctx.Continente.Add(Europa);

            ctx.Region.Add(Congo);
            ctx.Region.Add(Madagascar);
            ctx.Region.Add(Egipto);
            ctx.Region.Add(Islandia);
            ctx.Region.Add(Escandinavia);
            ctx.Region.Add(Ucrania);

            ctx.Jugador.Add(toni);
            ctx.Jugador.Add(oscar);

            ////Mapa Risk
            /////////////////////////
            ////
            ////    1 2 3
            ////    * * *
            ////     /
            ////    * * *
            ////    4 5 6
            ////
            /////////////////////////
            ///  1.Congo 2.Madagascar 3.Egipto
            ///  4.Escandinavia 5.Islandia 6.Ucrania

            ctx.SaveChanges();
            Console.WriteLine("Todo Ha salido a pedir de Milhouse");
        }


        public static void TurnBeggining(int turno)
        {

            Jugador ju = ctx.Jugador.Find(turno);
      
     

            List<Region> regiones = ctx.Region.ToList();
            List<String> idRegiones = new List<String>();
            Console.WriteLine("INICIO TURNO POSICIONAMIENTO TROPAS BONUS");
            List<Continente> continetes = ctx.Continente.ToList();
            Console.WriteLine("////Mapa Risk");
            Console.WriteLine("/////////////////////////");
            Console.WriteLine("////");
            Console.WriteLine("////    1 2 3");
            Console.WriteLine("////    * * *");
            Console.WriteLine("////     /");
            Console.WriteLine("////    * * *");
            Console.WriteLine("////    4 5 6");
            Console.WriteLine("////");
            Console.WriteLine("/////////////////////////");
            Console.WriteLine("///  1.Congo 2.Madagascar 3.Egipto");
            Console.WriteLine("///  4.Escandinavia 5.Islandia 6.Ucrania");
            ju.CantRegiones = ju.Regions.Count();
            foreach (Region r in regiones)
            {
                if (r.Jugador == ju) { 

                Console.WriteLine("Region" + r.RegionID + r.Nombre + " , tropas disponibles: " + r.NTropas);
                idRegiones.Add(r.RegionID.ToString());
                 }
            }


            int tropasAsignar = (ju.Regions.Count()/3) + 5;
            foreach(Continente c in continetes)
            {
               
                if (c.JugadorID != null)
                {
                   
                    if (c.JugadorID == ju)
                    {
                        Console.WriteLine("Bonus de contiente!! +" + c.BonusTropas + " tropas" );
                        tropasAsignar += c.BonusTropas;
                      
                    }
                }
            }


            String AAsignar;
            do
            {
                Console.WriteLine("Tropas para asignar: " + tropasAsignar);
                AAsignar = Console.ReadLine();

            } while (!idRegiones.Contains(AAsignar));

            Region re = ctx.Region.Find(Int32.Parse(AAsignar));
            re.NTropas += tropasAsignar;

            ctx.SaveChanges();

        }

        public static void Attack(int turno)
        {
            Console.WriteLine("ATAQUE");

            // do
            //  {
            Jugador ju = ctx.Jugador.Find(turno);

                List<Region> regiones = ctx.Region.ToList();
                List<String> idRegiones = new List<String>();
                List<String> idRegionesE = new List<String>();

                List<Continente> continetes = ctx.Continente.ToList();

                Console.WriteLine("Regiones jugador: " + ju.JugadorID + " desde donde quieres atacar?");
                foreach (Region r in regiones)
                {
                    if (r.Jugador == ju)
                    {

                        Console.WriteLine("Region" + r.RegionID + r.Nombre + " , tropas disponibles: " + r.NTropas);
                        idRegiones.Add(r.RegionID.ToString());
                    }
                }


                String AAsignar;
                do
                {
                    AAsignar = Console.ReadLine();

                } while (!idRegiones.Contains(AAsignar));

                Region rAtacant = ctx.Region.Find(Int32.Parse(AAsignar));

            Console.WriteLine("////Mapa Risk");
            Console.WriteLine("/////////////////////////");
            Console.WriteLine("////");
            Console.WriteLine("////    1 2 3");
            Console.WriteLine("////    * * *");
            Console.WriteLine("////     /");
            Console.WriteLine("////    * * *");
            Console.WriteLine("////    4 5 6");
            Console.WriteLine("////");
            Console.WriteLine("/////////////////////////");
            Console.WriteLine("///  1.Congo 2.Madagascar 3.Egipto");
            Console.WriteLine("///  4.Escandinavia 5.Islandia 6.Ucrania");


            Console.WriteLine("Regiones vecinas enemigas cuala quieres atacar?(En el caso de no tener poner 0): ");

                foreach (Region r in rAtacant.Regions)
                {
                    if (r.Jugador != ju)
                    {

                        Console.WriteLine("Region" + r.RegionID + r.Nombre + " , tropas disponibles: " + r.NTropas);
                        idRegionesE.Add(r.RegionID.ToString());

                    }
                }

                String AAsignar2 = " ";
                do
                {
                    AAsignar2 = Console.ReadLine();
                } while (!idRegionesE.Contains(AAsignar2) && AAsignar2 != "0");
            if (AAsignar != "0" && idRegionesE.Contains(AAsignar2))
            {
                Region rDefen = ctx.Region.Find(Int32.Parse(AAsignar2));

                Dados.DiceRoll(Math.Min((rAtacant.NTropas - 1), 3), Math.Min(rDefen.NTropas, 2), out int lossatk, out int lossdef);

                int perAtack = lossatk;
                int perDef = lossdef;

                rAtacant.NTropas -= lossatk;
                rDefen.NTropas -= lossdef;

                Console.WriteLine("Perdidas atacante: " + lossatk + " Perdidas defensor: " + lossdef);

                if (rDefen.NTropas == 0)
                {
                    Conquer(rAtacant.RegionID, rDefen.RegionID);
                }

                ctx.SaveChanges();
            }
            else
            {
                Console.WriteLine("Ataque no realizado");
            }
            //} while (Int32.Parse(Console.ReadLine()) == 0);
        }
        public static void Conquer(int idConAt, int idConDef)
        {
          //  do
           // {

                Region rAtac = ctx.Region.Find(idConAt);
                Region rDefen = ctx.Region.Find(idConDef);
                Jugador jA = ctx.Jugador.Find(rAtac.Jugador.JugadorID);
                Jugador jD = ctx.Jugador.Find(rDefen.Jugador.JugadorID);

                List<Region> regiones = ctx.Region.ToList();
                List<String> idRegiones = new List<String>();
                List<String> idRegionesE = new List<String>();


                rDefen.NTropas = (rAtac.NTropas - 1);
                rAtac.NTropas = 1;
                jD.Regions.Remove(rDefen);
                jA.Regions.Add(rDefen);
                
                ctx.SaveChanges();
                List<Region> regionConti = ctx.Region.Where(i => i.Continente.ContinenteID.ToString() == rDefen.Continente.ContinenteID.ToString()).ToList();
                int totreg = 0;
                foreach(Region re in regionConti)
                {
                    if(re.Jugador == jA)
                    {
                      
                        totreg++;
                    }
                }

            Continente cn = ctx.Continente.Find(Int32.Parse(rDefen.Continente.ContinenteID.ToString()));
                 if (totreg == regionConti.Count())
                {

                Console.WriteLine("CONTINENTE CONQUISTADO!!");

                cn.JugadorID = jA;

                }
                 else {
                cn.JugadorID = null;
            }

                ctx.SaveChanges();
            //} while (Int32.Parse(Console.ReadLine()) == 0);
        }

        public static void Reassing(int turno)
        {

            Console.WriteLine("REPOSICIONANDO TROPAS");

            // do { 
            Jugador ju = ctx.Jugador.Find(turno);

            List<Region> regiones = ctx.Region.ToList();
            List<String> idRegiones = new List<String>();
            List<String> idRegionesE = new List<String>();

            List<Continente> continetes = ctx.Continente.ToList();

            Console.WriteLine("Regiones jugador: " + ju.JugadorID + " desde donde quieres Moverlas?");
            foreach (Region r in regiones)
            {
                if (r.Jugador == ju && r.Regions.Count() >0 && r.NTropas >1)
                {

                    Console.WriteLine("Region" + r.RegionID + r.Nombre + " , tropas disponibles: " + r.NTropas);
                    idRegiones.Add(r.RegionID.ToString());
                }
            }


            String AAsignar;
            do
            {
                AAsignar = Console.ReadLine();

            } while (!idRegiones.Contains(AAsignar));

            Region rEnviador = ctx.Region.Find(Int32.Parse(AAsignar));
            Console.WriteLine("Regiones vecinas aliadas para mover(0 EN CASO DE NO CONTENER VECINOS ALIADOS): ");

            foreach (Region r in rEnviador.Regions)
            {
                if (r.Jugador == ju)
                {

                    Console.WriteLine("Region" + r.RegionID + r.Nombre + " , tropas disponibles: " + r.NTropas);
                    idRegionesE.Add(r.RegionID.ToString());

                }
            }
            ////////Arreglar caso no tener vecinos aliados
            String AAsignar2;
            do
            {
                AAsignar2 = Console.ReadLine();
            } while (!idRegionesE.Contains(AAsignar2) && AAsignar2!="0");
            if (AAsignar != "0" && idRegionesE.Contains(AAsignar2))
            {
                
                    Region rReceptor = ctx.Region.Find(Int32.Parse(AAsignar2));


                    Console.WriteLine("Cuantas tropas?(minimo una a de quedar) ");
                    int aenviar = 0;
                    do
                    {
                        aenviar = Int32.Parse(Console.ReadLine());
                    } while (aenviar < 1 || aenviar >= rEnviador.NTropas);



                    rEnviador.NTropas -= aenviar;
                    rReceptor.NTropas += aenviar;

                    ctx.SaveChanges();

            }
            else
            {
                Console.WriteLine("No es posible");

            }
          //  } while (Int32.Parse(Console.ReadLine()) == 0);
        }
        public static bool Chek()
        {

            bool fin = false;
            // do { 
            List<Jugador> Jugadores = ctx.Jugador.ToList();

            List<Region> regiones = ctx.Region.ToList();
            List<String> idRegiones = new List<String>();
            List<String> idRegionesE = new List<String>();

            foreach(Jugador j in Jugadores)
            {
                if(j.Regions.Count() < 1)
                {
                    fin = true;
                }
            }

            return fin;
            //  } while (Int32.Parse(Console.ReadLine()) == 0);
        }

        public static int turno(int turno)
        {

          
            List<Jugador> Jugadores = ctx.Jugador.ToList();

            if(turno == Jugadores.Count())
            {
                turno = 1;
            }
            else
            {
                turno++;
            }

            return turno;
       
        }
        public static void ganador(int turno)
        {
            
            Jugador jugador = ctx.Jugador.Find(turno);
            Console.WriteLine("Gana jugador" + jugador.JugadorID);
            Console.ReadLine();
        }
    }
}
