Imports System.Data.SqlClient
Imports System.Drawing


Public Class Mantener_Teoricos

    Private Sub Mantener_Teoricos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Modulo.cargoUser = 0 Then
            Inicio_Administrador.Show()

        Else
            Inicio_Operador.Show()
        End If



    End Sub

    Private Sub Mantener_Teoricos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        ' Button3.Enabled = False
        Button5.Enabled = True


        Dim tt As New ToolTip()
        tt.SetToolTip(PictureBox5, "Ayuda")


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
        col4.Text = "Genero"
        col5.Text = "Tallaje"
        col6.Text = "Color"
        col7.Text = "Actualizada"

        col1.Width = 70
        col2.Width = 150
        col3.Width = 70
        col4.Width = 100
        col5.Width = 70
        col6.Width = 100
        col7.Width = 250

        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)
        ListView1.Columns.Add(col4)
        ListView1.Columns.Add(col5)
        ListView1.Columns.Add(col6)
        ListView1.Columns.Add(col7)

        Dim col111 As New Windows.Forms.ColumnHeader
        Dim col211 As New Windows.Forms.ColumnHeader
        Dim col31 As New Windows.Forms.ColumnHeader
        Dim col41 As New Windows.Forms.ColumnHeader
        Dim col51 As New Windows.Forms.ColumnHeader
        Dim col61 As New Windows.Forms.ColumnHeader
        Dim col71 As New Windows.Forms.ColumnHeader
        Dim col81 As New Windows.Forms.ColumnHeader

        col111.Text = "Diseño"
        col211.Text = "Nombre"
        col31.Text = "Cantidad"
        col41.Text = "Genero"
        col51.Text = "Tallaje"
        col61.Text = "Color"
        col71.Text = "Actualizada"

        col111.Width = 70
        col211.Width = 150
        col31.Width = 70
        col41.Width = 100
        col51.Width = 70
        col61.Width = 100
        col71.Width = 250

        ListView4.Columns.Add(col111)
        ListView4.Columns.Add(col211)
        ListView4.Columns.Add(col31)
        ListView4.Columns.Add(col41)
        ListView4.Columns.Add(col51)
        ListView4.Columns.Add(col61)
        ListView4.Columns.Add(col71)

        ComboBox1.Items.Clear()

        'COLUMNAS DE TIEMPOS TEORICOS
        Dim col10 As New Windows.Forms.ColumnHeader
        Dim col11 As New Windows.Forms.ColumnHeader
        Dim col12 As New Windows.Forms.ColumnHeader
        Dim col13 As New Windows.Forms.ColumnHeader
        Dim col14 As New Windows.Forms.ColumnHeader
        Dim col15 As New Windows.Forms.ColumnHeader
        Dim col16 As New Windows.Forms.ColumnHeader

        col10.Text = "Diseño"
        col11.Text = "Nombre"
        col11.Width = 110
        col12.Text = "Diseño"
        col13.Text = "Corte"
        col14.Text = "Confeccion"
        col14.Width = 110
        col15.Text = "Cantidad inclusión"
        col16.Text = "Tiempo total inclusión"

        'COLUMNAS DE MATERIALES TEORICOS
        Dim col20 As New Windows.Forms.ColumnHeader
        Dim col21 As New Windows.Forms.ColumnHeader
        Dim col22 As New Windows.Forms.ColumnHeader
        Dim col23 As New Windows.Forms.ColumnHeader
        Dim col24 As New Windows.Forms.ColumnHeader
        Dim col25 As New Windows.Forms.ColumnHeader
        Dim col26 As New Windows.Forms.ColumnHeader
        Dim col27 As New Windows.Forms.ColumnHeader
        Dim col28 As New Windows.Forms.ColumnHeader

        col20.Text = "Diseño"
        col21.Text = "Nombre"
        col22.Text = "Material"
        col23.Text = "Nombre"
        col24.Text = "Unidad"
        col25.Text = "Diseño"
        col26.text = "Corte"
        col27.text = "Confeccion"

        col28.Text = "Cantidad total inclusión"

        ListView2.Columns.Add(col20)
        ListView2.Columns.Add(col21)
        ListView2.Columns.Add(col22)
        ListView2.Columns.Add(col23)
        ListView2.Columns.Add(col24)
        ListView2.Columns.Add(col25)
        ListView2.Columns.Add(col26)
        ListView2.Columns.Add(col27)
        ListView2.Columns.Add(col28)

        ListView3.Columns.Add(col10)
        ListView3.Columns.Add(col11)
        ListView3.Columns.Add(col12)
        ListView3.Columns.Add(col13)
        ListView3.Columns.Add(col14)
        ListView3.Columns.Add(col15)
        ListView3.Columns.Add(col16)



        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from MATERIAL"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)



            For i = 0 To dt.Rows.Count - 1
                ComboBox2.Items.Add(dt.Rows(i).Item("ID_MATERIAL").ToString.Trim & " : " & dt.Rows(i).Item("NOMBRE_MATERIAL").ToString.Trim)
            Next



        End Using




        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from ORDEN_DE_SERVICIO where ID_ESTADO = '0'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)



            For i = 0 To dt.Rows.Count - 1

                ComboBox1.Items.Add(dt.Rows(i).Item("ID_OS").ToString.Trim & " : " & dt.Rows(i).Item("RUT").ToString.Trim & " : " & dt.Rows(i).Item("COMENTARIO_OS").ToString.Trim)

            Next



        End Using


    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then

            'VER SI LA INCLUSION YA TIENE USO_TEORICO Y TIEMPO_TEORICO

            Using cnn As New SqlConnection(enlace)
                cnn.Open()
                Dim c As String = "select * from uso_teorico where id_diseno = '" & ListView1.SelectedItems(0).SubItems(0).Text & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    MsgBox("Esta inclusión ya posee valores teóricos")
                    Dim item As New ListViewItem
                    item = ListView1.SelectedItems(0)
                    ListView1.SelectedItems(0).Remove()
                    ListView4.Items.Add(item)
                Else
                    GroupBox1.Enabled = True
                    GroupBox2.Enabled = True
                    TextBox4.Enabled = True
                    TextBox2.Enabled = True
                    TextBox3.Enabled = True
                    TextBox4.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()

                    TextBox6.Clear()
                    TextBox9.Clear()
                    TextBox10.Clear()
                    TextBox11.Clear()
                    ComboBox2.SelectedItem = Nothing


                    TextBox1.Text = ListView1.SelectedItems(0).SubItems(0).Text
                    TextBox7.Text = ListView1.SelectedItems(0).SubItems(1).Text
                    TextBox5.Text = ListView1.SelectedItems(0).SubItems(2).Text
                    ComboBox1.Enabled = False

                End If


            End Using


          

        Else
            GroupBox1.Enabled = False
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim orden = Modulo.obtenerID(ComboBox1.Text)
        ListView1.Items.Clear()
        ListView4.Items.Clear()


        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * From INCLUSION where ID_OS = '" & orden & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)

            Dim id_diseno As String

            Dim item As New ListViewItem
            Dim dt1 As New DataTable


            For i = 0 To dt.Rows.Count - 1
                id_diseno = dt.Rows(i).Item("id_diseno").ToString.Trim
                item = New ListViewItem(id_diseno)
                c = "Select * from diseno where id_diseno = '" & id_diseno & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                dt1 = New DataTable
                da.Fill(dt1)

                item.SubItems.Add(dt1.Rows(0).Item("nombre_diseno").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("cantidad").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("genero_diseno").ToString.Trim)
                item.SubItems.Add(dt1.Rows(0).Item("tallaje").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("color").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("detalles_adicionales").ToString.Trim)

                ListView1.Items.Add(item)
            Next


        End Using

    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'pasar datos a listview3
        'ver si no esta en LV3
        Dim esta As Integer = 0
        Dim cantidad As Integer = 0
        For i = 0 To ListView3.Items.Count - 1
            If ListView3.Items(i).SubItems(0).Text = TextBox1.Text Then
                esta = 1
            End If
        Next
        If esta = 1 Then
            MsgBox("Diseño ya tiene tiempos teoricos especificados")
        Else
            Dim item As New ListViewItem(TextBox1.Text)
            item.SubItems.Add(TextBox7.Text)
            item.SubItems.Add(TextBox4.Text)
            item.SubItems.Add(TextBox2.Text)
            item.SubItems.Add(TextBox3.Text)
            item.SubItems.Add(TextBox5.Text)
            cantidad = CType(TextBox4.Text, Integer) * CType(TextBox5.Text, Integer) + CType(TextBox5.Text, Integer) * CType(TextBox2.Text, Integer) + CType(TextBox5.Text, Integer) * CType(TextBox3.Text, Integer)
            item.SubItems.Add(cantidad)

            ListView3.Items.Add(item)


            'text4 2 3
            TextBox4.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
        End If

        

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim cantidad_total As Integer = 0
        Dim esta_mat As Integer = 0
        Dim esta_diseno As Integer = 0

        ' If ListView2.Items.Count > 0 And ListView3.Items.Count > 0 Then
        'Button3.Enabled = True
        'Else
        'Button3.Enabled = False

        'E'nd If

        If TextBox6.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Then
            MsgBox("Ingrese todos los datos para el material: " & ComboBox2.Text)
        ElseIf IsNumeric(TextBox9.Text) = False Or IsNumeric(TextBox10.Text) = False Or IsNumeric(TextBox11.Text) = False Then
            MsgBox("Ingrese valores numericos para los datos del material: " & ComboBox2.Text)
        Else

            For i = 0 To ListView2.Items.Count - 1
                If ListView2.Items(i).SubItems(2).Text = obtenerID(ComboBox2.Text) Then
                    esta_mat = 1
                End If
            Next
            If esta_mat = 1 Then
                For i = 0 To ListView2.Items.Count - 1
                    If ListView2.Items(i).SubItems(0).Text = TextBox1.Text Then
                        esta_diseno = 1
                    End If
                Next
                If esta_mat = 1 And esta_diseno = 1 Then
                    MsgBox("Diseño ya tiene material teoricos especificados")
                Else

                    Dim item As New ListViewItem(TextBox1.Text)
                    item.SubItems.Add(TextBox7.Text)
                    item.SubItems.Add(obtenerID(ComboBox2.Text))
                    item.SubItems.Add(obtenerNombre(ComboBox2.Text))
                    item.SubItems.Add(TextBox6.Text)
                    item.SubItems.Add(TextBox9.Text)
                    item.SubItems.Add(TextBox11.Text)
                    item.SubItems.Add(TextBox10.Text)
                    cantidad_total = CType(TextBox9.Text, Integer) + CType(TextBox11.Text, Integer) + CType(TextBox10.Text, Integer)
                    item.SubItems.Add(cantidad_total)

                    ListView2.Items.Add(item)
                    TextBox6.Clear()
                    TextBox9.Clear()
                    TextBox10.Clear()
                    TextBox11.Clear()
                    ComboBox2.SelectedItem = Nothing


                End If
            Else

                Dim item As New ListViewItem(TextBox1.Text)
                item.SubItems.Add(TextBox7.Text)
                item.SubItems.Add(obtenerID(ComboBox2.Text))
                item.SubItems.Add(obtenerNombre(ComboBox2.Text))
                item.SubItems.Add(TextBox6.Text)
                item.SubItems.Add(TextBox9.Text)
                item.SubItems.Add(TextBox11.Text)
                item.SubItems.Add(TextBox10.Text)
                cantidad_total = CType(TextBox9.Text, Integer) + CType(TextBox11.Text, Integer) + CType(TextBox10.Text, Integer)
                item.SubItems.Add(cantidad_total)

                ListView2.Items.Add(item)
                TextBox6.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox11.Clear()
                ComboBox2.SelectedItem = Nothing

            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If ListView1.Items.Count > 0 And ListView2.Items.Count > 0 And ListView3.Items.Count > 0 Then
            'MATERIALES
            'ID_DISENO ID_PUESTO_TRABAJO ID_MATERIAL CANTIDAD_ESTIMADA UNIDAD_TEORICA

            'EVALUAR SI HAY MATERIALES PARA CADA DISEÑO
            Dim todos As Boolean = True
            Dim esta As Boolean = False

            For i = 0 To ListView1.Items.Count - 1
                esta = False

                For j = 0 To ListView2.Items.Count - 1
                    If ListView1.Items(i).SubItems(0).Text = ListView2.Items(j).SubItems(0).Text Then
                        esta = True

                    End If
                Next
                If esta = True Then

                Else
                    todos = False

                End If

            Next

            If todos Then

                'EVALUAR SI HAY TIEMPOS PARA TODOS

                Dim todos_tiempo As Boolean = True
                esta = False
                For i = 0 To ListView1.Items.Count - 1
                    esta = False
                    For j = 0 To ListView3.Items.Count - 1
                        If ListView1.Items(i).SubItems(0).Text = ListView3.Items(j).SubItems(0).Text Then
                            esta = True

                        End If
                    Next
                Next

                If todos_tiempo Then
                    'INSERCIONES EN MODO HARCORE!!!
                    Dim inserciones As Boolean = True

                    For i = 0 To ListView2.Items.Count - 1

                        Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)
                        Dim cmd As New System.Data.SqlClient.SqlCommand

                        'MATERIAL I PARA DISENO

                        cmd.CommandType = System.Data.CommandType.Text
                        Dim c As String = "INSERT INTO USO_TEORICO(ID_DISENO, ID_PUESTO_dE_TRABAJO , ID_MATERIAL, CANTIDAD_ESTIMADA, UNIDAD_TEORICA) VALUES ('"
                        'Dim c11 As String = c

                        c = c & ListView2.Items(i).SubItems(0).Text & "', '1', '" & ListView2.Items(i).SubItems(2).Text & "','" & ListView2.Items(i).SubItems(5).Text & "','" & ListView2.Items(i).SubItems(4).Text & "')"
                        cmd.CommandText = c
                        ' MsgBox(c)
                        cmd.Connection = sqlConnection1
                        sqlConnection1.Open()
                        Try
                            cmd.ExecuteNonQuery()
                            Modulo.insertar_auditoria(Modulo.usuario, "USO_TEORICO", "INSERT INTO USO_TEORICO(ID_DISENO, ID_PUESTO_dE_TRABAJO , ID_MATERIAL, CANTIDAD_ESTIMADA, UNIDAD_TEORICA) VALUES", "I", Date.Today, "", "")
                        Catch ex As Exception
                            inserciones = False
                        End Try

                        sqlConnection1.Close()


                        'MATERIAL  I PARA CORTE
                        c = "INSERT INTO USO_TEORICO(ID_DISENO, ID_PUESTO_dE_TRABAJO , ID_MATERIAL, CANTIDAD_ESTIMADA, UNIDAD_TEORICA) VALUES ('"
                        'Dim c11 As String = c
                        c = c & ListView2.Items(i).SubItems(0).Text & "', '2', '" & ListView2.Items(i).SubItems(2).Text & "','" & ListView2.Items(i).SubItems(6).Text & "','" & ListView2.Items(i).SubItems(4).Text & "')"
                        cmd = New SqlCommand
                        cmd.CommandType = System.Data.CommandType.Text
                        cmd.CommandText = c
                        'MsgBox(c)
                        cmd.Connection = sqlConnection1
                        sqlConnection1.Open()
                        Try
                            cmd.ExecuteNonQuery()
                            Modulo.insertar_auditoria(Modulo.usuario, "USO_TEORICO", "INSERT INTO USO_TEORICO(ID_DISENO, ID_PUESTO_dE_TRABAJO , ID_MATERIAL, CANTIDAD_ESTIMADA, UNIDAD_TEORICA) VALUES", "I", Date.Today, "", "")
                        Catch ex As Exception
                            inserciones = False
                        End Try
                        sqlConnection1.Close()

                        'MATERIAL I PARA CONFECCION
                        c = "INSERT INTO USO_TEORICO(ID_DISENO, ID_PUESTO_dE_TRABAJO , ID_MATERIAL, CANTIDAD_ESTIMADA, UNIDAD_TEORICA) VALUES ('"
                        ' c11 = c
                        c = c & ListView2.Items(i).SubItems(0).Text & "', '3', '" & ListView2.Items(i).SubItems(2).Text & "','" & ListView2.Items(i).SubItems(7).Text & "','" & ListView2.Items(i).SubItems(4).Text & "')"
                        cmd = New SqlCommand
                        cmd.CommandType = System.Data.CommandType.Text
                        cmd.CommandText = c
                        'MsgBox(c)
                        cmd.Connection = sqlConnection1
                        sqlConnection1.Open()
                        Try
                            cmd.ExecuteNonQuery()
                            Modulo.insertar_auditoria(Modulo.usuario, "USO_TEORICO", "INSERT INTO USO_TEORICO(ID_DISENO, ID_PUESTO_dE_TRABAJO , ID_MATERIAL, CANTIDAD_ESTIMADA, UNIDAD_TEORICA) VALUES", "I", Date.Today, "", "")
                        Catch ex As Exception
                            inserciones = False
                            MsgBox(ex.ToString)
                        End Try
                        sqlConnection1.Close()

                    Next

                    'TIEMPOS
                    'ID_DISENO ID_PUESTO_TRABAJO  TIEMPO_ESTIMADO
                    Dim cnn As New SqlConnection(enlace)
                    Dim cm As New SqlCommand
                    Dim consulta As String = ""
                    For i = 0 To ListView3.Items.Count - 1

                        consulta = "INSERT INTO TIEMPO_TEORICO(ID_DISENO, ID_PUESTO_DE_TRABAJO, TIEMPO_ESTIMADO) VALUES ('"
                        ' Dim c11 As String = consulta
                        consulta = consulta & ListView3.Items(i).SubItems(0).Text & "', '1', '" & ListView3.Items(i).SubItems(2).Text & "')"
                        cm = New SqlCommand
                        cm.CommandType = CommandType.Text
                        cm.CommandText = consulta
                        cm.Connection = cnn
                        cnn.Open()
                        Try
                            cm.ExecuteNonQuery()
                            Modulo.insertar_auditoria(Modulo.usuario, "USO_TEORICO", "INSERT INTO TIEMPO_TEORICO(ID_DISENO, ID_PUESTO_DE_TRABAJO, TIEMPO_ESTIMADO) VALUES (", "I", Date.Today, "", "")
                        Catch ex As Exception
                            inserciones = False
                            MsgBox(ex.ToString)
                        End Try
                        cnn.Close()


                        consulta = "INSERT INTO TIEMPO_TEORICO(ID_DISENO, ID_PUESTO_DE_TRABAJO, TIEMPO_ESTIMADO) VALUES ('"

                        consulta = consulta & ListView3.Items(i).SubItems(0).Text & "', '2', '" & ListView3.Items(i).SubItems(3).Text & "')"

                        cm = New SqlCommand
                        cm.CommandType = CommandType.Text
                        cm.CommandText = consulta
                        cm.Connection = cnn
                        cnn.Open()
                        Try
                            cm.ExecuteNonQuery()
                            Modulo.insertar_auditoria(Modulo.usuario, "TIEMPO_TEORICO_TEORICO", "INSERT INTO TIEMPO_TEORICO(ID_DISENO, ID_PUESTO_DE_TRABAJO, TIEMPO_ESTIMADO) VALUES (", "I", Date.Today, "", "")
                        Catch ex As Exception
                            inserciones = False
                            MsgBox(ex.ToString)
                        End Try
                        cnn.Close()

                        consulta = "INSERT INTO TIEMPO_TEORICO(ID_DISENO, ID_PUESTO_DE_TRABAJO, TIEMPO_ESTIMADO) VALUES ('"
                        consulta = consulta & ListView3.Items(i).SubItems(0).Text & "', '3', '" & ListView3.Items(i).SubItems(4).Text & "')"

                        cm = New SqlCommand
                        cm.CommandType = CommandType.Text
                        cm.CommandText = consulta
                        cm.Connection = cnn
                        cnn.Open()
                        Try
                            cm.ExecuteNonQuery()
                            Modulo.insertar_auditoria(Modulo.usuario, "TIEMPO_TEORICO", "INSERT INTO TIEMPO_TEORICO(ID_DISENO, ID_PUESTO_DE_TRABAJO, TIEMPO_ESTIMADO) VALUES (", "I", Date.Today, "", "")
                        Catch ex As Exception
                            inserciones = False
                            MsgBox(ex.ToString)
                        End Try
                        cnn.Close()
                    Next





                    'UPDATE PEDIDO TO "EN PROCESO"
                    Dim sqlConnection2 As New System.Data.SqlClient.SqlConnection(enlace)
                    Dim cmd1 As New System.Data.SqlClient.SqlCommand

                    'MATERIAL I PARA DISENO

                    cmd1.CommandType = System.Data.CommandType.Text
                    Dim c1 = "UPDATE ORDEN_DE_SERVICIO SET ID_ESTADO = '1' WHERE ID_OS = '" & obtenerID(ComboBox1.Text) & "'"
                    Dim c11 As String = c1
                    cmd1.CommandText = c1
                    'MsgBox(c)
                    cmd1.Connection = sqlConnection2
                    sqlConnection2.Open()
                    Try
                        cmd1.ExecuteNonQuery()
                        Modulo.insertar_auditoria(Modulo.usuario, "ORDEN_DE_SERVICIO", "INSERT INTO TIEMPO_TEORICO(ID_DISENO, ID_PUESTO_DE_TRABAJO, TIEMPO_ESTIMADO) VALUES (", "U", Date.Today, "", "")
                    Catch ex As Exception
                        inserciones = False
                        MsgBox(ex.ToString)
                    End Try
                    sqlConnection2.Close()


                    ListView1.Items.Clear()
                    ListView2.Items.Clear()
                    ListView4.Items.Clear()

                    ListView3.Items.Clear()
                    TextBox1.Clear()
                    TextBox7.Clear()
                    TextBox5.Clear()
                    TextBox4.Clear()
                    TextBox3.Clear()
                    TextBox2.Clear()

                    Using cnn1 As New SqlConnection(enlace)

                        cnn1.Open()
                        Dim c As String = "Select * from ORDEN_DE_SERVICIO where ID_ESTADO = '0'"
                        Dim cmd As New SqlCommand(c, cnn1)
                        cmd.CommandType = CommandType.Text

                        Dim da As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable
                        da.Fill(dt)


                        ComboBox1.Items.Clear()
                        For i = 0 To dt.Rows.Count - 1

                            ComboBox1.Items.Add(dt.Rows(i).Item("ID_OS").ToString.Trim & " : " & dt.Rows(i).Item("RUT").ToString.Trim & " : " & dt.Rows(i).Item("COMENTARIO_OS").ToString.Trim)

                        Next


                        ComboBox1.Enabled = True



                    End Using

                    If inserciones Then
                        MsgBox("Actualización de recursos teóricos completada")
                    Else
                        MsgBox("La actualización no ha podido ser completada")
                    End If
                Else
                    MsgBox("No ha especificado tiempos teoricos para todas las inclusiones")
                End If



            Else
                MsgBox("No ha especificado materiales teoricos para todas las inclusiones")
            End If

        Else
            MsgBox("Falta información por ingresar")
        End If

        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from ORDEN_DE_SERVICIO where id_estado = '0'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Inicio_Operador.Label8.Text = "Pedidos con Programación Pendiente"
                Inicio_Operador.PictureBox4.Image = My.Resources.uncheck

            Else
                Inicio_Operador.Label8.Text = "No Hay Pedidos Pendientes"
                Inicio_Operador.PictureBox4.Image = My.Resources.Symbol___Check
            End If
        End Using
        



    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'limpiartodo
        ComboBox1.Enabled = True
        ComboBox1.SelectedItem = Nothing
        Button3.Enabled = False

        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ListView3.Items.Clear()

    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub

    Private Sub Label18_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
        Crear_pedido.Show()

    End Sub

    Private Sub PictureBox5_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox5.Click
        Ayuda_General.Show()
        Ayuda_General.TabControl1.SelectedIndex = 0

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Me.Hide()
        Mantener_Programacion.Show()

    End Sub
End Class