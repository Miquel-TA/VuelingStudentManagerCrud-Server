using System;
using System.Runtime.Serialization;

namespace Vueling.Crosscutting.Models
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Guid Guid { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }

        public Student(DateTime birthday, string name, string surname)
        {
            Birthday = birthday.Date;
            Name = name;
            Surname = surname;
        }
    }

}
