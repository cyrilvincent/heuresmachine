Namespace Entities
    Public Class Temps
        Implements IEntity
        Public Property Id As Long Implements IEntity.Id
        Public Property NumeroSerie As String
        Public Property Indice As String 'Nullable(Of Integer)
        Public Property Descriptif As String
        Public Property Client As Client
        Public Property TYpeMachine As TypeMachine
        Public Property Date1 As DateTime
        Public Property Temps1 As Single
        Public Property Cwid As String
        Public Property Nom As String
        Public Property Service As String
        'Public Property TempsBEM As Single
        'Public Property TempsBEE As Single
        'Public Property TempsBEA As Single
        'Public Property TempsRestantBEM As Single
        'Public Property TempsRestantBEE As Single
        'Public Property TempsRestantBEA As Single

    End Class
End Namespace