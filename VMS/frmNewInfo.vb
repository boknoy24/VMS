
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1.X509

Public Class frmNewInfo
    Private connectionString As String = "Server=localhost;Database=vms;Uid=root;Pwd=;"

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
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO information (lastname, firstname, middleinitial, suffix, gender, dateofbirth, mothername, fathername, address) " &
                                      "VALUES (@lastname, @firstname, @middleinitial, @suffix, @gender, @dateofbirth, @mothername, @fathername, @address)"

                Using command As New MySqlCommand(query, connection)
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If Not ValidateInput() Then Return

        Try
            If MsgBox("Update record?", vbYesNo + vbQuestion) = vbYes Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "UPDATE information SET " &
                                      "lastname = @lastname, " &
                                      "firstname = @firstname, " &
                                      "middleinitial = @middleinitial, " &
                                      "suffix = @suffix, " &
                                      "gender = @gender, " &
                                      "dateofbirth = @dateofbirth, " &
                                      "mothername = @mothername, " &
                                      "fathername = @fathername, " &
                                      "address = @address " &
                                      "WHERE pid = @pid"

                    Using command As New MySqlCommand(query, connection)
                        command.Parameters.AddWithValue("@pid", txtPID.Text)
                        command.Parameters.AddWithValue("@lastname", txtLname.Text.Trim())
                        command.Parameters.AddWithValue("@firstname", txtFname.Text.Trim())
                        command.Parameters.AddWithValue("@middleinitial", txtMI.Text.Trim())
                        command.Parameters.AddWithValue("@suffix", txtSuffix.Text.Trim())
                        command.Parameters.AddWithValue("@gender", cmbSex.Text.Trim())
                        command.Parameters.AddWithValue("@dateofbirth", dtpBirthDate.Value.ToString("yyyy-MM-dd"))
                        command.Parameters.AddWithValue("@mothername", txtMother.Text.Trim())
                        command.Parameters.AddWithValue("@fathername", txtFather.Text.Trim())
                        command.Parameters.AddWithValue("@address", txtAddress.Text.Trim())
                        command.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Child Information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmSearch.RefreshDataGrid(CInt(txtPID.Text))
                frmNewVac.Clear()
                frmChildInfo.RefreshDataGrid()
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtPID.Text) OrElse Not IsNumeric(txtPID.Text) Then
            MessageBox.Show("Please enter a valid PID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPID.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtLname.Text) Then
            MessageBox.Show("Please enter the Last Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLname.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtFname.Text) Then
            MessageBox.Show("Please enter the First Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFname.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtMI.Text) Then
            MessageBox.Show("Please enter the Middle Initial.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMI.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtSuffix.Text) Then
            MessageBox.Show("Please enter the Suffix.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSuffix.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(cmbSex.Text) Then
            MessageBox.Show("Please select a Gender.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbSex.Focus()
            Return False
        End If
        If dtpBirthDate.Value = Nothing Then
            MessageBox.Show("Please select a Date of Birth.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpBirthDate.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtMother.Text) Then
            MessageBox.Show("Please enter the Mother's Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMother.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtFather.Text) Then
            MessageBox.Show("Please enter the Father's Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFather.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Please enter the Address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAddress.Focus()
            Return False
        End If
        Return True
    End Function

End Class