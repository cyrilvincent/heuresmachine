Imports System.Data.SqlClient
Imports HeuresMachineWEB.Entities

Namespace Repositories

    Public Class UtilisateursRepository
        Inherits ARepository(Of Personne)

        Public Const TABLE_NAME As String = "DBO.PERSONNE"
        Public Const FIELD_CWID As String = TABLE_NAME & "." & "CWID"
        Public Const FIELD_NAME As String = TABLE_NAME & "." & "NOM"
        Public Const FIELD_ACCES As String = TABLE_NAME & "." & "ACCES"
        Public Const FIELD_PASSWORD As String = TABLE_NAME & "." & "PASSWORD"

        '  Public Const ASSOCIATION_NAME As String = "DBO.INTERVENANTS"
        '  Public Const FIELD_OFFER As String = ASSOCIATION_NAME & "." & "OFFRE"
        ' Public Const FIELD_USER As String = ASSOCIATION_NAME & "." & "UTILISATEUR"
        ' Public Const FIELD_QUALITY As String = ASSOCIATION_NAME & "." & "QUALITE"

        Public Overrides Function Mapping(reader As SqlDataReader) As Personne
            Dim user As New Personne()
            user.Id = CType(reader.Item(TABLE_NAME & "." & FIELD_ID), Long)
            user.Cwid = CType(reader.Item(FIELD_CWID), String)
            user.Nom = CType(reader.Item(FIELD_NAME), String)
            user.Acces = CType(reader.Item(FIELD_ACCES), String)
            user.password = CType(reader.Item(FIELD_PASSWORD), String)
            Return user
        End Function

        Public Overrides Function FieldList() As List(Of String)
            Dim fields As List(Of String) = MyBase.FieldList()
            fields.Add(FIELD_CWID)
            fields.Add(FIELD_NAME)
            fields.Add(FIELD_ACCES)
            fields.Add(FIELD_PASSWORD)
            Return fields
        End Function

        Protected Overrides Function TableName() As String
            Return TABLE_NAME
        End Function

        Protected Overrides Function FieldList(user As Personne) As Dictionary(Of String, Object)
            Dim fields As Dictionary(Of String, Object) = MyBase.FieldList(user)
            fields.Add(FIELD_CWID, user.Cwid)
            fields.Add(FIELD_NAME, user.Nom)
            fields.Add(FIELD_ACCES, user.Acces)
            fields.Add(FIELD_PASSWORD, user.password)
            Return fields
        End Function

        ' ----------------------------------------------------------------------------------------------------
        ' Relation avec affaire
        ' ----------------------------------------------------------------------------------------------------

    End Class

End Namespace