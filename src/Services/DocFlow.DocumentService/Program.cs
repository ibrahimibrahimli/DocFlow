using MediatR;
using DocFlow.DocumentService.Application.Documents.Create;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateDocumentCommand).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/api/documents",
    async (
        CreateDocumentCommand command,
        ISender sender,
        CancellationToken cancellationToken) =>
    {
        var documentId = await sender.Send(
            command,
            cancellationToken);

        return Results.Created(
            $"/api/documents/{documentId}",
            new { Id = documentId });
    })
    .WithName("CreateDocument")
    .WithTags("Documents")
    .WithSummary("Create a new document");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
