using Bookkeeper.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add necessary services
//builder.Services.AddScoped<IInvoiceStorageService, InvoiceStorageService>();
builder.Services.AddSingleton<IInvoiceStorageService, InvoiceStorageService>();
builder.Services.AddControllers();

// Add Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build App

var app = builder.Build();

// Enable Swagger UI and OAS json
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
