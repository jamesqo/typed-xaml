# Typed XAML

<img src="http://i.imgur.com/dm65ZkB.png" width="25%"/>

![](https://travis-ci.org/jamesqo/typed-xaml.svg) ![](https://ci.appveyor.com/api/projects/status/github/jamesqo/typed-xaml?branch=master&svg=true)

Make full use of .NET generics in your WPF and Windows 10 projects.

## Installation

It's as easy as:

```powershell
Install-Package Typed.Xaml
```

## Supported Platforms

- .NET Framework 4.5+
- Windows 10 (of course)
- Windows and Windows Phone 8.1

## What can it do?

Typed XAML has three main goals:

- it lets you write your MVVM code in modern, generic C#
- it provides classes that bridge with the type-unsafe APIs
- it does not force you to refactor existing codebases

## Show me!

Here's a simple example, showing how you would bind a square's width to its height:

```csharp
using Typed.Xaml;

public class Square : DependencyObject
{
    public static readonly DependencyProperty HeightProperty =
        Dependency.Register<int, Square>(nameof(Height), OnHeightChanged);
    
    public int Height
    {
        get { return this.Get<int>(HeightProperty); }
        set { this.Set(HeightProperty, value); }
    }
    
    private static void OnHeightChanged(Square square, IPropertyChangedArgs<int> e)
    {
        square.Width = e.NewValue;
    }
}
```

Note the lack of any casting/`typeof` operators, which we would have to (ab)use in vanilla MVVM.

## How does it work?

This philosophy of Typed XAML is that *it's just syntax sugar.* All it does is call into the existing APIs you know and <s>hate</s> love. For example, here is how the `Get` and `Set` extension methods for `DependencyObject` are written:

```csharp
public static T Get<T>(this DependencyObject obj, DependencyProperty property)
{
    return (T)obj.GetValue(property);
}

public static void Set<T>(this DependencyObject obj, DependencyProperty property, T value)
{
    obj.SetValue(property, value);
}
```

As you can see, all they're doing is calling into existing functions. While this may not provide a huge functional benefit, it *does* allow you to write cleaner code like this:

```csharp
public string Foobar
{
    get { return this.Get<string>(FoobarProperty); }
    set { this.Set(FoobarProperty, value); }
}
```

as opposed to this:

```csharp
public string Foobar
{
    get { return (string)GetValue(FoobarProperty); }
    set { SetValue(FoobarProperty, value); }
}
```

## More Features

### Type-safe commands

Typed XAML allows you to easily create commands like this:

```csharp
using Typed.Xaml.Commands;

public class MyCommand : Command<string>
{
    public override void Execute(string param)
    {
        Console.WriteLine(param);
    }
}
```

The `Command<T>` base class implements `ICommand`, which means you can easily call your command from XAML:

```xaml
<Page.Resources>
    <local:MyCommand x:Key="ClickedCommand"/>
</Page.Resources>

<Button Command="{StaticResource ClickedCommand}"
        CommandParameter="Hello, world!"/>
```

#### Instructions

Don't want to go through the hassle of defining a new class? You can use `Instruction`, which lets you define your command dynamically. For example, here's the above code rewritten to use instructions:

```csharp
// In your code-behind...
public Command<string> WriteLine { get; } = new Instruction<string>(Console.WriteLine);
```

```xaml
<!-- In your XAML... -->
<Button Command="{Binding WriteLine}"
        CommandParameter="Hello, world!"/>
```

### Value converters

You can create a value converter like this:

```csharp
using Typed.Xaml.Converters;

public class MyConverter : Converter<object, string>
{
    // convert objects to strings
    public override string Convert(object value, CultureInfo culture)
    {
        return $"{value} :)";
    }
}
```

Similarly to the `Command` APIs, here's how you would use it from XAML:

```xaml
<Page.Resources>
    <local:MyConverter x:Key="SmileyConverter"/>
</Page.Resources>

<TextBox x:Name="TextBox" Text="Have a nice day"/>

<Button Content="{Binding Text,
                  ElementName=TextBox,
                  Converter={StaticResource SmileyConverter}}"/> <!-- displays 'Have a nice day :)' -->
```

## API Reference

TBC.

## License

[MIT](LICENSE)
