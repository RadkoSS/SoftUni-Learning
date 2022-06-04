using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People.Find(member => member.Age == this.People.Max(member => member.Age));
        }
    }
}
