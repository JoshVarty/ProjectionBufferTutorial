ProjectionBufferTutorial
========================

Full explanation and tutorial at: [http://joshvarty.wordpress.com/2014/08/01/ripping-the-visual-studio-editor-apart-with-projection-buffers/](http://joshvarty.wordpress.com/2014/08/01/ripping-the-visual-studio-editor-apart-with-projection-buffers/)

**Note**: This project must be deployed to an instance of Visual Studio using Roslyn. The Language Services were rewritten to properly handle projection buffers.

This project demonstrates the use of projection buffers with C# Language Services.

:exclamation: :exclamation:
Before running, you must modify the [filePath](https://github.com/JoshVarty/ProjectionBufferTutorial/blob/master/ProjectionBufferTutorial/ProjBufferToolWindow.cs#L26) string in [MyToolWindow.cs](https://github.com/JoshVarty/ProjectionBufferTutorial/blob/master/ProjectionBufferTutorial/ProjBufferToolWindow.cs).   It must point to a valid C# file on your machine.
:exclamation: :exclamation:

After downloading, you must modify the properties of the project as follows:

  1. Right click the project and select Properties
  
  2. Choose Debug
  
  3. Choose Start External program and use the path to devenv.exe
  
  4. Set the command line arguments to "/rootsuffix Exp"
  
  5. Save and then run.
  
  6. Open the C# solution that contain C# file you specificed in [filePath](https://github.com/JoshVarty/ProjectionBufferTutorial/blob/master/ProjectionBufferTutorial/MyToolWindow.cs#L24)
  
  7. View > Other Windows > ProjectionBufferTutorial
