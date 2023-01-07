using System.Collections.Generic;

namespace Owl.Abp.CultureMap;

public class OwlCultureMapOptions
{
    public readonly List<CultureMapInfo> CulturesMaps = new List<CultureMapInfo>();

    public readonly List<CultureMapInfo> UiCulturesMaps = new List<CultureMapInfo>();
}