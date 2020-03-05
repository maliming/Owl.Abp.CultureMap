# Owl.Abp.CultureMap

Owl.Abp.CultureMap can help you map the language code to the specified language.


## Install

```ps
dotnet add package Owl.Abp.CultureMap
```

## Getting Started

```c#
public override void ConfigureServices(ServiceConfigurationContext context)
{
	Configure<AbpLocalizationOptions>(options =>
	{
		options.Languages.Add(new LanguageInfo("en", "en", "English"));
		options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
		options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
	});
	
	Configure<OwlCultureMapOptions>(options =>
	{
		//Map some language-specific codes to zh-Hans.
		var maps = new Dictionary<string, string>
		{
			{"zh", "zh-Hans"},
			{"zh-CN", "zh-Hans"},
			{"zh-Hant", "zh-Hans"},
			{"zh-TW", "zh-Hans"}
		};
		
		options.CulturesMaps = maps;
		options.UiCulturesMaps = maps;
	});
}
		
public override void OnApplicationInitialization(ApplicationInitializationContext context)
{
	var app = context.GetApplicationBuilder();
	
	//...

	app.UseOwlRequestLocalization();
	
	//...
}
```

## Example
