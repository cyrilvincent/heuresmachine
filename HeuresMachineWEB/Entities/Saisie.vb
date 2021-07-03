Namespace Entities
    Public Class Saisie
        Implements IEntity
        Public Property Id As Long Implements IEntity.Id
        Public Property NumeroSerie As String
        Public Property Date1 As String
        Public Property Temps As Single
        Public Property Cwid As String
        Public Property Nom As String
        Public Property Service As String
        Public Property Indice As String

        Public Property Affaire As Long
    End Class
End Namespace