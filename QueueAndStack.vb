Module QueueAndStack
	Dim STORAGE As New Microsoft.VisualBasic.Collection()
	Dim ISSTACK As Boolean
	Dim EX As Boolean
	Dim TYPE As String
	Sub Main()
		Init()
		Do
			Menu()
		Loop Until EX = True
		Console.WriteLine("Press any key to exit.")
		Console.ReadKey()
	End Sub
	Sub Init()
		Dim sel As Integer
		Console.WriteLine("Initialising data STORAGE...")
		Console.WriteLine("Stack (0) or Queue (1)?")
		Console.WriteLine()
		Console.Write("Select: ")
		Try
			sel = Console.ReadLine()
		Catch e As InvalidCastException
			Console.WriteLine("Error, invalid input. Defaulting to Stack (0)")
			sel = 0
		End Try
		If sel = 0 Then
			ISSTACK = True
			TYPE = "Stack"
		Else
			TYPE = "Queue"
		End If
		Console.WriteLine("Initialised your new {0}. Press any key to continue...", TYPE)
		Console.ReadKey()
	End Sub
	Sub Menu()
		Dim sel As Integer
		Dim data As String
		Console.Clear()
		Console.WriteLine("Please select an option:")
		Console.WriteLine(" 1. Push")
		Console.WriteLine(" 2. Pop")
		Console.WriteLine(" 3. Display")
		Console.WriteLine(" 4. Exit")
		Console.WriteLine()
		Console.Write("Select: ")
		Try
			sel = Console.ReadLine()
		Catch e As InvalidCastException
			Console.WriteLine("Error, invalid input. Let's try that again!")
			Console.WriteLine("Press any key to continue...")
			Console.ReadKey()
		End Try
		Select sel
			Case 1
				Console.Write("Please input data to push to the {0}: ", TYPE)
				data = Console.ReadLine()
				Push(data)
			Case 2
				Pop()
			Case 3
				Display()
			Case 4
				EX = True
		End Select
	End Sub
	Sub Push(ByVal ToPush)
		Dim Len As Integer = GetLength()
		If ISSTACK Then
			If Len <> 0
				STORAGE.Add(ToPush, , 1)
			Else
				STORAGE.Add(ToPush)
			End If
		Else
			STORAGE.Add(ToPush)
		End If
		Console.WriteLine("Press any key to continue...")
		Console.ReadKey()
	End Sub
	Sub Pop()
		STORAGE.Remove(1)
		Console.WriteLine("Successfully popped!")
		Console.WriteLine("Press any key to continue...")
		Console.ReadKey()
	End Sub
	Sub Display()
		Dim count As Integer = 1
		Console.WriteLine("Contents of the {0}:", TYPE)
		For Each x in STORAGE
			Console.WriteLine("{0} | {1}", count, x)
			count += 1
		Next
		Console.WriteLine("Press any key to continue...")
		Console.ReadKey()
	End Sub
	Function GetLength() As Integer
		Dim count As Integer
		Try
			For Each x in STORAGE
				count += 1
			Next
		Catch e As NullReferenceException
			count = 0
		End Try
		Return count
	End Function
End Module