using Domain.Entities;
using Domain.Interface.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CentralRepository : ICentralRepository
    {
        IUnitOfWorkCentral _unitOfWork;
        public CentralRepository(IUnitOfWorkCentral unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ApagaCodigoBarraIntegrado(int pecaCodBarra_ID)
        {
            var dataset = _unitOfWork.Context.Set<LogIntegracaoCodigoBarraEntity>();
            var registro = dataset.FirstOrDefault(l => l.PecaCodBarra_ID == pecaCodBarra_ID);

            if (registro != null)
                dataset.Remove(registro);

            await _unitOfWork.Context.SaveChangesAsync();
        }
    }
}
