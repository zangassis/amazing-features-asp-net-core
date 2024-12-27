namespace AmazingFeatures.Data;
public class AmazingHelper
{
    private readonly AmazingContext _amazingContext;

    public AmazingHelper(AmazingContext amazingContext)
    {
        _amazingContext = amazingContext;
    }

    public static void MigrationInitialisation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<AmazingContext>();

            if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
            {
                context.Database.Migrate();
            }
        }
    }

    public List<Product> GetProductsWithPrice() =>
        _amazingContext.Products.Where(p => p.Price > 0).ToList(); 
}
