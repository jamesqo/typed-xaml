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
    get { return (string)this.GetValue(FoobarProperty); }
    set { this.SetValue(FoobarProperty, value); }
}
```

## API Reference

TBC.

## License

[MIT](LICENSE)
