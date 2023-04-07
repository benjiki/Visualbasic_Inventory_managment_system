Imports MySql.Data.MySqlClient

Public Class CATAGORY
    Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

    Dim conns As New MySqlConnection(connString)

    Public Sub populate()

        conns.Open()
        Dim sql = "select * from catagory_table"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        catagory_data_view.DataSource = ds.Tables(0)
        conns.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conns.Open()
            MessageBox.Show("Connection to MySQL test database was successful!!!!", "TESTING      CONNECTION TO MySQL DATABASE")
            Dim query As String
            query = "insert into catagory_table values (" & catagory_id.Text & ",'" & catagory_name.Text & "')"
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand(query, conns)
            cmd.ExecuteNonQuery()
            MsgBox("catagory_added_sucessfully.")
            conns.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conns.Close()

        End Try
        populate()
    End Sub

    Private Sub CATAGORY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        catagory_id.Text = ""
        catagory_name.Text = ""

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        Dim command As New MySqlCommand("DELETE FROM `catagory_table` WHERE `catagory_id` = @id", conns)

        command.Parameters.Add("@id", MySqlDbType.Int64).Value = catagory_id.Text

        conns.Open()

        Try

            If command.ExecuteNonQuery() = 1 Then

                MessageBox.Show("the catagory has been removed ")

            Else

                MessageBox.Show("Error")

            End If

        Catch ex As Exception

            MessageBox.Show("Something Wrong")

        End Try

        conns.Close()
        populate()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If catagory_id.Text = "" Or catagory_name.Text = "" Then
            MsgBox("incomplete data.")
        Else
            conns.Open()
            Dim sql = "update catagory_table set catagory_name='" & catagory_name.Text & "' where catagory_id = " & catagory_id.Text & " "
            Dim cmd As New MySqlCommand(sql, conns)
            cmd.ExecuteNonQuery()
            MsgBox("the catagory has been edited")
            conns.Close()
            populate()
        End If

    End Sub

    Private Sub OrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderToolStripMenuItem.Click
        ORDER.Show()
        Me.Close()

    End Sub



    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        CUSTOMER.Show()
        Me.Close()

    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        USER.Show()
        Me.Close()

    End Sub


    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        populate()
    End Sub

    Private Sub BynameToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles BynameToolStripMenuItem2.Click
        catagory_search_byname()

    End Sub

    Private Sub ByidnoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ByidnoToolStripMenuItem1.Click
        catagory_search_byid()

    End Sub
    Public Sub catagory_search_byid()
        Dim id As String
        id = InputBox("PLEASE ENTER THE CATAGORY ID ")

        Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

        Dim conns As New MySqlConnection(connString)
        conns.Open()
        Dim sql = "select * from catagory_table where catagory_id like '%" & id & "%'"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        catagory_data_view.DataSource = ds.Tables(0)
        conns.Close()
    End Sub
    Public Sub catagory_search_byname()
        Dim id As String
        id = InputBox("PLEASE ENTER THE CATAGORY NAME ")

        Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

        Dim conns As New MySqlConnection(connString)
        conns.Open()
        Dim sql = "select * from catagory_table where catagory_name like '%" & id & "%'"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        catagory_data_view.DataSource = ds.Tables(0)
        conns.Close()
    End Sub



    Private Sub ProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductToolStripMenuItem.Click
        PRODUCT.Show()
        Me.Close()

    End Sub

    Private Sub LogoutToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem1.Click
        Form1.Show()
        Me.Hide()


    End Sub

    Private Sub HomepageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomepageToolStripMenuItem.Click
        HOME_PAGE.Show()
        Me.Hide()

    End Sub
End Class