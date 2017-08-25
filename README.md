# PeteLazuran.com

#### Week 4 .NET independent project, 08.25.17

#### **By Pete Lazuran**

## Description

This is a personal website to tell the user about me and showcase my most popular Github repositories.

## Setup/Installation Requirements

To run this project:

* Clone this repository to your desktop
* Open Visual Studio, click "file", "open", "project/solution"
* In the finder open the cloned "PeteLazuran.com" directory, then open the solution "PeteLazuran"
* Right click the "Models" folder and choose "add", "...new item"
* Create a **Class** file and name it **"EnvironmentVariables.cs"**
* Copy and paste this snippet into the file you created, adding your own Github credentials in the quotes
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeteLazuran.Models;

namespace PeteLazuran.Models
{
    public class EnvironmentVariables
    {
        public static string username = "<your username>";
        public static string token = "<your password>";
    }
}

```
* Click the IIS Express button (middle of the toolbar) to view the site.


## Support and contact details

If you have any issues or have questions, ideas, concerns, or contributions please contact me through through Github.

## Known Bugs

None

## Technologies Used

* Visual Studio 2015
* C# / ASP.NET
* RestSharp
* JSON
* HTML
* CSS
* Bootstrap

### License
This software is licensed under the MIT license.

Copyright (c) 2017 **Pete Lazuran**
