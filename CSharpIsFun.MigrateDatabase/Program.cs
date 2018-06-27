using System;
using System.IO;
using CSharpIsFun.Database;
using Microsoft.EntityFrameworkCore;

namespace CSharpIsFun.MigrateDatabase
{
    /// <summary>
    /// EF Core Migration Console App
    /// </summary>
    /// <see cref="https://blog.johnnyreilly.com/2018/06/vsts-and-ef-core-migrations.html"/>
    /// <see cref="https://github.com/aspnet/EntityFramework.Docs/issues/691"/>
    class Program
    {
        // Example usage:
        // dotnet MyAwesomeProject.MigrateDatabase.dll "Server=(localdb)\\mssqllocaldb;Database=MyAwesomeProject;Trusted_Connection=True;"
        static void Main(string[] args)
        {
            //if (args.Length == 0)
            //    throw new Exception("No connection string supplied!");

            //var myAwesomeProjectConnectionString = args[0];

            //// Totally optional debug information
            //Console.WriteLine("About to migrate this database:");
            //var connectionBits = myAwesomeProjectConnectionString.Split(";");
            //foreach (var connectionBit in connectionBits)
            //{
            //    if (!connectionBit.StartsWith("Password", StringComparison.CurrentCultureIgnoreCase))
            //        Console.WriteLine(connectionBit);
            //}

            //try
            //{
            //    var optionsBuilder = new DbContextOptionsBuilder<MyAwesomeProjectContext>();
            //    optionsBuilder.UseSqlServer(myAwesomeProjectConnectionString);

            //    using (var context = new MyAwesomeProjectContext(optionsBuilder.Options))
            //    {
            //        context.Database.Migrate();
            //    }
            //    Console.WriteLine("This database is migrated like it's the Serengeti!");
            //}
            //catch (Exception exc)
            //{
            //    var failedToMigrateException = new Exception("Failed to apply migrations!", exc);
            //    Console.WriteLine($"Didn't succeed in applying migrations: {exc.Message}");
            //    throw failedToMigrateException;
            //}
        }
    }
}