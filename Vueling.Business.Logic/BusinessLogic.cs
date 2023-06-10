using System;
using System.Collections.Generic;
using Vueling.Crosscutting.Models;
using Vueling.Infrastructure.Repository;

namespace Vueling.Business.Logic
{
    public class BusinessLogic
    {
        private readonly DatabaseInteraction DbInteraction = new DatabaseInteraction();

        public bool DeleteStudent(Student student)
        {
            try
            {
                bool success = DbInteraction.DeleteStudent(student);
                if (success)
                {
                    Logger.Log("Database didn't delete Student: " + student.ToString(), Logger.Severity.Warning);
                }
                else
                {
                    Logger.Log("Deleted Student: " + student.ToString(), Logger.Severity.Info);
                }
                return success;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, Logger.Severity.Error);
                Logger.Log(ex.StackTrace, Logger.Severity.Error);
                return false;
            }
        }
        public bool UpdateStudent(Student student)
        {
            try
            {
                bool success = DbInteraction.UpdateStudent(student);
                if (success)
                {
                    Logger.Log("Updated Student: " + student.ToString(), Logger.Severity.Info);
                }
                else
                {
                    Logger.Log("Failed to update Student: " + student.ToString(), Logger.Severity.Warning);
                }
                return success;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, Logger.Severity.Error);
                Logger.Log(ex.StackTrace, Logger.Severity.Error);
                return false;
            }
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> studentsReturned = DbInteraction.GetAllStudents();
                if (studentsReturned.Count > 0)
                {
                    Logger.Log("Database returned " + studentsReturned.Count + " Students.", Logger.Severity.Info);
                }
                else
                {
                    Logger.Log("Database returned an empty Student list.", Logger.Severity.Warning);
                }
                return studentsReturned;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, Logger.Severity.Error);
                Logger.Log(ex.StackTrace, Logger.Severity.Error);
                return new List<Student>();
            }
        }

        public bool AddStudent(Student student)
        {
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
                    bool success = DbInteraction.AddStudent(student);
                    if (success)
                    {
                        Logger.Log("Inserted Student: " + student.ToString(), Logger.Severity.Info);
                    }
                    else
                    {
                        Logger.Log("Database didn't insert Student: " + student.ToString(), Logger.Severity.Warning);
                    }
                    return success;
                }
                else
                {
                    Logger.Log("Failed to verify a new student: " + student.ToString(), Logger.Severity.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, Logger.Severity.Error);
                Logger.Log(ex.StackTrace, Logger.Severity.Error);
                return false;
            }
            

        }

    }
}
