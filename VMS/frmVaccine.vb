Imports MySql.Data.MySqlClient

Public Class frmVaccine
    Private connectionString As String = "Server=localhost;Database=vms;Uid=root;Pwd=;"

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With frmNewVac
            .btnUpdate.Enabled = False
            .ShowDialog()
        End With
    End Sub

    Private Sub LoadVaccineInfoData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT pid, age_years, age_months, height AS column_height, weight, vaccine_name, dosage_per_vaccine, doses FROM vaccine_info"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    DataGridView1.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmVaccine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadVaccineInfoData()
    End Sub

    Public Sub RefreshVaccineData()
        LoadVaccineInfoData()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colname As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colname = "btnEdit" Then
            With frmNewVac
                .txtPID.Text = DataGridView1.Rows(e.RowIndex).Cells("pid").Value.ToString()
                .txtVaccineName.Text = DataGridView1.Rows(e.RowIndex).Cells("vaccine_name").Value.ToString()
                .txtAgeYear.Text = DataGridView1.Rows(e.RowIndex).Cells("age_years").Value.ToString()
                .txtAgeMonth.Text = DataGridView1.Rows(e.RowIndex).Cells("age_months").Value.ToString()
                .txtHeightRange.Text = DataGridView1.Rows(e.RowIndex).Cells("column_height").Value.ToString()
                .txtWeightRange.Text = DataGridView1.Rows(e.RowIndex).Cells("weight").Value.ToString()
                .txtDosage.Text = DataGridView1.Rows(e.RowIndex).Cells("dosage_per_vaccine").Value.ToString()
                .txtDoses.Text = DataGridView1.Rows(e.RowIndex).Cells("doses").Value.ToString()
                .btnSave.Enabled = False
                .ShowDialog()
            End With
        ElseIf colname = "btnDelete" Then
            Dim pid As Integer = CInt(DataGridView1.Rows(e.RowIndex).Cells("pid").Value)

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this vaccine record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                Try
                    Using connection As New MySqlConnection(connectionString)
                        connection.Open()
                        Dim query As String = "DELETE FROM vaccine_info WHERE pid = @pid"

                        Using command As New MySqlCommand(query, connection)
                            command.Parameters.AddWithValue("@pid", pid)
                            command.ExecuteNonQuery()
                        End Using
                    End Using

                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefreshVaccineData()
                Catch ex As Exception
                    MessageBox.Show("An error occurred while deleting the data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If

    End Sub
End Class
