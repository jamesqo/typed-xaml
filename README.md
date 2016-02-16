# Typed XAML

<img src="http://i.imgur.com/dm65ZkB.png" width="25%"/>

Make full use of .NET generics in your WPF and Windows 10 projects.

## Installation

It's as easy as:

```powershell
Install-Package Typed.Xaml
```

## What can it do?

Typed XAML:

- makes your code more readable
- introduces a cleaner syntax for expressing types
- lets you easily create dependency properties, free of casting and `typeof`
- provides generic base classes that can work with the type-unsafe APIs

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

That's it! No casting, no `typeof`, and as an added bonus the getter/setters are clearer to read.

## License

[MIT](LICENSE)
