using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotellApp.Data
{
    public class CreateBuild
    {     
            public HotellContext AppBuilder()
            {

                var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
                var config = builder.Build();

                var options = new DbContextOptionsBuilder<HotellContext>();
                var connectionString = config.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);

                var Context = new HotellContext(options.Options);

                var Seeder = new Seeding();
                Seeder.Seed(Context);

                var dbContextReturned = new HotellContext(options.Options);
                return dbContextReturned;

             }

        
    }
}
