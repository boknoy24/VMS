Imports System.Data.SQLite

Public Class frmChildInfo

    Private connectionString As String = "Data Source=vms.db;Version=3;"

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub
    Private Sub btnAddnew_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        With frmNewInfo
            .btnUpdate.Enabled = False
            .ShowDialog()
        End With
    End Sub


    Private Sub LoadPeopleData()
        Using connection As New SQLiteConnection(connectionString)
            Dim query As String = "SELECT pid, lastname, firstname, middleinitial, suffix, gender, dateofbirth, mothername, fathername, address FROM information"
            connection.Open()
            Using adapter As New SQLiteDataAdapter(query, connection)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End Using
    End Sub

    Private Sub frmChildInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPeopleData()
    End Sub
    Public Sub RefreshDataGrid()
        LoadPeopleData()
    End Sub
End Class