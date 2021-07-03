Imports HeuresMachineWEB.Entities
Imports HeuresMachineWEB.Repositories
Imports System.IO
Public Class ResearchTempsSaisi
    Inherits System.Web.UI.Page
    Private reports As List(Of Temps)
    Private connexion As Personne
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connexion = Session("connexion")

        ' Afin de cacher le bouton "Utilisateur" si le profil est "technicien"
        If connexion.Acces.Equals("technicien") Then
            BtnAddUser.Visible = False
        End If

        ' Afin de cacher le bouton "Vue Export" si le profil est "technicien"
        If connexion.Acces.Equals("technicien") Then
            BtnVue.Visible = False
        End If

        ' Afin de cacher le bouton "Utilisateur" si le profil est "Gestionnaire"
        If connexion.Acces.Equals("Gestionnaire") Then
            BtnAddUser.Visible = False
        End If

        ' Afin de cacher le bouton "Vue Export" si le profil est "Gestionnaire"
        If connexion.Acces.Equals("Gestionnaire") Then
            BtnVue.Visible = False
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
        If txtSerialNumber.Text <> "" Or TxtCustomer.Text <> "" Or TxtMachine.Text <> "" Or TxtIndice.Text <> "" Or TxtNom.Text <> "" Or TxtService.Text <> "" Then
            l.RemoveAll(Function(o) Not (o.NumeroSerie.ToUpper.Contains(txtSerialNumber.Text.ToUpper) And o.Client.Nom.ToUpper.Contains(TxtCustomer.Text.ToUpper) And o.TYpeMachine.Modele.ToUpper.Contains(TxtMachine.Text.ToUpper) And o.Indice.ToUpper.Contains(TxtIndice.Text.ToUpper) And o.Nom.ToUpper.Contains(TxtNom.Text.ToUpper) And o.Service.ToUpper.Contains(TxtService.Text.ToUpper)))
        End If
    End Sub

    Protected Sub BtnAddUser_Click(sender As Object, e As EventArgs) Handles BtnAddUser.Click
        Response.Redirect("ResearchUser.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnVue.Click
        Response.Redirect("VueExport.aspx")
    End Sub

    Protected Sub Btnsearch_Click(sender As Object, e As EventArgs) Handles Btnsearch.Click
        GrdTime.DataBind()
    End Sub
End Class