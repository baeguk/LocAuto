using System.ComponentModel;

namespace Locacoes.Models
{
    public class Veiculo
    {
        public int ID { get; set; } 

        public int AnoFabricacao { get; set; }  

        public string Combustivel { get; set; }

        public long Kilometragem { get; set; }

        [DisplayName("Modelo")]

        public int ModeloID { get; set; }

        public Modelo? Modelo { get; set; }

    }
}
