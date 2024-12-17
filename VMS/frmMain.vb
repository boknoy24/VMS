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

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Hide()
        frmLogin.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
