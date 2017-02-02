Imports System.IO	'MUST HAVE THIS FOR FILE ACCESS

Module modStudent

	Public Sub RunProject()

		'Name: File IO - Basic Write
		'Purpose: Demonstrates basic file writing
		'Author: CIS 122
		'Date: 11/19/14

		'>>> The purpose of this project is to demonstrate basic file OUTPUT. So far, we've been READING from files, but now it's time to WRITE to a file.

		'Constants
		'>>> Similarly to what we did before, we'll create a constant to store the path of the file we're going to write to.  Keep in mind that the file will be created in the same folder as our .exe file - most likely "bin\Debug".
		Const c_sOutputFilePath As String = "BasicWrite.txt"

		'Variables
		Dim sText As String = ""  '>>> We'll use a string a variable to store the text we're going to write to the output file.
		'>>> When we read from a file, we needed to use a StreamReader variable. But when *writing* to a file, we use a StreamWriter variable. Notice the "file" prefix I'm using to designate that this variable works with files. I've decided to name the file "fileOutput", which makes it nice and clear that we're going to write to it.
		Dim fileOutput As StreamWriter


		'Begin Code
		SetTitle("File IO - Basic Write")

		'>>> Now we have to create the file we're going to write to. If the file already exists, its contents will be wiped out.
		'We use "File.CreateText" to create a simple empty text file. It's a function and it expects to be given the path of the output file you want to create. So, we pass it our constant that we created up above.
		'But that's not all, folks. CreateText returns a special piece of data that we need. It returns a "file handle" - a StreamWriter variable type. We declared this variable up above, and now we're going to make use of it:
		fileOutput = File.CreateText(c_sOutputFilePath)
		'>>> From now on in out program, we will use the fileOutput variable to work with the file.
		'Note: if you want *append* text to a file instead of wiping out the existing contents, use File.AppendText instead of File.CreateText.


		'>>> And now it's time to actually write to the file. To do this, we must use our StreamWriter variable, fileOutput. The StreamWriter variable has a special function called "WriteLine" that we can use to write a single line of text to our file. For example:
		fileOutput.WriteLine("This is the first line of text.")
		'Note that WriteLine will also write out a newline character after the text, which causes whatever is written next time to begin on the NEXT line, instead of the same line.
		'Now our text file will contain one line of text.  Let's write some more...

		'>>> Using a For loop, we're going to write out 10 lines of text. Notice the we're using the For loop's "counter" variable (i) as part of our text.  Take a look:
		For i As Integer = 1 To 10
			fileOutput.WriteLine("Line " & i)
		Next
		'Can you guess what the above code is writing out? Run the program, open the text file with Notepad (or something similar) and find out. Close the file when you're done looking at it.

		'>>> Remember to close the file
		fileOutput.Close()


		'>>> NOTE: To write a blank line to a file, do this:  fileOutput.WriteLine()

	End Sub

End Module