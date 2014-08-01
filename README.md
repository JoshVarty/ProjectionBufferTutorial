ProjectionBufferTutorial
========================

Note: This project must be deployed to an instance of Visual Studio using Roslyn.

This project demonstrates the use of projection buffers with C# Language Services.

Before running, you must modify the *filePath* string in MyToolWindow.cs. It must point to a valid C# file on your machine.

After downloading, uou must modify the properties of the project as follows:

  1. Right click the project and select Properties
  
  2. Choose Debug
  
  3. Choose Start External program and use the path to devenv.exe
  
  4. Set the command line arguments to "/rootsuffix Exp"
  
  5. Save and then run.
  
  6. Open the C# solution that contain C# file you specificed in *filePath*
  
  7. View > Other Windows > ProjectionBufferTutorial
