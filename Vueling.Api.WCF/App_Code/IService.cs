using System;
using System.ServiceModel;
using Vueling.Crosscutting.Models;

public interface IService
{
    [OperationContract]
    bool InsertStudent(Student student);

    [OperationContract]
    bool DeleteStudent(int id);

    [OperationContract]
    bool GetStudent(int id);

    [OperationContract]
    bool GetStudents();

    [OperationContract]
    bool UpdateStudent(int id, Student student);
}