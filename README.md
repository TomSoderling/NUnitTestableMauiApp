# Introduction 
This is a sample unit test project to illustrate how to write NUnit based unit tests in C# for mobile apps using the .NET MAUI framework.
The purpose of this sample is to convey best practices for writing and structuring unit tests. The sample contains a collection of reference unit tests for testing common mobile app scenarios, or scenarios that can be tricky to test.

In this sample, fake objects are created with the FakeItEasy library. Docs: https://fakeiteasy.github.io  


# Getting Started
- Clone the repo and explore!
- Each test can be debugged in place with the VS debugger so you can step though the reference unit tests and see how they work.  


# Unit Test Naming Convention
Naming each test clearly and consistently helps explain the test to developers who aren't familiar with it. We found that clearly spelling out these 3 pieces of information also helps developers understand what exactly they're trying to test when writing the test.
The naming convention is made up of 3 parts: `UnitUnderTest_StateUnderTest_ExpectedResult`
  - `UnitUnderTest` : what method, member, or code block is being tested.
  - `StateUnderTest` : the condition or case being tested.
  - `ExpectedResult` : what the outcome of the test should be. Should match what Assert statements you have.
  
# Unit Test Outline
In the test method block, use the AAA pattern to organize your test in a clear and consistent way
- `Arrange` : set up variables, constants, etc. for the test. Expected results. Instance of Model, ViewModel, or Service to be tested
- `Act` : perform the test and save result to a variable. Should be simple; shouldn't need to do a lot here if you've used the Arrange section correctly.
- `Assert` : Assert statements to check that the actual result matches the expected results.