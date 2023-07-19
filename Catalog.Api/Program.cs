using Catalog.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddNewtonsoftJson(opt =>
{
    // Include methodundan sonra döngüye girmemesi için configuration
    // görmezden gel: ignore
    opt.SerializerSettings.ReferenceLoopHandling = 
    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom ServiceConfigure Extensions
builder.Services.ConfigureSqlConnection(builder.Configuration);
builder.Services.ConfigureRepositoryInjection();
builder.Services.ConfigureUnitOfWorkInjection();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureRepoManagerInjection();
builder.Services.ConfigureServiceInjection();

var app = builder.Build();

// Exception middleware extension configure
app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
