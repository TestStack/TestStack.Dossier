NTestDataBuilder
================

NTestDataBuilder provides you with the code instructure to easily and quickly generate test fixture data for your automated tests in a terse, readable and maintainable way using the Test Data Builder pattern.

For more information please see the [blog post](http://robdmoore.id.au/blog/2013/05/26/test-data-generation-the-right-way-object-mother-test-data-builders-nsubstitute-nbuilder/) that gives the theory behind the approach this library was intended for and the [presentation and example code](https://github.com/robdmoore/TestFixtureDataGenerationPresentation) that gives a concrete example of the usage of the library (and the theory behind it).

NTestDataBuilder is integrated with NSubstitute for proxy/mock/substitute object generation and NBuilder for terse list generation.

How do I get started?
---------------------

1. `Install-Package NTestDataBuilder`
2. Create a builder class for one of your objects, e.g. if you have a customer:
```c#
    // Customer.cs
    
    public class Customer
    {
        protected Customer() {}

        public Customer(string firstName, string lastName, int yearJoined)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException("firstName");
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("lastName");

            FirstName = firstName;
            LastName = lastName;
            YearJoined = yearJoined;
        }

        public virtual int CustomerForHowManyYears(DateTime since)
        {
            if (since.Year < YearJoined)
                throw new ArgumentException("Date must be on year or after year that customer joined.", "since");
            return since.Year - YearJoined;
        }

        public virtual string FirstName { get; private set; }
        public virtual string LastName { get; private set; }
        public virtual int YearJoined { get; private set; }
    }
    
    // CustomerBuilder.cs
    
    class CustomerBuilder : TestDataBuilder<Customer, CustomerBuilder>
    {
        public CustomerBuilder()
        {
            WithFirstName("Rob");
            WithLastName("Moore");
            WhoJoinedIn(2013);
        }

        public CustomerBuilder WithFirstName(string firstName)
        {
            Set(x => x.FirstName, firstName);
            return this;
        }

        public CustomerBuilder WithLastName(string lastName)
        {
            Set(x => x.LastName, lastName);
            return this;
        }

        public CustomerBuilder WhoJoinedIn(int yearJoined)
        {
            Set(x => x.YearJoined, yearJoined);
            return this;
        }

        protected override Customer BuildObject()
        {
            return new Customer(
                Get(x => x.FirstName),
                Get(x => x.LastName),
                Get(x => x.YearJoined)
            );
        }
    }
```
3. Use the builder in a test, e.g.
```c#
    var customer = new CustomerBuilder().WithFirstName("Robert").Build();
```
4. Consider using the Object Mother pattern in combination with the builders, see [my blog post](http://robdmoore.id.au/blog/2013/05/26/test-data-generation-the-right-way-object-mother-test-data-builders-nsubstitute-nbuilder/) for a description of how I use this library.

How can I create a list of entities using my builders?
------------------------------------------------------

This library integrates with [NBuilder](http://nbuilder.org/) for generating lists of entities, this means you can call the `CreateListOfSize` static method on your builder class and then use NBuilder syntax from there. Then when you are ready to create a list of entities call the `BuildList` method rather than the usual NBuilder `Build` method. e.g.:

```c#
    var customers = CustomerBuilder.CreateListOfSize(3)
        .TheFirst(2).With(b => b.WithFirstName("Rob"))
        .TheNext(1).With(b => b.WithFirstName("Matt"))
        .BuildList<Customer, CustomerBuilder>();
```

If you don't want to have to specify the type of object and builder everywhere then simply add a couple of extension methods next to your builder class:

```c#
    static class CustomerBuilderExtensions
    {
        public static IList<Customer> BuildList(this IOperable<CustomerBuilder> list)
        {
            return list.BuildList<Customer, CustomerBuilder>();
        }

        public static IList<Customer> BuildList(this IListBuilder<CustomerBuilder> list)
        {
            return list.BuildList<Customer, CustomerBuilder>();
        }
    }
    
    // Then your test can use:
    
    var customers = CustomerBuilder.CreateListOfSize(3)
        .TheFirst(2).With(b => b.WithFirstName("Rob"))
        .TheNext(1).With(b => b.WithFirstName("Matt"))
        .BuildList();
```

How can I create proxy objects?
-------------------------------

This library integrates with [NSubstitute](http://nsubstitute.github.io/) for generating proxy objects, this means you can call the `AsProxy` method on your builder to request that the result from calling `Build` will be an NSubstitute proxy with the public properties set to return the values you have specified via your builder, e.g.

    var customer = CustomerBuilder.WithFirstName("Rob").AsProxy().Build();
    customer.CustomerForHowManyYears(Arg.Any<DateTime>()).Returns(10);
    var name = customer.FirstName; // "Rob"
    var years = customer.CustomerForHowManyYears(DateTime.Now); // 10

If you need to alter the proxy before calling `Build` to add complex behaviours that can't be expressed by the default public properties returns values then you can override the `AlterProxy` method in your builder, e.g.

```c#
    class CustomerBuilder : TestDataBuilder<Customer, CustomerBuilder>
    {
        // ...
        
        private int _years;
        
        public CustomerBuilder HasBeenMemberForYears(int years)
        {
            _years = years;
            return this;
        }
        
        protected override void AlterProxy(Customer proxy)
        {
            proxy.CustomerForHowManyYears(Arg.Any<DateTime>()).Returns(_years);
        }
        
        // ...
    }
    
    // Then in your test you can use:
    
    var customer = new CustomerBuilder().AsProxy().HasBeenMemberForYears(10);
    var years = customer.CustomerForHowManyYears(DateTime.Now); // 10
```

*Remember that when using proxy objects of real classes that you need to mark properties and methods as virtual and have a protected empty constructor.*

Why does NTestDataBuilder have NSubstitute and NBuilder as dependencies?
------------------------------------------------------------------------

NTestDataBuilder is an opinionated framework and as such prescribes how to build your fixture data, including how to build lists and how to build mock objects. Because of this we have decided to bundle it with the two best of breed libraries for this purpose: NBuilder and NSubstitute.

This allows for this library to provide a rich value-add on top of the basics of tracking properties in a dictionary in the `TestDataBuilder` base class. If you want to use different libraries or want a cut down version that doesn't come with NSubstitute or NBuilder and the extra functionality they bring then take the `TestDataBuilder.cs` file and cut out the bits you don't want - open source ftw :).

If you have a suggestion for the library that can incorporate this value-add without bundling these libraries feel free to submit a pull request.

Contributions / Questions
-------------------------

If you would like to contribute to this project then feel free to communicate with me via Twitter @robdmoore or alternatively submit a pull request / issue.
