using People.Business.Models;
using System;
using System.Threading.Tasks;

namespace People.Business.Interfaces
{
    public interface IPersonService : IDisposable
    {
        Task<bool> Add(Person person);
        Task<bool> Update(Person person);
        Task<bool> Delete(Guid id);
    }
}
