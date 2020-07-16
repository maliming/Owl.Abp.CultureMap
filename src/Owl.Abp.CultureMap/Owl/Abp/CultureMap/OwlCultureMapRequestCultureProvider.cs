using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.RequestLocalization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Owl.Abp.CultureMap
{
    public class OwlCultureMapRequestCultureProvider : RequestCultureProvider
    {
        public override async Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var option = httpContext.RequestServices.GetRequiredService<IOptions<OwlCultureMapOptions>>().Value;

            var mapCultures = new List<StringSegment>();
            var mapUiCultures = new List<StringSegment>();

            var requestLocalizationOptionsProvider =
                httpContext.RequestServices.GetRequiredService<IAbpRequestLocalizationOptionsProvider>();
            foreach (var provider in (await requestLocalizationOptionsProvider.GetLocalizationOptionsAsync())
                .RequestCultureProviders)
            {
                if (provider == this)
                {
                    continue;
                }

                var providerCultureResult = await provider.DetermineProviderCultureResult(httpContext);
                if (providerCultureResult == null)
                {
                    continue;
                }

                var cultures = providerCultureResult.Cultures;
                var uiCultures = providerCultureResult.UICultures;

                mapCultures.AddRange(cultures.Where(x => x.HasValue)
                    .Select(culture => option.CulturesMaps.ContainsKey(culture.Value)
                        ? new StringSegment(option.CulturesMaps[culture.Value])
                        : culture));

                mapUiCultures.AddRange(uiCultures.Where(x => x.HasValue)
                    .Select(culture => option.UiCulturesMaps.ContainsKey(culture.Value)
                        ? new StringSegment(option.UiCulturesMaps[culture.Value])
                        : culture));

                if (mapCultures.Any() || mapUiCultures.Any())
                {
                    break;
                }
            }

            if (mapCultures.IsNullOrEmpty() || mapUiCultures.IsNullOrEmpty())
            {
                return await NullProviderCultureResult;
            }

            return new ProviderCultureResult(mapCultures, mapUiCultures);
        }
    }
}
