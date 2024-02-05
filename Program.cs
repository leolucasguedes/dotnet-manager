var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Hardware/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "hardwareDetails",
    pattern: "hardware/{id}",
    defaults: new { controller = "Hardware", action = "Details" }
);

app.MapControllerRoute(
    name: "hardwares",
    pattern: "hardware",
    defaults: new { controller = "Hardware", action = "Index" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hardware}/{action=Index}/{id?}");

app.Run();
