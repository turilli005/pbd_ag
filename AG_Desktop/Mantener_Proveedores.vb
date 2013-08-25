Imports System.Data.SqlClient

Public Class Mantener_Proveedores

    Private Sub Mantener_Proveedores_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Inicio_Administrador.Show()
    End Sub

    Private Sub Mantener_Proveedores_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        Dim col1 As New Windows.Forms.ColumnHeader
        Dim col2 As New Windows.Forms.ColumnHeader
        Dim col3 As New Windows.Forms.ColumnHeader
        Dim col4 As New Windows.Forms.ColumnHeader
        Dim col5 As New Windows.Forms.ColumnHeader
        Dim col6 As New Windows.Forms.ColumnHeader
        Dim col7 As New Windows.Forms.ColumnHeader
        Dim col8 As New Windows.Forms.ColumnHeader

        col1.Text = "Rut"
        col2.Text = "Nombre"
        col3.Text = "Correo"
        col4.Text = "Teléfono"
        col5.Text = "Ciudad"
        col6.Text = "Región"
        col7.Text = "Dirección"
        col8.Text = "Información"

        col1.Width = 100
        col2.Width = 120
        col3.Width = 140
        col4.Width = 100
        col5.Width = 100
        col6.Width = 70
        col7.Width = 300

        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)
        ListView1.Columns.Add(col4)
        ListView1.Columns.Add(col5)
        ListView1.Columns.Add(col6)
        ListView1.Columns.Add(col7)
        ListView1.Columns.Add(col8)

        'btnVer.Enabled = False



        Dim col11 As New Windows.Forms.ColumnHeader
        Dim col12 As New Windows.Forms.ColumnHeader
        Dim col13 As New Windows.Forms.ColumnHeader
        Dim col14 As New Windows.Forms.ColumnHeader
        Dim col15 As New Windows.Forms.ColumnHeader
        Dim col16 As New Windows.Forms.ColumnHeader
        Dim col17 As New Windows.Forms.ColumnHeader
        Dim col18 As New Windows.Forms.ColumnHeader

        col11.Text = "Id Material"
        col12.Text = "Nombre"
        col13.Text = "Unidad medida"
        col14.Text = "Cantidad"
       

        col11.Width = 100
        col12.Width = 90
        col13.Width = 250
        col14.Width = 100
       

        ' ListView2.Columns.Add(col11)
        ' ListView2.Columns.Add(col12)
        ' ListView2.Columns.Add(col13)
        ' ListView2.Columns.Add(col14)
        ' ListView2.Columns.Add(col15)
        ' ListView2.Columns.Add(col16)
        'ListView2.Columns.Add(col17)
        ' ListView2.Columns.Add(col18)
        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * From Proveedor where informacion_adicional <> '0'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            ' Dim dt As New DataTable
            Dim dt As New DataTable
            da.Fill(dt)

            Dim item As New ListViewItem
            For i = 0 To dt.Rows.Count - 1


                Dim c1 As String = "Select * from persona where rut = '" & dt.Rows(i).Item("rut") & "'"
                cmd = New SqlCommand(c1, cnn)
                cmd.CommandType = CommandType.Text
                da = New SqlDataAdapter(cmd)
                Dim dt1 As New DataTable
                da.Fill(dt1)

                item = New ListViewItem(dt.Rows(i).Item("RUT").ToString)
                item.SubItems.Add(dt1.Rows(0).Item("Nombre").ToString)
                item.SubItems.Add(dt1.Rows(0).Item("MAIL").ToString)
                item.SubItems.Add(dt1.Rows(0).Item("TELEFONO").ToString)
                item.SubItems.Add(dt1.Rows(0).Item("DIRECCION").ToString)
                item.SubItems.Add(dt1.Rows(0).Item("CIUDAD").ToString)
                item.SubItems.Add(dt1.Rows(0).Item("REGION").ToString)

                item.SubItems.Add(dt.Rows(i).Item("informacion_adicional").ToString)

                ListView1.Items.Add(item)




            Next

        End Using

    End Sub

    Private Sub btnCrear_Click(sender As System.Object, e As System.EventArgs) Handles btnCrear.Click
        Me.Hide()
        Crear_Proveedor.Show()

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If ListView1.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione un Proveedor para eliminar")
        Else
            Dim Box As MsgBoxResult = MsgBox("Está seguro de eliminar el proveedor: " & ListView1.SelectedItems(0).SubItems(1).Text & "?", MsgBoxStyle.YesNo)
            If Box = MsgBoxResult.Yes Then
                'borrar
                Dim sqlConnection1 As New SqlConnection(enlace)
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                cmd.CommandText = "UPDATE Proveedor SET informacion_adicional='0'  WHERE rut = '" & ListView1.SelectedItems(0).SubItems(0).Text & "'"
                cmd.Connection = sqlConnection1
                'MsgBox("UPDATE Usuario SET nombre='" & TextBox1.Text.Trim & "', mail='" & TextBox2.Text.Trim & "', fono='" & TextBox3.Text.Trim & "', cargo = '" & cargo(ComboBox1.Text.Trim) & "' WHERE username = '" & TextBox4.Text.Trim & "'")
                sqlConnection1.Open()

                Try
                    cmd.ExecuteNonQuery()
                    MsgBox("Proveedor eliminado correctamente.")

                Catch ex As Exception
                    MsgBox("Error en la actualización de los datos")

                End Try
                sqlConnection1.Close()
            Else

            End If
            Using cnn As New SqlConnection(enlace)

                cnn.Open()
                Dim c As String = "Select * From proveedor where informacion_adicional <> '0'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                ' Dim dt As New DataTable
                Dim dt As New DataTable
                da.Fill(dt)
                ListView1.Items.Clear()

                Dim item As New ListViewItem
                For i = 0 To dt.Rows.Count - 1


                    Dim c1 As String = "Select * from persona where rut = '" & dt.Rows(i).Item("rut") & "'"
                    cmd = New SqlCommand(c1, cnn)
                    cmd.CommandType = CommandType.Text
                    da = New SqlDataAdapter(cmd)
                    Dim dt1 As New DataTable
                    da.Fill(dt1)

                    item = New ListViewItem(dt.Rows(i).Item("RUT").ToString)
                    item.SubItems.Add(dt1.Rows(0).Item("Nombre").ToString)
                    item.SubItems.Add(dt1.Rows(0).Item("MAIL").ToString)
                    item.SubItems.Add(dt1.Rows(0).Item("TELEFONO").ToString)
                    item.SubItems.Add(dt1.Rows(0).Item("DIRECCION").ToString)
                    item.SubItems.Add(dt1.Rows(0).Item("CIUDAD").ToString)
                    item.SubItems.Add(dt1.Rows(0).Item("REGION").ToString)

                    item.SubItems.Add(dt.Rows(i).Item("informacion_adicional").ToString)

                    ListView1.Items.Add(item)
                Next

            End Using

        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class