Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmMain
    Private Sub btnChildInfo_Click(sender As Object, e As EventArgs) Handles btnChildInfo.Click
        With frmChildInfo
            .TopLevel = False
            Panel2.Controls.Add(frmChildInfo)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnVaccine_Click(sender As Object, e As EventArgs) Handles btnVaccine.Click
        With frmVaccine
            .TopLevel = False
            Panel2.Controls.Add(frmVaccine)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchText As String = txtSearch.Text.Trim()

        If String.IsNullOrEmpty(searchText) OrElse searchText = "Enter information here" Then
            MessageBox.Show("Please enter a valid search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        With frmSearch
            .TopLevel = False
            Panel2.Controls.Add(frmSearch)
            .BringToFront()
            .PerformSearch(searchText)

            .Show()
        End With
    End Sub


    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        If txtSearch.Text = "Enter information here" Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Enter information here"
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Hide()
        frmLogin.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSearch.Text = "Enter information here"
        txtSearch.ForeColor = Color.Gray
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim intx As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim inty As Integer = Screen.PrimaryScreen.Bounds.Height

        Me.Width = intx
        Me.Height = inty

        Me.Left = 0
        Me.Top = 0
    End Sub


End Class
