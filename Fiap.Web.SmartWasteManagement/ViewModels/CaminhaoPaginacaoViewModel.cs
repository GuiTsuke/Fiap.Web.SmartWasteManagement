namespace Fiap.Web.SmartWasteManagement.ViewModels
{
    public class CaminhaoPaginacaoViewModel
    {
        public IEnumerable<CaminhaoViewModel> Caminhoes { get; set; } = new List<CaminhaoViewModel>();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Caminhoes.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Caminhao?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Caminhao?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";
    }

    public class CaminhaoPaginacaoReferenciaViewModel
    {
        public IEnumerable<CaminhaoViewModel> Caminhoes { get; set; } = new List<CaminhaoViewModel>();
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/Caminhao/ref?referencia={Ref}&tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/Caminhao/ref?referencia={NextRef}&tamanho={PageSize}" : "";
    }
}
    
