Imports System.Data.SqlClient
Imports HeuresMAchineWEB.Entities

Namespace Repositories
    Public Class PrevionnelRepository
        Inherits ARepository(Of Previsionnel)
        Public Const TABLE_NAME As String = "DBO.Previsionnel"
        Public Const FIELD_NUMERO As String = TABLE_NAME & "." & "NUMEROSERIE"
        Public Const FIELD_INDICE As String = TABLE_NAME & "." & "INDICE"
        Public Const FIELD_DESCRIPTIF As String = TABLE_NAME & "." & "DESCRIPTIF"
        Public Const FIELD_CLIENT As String = TABLE_NAME & "." & "CLIENT"
        Public Const FIELD_TYPEMACHINE As String = TABLE_NAME & "." & "TYPEMACHINE"
        Public Const FIELD_TEMPSBEM As String = TABLE_NAME & "." & "TEMPSBEM"
        Public Const FIELD_TEMPSBEE As String = TABLE_NAME & "." & "TEMPSBEE"
        Public Const FIELD_TEMPSBEA As String = TABLE_NAME & "." & "TEMPSBEA"
        Public Const FIELD_TEMPSTOTALBEM As String = TABLE_NAME & "." & "TEMPSTOTALBEM"
        Public Const FIELD_TEMPSTOTALBEE As String = TABLE_NAME & "." & "TEMPSTOTALBEE"
        Public Const FIELD_TEMPSTOTALBEA As String = TABLE_NAME & "." & "TEMPSTOTALBEA"
        Public Const FIELD_TEMPSRESTANTBEM As String = TABLE_NAME & "." & "TEMPSRESTANTBEM"
        Public Const FIELD_TEMPSRESTANTBEE As String = TABLE_NAME & "." & "TEMPSRESTANTBEE"
        Public Const FIELD_TEMPSRESTANTBEA As String = TABLE_NAME & "." & "TEMPSRESTANTBEA"
        Private ClientRepos As New ClientsRepository()
        Private UserRepos As New UtilisateursRepository()
        Private MachineRepos As New MachineRepository()


        Public Overrides Function Mapping(reader As SqlDataReader) As Previsionnel
            Dim affaire As New Previsionnel()
            affaire.Id = CType(reader.Item(TABLE_NAME & "." & FIELD_ID), Long)
            affaire.NumeroSerie = CType(reader.Item(FIELD_NUMERO), String)
            affaire.Indice = CType(reader.Item(FIELD_INDICE), String)
            affaire.Descriptif = CType(reader.Item(FIELD_DESCRIPTIF), String)
            affaire.TempsBEM = CType(reader.Item(FIELD_TEMPSBEM), Single)
            affaire.TempsBEE = CType(reader.Item(FIELD_TEMPSBEE), Single)
            affaire.TempsBEA = CType(reader.Item(FIELD_TEMPSBEA), Single)
            affaire.TempsTotalBEM = CType(reader.Item(FIELD_TEMPSTOTALBEM), Single)
            affaire.TempsTotalBEE = CType(reader.Item(FIELD_TEMPSTOTALBEE), Single)
            affaire.TempsTotalBEA = CType(reader.Item(FIELD_TEMPSTOTALBEA), Single)
            affaire.TempsRestantBEM = CType(reader.Item(FIELD_TEMPSRESTANTBEM), Single)
            affaire.TempsRestantBEE = CType(reader.Item(FIELD_TEMPSRESTANTBEE), Single)
            affaire.TempsRestantBEA = CType(reader.Item(FIELD_TEMPSRESTANTBEA), Single)
            affaire.Client = ClientRepos.Mapping(reader)
            affaire.TYpeMachine = MachineRepos.Mapping(reader)

            Return Affaire
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
            fields.Add(FIELD_TEMPSBEM)
            fields.Add(FIELD_TEMPSBEE)
            fields.Add(FIELD_TEMPSBEA)
            fields.Add(FIELD_TEMPSTOTALBEM)
            fields.Add(FIELD_TEMPSTOTALBEE)
            fields.Add(FIELD_TEMPSTOTALBEA)
            fields.Add(FIELD_TEMPSRESTANTBEM)
            fields.Add(FIELD_TEMPSRESTANTBEE)
            fields.Add(FIELD_TEMPSRESTANTBEA)
            Return fields
        End Function

        Protected Overrides Function FieldList(affaire As Previsionnel) As Dictionary(Of String, Object)
            Dim fields As Dictionary(Of String, Object) = MyBase.FieldList(affaire)
            fields.Add(FIELD_NUMERO, affaire.NumeroSerie)
            fields.Add(FIELD_INDICE, affaire.Indice)
            fields.Add(FIELD_DESCRIPTIF, affaire.Descriptif)
            fields.Add(FIELD_CLIENT, affaire.Client.Id)
            fields.Add(FIELD_TYPEMACHINE, affaire.TYpeMachine.Id)
            fields.Add(FIELD_TEMPSBEM, affaire.TempsBEM)
            fields.Add(FIELD_TEMPSBEE, affaire.TempsBEE)
            fields.Add(FIELD_TEMPSBEA, affaire.TempsBEA)
            fields.Add(FIELD_TEMPSTOTALBEM, affaire.TempsTotalBEM)
            fields.Add(FIELD_TEMPSTOTALBEE, affaire.TempsTotalBEE)
            fields.Add(FIELD_TEMPSTOTALBEA, affaire.TempsTotalBEA)
            fields.Add(FIELD_TEMPSRESTANTBEM, affaire.TempsRestantBEM)
            fields.Add(FIELD_TEMPSRESTANTBEE, affaire.TempsRestantBEE)
            fields.Add(FIELD_TEMPSRESTANTBEA, affaire.TempsRestantBEA)
            Return fields
        End Function

        ' ---------------------------------------------------------------------------------------------------------------
        ' Implémentation de IRepository
        ' ---------------------------------------------------------------------------------------------------------------

        Public Overrides Function Add(affaire As Previsionnel, Optional returnId As Boolean = False) As Long
            affaire.Id = MyBase.Add(affaire, True)

            Return If(returnId, affaire.Id, 0)
        End Function

        Public Overrides Function GetAll() As List(Of Previsionnel)
            Dim request As String = "SELECT " & FormatFieldList(FieldList(), True) & "," &
                FormatFieldList(ClientRepos.FieldList(), True) & "," &
                FormatFieldList(MachineRepos.FieldList(), True) &
                " FROM " & TABLE_NAME &
                " JOIN " & ClientsRepository.TABLE_NAME & " ON " & FIELD_CLIENT & " = " & ClientsRepository.TABLE_NAME & "." & FIELD_ID &
                " JOIN " & MachineRepository.TABLE_NAME & " ON " & FIELD_TYPEMACHINE & " = " & MachineRepository.TABLE_NAME & "." & FIELD_ID &
                " ORDER BY " & FIELD_NUMERO & " DESC "
            Dim query As New MonoTableReadQuery(Of Previsionnel)(Me, request)
            Database.GetInstance().ExecuteQuery(query)
            Return query.Data
        End Function

        Public Overrides Function GetById(Id As Long) As Previsionnel
            Dim request As String = "SELECT " & FormatFieldList(FieldList(), True) & "," &
                FormatFieldList(ClientRepos.FieldList(), True) & "," &
                FormatFieldList(MachineRepos.FieldList(), True) &
                " FROM " & TABLE_NAME &
                " JOIN " & ClientsRepository.TABLE_NAME & " ON " & FIELD_CLIENT & " = " & ClientsRepository.TABLE_NAME & "." & FIELD_ID &
                " JOIN " & MachineRepository.TABLE_NAME & " ON " & FIELD_TYPEMACHINE & " = " & MachineRepository.TABLE_NAME & "." & FIELD_ID &
                " WHERE " & TABLE_NAME & "." & FIELD_ID & " = " & Id
            Dim query As New MonoTableReadQuery(Of Previsionnel)(Me, request)
            Database.GetInstance().ExecuteQuery(query)

            Dim affaire As Previsionnel = query.Data.Item(0)
            'UserRepos.FillContributors(affaire)
            Return affaire
        End Function

        Public Overrides Sub Update(affaire As Previsionnel)
            MyBase.Update(affaire)
            ' UserRepos.AssociateUsers(affaire)

        End Sub

    End Class

End Namespace