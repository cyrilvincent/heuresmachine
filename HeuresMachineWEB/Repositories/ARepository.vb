Imports System.Data.SqlClient
Imports HeuresMAchineWEB.Entities

Namespace Repositories

    Public MustInherit Class ARepository(Of T As IEntity)
        Implements IRepository(Of T)

        Protected MustInherit Class AQuery(Of E As T)
            Implements IQuery

            Protected Request As String
            Protected Repository As ARepository(Of E)

            Public Sub New(repository As ARepository(Of E), request As String)
                Me.Request = request
                Me.Repository = repository
            End Sub

            Public Function GetRequest() As String Implements IQuery.GetRequest
                Return Request
            End Function

            Public MustOverride Sub ProcessResults(result As SqlDataReader) Implements IQuery.ProcessResults

        End Class

        Protected Class MonoTableReadQuery(Of E As T)
            Inherits AQuery(Of E)

            Public Data As List(Of E)

            Public Sub New(repository As ARepository(Of E), request As String)
                MyBase.New(repository, request)
                Data = New List(Of E)()
            End Sub

            Public Overrides Sub ProcessResults(result As SqlDataReader)
                While (result.Read())
                    Dim entity As E = Repository.Mapping(result)
                    Data.Add(entity)
                End While
            End Sub
        End Class

        Public Const FIELD_ID As String = "ID"

        Public MustOverride Function Mapping(reader As SqlDataReader) As T
        Protected MustOverride Function TableName() As String

        Protected Overridable Function FieldList(entity As T) As Dictionary(Of String, Object)
            Dim fields As New Dictionary(Of String, Object)
            fields.Add(TableName() & "." & FIELD_ID, entity.Id)
            Return fields
        End Function

        Protected Function FormatFieldList(fields As ICollection(Of String), addAliases As Boolean) As String
            Dim formattedList As String = ""
            Dim first As Boolean = True
            For Each field As String In fields
                If Not first Then formattedList += "," Else first = False
                formattedList += field
                If addAliases Then formattedList += " AS '" & field & "'"
            Next
            Return formattedList
        End Function

        Protected Function FormatFieldValue(value As Object) As String
            Dim formattedValue As String
            If TypeOf value Is String Then
                formattedValue = "'" & value & "'"
            ElseIf TypeOf value Is DateTime Then
                formattedValue = "CONVERT(DATETIME,'" & CType(value, DateTime).ToString("yyyy-MM-dd HH:mm:ss") & "',20)"
            ElseIf value.GetType.IsEnum Then
                formattedValue = CStr(value)
            ElseIf TypeOf value Is Boolean Then
                formattedValue = If(value, "1", "0")
            ElseIf TypeOf value Is Single Then
                formattedValue = value.ToString().Replace(",", ".")
            Else
                formattedValue = value.ToString
            End If
            Return formattedValue
        End Function

        Public Overridable Function FieldList() As List(Of String)
            Dim fields As New List(Of String)
            fields.Add(TableName() & "." & FIELD_ID)
            Return fields
        End Function

        ' ---------------------------------------------------------------------------------------------------------------
        ' Implémentation de IRepository
        ' ---------------------------------------------------------------------------------------------------------------

        Public Overridable Function Add(entity As T, Optional returnId As Boolean = False) As Long Implements IRepository(Of T).Add
            Dim fields As Dictionary(Of String, Object) = FieldList(entity)
            fields.Remove(TableName() & "." & FIELD_ID)

            Dim sql As String = "INSERT INTO " & TableName() & "("
            sql += FormatFieldList(fields.Keys, False)
            sql += ") VALUES ("

            Dim first As Boolean = True
            For Each value As Object In fields.Values
                If Not first Then sql += "," Else first = False
                sql += FormatFieldValue(value)
            Next

            sql += ");"

            If returnId Then
                sql += " SELECT SCOPE_IDENTITY()"
                Return Database.GetInstance().InsertAndGetId(sql)
            Else
                Database.GetInstance().ExecuteNonQuery(sql)
                Return 0
            End If

        End Function

        Public Sub Delete(Id As Long) Implements IRepository(Of T).Delete
            Database.GetInstance().ExecuteNonQuery("DELETE FROM " & TableName() & " WHERE " & FIELD_ID & " = " & Id)
        End Sub

        Public Overridable Function GetAll() As List(Of T) Implements IRepository(Of T).GetAll
            Dim sql As String = "SELECT " & FormatFieldList(FieldList(), True) & " FROM " & TableName()
            Dim query As New MonoTableReadQuery(Of T)(Me, sql)
            Database.GetInstance().ExecuteQuery(query)
            Return query.Data
        End Function

        Public Overridable Function GetAll1() As List(Of T) Implements IRepository(Of T).GetAll1
            Dim sql As String = "SELECT " & FormatFieldList(FieldList(), True) & " FROM " & TableName()
            Dim query As New MonoTableReadQuery(Of T)(Me, sql)
            Database.GetInstance().ExecuteQuery(query)
            Return query.Data
        End Function


        Public Overridable Function GetById(Id As Long) As T Implements IRepository(Of T).GetById
            Dim sql As String = "SELECT " & FormatFieldList(FieldList(), True) & " FROM " & TableName() & " WHERE " & FIELD_ID & " = " & Id
            Dim query As New MonoTableReadQuery(Of T)(Me, sql)
            Database.GetInstance().ExecuteQuery(query)
            Return query.Data.Item(0)
        End Function

        Public Function GetCount() As Long Implements IRepository(Of T).GetCount
            Return Database.GetInstance().getRowCount(TableName())
        End Function

        Public Overridable Sub Update(entity As T) Implements IRepository(Of T).Update
            Dim fields As Dictionary(Of String, Object) = FieldList(entity)
            fields.Remove(TableName() & "." & FIELD_ID)

            Dim sql As String = "UPDATE " & TableName() & " SET "
            Dim first As Boolean = True
            For Each field As KeyValuePair(Of String, Object) In fields
                If Not first Then sql += "," Else first = False
                sql += field.Key & " = " & FormatFieldValue(field.Value)
            Next
            sql += " WHERE " & FIELD_ID & " = " & entity.Id

            Database.GetInstance().ExecuteNonQuery(sql)
        End Sub

    End Class

End Namespace