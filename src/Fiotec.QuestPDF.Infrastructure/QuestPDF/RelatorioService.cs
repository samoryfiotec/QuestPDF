using System.Reflection.Metadata;
using Fiotec.QuestPDF.Application.DTOs;
using Fiotec.QuestPDF.Application.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Document = QuestPDF.Fluent.Document;

namespace Fiotec.QuestPDF.Infrastructure.QuestPDF
{
    public class RelatorioService : IRelatorioService
    {
        public byte[] GerarRelatorioPdf(RelatorioDto dados)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Header().Text(dados.Titulo).FontSize(20).Bold();
                    page.Content().Column(col =>
                    {
                        foreach (var item in dados.Itens)
                        {
                            col.Item().Text($"• {item}");
                        }
                    });
                    page.Footer().AlignCenter().Text("Gerado com QuestPDF");
                });
            });

            return document.GeneratePdf();
        }
    }

}
