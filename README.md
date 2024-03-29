![](https://github.com/jpedretti/.NETCore3HelperExtensions/workflows/Build%20and%20Test/badge.svg) ![](https://github.com/jpedretti/.NETCore3HelperExtensions/workflows/Build%20and%20Publish/badge.svg)

# HelperExtensions

#### A set of extensions to maximize productivity and help writing cleaner code

### Get it on Nuget
[Donwload from nuget](https://www.nuget.org/packages/RJPSoft.HelperExtensions)

### What's New

#### V 1.2.0

Added forEachNotNull for the following types:

- `LinkedList`
- `SortedList`
- `HashSet` with an overload that receives a new comparer
- `SortedSet` with an overload that receives a new comparer
- `SortedDictionary`
- `Queue`
- `Stack`

#### V 1.1.0

- `ForEachNotNull`

  - Executes the specified Action on each not null element (class or struct) of an IEnumerable:

    ```C#
    var collection = new List<int?> { 1, 2, null };
    var intResult = new List<int>();
    collection.ForEachNotNull(value => intResult.Add(value));
    //intResult will be [1,2]
    ```

- `FilterNotNull`

    - Removes all null elements (class or struct) from as IEnumerable, List, Array, Set or Dictionary, returning the same type as the original:
    
    ```C#
    var collection = new List<Uri?>() { new Uri("file://local"), null, new Uri("https://github.com") };
    var notNullElements = collection.FilterNotNull();
    //notNullElements will be a List<Uri> wir values [Uri("file://local"), Uri("https://github.com")]
    ```


#### Dealing with nullable objects

Every day we have to write code to deal with nullable objects, even using the new C#8 nullable feature, and it's almost the same code every time. Why don't optimize it?
Using this set of extensions we can!

 Need to check if something is null before doing some operation over it? We can change this:
```c#
if (myNullableEntity != null)
{
    DoSomething(myNullableEntity);
    // wherever more you need
}
```

To this:
```c#
myNullableEntity.Run(notNullEntity => 
{
    DoSomething(notNullEntity);
    // wherever more you need	
});
```

If you need to use some data created based on your nullable entity you can do this:
```c#
if (myNullableEntity != null)
{
    DoSomething(myNullableEntity);
    // whatever more you need
    // lots ans lots of code that dependes on myNullableEntity value or somethig created from it
}
```
or this:
```c#
var myNewEntity = //whatever you need
if (myNullableEntity != null)
{
    //do something to calaculate your new value
    myNewEntity = /*some value based on myNullableEntity*/
}

//use your new value
```
or, you can change to a nice extension
```c#
var myNewEntity = myNullableEntity.Let(notNullEntity =>
{
    //do something to calaculate your new value
    return /*some value based on myNullableEntity*/;
});
//use your new value

//if your logic is short, can be done in one line
var myNewEntity = myNullableEntity.Let(notNullEntity => /*newvalue*/);
```
It's possible to use the nice Null-coalescing operator to handle the null scenario:
```c#
var myNewEntity = myNullableEntity.Let(notNullEntity => /*newvalue*/) ?? someValue;
```
