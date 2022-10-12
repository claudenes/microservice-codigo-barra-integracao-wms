using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CodigoBarrasIntegrarDTO
    {
        public int PecaCodBarra_ID { get; set; }
        public int Peca_ID { get; set; }
        public string Peca_CodBarra_CdBarras { get; set; }
        public bool Cancelar { get; set; }
    }
}
