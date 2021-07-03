Imports HeuresMAchineWEB.Entities

Namespace Repositories

    Public Interface IRepository(Of T As IEntity)
        Function Add(entity As T, Optional returnId As Boolean = False) As Long
        Sub Delete(Id As Long)
        Function GetAll() As List(Of T)
        Function GetAll1() As List(Of T)
        Function GetById(Id As Long) As T
        Function GetCount() As Long
        Sub Update(entity As T)
    End Interface

End Namespace