namespace Fiotec.QuestPDF.Application.DTOs
{
    public class RelatorioDto
    {
        public string Titulo { get; set; } = string.Empty;
        public List<string> Itens { get; set; } = new();
    }

}
