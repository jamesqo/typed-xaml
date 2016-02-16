# Typed XAML

<img src="http://i.imgur.com/dm65ZkB.png" width="25%"/>

Make full use of .NET generics in your WPF and Windows 10 projects.

## Introduction

If you're a XAML developer, you probably know that you have to write lots of type-unsafe code when implementing MVVM. For example, let's say you have a square and you want to change its width whenever the height changes. You would probably implement it like this:

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

Yuck! The code is filled with casts and things like `typeof`, and the `DependencyPropertyChangedEventArgs` makes the function look like a overstretched diving board. Is there any way we can fix this?

Enter **Typed XAML**. Once refactored, the code above now looks like this:

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

That's it! No casting, no `typeof`, and as an added bonus the syntax for the getter/setter has been shortened.

## License

[MIT](LICENSE)
