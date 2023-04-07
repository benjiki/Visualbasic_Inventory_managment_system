Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class Form1
    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

    Dim conns As New MySqlConnection(connString)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        checker_for_the_logger()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        EMP_ID_TB.Text = ""
        PASS_TB.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
    Public Sub checker_for_the_logger()
        Dim name As String
        Dim password As String
        name = EMP_ID_TB.Text
        password = PASS_TB.Text



        Dim connString As String = "server=127.0.0.1;userid=root;password='';database=inventory_system"

        Dim conns As New MySqlConnection(connString)
        conns.Open()
        Dim sql = "select * from user_table where user_name like '%" & name & "%' and user_password like '%" & password & "%'"
        Dim adaptor As MySqlDataAdapter
        adaptor = New MySqlDataAdapter(sql, conns)
        Dim table As New DataTable()
        adaptor.Fill(table)
        If table.Rows.Count = 0 Then

            MessageBox.Show("Invalid Username Or Password")

        Else
            HOME_PAGE.Show()
            Me.Hide()


        End If

        conns.Close()

    End Sub
End Class
