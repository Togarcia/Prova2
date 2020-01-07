using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;  //import per les anotacions
using System.ComponentModel.DataAnnotations;
namespace RiskProyecto
{
    class Region
    {
        public int RegionID { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Column("Jugador")]
        public Jugador Jugador { get; set; }

        [Column("numero_tropas")]
        public int NTropas { get; set; }

        //Relacion a el mismo agregamos s al final n a n
        public ICollection<Region> Regions { get; set; }

        public ICollection<Region> Regions2 { get; set; }


        //Relacion N-1
        public Continente Continente { get; set; }

        public Region()
        {
            this.Regions = new HashSet<Region>();
            this.Regions2 = new HashSet<Region>();
        }
    }
}
