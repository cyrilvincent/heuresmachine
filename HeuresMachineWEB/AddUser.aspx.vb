Imports HeuresMachineWEB.Entities
Imports HeuresMachineWEB.Repositories

Public Class AddUser
    Inherits System.Web.UI.Page
    Dim user As Personne
    Protected Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim AffaireUsers As UtilisateursRepository
        Dim NewUser As New Personne
        NewUser.Nom = TxtNom.Text
        NewUser.Cwid = TxtCwid.Text
        NewUser.password = txtpassword.Text
        NewUser.Acces = CmbAcces.SelectedItem.Text

        Dim repos As New UtilisateursRepository
        AffaireUsers = New UtilisateursRepository

        If user IsNot Nothing Then
            NewUser.Id = user.Id
            AffaireUsers.Update(NewUser)
            ' AffaireUsers.Add(NewUser, True)
        Else
            AffaireUsers.Add(NewUser, True)
        End If
        '  repos.Add(NewUser)
        Session("user") = NewUser
        Response.Redirect("ResearchUser.aspx")
    End Sub

    Protected Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Response.Redirect("ResearchTempsSaisi.aspx")
    End Sub

    Private Sub BtnSave_Load(sender As Object, e As EventArgs) Handles BtnSave.Load
        user = Session("user")
        If user IsNot Nothing And Not IsPostBack Then
            TxtCwid.Text = user.Cwid
            TxtNom.Text = user.Nom
            txtpassword.Text = user.password
            CmbAcces.SelectedValue = user.Acces
        End If
    End Sub


End Class