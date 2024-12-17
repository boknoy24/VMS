Imports MySql.Data.MySqlClient

Public Class frmNewVac
    Private connectionString As String = "Server=localhost;Database=vms;Uid=root;Pwd=;"

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInput() Then Return

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO vaccine_info (vaccine_name, age_years, age_months, height, weight, dosage_per_vaccine, doses) " &
                                  "VALUES (@vaccine_name, @age_year, @age_month, @height_range, @weight_range, @dosage, @doses)"

                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@vaccine_name", txtVaccineName.Text.Trim())
                    command.Parameters.AddWithValue("@age_year", If(String.IsNullOrEmpty(txtAgeYear.Text), DBNull.Value, CInt(txtAgeYear.Text)))
                    command.Parameters.AddWithValue("@age_month", If(String.IsNullOrEmpty(txtAgeMonth.Text), DBNull.Value, CInt(txtAgeMonth.Text)))
                    command.Parameters.AddWithValue("@height_range", txtHeightRange.Text.Trim())
                    command.Parameters.AddWithValue("@weight_range", txtWeightRange.Text.Trim())
                    command.Parameters.AddWithValue("@dosage", If(String.IsNullOrEmpty(txtDosage.Text), DBNull.Value, CDbl(txtDosage.Text)))
                    command.Parameters.AddWithValue("@doses", If(String.IsNullOrEmpty(txtDoses.Text), DBNull.Value, CInt(txtDoses.Text)))
                    command.ExecuteNonQuery()
                End Using

                MessageBox.Show("Vaccine information saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Clear()
                frmVaccine.RefreshVaccineData()
                Me.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If Not ValidateInput() Then Return

        Try
            If MsgBox("Update record?", vbYesNo + vbQuestion) = vbYes Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "UPDATE vaccine_info SET vaccine_name = @vaccine_name, age_years = @age_year, age_months = @age_month, " &
                                          "height = @height_range, weight = @weight_range, dosage_per_vaccine = @dosage, doses = @doses " &
                                          "WHERE pid = @pid"

                    Using command As New MySqlCommand(query, connection)
                        command.Parameters.AddWithValue("@pid", If(String.IsNullOrEmpty(txtPID.Text), DBNull.Value, CInt(txtPID.Text)))
                        command.Parameters.AddWithValue("@vaccine_name", txtVaccineName.Text.Trim())
                        command.Parameters.AddWithValue("@age_year", If(String.IsNullOrEmpty(txtAgeYear.Text), DBNull.Value, CInt(txtAgeYear.Text)))
                        command.Parameters.AddWithValue("@age_month", If(String.IsNullOrEmpty(txtAgeMonth.Text), DBNull.Value, CInt(txtAgeMonth.Text)))
                        command.Parameters.AddWithValue("@height_range", txtHeightRange.Text.Trim())
                        command.Parameters.AddWithValue("@weight_range", txtWeightRange.Text.Trim())
                        command.Parameters.AddWithValue("@dosage", If(String.IsNullOrEmpty(txtDosage.Text), DBNull.Value, CDbl(txtDosage.Text)))
                        command.Parameters.AddWithValue("@doses", If(String.IsNullOrEmpty(txtDoses.Text), DBNull.Value, CInt(txtDoses.Text)))
                        command.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Vaccine information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Clear()
                    frmVaccine.RefreshVaccineData()
                    Me.Close()

                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtVaccineName.Text) Then
            MessageBox.Show("Please enter the Vaccine Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtVaccineName.Focus()
            Return False
        End If

        If Not IsNumeric(txtAgeYear.Text) Then
            MessageBox.Show("Please enter a valid number for Age (Year).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAgeYear.Focus()
            Return False
        End If

        If Not IsNumeric(txtAgeMonth.Text) Then
            MessageBox.Show("Please enter a valid number for Age (Month).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAgeMonth.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtHeightRange.Text) Then
            MessageBox.Show("Please enter the Height Range.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtHeightRange.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtWeightRange.Text) Then
            MessageBox.Show("Please enter the Weight Range.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWeightRange.Focus()
            Return False
        End If

        If Not IsNumeric(txtDosage.Text) Then
            MessageBox.Show("Please enter a valid number for Dosage Per Vaccine.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDosage.Focus()
            Return False
        End If

        If Not IsNumeric(txtDoses.Text) Then
            MessageBox.Show("Please enter a valid number for Doses.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDoses.Focus()
            Return False
        End If

        Return True
    End Function

    Sub Clear()
        'txtPID.Clear()
        txtVaccineName.Clear()
        txtAgeYear.Clear()
        txtAgeMonth.Clear()
        txtHeightRange.Clear()
        txtWeightRange.Clear()
        txtDosage.Clear()
        txtDoses.Clear()
        btnSave.Enabled = True
        btnUpdate.Enabled = True
    End Sub
End Class
