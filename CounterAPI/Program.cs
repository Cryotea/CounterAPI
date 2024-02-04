using CounterAPI;
using CounterAPI.Context;
using CounterAPI.DTOs;
using CounterAPI.Entities;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.MapPost("/counter", ([FromBody]string name) =>
{
    using (var context = new MyDbContext())
    {
        Counter counter = new Counter(name);
        context.Counters.Add(counter);
        context.SaveChanges();
        return counter.Id;
    }
});


app.MapPost("/counter/increase", ([FromBody]CounterDTO counterDto) =>
{
    using (var context = new MyDbContext())
    {
       var currentcounter= context.Counters.Find(counterDto.Id);
       currentcounter.IncreaseCount(counterDto.Amount);
       context.SaveChanges();
       return currentcounter;
    }
    
});

app.MapPost("/counter/decrease", ([FromBody]CounterDTO counterDto) =>
{
    using (var context = new MyDbContext())
    {
        var currentcounter= context.Counters.Find(counterDto.Id);
        currentcounter.DecreaseCount(counterDto.Amount);
        context.SaveChanges();
        return currentcounter;
    }
});

app.MapGet("/counter", (int id) =>
{
    using (var context = new MyDbContext())
    {
       return context.Counters.Find(id);
    }
});

app.Run();