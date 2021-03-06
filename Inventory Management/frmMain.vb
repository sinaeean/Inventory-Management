﻿Imports MySql.Data.MySqlClient
Public Class frmMain
    Public Property cmd As MySqlCommand
    Public Property dr As MySqlDataReader
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If Me.Text = "frmMain" Then
        '    Me.BackColor = Color.Transparent
        'End If
        lvMain.Columns.Add("ID", 50)
        lvMain.Columns.Add("Product Name", 80)
        lvMain.Columns.Add("Category", 80)
        lvMain.Columns.Add("Price", 50)
    End Sub
    Private Sub tsRegistration_Click(sender As Object, e As EventArgs) Handles tsRegistration.Click
        frmRegistration.Show()
        Me.Hide()
    End Sub
    Sub ProductLV()
        '  Dim sql As String
        Dim publictable As New DataTable
        ConnectDB() 'Call Function Connection
        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "SELECT c.*,p.* from tbl_category as c inner join tbl_product as p on c.ct_id=p.ct_id"
            cmd = New MySqlCommand(Query, MysqlConn)
            dr = cmd.ExecuteReader
            Dim list As ListViewItem
            Do While dr.Read = True
                list = New ListViewItem(dr("pd_id").ToString)
                list.SubItems.Add(dr("pd_name"))
                list.SubItems.Add(dr("ct_name"))
                list.SubItems.Add(Format(dr("price"), "Currency"))
                lvMain.Items.Add(list)
            Loop
            MysqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub
    Private Sub tsOrder_Click(sender As Object, e As EventArgs) Handles tsOrder.Click
        lvMain.Columns.Clear()
        lvMain.Items.Clear()
        lvMain.Columns.Add("Order ID", 50)
        lvMain.Columns.Add("Product Name", 80)
        lvMain.Columns.Add("Category", 80)
        lvMain.Columns.Add("Price", 50)
        ProductLV()
    End Sub
    Private Sub tsProduct_Click(sender As Object, e As EventArgs) Handles tsProduct.Click
        lvMain.Columns.Clear()
        lvMain.Items.Clear()
        lvMain.Columns.Add("ID", 50)
        lvMain.Columns.Add("Product Name", 80)
        lvMain.Columns.Add("Category", 80)
        lvMain.Columns.Add("Price", 50)
        ProductLV()
    End Sub

End Class