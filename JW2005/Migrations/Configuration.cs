using System.Data.Entity.Migrations;
using JW2005.DAL;
using JW2005.Models;

namespace JW2005.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Jw2005Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Jw2005Context context)
        {
            context.Servers.AddOrUpdate(server => server.Hostname,
                new Server
                {
                    Hostname = "222.201.132.113",
                    Status = ServerStatus.Down
                },
                new Server
                {
                    Hostname = "222.201.132.114",
                    Status = ServerStatus.Down
                },
                new Server
                {
                    Hostname = "222.201.132.115",
                    Status = ServerStatus.Down
                },
                new Server
                {
                    Hostname = "222.201.132.116",
                    Status = ServerStatus.Down
                },
                new Server
                {
                    Hostname = "222.201.132.117",
                    Status = ServerStatus.Down
                });
        }
    }
}