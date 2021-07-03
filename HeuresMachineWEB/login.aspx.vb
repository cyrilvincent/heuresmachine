Imports System.ComponentModel
Imports System.Data.SqlClient
Imports HeuresMachineWEB.Entities
Imports HeuresMachineWEB.Repositories
Imports System.Web.UI.WebControls
Public Class login
    Inherits System.Web.UI.Page

    Private users As List(Of Personne)
    Private Const dbServer As String = "CFRS000100\SQLSERVER"
    ' Private Const dbServer As String = "DFFMZD1587\CFRDB01"
    Private Const catalog As String = "HeuresMachine"
    Private conn As New SqlConnection("Data Source=" & dbServer & ";Initial Catalog=" & catalog & ";Integrated Security=True")
    Dim dr As SqlDataReader
    Private connexion As Personne
    ' Dim IDE As Integer = 0

    Protected Sub btnConn_Click(sender As Object, e As EventArgs) Handles btnConn.Click
        Dim UsersRepos As New UtilisateursRepository
        users = UsersRepos.GetAll()
        'Dim conn As New SqlConnection("Data Source=" & dbServer & ";Initial Catalog=" & catalog & ";Integrated Security=True")
        'conn.Open()
        'Dim commando As New SqlCommand("select * from dbo.personne where cwid='" & txtuser.Text & "'AND password='" & txtPassword.Text & "' ", conn)
        '' conn.Close()
        'dr = commando.ExecuteReader

        '' Dim connexion As Personne = UsersRepos.GetById(IDE)
        'If dr.Read Then
        '    Response.Redirect("researchtempssaisi.aspx")
        '    ' Response.Write("yes")
        'Else
        '    Response.Write("no")
        'End If
        Dim cwid As String = txtuser.Text
        Dim pass As String = txtPassword.Text
        ' Dim connexion As Personne = UsersRepos.GetById(Ide)
        For Each user As Personne In users
            If cwid = user.Cwid And pass = user.password Then
                Session("connexion") = user
                Response.Redirect("researchtempssaisi.aspx")
            Else
                Response.Write("mot de passe incorrect")
                ' Response.Write("<script>alert(""Mot de passe ou Identifiant incorrect"");</script>")
                '  Exit Sub
            End If
        Next
        ' connexion.Cwid = txtuser.Text
        ' connexion.password = txtPassword.Text
        ' Session("connexion") = connexion
    End Sub


    'Protected Sub validateUser(sender As Object, e As EventArgs)
    '    Dim UsersRepos As New UtilisateursRepository
    '    users = UsersRepos.GetAll()

    '    'conn.Open()
    '    Dim conn As New SqlConnection("Data Source=" & dbServer & ";Initial Catalog=" & catalog & ";Integrated Security=True")

    '    Dim commando As New SqlCommand("select ID * from dbo.personne where cwid=@cwid AND password=@password", conn)
    '    commando.CommandType = CommandType.StoredProcedure
    '    commando.Parameters.AddWithValue("@cwid", Login1.UserName)
    '    commando.Parameters.AddWithValue("@password", Login1.Password)
    '    commando.Connection = conn
    '    conn.Open()
    '    IDE = Convert.ToInt32(commando.ExecuteScalar())
    '    conn.Close()
    '    'dr = commando.ExecuteReader

    '    Dim connexion As Personne = UsersRepos.GetById(IDE)
    '    If IDE <> 0 Then 'dr.Read Then
    '        ' Response.Redirect("researchtempssaisi.aspx")
    '        Response.Write("yes")
    '    Else
    '        Response.Write("no")
    '    End If
    '    Session("connexion") = connexion
    'End Sub
End Class