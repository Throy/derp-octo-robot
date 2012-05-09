using System;
using System.Globalization;
using System.Web.Mvc;

namespace IndignadoWeb.Common
{
    public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState {Value = valueResult};
            object actualValue = null;
            try
            {
                actualValue = float.Parse(valueResult.AttemptedValue.Replace(".", ","));
            }
            catch (FormatException error)
            {
                modelState.Errors.Add(error);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
}