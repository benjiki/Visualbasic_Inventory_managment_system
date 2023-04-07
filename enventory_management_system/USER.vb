Imports MySql.Data.MySqlClient

Public Class USER

    Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

    Dim conns As New MySqlConnection(connString)


    Public Sub populate()

        conns.Open()
        Dim sql = "select * from user_table"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        user_data_view.DataSource = ds.Tables(0)
        conns.Close()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conns.Open()
            MessageBox.Show("Connection to MySQL test database was successful!!!!", "TESTING      CONNECTION TO MySQL DATABASE")
            Dim query As String
            query = "insert into user_table values (" & user_id.Text & ",'" & user_name.Text & "','" & user_phone.Text & "','" & password.Text & "')"
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand(query, conns)
            cmd.ExecuteNonQuery()
            MsgBox("user_added_sucessfully.")
            conns.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conns.Close()

        End Try

        populate()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim command As New MySqlCommand("DELETE FROM `user_table` WHERE `user_id` = @id", conns)

        command.Parameters.Add("@id", MySqlDbType.Int64).Value = user_id.Text

        conns.Open()

        Try

            If command.ExecuteNonQuery() = 1 Then

                MessageBox.Show("the user has been removed ")

            Else

                MessageBox.Show("Error")

            End If

        Catch ex As Exception

            MessageBox.Show("Something Wrong")

        End Try

        conns.Close()
        populate()

    End Sub

    Private Sub USER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If user_id.Text = "" Or user_name.Text = "" Or user_phone.Text = "" Then
            MsgBox("incomplete data.")
        Else
            conns.Open()
            Dim sql = "update user_table set user_name='" & user_name.Text & "', user_phone='" & user_phone.Text & "' ,user_password='" & password.Text & "' where user_id = " & user_id.Text & " "
            Dim cmd As New MySqlCommand(sql, conns)
            cmd.ExecuteNonQuery()
            MsgBox("the user has been edited")
            conns.Close()
            populate()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        user_id.Text = ""
        user_name.Text = ""
        user_phone.Text = ""

    End Sub

    Private Sub OrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderToolStripMenuItem.Click
        ORDER.Show()
        Me.Hide()
    End Sub

    Private Sub CatagoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatagoryToolStripMenuItem.Click
        CATAGORY.Show()
        Me.Hide()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        CUSTOMER.Show()
        Me.Hide()
    End Sub

    Private Sub ProductsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem1.Click
        PRODUCT.Show()
        Me.Hide()
    End Sub

    Private Sub LogoutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub ByidnoToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ByidnoToolStripMenuItem3.Click
        user_search_byid()

    End Sub
    Public Sub user_search_byid()
        Dim id As String
        id = InputBox("PLEASE ENTER THE USER ID ")

        Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

        Dim conns As New MySqlConnection(connString)
        conns.Open()
        Dim sql = "select * from user_table where user_id like '%" & id & "%'"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        user_data_view.DataSource = ds.Tables(0)
        conns.Close()
    End Sub
    Public Sub user_search_byname()
        Dim id As String
        id = InputBox("PLEASE ENTER THE USER NAME ")

        Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

        Dim conns As New MySqlConnection(connString)
        conns.Open()
        Dim sql = "select * from user_table where user_name like '%" & id & "%'"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        user_data_view.DataSource = ds.Tables(0)
        conns.Close()
    End Sub

    Private Sub BynameToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles BynameToolStripMenuItem3.Click
        user_search_byname()

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        populate()
    End Sub

    Private Sub HomepageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomepageToolStripMenuItem.Click
        HOME_PAGE.Show()
        Me.Hide()

    End Sub

    Private Sub ABOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABOUTToolStripMenuItem.Click
        about.Show()

    End Sub
End Class