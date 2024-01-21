using Messaging;

namespace Application.Common.Errors;

internal static class DomainErrors
{
    internal static class School
    {
        public static readonly Error GetAllSchoolsInvalidRequest = 
            new("School.GetAllSchoolsInvalidRequest", "The request to get all schools was invalid!");

        public static readonly Error GetAllSchoolsEmpty =
            new("School.GetAllSchoolsEmpty", "No schools found!");

        public static readonly Error GetSchoolInvalidRequest = 
            new("School.GetSchoolInvalidRequest", "The request to get a school was invalid!");

        public static readonly Error GetSchoolNotFound = 
            new("School.GetSchoolNotFound", "The school was not found!");

        public static readonly Error AddSchoolInvalidRequest = 
            new("School.CreateSchoolInvalidRequest", "The request to create a school was invalid!");

        public static readonly Error AddSchoolSavingFailure = 
            new("School.CreateSchoolSavingFailure", "The school could not be saved!");

        public static readonly Error RemoveSchool = 
            new("School.RemoveSchoolError", "Cannot remove the school!");

        public static readonly Error UpdateSchoolInvalidRequest = 
            new("School.UpdateSchoolInvalidRequest", "The request to update a school was invalid!");
        
        public static readonly Error UpdateSchoolSavingFailure = 
            new("School.UpdateSchoolSavingFailure", "The school update could not be saved!");

        public static readonly Error RemoveSchoolInvalidRequest =
            new("School.RemoveSchoolInvalidRequest", "The request to remove a school was invalid!");

        public static readonly Error RemoveSchoolSavingFailure =
            new("School.RemoveSchoolSavingFailure", "The school removal could not be saved!");
    }
}
