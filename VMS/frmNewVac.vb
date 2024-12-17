Imports System.Data.SQLite
Public Class frmNewVac
    Private connectionString As String = "Data Source=vms.db;Version=3;"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim vaccineName As String = txtVaccineName.Text.Trim()
        Dim ageYear As String = txtAgeYear.Text.Trim()
        Dim ageMonth As String = txtAgeMonth.Text.Trim()
        Dim heightRange As String = txtHeightRange.Text.Trim()
        Dim weightRange As String = txtWeightRange.Text.Trim()
        Dim dosage As String = txtDosage.Text.Trim()
        Dim doses As String = txtDoses.Text.Trim()

        If String.IsNullOrEmpty(vaccineName) Then
            MessageBox.Show("Please enter the Vaccine Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtVaccineName.Focus()
            Return
        End If

        If String.IsNullOrEmpty(ageYear) Then
            MessageBox.Show("Please enter the Recommended Age (Year).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAgeYear.Focus()
            Return
        End If

        If String.IsNullOrEmpty(ageMonth) Then
            MessageBox.Show("Please enter the Recommended Age (Month).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAgeMonth.Focus()
            Return
        End If

        If String.IsNullOrEmpty(heightRange) Then
            MessageBox.Show("Please enter the Height Range.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtHeightRange.Focus()
            Return
        End If

        If String.IsNullOrEmpty(weightRange) Then
            MessageBox.Show("Please enter the Weight Range.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWeightRange.Focus()
            Return
        End If

        If String.IsNullOrEmpty(dosage) Then
            MessageBox.Show("Please enter the Dosage Per Vaccine.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDosage.Focus()
            Return
        End If

        If String.IsNullOrEmpty(doses) Then
            MessageBox.Show("Please enter the Number of Doses.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDoses.Focus()
            Return
        End If
        Try
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO vaccine_info (vaccine_name, recommended_age_year, recommended_age_month, height_range, weight_range, dosage_per_vaccine, doses) " &
                                      "VALUES (@vaccine_name, @age_year, @age_month, @height_range, @weight_range, @dosage, @doses)"

                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@vaccine_name", vaccineName)
                    command.Parameters.AddWithValue("@age_year", If(String.IsNullOrEmpty(ageYear), DBNull.Value, CInt(ageYear)))
                    command.Parameters.AddWithValue("@age_month", If(String.IsNullOrEmpty(ageMonth), DBNull.Value, CInt(ageMonth)))
                    command.Parameters.AddWithValue("@height_range", heightRange)
                    command.Parameters.AddWithValue("@weight_range", weightRange)
                    command.Parameters.AddWithValue("@dosage", If(String.IsNullOrEmpty(dosage), DBNull.Value, CDbl(dosage)))
                    command.Parameters.AddWithValue("@doses", If(String.IsNullOrEmpty(doses), DBNull.Value, CInt(doses)))
                    command.ExecuteNonQuery()
                End Using

                MessageBox.Show("Vaccine information saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                frmVaccine.RefreshVaccineData()
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class