using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;  //import per les anotacions
using System.ComponentModel.DataAnnotations;

namespace RiskProyecto
{
    class Jugador
    {
        public int JugadorID { get; set; }  //assumeix per el nom que es la ID

        [Column("orden_tirada")]
        public int OrdrenTirada { get; set; }

        [Column("cantidad_regiones")]
        public int CantRegiones { get; set; }

        [Column("contador_victorias")]
        public int ContadorVictorias { get; set; }
        //N-1
        public ICollection<Region> Regions { get; set; }
        //N-1
        public ICollection<Continente> Continentes{ get; set; }

        public Jugador()
        {
            this.Regions = new HashSet<Region>();
            this.Continentes = new HashSet<Continente>();
        }
    }
}
