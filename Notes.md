# Notes

Notes to myself regarding this DDD Lab workshop.


# Setup

I created new branch from _3.0_Lab1Start_ tag (commit: 4cfbb077) in order to go through all lab steps one-by-one. The branch is named _my-walkthough_.

In order to be able to run the solution, I had to enable SSL for the web project (by selecting _Enable SLL_ checkbox on _Debug_ tab of project properties.

Since version 3.0, ASP.NET Core does not include EF, so it needs to be installed manually. To do so, execute the following cmdlet:

```powershell
dotnet tool install --global dotnet-ef
```

