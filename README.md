TriEngine2D
===========

2D general-purpose engine in C#/OpenGL

License
-------

Copyright © 2013 by [Adam Hellberg](https://github.com/Sharparam), [Sijmen Schoon](https://github.com/Vijfhoek) and [Preston Shumway](https://github.com/anidude).

TriEngine2D is licensed under the [MIT License](http://opensource.org/licenses/MIT), more info can be found in the **LICENSE** file.

Dependencies
------------

TriEngine2D depends on [log4net](http://logging.apache.org/log4net/), which is included in the **libs/log4net** folder.

TriEngine2D depends on [OpenTK](http://www.opentk.com/), this is not included and you will have to build/install it yourself.  
OpenTK depends on OpenGL drivers being installed, they are usually in your normal video card drivers.

TriEngine2D depends on [Json.NET](http://json.codeplex.com/), this is not included, but is specified in the NuGet package config.  
If you [properly configure your NuGet settings](http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages#Using_NuGet_without_committing_packages_to_source_control), NuGet will automatically download Json.NET when building any projects that depend on it.

If you want to run the tests you will need to have [NUnit](http://www.nunit.org/) installed.
