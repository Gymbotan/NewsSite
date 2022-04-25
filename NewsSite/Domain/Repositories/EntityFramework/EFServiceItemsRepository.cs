using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsSite.Domain.Repositories.Interfaces;
using NewsSite.Domain.Entities;

namespace NewsSite.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;

        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.ServiceItems;
        }

        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteServiceItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem { Id = id });
            context.SaveChanges();
        }

        public ServiceItem GetServiceItemById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }
    }
}
