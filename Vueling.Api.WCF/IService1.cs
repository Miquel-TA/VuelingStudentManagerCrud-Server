using System;
using System.Collections.Generic;
using System.ServiceModel;
using Vueling.Crosscutting.Models;
using Vueling.Business.Logic;

namespace Vueling.Api.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool AddStudent(Student student);

        [OperationContract]
        bool DeleteStudent(Student studentToDelete);

        [OperationContract]
        List<Student> GetAllStudents();

        [OperationContract]
        bool UpdateStudent(Student student);
    }

}
