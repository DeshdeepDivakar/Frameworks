# Frameworks

Here is a quick example of Page Object Model using Page Factories.

The demoframework have 02 projects 
  1. demoframework
  2. demoUISpecTest
 
demoframework - Is the boilerplate code that would be used across all the UISpec test projects.
It has a Static class which act as an library named Initialiser.cs. Additionally, you could have other utility classes.
On the other hand demoUISpectests - is the project with your page models/page definitions, feature/scenario file and step definitions.

Another class BeforeAfterSteps.cs sits at the solution level to abstract the Before and After scenario/feature steps.
Additionally, this also caters for basic implementation of Extent Reports library. Find more details in Stepdefinition file. 



 
