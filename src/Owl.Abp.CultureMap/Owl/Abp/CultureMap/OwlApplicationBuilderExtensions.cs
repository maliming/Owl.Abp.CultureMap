using System;
using Microsoft.AspNetCore.Builder;

namespace Owl.Abp.CultureMap
{
    public static class OwlApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseOwlRequestLocalization(this IApplicationBuilder app,
            Action<RequestLocalizationOptions> optionsAction = null)
        {
            return app.UseAbpRequestLocalization(options =>
            {
                optionsAction?.Invoke(options);
                options.RequestCultureProviders.Insert(0, new CultureMapRequestCultureProvider());
            });
        }
    }
}