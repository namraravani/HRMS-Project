using HRMS_POC_Project_Frontend.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews(); 


builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7124/");
});
builder.Services.AddHttpClient<IOrganizationService, OrganizationService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7124/");
});


builder.Services.AddHttpContextAccessor();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization(); 


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Index}/{id?}");

app.Run();
