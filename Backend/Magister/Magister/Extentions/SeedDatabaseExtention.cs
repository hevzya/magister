using Magister.DbInitializer;

namespace Magister.Extentions
{
    public static class SeedDatabaseExtention
    {
        public static WebApplication SeedDatabase(this WebApplication webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                try
                {
                    var initializer = scope
                        .ServiceProvider
                        .GetRequiredService<IDatabaseInitializer>();


                    initializer.SeedData().Wait();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return webHost;
        }
    }
}
