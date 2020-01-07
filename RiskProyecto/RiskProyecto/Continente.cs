using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;  //import per les anotacions
using System.ComponentModel.DataAnnotations;
namespace RiskProyecto
{
    class Continente
    {
        public int ContinenteID { get; set; }

        public String Nombre { get; set; }

        [Column("bonus_tropas")]
        public int BonusTropas { get; set; }

        [Column("jugador_propietario")]
        public Jugador JugadorID { get; set; }
       
        //Inferida
        public ICollection<Region> Regions { get; set; }

        public Continente()
        {
            this.Regions = new HashSet<Region>();
            
        }

    }
}
