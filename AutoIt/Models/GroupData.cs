using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Models
{
    public class GroupData : IEquatable<GroupData>
    {
        public string Name { get; set; }

        public GroupData() { }
        public GroupData(string name) => Name = name;

        public static GroupData GetRandom()
        {
            var faker = new Faker("ru");
            return new GroupData()
            { 
                Name = faker.Random.Words(3).Replace(' ', '_')
            };
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(GroupData other)
        {
            return Name == other.Name;
        }

    }
}
