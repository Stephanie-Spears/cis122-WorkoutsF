Imports System.IO	'MUST HAVE THIS FOR FILE ACCESS

Module modStudent

	Public Sub RunProject()

		'Name: File IO - ReadWrite -Scores
		'Purpose: Demonstrates file reading
		'Author: CIS 122
		'Date: 11/19/14

		'>>> This program is very similar to the program that read scores from a file and then displayed into to the screen. We're going to do the exact same thing, only this time, we're outputting to a file instead of the screen.  So, we'll be working with TWO files at the same time - our input file (the file we're reading from), and an output file (the file we're writing to).

		'Constants
		Const c_sInputFilePath As String = "Scores.txt"	'>>> the path to our input file
		Const c_sOutputFilePath As String = "ScoresReport.txt"	'>>> the path to our output file

		'Variables
		Dim fileInput As StreamReader	'>>> For the input file, we need a variable of type StreamReader, just as we did before.
		Dim fileOutput As StreamWriter '>>> For the output file, we need a variable of type StreamWriter, just as we used in the Basic Write workout.
		Dim sName As String = ""
		Dim dTotal As Double = 0
		Dim dScore As Double = 0
		Dim dAverage As Double = 0


		'Begin Code
		SetTitle("File IO - ReadWrite -Scores")

		'>>> Get our "file handles" so we can work with the files
		fileInput = File.OpenText(c_sInputFilePath) '>>> open the input file 
		fileOutput = File.CreateText(c_sOutputFilePath)	'>>> create the output file
		'>>> Now we'll use the file handles (fileInput and fileOutput) to work with the files


		'>>> we use a While loop to read thru the input file. Each iteration of the loop reads everything it needs for ONE student.
		While fileInput.Peek <> -1	'>>> Remember - this gobbledy-gook just means "As long as there is more to read"
			sName = fileInput.ReadLine	'>>> Read the student's name and assign it to sName
			DisplayLine("Name: " & sName)	'>>> For debugging purposes, display the info to the screen
			fileOutput.WriteLine("Name: " & sName)	'>>> Write the output to the file

			dTotal = 0 '>>> Remember why we have to set dTotal to zero before we go into the For loop?  If we don't, dTotal will keep accumulating from the previous students and give us bad results.

			'>>> We'll use a For loop to read the 5 scores
			For i As Integer = 1 To 5
				dScore = CDbl(fileInput.ReadLine) '>>> ReadLine always gives us text, but we have to do math on dScore, so we will convert it to a Double as we read it in.
				dTotal = dTotal + dScore
			Next

			dAverage = dTotal / 5 '>>> Calculate the student's average
			DisplayLine("Student Average: " & FormatNumber(dAverage) & "%") '>>> Display the student's average
			fileOutput.WriteLine("Student Average: " & FormatNumber(dAverage) & "%") '>>> Write the student's average to the output file.

			DisplayLine() '>>> Display a blank line
			fileOutput.WriteLine() '>>> Write a blank line
		End While

		'>>> Close both of the files
		fileInput.Close()
		fileOutput.Close()

		'>>> Run the program and take a look at the output file.

	End Sub

End Module