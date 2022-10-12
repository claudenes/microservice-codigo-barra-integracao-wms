using System.Text.Json;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using System.Threading.Tasks;
using Domain.DTO;
using System;

namespace Service
{
    public class IntegracaoService : IIntegracaoService
    {
        private readonly ICentralRepository _centralRepository;


        public IntegracaoService(
            ICentralRepository centralRepository)
        {
            _centralRepository = centralRepository;
        }

        public async Task<bool> IntegrarCodigoBarra(CodigoBarrasIntegrarDTO codigoBarraIntegrarDTO)
        {
            var codBarrasSenior = new CodigoBarrasIntegracoSeniorDTO();

            codBarrasSenior.usuario = Environment.GetEnvironmentVariable("USUARIO_SENIOR");
            codBarrasSenior.senha = Environment.GetEnvironmentVariable("SENHA_SENIOR");

            codBarrasSenior.codigobarras.cd_empresa = Convert.ToInt32(Environment.GetEnvironmentVariable("CODIGO_CD_SENIOR"));
            codBarrasSenior.codigobarras.cd_produto = codigoBarraIntegrarDTO.Peca_ID.ToString();
            codBarrasSenior.codigobarras.cd_barras = codigoBarraIntegrarDTO.Peca_CodBarra_CdBarras;
            codBarrasSenior.codigobarras.cd_situacao = codigoBarraIntegrarDTO.Cancelar ? 2 : 1;

            var json = JsonSerializer.Serialize(codBarrasSenior);
            await HttpClientIntegracaoHelper.PostAsync<CodigoBarrasSeniorRetornoDTO>(json, "entrada/codigobarras");

            await _centralRepository.ApagaCodigoBarraIntegrado(codigoBarraIntegrarDTO.PecaCodBarra_ID);

            return true;
        }
    }
}