using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsSite.Domain.Repositories.Interfaces;

namespace NewsSite.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }

        public DataManager (ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository)
        {
            this.TextFields = textFieldsRepository;
            this.ServiceItems = serviceItemsRepository;
        }
    }
}
