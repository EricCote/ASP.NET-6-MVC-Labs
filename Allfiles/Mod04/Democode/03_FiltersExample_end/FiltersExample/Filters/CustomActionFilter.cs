﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersExample.Filters;
public class CustomActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        string? actionName = filterContext.ActionDescriptor.RouteValues["action"] ?? "No_Action";
        Debug.WriteLine(">>> " + actionName + " started, event fired: OnActionExecuting");
    }

    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        string actionName = filterContext.ActionDescriptor.RouteValues["action"] ?? "No_Action";
        Debug.WriteLine(">>> " + actionName + " finished, event fired: OnActionExecuted");
    }

    public override void OnResultExecuting(ResultExecutingContext filterContext)
    {
        string actionName = filterContext.ActionDescriptor.RouteValues["action"] ?? "No_Action";
        Debug.WriteLine(">>> " + actionName + " before result, event fired: OnResultExecuting");
    }

    public override void OnResultExecuted(ResultExecutedContext filterContext)
    {
        string actionName = filterContext.ActionDescriptor.RouteValues["action"] ?? "No_Action";
        ContentResult result = (ContentResult)filterContext.Result;
        Debug.WriteLine(">>> " + actionName + " result is: " + result.Content + " , event fired: OnResultExecuted");
    }
}

