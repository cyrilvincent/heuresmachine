Imports HeuresMachineWEB.Entities
Imports HeuresMachineWEB.Repositories
Imports System.IO

Public Class VueExport
    Inherits System.Web.UI.Page
    Private reports As List(Of Temps)
    Private connexion As Personne
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connexion = Session("connexion")
        If connexion.Acces.Equals("technicien") Then
            ' BtnPrev.Visible = False
            '  BtnAddUser.Visible = False
        End If

        ' Dim repos As New TempsRepository
        ' reports = repos.GetAll
        GrdTime.DataBind()
    End Sub

    Protected Sub GrdTime_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GrdTime.SelectedIndexChanged
        Dim Id As Integer = GrdTime.SelectedValue
        Dim Repos As New TempsRepository
        Dim affaire As Temps = Repos.GetById(Id)
        Session("affaire") = affaire
        Session("Client") = affaire.Client
        Response.Redirect("SaisieHeures.aspx")
    End Sub


    Private Sub ObjectDataSource1_Selected(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Selected
        Dim l As List(Of Temps) = e.ReturnValue
        If txtSerialNumber.Text <> "" Or txtCustomer.Text <> "" Or txtMachine.Text <> "" Or txtIndice.Text <> "" Or txtnom.Text <> "" Or txtService.Text <> "" Or Txtdate.Text <> "" Then 'Or CldDate.SelectedDate <> Nothing Then
            l.RemoveAll(Function(o) Not (o.NumeroSerie.ToUpper.Contains(txtSerialNumber.Text.ToUpper) And o.Client.Nom.ToUpper.Contains(txtCustomer.Text.ToUpper) And o.TYpeMachine.Modele.ToUpper.Contains(txtMachine.Text.ToUpper) And o.Indice.ToUpper.Contains(txtIndice.Text.ToUpper) And o.Nom.ToUpper.Contains(txtnom.Text.ToUpper) And o.Service.ToUpper.Contains(txtService.Text.ToUpper) And o.Date1.Date >= Txtdate.Text)) 'And o.Date1.Date > CldDate.SelectedDate))
        End If
    End Sub

    Protected Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        GrdTime.DataBind()
    End Sub

    Protected Sub BtnSaisie_Click(sender As Object, e As EventArgs) Handles BtnSaisie.Click
        Response.Redirect("ResearchTempsSaisi.aspx")
    End Sub



End Class