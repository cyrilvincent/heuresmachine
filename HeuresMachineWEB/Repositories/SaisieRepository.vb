Imports System.Data.SqlClient
Imports HeuresMachineWEB.Entities

Namespace Repositories
    Public Class SaisieRepository
        Inherits ARepository(Of Saisie)

        Public Const TABLE_NAME As String = "DBO.SaisieHeures"
        Public Const FIELD_AFFAIRE As String = TABLE_NAME & "." & "AFFAIRE"
        Public Const FIELD_NUMERO As String = TABLE_NAME & "." & "NUMEROSERIE"
        Public Const FIELD_INDICE As String = TABLE_NAME & "." & "INDICE"
        Public Const FIELD_DATE1 As String = TABLE_NAME & "." & "DATE1"
        Public Const FIELD_TEMPS As String = TABLE_NAME & "." & "TEMPS"
        Public Const FIELD_CWID As String = TABLE_NAME & "." & "CWID"
        Public Const FIELD_NOM As String = TABLE_NAME & "." & "NOM"
        Public Const FIELD_SERVICE As String = TABLE_NAME & "." & "SERVICE"
        ' Private ClientRepos As New ClientsRepository()
        ' Private UserRepos As New UtilisateursRepository()
        ' Private MachineRepos As New MachineRepository()

        Public Overrides Function Mapping(reader As SqlDataReader) As Saisie
            Dim affaire As New Saisie()
            affaire.Id = CType(reader.Item(TABLE_NAME & "." & FIELD_ID), Long)
            affaire.Affaire = CType(reader.Item(FIELD_AFFAIRE), Long)
            affaire.NumeroSerie = CType(reader.Item(FIELD_NUMERO), String)
            affaire.Indice = CType(reader.Item(FIELD_INDICE), String)
            affaire.Date1 = CType(reader.Item(FIELD_DATE1), String)
            affaire.Temps = CType(reader.Item(FIELD_TEMPS), Single)
            affaire.Cwid = CType(reader.Item(FIELD_CWID), String)
            affaire.Nom = CType(reader.Item(FIELD_NOM), String)
            affaire.Service = CType(reader.Item(FIELD_SERVICE), String)

            ' affaire.Client = ClientRepos.Mapping(reader)
            'affaire.TYpeMachine = MachineRepos.Mapping(reader)
            Return affaire
        End Function

        Protected Overrides Function TableName() As String
            Return TABLE_NAME
        End Function

        Public Overrides Function FieldList() As List(Of String)
            Dim fields As List(Of String) = MyBase.FieldList()
            fields.Add(FIELD_AFFAIRE)
            fields.Add(FIELD_NUMERO)
            fields.Add(FIELD_INDICE)
            fields.Add(FIELD_DATE1)
            fields.Add(FIELD_TEMPS)
            fields.Add(FIELD_CWID)
            fields.Add(FIELD_NOM)
            fields.Add(FIELD_SERVICE)
            Return fields
        End Function

        Protected Overrides Function FieldList(report As Saisie) As Dictionary(Of String, Object)
            Dim fields As Dictionary(Of String, Object) = MyBase.FieldList(report)
            fields.Add(FIELD_AFFAIRE, report.Affaire)
            fields.Add(FIELD_NUMERO, report.NumeroSerie)
            fields.Add(FIELD_INDICE, report.Indice)
            fields.Add(FIELD_DATE1, report.Date1)
            fields.Add(FIELD_TEMPS, report.Temps)
            fields.Add(FIELD_CWID, report.Cwid)
            fields.Add(FIELD_NOM, report.Nom)
            fields.Add(FIELD_SERVICE, report.Service)
            Return fields
        End Function

        Public Sub FillAssociatedFlows(affaire As Temps)
            Dim sql As String = "SELECT " & FormatFieldList(FieldList(), True) &
                " FROM " & TABLE_NAME &
                " WHERE " & FIELD_AFFAIRE & " = " & affaire.Id
            Dim query As New MonoTableReadQuery(Of Saisie)(Me, sql)
            Database.GetInstance().ExecuteQuery(query)

            ' For Each flow As Saisie In query.Data
            'affaire.Add(flow)
            ' Next
        End Sub

        Public Overloads Sub Delete(affaire As Temps)
            Database.GetInstance().ExecuteNonQuery("DELETE FROM " & TableName() & " WHERE " & FIELD_AFFAIRE & " = " & affaire.Id)
        End Sub
    End Class


End Namespace