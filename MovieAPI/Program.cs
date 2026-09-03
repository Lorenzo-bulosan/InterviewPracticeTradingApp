using MovieAPI.Solution;
using System.Reflection;

namespace MovieAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<MovieCatalog>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // 1. Optimize Swagger Generation
            builder.Services.AddSwaggerGen(options =>
            {
                // Prevents schema generator from creating redundant or overly deep object graphs
                options.UseAllOfToExtendReferenceSchemas();
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                // 2. Optimize Swagger UI Performance
                app.UseSwaggerUI(options =>
                {
                    // Collapses the models and schemas section by default to save DOM space
                    options.DefaultModelsExpandDepth(-1);

                    // Collapses all API endpoints by default so the page doesn't lag on load
                    options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

                    // Disables syntax highlighting on massive response payloads to prevent browser freezing
                    options.ConfigObject.AdditionalItems["highlightSizeThreshold"] = 5000;
                });
            }

            app.UseHttpsRedirection();

            try
            {
                app.MapControllers();
                app.Run();
            }
            catch (ReflectionTypeLoadException ex)
            {
                Console.WriteLine("========== REAL LOADER ERRORS ==========");
                foreach (var error in ex.LoaderExceptions)
                {
                    Console.WriteLine(error);
                }
                Console.WriteLine("========================================");
                throw;
            }
        }
    }
}