Imports System.Data.SqlClient
Imports HeuresMachineWEB.Entities

Namespace Repositories
    Public Class MachineRepository
        Inherits ARepository(Of TypeMachine)

        Public Const TABLE_NAME As String = "DBO.TypeMachine"
        Public Const FIELD_MODEL As String = TABLE_NAME & "." & "MODELE"

        Public Overrides Function Mapping(reader As SqlDataReader) As TypeMachine
            Dim machine As New TypeMachine()
            machine.Id = CType(reader(TABLE_NAME & "." & FIELD_ID), Long)
            machine.Modele = CType(reader(FIELD_MODEL), String)
            Return machine
        End Function

        Protected Overrides Function TableName() As String
            Return TABLE_NAME
        End Function

        Public Overrides Function FieldList() As List(Of String)
            Dim fields As List(Of String) = MyBase.FieldList()
            fields.Add(FIELD_MODEL)
            Return fields
        End Function

        Protected Overrides Function FieldList(entity As TypeMachine) As System.Collections.Generic.Dictionary(Of String, Object)
            Dim fields As Dictionary(Of String, Object) = MyBase.FieldList(entity)
            fields.Add(FIELD_MODEL, entity.Modele)
            Return fields
        End Function
    End Class
End Namespace