using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public interface ICaminhaoService
    {
        IEnumerable<CaminhaoModel> ListarCaminhoes(int pagina, int tamanho);
        IEnumerable<CaminhaoModel> ListarCaminhoesReferencia(int pagina, int tamanho);
        IEnumerable<CaminhaoModel> ListarCaminhoesSemPage();
        CaminhaoModel? ObterCaminhaoPorId(int id);
        void CriarCaminhao(CaminhaoModel caminhao);
        void AtualizarCaminhao(CaminhaoModel caminhao);
        void DeletarCaminhao(int id);
    }
}
