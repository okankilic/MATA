using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Filters
{
    public class CustomLogAttribute : ActionFilterAttribute
    {
        IDependencyResolver dependencyResolver;

        IDependencyResolver CurrentDependencyResolver
        {
            get
            {
                if(dependencyResolver == null)
                {
                    return DependencyResolver.Current;
                }

                return dependencyResolver;
            }
            set
            {
                dependencyResolver = value;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            var logger = CurrentDependencyResolver.GetService<ILogger>();

            //logger.Info(JsonConvert.SerializeObject(request, new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    ContractResolver = new IgnoreErrorPropertiesResolver()
            //}));

            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            var logger = CurrentDependencyResolver.GetService<ILogger>();

            logger.Info(JsonConvert.SerializeObject(response, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new IgnoreErrorPropertiesResolver()
            }));

            base.OnResultExecuted(filterContext);
        }
    }

    public class IgnoreErrorPropertiesResolver : DefaultContractResolver
    {

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            switch (property.PropertyName)
            {
                case "InputStream":
                case "Filter":
                case "Length":
                case "Position":
                case "ReadTimeout":
                case "WriteTimeout":
                case "LastActivityDate":
                case "LastUpdatedDate":
                case "Session":
                    property.Ignored = true;
                    break;
            }

            return property;
        }
    }
}