using Events.Infrastructure.Repositories;
using Events.Infrastructure.Uow;
using Events.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Services
{
    public class EventService
    {
        private readonly EventRepository eventRepository;
        private readonly EventFileRepository eventFileRepository;
        private readonly UnitOfWork uow;

        public EventService(EventRepository eventRepository,EventFileRepository eventFileRepository,UnitOfWork Uow)
        {
            this.eventRepository = eventRepository;
            this.eventFileRepository = eventFileRepository;
            uow = Uow;
        }

        public List<Event> GetEvents()
        {
            try
            {
                return this.eventRepository.Queryable().Include(x => x.Files).ToList();
            }catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> InsertEvent(Event e){
            this.eventRepository.Insert(e);
            var count = await this.uow.SaveChangesAsync();
            if (count > 0) {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateEvent(Event e)
        {
            var oldEvent = this.eventRepository.Queryable().FirstOrDefault(x=>x.RfId == e.RfId);
            if (oldEvent == null)
                return false;
            oldEvent.Title = e.Title;
            oldEvent.EventDate = e.EventDate;

            var count = await this.uow.SaveChangesAsync();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> InsertEventFiles(List<EventFile> files)
        {
            foreach (var file in files)
            {
                this.eventFileRepository.Insert(file);
            }
            var count = await this.uow.SaveChangesAsync();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteEvent(Event e)
        {
            this.eventRepository.Delete(e);
            var count = await this.uow.SaveChangesAsync();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
