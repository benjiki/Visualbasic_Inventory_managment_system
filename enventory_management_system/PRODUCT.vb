Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx

Public Class PRODUCT


    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

    Dim conns As New MySqlConnection(connString)
    Public Sub populate()

        conns.Open()
        Dim sql = "select * from product_table"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        product_data_view.DataSource = ds.Tables(0)
        conns.Close()

    End Sub

    Public Sub fillcatagory()
        conns.Open()
        Dim sql = "select * from catagory_table"
        Dim cmd As New MySqlCommand(sql, conns)
        Dim adaptor As New MySqlDataAdapter(cmd)
        Dim tbl As New DataTable()
        adaptor.Fill(tbl)
        product_catagory.DataSource = tbl
        product_catagory.DisplayMember = "catagory_name"
        product_catagory.ValueMember = "catagory_name"
        conns.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn = New MySqlConnection
        conn.ConnectionString = "server=127.0.0.1;userid=root;password='';database=inventory_system"

        Try
            conn.Open()
            MessageBox.Show("Connection to MySQL test database was successful!!!!", "TESTING      CONNECTION TO MySQL DATABASE")
            Dim query As String
            query = "insert into product_table values (" & product_id.Text & ",'" & product_name.Text & "'," & product_quantity.Text & "," & product_price.Text & ",'" & product_description.Text & "','" & product_catagory.SelectedValue.ToString() & "')"
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand(query, conn)
            cmd.ExecuteNonQuery()
            MsgBox("product_added_sucessfully.")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        populate()
    End Sub

    Private Sub PRODUCT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
        fillcatagory()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim command As New MySqlCommand("DELETE FROM `product_table` WHERE `product_id` = @id", conns)

        command.Parameters.Add("@id", MySqlDbType.Int64).Value = product_id.Text

        conns.Open()

        Try

            If command.ExecuteNonQuery() = 1 Then

                MessageBox.Show("the product has been removed ")

            Else

                MessageBox.Show("Error")

            End If

        Catch ex As Exception

            MessageBox.Show("Something Wrong")

        End Try

        conns.Close()
        populate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        product_id.Text = ""
        product_name.Text = ""
        product_price.Text = ""
        product_quantity.Text = ""
        product_description.Text = ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If product_id.Text = "" Or product_name.Text = "" Or product_quantity.Text = "" Or product_price.Text = "" Or product_description.Text = "" Then
            MsgBox("incomplete data.")
        Else
            conns.Open()
            Dim sql = "update product_table set product_name='" & product_name.Text & "',product_qty= " & product_quantity.Text & ",product_price=" & product_price.Text & ",product_desc='" & product_description.Text & "',product_cat='" & product_catagory.SelectedValue.ToString() & "' where product_id = " & product_id.Text & " "
            Dim cmd As New MySqlCommand(sql, conns)
            cmd.ExecuteNonQuery()
            MsgBox("the product has been edited")
            conns.Close()
            populate()
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        CUSTOMER.Show()
        Me.Hide()
    End Sub

    Private Sub OrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderToolStripMenuItem.Click
        ORDER.Show()
        Me.Hide()
    End Sub

    Private Sub CatagoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatagoryToolStripMenuItem.Click
        CATAGORY.Show()
        Me.Hide()

    End Sub

    Public Sub ByidToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ByidToolStripMenuItem.Click
        product_search_byid()

    End Sub


    Public Sub product_search_byid()
        Dim id As String
        id = InputBox("PLEASE ENTER THE PRODUCT ID ")

        Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

        Dim conns As New MySqlConnection(connString)
        conns.Open()
        Dim sql = "select * from product_table where product_id like '%" & id & "%'"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        product_data_view.DataSource = ds.Tables(0)
        conns.Close()
    End Sub
    Public Sub product_search_byname()
        Dim id As String
        id = InputBox("PLEASE ENTER THE PRODUCT NAME ")

        Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

        Dim conns As New MySqlConnection(connString)
        conns.Open()
        Dim sql = "select * from product_table where product_name like '%" & id & "%'"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        product_data_view.DataSource = ds.Tables(0)
        conns.Close()
    End Sub

    Private Sub BynameToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BynameToolStripMenuItem1.Click
        product_search_byname()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        populate()
        fillcatagory()
    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        USER.Show()
        Me.Hide()
    End Sub

    Private Sub LogoutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub HomepageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomepageToolStripMenuItem.Click
        HOME_PAGE.Show()
        Me.Hide()

    End Sub
End Class