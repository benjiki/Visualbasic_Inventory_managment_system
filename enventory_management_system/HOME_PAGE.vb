Public Class HOME_PAGE
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        CUSTOMER.Show()
        Me.Close()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        CATAGORY.Show()
        Me.Close()


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        USER.Show()
        Me.Close()

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        PRODUCT.Show()
        Me.Close()


    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        ORDER.Show()
        Me.Close()

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub HOME_PAGE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        product_load()
        users_load()
        order_load()
        customer_load()
        catagories_load()

    End Sub


    Public Sub product_load()
        Dim getdata As New for_the_home_page
        Dim product_number As Single
        product_number = getdata.get_product_number()
        product1.Text = product_number
    End Sub

    Public Sub users_load()
        Dim getuser As New for_the_home_page
        Dim user_number As Single
        user_number = getuser.get_user_number()
        users1.Text = user_number
    End Sub
    Public Sub order_load()
        Dim getuser As New for_the_home_page
        Dim order_number As Single
        order_number = getuser.get_order_number()
        order1.Text = order_number
    End Sub

    Public Sub customer_load()
        Dim getuser As New for_the_home_page
        Dim customer_number As Single
        customer_number = getuser.get_customer_number()
        customer1.Text = customer_number
    End Sub
    Public Sub catagories_load()
        Dim getuser As New for_the_home_page
        Dim catagories_number As Single
        catagories_number = getuser.get_catagories_number()
        catagories1.Text = catagories_number
    End Sub


End Class