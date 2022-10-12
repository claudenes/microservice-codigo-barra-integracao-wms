using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CodigoBarrasIntegracoSeniorDTO
    {
        public string usuario { get; set; }
        public string senha { get; set; }
        public CodigoBarrasSeniorDTO codigobarras { get; set; }

        public CodigoBarrasIntegracoSeniorDTO()
        {
            codigobarras = new CodigoBarrasSeniorDTO();
        }
    }

    public class CodigoBarrasSeniorDTO
    {
        public int cd_empresa { get; set; }
        public string cd_produto { get; set; }
        public string cd_barras { get; set; }
        public int cd_situacao { get; set; }
        public int tp_codigo_barras { get; set; }
        public int qt_embalagem { get; set; }
        public string id_codigo_principal { get; set; }

        public CodigoBarrasSeniorDTO()
        {
            id_codigo_principal = "S";
            qt_embalagem = 1;
            tp_codigo_barras = 13;
        }
    }
}
