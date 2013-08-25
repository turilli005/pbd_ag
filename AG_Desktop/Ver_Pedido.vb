Imports System.Data.SqlClient

Public Class Ver_Pedido

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        Dim traje As String

        If ListView1.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione solo una inclusión para ver")
        Else

        End If

    End Sub

    Private Sub Ver_Pedido_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Mantener_Pedidos.Show()

    End Sub

    Private Sub Ver_Pedido_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim col1 As New Windows.Forms.ColumnHeader
        Dim col2 As New Windows.Forms.ColumnHeader
        Dim col3 As New Windows.Forms.ColumnHeader
        Dim col4 As New Windows.Forms.ColumnHeader
        Dim col5 As New Windows.Forms.ColumnHeader

        col1.Text = "Diseño"
        col2.Text = "Nombre"
        col3.Text = "Cantidad"
        col4.Text = "Color"
        col5.Text = "Detalles"

        col1.Width = 80
        col2.Width = 130
        col3.Width = 80
        col4.Width = 130
        col5.Width = 250

        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)
        ListView1.Columns.Add(col4)
        ListView1.Columns.Add(col5)

        Dim col11 As New Windows.Forms.ColumnHeader
        Dim col21 As New Windows.Forms.ColumnHeader
        Dim col31 As New Windows.Forms.ColumnHeader
        Dim col41 As New Windows.Forms.ColumnHeader
        Dim col51 As New Windows.Forms.ColumnHeader

        col11.Text = "Estado"
        col21.Text = "Fecha"
        

        col11.Width = 100
        col21.Width = 130
       

        ListView2.Columns.Add(col11)
        ListView2.Columns.Add(col21)
        ' ListView2.Columns.Add(col31)
        ' ListView2.Columns.Add(col41)
        ' ListView2.Columns.Add(col51)

        'columnas historial
       


        Dim pedido As String = TextBox1.Text

        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * from inclusion where id_os = '" & pedido & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            'MsgBox(dt.Rows.Count)

            Dim item As New ListViewItem()
            For i = 0 To dt.Rows.Count - 1

                item = New ListViewItem(dt.Rows(i).Item("id_diseno").ToString.Trim)
                Dim c1 As String = "select * from diseno where id_diseno = '" & dt.Rows(i).Item("id_diseno").ToString.Trim & "'"
                cmd = New SqlCommand(c1, cnn)
                cmd.CommandType = CommandType.Text
                da = New SqlDataAdapter(cmd)
                Dim dt1 = New DataTable
                da.Fill(dt1)

                item.SubItems.Add(dt1.Rows(0).Item("nombre_diseno").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("cantidad").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("color").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("detalles_adicionales").ToString.Trim)

                ListView1.Items.Add(item)

            Next


        End Using

        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * from historial_de_avance where id_os = '" & pedido & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            Dim item As New ListViewItem()

            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(estado(dt.Rows(i).Item("id_estado").ToString.Trim))
                item.SubItems.Add(dt.Rows(i).Item("fecha_de_avance").ToString.Trim)
                ListView2.Items.Add(item)


            Next
        End Using


    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count <> 1 Then
        Else
            TextBox12.Text = ListView1.SelectedItems(0).SubItems(0).Text
            TextBox8.Text = ListView1.SelectedItems(0).SubItems(1).Text
            TextBox16.Text = ListView1.SelectedItems(0).SubItems(2).Text
            TextBox15.Text = ListView1.SelectedItems(0).SubItems(3).Text
            TextBox14.Text = ListView1.SelectedItems(0).SubItems(4).Text

            Using cnn As New SqlConnection(enlace)
                cnn.Open()
                Dim c As String = "Select * from diseno where id_diseno = '" & ListView1.SelectedItems(0).SubItems(0).Text & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

              
                TextBox9.Text = dt.Rows(0).Item("Genero_diseno").ToString.Trim
                TextBox10.Text = dt.Rows(0).Item("tallaje").ToString.Trim
                TextBox7.Text = dt.Rows(0).Item("descripcion_diseno").ToString.Trim
                TextBox6.Text = dt.Rows(0).Item("descripcion_tallaje").ToString.Trim


            End Using
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Hide()


        ver_un_informe.TextBox1.Text = TextBox1.Text

        ver_un_informe.Show()


    End Sub
End Class