using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Vueling.Business.Logic;
using Vueling.Crosscutting.Models;

namespace Vueling.Api.WCF
{
    public class Service1 : IService1
    {
        private readonly BusinessLogic BusinessLogic = new BusinessLogic();

        public List<Student> GetAllStudents()
        {
            return BusinessLogic.GetAllStudents();
        }

        public bool AddStudent(Student student)
        {
            return BusinessLogic.AddStudent(student);
        }

        public bool DeleteStudent(Student studentToDelete)
        {
            return BusinessLogic.DeleteStudent(studentToDelete);
        }

        public bool UpdateStudent(Student student)
        {
            return BusinessLogic.UpdateStudent(student);
        }
    }
}
