NTestDataBuilder Breaking Changes
=================================

Version 2.0.0
-------------

When you don't `Set` a default value for a property that you later `Get` in your builder it will now generate an anonymous value for that property rather than throwing an exception.

### Reason

This is part of the work to make anonymous values a first class citizen of the library and to make it easier and quicker to tersely set up builders. This avoids the need to have boilerplate `Set` calls in your builder constructor and also means that when you generate a list of objects each object will have a different value (by default).

### Fix

The old behaviour of throwing an exception if a value hasn't been specified is no longer supported - use NTestDataBuilder version 1 if you want that or raise an issue on GitHub to explain your use case.

If you want to fix a static value for a property then by all means you can still use `Set` calls in your builder constructor. If you aren't happy with the default anonymous value that is generated for a property you can use the `Any` property to generate a value from a different equivalence class in combination with a `Set` call in your builder constructor.

Version 2.0.0
-------------

The way that lists are generated no longer uses NBuilder - the new syntax is backwards compatible with NBuilder except that the namespace you need to include is different. You can also refactor your list generation to be a lot more terse, but that is optional. Any `BuildList` extension methods you created will now need to be deleted since they are no longer needed. You also need to ensure that all of the methods you call are marked virtual so the list generation can proxy those method calls.

### Reason
In order to support a new, much terser syntax for generating lists we rewrote the list generation code ourselves. You can now do this:

```c#
	var customers = CustomerBuilder.CreateListOfSize(3)
		.TheFirst(1).WithFirstName("Robert")
		.TheLast(1).WithEmail("matt@domain.tld")
		.BuildList();
```

That's instead of this syntax (which still works as well):

```c#
	var customers = CustomerBuilder.CreateListOfSize(3)
		.TheFirst(1).With(b => b.WithFirstName("Robert"))
		.TheLast(1).With(b => b.WithEmail("matt@domain.tld"))
		.BuildList();
```

You also no longer need a custom extension method for the `BuildList` method so you will need to delete any of these that you have created. If you don't use NBuilder's features outside of the list generation you may uninstall the NBuilder package.

### Fix

Simply add the following to the files that generate lists of builders and change your builder modification methods to be virtual and the existing syntax should work:

```
using NTestDataBuilder.Lists;
```

Assuming you aren't using NBuilder for anything other than generating lists of entities with NTestDataBuilder 1.0 you should be abke to do a global find and replace against `using FizzWare.NBuilder;`.

If you uninstall the NBuilder package then you will need to remove the using statements for that library too.

Also, remove any `BuildList` extension methods you created.
