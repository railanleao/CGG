using BVS.Models.Entity.Parceria;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BVS.Models.Entity.ModelBind
{
    public class ConvertBind : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
         {
            bindingContext.Result = ModelBindingResult.Success(new ACadastroBoi());
            return Task.CompletedTask;
        }
        //public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        //{
        //    ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        //    ModelState modelState = new ModelState
        //    {
        //        Value = valueResult,
        //    };
        //    object actualValue = null;
        //    try
        //    {
        //        actualValue = Convert.ToDecimal(valueResult.AttemptedValue, 
        //            CultureInfo.CurrentCulture);
        //    }
        //    catch(FormatException e)
        //    {
        //        modelState.Errors.Add(e);
        //    }
        //    bindingContext.ModelState.Add(bindingContext.ModelName, modelState);

        //    return actualValue;
        //}

        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    ModelBinders.Binders.Add(typeof(decimal), new ConvertBind());
        //}

    }
}
