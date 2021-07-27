M&G Distribution Candidate Test


------------------------------------------------------------------
There are two class libraries in solution
1. Actual implementation of the given requirement  - SEDOL
2. Unit Test Project - SEDOL.UnitTest- consists of unit test cases for each scenario


Brief description about actual implementation- SEDOL
It consists of following files and folder
Folder Name- Inteface
1. ISedolValidator
2. ISedolValidationResult

FolderName - Validations
SedolValidations.cs

Constants
Constants.cs - for constants values 

SedolValidationResult class implementing ISedolValidationResult interface
SedolValidator class implementing ValidateSedol method of ISedolValidationResult interface and returns SedolValidationResult object

Entry point - SedolValidator.ValidateSedol(input) is entry point of the application which is taking input and calling SedolValidations class methods and properties for
checking given validations and returning SedolValidationResult class object as result

So to test the given code in test engine, we will have to call SedolValidator.ValidateSedol(input) method in test project










