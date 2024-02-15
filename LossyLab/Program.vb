Imports System

Module Program

    Dim X_O_Game(,) = New String(2, 2) {{" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "}}
    Dim RowCounter As Integer
    Dim ColumnCounter As Integer

    Sub Display3x3()
        For RowCounter = 0 To 2
            For ColumnCounter = 0 To 2
                Console.Write(X_O_Game(RowCounter, ColumnCounter))
                If ColumnCounter < 2 Then
                    Console.Write("|")
                End If
            Next
            Console.WriteLine()
            If RowCounter < 2 Then
                Console.Write("_____")
                Console.WriteLine()
            End If
        Next
    End Sub
    'To display the 3x3 grid

    Sub UserInput()
        If Player1Turn Then
            Console.WriteLine("Player 1 Turn (X)")
            Console.Write("Enter Row Number (1-3): ")
            RowCounter = Console.ReadLine() - 1
            Console.Write("Enter Column Number (1-3): ")
            ColumnCounter = Console.ReadLine() - 1
            If X_O_Game(RowCounter, ColumnCounter) = " " Then
                X_O_Game(RowCounter, ColumnCounter) = "X"
                Player1Turn = False
            Else
                Console.WriteLine("Invalid Move")
                UserInput()
            End If
        Else
            Console.WriteLine("Player 2 Turn (O)")
            Console.Write("Enter Row Number (1-3): ")
            RowCounter = Console.ReadLine() - 1
            Console.Write("Enter Column Number (1-3): ")
            ColumnCounter = Console.ReadLine() - 1
            If X_O_Game(RowCounter, ColumnCounter) = " " Then
                X_O_Game(RowCounter, ColumnCounter) = "O"
                Player1Turn = True
            Else
                Console.WriteLine("Invalid Move")
                UserInput()
            End If
        End If
    End Sub
    'To take user input and update the 3x3 grid

    Dim MatchDone As Boolean = False
    Dim MatchWon As Boolean = False
    Dim Player1Turn As Boolean = True
    Sub Main()
        Console.WriteLine("Tick Tack Toe Game")
        Console.WriteLine("Player 1 is X and Player 2 is O")
        Dim Player1Turn As Boolean = True
        While Not MatchDone
            Call Display3x3()
            Call UserInput()
            For RowCounter = 0 To 2
                For ColumnCounter = 0 To 2
                    If X_O_Game(RowCounter, ColumnCounter) = " " Then
                        MatchDone = False
                    End If
                Next
            Next
            'To check if the match is draw if Completed
            For CheckerCounter = 0 To 2
                If X_O_Game(CheckerCounter, 0) = X_O_Game(CheckerCounter, 1) And X_O_Game(CheckerCounter, 1) = X_O_Game(CheckerCounter, 2) And X_O_Game(CheckerCounter, 0) <> " " Then
                    Call ResultHelper()
                ElseIf X_O_Game(0, CheckerCounter) = X_O_Game(1, CheckerCounter) And X_O_Game(1, CheckerCounter) = X_O_Game(2, CheckerCounter) And X_O_Game(0, CheckerCounter) <> " " Then
                    Call ResultHelper()
                ElseIf X_O_Game(0, 0) = X_O_Game(1, 1) And X_O_Game(1, 1) = X_O_Game(2, 2) And X_O_Game(0, 0) <> " " Then
                    Call ResultHelper()
                ElseIf X_O_Game(0, 2) = X_O_Game(1, 1) And X_O_Game(1, 1) = X_O_Game(2, 0) And X_O_Game(0, 2) <> " " Then
                    Call ResultHelper()
                End If
            Next
        End While
        'To check if the match is won
        If Not MatchWon Then
            Console.WriteLine("Match Draw")
        End If
        Call Display3x3()
        Console.ReadKey()
    End Sub

    Sub ResultHelper()
        MatchWon = True
        MatchDone = True
        If Not Player1Turn Then
            Console.WriteLine("Player 1 Wins")
        Else
            Console.WriteLine("Player 2 Wins")
        End If
    End Sub
    'To display the result of the match

End Module
