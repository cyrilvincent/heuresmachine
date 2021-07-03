Imports System.Data.SqlClient
Imports HeuresMachineWEB.Entities

Namespace Repositories
    Public Class TempsRepository
        Inherits ARepository(Of Temps)

        Public Const TABLE_NAME As String = "DBO.Temps"
        Public Const FIELD_NUMERO As String = TABLE_NAME & "." & "NUMEROSERIE"
        Public Const FIELD_INDICE As String = TABLE_NAME & "." & "INDICE"
        Public Const FIELD_DESCRIPTIF As String = TABLE_NAME & "." & "DESCRIPTIF"
        Public Const FIELD_CLIENT As String = TABLE_NAME & "." & "CLIENT"
        Public Const FIELD_TYPEMACHINE As String = TABLE_NAME & "." & "TYPEMACHINE"
        Public Const FIELD_DATE1 As String = TABLE_NAME & "." & "DATE1"
        Public Const FIELD_TEMPS1 As String = TABLE_NAME & "." & "TEMPS1"
        Public Const FIELD_CWID As String = TABLE_NAME & "." & "CWID"
        Public Const FIELD_NOM As String = TABLE_NAME & "." & "NOM"
        Public Const FIELD_SERVICE As String = TABLE_NAME & "." & "SERVICE"
        'Public Const FIELD_TEMPSBEM As String = TABLE_NAME & "." & "TEMPSBEM"
        'Public Const FIELD_TEMPSBEE As String = TABLE_NAME & "." & "TEMPSBEE"
        'Public Const FIELD_TEMPSBEA As String = TABLE_NAME & "." & "TEMPSBEA"
        'Public Const FIELD_TEMPSRESTANTBEM As String = TABLE_NAME & "." & "TEMPSRESTANTBEM"
        'Public Const FIELD_TEMPSRESTANTBEE As String = TABLE_NAME & "." & "TEMPSRESTANTBEE"
        'Public Const FIELD_TEMPSRESTANTBEA As String = TABLE_NAME & "." & "TEMPSRESTANTBEA"
        Private ClientRepos As New ClientsRepository()
        Private UserRepos As New UtilisateursRepository()
        Private MachineRepos As New MachineRepository()

        Public Overrides Function Mapping(reader As SqlDataReader) As Temps
            Dim affaire As New Temps()
            affaire.Id = CType(reader.Item(TABLE_NAME & "." & FIELD_ID), Long)
            affaire.NumeroSerie = CType(reader.Item(FIELD_NUMERO), String)
            affaire.Indice = CType(reader.Item(FIELD_INDICE), String)
            affaire.Descriptif = CType(reader.Item(FIELD_DESCRIPTIF), String)
            affaire.Date1 = CType(reader.Item(FIELD_DATE1), DateTime)
            affaire.Temps1 = CType(reader.Item(FIELD_TEMPS1), Single)
            affaire.Cwid = CType(reader.Item(FIELD_CWID), String)
            affaire.Nom = CType(reader.Item(FIELD_NOM), String)
            affaire.Service = CType(reader.Item(FIELD_SERVICE), String)
            'affaire.TempsBEM = CType(reader.Item(FIELD_TEMPSBEM), Single)
            'affaire.TempsBEE = CType(reader.Item(FIELD_TEMPSBEE), Single)
            'affaire.TempsBEA = CType(reader.Item(FIELD_TEMPSBEA), Single)
            'affaire.TempsRestantBEM = CType(reader.Item(FIELD_TEMPSRESTANTBEM), Single)
            'affaire.TempsRestantBEE = CType(reader.Item(FIELD_TEMPSRESTANTBEE), Single)
            'affaire.TempsRestantBEA = CType(reader.Item(FIELD_TEMPSRESTANTBEA), Single)
            affaire.Client = ClientRepos.Mapping(reader)
            affaire.TYpeMachine = MachineRepos.Mapping(reader)
            Return affaire
        End Function

        Protected Overrides Function TableName() As String
            Return TABLE_NAME
        End Function

        Public Overrides Function FieldList() As List(Of String)
            Dim fields As List(Of String) = MyBase.FieldList()
            fields.Add(FIELD_NUMERO)
            fields.Add(FIELD_INDICE)
            fields.Add(FIELD_DESCRIPTIF)
            fields.Add(FIELD_CLIENT)
            fields.Add(FIELD_TYPEMACHINE)
            fields.Add(FIELD_DATE1)
            fields.Add(FIELD_TEMPS1)
            fields.Add(FIELD_CWID)
            fields.Add(FIELD_NOM)
            fields.Add(FIELD_SERVICE)
            'fields.Add(FIELD_TEMPSBEM)
            'fields.Add(FIELD_TEMPSBEE)
            'fields.Add(FIELD_TEMPSBEA)
            'fields.Add(FIELD_TEMPSRESTANTBEM)
            'fields.Add(FIELD_TEMPSRESTANTBEE)
            'fields.Add(FIELD_TEMPSRESTANTBEA)
            Return fields
        End Function

        Protected Overrides Function FieldList(report As Temps) As Dictionary(Of String, Object)
            Dim fields As Dictionary(Of String, Object) = MyBase.FieldList(report)
            fields.Add(FIELD_NUMERO, report.NumeroSerie)
            fields.Add(FIELD_INDICE, report.Indice)
            fields.Add(FIELD_DESCRIPTIF, report.Descriptif)
            fields.Add(FIELD_CLIENT, report.Client.Id)
            fields.Add(FIELD_TYPEMACHINE, report.TYpeMachine.Id)
            fields.Add(FIELD_DATE1, report.Date1)
            fields.Add(FIELD_TEMPS1, report.Temps1)
            fields.Add(FIELD_CWID, report.Cwid)
            fields.Add(FIELD_NOM, report.Nom)
            fields.Add(FIELD_SERVICE, report.Service)
            'fields.Add(FIELD_TEMPSBEM, report.TempsBEM)
            'fields.Add(FIELD_TEMPSBEE, report.TempsBEE)
            'fields.Add(FIELD_TEMPSBEA, report.TempsBEA)
            'fields.Add(FIELD_TEMPSRESTANTBEM, report.TempsRestantBEM)
            'fields.Add(FIELD_TEMPSRESTANTBEE, report.TempsRestantBEE)
            'fields.Add(FIELD_TEMPSRESTANTBEA, report.TempsRestantBEA)
            Return fields
        End Function


        Public Overrides Function Add(report As Temps, Optional returnId As Boolean = False) As Long
            report.Id = MyBase.Add(report, True)

            Return If(returnId, report.Id, 0)
        End Function

        Public Overrides Function GetAll() As List(Of Temps)
            Dim request As String = "SELECT " & FormatFieldList(FieldList(), True) & "," &
                FormatFieldList(ClientRepos.FieldList(), True) & "," &
                FormatFieldList(MachineRepos.FieldList(), True) &
                " FROM " & TABLE_NAME &
                " JOIN " & ClientsRepository.TABLE_NAME & " ON " & FIELD_CLIENT & " = " & ClientsRepository.TABLE_NAME & "." & FIELD_ID &
                " JOIN " & MachineRepository.TABLE_NAME & " ON " & FIELD_TYPEMACHINE & " = " & MachineRepository.TABLE_NAME & "." & FIELD_ID &
            " JOIN " & UtilisateursRepository.TABLE_NAME & " ON " & FIELD_TYPEMACHINE & " = " & UtilisateursRepository.TABLE_NAME & "." & FIELD_ID &
             " Where " & FIELD_TEMPS1 & " <> " & " 0 " &
            " ORDER BY " & FIELD_DATE1 & " DESC "
            Dim query As New MonoTableReadQuery(Of Temps)(Me, request)
            Database.GetInstance().ExecuteQuery(query)
            Return query.Data
        End Function

        Public Overrides Function GetAll1() As List(Of Temps)
            Dim request As String = "SELECT " & FormatFieldList(FieldList(), True) & "," &
                FormatFieldList(ClientRepos.FieldList(), True) & "," &
                FormatFieldList(MachineRepos.FieldList(), True) &
                " FROM " & TABLE_NAME &
                " JOIN " & ClientsRepository.TABLE_NAME & " ON " & FIELD_CLIENT & " = " & ClientsRepository.TABLE_NAME & "." & FIELD_ID &
                " JOIN " & MachineRepository.TABLE_NAME & " ON " & FIELD_TYPEMACHINE & " = " & MachineRepository.TABLE_NAME & "." & FIELD_ID &
            " JOIN " & UtilisateursRepository.TABLE_NAME & " ON " & FIELD_TYPEMACHINE & " = " & UtilisateursRepository.TABLE_NAME & "." & FIELD_ID &
            " Where " & FIELD_TEMPS1 & " = " & " 0 " &
             " ORDER BY " & FIELD_DATE1 & " DESC "
            Dim query As New MonoTableReadQuery(Of Temps)(Me, request)
            Database.GetInstance().ExecuteQuery(query)
            Return query.Data
        End Function

        Public Overrides Function GetById(Id As Long) As Temps
            Dim request As String = "SELECT " & FormatFieldList(FieldList(), True) & "," &
                FormatFieldList(ClientRepos.FieldList(), True) & "," &
                FormatFieldList(MachineRepos.FieldList(), True) &
                " FROM " & TABLE_NAME &
                " JOIN " & ClientsRepository.TABLE_NAME & " ON " & FIELD_CLIENT & " = " & ClientsRepository.TABLE_NAME & "." & FIELD_ID &
                " JOIN " & MachineRepository.TABLE_NAME & " ON " & FIELD_TYPEMACHINE & " = " & MachineRepository.TABLE_NAME & "." & FIELD_ID &
                " JOIN " & UtilisateursRepository.TABLE_NAME & " ON " & FIELD_TYPEMACHINE & " = " & UtilisateursRepository.TABLE_NAME & "." & FIELD_ID &
                " WHERE " & TABLE_NAME & "." & FIELD_ID & " = " & Id
            Dim query As New MonoTableReadQuery(Of Temps)(Me, request)
            Database.GetInstance().ExecuteQuery(query)

            Dim report As Temps = query.Data.Item(0)
            'UserRepos.FillContributors(affaire)
            Return report
        End Function

        Public Overrides Sub Update(report As Temps)
            MyBase.Update(report)
            ' UserRepos.AssociateUsers(affaire)

        End Sub
    End Class

End Namespace