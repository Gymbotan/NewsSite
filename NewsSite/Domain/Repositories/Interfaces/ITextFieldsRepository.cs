using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsSite.Domain.Entities;

namespace NewsSite.Domain.Repositories.Interfaces
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid id);
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
