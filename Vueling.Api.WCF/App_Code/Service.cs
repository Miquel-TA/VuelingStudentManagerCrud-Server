using System;
using Vueling.Crosscutting.Models;
using Vueling.Business.Logic;

public class Service : IService
{
    private BusinessLogic BusinessLogic = new BusinessLogic();

    public bool InsertStudent(Student student)
    {
        return BusinessLogic.InsertStudent(student);
    }

    public bool DeleteStudent(int id)
    {
        throw new NotImplementedException();
    }

    public bool GetStudent(int id)
    {
        throw new NotImplementedException();
    }

    public bool GetStudents()
    {
        throw new NotImplementedException();
    }

    public bool UpdateStudent(int id, Student student)
    {
        throw new NotImplementedException();
    }
}

