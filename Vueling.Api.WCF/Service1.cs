using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Vueling.Business.Logic;
using Vueling.Crosscutting.Models;

namespace Vueling.Api.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
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
