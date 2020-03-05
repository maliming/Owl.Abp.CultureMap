using System.Collections.Generic;

namespace Owl.Abp.CultureMap
{
    public class OwlCultureMapOptions
    {
        public Dictionary<string, string> CulturesMaps = new Dictionary<string, string>();
        
        public Dictionary<string, string> UiCulturesMaps = new Dictionary<string, string>();
    }
}