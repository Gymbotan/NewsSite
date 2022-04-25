using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsSite.Domain.Entities;

namespace NewsSite.Domain.Repositories.Interfaces
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid id);
    }
}
