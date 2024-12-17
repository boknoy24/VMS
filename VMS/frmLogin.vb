﻿Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SQLite

Public Class frmLogin
    Private connectionString As String = "Data Source=vms.db;Version=3;"


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text


        If ValidateLogin(username, password) Then
            MessageBox.Show("Login successful!")
            frmMain.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid username or password!")
        End If
    End Sub

    Private Function ValidateLogin(username As String, password As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()

            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)
                Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return result = 1
            End Using
        End Using
    End Function
End Class