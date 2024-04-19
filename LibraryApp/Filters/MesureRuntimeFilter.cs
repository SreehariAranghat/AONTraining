using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace LibraryApp.Filters
{
    public class MesureRuntimeFilter : ActionFilterAttribute
    {
  
        private Stopwatch _swActionFilter = new Stopwatch();

        public MesureRuntimeFilter()
        {
   
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _swActionFilter.Reset();
            _swActionFilter.Start();    
            
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _swActionFilter.Stop();

            File.AppendAllText("Mesure.text",$"Total Elapsed Time : {_swActionFilter.ElapsedMilliseconds}\n");
            base.OnActionExecuted(context);
        }
    }
}
