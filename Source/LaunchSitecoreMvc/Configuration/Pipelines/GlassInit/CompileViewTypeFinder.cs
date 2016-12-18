using System;
using System.Reflection;
using System.Web.Mvc;
using Glass.Mapper.Sc.Pipelines.Response;
using RazorGenerator.Mvc;
using Sitecore.Mvc.Common;

namespace LaunchSitecore.Configuration.Pipelines.GlassInit
{
    public class CompileViewTypeFinder : IViewTypeResolver
    {
        public Type GetType(string path)
        {

            ViewContext current = ContextService.Get().GetCurrent<ViewContext>();
            var partial = System.Web.Mvc.ViewEngines.Engines.FindPartialView((ControllerContext)current, path);
            var view = partial.View as PrecompiledMvcView;

            var type = typeof(PrecompiledMvcView).GetField("_type", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(view)
                as Type;

            Type baseType = type.BaseType;

            if (baseType == null || !baseType.IsGenericType)
            {
                Sitecore.Diagnostics.Log.Warn(string.Format(
                    "View {0} compiled type {1} base type {2} does not have a single generic argument.",
                    path,
                    type,
                    baseType), this);

                return typeof(NullModel);
            }

            Type proposedType = baseType.GetGenericArguments()[0];
            return proposedType == typeof(object)
                ? typeof(NullModel)
                : proposedType;
        }
    }
}