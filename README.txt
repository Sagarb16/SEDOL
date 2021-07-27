M&G Distribution Candidate Test


------------------------------------------------------------------
There are two class libraries in solution
1. Actual implementation of the given requirement  - SEDOL
2. Unit Test Project - SEDOL.Test


Brief description about actual implementation- SEDOL
It consists of following files and folder
Inteface
1. ISedolValidator
2. ISedolValidationResult

Constants
Constants.cs - constants values 

SedolValidationResult class implementing ISedolValidationResult interface
SedolValidator class implementing ValidateSedol method of ISedolValidationResult interface

So SedolValidator.ValidateSedol() is entry point application which is taking input and calling SedolValidations class methods and properties for
performing given validations and returning SedolValidationResult class object as result







