using System;
using System.Collections.Generic;
using Vueling.Crosscutting.Models;
using Vueling.Infrastructure.Repository;

namespace Vueling.Business.Logic
{
    public class BusinessLogic
    {
        private readonly InfrastructureRepository Infrastructure = new InfrastructureRepository();

        public bool DeleteStudent(Student student)
        {
            bool success = false;
            try
            {
                if
                (
                    Utils.VerifyDateTime(student.Birthday) &&
                    Utils.VerifyName(student.Name) &&
                    Utils.VerifyName(student.Surname)
                )
                {
                    success = Infrastructure.DeleteStudent(student);
                    if (success)
                    {
                        Logger.Log("Deleted Student: " + student.ToString(), Logger.Severity.Info);
                    }
                    else
                    {
                        Logger.Log("Database didn't delete Student: " + student.ToString(), Logger.Severity.Warning);
                    }
                }
                else
                {
                    Logger.Log("Failed to validate a student deletion: " + student.ToString(), Logger.Severity.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, Logger.Severity.Error);
                Logger.Log(ex.StackTrace, Logger.Severity.Error);
            }
            return success;
        }
        public bool UpdateStudent(Student student)
        {
            bool success = false;
            try
            {
                if
                (
                    Utils.VerifyDateTime(student.Birthday) &&
                    Utils.VerifyName(student.Name) &&
                    Utils.VerifyName(student.Surname)
                )
                {
                    success = Infrastructure.UpdateStudent(student);
                    if (success)
                    {
                        Logger.Log("Updated Student: " + student.ToString(), Logger.Severity.Info);
                    }
                    else
                    {
                        Logger.Log("Database didn't update Student: " + student.ToString(), Logger.Severity.Warning);
                    }
                }
                else
                {
                    Logger.Log("Failed to verify an update to an existing student: " + student.ToString(), Logger.Severity.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, Logger.Severity.Error);
                Logger.Log(ex.StackTrace, Logger.Severity.Error);
            }
            return success;
        }

        public bool AddStudent(Student student)
        {
            bool success = false;
            try
            {
                if
                (
                    Utils.VerifyDateTime(student.Birthday) &&
                    Utils.VerifyName(student.Name) &&
                    Utils.VerifyName(student.Surname)
                )
                {
                    student.Age = Utils.GetAgeFromBirthday(student.Birthday);
                    success = Infrastructure.AddStudent(student);
                    if (success)
                    {
                        Logger.Log("Inserted Student: " + student.ToString(), Logger.Severity.Info);
                    }
                    else
                    {
                        Logger.Log("Database didn't insert Student: " + student.ToString(), Logger.Severity.Warning);
                    }
                }
                else
                {
                    Logger.Log("Failed to verify values of a new student: " + student.ToString(), Logger.Severity.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, Logger.Severity.Error);
                Logger.Log(ex.StackTrace, Logger.Severity.Error);
            }
            return success;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentsReturned = new List<Student>();
            try
            {
                studentsReturned = Infrastructure.GetAllStudents();
                if (studentsReturned.Count > 0)
                {
                    Logger.Log("Database returned " + studentsReturned.Count + " Students.", Logger.Severity.Info);
                }
                else
                {
                    Logger.Log("Database returned an empty Student list.", Logger.Severity.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, Logger.Severity.Error);
                Logger.Log(ex.StackTrace, Logger.Severity.Error);
            }
            return studentsReturned;
        }

    }
}
