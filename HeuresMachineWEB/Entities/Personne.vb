Namespace Entities

    Public Class Personne
        Implements IEntity

        Public Property Id As Long Implements IEntity.Id
        Public Property Cwid As String
        Public Property Nom As String
        Public Property Acces As String
        Public Property password As String
    End Class

    Public Class Intervenant
        Inherits Personne


        Public Sub New()
        End Sub

        Public Sub New(user As Personne)
            Id = user.Id
            Cwid = user.Cwid
            Nom = user.Nom
            Acces = user.Acces
            password = user.password
        End Sub
    End Class

End Namespace