using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface ICentralRepository
    {
        Task ApagaCodigoBarraIntegrado(int pecaCodBarra_ID);
    }
}
