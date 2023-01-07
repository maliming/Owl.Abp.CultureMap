using System.Collections.Generic;

namespace Owl.Abp.CultureMap;

public class CultureMapInfo
{
    public string TargetCulture { get; set; }

    public List<string> SourceCultures { get; set; }
}
