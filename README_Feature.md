![](nuget.png)
# Plugin.Maui.Rotatable

`Plugin.Maui.Rotatable` provides the ability to customize your presentation when the orientation changes inside a .NET MAUI application.

## Install Plugin

[![NuGet](https://img.shields.io/nuget/v/Plugin.Maui.Rotatable.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.Maui.Rotatable/)

Available on [NuGet](http://www.nuget.org/packages/Plugin.Maui.Rotatable) soon.

Install with the dotnet CLI: `dotnet add package Plugin.Maui.Rotatable`, or through the NuGet Package Manager in Visual Studio.

### Supported Platforms

| Platform | Minimum Version Supported |
|----------|---------------------------|
| iOS      | 11+                       |
| macOS    | 10.15+                    |
| Android  | 5.0 (API 21)              |
| Windows  | 11 and 10 version 1809+   |

## API Usage

`Plugin.Maui.Feature` provides the `RotatableImplementation` class that has a single property `IsPortrait` that you can get.

You can use it as a base class, e.g.: `{Binding IsPortrait}`

### Straight usage

You can enable your classes to depend on `RotatableImplementation` as per the following example.

```csharp
public class RotatableViewModel : RotatableImplementation
{
    
}
```

Then you can use property `IsPortrait` in your presentation as per the following example.

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    x:Class="MyAwesomeApp.MainPage"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:c="clr-namespace:MyAwesomeApp.Converters"
    xmlns:vm="clr-namespace:MyAwesomeApp.ViewModels">
    <ContentPage.BindingContext>
        <vm:MainPage />
    </ContentPage.BindingContext>
    <Grid ColumnDefinitions="*,2*,*" ColumnSpacing="0">
        <Grid Padding="10" BackgroundColor="Red">
            <Grid.Column>
                <Binding Path="IsPortrait">
                    <Binding.Converter>
                        <c:RotatableColumnConverter x:TypeArguments="x:Int32" />
                    </Binding.Converter>
                </Binding>
            </Grid.Column>
            <Grid.ColumnSpan>
                <Binding Path="IsPortrait">
                    <Binding.Converter>
                        <c:RotatableColumnSpanConverter x:TypeArguments="x:Int32" />
                    </Binding.Converter>
                </Binding>
            </Grid.ColumnSpan>
            <Label
                FontSize="Medium"
                HorizontalTextAlignment="Center"
                Text="I am customized for every orientation"
                TextColor="White"
                VerticalTextAlignment="Center" />
        </Grid>
    </Grid>
</ContentPage>
```

### Rotatable

Once you have overridden a `RotatableImplementation` you can interact with it in the following ways:

#### Properties

##### `IsPortrait`

Gets a value indicating whether the orientation is changed.

# Acknowledgements

This project could not have came to be without these projects and people, thank you! <3

## Plugin.Maui.Feature template

Basically the template for this plugin. We have been using this in our .NET MAUI projects with much joy and ease, so thank you so much [Gerald](https://github.com/jfversluis/) (and contributors!) for that. Find the original project [here](https://github.com/jfversluis/Plugin.Maui.Feature/) where we have based our project on and evolved it from there.