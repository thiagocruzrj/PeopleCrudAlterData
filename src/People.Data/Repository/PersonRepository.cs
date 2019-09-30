using People.Business.Interfaces;
using People.Business.Models;
using People.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Data.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonDbContext context) :base(context)
        {

        }
    }
}
