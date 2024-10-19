using Fiap.Web.SmartWasteManagement.Models.Enums;

namespace Fiap.Web.SmartWasteManagement.Models
{
    public class CaminhaoModel
    {
        public int Codigo { get; set; }
        public string Placa { get; set; } = string.Empty;
        public decimal CapacidadeCarga { get; set; }
        public CaminhaoStatus Status { get; set; }
        public string LocalizacaoAtual { get; set; } = string.Empty;
        public List<RotaModel> Rotas { get; set; } = new List<RotaModel>();
    }
}
