Imports HeuresMachineWEB.Entities

Namespace Repositories

    Public Class ClientsRepository
        Inherits ARepository(Of Client)

        Public Const TABLE_NAME As String = "DBO.CLIENTS"
        Public Const FIELD_NOM As String = TABLE_NAME & "." & "NOM"
        Public Const FIELD_VILLE As String = TABLE_NAME & "." & "VILLE"
        Public Const FIELD_PAYS As String = TABLE_NAME & "." & "PAYS"
        Public Const FIELD_ZONE As String = TABLE_NAME & "." & "ZONE"

        Public Overrides Function Mapping(reader As System.Data.SqlClient.SqlDataReader) As Entities.Client
            Dim client As New Client()
            client.Id = CType(reader(TABLE_NAME & "." & FIELD_ID), Long)
            client.Nom = CType(reader(FIELD_NOM), String)
            client.Ville = CType(reader(FIELD_VILLE), String)
            client.Pays = CType(reader(FIELD_PAYS), String)
            client.Zone = CType(reader(FIELD_ZONE), String)
            Return client
        End Function

        Protected Overrides Function TableName() As String
            Return TABLE_NAME
        End Function

        Public Overrides Function FieldList() As List(Of String)
            Dim fields As List(Of String) = MyBase.FieldList()
            fields.Add(FIELD_NOM)
            fields.Add(FIELD_VILLE)
            fields.Add(FIELD_PAYS)
            fields.Add(FIELD_ZONE)
            Return fields
        End Function

        Protected Overrides Function FieldList(entity As Client) As System.Collections.Generic.Dictionary(Of String, Object)
            Dim fields As Dictionary(Of String, Object) = MyBase.FieldList(entity)
            fields.Add(FIELD_NOM, entity.Nom)
            fields.Add(FIELD_VILLE, entity.Ville)
            fields.Add(FIELD_PAYS, entity.Pays)
            fields.Add(FIELD_ZONE, entity.Zone)
            Return fields
        End Function
    End Class

End Namespace