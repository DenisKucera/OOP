using Microsoft.EntityFrameworkCore;
using Projekt.Domain;

namespace Projekt.Data;

public static class DataSeeder
{
    public static void Seed(TaskDbContext context)
    {
        if (context.Users.Any())
        {
            return; 
        }

        var user1 = new User("Denis Kucera", "denis.kucera@vutbr.cz");
        var user2 = new User("Jan Novak", "jan.novak@vutbr.cz");
        var user3 = new User("Petr Svoboda", "petr.svoboda@vutbr.cz");

        context.Users.AddRange(user1, user2, user3);
        
        context.SaveChanges(); 

        var task1 = new TeamTask("Úklid", "Uklidit pracovní stůl");
        task1.AssignToUser(user1.Id);       
        task1.StartProgress();              

        var task2 = new TeamTask("Napsat dokumentaci", "Sepsat podrobnou dokumentaci popisující produkt");
        task2.AssignToUser(user2.Id);       
        task2.MarkAsCompleted();     

        var task3 = new TeamTask("Údržba kávovaru", "Doplnit vodu do kávovaru");
        task3.AssignToUser(user3.Id);       
        task3.MarkAsCompleted();     

        context.Tasks.AddRange(task1, task2, task3);
        
        context.SaveChanges();
    }

public static void SeedDatabase(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<TaskDbContext>();
                
                context.Database.Migrate(); 
                
                Seed(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při inicializaci databáze: {ex.Message}");
            }
        }
    }
}