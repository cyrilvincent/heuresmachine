Namespace Entities
    Public Class Previsionnel
        Implements IEntity
        Public Property Id As Long Implements IEntity.Id
        Public Property NumeroSerie As String
        Public Property Indice As String 'Nullable(Of Integer)
        Public Property Descriptif As String
        Public Property Client As Client
        Public Property TYpeMachine As TypeMachine
        Public Property TempsBEM As Single
        Public Property TempsBEE As Single
        Public Property TempsBEA As Single
        Public Property TempsTotalBEM As Single
        Public Property TempsTotalBEE As Single
        Public Property TempsTotalBEA As Single
        Public Property TempsRestantBEM As Single
        Public Property TempsRestantBEE As Single
        Public Property TempsRestantBEA As Single
    End Class


End Namespace