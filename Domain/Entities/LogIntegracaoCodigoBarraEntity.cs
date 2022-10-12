using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LogIntegracaoCodigoBarraEntity
    {
        public int Log_Integracao_CodigoBarra_ID { get; set; }
        public int PecaCodBarra_ID { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public int Status { get; set; }

        public LogIntegracaoCodigoBarraEntity()
        {
            Data_Alteracao = DateTime.Now;
        }
    }
}
