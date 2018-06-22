using FitnessAPP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessAPP.DATA
{
    public class EntriesRepository : IEntriesRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IQueryable<object> GetActivities()
        {
            return context.Entries;
        }

        public void InsertOrUpdate(Entry entry)
        {
            if (entry.EntryId == default(Guid))
            {
                // New entity
                entry.EntryId = Guid.NewGuid();
                context.Entries.Add(entry);
            }
            else if (entry.EntryId != null)
            {
                context.Entries.Add(entry);
            }
            else
            {
                // Existing entity
                context.Entry(entry).State = EntityState.Modified;
            }
        }
        public void Delete(string entryID)
        {
            Guid ID = Guid.Parse(entryID);
            var remoe = context.Entries.Where(x => x.EntryId.Equals(ID)).FirstOrDefault();
            context.Entries.Remove(remoe);
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

    public interface IEntriesRepository : IDisposable
    {
        IQueryable<object> GetActivities();
        void InsertOrUpdate(Entry entry);
        void Delete(string entryID);      
        void Save();
    }
}
