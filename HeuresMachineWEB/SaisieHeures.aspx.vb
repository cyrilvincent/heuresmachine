Imports System.ComponentModel
Imports System.Data.SqlClient
Imports HeuresMachineWEB.Entities
Imports HeuresMachineWEB.Repositories
Imports System.Web.UI.WebControls

Public Class SaisieHeures
    Inherits System.Web.UI.Page
    Private affaire As New Previsionnel
    Private affaires As List(Of Previsionnel)
    Private report As Temps
    Private reports As List(Of Temps)
    Private users As List(Of Personne)
    Private modeles As List(Of TypeMachine)
    Private connexion As Personne
    Private Client As Client
    ' Dim us As Personne

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connexion = Session("connexion")
        report = Session("affaire")
        'affaire = Session("affaires")

        'chargement de la liste des users
        Dim UsersRepos As New UtilisateursRepository
        users = UsersRepos.GetAll()

        If CmbCwid1.Items.Count = 0 Then
            For Each user As Personne In users
                CmbCwid1.Items.Add(user.Cwid) '& " " & user.Nom)              
            Next
        End If
        For Each user As Personne In users
            If CmbCwid1.SelectedItem.Text.Equals(user.Cwid) Then
                TxtNom1.Text = user.Nom
            End If
        Next

        'chargement de la liste des modèles de machine
        Dim ModeleRepos As New MachineRepository
        modeles = ModeleRepos.GetAll()

        If CmbModeles.Items.Count = 0 Then
            For Each Model As TypeMachine In modeles
                CmbModeles.Items.Add(Model.Modele)
            Next
        End If


        If report IsNot Nothing And Not IsPostBack Then
            TxtNumber.Enabled = False
            TxtIndice.Enabled = False
            TxtDescriptif.Enabled = False
            TxtClient.Enabled = False
            CmbModeles.Enabled = False
            TxtNumber.Text = report.NumeroSerie
            TxtIndice.Text = report.Indice
            TxtDescriptif.Text = report.Descriptif
            TxtClient.Text = report.Client.Nom
            CmbModeles.SelectedValue = report.TYpeMachine.Modele.ToString
            CldDate.SelectedDate = report.Date1   ' txtDate1.Text = report.Date1
            TxtTemps1.Text = report.Temps1
            CmbCwid1.SelectedValue = report.Cwid
            TxtNom1.Text = report.Nom
            CmbService1.SelectedValue = report.Service
        End If

        '' Dim str As String = ""
        'Dim id As Integer
        ''  Dim Id As Integer = CmbCwid1.SelectedValue
        'Dim Repos As New UtilisateursRepository
        'Dim use As Personne = Repos.GetById(Id.ToString)
        'TxtNom1.Text = use.Nom.ToString
    End Sub


    Protected Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        If Not IsNumeric(TxtTemps1.Text) Then
            Response.Write("<script>alert(""Saisi incorrect"");</script>")
            Session("Temps1") = Nothing
            Exit Sub
        ElseIf IsNothing(TxtTemps1.Text) Then
            Response.Write("<script>alert(""Merci de saisir le temps"");</script>")
            Exit Sub
        ElseIf TxtTemps1.Text = 0 Then
            Response.Write("<script>alert(""Merci de saisir le temps"");</script>")
            Session("Temps1") = Nothing
            Exit Sub
        End If

        System.Web.HttpContext.Current.Session("Numero") = TxtNumber.Text 'affaire.Id
        System.Web.HttpContext.Current.Session("Indice") = TxtIndice.Text
        System.Web.HttpContext.Current.Session("Descriptif") = TxtDescriptif.Text
        ' System.Web.HttpContext.Current.Session("Client") = TxtCustomer.Text

        If IsNothing(report) Then
            report = New Temps
        End If

        'Try
        '    Session("Machine") = txtmachine.Text
        'Catch ex As Exception
        '    Session("Machine") = ""
        'End Try

        Try
            Session("Temps1") = TxtTemps1.Text
        Catch ex As Exception
            Session("Temps1") = "1"
        End Try

        Try
            Session("Date1") = CldDate.SelectedDate 'txtDate1.Text
        Catch ex As Exception
            Session("Date1") = "1"
        End Try

        Try
            Session("Cwid") = CmbCwid1.SelectedItem.Value
        Catch ex As Exception
            Session("Cwid") = "1"
        End Try

        Try
            Session("Nom") = TxtNom1.Text
        Catch ex As Exception
            Session("Nom") = "1"
        End Try

        Try
            Session("Service") = CmbService1.SelectedItem.Text
        Catch ex As Exception
            Session("Service") = "1"
        End Try


        Dim TempsRepos As New TempsRepository
        Dim AffaireRepos As New PrevionnelRepository
        report.NumeroSerie = Session("Numero")
        report.Client = Session("Client")
        report.Indice = Session("Indice")
        report.Descriptif = (Session("Descriptif"))
        report.TYpeMachine = New TypeMachine
        report.Date1 = (Session("Date1"))
        report.Temps1 = (Session("Temps1"))
        report.Cwid = (Session("Cwid"))
        report.Nom = (Session("Nom"))
        report.Service = (Session("Service"))

        reports = TempsRepos.GetAll
        affaires = AffaireRepos.GetAll

        For Each Model As TypeMachine In modeles
            Dim temp As String = Model.Modele
            If temp.Equals(CmbModeles.SelectedItem.Text) Then
                report.TYpeMachine = Model
            End If
        Next

        For Each Model As TypeMachine In modeles
            Dim temp As String = Model.Modele
            If temp.Equals(CmbModeles.SelectedItem.Text) Then
                affaire.TYpeMachine = Model
            End If
        Next

        For Each aff As Previsionnel In affaires
            '  For Each rep As Temps In reports
            Dim temp As String = report.NumeroSerie
            Dim Temp1 As String = report.Indice
            If temp = aff.NumeroSerie And Temp1 = aff.Indice Then
                Dim number As Single
                Dim number1 As Single
                Dim number2 As Single
                'Dim i As Single
                For Each rep As Temps In reports
                    If aff.NumeroSerie = rep.NumeroSerie And aff.Indice = rep.Indice And rep.Service.Equals("Mecanique") Then
                        ' For i = 0 To rep.Temps1
                        number += rep.Temps1
                        ' Next 'i
                    End If

                    If aff.NumeroSerie = rep.NumeroSerie And aff.Indice = rep.Indice And rep.Service.Equals("Electrique") Then
                        ' For i = 0 To rep.Temps1
                        number1 += rep.Temps1
                        ' Next 'i
                    End If

                    If aff.NumeroSerie = rep.NumeroSerie And aff.Indice = rep.Indice And rep.Service.Equals("Automatisme") Then
                        ' For i = 0 To rep.Temps1
                        number2 += rep.Temps1
                        ' Next 'i
                    End If
                Next

                affaire.Id = aff.Id
                If report.Service.Equals("Mecanique") Then
                    affaire.TempsTotalBEM = number + report.Temps1 '+ Session("Temps1")
                    affaire.TempsRestantBEM = aff.TempsBEM - affaire.TempsTotalBEM
                    affaire.TempsRestantBEE = aff.TempsRestantBEE
                    affaire.TempsRestantBEA = aff.TempsRestantBEA
                Else
                    affaire.TempsTotalBEM = aff.TempsTotalBEM
                End If
                If report.Service.Equals("Electrique") Then
                    affaire.TempsTotalBEE = number1 + report.Temps1
                    affaire.TempsRestantBEE = aff.TempsBEE - affaire.TempsTotalBEE
                    affaire.TempsRestantBEA = aff.TempsRestantBEA
                    affaire.TempsRestantBEM = aff.TempsRestantBEM
                Else
                    affaire.TempsTotalBEE = aff.TempsTotalBEE
                End If
                If report.Service.Equals("Automatisme") Then
                    affaire.TempsTotalBEA = number2 + report.Temps1
                    affaire.TempsRestantBEA = aff.TempsBEA - affaire.TempsTotalBEA
                    affaire.TempsRestantBEE = aff.TempsRestantBEE
                    affaire.TempsRestantBEM = aff.TempsRestantBEM
                Else
                    affaire.TempsTotalBEA = aff.TempsTotalBEA
                End If
                affaire.TempsBEM = aff.TempsBEM
                affaire.TempsBEE = aff.TempsBEE
                affaire.TempsBEA = aff.TempsBEA
                'affaire.TempsRestantBEM = affaire.TempsBEM - affaire.TempsTotalBEM
                'affaire.TempsRestantBEE = affaire.TempsBEE - affaire.TempsTotalBEE
                'affaire.TempsRestantBEA = affaire.TempsBEA - affaire.TempsTotalBEA
                ' If affaire.NumeroSerie = report.NumeroSerie And affaire.Indice = report.Indice Then
                affaire.NumeroSerie = aff.NumeroSerie 'Session("Numero")
                affaire.Client = Session("Client")
                affaire.Indice = aff.Indice 'Session("Indice")
                affaire.Descriptif = aff.Descriptif '(Session("Descriptif"))
                AffaireRepos.Update(affaire)
                ' End If
                'AffaireRepos.Update(affaire)
            End If
        Next

        TempsRepos = New TempsRepository
        AffaireRepos = New PrevionnelRepository
        'If report.Id = 0 Then
        TempsRepos.Add(report, True)
        Response.Write("<script>alert(""Heures Ajoutées"");window.location=""ResearchTempsSaisi.aspx"";</script>")
        ' Else
        ' TempsRepos.Update(report)
        ' End If
        '  Response.Redirect("ResearchTempsSaisi.aspx")
    End Sub

    Protected Sub CmbCwid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCwid1.SelectedIndexChanged
        ' Dim Id As String = CmbCwid1.SelectedValue
        ' Dim Repos As New UtilisateursRepository
        ' Dim user As Personne = Repos.GetById(Id)
        'TxtNom1.Text = user.Nom
        '  Session("Client") = affaire.Client
        '  Response.Redirect("SaisieHeures.aspx")
    End Sub

    Protected Sub Btnajout_Click(sender As Object, e As EventArgs) Handles Btnajout.Click
        'Lbldate2.Visible = True
        'txtDate2.Visible = True
        'LblTemps2.Visible = True
        'TxtTemps2.Visible = True
        'TxtNom2.Visible = True
        'LblNom2.Visible = True
        'CmbCwid2.Visible = True
        'LblCwid2.Visible = True
        'CmbService2.Visible = True
        'LblService2.Visible = True

        'If txtDate2.Text IsNot Nothing Then
        '    Lbldate3.Visible = True
        '    txtDate3.Visible = True
        '    LblTemps3.Visible = True
        '    TxtTemps3.Visible = True
        '    TxtNom3.Visible = True
        '    LblNom3.Visible = True
        '    CmbCwid3.Visible = True
        '    LblCwid3.Visible = True
        '    CmbService3.Visible = True
        '    LblService3.Visible = True
        'End If
    End Sub

    Protected Sub BtnModifier_Click(sender As Object, e As EventArgs) Handles BtnModifier.Click
        System.Web.HttpContext.Current.Session("Numero") = TxtNumber.Text 'affaire.Id
        System.Web.HttpContext.Current.Session("Indice") = TxtIndice.Text
        System.Web.HttpContext.Current.Session("Descriptif") = TxtDescriptif.Text
        ' System.Web.HttpContext.Current.Session("Client") = TxtCustomer.Text

        If IsNothing(report) Then
            report = New Temps
        End If

        'Try
        '    Session("Machine") = txtmachine.Text
        'Catch ex As Exception
        '    Session("Machine") = ""
        'End Try

        Try
            Session("Temps1") = TxtTemps1.Text
        Catch ex As Exception
            Session("Temps1") = "1"
        End Try

        Try
            Session("Date1") = CldDate.SelectedDate 'txtDate1.Text
        Catch ex As Exception
            Session("Date1") = "1"
        End Try

        Try
            Session("Cwid") = CmbCwid1.SelectedItem.Value
        Catch ex As Exception
            Session("Cwid") = "1"
        End Try

        Try
            Session("Nom") = TxtNom1.Text
        Catch ex As Exception
            Session("Nom") = "1"
        End Try

        Try
            Session("Service") = CmbService1.SelectedItem.Text
        Catch ex As Exception
            Session("Service") = "1"
        End Try

        Dim AffaireRepos As New PrevionnelRepository
        Dim TempsRepos As New TempsRepository

        report.NumeroSerie = Session("Numero")
        report.Client = Session("Client")
        report.Indice = Session("Indice")
        report.Descriptif = (Session("Descriptif"))
        report.TYpeMachine = New TypeMachine
        report.Date1 = (Session("Date1"))
        report.Temps1 = (Session("Temps1"))
        report.Cwid = (Session("Cwid"))
        report.Nom = (Session("Nom"))
        report.Service = (Session("Service"))
        ' If CmbService1.SelectedValue.Equals("Automatisme") Then
        'report.
        ' End If

        For Each Model As TypeMachine In modeles
            Dim temp As String = Model.Modele
            If temp.Equals(CmbModeles.SelectedItem.Text) Then
                report.TYpeMachine = Model
            End If
        Next

        For Each Model As TypeMachine In modeles
            Dim temp As String = Model.Modele
            If temp.Equals(CmbModeles.SelectedItem.Text) Then
                affaire.TYpeMachine = Model
            End If
        Next

        affaires = AffaireRepos.GetAll
        reports = TempsRepos.GetAll

        For Each aff As Previsionnel In affaires
            '  For Each rep As Temps In reports
            Dim temp As String = report.NumeroSerie
            If temp = aff.NumeroSerie Then
                'Dim number1 As Single
                Dim number As Single
                'Dim i As Single
                For Each rep As Temps In reports
                    If aff.NumeroSerie = rep.NumeroSerie And aff.Indice = rep.Indice And rep.Service.Equals("Mecanique") Then
                        ' For i = 0 To rep.Temps1
                        number += rep.Temps1
                        ' Next 'i
                    End If
                Next
                affaire.Id = aff.Id
                '  number1 = number - report.Temps1
                affaire.TempsTotalBEM = (number + Session("Temps1"))
                affaire.TempsBEM = aff.TempsBEM
                affaire.TempsBEE = aff.TempsBEE
                affaire.TempsBEA = aff.TempsBEA
                affaire.NumeroSerie = Session("Numero")
                affaire.Client = Session("Client")
                affaire.Indice = Session("Indice")
                affaire.Descriptif = (Session("Descriptif"))
                AffaireRepos.Update(affaire)
            End If
        Next

        AffaireRepos = New PrevionnelRepository
        TempsRepos = New TempsRepository
        'If report.Id = 0 Then
        'TempsRepos.Add(report, True)
        'Else
        TempsRepos.Update(report)
        'End If
        Response.Redirect("ResearchTempsSaisi.aspx")
    End Sub

    Protected Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Response.Redirect("ResearchTempsSaisi.aspx")
    End Sub
End Class