using Fiotec.QuestPDF.Application.DTOs;
using Fiotec.QuestPDF.Application.Interfaces;
using Fiotec.QuestPDF.Infrastructure.QuestPDF;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRelatorioService, RelatorioService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/api/relatorio", (RelatorioDto dto, IRelatorioService relatorioService) =>
{
    var pdfBytes = relatorioService.GerarRelatorioPdf(dto);
    return Results.File(pdfBytes, "application/pdf", "relatorio.pdf");
})
.WithName("GerarRelatorio")
.Produces(200, typeof(FileContentResult))
.WithOpenApi();


app.Run();