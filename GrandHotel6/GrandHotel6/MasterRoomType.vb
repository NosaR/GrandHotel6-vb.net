Imports System.Data.SqlClient
Public Class MasterRoomType
    Dim conn As New SqlConnection("data source=DESKTOP-I9HFBOF\SQLEXPRESS;initial catalog=db_grand_hotel;integrated security=true")
    Sub TextBoxDissable()
        TextBox1.Enabled = False
        RichTextBox1.Enabled = False
        TextBox3.Enabled = False
    End Sub

    Sub TextBoxEnable()
        TextBox1.Enabled = True
        RichTextBox1.Enabled = True
        TextBox3.Enabled = True
    End Sub

    Sub InsertButtonEnabled()
        DataGridView1.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True
    End Sub

    Sub MainButtonEnabled()
        DataGridView1.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = False
    End Sub

    Sub UpdateButtonEnabled()
        DataGridView1.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True
    End Sub
    Sub Display()
        conn.Open()
        Dim query = "Select * from RoomType"
        Dim adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, conn)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
    End Sub

    Private Sub MasterRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxDissable()
        MainButtonEnabled()
        Display()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBoxEnable()
        InsertButtonEnabled()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'If conn.State = ConnectionState.Closed Then
        '    conn.Open()
        'End If
        If TextBox1.Text = "" Or RichTextBox1.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Tolong Masukkan Data dengan Benar")
        Else
            Try
                conn.Open()
                Dim query = "Insert into RoomType values('" & TextBox1.Text & "', '" & RichTextBox1.SelectionType & "', '" & TextBox3.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Disimpan")
                conn.Close()
                Display()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox3.Clear()
        TextBoxDissable()
        MainButtonEnabled()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or RichTextBox1.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Tolong Masukkan Data dengan Benar")
        Else
            Try
                conn.Open()
                Dim query = "Insert into RoomType values('" & TextBox1.Text & "', '" & RichTextBox1.SelectionType & "', '" & TextBox3.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Disimpan")
                conn.Close()
                Display()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Dim key = 0
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        TextBox1.Text = row.Cells(1).Value.ToString
        RichTextBox1.SelectionBullet = row.Cells(2).Value.ToString
        TextBox3.Text = row.Cells(3).Value.ToString

        If TextBox1.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBoxEnable()
        UpdateButtonEnabled()
    End Sub
End Class