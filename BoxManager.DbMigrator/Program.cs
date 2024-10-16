using Microsoft.EntityFrameworkCore;

Console.WriteLine("Migration - START");

var dbFactory = BoxManagerContextFactory();

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
using (var db = dbFactory.CreateDbContext(null))
{
    db.Database.Migrate();
}
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

Console.WriteLine("Migration - STOP");
Console.WriteLine("Press any key");
Console.ReadKey();