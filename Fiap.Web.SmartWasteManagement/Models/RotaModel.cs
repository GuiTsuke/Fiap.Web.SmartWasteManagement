namespace Fiap.Web.SmartWasteManagement.Models
{
    public class RotaModel
    {
        public int Codigo { get; set; }
        public int CodigoCaminhao { get; set; }
        public DateTime DataColeta { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public string PontosColeta { get; set; } = string.Empty;
        public CaminhaoModel Caminhao { get; set; } = new CaminhaoModel();
        public List<AgendamentoColetaModel> Agendamentos { get; set; } = new List<AgendamentoColetaModel>();
    }
}
