namespace FintechApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // ✅ AGREGAR ESTO (si no estaba)
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // ✅ AGREGAR ESTO (después de UseRouting)
            app.UseSession();

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            ////app.Run();
            //app.UseStaticFiles();
            //app.UseRouting();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Cliente}/{action=Index}/{id?}");


            // 👉 RUTAS
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}");

            app.Run();


        }
    }
}
