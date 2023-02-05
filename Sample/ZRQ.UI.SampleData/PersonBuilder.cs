using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRQ.UI.SampleData
{
    public static class PersonBuilder
    {
        public static Lazy<List<Person>> Create(int index)
        {
            Lazy<List<Person>> persons = new(() =>
            {
                var list = new List<Person>(index + 1);
                for (int i = 0; i < index; i++)
                {
                    list.Add(new Person()
                    {
                        Id = i,
                        Name = $"Name_{i}",
                        Age = i,
                    });
                }
                return list;
            });
            return persons;
        }
    }
}
