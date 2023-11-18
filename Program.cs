using GiveMeMovie.Services.ApiHelper.Implementations;
using GiveMeMovie.Services.ApiHelper.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("externalApiClient", client =>
{
    client.BaseAddress = new Uri("https://api.themoviedb.org/3");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("Authorization",
        "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmZjZmZTVjMmYwZWVkNjBhMzVlNTNhNjQ2YWUxNDJjMyIsInN1YiI6IjVmZTBjNTY0MWIxNTdkMDA0MWM3OWE5YyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.MZFR89Ma_9cyScbAbmqLFzYx1ZsrgV7AG2RMa2QPZuA");
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
