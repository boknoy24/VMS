
Imports MySql.Data.MySqlClient

Public Class frmChildInfo
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

    Private Sub frmChildInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPeopleData()
    End Sub

    Public Sub RefreshDataGrid()
        LoadPeopleData()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colname As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colname = "btnEdit" Then
            With frmNewInfo
                .txtPID.Text = DataGridView1.Rows(e.RowIndex).Cells("pid").Value.ToString()
                .txtLname.Text = DataGridView1.Rows(e.RowIndex).Cells("lastname").Value.ToString()
                .txtFname.Text = DataGridView1.Rows(e.RowIndex).Cells("firstname").Value.ToString()
                .txtMI.Text = DataGridView1.Rows(e.RowIndex).Cells("middleinitial").Value.ToString()
                .txtSuffix.Text = DataGridView1.Rows(e.RowIndex).Cells("suffix").Value.ToString()
                .cmbSex.Text = DataGridView1.Rows(e.RowIndex).Cells("gender").Value.ToString()
                .dtpBirthDate.Value = Convert.ToDateTime(DataGridView1.Rows(e.RowIndex).Cells("dateofbirth").Value)
                .txtMother.Text = DataGridView1.Rows(e.RowIndex).Cells("mothername").Value.ToString()
                .txtFather.Text = DataGridView1.Rows(e.RowIndex).Cells("fathername").Value.ToString()
                .txtAddress.Text = DataGridView1.Rows(e.RowIndex).Cells("address").Value.ToString()
                .btnSave.Enabled = False
                .ShowDialog()
            End With
        ElseIf colname = "btnDelete" Then
            Dim pid As Integer = CInt(DataGridView1.Rows(e.RowIndex).Cells("pid").Value)

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                Try
                    Using connection As New MySqlConnection(connectionString)
                        connection.Open()
                        Dim query As String = "DELETE FROM information WHERE pid = @pid"

                        Using command As New MySqlCommand(query, connection)
                            command.Parameters.AddWithValue("@pid", pid)
                            command.ExecuteNonQuery()
                        End Using
                    End Using

                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadPeopleData()
                Catch ex As Exception
                    MessageBox.Show("An error occurred while deleting the data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If

    End Sub
End Class