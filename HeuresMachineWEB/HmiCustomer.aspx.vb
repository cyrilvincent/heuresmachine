Imports System.Data.SqlClient
Imports HeuresMachineWEB.Entities
Imports HeuresMachineWEB.Repositories
Imports System.Web.UI.WebControls
Public Class HmiCustomer
    Inherits System.Web.UI.Page
    Private Customer As Client
    Private modifyCustomer As Boolean = False


    ' Private Shared Logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()
    ' Public Sub New(Customer As Client)

    ' Cet appel est requis par le concepteur.
    ' InitializeComponent()

    'If Customer IsNot Nothing Then
    '   modifyCustomer = True
    'Me.Customer = Customer
    'End If

    ' End Sub


    Protected Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        ' Response.Write("<body><script>window.close();</script></body>")
        Response.Redirect("Previsionnel.aspx")
    End Sub

    Protected Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If IsNothing(TxtName.Text) Then
            Response.Write("<script>alert(""Required Name Field"");</script>")
            Exit Sub
        ElseIf TxtName.Text.Equals("") Then
            Response.Write("<script>alert(""Required Name Field"");</script>")
            Exit Sub
        End If

        If IsNothing(TxtCity.Text) Then
            Response.Write("<script>alert(""Required City Field"");</script>")
            Exit Sub
        ElseIf TxtCity.Text.Equals("") Then
            Response.Write("<script>alert(""Required City Field"");</script>")
            Exit Sub
        End If

        If IsNothing(TxtCountry.Text) Then
            Response.Write("<script>alert(""Required Country Field"");</script>")
            Exit Sub
        ElseIf TxtCountry.Text.Equals("") Then
            Response.Write("<script>alert(""Required Country Field"");</script>")
            Exit Sub
        End If

        If IsNothing(CmbArea.SelectedItem) Then
            Response.Write("<script>alert(""Required Area Field"");</script>")
            Exit Sub
        ElseIf CmbArea.SelectedItem.Equals("") Then
            Response.Write("<script>alert(""Required Area Field"");</script>")
            Exit Sub
        End If
        Dim NewClient As New Client
        NewClient.Nom = TxtName.Text
        NewClient.Ville = TxtCity.Text
        NewClient.Pays = TxtCountry.Text
        NewClient.Zone = CmbArea.SelectedItem.Value

        Dim Repos As New ClientsRepository

        If Customer IsNot Nothing Then
            NewClient.Id = Customer.Id
            Repos.Update(NewClient)
        Else
            Repos.Add(NewClient)
        End If
        Session("Client") = NewClient
        Response.Redirect("ResearchSerialNumber.aspx")
        Session("Client") = Nothing
    End Sub

    Private Sub HmiCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Customer = Session("Client")
        '  Try
        If Customer IsNot Nothing And Not IsPostBack Then
            TxtName.Text = Customer.Nom
            TxtCity.Text = Customer.Ville
            TxtCountry.Text = Customer.Pays
            CmbArea.SelectedValue = Customer.Zone
            '  Me.Text = "MODIFY A CUSTOMER"
        End If
        'Catch ex As Exception
        'Logger.Debug(ex, "Show Customer")
        ' End Try
    End Sub

End Class