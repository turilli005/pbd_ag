Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Mantener_Clientes

    Private Sub Mantener_Clientes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Modulo.cargoUser = 0 Then
            Inicio_Administrador.Show()
        Else
            Inicio_Vendedor.Show()

        End If



    End Sub

    Private Sub Mantener_Clientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GroupBox2.Enabled = False

        ComboBox1.Items.Add("RM")
        ComboBox1.Items.Add("Arica y Parinacota")
        ComboBox1.Items.Add("Tarapaca")
        ComboBox1.Items.Add("Antofagasta")
        ComboBox1.Items.Add("Atacama")
        ComboBox1.Items.Add("Coquimbo")
        ComboBox1.Items.Add("Valparaíso")
        ComboBox1.Items.Add("O'Higgins")
        ComboBox1.Items.Add("Maule")
        ComboBox1.Items.Add("Bío Bío")
        ComboBox1.Items.Add("Araucanía")
        ComboBox1.Items.Add("Los Ríos")
        ComboBox1.Items.Add("Los Lagos")
        ComboBox1.Items.Add("Aysén")
        ComboBox1.Items.Add("Magallanes")

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
        col5.Text = "Dirección"
        col6.Text = "Ciudad"
        col7.Text = "Región"
        col8.Text = "Organización"

        col1.Width = 100
        col2.Width = 120
        col3.Width = 140
        col4.Width = 90
        col5.Width = 100
        col6.Width = 70
        col7.Width = 100
        col8.Width = 150

        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)
        ListView1.Columns.Add(col4)
        ListView1.Columns.Add(col5)
        ListView1.Columns.Add(col6)
        ListView1.Columns.Add(col7)
        ListView1.Columns.Add(col8)

        btnVer.Enabled = False
        btnEliminar.Enabled = False




        Dim col11 As New Windows.Forms.ColumnHeader
        Dim col12 As New Windows.Forms.ColumnHeader
        Dim col13 As New Windows.Forms.ColumnHeader
        Dim col14 As New Windows.Forms.ColumnHeader
        Dim col15 As New Windows.Forms.ColumnHeader
        Dim col16 As New Windows.Forms.ColumnHeader
        Dim col17 As New Windows.Forms.ColumnHeader
        Dim col18 As New Windows.Forms.ColumnHeader

        col11.Text = "Id Pedido"
        col12.Text = "Estado"
        col13.Text = "Descripcion"
        col14.Text = "Diseño"
        col15.Text = "Cantidad"
        col16.Text = "Detalles"
        ' col17.Text = "Dirección"
        'col18.Text = "Organización"

        col11.Width = 100
        col12.Width = 90
        col13.Width = 250
        col14.Width = 100
        col15.Width = 100
        col16.Width = 70
        col17.Width = 100

        ListView2.Columns.Add(col11)
        ListView2.Columns.Add(col12)
        ListView2.Columns.Add(col13)
        '   ListView2.Columns.Add(col14)
        ' ListView2.Columns.Add(col15)
        ' ListView2.Columns.Add(col16)
        'ListView2.Columns.Add(col17)
        ' ListView2.Columns.Add(col18)




        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * From Cliente where Organizacion <> '0'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            ' Dim dt As New DataTable
            Dim dt As New DataTable
            da.Fill(dt)
            ListView1.Items.Clear()

            Dim item As New ListViewItem
            For i = 0 To dt.Rows.Count - 1


                Dim c1 As String = "Select * from persona where rut = '" & dt.Rows(i).Item("rut").ToString.Trim & "'"
                cmd = New SqlCommand(c1, cnn)
                cmd.CommandType = CommandType.Text
                da = New SqlDataAdapter(cmd)
                Dim dt1 As New DataTable
                da.Fill(dt1)

                item = New ListViewItem(dt.Rows(i).Item("RUT").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("Nombre").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("MAIL").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("TELEFONO").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("DIRECCION").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("CIUDAD").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("REGION").ToString.Trim)

                item.SubItems.Add(dt.Rows(i).Item("ORGANIZACION").ToString.Trim)

                ListView1.Items.Add(item)




            Next

        End Using





    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim seleccion As String
        btnVer.Enabled = False
        btnEliminar.Enabled = True

        'If ListView1.SelectedItems.Count <> 1 Then
        'MsgBox("Seleccione solo un Cliente")
        ' Else
        If ListView1.SelectedItems.Count = 1 Then
            seleccion = ListView1.SelectedItems(0).SubItems(0).Text
            ListView2.Items.Clear()

            Using cnn As New SqlConnection(enlace)
                cnn.Open()

                Dim c As String = "Select * From ORDEN_DE_SERVICIO where rut = '" & seleccion & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                Dim item As New ListViewItem
                For i = 0 To dt.Rows.Count - 1
                    item = New ListViewItem(dt.Rows(i).Item("ID_OS").ToString)

                    If dt.Rows(i).Item("id_estado") = "0" Then
                        item.SubItems.Add("CREADA")
                    ElseIf dt.Rows(i).Item("id_estado") = "1" Then
                        item.SubItems.Add("EN_PROCESO")
                    ElseIf dt.Rows(i).Item("id_estado") = "2" Then
                        item.SubItems.Add("PAUSADA")
                    ElseIf dt.Rows(i).Item("id_estado") = "3" Then
                        item.SubItems.Add("FINALIZADA")
                    Else
                        item.SubItems.Add("CANCELADA")
                    End If


                    item.SubItems.Add(dt.Rows(i).Item("COMENTARIO_OS").ToString)

                    ListView2.Items.Add(item)

                Next

            End Using
            btnEditar.Enabled = True
            'btnEliminar.Enabled = True
        Else
            btnEditar.Enabled = False
            'btnEliminar.Enabled = False

        End If




        'End If
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        If ListView2.SelectedItems.Count = 1 Then
            btnVer.Enabled = True
        Else

            btnVer.Enabled = False
        End If
    End Sub

    Private Sub btnCrear_Click(sender As System.Object, e As System.EventArgs) Handles btnCrear.Click
        Me.Hide()
        Crear_Cliente.Show()

    End Sub

    Private Sub btnVer_Click(sender As System.Object, e As System.EventArgs) Handles btnVer.Click
        Dim id_pedido As String = ListView2.SelectedItems(0).SubItems(0).Text

        Ver_Pedido.TextBox1.Text = id_pedido
        Ver_Pedido.TextBox2.Text = ListView1.SelectedItems(0).SubItems(0).Text & " : " & ListView1.SelectedItems(0).SubItems(1).Text
        Ver_Pedido.TextBox5.Text = ListView2.SelectedItems(0).SubItems(1).Text
        Ver_Pedido.TextBox13.Text = ListView2.SelectedItems(0).SubItems(2).Text
        Me.Hide()
        Ver_Pedido.Show()

    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        If ListView1.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione un Cliente para editar")
        Else
            btnCrear.Enabled = False
            btnEliminar.Enabled = False
            btnEditar.Enabled = False
            btnVer.Enabled = False



            GroupBox2.Enabled = True
            TextBox3.Text = ListView1.SelectedItems(0).SubItems(1).Text
            TextBox7.Text = ListView1.SelectedItems(0).SubItems(0).Text
            TextBox1.Text = ListView1.SelectedItems(0).SubItems(4).Text
            TextBox8.Text = ListView1.SelectedItems(0).SubItems(5).Text
            TextBox5.Text = ListView1.SelectedItems(0).SubItems(2).Text
            TextBox6.Text = ListView1.SelectedItems(0).SubItems(3).Text
            TextBox2.Text = ListView1.SelectedItems(0).SubItems(7).Text
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If ListView1.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione un Cliente para eliminar")
        Else
            Dim Box As MsgBoxResult = MsgBox("Está seguro de eliminar el cliente: " & ListView1.SelectedItems(0).SubItems(1).Text & "?", MsgBoxStyle.YesNo)
            If Box = MsgBoxResult.Yes Then
                'borrar



                If Modulo.cargoUser = 0 Then
                    'ADMIN

                    'Variables
                    Dim orden As String
                    Dim cliente As String
                    Dim diseno As String


                    'BORRAR TOOOODO EN MODO HARCORE

                    'MONITOREO

                    'PRODUCTO
                    'REPORTE PRODUCCION
                    'INCLUSION
                    'HISTORIAL DE AVANCE
                    'ORDEN
                    'CLIENTE
                    'PERSONA



                Else
                    'VENDEDOR


                    Using cnn As New SqlConnection(enlace)
                        cnn.Open()
                        Dim c As String = "Select * From ORDEN_DE_SERVICIO where rut = '" & ListView1.SelectedItems(0).SubItems(0).Text & "' and id_estado <> '3'"
                        Dim cmd1 As New SqlCommand(c, cnn)
                        cmd1.CommandType = CommandType.Text
                        Dim da As New SqlDataAdapter(cmd1)
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If dt.Rows.Count > 0 Then


                            If dt.Rows.Count = 1 Then

                                c = "Select * from inclusion where id_os = '" & dt.Rows(0).Item("id_os").ToString.Trim & "'"
                                cmd1 = New SqlCommand(c, cnn)
                                cmd1.CommandType = CommandType.Text
                                da = New SqlDataAdapter(cmd1)
                                Dim dt_inclusion As New DataTable
                                da.Fill(dt_inclusion)

                                If dt_inclusion.Rows.Count > 0 Then
                                    MsgBox("El cliente seleccionado posee ordenes en proceso. No puede ser eliminado")
                                Else

                                    'DELETE ORDEN dt.Rows(0).Item("id_os").ToString.Trim
                                    c = "DELETE FROM ORDEN_DE_SERVICIO Where id_os =  '" & dt.Rows(0).Item("id_os").ToString.Trim & "'"
                                    cmd1 = New SqlCommand(c, cnn)
                                    cmd1.CommandType = CommandType.Text
                                    Try
                                        cmd1.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MsgBox("No es posible borrar la ORDEN: " & dt.Rows(0).Item("id_os").ToString.Trim)
                                    End Try
                                    'DELETE CLIENTE 
                                    c = "DELETE FROM CLIENTE Where rut =  '" & ListView1.SelectedItems(0).SubItems(0).Text & "'"
                                    cmd1 = New SqlCommand(c, cnn)
                                    cmd1.CommandType = CommandType.Text
                                    Try
                                        cmd1.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MsgBox("No es posible borrar el cliente: " & ListView1.SelectedItems(1).SubItems(0).Text)
                                    End Try
                                    'DELETE PERSONA
                                    c = "DELETE FROM PERSONA Where rut =  '" & ListView1.SelectedItems(0).SubItems(0).Text & "'"
                                    cmd1 = New SqlCommand(c, cnn)
                                    cmd1.CommandType = CommandType.Text
                                    Try
                                        cmd1.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MsgBox("No es posible borrar la persona: " & ListView1.SelectedItems(1).SubItems(0).Text)
                                    End Try


                                    MsgBox("Cliente borrado satisfactoriamente")
                                End If


                            Else
                                MsgBox("El cliente seleccionado posee ordenes en proceso. No puede ser eliminado")
                            End If

                        Else
                            Dim sqlConnection1 As New SqlConnection(enlace)
                            Dim cmd As New System.Data.SqlClient.SqlCommand
                            cmd.CommandType = System.Data.CommandType.Text
                            cmd.CommandText = "UPDATE Cliente SET organizacion='0'  WHERE rut = '" & ListView1.SelectedItems(0).SubItems(0).Text & "'"
                            cmd.Connection = sqlConnection1
                            'MsgBox("UPDATE Usuario SET nombre='" & TextBox1.Text.Trim & "', mail='" & TextBox2.Text.Trim & "', fono='" & TextBox3.Text.Trim & "', cargo = '" & cargo(ComboBox1.Text.Trim) & "' WHERE username = '" & TextBox4.Text.Trim & "'")
                            sqlConnection1.Open()

                            Try
                                cmd.ExecuteNonQuery()
                                MsgBox("Cliente eliminado correctamente.")

                            Catch ex As Exception
                                MsgBox("Error en la actualización de los datos")

                            End Try
                            sqlConnection1.Close()
                        End If



                    End Using
                End If





                



               
            Else

            End If
            Using cnn As New SqlConnection(enlace)

                cnn.Open()
                Dim c As String = "Select * From Cliente where organizacion <> '0'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                ' Dim dt As New DataTable
                Dim dt As New DataTable
                da.Fill(dt)
                ListView1.Items.Clear()

                Dim item As New ListViewItem
                For i = 0 To dt.Rows.Count - 1


                    Dim c1 As String = "Select * from persona where rut = '" & dt.Rows(i).Item("rut").ToString.Trim & "'"
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

                    item.SubItems.Add(dt.Rows(i).Item("ORGANIZACION").ToString)

                    ListView1.Items.Add(item)
                Next

            End Using

        End If
    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox3.Text = "" Or TextBox7.Text = "" Or TextBox1.Text = "" Or TextBox8.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Debe completar todos los campos antes de actualizar")
        ElseIf ComboBox1.SelectedItem = Nothing Then
            MsgBox("Seleccione una region")
        ElseIf IsNumeric(TextBox7.Text) = False Then
            MsgBox("El campo de rut debe ser numérico")
        ElseIf Regex.IsMatch(TextBox5.Text, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") = False Then

            MsgBox("Ingrese un correo electrónico válido")
        Else
            'UPDATE
            btnCrear.Enabled = True
            btnEliminar.Enabled = True
            btnEditar.Enabled = True
            btnVer.Enabled = True

            Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "UPDATE Persona SET nombre='" & TextBox3.Text.Trim & "', direccion='" & TextBox1.Text.Trim & "', region='RM', ciudad='" & TextBox8.Text.Trim & "', mail='" & TextBox5.Text.Trim & "', telefono='" & TextBox6.Text.Trim & "'" & " WHERE rut = '" & TextBox7.Text.Trim & "'"
            cmd.Connection = sqlConnection1
            'MsgBox("UPDATE Usuario SET nombre='" & TextBox1.Text.Trim & "', mail='" & TextBox2.Text.Trim & "', fono='" & TextBox3.Text.Trim & "', cargo = '" & cargo(ComboBox1.Text.Trim) & "' WHERE username = '" & TextBox4.Text.Trim & "'")
            sqlConnection1.Open()

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Persona actualizada correctamente.")
                Modulo.insertar_auditoria(Modulo.usuario, "PERSONA", "UPDATE Persona SET nombre=", "U", Date.Today, "", "")
            Catch ex As Exception
                MsgBox("Error en la actualización de los datos")

            End Try
            sqlConnection1.Close()
            'actualizar()
            'GroupBox1.Enabled = False

            'Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)
            cmd = New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "UPDATE Cliente SET organizacion='" & TextBox2.Text.Trim & "'  WHERE rut = '" & TextBox7.Text.Trim & "'"
            cmd.Connection = sqlConnection1
            'MsgBox("UPDATE Usuario SET nombre='" & TextBox1.Text.Trim & "', mail='" & TextBox2.Text.Trim & "', fono='" & TextBox3.Text.Trim & "', cargo = '" & cargo(ComboBox1.Text.Trim) & "' WHERE username = '" & TextBox4.Text.Trim & "'")
            sqlConnection1.Open()

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Cliente actualizado correctamente.")
                Modulo.insertar_auditoria(Modulo.usuario, "CLIENTE", "UPDATE Cliente SET organizacion=", "U", Date.Today, "", "")
            Catch ex As Exception
                MsgBox("Error en la actualización de los datos")

            End Try
            sqlConnection1.Close()
            ' actualizar()
            ' GroupBox1.Enabled = False
            Using cnn As New SqlConnection(enlace)

                cnn.Open()
                Dim c As String = "Select * From Cliente where organizacion <> '0'"
                cmd = New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                ' Dim dt As New DataTable
                Dim dt As New DataTable
                da.Fill(dt)
                ListView1.Items.Clear()

                Dim item As New ListViewItem
                For i = 0 To dt.Rows.Count - 1


                    Dim c1 As String = "Select * from persona where rut = '" & dt.Rows(i).Item("rut").ToString.Trim & "'"
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

                    item.SubItems.Add(dt.Rows(i).Item("ORGANIZACION").ToString)

                    ListView1.Items.Add(item)




                Next

            End Using

            TextBox3.Clear()
            TextBox7.Clear()
            TextBox1.Clear()
            TextBox8.Clear()
            TextBox5.Clear()
            TextBox2.Clear()
            TextBox6.Clear()
            GroupBox2.Enabled = False
            btnEditar.Enabled = False



        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        btnCrear.Enabled = True
        btnEliminar.Enabled = False
        btnEditar.Enabled = True
        btnVer.Enabled = True
        GroupBox2.Enabled = False

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        ComboBox1.SelectedItem = Nothing

    End Sub
End Class