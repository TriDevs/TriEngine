TriEngine2D
===========

2D general-purpose engine in C#/OpenGL

IRC
---

TriDevs has an IRC channel, feel free to hop in if you have a question about anything:  
**Server:** irc.kottnet.net  
**Port:** 6667, 6697 (SSL)  
**Channel:** #TriDevs

The channel topic contains further info.

License
-------

Copyright © 2013 by [Adam Hellberg](https://github.com/Sharparam), [Sijmen Schoon](https://github.com/Vijfhoek) and [Preston Shumway](https://github.com/anidude).

TriEngine2D is licensed under the [MIT License](http://opensource.org/licenses/MIT), more info can be found in the **LICENSE** file.

Contributing
------------

You are free to fork this project and make your own changes, as long as you follow the MIT License.

If you want to make a pull request, please do so to the [main project](https://github.com/TriDevs/TriEngine2D) and not any of the "official" forks.

For your pull request to be accepted, please follow our coding style:
 * Indent with 4 spaces, not tabs.
 * Curly braces placed on next line.
 * All **public** methods, accessors and members must be properly documented.
 * Use sensible variable names that describe what they are for.
 * Method declarations written as:

```c#
public void Hello(string world)
```

 * If your method accepts many parameters, it can be useful to put parameters on separate lines, as per this style:

```c#
public void Hello(string world,
                  bool print)
```

 * Please write tests for your code (not strictly required, but it's a plus)

By looking through the current source code, you should be able to get a good understanding of the formatting we use.

If you're using Visual Studio, you can change the indent behaviour by going to: **Tools** -> **Options** -> **Text Editor** -> **C#** -> **Tabs** and make sure "Insert spaces" is checked.

If you write tests for your code, please place these tests in their own project: "&lt; **Namespace** &gt;.Tests", create said project if it does not exist (of type Class Library).

We use NUnit as test framework, feel free to use something else if you want to, but make sure you document what framework you are using and that it is freely available for anyone to obtain.

Dependencies
------------

TriEngine2D depends on [log4net](http://logging.apache.org/log4net/), which is included in the **libs/log4net** folder.

TriEngine2D depends on [OpenTK](http://www.opentk.com/), this is not included and you will have to build/install it yourself.  
OpenTK depends on OpenGL drivers being installed, they are usually in your normal video card drivers.

TriEngine2D depends on [Json.NET](http://json.codeplex.com/), this is not included, but is specified in the NuGet package config.  
If you [properly configure your NuGet settings](http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages#Using_NuGet_without_committing_packages_to_source_control), NuGet will automatically download Json.NET when building any projects that depend on it.

If you want to run the tests you will need to have [NUnit](http://www.nunit.org/) installed.
