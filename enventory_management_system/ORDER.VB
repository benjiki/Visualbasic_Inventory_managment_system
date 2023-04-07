Imports System.Reflection.Metadata.Ecma335
Imports System.Xml.Schema
Imports Google.Protobuf.WellKnownTypes
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Utilities

Public Class ORDER

    Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

    Dim conns As New MySqlConnection(connString)

    Public Sub fillproduct()
        conns.Open()
        Dim sql = "select * from product_table"
        Dim cmd As New MySqlCommand(sql, conns)
        Dim adaptor As New MySqlDataAdapter(cmd)
        Dim tbl As New DataTable()
        adaptor.Fill(tbl)
        product_combo_box.DataSource = tbl
        product_combo_box.DisplayMember = "product_id"
        product_combo_box.ValueMember = "product_id"
        conns.Close()
    End Sub
    Public Sub fillcustomer()
        conns.Open()
        Dim sql = "select * from customer_table"
        Dim cmd As New MySqlCommand(sql, conns)
        Dim adaptor As New MySqlDataAdapter(cmd)
        Dim tbl As New DataTable()
        adaptor.Fill(tbl)
        customer_id.DataSource = tbl
        customer_id.DisplayMember = "customer_id"
        customer_id.ValueMember = "customer_id"
        conns.Close()

    End Sub

    Public Sub populate()

        conns.Open()
        Dim sql = "select * from order_table"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        order_data_view.DataSource = ds.Tables(0)
        conns.Close()

    End Sub
    Public Sub get_name()
        conns.Open()
        Dim sql = " select * from customer_table where customer_id = " & customer_id.SelectedValue.ToString() & "  "
        Dim cmd As New MySqlCommand(sql, conns)
        Dim reader As MySqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            customer_name.Text = reader(1).ToString()

        End While
        conns.Close()

    End Sub
    Dim products_name As String
    Dim product_price As Integer
    Dim avilable_product_quantity As Integer
    Public Sub get_product_data()
        conns.Open()
        Dim sql = " select * from product_table where product_id = " & product_combo_box.SelectedValue.ToString() & "  "
        Dim cmd As New MySqlCommand(sql, conns)
        Dim reader As MySqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read

            'customer_name.Text = reader(1).ToString()
            products_name = reader(1).ToString()
            product_price = Convert.ToUInt32(reader(3).ToString())
            avilable_product_quantity = Convert.ToUInt32(reader(2).ToString())

            product_name.Text = products_name
        End While
        conns.Close()


    End Sub



    Private Sub ORDER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillproduct()
        fillcustomer()
        populate()
    End Sub

    Private Sub customer_id_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles customer_id.SelectionChangeCommitted
        get_name()
    End Sub

    Private Sub product_combo_box_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles product_combo_box.SelectionChangeCommitted
        get_product_data()
    End Sub
    Dim product_quatitiy

    Dim new_quantity
    Private Sub update_product_data()
        new_quantity = avilable_product_quantity - Convert.ToUInt32(quantity.Text)
        conns.Open()
        Dim sql = "update product_table set product_qty= " & product_quatitiy & " where product_id = " & product_combo_box.SelectedItem.ToString() & " "

        Dim cmd As New MySqlCommand(sql, conns)
        cmd.ExecuteNonQuery()
        MsgBox("the product has been edited")
        conns.Close()


    End Sub
    Dim total_amount = 0, i = 0, total = 0

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            conns.Open()
            MessageBox.Show("Connection to MySQL test database was successful!!!!", "TESTING      CONNECTION TO MySQL DATABASE")
            Dim query As String
            query = "insert into order_table values (" & order_id.Text & ", " & customer_id.SelectedValue.ToString() & ",'" & customer_name.Text & "'," & total_amount_display.Text & ")"

            Dim cmd As MySqlCommand
            cmd = New MySqlCommand(query, conns)
            cmd.ExecuteNonQuery()
            MsgBox("order_added_sucessfully.")
            conns.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conns.Close()

        End Try
        populate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If quantity.Text = "" Then
            MsgBox("please enter the quantity ")
        Else
            Dim rnum As Integer = bill_data_view.Rows.Add()

            i = i + 1
            total = product_price * Convert.ToInt32(quantity.Text)
            bill_data_view.Rows.Item(rnum).Cells(0).Value = i
            bill_data_view.Rows.Item(rnum).Cells(1).Value = product_name.Text
            bill_data_view.Rows.Item(rnum).Cells(2).Value = product_price
            bill_data_view.Rows.Item(rnum).Cells(3).Value = quantity.Text
            bill_data_view.Rows.Item(rnum).Cells(4).Value = total
            total_amount = total_amount + total
            total_amount_display.Text = total_amount


        End If
    End Sub

    Private Sub ByidnoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ByidnoToolStripMenuItem2.Click
        order_search_byid()
    End Sub

    Private Sub ByCUstomerordernameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ByCUstomerordernameToolStripMenuItem.Click
        order_search_byname()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        populate()
    End Sub

    Private Sub CatagoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatagoryToolStripMenuItem.Click
        CATAGORY.Show()
        Me.Hide()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        USER.Show()
        Me.Hide()
    End Sub

    Private Sub CstomersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CstomersToolStripMenuItem.Click
        CUSTOMER.Show()
        Me.Hide()
    End Sub

    Private Sub ProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductToolStripMenuItem.Click
        PRODUCT.Show()
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


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim command As New MySqlCommand("DELETE FROM `order_table` WHERE `order_id` = @id", conns)

        command.Parameters.Add("@id", MySqlDbType.Int64).Value = order_id.Text

        conns.Open()

        Try

            If command.ExecuteNonQuery() = 1 Then

                MessageBox.Show("the order has been removed ")

            Else

                MessageBox.Show("Error")

            End If

        Catch ex As Exception

            MessageBox.Show("Something Wrong")

        End Try

        conns.Close()
        populate()



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If order_id.Text = "" Or customer_name.Text = "" Or customer_id.Text = "" Or customer_name.Text = "" Or quantity.Text = "" Or product_name.Text = "" Then

            MsgBox("incomplete data.")
        Else
            conns.Open()

            Dim sql = "update order_table set customer_id=" & customer_id.SelectedValue.ToString() & " ,customer_name='" & customer_name.Text & "', total_amount=" & total_amount_display.Text & "  where order_id = " & order_id.Text & " "
            Dim cmd As New MySqlCommand(sql, conns)
            cmd.ExecuteNonQuery()
            MsgBox("the order has been edited")
            conns.Close()
            populate()
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim index As Integer
        index = bill_data_view.CurrentCell.RowIndex
        bill_data_view.Rows.RemoveAt(index)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        order_id.Text = ""
        customer_name.Text = ""
        product_name.Text = ""
        quantity.Text = ""
    End Sub

    Private Sub customer_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles customer_id.SelectedIndexChanged

    End Sub

    Public Sub order_search_byid()
        Dim id As String
        id = InputBox("PLEASE ENTER THE ORDER ID ")

        Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

        Dim conns As New MySqlConnection(connString)
        conns.Open()
        Dim sql = "select * from order_table where order_id like '%" & id & "%'"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        order_data_view.DataSource = ds.Tables(0)
        conns.Close()
    End Sub
    Public Sub order_search_byname()
        Dim id As String
        id = InputBox("PLEASE ENTER THE ORDER_CUSTOMER NAME ")

        Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

        Dim conns As New MySqlConnection(connString)
        conns.Open()
        Dim sql = "select * from order_table where customer_name like '%" & id & "%'"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adaptor)
        Dim ds As DataSet
        ds = New DataSet
        adaptor.Fill(ds)
        order_data_view.DataSource = ds.Tables(0)
        conns.Close()
    End Sub

End Class