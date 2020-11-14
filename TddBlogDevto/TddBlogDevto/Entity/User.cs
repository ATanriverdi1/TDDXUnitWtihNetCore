using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TddBlogDevto.Entity
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string name, int age, bool isActive)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.IsActive = isActive;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}
