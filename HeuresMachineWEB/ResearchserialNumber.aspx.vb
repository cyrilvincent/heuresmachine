
Imports HeuresMachineWEB.Entities
Imports HeuresMachineWEB.Repositories

Public Class ResearchserialNumber
    Inherits System.Web.UI.Page
    Private Affaires As List(Of Previsionnel)
    Private reports As List(Of Temps)
    Private connexion As Personne


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("Client") = Nothing
        connexion = Session("connexion")
        If connexion.Acces.Equals("Gestion") Or connexion.Acces.Equals("technicien") Then
            BtnPrev.Visible = False
        End If
        Dim repos As New PrevionnelRepository
        Dim repo As New TempsRepository
        Affaires = repos.GetAll
        reports = repo.GetAll
        GrdPrev.DataBind()

        'For Each aff As Previsionnel In Affaires
        '    Dim temp As String = report.NumeroSerie
        '    If temp = aff.NumeroSerie Then
        '        aff.TempsTotalBEM = aff.TempsBEM - report.Temps1
        '    End If
        'Next
        'If BtnPrev.OnClientClick Then
        '    Session("affaire") = False
        'End If
    End Sub

    Protected Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        GrdPrev.DataBind()
    End Sub

    Private Sub ObjectDataSource1_Selected(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Selected
        Dim l As List(Of Previsionnel) = e.ReturnValue
        If TxtserialNumber.Text <> "" Or TxtCustomer.Text <> "" Or TxtMachine.Text <> "" Then
            l.RemoveAll(Function(o) Not (o.NumeroSerie.ToUpper.Contains(TxtserialNumber.Text.ToUpper) And o.Client.Nom.ToUpper.Contains(TxtCustomer.Text.ToUpper) And o.TYpeMachine.Modele.ToUpper.Contains(TxtMachine.Text.ToUpper)))
        End If
    End Sub

    Protected Sub GrdPrev_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GrdPrev.SelectedIndexChanged
        Dim Id As Integer = GrdPrev.SelectedValue
        Dim Repos As New PrevionnelRepository
        Dim affaire As Previsionnel = Repos.GetById(Id)
        Session("affaires") = affaire
        Session("Client") = affaire.Client
        Response.Redirect("Previsonnel.aspx")
    End Sub

    Protected Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click

        Response.Redirect("Previsonnel.aspx")
        ' Session("affaires") = Nothing
    End Sub



    Protected Sub BtnSaisi_Click(sender As Object, e As EventArgs) Handles BtnSaisi.Click
        Response.Redirect("ResearchTempsSaisi.aspx")
    End Sub
End Class