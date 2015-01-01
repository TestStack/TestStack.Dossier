NTestDataBuilder Breaking Changes
=================================

Version 2.0.0
-------------

The way that lists are generated no longer uses NBuilder - the new syntax is backwards compatible with NBuilder except that the namespace you need to include is different. You can also refactor your list generation to be a lot more terse, but that is optional. Any `BuildList` extension methods you created will now need to be deleted since they are no longer needed.

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

Simply add the following to the files that generate lists of builders and the existing syntax should work:

```
using NTestDataBuilder.Lists;
```

If you uninstall the NBuilder package then you will need to remove the using statements for that library too.

Also, remove any `BuildList` extension methods you created.
