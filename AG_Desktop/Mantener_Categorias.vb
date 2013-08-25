Imports System.Data.SqlClient

Public Class Mantener_Categorias

    Private Sub Mantener_Categorias_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Inicio_Administrador.Show()

    End Sub

    Private Sub Mantener_Categorias_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim col1 As New Windows.Forms.ColumnHeader
        Dim col2 As New Windows.Forms.ColumnHeader
        Dim col3 As New Windows.Forms.ColumnHeader

        col1.Text = "Id"
        col2.Text = "Nombre"
        col3.Text = "Descripción"

        col2.Width = 120
        col3.Width = 200

        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)

        Dim col11 As New Windows.Forms.ColumnHeader
        Dim col12 As New Windows.Forms.ColumnHeader
        Dim col13 As New Windows.Forms.ColumnHeader

        col11.Text = "Id"
        col12.Text = "Nombre"
        col13.Text = "Descripción"

        col12.Width = 120
        col13.Width = 200

        ListView2.Columns.Add(col11)
        ListView2.Columns.Add(col12)
        ListView2.Columns.Add(col13)

        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * From categoria"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            ' Dim dt As New DataTable
            Dim dt As New DataTable
            da.Fill(dt)
            ListView1.Items.Clear()

            Dim item As New ListViewItem
            For i = 0 To dt.Rows.Count - 1

                item = New ListViewItem(dt.Rows(i).Item("ID_CATEGORIA").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("Nombre_CATEGORIA").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("DESCRIPCION_CATEGORIA").ToString.Trim)
                ListView1.Items.Add(item)
                ComboBox2.Items.Add(dt.Rows(i).Item("ID_CATEGORIA").ToString.Trim & " : " & dt.Rows(i).Item("Nombre_CATEGORIA").ToString.Trim)
            Next

            c = "Select * from diseno"
            cmd = New SqlCommand(c, cnn)
            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)

            For i = 0 To dt.Rows.Count - 1
                ComboBox1.Items.Add(dt.Rows(i).Item("ID_DISENO").ToString.Trim & " : " & dt.Rows(i).Item("Nombre_DISENO").ToString.Trim)
            Next



        End Using

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Crear_categoria.Show()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If ListView1.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione sólo una categoría")
        Else

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione sólo una categoría")
        Else

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim id As String = obtenerID(ComboBox1.Text)

        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * From categorizacion where id_diseno = '" & id & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            ' Dim dt As New DataTable
            Dim dt As New DataTable
            da.Fill(dt)
            ListView2.Items.Clear()

            Dim dt_cat As New DataTable


            Dim item As New ListViewItem
            For i = 0 To dt.Rows.Count - 1

                c = "Select * from categoria where id_categoria = '" & dt.Rows(i).Item("ID_CATEGORIA").ToString.Trim & "'"

                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                da.Fill(dt_cat)




                item = New ListViewItem(dt.Rows(i).Item("ID_CATEGORIA").ToString.Trim)
                item.SubItems.Add(dt_cat.Rows(0).Item("Nombre_CATEGORIA").ToString.Trim)
                item.SubItems.Add(dt_cat.Rows(0).Item("DESCRIPCION_CATEGORIA").ToString.Trim)
                ListView2.Items.Add(item)

            Next
        End Using

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If ListView2.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione sólo una categoría")
        Else

        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If ComboBox2.Text = "" Then
            MsgBox("Seleccione una categoría para agregar")
        Else
            Dim id_cat As String = obtenerID(ComboBox2.Text)

        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'ELIMINAR TODAS LAS CATEGORIZACIONES DEL DISEÑO SELECCIONADO

        'INSERTAR TODAS LAS CATEGORIZACIONES DEL LISTVIEW2


        ListView2.Items.Clear()
        MsgBox("Diseño y Categorías actualizados")


    End Sub
End Class