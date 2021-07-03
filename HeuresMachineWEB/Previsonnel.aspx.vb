Imports System.Data.SqlClient
Imports HeuresMachineWEB.Entities
Imports HeuresMachineWEB.Repositories
Imports System.Web.UI.WebControls
Public Class Previsonnel
    Inherits System.Web.UI.Page

    Private Client As Client
    Private affaire As New Previsionnel
    Private report As New Temps
    Private Modeles As List(Of TypeMachine)
    Private connexion As Personne

    Protected Sub BtnCustomer_Click(sender As Object, e As EventArgs) Handles BtnCustomer.Click
        Dim showform As New ResearchCustomer()
        Response.Redirect("ResearchCustomer.aspx")
        If IsNothing(showform.GetSelectedCustomer) Then
            Response.Write("<script>window.close();</script>")
        Else
            Client = showform.GetSelectedCustomer
            TxtCustomer.Text = showform.GetSelectedCustomer.Nom & " " & showform.GetSelectedCustomer.Pays & " " & showform.GetSelectedCustomer.Ville
            showform = Nothing
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        affaire = Session("affaires")
        'If affaire.Client.Id = 0 Then
        '    TxtCustomer.Text = " "
        'End If
        connexion = Session("connexion")
        If connexion.Acces.Equals("technicien") Or connexion.Acces.Equals("Gestion") Then
            TxtBEA.Enabled = False
            TxtBEE.Enabled = False
            TxtBEM.Enabled = False
            BtnAdd.Visible = False
        End If

        'chargement de la liste des modèles de machine
        Dim ModeleRepos As New MachineRepository
        Modeles = ModeleRepos.GetAll()

        For Each Model As TypeMachine In Modeles
            CmbModele.Items.Add(Model.Modele)
        Next


        If affaire IsNot Nothing And Not IsPostBack Then
            ' TxtNumber.Enabled = False
            ' TxtIndice.Enabled = False
            TxtNumber.Text = affaire.NumeroSerie
            TxtIndice.Text = affaire.Indice
            TxtDescriptif.Text = affaire.Descriptif
            TxtCustomer.Text = affaire.Client.Nom
            CmbModele.SelectedValue = affaire.TYpeMachine.Modele.ToString
            TxtBEA.Text = affaire.TempsBEA
            TxtBEE.Text = affaire.TempsBEE
            TxtBEM.Text = affaire.TempsBEM
            affaire.Client = Session("Client")
        End If

        If Session("Client") IsNot Nothing Then
            Dim Client As Client = Session("Client")
            TxtCustomer.Text = Client.Nom & " " & Client.Ville & " " & Client.Pays
        End If
        Session("affaires") = affaire
    End Sub

    Protected Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        If IsNothing(TxtNumber.Text) Then
            Response.Write("<script>alert(""Merci de saisir un Numero de Serie"");</script>")
            Session("Numero") = Nothing
            ' Exit Sub
        End If
        If IsNothing(TxtIndice.Text) Then
            Response.Write("<script>alert(""Merci de saisir l'indice"");</script>")
            ' Exit Sub
            Session("Indice") = Nothing
        End If

        If IsNothing(TxtCustomer.Text) Then
            Response.Write("<script>alert(""Merci de choisir le client"");</script>")
            Exit Sub
        ElseIf TxtCustomer.Text.Equals("") Then
            Response.Write("<script>alert(""Merci de choisir le client"");</script>")
            Exit Sub
        End If

        If Not IsNumeric(TxtBEA.Text) Then
            Response.Write("<script>alert(""Vérifier les caractéres saisis pour le Temps Prévu BEA"");</script>")
            Exit Sub
        ElseIf TxtBEA.Text.Equals("") Then
            Response.Write("<script>alert(""Saisir le Temps Prévu BEA"");</script>")
            Exit Sub
        End If

        If Not IsNumeric(TxtBEE.Text) Then
            Response.Write("<script>alert(""Vérifier les caractéres saisis pour le Temps Prévu BEE"");</script>")
            Exit Sub
        ElseIf TxtBEE.Text.Equals("") Then
            Response.Write("<script>alert(""Saisir le Temps Prévu BEE"");</script>")
            Exit Sub
        End If
        If Not IsNumeric(TxtBEM.Text) Then
            Response.Write("<script>alert(""Vérifier les caractéres saisis pour le Temps Prévu BEM"");</script>")
            Exit Sub
        ElseIf TxtBEM.Text.Equals("") Then
            Response.Write("<script>alert(""Saisir le Temps Prévu BEM"");</script>")
            Exit Sub
        End If
        System.Web.HttpContext.Current.Session("Numero") = TxtNumber.Text
        System.Web.HttpContext.Current.Session("Indice") = TxtIndice.Text
        System.Web.HttpContext.Current.Session("Descriptif") = TxtDescriptif.Text
        ' System.Web.HttpContext.Current.Session("Client") = TxtCustomer.Text

        If IsNothing(affaire) Then
            affaire = New Previsionnel
        End If

        Try
            Session("Model") = CmbModele.SelectedItem.Text
        Catch ex As Exception
            Session("Model") = ""
        End Try

        Try
            Session("TempsBEM") = TxtBEM.Text
        Catch ex As Exception
            Session("TempsBEM") = "1"
        End Try

        Try
            Session("TempsBEE") = TxtBEE.Text
        Catch ex As Exception
            Session("TempsBEE") = "1"
        End Try

        Try
            Session("TempsBEA") = TxtBEA.Text
        Catch ex As Exception
            Session("TempsBEA") = "1"
        End Try

        Dim AffairreRepo As PrevionnelRepository
        Dim ReportRepos As TempsRepository

        affaire.NumeroSerie = Session("Numero")
        affaire.Client = Session("Client")
        affaire.Indice = Session("Indice")
        affaire.Descriptif = (Session("Descriptif"))
        affaire.TYpeMachine = New TypeMachine
        affaire.TempsBEM = (Session("TempsBEM"))
        affaire.TempsBEE = (Session("TempsBEE"))
        affaire.TempsBEA = (Session("TempsBEA"))
        affaire.TempsTotalBEM = 0
        affaire.TempsTotalBEE = 0
        affaire.TempsTotalBEA = 0
        affaire.TempsRestantBEM = affaire.TempsBEM - affaire.TempsTotalBEM
        affaire.TempsRestantBEE = affaire.TempsBEE - affaire.TempsTotalBEE
        affaire.TempsRestantBEA = affaire.TempsBEA - affaire.TempsTotalBEA
        ' affaire.TempsTotalBEM = report.Temps1

        For Each Model As TypeMachine In Modeles
            Dim Temp As String = Model.Modele
            If Temp.Equals(CmbModele.SelectedItem.Text) Then
                affaire.TYpeMachine = Model
            End If
        Next
        report.NumeroSerie = Session("Numero")
        report.Client = Session("Client")
        report.Indice = Session("Indice")
        report.Descriptif = (Session("Descriptif"))
        report.TYpeMachine = New TypeMachine
        report.Cwid = ""
        report.Date1 = DateTime.Now
        report.Temps1 = 0
        report.Nom = ""
        report.Service = ""
        'report.TempsBEM = affaire.TempsBEM
        'report.TempsBEA = affaire.TempsBEA
        'report.TempsBEE = affaire.TempsBEE
        ' report.TempsRestantBEM = 0
        ' report.TempsRestantBEA = 0
        ' report.TempsRestantBEE = 0
        For Each Model As TypeMachine In Modeles
            Dim Temp As String = Model.Modele
            If Temp.Equals(CmbModele.SelectedItem.Text) Then
                report.TYpeMachine = Model
            End If
        Next

        AffairreRepo = New PrevionnelRepository
        ReportRepos = New TempsRepository
        If affaire.Id = 0 Then
            AffairreRepo.Add(affaire, True)
            ReportRepos.Add(report, True)
        Else
            AffairreRepo.Update(affaire)
            ReportRepos.Update(report)
        End If
        Response.Redirect("ResearchserialNumber.aspx")
        'HttpContext.Current.Session("ID_OFFER") = AffairreRepo.Add(affaire, True)
    End Sub

    Protected Sub Btncancel_Click(sender As Object, e As EventArgs) Handles Btncancel.Click
        Response.Redirect("ResearchSerialNumber.aspx")
    End Sub

    Protected Sub BtnAddCustomer_Click(sender As Object, e As EventArgs) Handles BtnAddCustomer.Click
        Response.Redirect("HmiCustomer.aspx")
    End Sub

    Protected Sub CmbModele_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class