using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Extensions
{
    public static class ModelStateExtension
    {
        public static List<String> GetErrors(this ModelStateDictionary modelState)
        {
            return (from item in modelState.Values from error in item.Errors select error.ErrorMessage).ToList();
        }

        //public static List<String> GetErrors(this ModelStateDictionary modelState)
        //{
        //    var errors = new List<String>();

        //    foreach (var item in modelState.Values)
        //    {
        //        foreach (var error in item.Errors)
        //        {
        //            errors.Add(error.ErrorMessage);
        //        }
        //    }

        //    return errors;

        //}
    }
}
