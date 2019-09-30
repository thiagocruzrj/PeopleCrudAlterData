using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Business.Interfaces;
using People.Business.Models;
using People.Business.Models.Validations;

namespace People.Business.Services
{
    public class PersonService : BaseService, IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository, INotifier notifier) : base(notifier)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> Add(Person person)
        {
            if (!ExecValidation(new PersonValidation(), person)) return false;
            if (_personRepository.Search(f => f.Email == person.Email).Result.Any())
            {
                Notify("Já existe uma pessoa com esse Email.");
                return false;
            }

            await _personRepository.Add(person);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _personRepository.Delete(id);
            return true;
        }

        public async Task<bool> Update(Person person)
        {
            if (!ExecValidation(new PersonValidation(), person)) return false;

            await _personRepository.Update(person);
            return true;
        }

        public void Dispose()
        {
            _personRepository?.Dispose();
        }
    }
}
