# HelperExtensions
A set of extensions to maximize productivity and help writing cleaner code

### Get it on Nuget
[Donwload from nuget](https://www.nuget.org/packages/RJPSoft.HelperExtensions)

#### Dealing with nullable objects

Every day we have to write code to deal with nullable objects, even using the new C#8 nullable feature, and it's almost the same code every time. Why don't optimize it?</br>
Using this set of extensions we can!

 Need to check if something is null before doing some operation over it? We can change this:</br>
```c#
if (myNullableEntity != null)
{
	DoSomething(myNullableEntity);
	// wherever more you need
}
```

To this:</br>
```c#
myNullableEntity?.Run(notNullEntity => 
{
	DoSomething(notNullEntity);
	// wherever more you need	
});
```

If you need to use some data created based on your nullable entity you can do this:</br>
```c#
if (myNullableEntity != null)
{
	DoSomething(myNullableEntity);
	// whatever more you need
	// lots ans lots of code that dependes on myNullableEntity value or somethig created from it
}
```
or this:</br>
```c#
var myNewEntity = //whatever you need
if (myNullableEntity != null)
{
	//do something to calaculate your new value
	myNewEntity = //some value based on myNullableEntity
}

//use your new value
```
or, you can change to a nice extension
```c#
var myNewEntity = myNullableEntity?.Let(notNullEntity =>
{
	//do something to calaculate your new value
	return //some value based on myNullableEntity
});
//use your new value

//if your logic is short, can be done in one line
var myNewEntity = myNullableEntity?.Let(notNullEntity => //newvalue);
```
It's possible to use the nice Null-coalescing operator to handle the null scenario:</br>
```c#
var myNewEntity = myNullableEntity?.Let(notNullEntity => //newvalue) ?? someValue;
```
