var builder = WebApplication.CreateBuilder(args);

//Add services to the container 
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    //To register all command and query handlers in current project.
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("DataBabse")!);
    
}).UseLightweightSessions();

var app = builder.Build();

// configure the HTTP request pipeline.
app.MapCarter();
app.Run();
