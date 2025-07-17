using Fiotec.QuestPDF.Application.DTOs;

namespace Fiotec.QuestPDF.Application.Interfaces
{

    public interface IRelatorioService
    {
        byte[] GerarRelatorioPdf(RelatorioDto dados);
    }

}
