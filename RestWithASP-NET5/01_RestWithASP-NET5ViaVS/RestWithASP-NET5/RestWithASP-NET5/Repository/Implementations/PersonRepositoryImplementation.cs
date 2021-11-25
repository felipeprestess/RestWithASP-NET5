using RestWithASP_NET5.Models;
using RestWithASP_NET5.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return person;
        }

        public void Delete(long id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (person != null)
            {
                try
                {
                    _context.Persons.Remove(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Person Name" + i,
                LastName = "Person LastName" + i,
                Address = "Same Address" + i,
                Gender = "Male"
            };
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }
    }
}
