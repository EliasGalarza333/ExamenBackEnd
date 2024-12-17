/*Api desarrollada con modelo MVC truncado o Modelo Servicio Controlador*/
/*constructor*/
var builder = WebApplication.CreateBuilder(args);

/*Inyeccion de dependencias y controlador */
builder.Services.AddControllers();
builder.Services.AddHttpClient<ClientService>();
builder.Services.AddScoped<infoSv>();
builder.Services.AddScoped<AddressSv>();
builder.Services.AddScoped<PreferredAdSv>();
builder.Services.AddScoped<postalSv>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
//redireccion http
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapGet("/", () => "local funcionando");


app.MapControllers();

app.Run();
