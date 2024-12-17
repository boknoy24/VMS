Imports MySql.Data.MySqlClient

Public Class frmSearch
    Private connectionString As String = "Server=localhost;Database=vms;Uid=root;Pwd=;"

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
        Using connection As New MySqlConnection(connectionString)
            Dim query As String = "SELECT pid, lastname, firstname, middleinitial, suffix, gender, dateofbirth, mothername, fathername, address FROM information"
            connection.Open()
            Using adapter As New MySqlDataAdapter(query, connection)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End Using
    End Sub

    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPeopleData()
    End Sub

    Public Sub RefreshDataGrid()
        LoadPeopleData()
    End Sub
End Class
