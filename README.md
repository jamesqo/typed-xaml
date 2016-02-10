# Typed XAML

Make full use of .NET generics in your WPF and Windows 10 projects.

## Introduction

If you're a WPF or Windows 10 developer, you're no doubt aware of the massive amount of boilerplate, type-unsafe you must write to get things done. For example, here is how you would register a dependency property on an object:

```csharp
public static readonly DependencyProperty FooProperty =
    DependencyProperty.Register(
        nameof(Foo),
        typeof(string),
        typeof(ThisClass),
        new PropertyMetadata(null, OnFooChanged));

public string Foo
{
    get { return (string)GetValue(FooProperty); }
    set { SetValue(FooProperty, Value); }
}

private static void OnFooChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
{
    var newValue = (string)e.NewValue;
    Console.WriteLine(newValue);
}
```

Yuck! Not only did we [TBC], but we [TBC].

Enter **Typed XAML**. With [this library], the code above now looks like this:

```csharp
public static readonly DependencyProperty FooProperty =
    Dependency.Register<string, ThisClass>(nameof(Foo), OnFooChanged);

public string Foo
{
    get { return this.Get<string>(FooProperty); }
    set { this.Set(FooProperty, value); }
}

private static void OnFooChanged(ThisClass sender, IPropertyChangedArgs<string> e)
{
    Console.WriteLine(e.NewValue);
}
```

TBC

## License

[MIT](LICENSE)
