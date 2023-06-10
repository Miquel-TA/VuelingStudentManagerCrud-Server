using System;
using Vueling.Crosscutting.Models;
using Vueling.Infrastructure.Repository;

namespace Vueling.Business.Logic
{
    public class BusinessLogic
    {

        private readonly DatabaseInteraction DbInteraction = new DatabaseInteraction();

        public bool InsertStudent(Student student)
        {
            if
            (
                Utils.VerifyDateTime(student.Birthday) &&
                Utils.VerifyName(student.Name) &&
                Utils.VerifyName(student.Surname)
            )
            {
                return DbInteraction.InsertStudent(student);
            }
            else
            {
                return false;
            }

        }
    }
}
