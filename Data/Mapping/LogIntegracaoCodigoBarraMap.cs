using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class LogIntegracaoCodigoBarraMap : IEntityTypeConfiguration<LogIntegracaoCodigoBarraEntity>
    {
        public void Configure(EntityTypeBuilder<LogIntegracaoCodigoBarraEntity> builder)
        {
            builder.ToTable("Log_Integracao_CodigoBarra");
            builder.HasKey(p => p.Log_Integracao_CodigoBarra_ID);
        }
    }
}
