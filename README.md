# AQA 2017 P1 Skeleton Code - VB.NET

[![Build status](https://ci.appveyor.com/api/projects/status/51i1ik4sux8rwg7d?svg=true)](https://ci.appveyor.com/project/viljowilding/vb-skeleton-aqa-2017)

This repository holds a modified version of the **AQA 2017 Skeleton Code** in VB.NET, improved as per the task. When I figure out how GitHub releases work, I'll probably create releases when new features are added!

## Stuff to note

### PlantFirstSeed

PlantFirstSeed is a function I wrote, unlike some others which were modified from [WikiBooks](https://en.wikibooks.org/w/index.php?title=A-level_Computing/AQA/Paper_1/Skeleton_program/AS2017), to allow random planting of the first seed in the simulator. If the user gives an invalid input, it defaults to planting in the centre of the field.

```VB.NET
Function PlantFirstSeed(ByVal Field As Char(,), ByVal SeedPosition As Integer)
    Dim Row, Column As Integer
    Select SeedPosition
        Case 0:
            Console.WriteLine("Planting seed in the centre of the field!")
        Case 1:
            Console.WriteLine("Planting the seed in a random location")
            Row = Int(Rnd() * FIELDLENGTH)
            Column = Int(Rnd() * FIELDWIDTH)
            Field(Row, Column) = SEED
            Return Field
        Case Else:
            Console.WriteLine("Invalid input, defaulting to centre position")
    End Select
    Row = FIELDLENGTH \ 2
    Column = FIELDWIDTH \ 2
    Field(Row, Column) = SEED
    Return Field
End Function
```

### Console Colours

I felt like adding another unique feature, so I used `Console.ForegroundColor` to give each symbol a different colour; this should increase readability and make it look **fanceh**.

```VB.NET
Sub Display(ByVal Field(,) As Char, ByVal Season As String, ByVal Year As Integer)
    Dim Row As Integer
    Dim Column As Integer
    Console.WriteLine("Season: " & Season & "  Year number: " & Year)
    For Row = 0 To FIELDLENGTH - 1
        For Column = 0 To FIELDWIDTH - 1
            If Field(Row, Column) = SOIL Then
                Console.ForegroundColor = 6
            Else If Field(Row, Column) = SEED Then
                Console.ForegroundColor = 11
            Else If Field(Row, Column) = PLANT Then
                Console.ForegroundColor = 10
            Else If Field(Row, Column) = ROCKS Then
                Console.ForegroundColor = 12
            Else
                Console.ForegroundColor = 7
            End If
            Console.Write(Field(Row, Column))
        Next
        Console.ResetColor
        Console.WriteLine("|" & Str(Row).PadLeft(3))
    Next
    Console.WriteLine()
End Sub
```

### SaveToFile

Damn, I spoil you! The new `Sub SaveToFile` allows the user to save their field at the end of the simulation to a file. This has validation to ensure that users aren't users, and will be run at the end of the simulation.

```VB.NET
Sub SaveToFile(ByVal Field As Char(,))
    Dim Row, Column As Integer
    Dim ToSave As Boolean = False
    Dim Save, FileName, RowEnding As String
    Dim FileHandler As IO.StreamWriter
    Do
        Console.Write("Do you want to save the file? Y/N: ")
        Save = UCase(Console.ReadLine())
        If Save = "Y" Then
            ToSave = True
            Console.Write("Please enter the file name: ")
            FileName = Console.ReadLine()
            If Right(FileName, 4) = ".txt" Then
                FileName = FileName
            Else
                FileName = String.Concat(FileName, ".txt")
            End If
            Try
                FileHandler = New IO.StreamWriter(FileName)
                For Row = 0 To FIELDLENGTH - 1
                    For Column = 0 To FIELDWIDTH - 1
                        FileHandler.Write(Field(Row, Column))
                    Next
                    RowEnding = String.Format("| {0}", Row)
                    FileHandler.Write(RowEnding)
                    FileHandler.WriteLine()
                Next
                FileHandler.Close()
            Catch ex As Exception
                Console.WriteLine("An error occured whilst writing the file; the program will now exit.")
                Console.WriteLine(ex)
            End Try
        Else If Save = "N" Then
            ToSave = True
        Else
            Console.WriteLine("Invalid input, please try again.")
        End If
    Loop Until ToSave = True
    Console.WriteLine("The program will now exit.")
End Sub
```
