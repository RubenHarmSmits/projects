using System;
using System.Linq;
using System.Collections;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SogyoLunchApp.APIService
{
    public static class ControllerExtensions
    {
        public static IEnumerable Errors(this ModelStateDictionary modelState)
        {
            var errors = new Hashtable();
            foreach (var kv in modelState.Where(kv => kv.Value.Errors.Count > 0)) {
                errors[kv.Key] = kv.Value.Errors.Select(error => error.ErrorMessage).ToList();
            }
            return errors;
        }
    }
}