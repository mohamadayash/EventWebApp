using Events.Infrastructure.Contexts;
using Events.Infrastructure.Repositories;
using Events.Infrastructure.Uow;
using Events.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

//DI
builder.Services.AddDbContext<EventsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(EventsContext));
builder.Services.AddScoped(typeof(UnitOfWork));
builder.Services.AddScoped(typeof(EventRepository));
builder.Services.AddScoped(typeof(EventFileRepository));
builder.Services.AddScoped(typeof(EventService));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
