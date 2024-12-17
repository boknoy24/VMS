Imports System.Data.SQLite
Public Class frmNewInfo
    Private connectionString As String = "Data Source=vms.db;Version=3;"
    Private Sub cmbSex_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbSex.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lastname As String = txtLname.Text.Trim()
        Dim firstname As String = txtFname.Text.Trim()
        Dim middleinitial As String = txtMI.Text.Trim()
        Dim suffix As String = txtSuffix.Text.Trim()
        Dim gender As String = cmbSex.Text.Trim()
        Dim dateofbirth As String = dtpBirthDate.Value.ToString("yyyy-MM-dd")
        Dim mothername As String = txtMother.Text.Trim()
        Dim fathername As String = txtFather.Text.Trim()
        Dim address As String = txtAddress.Text.Trim()
        If String.IsNullOrEmpty(lastname) Then
            MessageBox.Show("Please enter the Last Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLname.Focus()
            Return
        End If

        If String.IsNullOrEmpty(firstname) Then
            MessageBox.Show("Please enter the First Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFname.Focus()
            Return
        End If

        If String.IsNullOrEmpty(gender) Then
            MessageBox.Show("Please select the Gender.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbSex.Focus()
            Return
        End If

        If String.IsNullOrEmpty(dateofbirth) Then
            MessageBox.Show("Please select the Birth Date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpBirthDate.Focus()
            Return
        End If

        If String.IsNullOrEmpty(mothername) Then
            MessageBox.Show("Please enter the Mother's Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMother.Focus()
            Return
        End If

        If String.IsNullOrEmpty(fathername) Then
            MessageBox.Show("Please enter the Father's Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFather.Focus()
            Return
        End If

        If String.IsNullOrEmpty(address) Then
            MessageBox.Show("Please enter the Address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAddress.Focus()
            Return
        End If

        Try
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO information (lastname, firstname, middleinitial, suffix, gender, dateofbirth, mothername, fathername, address) " &
                                      "VALUES (@lastname, @firstname, @middleinitial, @suffix, @gender, @dateofbirth, @mothername, @fathername, @address)"

                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@lastname", lastname)
                    command.Parameters.AddWithValue("@firstname", firstname)
                    command.Parameters.AddWithValue("@middleinitial", middleinitial)
                    command.Parameters.AddWithValue("@suffix", suffix)
                    command.Parameters.AddWithValue("@gender", gender)
                    command.Parameters.AddWithValue("@dateofbirth", dateofbirth)
                    command.Parameters.AddWithValue("@mothername", mothername)
                    command.Parameters.AddWithValue("@fathername", fathername)
                    command.Parameters.AddWithValue("@address", address)

                    command.ExecuteNonQuery()
                End Using

                MessageBox.Show("Information saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmChildInfo.RefreshDataGrid()
                Me.Close()

            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class