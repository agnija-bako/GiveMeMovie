using GiveMeMovie;
using GiveMeMovie.Services.ApiHelper.Implementations;
using GiveMeMovie.Services.ApiHelper.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var config = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json", optional: false)
//    .Build();

var options = new TMDBOptions();
builder.Configuration.GetSection("TMDB").Bind(options);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("externalApiClient", client =>
{
    client.BaseAddress = new Uri(options.BaseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("Authorization",options.ApiKey);
});
builder.Services.AddSingleton<IGetMovieChangesList, GetMovieChangesList>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
