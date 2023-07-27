# Introduction 
This is an example solution to illustrate how to create an NUnit unit test project that tests a .NET MAUI app.  
It also includes a few examples and suggestions on how to help make your tests better.

# Known Issues
 1. In order to get the MAUI app to run and have avail. simulators/devices to run against in VS, uncomment the noted TargetFrameworks line in the MauiAppToTest.csproj file and comment out the existing TargetFrameworks line.
    
 Before:  
 <img width="418" src="https://github.com/TomSoderling/NUnitTestableMauiApp/assets/18268845/f64e203c-98d1-471d-b5ca-f17d2e8be6bb">  
 After:  
 <img width="521" src="https://github.com/TomSoderling/NUnitTestableMauiApp/assets/18268845/b2a9ad9d-b89d-40b7-a728-21b03d0bccb1">


 2. Since the unit test project must target the "plain" net7.0 TFM, so must the MAUI app that is referenced by the unit test project. Some NuGet packages you add to your app project may not include the net7.0 TFM, so that will cause build errors that it can't find the namespace/class from that library when you attempt to use it your MAUI app code. I haven't found a good way to deal with this yet - outside of getting the library source, adding that TFM, and rebuilding the library.
