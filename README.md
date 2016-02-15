# Typed XAML

Make full use of .NET generics in your WPF and Windows 10 projects.

## Introduction

If you're a WPF or Windows 10 developer, you're no doubt aware of the massive amount of boilerplate, type-unsafe code you must write to get things done. For example, here is how you would register a dependency property on an object:

```csharp
public class Square : DependencyObject
{
    public static readonly DependencyProperty HeightProperty =
        DependencyProperty.Register(
            nameof(Height),
            typeof(int),
            typeof(Square),
            new PropertyMetadata(0, OnHeightChanged));
    
    public int Height
    {
        get { return (int)GetValue(HeightProperty); }
        set { SetValue(HeightProperty, value); }
    }
    
    private static void OnHeightChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var square = (Square)sender;
        var newValue = (int)e.NewValue;
        square.Width = newValue;
    }
}
```

Yuck! Not only did we [TBC], but we [TBC].

Enter **Typed XAML**. With [this library], the code above now looks like this:

```csharp
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

TBC

## License

[MIT](LICENSE)
