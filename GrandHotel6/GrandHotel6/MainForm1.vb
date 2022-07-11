Imports System.Data.SqlClient
Public Class MainForm1
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Reservation.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        MasterRoom.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        MasterRoomType1.Show()
        Me.Hide()
    End Sub
End Class