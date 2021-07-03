Imports System.Data.SqlClient

Namespace Repositories

    Public Interface IQuery
        Function GetRequest() As String
        Sub ProcessResults(result As SqlDataReader)
    End Interface

End Namespace
