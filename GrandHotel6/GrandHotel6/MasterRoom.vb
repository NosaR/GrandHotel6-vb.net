Imports System.Data.SqlClient
Public Class MasterRoom
    'Database
    Dim conn As New SqlConnection("Data source=DESKTOP-I9HFBOF\SQLEXPRESS; Initial catalog=db_grand_hotel; Integrated security=true")
    Dim key = 0

    'Main Method
    Sub MainEnabled()
        TextBox1.Enabled = False
        ComboBox1.Enabled = False
        TextBox3.Enabled = False
        TextBox2.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = False
    End Sub

    'Insert Method
    Sub InsertEnabled()
        TextBox1.Enabled = True
        ComboBox1.Enabled = True
        TextBox3.Enabled = True
        TextBox2.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True
    End Sub

    'Updated Method
    Sub UpdateEnabled()
        TextBox1.Enabled = True
        ComboBox1.Enabled = True
        TextBox3.Enabled = True
        TextBox2.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True
    End Sub

    'Display Data Method
    Sub DisplayData()
        conn.Open()
        Dim data = "Select * from Room"
        Dim adapter As SqlDataAdapter
        Dim cmd As New SqlCommand(data, conn)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
    End Sub

    'Posisi Default
    Private Sub MasterRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainEnabled()
        DisplayData()
    End Sub

    'Tombol Insert
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InsertEnabled()
    End Sub

    'Tombol Cancel
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        ComboBox1.SelectedIndex = -1
        TextBox3.Clear()
        TextBox2.Clear()
        MainEnabled()
    End Sub

    'Tombol Save
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Ketika dalam Kondisi Tombol Insert Diklik
        If Button1.Enabled Then
            If TextBox1.Text = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Data Tidak Boleh Kosong")

            Else
                conn.Open()
                Dim data = "Insert into Room values ('" & TextBox1.Text & "', '" & ComboBox1.Text & "', '" & TextBox3.Text & "', '" & TextBox2.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(data, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Disimpan")
                conn.Close()
                DisplayData()
            End If
        End If

        'Ketika dalam Kondisi Tombol Update Diklik
        If Button2.Enabled Then
            If TextBox1.Text = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Silahkan Pilih Data yang akan Diupdate")

            Else
                conn.Open()
                Dim data = "Update Room Set RoomNumber='" & TextBox1.Text & "',RoomTypeID='" & ComboBox1.Text & "',RoomFloor='" & TextBox3.Text & "', Description= " & TextBox2.Text & " where ID= " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(data, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Disimpan")
                conn.Close()
                DisplayData()
            End If
        End If
    End Sub

    'Tombol Delete
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If key = 0 Then
            MsgBox("Silahkan Pilih Data yang akan Dihapus")

        Else
            conn.Open()
            Dim data = "Delete from Room where ID = " & key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(data, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil Dihapus")
            conn.Close()
            DisplayData()
        End If
    End Sub

    'Ketika Tabel Data Diklik
    'Akan Berfungsi hanya ketika nama Diklik
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        TextBox1.Text = row.Cells(1).Value.ToString
        ComboBox1.Text = row.Cells(2).Value.ToString
        TextBox3.Text = row.Cells(3).Value.ToString
        TextBox2.Text = row.Cells(4).Value.ToString

        If TextBox1.Text = "" Then
            key = 0

        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    'Tombol Upda
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UpdateEnabled()
    End Sub
End Class