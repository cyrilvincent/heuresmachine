Namespace Entities

    Public Class Client
        Implements IEntity

        Public Property Id As Long Implements IEntity.Id
        Public Property Nom As String
        Public Property Ville As String
        Public Property Pays As String
        Public Property Zone As String
    End Class
End Namespace