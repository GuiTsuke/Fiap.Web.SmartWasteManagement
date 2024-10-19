using Fiap.Web.SmartWasteManagement.Models.Enums;

namespace Fiap.Web.SmartWasteManagement.Models
{
    public class RecipienteModel
    {
        public int Codigo { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public TipoResiduo TipoResiduo { get; set; }
        public decimal CapacidadeTotal { get; set; }
        public decimal NivelOcupacaoAtual { get; set; }
        public int CodigoMorador { get; set; }
        public MoradorModel Morador { get; set; } = new MoradorModel();

        public List<NotificacaoModel> Notificacoes { get; set; } = new List<NotificacaoModel>();
        public List<AgendamentoColetaModel> Agendamentos { get; set; } = new List<AgendamentoColetaModel>();
    }
}
