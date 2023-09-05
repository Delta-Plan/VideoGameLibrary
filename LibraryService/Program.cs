using LibraryService;
using LibraryService.DataReaders;
using Microsoft.EntityFrameworkCore;
using StructureMap;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
optionsBuilder.UseSqlServer(connection);

var context = new ApplicationContext(optionsBuilder.Options);


builder.Services.AddSingleton(new Container(c =>
{
    c.For<IDataRepository>().Use<DatabaseRepository>().Ctor<ApplicationContext>().Is(context);
    //c.For<IDataRepository>().Use<DummyRepository>();
}
));


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
