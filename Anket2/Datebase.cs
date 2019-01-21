using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anket2
{
    class Datebase
    {
        private List<Person> people = new List<Person>()
        {
            {
                new Person(){
                    Name="John",
                    Surname="Doe",
                    Email="john.123@gmail.com",
                    Phonenumber="505555555",
                    Birthdate=new DateTime(1985,2,25)
                }
              },
            new Person(){
                    Name="Mike",
                    Surname="Zemon",
                    Email="mike_1212@mail.ru",
                    Phonenumber="505555555",
                    Birthdate=new DateTime(1992,1,12)
                }
        };
        public Person GetPerson(Person person)
        {
            return person;
        }
        public void Add(Person person)
        {
            people.Add(person);
        }
        public void Remove(Person person)
        {
            people.Remove(person);
        }
        public void SetList(List<Person> peoplelist)
        {
            people = peoplelist;
        }
        public List<Person> GetPeopleList()
        {
            return people;
        }
        
    }
}
