using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anket2
{
    class Datebase
    {
        private List<Person> people = new List<Person>();
        public void Add(Person person)
        {
            people.Add(person);
        }
        public void Remove(Person person)
        {
            people.Remove(person);
        }
        public List<Person> GetPeopleList()
        {
            return people;
        }
    }
}
