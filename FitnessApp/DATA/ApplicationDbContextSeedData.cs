using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessAPP.Models;
namespace FitnessAPP.DATA
{
    public static class ApplicationDbContextSeedData
    {

        // prepolulate tables when database is initialised the first time
        public static void SeedData(this IServiceScopeFactory scopeFactory)
        {
            using (var serviceScope = scopeFactory.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

               
                    var activities = new List<Activity>
                    {
                        new Activity { ActiveId=1, Name = "Basketball"},
                        new Activity { ActiveId=2, Name = "Biking"},
                        new Activity { ActiveId=3, Name = "Kayaking"},
                        new Activity { ActiveId=4, Name = "Running"},
                        new Activity { ActiveId=5, Name = "Sking"},
                        new Activity { ActiveId=6, Name = "Swimming"},
                        new Activity { ActiveId=7, Name = "Walking"}
                    };
                    context.AddRange(activities);
                    context.SaveChanges();               

               
                    var Statuses = new List<Entry>
                    {
                        new Entry { EntryId = Guid.NewGuid(),Date = DateTime.Now, Activityid = 1, IntensityName = "low", Duration = 10.0f},
                        new Entry { EntryId = Guid.NewGuid(),Date = DateTime.Now, Activityid = 4, IntensityName = "high", Duration = 10.0f},
                        new Entry { EntryId = Guid.NewGuid(),Date = DateTime.Now, Activityid = 2, IntensityName = "medium", Duration = 10.0f},
                        new Entry { EntryId = Guid.NewGuid(),Date = DateTime.Now, Activityid = 3, IntensityName = "high", Duration = 10.0f},
                    };
                    context.AddRange(Statuses);
                    context.SaveChanges();
                
            }
        }
    }
}
