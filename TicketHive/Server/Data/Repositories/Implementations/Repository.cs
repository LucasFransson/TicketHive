using Duende.IdentityServer.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
            //return (TEntity?) ReturnViewModel(selectedEntity);
            //return (TEntity?) _convertToViewModelService.ReturnViewModel(await _context.Set<TEntity>().FindAsync(id));
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IEnumerable<TEntity> entities = await _context.Set<TEntity>().ToListAsync();
            
            return entities;
        }
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public Object ReturnViewModel(TEntity entity)
        {
            switch (entity.GetType().Name)
            {
                case "CountryModel":
                    {
                        return ConvertCountryModel(entity as CountryModel);
                    }
                case "EventModel":
                    {
                        //EventModel? test = entity as EventModel;
                        return ConvertEventModel(entity as EventModel);
                    }
                case "EventTypeModel":
                    {
                        return ConvertEventTypeModel(entity as EventTypeModel);
                    }
                case "TicketModel":
                    {
                        return ConvertTicketModel(entity as TicketModel);
                    }

                default: throw new ArgumentException("Invalid Model type.");
            }
        }

        private EventTypeViewModel ConvertEventTypeModel(EventTypeModel eventTypeModel)
        {
            EventTypeViewModel eventTypeViewModel = new()
            {
                Name = eventTypeModel.Name,
                Events = ConvertListOfEventModels(eventTypeModel.Events)
            };

            return eventTypeViewModel;
        }

        private List<EventViewModel>? ConvertListOfEventModels(List<EventModel> eventModels)
        {
            List<EventViewModel>? eventViewModels = eventModels.Select(e => ConvertEventModel(e)).ToList();

            return eventViewModels;
        }

        private EventViewModel ConvertEventModel(EventModel eventModel)
        {
            EventViewModel eventViewModel = new()
            {
                Id = eventModel.Id,
                Name = eventModel.Name,
                Description = eventModel.Description,
                MaxUsers = eventModel.MaxUsers,
                IsSoldOut = eventModel.IsSoldOut,
                Price = eventModel.Price,
                //StartTime = eventModel.StartTime,
                //EndTime = eventModel.EndTime,
                SoldTickets = ConvertListOfTicketModels(eventModel.SoldTickets),
                Country = ConvertCountryModel(eventModel.Country),
                EventType = ConvertEventTypeModel(eventModel.EventType)
            };

            return eventViewModel;
        }

        private CountryViewModel ConvertCountryModel(CountryModel countryModel)
        {
            CountryViewModel countryViewModel = new()
            {
                Name = countryModel.Name,
                Currency = countryModel.Currency,
                IsAvailableForUserRegistration = countryModel.IsAvailableForUserRegistration,
            };

            return countryViewModel;
        }

        private TicketViewModel ConvertTicketModel(TicketModel ticketModel)
        {
            TicketViewModel ticketViewModel = new()
            {
                Id = ticketModel.Id,
                Event = ConvertEventModel(ticketModel.Event),
                Username = ticketModel.Username,
                Price = ticketModel.Price,
                //StartTime = ticketModel.StartTime,
                //EndTime = ticketModel.EndTime
            };

            return ticketViewModel;
        }

        private List<TicketViewModel>? ConvertListOfTicketModels(List<TicketModel> eventModels)
        {
            List<TicketViewModel>? ticketViewModels = eventModels.Select(t => ConvertTicketModel(t)).ToList();

            return ticketViewModels;
        }
    }
}
