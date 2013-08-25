Imports System.Data.SqlClient

Public Class Mantener_Pedidos2

    Private Sub Mantener_Pedidos2_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Mantener_Pedidos.Show()

    End Sub

    Private Sub Mantener_Pedidos2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim pedido As String = TextBox4.Text


        Dim col1 As New Windows.Forms.ColumnHeader
        Dim col2 As New Windows.Forms.ColumnHeader
        Dim col3 As New Windows.Forms.ColumnHeader
        Dim col4 As New Windows.Forms.ColumnHeader
        Dim col5 As New Windows.Forms.ColumnHeader
        Dim col6 As New Windows.Forms.ColumnHeader
        Dim col7 As New Windows.Forms.ColumnHeader
        Dim col8 As New Windows.Forms.ColumnHeader

        col1.Text = "Diseño"
        col2.Text = "Nombre"
        col3.Text = "Cantidad"
        col4.Text = "Descripción"
        col5.Text = "Género"
        col6.Text = "Tallaje"
        col7.Text = "Color"
        col8.Text = "Detalles"

        col1.Width = 70
        col2.Width = 120
        col3.Width = 70
        col4.Width = 130
        col5.Width = 60
        col6.Width = 60
        col7.Width = 100
        col8.Width = 250

        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)
        ListView1.Columns.Add(col4)
        ListView1.Columns.Add(col5)
        ListView1.Columns.Add(col6)
        ListView1.Columns.Add(col7)
        ListView1.Columns.Add(col8)


        Dim id_os As String = obtenerID(TextBox4.Text)

        Using cnn As New SqlConnection(enlace)
            cnn.Open()

            Dim c As String = "Select * From INCLUSION where id_os = '" & id_os & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            ListView1.Items.Clear()
            Dim dt1 As New DataTable

            Dim item As New ListViewItem
            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("ID_DISENO").ToString.Trim)

                c = "Select * from diseno where id_diseno = '" & dt.Rows(i).Item("ID_DISENO").ToString.Trim & "'"
                cmd = New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                da = New SqlDataAdapter(cmd)
                dt1 = New DataTable

                da.Fill(dt1)


                item.SubItems.Add(dt1.Rows(0).Item("nombre_diseno").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("CANTIDAD").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("descripcion_diseno").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("genero_diseno").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("tallaje").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("COLOR").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("DETALLES_ADICIONALES").ToString.Trim)
                ListView1.Items.Add(item)

            Next

        End Using




    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        'evaluar si pedido es finalizado o cancelado
        'actualizar inclusiones

        'quitar todas las inclusiones y dejar las nuevas
        If ListView1.Items.Count = 0 Then
            Dim Box As MsgBoxResult = MsgBox("Dejará el pedido sin inclusiones. Está seguro?", MsgBoxStyle.YesNo)
            If Box = MsgBoxResult.Yes Then

                Dim rut As String = obtenerNombre(TextBox4.Text)
                Dim INI As String = DateTimePicker1.Value.ToString
                Dim estado1 As String = estado_a_int(ComboBox2.Text)

                Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)

                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                'cmd.CommandText = "INSERT INTO ORDEN_DE_SERVICIO (ID_ESTADO ,RUT,COMENTARIO_OS, FECHA_INICIO) VALUES ('" & estado1 & "' , '" & CType(rut, Integer) & "','" & TextBox1.Text & "','" & INI & "')"
                cmd.CommandText = "UPDATE ORDEN_DE_SERVICIO  SET ID_ESTADO= '" & estado1 & "' ,  " & "COMENTARIO_OS = '" & TextBox1.Text & "', FECHA_INICIO = '" & INI & "' where id_os = '" & obtenerID(TextBox4.Text) & "'"

                cmd.Connection = sqlConnection1
                sqlConnection1.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MsgBox("Orden actualizada exitosamente")
                    Modulo.insertar_auditoria(Modulo.usuario, "ORDEN_DE_SERVICIO", "UPDATE ORDEN_DE_SERVICIO  SET ID_ESTADO", "U", Date.Today, "", "")

                Catch ex As Exception
                    MsgBox("Error en la actualizacion de los datos de la orden")
                End Try
                sqlConnection1.Close()


                cmd = New SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                cmd.CommandText = "INSERT INTO HISTORIAL_DE_AVANCE(ID_OS,ID_ESTADO,FECHA_DE_AVANCE) VALUES ('" & obtenerID(TextBox4.Text) & "','" & estado1 & "','" & Date.Today.ToString & "')"
                cmd.Connection = sqlConnection1
                sqlConnection1.Open()
                Try
                    cmd.ExecuteNonQuery()
                    ' MsgBox("Historial actualizada exitosamente")
                    Modulo.insertar_auditoria(Modulo.usuario, "HISTORIAL_DE_AVANCE", "INSERT INTO HISTORIAL_DE_AVANCE(ID_OS,ID_ESTADO,FECHA_DE_AVANCE) VALUES", "I", Date.Today, "", "")

                Catch ex As Exception
                    MsgBox("Error en el Historial")
                End Try
                sqlConnection1.Close()


            Else

            End If
        Else


            Dim rut As String = obtenerNombre(TextBox4.Text)
            Dim INI As String = DateTimePicker1.Value.ToString
            Dim estado1 As String = estado_a_int(ComboBox2.Text)

            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            'cmd.CommandText = "INSERT INTO ORDEN_DE_SERVICIO (ID_ESTADO ,RUT,COMENTARIO_OS, FECHA_INICIO) VALUES ('" & estado1 & "' , '" & CType(rut, Integer) & "','" & TextBox1.Text & "','" & INI & "')"
            cmd.CommandText = "UPDATE ORDEN_DE_SERVICIO  SET ID_ESTADO= '" & estado1 & "' ,  " & "COMENTARIO_OS = '" & TextBox1.Text & "', FECHA_INICIO = '" & INI & "' where id_os = '" & obtenerID(TextBox4.Text) & "'"
            Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)
            cmd.Connection = sqlConnection1
            sqlConnection1.Open()
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Orden actualizada exitosamente")
                Modulo.insertar_auditoria(Modulo.usuario, "ORDEN_DE_SERVICIO", "UPDATE ORDEN_DE_SERVICIO  SET ID_ESTADO=", "U", Date.Today, "", "")

            Catch ex As Exception
                MsgBox("Error en la actualizacion de los datos de la orden")
            End Try
            sqlConnection1.Close()

            'BORRAR INCLUSIONES
            Using cnn As New SqlConnection(enlace)
                cnn.Open()
                Dim c As String = "Select * from inclusion where id_os = '" & obtenerID(TextBox4.Text) & "'"
                Dim cmd1 As New System.Data.SqlClient.SqlCommand(c, cnn)

                cmd1.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd1)
                Dim dt As New DataTable
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    c = "DELETE FROM INCLUSION Where id_os = '" & obtenerID(TextBox4.Text) & "'"
                    cmd1 = New SqlCommand(c, cnn)
                    cmd1.CommandType = CommandType.Text
                    Try
                        '  cmd1.ExecuteNonQuery()
                        Modulo.insertar_auditoria(Modulo.usuario, "INCLUSION", "DELETE FROM INCLUSION Where id_os", "D", Date.Today, "", "")
                    Catch ex As Exception
                        MsgBox("No es posible borrar la inclusion: " & ListView1.Items(i).SubItems(1).Text)
                        MsgBox(ex.ToString)
                    End Try


                Next

            End Using



            'crear orden e inclusiones
            rut = obtenerNombre(TextBox4.Text)

            estado1 = estado_a_int(ComboBox2.Text)

            'Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)

            cmd =New System.Data.SqlClient.SqlCommand

            Dim id_ORDEN_actual As Integer = obtenerID(TextBox4.Text)
            sqlConnection1.Close()
            'ComboBox1.SelectedItem = Nothing
            ComboBox2.SelectedItem = Nothing
            'TextBox1.Clear()

            Dim insercion_inclusiones As Boolean = True
            Dim id_diseno, cantidad, color, detalles As String

            For i = 0 To ListView1.Items.Count - 1
                ' MsgBox("PERRITO")
                cmd = New SqlCommand
                cmd.CommandType = CommandType.Text
                cmd.Connection = sqlConnection1
                sqlConnection1.Open()
                id_diseno = ListView1.Items(i).SubItems(0).Text
                cantidad = ListView1.Items(i).SubItems(2).Text
                color = ListView1.Items(i).SubItems(6).Text
                detalles = ListView1.Items(i).SubItems(7).Text
                cmd.CommandText = "INSERT INTO INCLUSION (ID_OS ,ID_DISENO,COLOR, CANTIDAD, DETALLES_ADICIONALES) VALUES ('" & id_ORDEN_actual & "' , '" & id_diseno & "','" & color & "','" & cantidad & "' , '" & detalles & "')"
                ' MsgBox(cmd.CommandText)

                Try
                    cmd.ExecuteNonQuery()
                    Modulo.insertar_auditoria(Modulo.usuario, "INCLUSION", "INSERT INTO INCLUSION (ID_OS ,ID_DISENO,COLOR, CANTIDAD, DETALLES_ADICIONALES) VALUES", "I", Date.Today, "", "")
                Catch ex As Exception

                    'insercion_inclusiones = False
                End Try

                sqlConnection1.Close()
            Next

            cmd = New SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "INSERT INTO HISTORIAL_DE_AVANCE(ID_OS,ID_ESTADO,FECHA_DE_AVANCE) VALUES ('" & obtenerID(TextBox4.Text) & "','" & estado1 & "','" & Date.Today.ToString & "')"
            'MsgBox(cmd.CommandText)

            cmd.Connection = sqlConnection1
            sqlConnection1.Open()
            Try
                cmd.ExecuteNonQuery()
                ' MsgBox("Historial actualizada exitosamente")
                Modulo.insertar_auditoria(Modulo.usuario, "HISTORIAL_DE_AVANCE", "INSERT INTO HISTORIAL_DE_AVANCE(ID_OS,ID_ESTADO,FECHA_DE_AVANCE) VALUES", "I", Date.Today, "", "")

            Catch ex As Exception
                'MsgBox("Error en el Historial")
            End Try
            sqlConnection1.Close()
            If insercion_inclusiones = True Then
                MsgBox("Inclusiones ingresadas exitosamente. Pedido Actualizado en el Sistema")
                ListView1.Items.Clear()
                TextBox1.Clear()
                'ComboBox1.SelectedItem = Nothing
                ComboBox2.SelectedItem = Nothing
                Me.Close()

                'INSERTAR EN REPORTE_PRODUCCION POR CADA INCLUSION
                ' ID_REPORTE_PRODUCCION ID_OS ID_DISENO INFORMACION_PRODUCCION PORCENTAJE_AVANCE



            End If

            'Catch ex As Exception
            '     MsgBox("Error en el ingreso de los datos de la orden")
            'End Try

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim cliente_rut As String = obtenerNombre(TextBox4.Text)
        Dim fecha_ini As String = DateTimePicker1.Value
        Dim fecha_fin As String = DateTimePicker2.Value



        Dim estado As Integer = 0
        If ComboBox2.Text = "Creada" Then
            estado = 0
        ElseIf ComboBox2.Text = "En proceso" Then
            estado = 1
        ElseIf ComboBox2.Text = "Pausada" Then
            estado = 2
        ElseIf ComboBox2.Text = "Finalizada" Then
            estado = 3
        Else
            estado = 4
        End If

        Dim coments As String = TextBox1.Text

        Mantener_pedidos3.TextBox10.Text = cliente_rut
        Mantener_pedidos3.TextBox7.Text = fecha_ini
        Mantener_pedidos3.TextBox9.Text = fecha_fin
        Mantener_pedidos3.TextBox8.Text = ComboBox2.Text
        Mantener_pedidos3.TextBox11.Text = obtenerID(TextBox4.Text)

        Me.Hide()
        Mantener_pedidos3.Show()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("Seleccione inclusiones para remover del pedido")
        Else
            Dim mb As MsgBoxResult = MsgBox("Esta seguro de remover las inclusiones seleccionadas?", MsgBoxStyle.YesNo)
            If mb = MsgBoxResult.Yes Then
                For i = 0 To ListView1.CheckedItems.Count - 1
                    ListView1.CheckedItems.Item(0).Remove()

                Next

            End If
        End If
    End Sub
End Class