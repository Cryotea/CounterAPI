using CounterAPI;var builder = WebApplication.CreateBuilder(args);

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

List <Counter> CounterList = new List<Counter>();
int idCounter = 1;
    
app.MapPost("/counter", () =>
{
    Counter counter = new Counter (idCounter);
    idCounter++;
    CounterList.Add(counter);
    return counter.Id;
});


app.MapPost("/counter/increase", (int id ,int amount) =>
{
    var CurrentList = CounterList.First(counter => counter.Id == id);
    if (CurrentList != null) return CurrentList.IncreaseCount(amount);
    else return -1;
});

app.MapPost("/counter/decrease", (int id ,int amount) =>
{
    var CurrentList = CounterList.First(counter => counter.Id == id);
    if (CurrentList != null) return CurrentList.DecreaseCount(amount);
    else return -1;
});

app.MapGet("/counter", (int id) =>
{
    var CurrentList = CounterList.First(counter => counter.Id == id);
    if (CurrentList != null) return CurrentList.Count;
    else return -1;
});

app.Run();

