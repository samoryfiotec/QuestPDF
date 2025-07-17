# QuestPDF

[![NuGet](https://img.shields.io/nuget/v/QuestPDF.svg)](https://www.nuget.org/packages/QuestPDF)
[![License: Community MIT and Professional](https://img.shields.io/badge/License-Community%20MIT%20and%20professional-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)

QuestPDF é uma biblioteca open-source para geração de documentos PDF de alta qualidade em aplicações .NET. Ela permite criar layouts complexos de forma declarativa, utilizando C# moderno e integração total com .NET 8.

## Recursos

- Layouts flexíveis e responsivos
- Suporte a tabelas, imagens, gráficos e textos ricos
- Estilização avançada (cores, fontes, margens, espaçamentos)
- Geração rápida e thread-safe
- API fluente e intuitiva
- Compatível com .NET 6, 7 e 8

## Instalação

Adicione o pacote via NuGet:

```bash
dotnet add package QuestPDF
```

Ou via Package Manager:

```powershell
Install-Package QuestPDF
```

## Exemplo Básico

```csharp
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class InvoiceDocument : IDocument
{
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(50);
            page.Header().Text("Fatura").FontSize(24).Bold();
            page.Content().Column(col =>
            {
                col.Item().Text("Cliente: João da Silva");
                col.Item().Text("Data: 01/01/2024");
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(200);
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("Produto").Bold();
                        header.Cell().Text("Quantidade").Bold();
                        header.Cell().Text("Preço").Bold();
                    });

                    table.Cell().Text("Notebook");
                    table.Cell().Text("1");
                    table.Cell().Text("R$ 5.000,00");
                });
            });
            page.Footer().AlignCenter().Text("Obrigado pela preferência!");
        });
    }
}
```

## Gerando o PDF

```csharp
var document = new InvoiceDocument();
document.GeneratePdf("fatura.pdf");
```

## Documentação

- [Documentação Oficial](https://www.questpdf.com/documentation/)
- [Exemplos de Uso](https://www.questpdf.com/gallery/)
- [Repositório no GitHub](https://github.com/QuestPDF/QuestPDF)

## Contribuição

Contribuições são bem-vindas! Consulte o [Guia de Contribuição](CONTRIBUTING.md) para mais detalhes.

## Licença

Distribuído sob a licença Communit MIT and Professional. Veja o arquivo [LICENSE](LICENSE) para mais informações.
