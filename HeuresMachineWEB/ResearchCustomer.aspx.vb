﻿Imports System.ComponentModel
Imports System.Data.SqlClient
Imports HeuresMachineWEB.Entities
Imports HeuresMachineWEB.Repositories
Imports System.Web.UI.WebControls

Public Class ResearchCustomer
    Inherits System.Web.UI.Page
    ' Private Shared Logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()
    Private clients As List(Of Client)
    Private SelectedCustomer As Client

    Public Sub LoadGrid()
        ' Try
        Dim clientTable As New DataTable()

        GrdClientList.DataSource = clientTable

        clientTable.Columns.Add("Nom", GetType(System.String))
            clientTable.Columns.Add("Ville", GetType(System.String))
            clientTable.Columns.Add("Pays", GetType(System.String))

            For Each client As Client In clients
                If Not client.Nom.ToUpper.Contains(TxtName.Text.ToUpper) Then Continue For
                If Not client.Pays.ToUpper.Contains(TxtCountry.Text.ToUpper) Then Continue For
                Dim row As DataRow = clientTable.NewRow()
                row("Nom") = client.Nom
                row("Ville") = client.Ville
                row("Pays") = client.Pays
                clientTable.Rows.Add(row)
            Next
            GrdClientList.DataBind()
            ' Catch ex As Exception
        '  Logger.Debug(ex, "Show Customer List")
        ' End Try

    End Sub



    Private Sub ResearchCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ClientRepos As New ClientsRepository()
        clients = ClientRepos.GetAll()
        ' LoadGrid()
    End Sub

    Public Function GetSelectedCustomer() As Client
        Return SelectedCustomer
    End Function

    Protected Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        GrdClientList.DataBind()
    End Sub

    Protected Sub GrdClientList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GrdClientList.SelectedIndexChanged
        Dim Id As Integer = GrdClientList.SelectedValue
        Dim selectedRow As GridViewRow = GrdClientList.SelectedRow
        ' Dim ClientRepos As New OffresRepository()
        ' Dim Client As Client = ClientRepos.GetById(Id)       
        ' Session("Client") = Offre.Client
        For Each Customer As Client In clients
            If Customer.Nom.Equals(selectedRow.Cells(2).Text) And Customer.Ville.Equals(selectedRow.Cells(3).Text) And Customer.Pays.Equals(selectedRow.Cells(4).Text) Then
                SelectedCustomer = Customer
                Session("Client") = SelectedCustomer
                Exit For
            End If
        Next
        Dim Showform As New ResearchCustomer()

        ' Response.Redirect("HmiOffer.aspx")
        '  If Request.QueryString("SwitchOffer") = "1" Then
        ' Response.Redirect("HmiCustomer.aspx")
        '  Else
        '  Session("client") = Nothing
        Response.Redirect("Previsonnel.aspx")
        '  End If
    End Sub

    Protected Sub ObjectDataSource1_Selected(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Selected
        Dim l As List(Of Client) = e.ReturnValue
        If TxtName.Text <> "" Or TxtCountry.Text <> "" Then
            l.RemoveAll(Function(o) Not (o.Nom.ToUpper.Contains(TxtName.Text.ToUpper) And o.Pays.ToUpper.Contains(TxtCountry.Text.ToUpper)))
        End If
    End Sub


End Class