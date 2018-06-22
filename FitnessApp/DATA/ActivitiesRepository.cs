using FitnessAPP.DATA;
using FitnessAPP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace FitnessAPP.DATA
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IQueryable<object> GetActivities()
        {
            return context.Activities;
        }

        public void InsertOrUpdate(Models.Activity activity)
        {
            if (activity.ActiveId == 0)
            {
                // New entity
                activity.ActiveId = 0;
                context.Activities.Add(activity);
            }            
            else
            {
                // Existing entity
                context.Entry(activity).State = EntityState.Modified;
            }
        }
        public void Delete(string activityID)
        {
            Guid ID = Guid.Parse(activityID);
            var remoe = context.Activities.Where(x => x.ActiveId.Equals(ID)).FirstOrDefault();
            context.Activities.Remove(remoe);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }

    public interface IActivitiesRepository : IDisposable
    {
        IQueryable<object> GetActivities();
        void InsertOrUpdate(Models.Activity activity);
        void Delete(string activityID);      
        void Save();
    }
}
