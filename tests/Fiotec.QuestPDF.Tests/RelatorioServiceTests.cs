using Fiotec.QuestPDF.Application.DTOs;
using Fiotec.QuestPDF.Infrastructure.QuestPDF;

namespace Fiotec.QuestPDF.Tests
{
    public class RelatorioServiceTests
    {
        [Fact]
        public void GerarRelatorioPdf_DeveRetornarPdfValido()
        {
            var service = new RelatorioService();
            var dto = new RelatorioDto
            {
                Titulo = "Relatório de Teste",
                Itens = new List<string> { "Item 1", "Item 2" }
            };

            var pdf = service.GerarRelatorioPdf(dto);

            Assert.NotNull(pdf);
            Assert.True(pdf.Length > 100); // tamanho mínimo esperado
        }
    }

}
