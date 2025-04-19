using Zoo.Application.Interfaces;
using Zoo.Application.Services;
using Zoo.Infrastructure.Events;
using Zoo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Добавляем контроллеры и Swagger:
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Регистрируем репозитории (in‑memory) и издатель событий:
builder.Services.AddSingleton<IAnimalRepository, InMemoryAnimalRepository>();
builder.Services.AddSingleton<IEnclosureRepository, InMemoryEnclosureRepository>();
builder.Services.AddSingleton<IFeedingScheduleRepository, InMemoryFeedingScheduleRepository>();
builder.Services.AddSingleton<IDomainEventPublisher, ConsoleDomainEventPublisher>();

// 3. Регистрируем application‑сервисы:
builder.Services.AddScoped<AnimalService>();
builder.Services.AddScoped<EnclosureService>();
builder.Services.AddScoped<AnimalTransferService>();
builder.Services.AddScoped<FeedingOrganizationService>();
builder.Services.AddScoped<ZooStatisticsService>();

var app = builder.Build();

// 4. Настраиваем middleware:
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();