Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Utilities

Public Class for_the_home_page
    Structure get_the_numbers
        Dim number As Integer

    End Structure




    Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

    Dim conns As New MySqlConnection(connString)
    Public Function get_product_number()
        Dim Total As get_the_numbers


        conns.Open()
        Dim sql = "select * from product_table"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim table As New DataTable()
        adaptor.Fill(table)
        If table.Rows.Count = 0 Then

            Total.number = 0


        Else
            Total.number = table.Rows.Count




        End If



        Return Total.number
        conns.Close()
    End Function




    Public Function get_user_number()
        Dim Total As Single
        conns.Open()
        Dim sql = "select * from user_table"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim table As New DataTable()
        adaptor.Fill(table)
        If table.Rows.Count = 0 Then

            Total = 0


        Else
            Total = table.Rows.Count




        End If



        Return Total
        conns.Close()
    End Function


    Public Function get_catagories_number()
        Dim Total As Single
        conns.Open()
        Dim sql = "select * from catagory_table"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim table As New DataTable()
        adaptor.Fill(table)
        If table.Rows.Count = 0 Then

            Total = 0


        Else
            Total = table.Rows.Count




        End If



        Return Total
        conns.Close()
    End Function

    Public Function get_order_number()
        Dim Total As Single
        conns.Open()
        Dim sql = "select * from order_table"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim table As New DataTable()
        adaptor.Fill(table)
        If table.Rows.Count = 0 Then

            Total = 0


        Else
            Total = table.Rows.Count




        End If



        Return Total
        conns.Close()
    End Function

    Public Function get_customer_number()
        Dim Total As Single
        conns.Open()
        Dim sql = "select * from customer_table"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim table As New DataTable()
        adaptor.Fill(table)
        If table.Rows.Count = 0 Then

            Total = 0


        Else
            Total = table.Rows.Count




        End If



        Return Total
        conns.Close()
    End Function


End Class
