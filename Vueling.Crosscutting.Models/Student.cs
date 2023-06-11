using System;
using System.Runtime.Serialization;
using System.Text;

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
        public DateTime CreationDate { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public short Age { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        public Student() { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Id.ToString());
            sb.Append(Guid.ToString());
            sb.Append(CreationDate.ToString());
            sb.Append(Birthday.ToString());
            sb.Append(Age.ToString());
            sb.Append(Name.ToString());
            sb.Append(Surname.ToString());

            return sb.ToString();
        }
    }

}
