# Introduction 
This is an example solution to illustrate how to create an NUnit unit test project that tests a .NET MAUI app.

# Known Issues
 1. In order to get the MAUI app to run and have avail. simulators/devices to run against in VS, uncomment the noted TargetFrameworks line in the MauiAppToTest.csproj file and comment out the existing TargetFrameworks line.

 2. Since the unit test project must target the "plain" net7.0 TFM, so must the MAUI app that is referenced by the unit test project. Some NuGet packages you add to your app project may not include the net7.0 TFM so that will cause NuGet restore or NuGet package manager issues. I haven't found a good way to deal with this yet - outside of getting the library source, adding that TFM, and rebuilding the library.
