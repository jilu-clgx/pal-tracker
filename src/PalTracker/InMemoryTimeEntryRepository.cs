using System.Collections.Generic;
using System;
using System.Linq;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        private Dictionary<long, TimeEntry> _entries;

        public InMemoryTimeEntryRepository()
        {
            _entries = new Dictionary<long, TimeEntry>();
        }

        public TimeEntry Create(TimeEntry timeEntry)
        {
            var newId =  (_entries.Count() > 0) ? _entries.Keys.Max() + 1 : 1;

            timeEntry.Id = newId;
            _entries.Add(newId, timeEntry);
            return timeEntry;
        }

        public TimeEntry Find(long id)
        {
            if (id > 0 && _entries.ContainsKey(id))
            {
                return _entries[id];
            }
            return new TimeEntry(0,0,0,DateTime.MinValue, 0);
        }

        public bool Contains(long id)        
        {
            return _entries.ContainsKey(id);
        }

        public IEnumerable<TimeEntry> List()        
        {
            return _entries.Values;
        }

        public TimeEntry Update(long id, TimeEntry timeEntry)        
        {
            if (id > 0 && _entries.ContainsKey(id))
            {
                timeEntry.Id = id;
                _entries[id] = timeEntry;
                return timeEntry;
            }
            return new TimeEntry(0,0,0,DateTime.MinValue, 0);
        }

        public void Delete(long id)        
        {
            if (id > 0 && _entries.ContainsKey(id))
            {
                _entries.Remove(id);
            }
        }

    }
}