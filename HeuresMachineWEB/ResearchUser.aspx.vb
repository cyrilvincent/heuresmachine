Imports System.ComponentModel
Imports System.Data.SqlClient
Imports HeuresMachineWEB.Entities
Imports HeuresMachineWEB.Repositories
Imports System.Web.UI.WebControls
Public Class ResearchUser
    Inherits System.Web.UI.Page
    Private Users As List(Of Personne)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim repos As New UtilisateursRepository
        Users = repos.GetAll
        GrdUsers.DataBind()
    End Sub

    Protected Sub BtnAddUser_Click(sender As Object, e As EventArgs) Handles BtnAddUser.Click
        Response.Redirect("AddUser.aspx")
    End Sub

    Private Sub ObjectDataSource1_Selected(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Selected
        Dim l As List(Of Personne) = e.ReturnValue
        If TxtName.Text <> "" Or TxtAcces.Text <> "" Then
            l.RemoveAll(Function(o) Not (o.Nom.ToUpper.Contains(TxtName.Text.ToUpper) And o.Acces.ToUpper.Contains(TxtAcces.Text.ToUpper)))
        End If
    End Sub

    Protected Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        GrdUsers.DataBind()
    End Sub

    Protected Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Response.Redirect("ResearchTempsSaisi.aspx")
    End Sub

    Protected Sub GrdUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GrdUsers.SelectedIndexChanged
        Dim Id As Integer = GrdUsers.SelectedValue
        Dim Repos As New UtilisateursRepository
        Dim user As Personne = Repos.GetById(Id)
        Session("user") = user
        ' Session("Client") = affaire.Client
        Response.Redirect("AddUser.aspx")
    End Sub
End Class