Imports System.Data.SqlClient
Public Class LoginForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New SqlConnection("data source=desktop-i9hfbof\sqlexpress;initial catalog=db_grand_hotel;integrated security=true")
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        'Connection()
        Dim cmd As New SqlCommand("Select * from Employee where username=@username and password=@password", conn)
        cmd.Parameters.AddWithValue("username", TextBox1.Text)
        cmd.Parameters.AddWithValue("password", TextBox2.Text)
        Dim myreader As SqlDataReader = cmd.ExecuteReader

        If (myreader.Read()) Then
            username_v = myreader("username")
            MsgBox(username_v + " Telah Berhasil Login")
            If (username_v = "admin") Then
                MasterEmployee.Show()
            ElseIf (username_v = "hk") Then
                CleaningRoom.Show()
            ElseIf (username_v = "hksupervisor") Then
                AddHousekeepingSchedule.Show()
            Else
                MainForm1.Show()
            End If
            Me.Hide()
        Else
            MsgBox("Username dan Password Anda Salah")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False

        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
End Class
