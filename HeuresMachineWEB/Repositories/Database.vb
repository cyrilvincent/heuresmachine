Imports System.Data.SqlClient

Namespace Repositories

    Public Class Database

        'Private Const dbServer As String = "CFRS000100\SQLSERVER"
        'Private Const dbServer As String = "DFFMZD1587\CFRDB01"
        Private Const dbServer As String = "."
        'Private Const catalog As String = "HeuresMachine"
        Private Const catalog As String = "covestro"


        ' Private Const connString As String = "Data Source=" & dbServer & ";Initial Catalog=" & catalog & ";Persist Security Info=True;User ID=" & user & ";Password=" & password
        Private Const connString As String = "Data Source=" & dbServer & ";Initial Catalog=" & catalog & ";Integrated Security=True"

        ' Membres de classe
        Private Shared instance As Database = Nothing

        ' Constructeur privé pour pattern Singleton
        Private Sub New()
            ' Ajouter ici du code pour un paramétrage externe (fichier de paramétrage, etc ...)
        End Sub

        ' Méthode getInstance pour pattern Singleton
        Public Shared Function GetInstance() As Database
            If IsNothing(instance) Then
                instance = New Database()
            End If

            Return instance
        End Function

        ' Fonction getRowCount
        ' Rôle : renvoyer le nombre d'enregistrements d'une table de la base de de données
        Public Function getRowCount(tableName As String) As Integer
            Dim rowCount As Integer = -1

            Using db As SqlConnection = New SqlConnection(connString)
                db.Open()
                Dim request As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM " & tableName, db)
                Dim result As SqlDataReader = request.ExecuteReader()
                If result.HasRows Then
                    result.Read()
                    rowCount = result.Item(0)
                End If
            End Using

            Return rowCount
        End Function

        ' Procédure ExecuteQuery
        ' Rôle : exécuter une requête SQL et traiter les résultats
        Public Sub ExecuteQuery(query As IQuery)
            Using db As SqlConnection = New SqlConnection(connString)
                db.Open()
                Dim request As SqlCommand = New SqlCommand(query.GetRequest(), db)
                query.ProcessResults(request.ExecuteReader())
            End Using
        End Sub

        ' Procédure ExecuteNonQuery
        ' Rôle : exécuter une requête SQL qui ne retourne aucun résultat
        Public Sub ExecuteNonQuery(sql As String)
            Using db As SqlConnection = New SqlConnection(connString)
                db.Open()
                Dim request As SqlCommand = New SqlCommand(sql, db)
                request.ExecuteNonQuery()
            End Using
        End Sub

        Friend Function InsertAndGetId(sql As String) As Long
            Using db As SqlConnection = New SqlConnection(connString)
                db.Open()
                Dim request As SqlCommand = New SqlCommand(sql, db)
                Return request.ExecuteScalar()
            End Using
        End Function
    End Class

End Namespace