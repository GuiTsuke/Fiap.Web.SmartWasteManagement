using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public interface ICaminhaoRepository
    {
        IEnumerable<CaminhaoModel> GetAll(int pagina, int tamanho);
        IEnumerable<CaminhaoModel> GetAllWithoutPage();
        IEnumerable<CaminhaoModel> GetAllReference(int pagina, int tamanho);
        CaminhaoModel? GetById(int id);
        void Add(CaminhaoModel caminhao);
        void Update(CaminhaoModel caminhao);
        void Delete(CaminhaoModel caminhao);
    }
}
