# Owl.Abp.CultureMap

it can help you map the language code to the specified language.

![Nuget](https://img.shields.io/nuget/v/Owl.Abp.CultureMap?style=plastic)

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
        var zhHansCultureMapInfo = new CultureMapInfo
        {
            TargetCulture = "zh-Hans",
            SourceCultures = new List<string>
            {
                "zh", "zh-CN"
            }
        };

        options.CulturesMaps.Add(zhHansCultureMapInfo);
        options.UiCulturesMaps.Add(zhHansCultureMapInfo);
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

[BookStore](https://github.com/maliming/Owl.Abp.CultureMap/tree/master/example/BookStore)
