Imports System.Data.SQLite
Public Class frmVaccine
    Private connectionString As String = "Data Source=vms.db;Version=3;"
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
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT pid, age_years, age_months, height AS column_height, weight, vaccine_name, dosage_per_vaccine, doses FROM vaccine_info"

                Using adapter As New SQLiteDataAdapter(query, connection)
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
End Class