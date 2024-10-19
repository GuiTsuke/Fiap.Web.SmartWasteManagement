namespace Fiap.Web.SmartWasteManagement.Models
{
    public class MoradorModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public List<RecipienteModel> Recipientes { get; set; } = new List<RecipienteModel>();
        public List<NotificacaoModel> Notificacoes { get; set; } = new List<NotificacaoModel>();

    }
}
