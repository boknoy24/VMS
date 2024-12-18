Imports MySql.Data.MySqlClient

Public Class frmSearch
    Private connectionString As String = "Server=localhost;Database=vms;Uid=root;Pwd=;"
    Public Sub PerformSearch(searchText As String)
        If String.IsNullOrEmpty(searchText) Then
            MessageBox.Show("Search term cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim query As String = "SELECT pid, lastname, firstname, middleinitial, suffix, gender, dateofbirth, mothername, fathername, address " &
                              "FROM information " &
                              "WHERE mothername LIKE @search OR fathername LIKE @search OR lastname LIKE @search OR firstname LIKE @search"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@search", "%" & searchText & "%")

                Try
                    connection.Open()
                    Dim adapter As New MySqlDataAdapter(command)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    DGVSearch.DataSource = table
                Catch ex As MySqlException
                    MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub DGVSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVSearch.CellContentClick
        Dim colname As String = DGVSearch.Columns(e.ColumnIndex).Name
        If colname = "btnEdit" Then
            Dim editForm As New frmNewInfo
            With editForm
                .txtPID.Text = DGVSearch.Rows(e.RowIndex).Cells("pid").Value.ToString()
                .txtLname.Text = DGVSearch.Rows(e.RowIndex).Cells("lastname").Value.ToString()
                .txtFname.Text = DGVSearch.Rows(e.RowIndex).Cells("firstname").Value.ToString()
                .txtMI.Text = DGVSearch.Rows(e.RowIndex).Cells("middleinitial").Value.ToString()
                .txtSuffix.Text = DGVSearch.Rows(e.RowIndex).Cells("suffix").Value.ToString()
                .cmbSex.Text = DGVSearch.Rows(e.RowIndex).Cells("gender").Value.ToString()
                .dtpBirthDate.Value = Convert.ToDateTime(DGVSearch.Rows(e.RowIndex).Cells("dateofbirth").Value)
                .txtMother.Text = DGVSearch.Rows(e.RowIndex).Cells("mothername").Value.ToString()
                .txtFather.Text = DGVSearch.Rows(e.RowIndex).Cells("fathername").Value.ToString()
                .txtAddress.Text = DGVSearch.Rows(e.RowIndex).Cells("address").Value.ToString()
                .btnSave.Enabled = False
                .btnUpdate.Enabled = True ' Enable the Update button for editing
                editForm.ShowDialog()

            End With
        ElseIf colname = "btnDelete" Then
            Dim pid As Integer = CInt(DGVSearch.Rows(e.RowIndex).Cells("pid").Value)

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
                    RefreshDataGrid()

                Catch ex As Exception
                    MessageBox.Show("An error occurred while deleting the data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If

    End Sub

    Public Sub RefreshDataGrid(Optional ByVal pid As Integer? = Nothing)
        Dim query As String

        If pid.HasValue Then
            query = "SELECT pid, lastname, firstname, middleinitial, suffix, gender, dateofbirth, mothername, fathername, address " &
                    "FROM information WHERE pid = @pid"
        Else
            query = "SELECT pid, lastname, firstname, middleinitial, suffix, gender, dateofbirth, mothername, fathername, address FROM information"
        End If

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                If pid.HasValue Then
                    command.Parameters.AddWithValue("@pid", pid.Value)
                End If

                Try
                    connection.Open()
                    Dim adapter As New MySqlDataAdapter(command)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    DGVSearch.DataSource = table
                Catch ex As MySqlException
                    MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub


End Class
