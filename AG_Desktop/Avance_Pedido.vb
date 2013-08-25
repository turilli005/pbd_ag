Imports System.Data.SqlClient
Imports System.Drawing

Public Class Avance_Pedido

    Private Sub Avance_Pedido_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Inicio_Operador.Show()

    End Sub

    Private Sub Avance_Pedido_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GroupBox1.Enabled = False

        Dim tt As New ToolTip()
        tt.SetToolTip(PictureBox5, "Ayuda")


        Dim col1 As New Windows.Forms.ColumnHeader
        Dim col2 As New Windows.Forms.ColumnHeader
        Dim col3 As New Windows.Forms.ColumnHeader
        Dim col4 As New Windows.Forms.ColumnHeader
        Dim col5 As New Windows.Forms.ColumnHeader
        Dim col6 As New Windows.Forms.ColumnHeader
        Dim col7 As New Windows.Forms.ColumnHeader

        col1.Text = "Traje"
        col2.Text = "Cantidad"
        col3.Text = "Diseño"
        col4.Text = "Compra"
        col5.Text = "Corte"
        col6.Text = "Confección"
        col7.Text = "% Avance"

        col1.Width = 100
        col2.Width = 70
        col7.Width = 70





        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from ORDEN_DE_SERVICIO where ID_ESTADO = '1'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)



            For i = 0 To dt.Rows.Count - 1

                ComboBox1.Items.Add(dt.Rows(i).Item("ID_OS").ToString & " : " & dt.Rows(i).Item("RUT").ToString & " : " & dt.Rows(i).Item("COMENTARIO_OS").ToString)

            Next



        End Using


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim id As String = obtenerID(ComboBox1.Text)
        ComboBox2.Items.Clear()
        GroupBox1.Enabled = True

        Label2.Text = "PENDIENTE"
        Label3.Text = "PENDIENTE"
        Label4.Text = "PENDIENTE"
        Label5.Text = "PENDIENTE"

        TextBox12.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox6.Clear()
        TextBox16.Clear()
        TextBox15.Clear()
        TextBox14.Clear()


        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * From INCLUSION where ID_OS = '" & id & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)

            Dim id_diseno As String
            Dim dt1 As New DataTable


            For i = 0 To dt.Rows.Count - 1
                id_diseno = dt.Rows(i).Item("id_diseno").ToString
                c = "Select * from diseno where id_diseno = '" & id_diseno & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                dt1 = New DataTable
                da.Fill(dt1)

                ComboBox2.Items.Add(dt.Rows(i).Item("id_diseno").ToString & " : " & dt1.Rows(0).Item("nombre_diseno").ToString & " : " & dt.Rows(i).Item("cantidad").ToString)

            Next


        End Using

        'CONSULTAR POR REPORTES PRODUCCION
        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * from REPORTE_PRODUCCION where id_os = '" & id & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count = 0 Then
                MsgBox("La orden no tiene inclusiones asociadas", MsgBoxStyle.Information, "Error")
                GroupBox1.Enabled = False

            Else
                GroupBox1.Enabled = True

                Dim ITEM As New ListViewItem(TextBox8.Text)
                ITEM.SubItems.Add(TextBox16.Text)

                If CType(dt.Rows(0).Item("PORCENTAJE_AVANCE").ToString, Integer) = 0 Then

                    ITEM.SubItems.Add("Pendiente")
                    ITEM.SubItems.Add("Pendiente")
                    ITEM.SubItems.Add("Pendiente")
                    ITEM.SubItems.Add("Pendiente")
                    ITEM.SubItems.Add("0")
                ElseIf CType(dt.Rows(0).Item("PORCENTAJE_AVANCE").ToString, Integer) = 25 Then

                    ITEM.SubItems.Add("Listo")
                    ITEM.SubItems.Add("Pendiente")
                    ITEM.SubItems.Add("Pendiente")
                    ITEM.SubItems.Add("Pendiente")
                    ITEM.SubItems.Add("25")
                ElseIf CType(dt.Rows(0).Item("PORCENTAJE_AVANCE").ToString, Integer) = 50 Then
                    ITEM.SubItems.Add("Listo")
                    ITEM.SubItems.Add("Listo")
                    ITEM.SubItems.Add("Pendiente")
                    ITEM.SubItems.Add("Pendiente")
                    ITEM.SubItems.Add("50")
                ElseIf CType(dt.Rows(0).Item("PORCENTAJE_AVANCE").ToString, Integer) = 75 Then
                    ITEM.SubItems.Add("Listo")
                    ITEM.SubItems.Add("Listo")
                    ITEM.SubItems.Add("Listo")
                    ITEM.SubItems.Add("Pendiente")
                    ITEM.SubItems.Add("75")
                ElseIf CType(dt.Rows(0).Item("PORCENTAJE_AVANCE").ToString, Integer) = 100 Then
                    ITEM.SubItems.Add("Listo")
                    ITEM.SubItems.Add("Listo")
                    ITEM.SubItems.Add("Listo")
                    ITEM.SubItems.Add("Listo")
                    ITEM.SubItems.Add("100")

                End If

                ' ListView3.Items.Add(ITEM)
            End If

            


        End Using
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        Button1.Enabled = True
        PictureBox1.Enabled = True
        PictureBox2.Enabled = True
        PictureBox3.Enabled = True
        PictureBox4.Enabled = True

        ' VER SI ESTA INCLUSION TIENE PROGRAMACION ALTERNATIVA
        Dim c As String = ""
        Dim cmd As SqlCommand
        'cmd.CommandType = CommandType.Text
        Dim da As SqlDataAdapter
        Dim dt As DataTable


        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            c = "Select * from PROGRAMACION where id_diseno = '" & obtenerID(ComboBox2.Text) & "'"
            cmd = New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                'PASAR A PROGRAMACION ALTERNATIVA
                MsgBox("Esta inclusión tiene una programación alternativa.")
                Button1.Enabled = False
                PictureBox1.Enabled = False
                PictureBox2.Enabled = False
                PictureBox3.Enabled = False
                PictureBox4.Enabled = False

            Else

                Dim inclusion As String = obtenerID(ComboBox1.Text) & " : " & obtenerID(ComboBox2.Text)
                PictureBox1.Enabled = True


                TextBox12.Text = obtenerID(ComboBox2.Text)
                c = "Select * from inclusion where id_diseno = '" & obtenerID(ComboBox2.Text) & "' and id_os = '" & obtenerID(ComboBox1.Text) & "'"
                cmd = New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)

                If dt.Rows.Count > 0 Then
                    TextBox16.Text = dt.Rows(0).Item("cantidad").ToString
                    TextBox15.Text = dt.Rows(0).Item("color").ToString
                    TextBox14.Text = dt.Rows(0).Item("detalles_adicionales").ToString

                Else


                End If

               

                ' End Using

                'U'sing cnn As New SqlConnection(enlace)
                'cnn.Open()
                c = "Select * from diseno where id_diseno = '" & obtenerID(ComboBox2.Text) & "'"
                cmd = New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)

                TextBox8.Text = dt.Rows(0).Item("nombre_diseno").ToString
                TextBox9.Text = dt.Rows(0).Item("Genero_diseno").ToString
                TextBox10.Text = dt.Rows(0).Item("tallaje").ToString
                TextBox7.Text = dt.Rows(0).Item("descripcion_diseno").ToString
                TextBox6.Text = dt.Rows(0).Item("descripcion_tallaje").ToString

                '  End Using

                'SETEAR BOTONES
                ' Using CNN As New SqlConnection(enlace)
                'CNN.Open()

                c = "Select * from REPORTE_PRODUCCION where id_os = '" & obtenerID(ComboBox1.Text) & "' and id_diseno = '" & obtenerID(ComboBox2.Text) & "'"
                cmd = New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)

                Dim avance As String = dt.Rows(0).Item("Porcentaje_avance").ToString.Trim

                If avance = "0" Then
                    Label2.Text = "PENDIENTE"
                    Label3.Text = "PENDIENTE"
                    Label4.Text = "PENDIENTE"
                    Label5.Text = "PENDIENTE"
                ElseIf avance = "25" Then
                    Label2.Text = "   LISTO"
                    Label3.Text = "PENDIENTE"
                    Label4.Text = "PENDIENTE"
                    Label5.Text = "PENDIENTE"

                ElseIf avance = "50" Then
                    Label2.Text = "   LISTO"
                    Label3.Text = "   LISTO"
                    Label4.Text = "PENDIENTE"
                    Label5.Text = "PENDIENTE"
                ElseIf avance = "75" Then
                    Label2.Text = "   LISTO"
                    Label3.Text = "   LISTO"
                    Label4.Text = "   LISTO"
                    Label5.Text = "PENDIENTE"
                Else
                    Label2.Text = "   LISTO"
                    Label3.Text = "   LISTO"
                    Label4.Text = "   LISTO"
                    Label5.Text = "   LISTO"


                End If

                ' MsgBox(avance)




                ' End Using

            End If
        End Using




    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

        If ComboBox2.Text = "" Then
            MsgBox("Seleccione una inclusión")
        Else
            If Label2.Text = "   LISTO" And Label3.Text = "   LISTO" Then

                MsgBox("No puede quedar pendiente esta etapa si esta LISTO el proceso de COMPRA DE MATERIALES")

            ElseIf Label2.Text = "PENDIENTE" Then

                'INDICAR CONSUMO
                Avance_Pedido_Indicar_Consumo.ETAPA = "Diseño"
                Avance_Pedido_Indicar_Consumo.puesto = 0
                Avance_Pedido_Indicar_Consumo.TextBox12.Text = TextBox12.Text & " : " & TextBox8.Text
                Avance_Pedido_Indicar_Consumo.TextBox16.Text = TextBox16.Text
                Avance_Pedido_Indicar_Consumo.TextBox15.Text = TextBox15.Text
                Avance_Pedido_Indicar_Consumo.TextBox8.Text = ComboBox1.Text

                Avance_Pedido_Indicar_Consumo.Show()


                Label2.Text = "   LISTO"
            Else
                Label2.Text = "PENDIENTE"
            End If
        End If


        

    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click

        If ComboBox2.Text = "" Then
            MsgBox("Seleccione una inclusión")
        Else

            If Label4.Text = "PENDIENTE" And Label3.Text = "PENDIENTE" Then
                MsgBox("No puede llevarse a cabo esta etapa si no esta LISTO el proceso de COMPRA DE MATERIALES", MsgBoxStyle.Information, "Error")

            ElseIf Label4.Text = "   LISTO" And Label5.Text = "   LISTO" Then

                MsgBox("No puede quedar pendiente esta etapa si esta LISTO el proceso de CONFECCIÓN", MsgBoxStyle.Information, "Error")
            ElseIf Label4.Text = "PENDIENTE" Then

                'INDICAR CONSUMO
                Avance_Pedido_Indicar_Consumo.ETAPA = "Corte"
                Avance_Pedido_Indicar_Consumo.puesto = 2
                Avance_Pedido_Indicar_Consumo.TextBox12.Text = TextBox12.Text & " : " & TextBox8.Text
                Avance_Pedido_Indicar_Consumo.TextBox16.Text = TextBox16.Text
                Avance_Pedido_Indicar_Consumo.TextBox15.Text = TextBox15.Text
                Avance_Pedido_Indicar_Consumo.TextBox8.Text = ComboBox1.Text
                Avance_Pedido_Indicar_Consumo.Show()
                Label4.Text = "   LISTO"
            Else
                Label4.Text = "PENDIENTE"
            End If
        End If


    End Sub


    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click

        If ComboBox2.Text = "" Then
            MsgBox("Seleccione una inclusión")
        Else

            If Label3.Text = "PENDIENTE" And Label2.Text = "PENDIENTE" Then
                MsgBox("No puede llevarse a cabo esta etapa si no esta LISTO el proceso de DISEÑO", MsgBoxStyle.Information, "Error")

            ElseIf Label3.Text = "   LISTO" And Label4.Text = "   LISTO" Then

                MsgBox("No puede quedar pendiente esta etapa si esta LISTO el proceso de CORTE", MsgBoxStyle.Information, "Error")
            ElseIf Label3.Text = "PENDIENTE" Then
                'INDICAR CONSUMO
                Avance_Pedido_Indicar_Consumo.ETAPA = "Compra"
                Avance_Pedido_Indicar_Consumo.puesto = 1
                Avance_Pedido_Indicar_Consumo.TextBox12.Text = TextBox12.Text & " : " & TextBox8.Text
                Avance_Pedido_Indicar_Consumo.TextBox16.Text = TextBox16.Text
                Avance_Pedido_Indicar_Consumo.TextBox15.Text = TextBox15.Text
                Avance_Pedido_Indicar_Consumo.TextBox8.Text = ComboBox1.Text
                Avance_Pedido_Indicar_Consumo.Show()
                Label3.Text = "   LISTO"
            Else
                Label3.Text = "PENDIENTE"
            End If
        End If



       



    End Sub

    Private Sub PictureBox4_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox4.Click

        If ComboBox2.Text = "" Then
            MsgBox("Seleccione una inclusión", MsgBoxStyle.Information, "Error")
        Else
            If Label5.Text = "PENDIENTE" And Label4.Text = "PENDIENTE" Then
                MsgBox("No puede llevarse a cabo esta etapa si no esta LISTO el proceso de CORTE")


            ElseIf Label5.Text = "PENDIENTE" Then
                Avance_Pedido_Indicar_Consumo.ETAPA = "Confección"
                Avance_Pedido_Indicar_Consumo.puesto = 3
                Avance_Pedido_Indicar_Consumo.TextBox12.Text = TextBox12.Text & " : " & TextBox8.Text
                Avance_Pedido_Indicar_Consumo.TextBox16.Text = TextBox16.Text
                Avance_Pedido_Indicar_Consumo.TextBox15.Text = TextBox15.Text
                Avance_Pedido_Indicar_Consumo.TextBox8.Text = ComboBox1.Text
                Avance_Pedido_Indicar_Consumo.Show()
                Label5.Text = "   LISTO"
            Else
                Label5.Text = "PENDIENTE"
            End If
        End If

     
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.BorderStyle = BorderStyle.Fixed3D

    End Sub


    Private Sub PictureBox1_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BorderStyle = BorderStyle.None

    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As System.EventArgs) Handles PictureBox2.MouseHover
        PictureBox2.BorderStyle = BorderStyle.Fixed3D

    End Sub


    Private Sub PictureBox2_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.BorderStyle = BorderStyle.None

    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.BorderStyle = BorderStyle.Fixed3D

    End Sub


    Private Sub PictureBox3_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.BorderStyle = BorderStyle.None

    End Sub

    Private Sub PictureBox4_MouseHover(sender As Object, e As System.EventArgs) Handles PictureBox4.MouseHover
        PictureBox4.BorderStyle = BorderStyle.Fixed3D

    End Sub


    Private Sub PictureBox4_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.BorderStyle = BorderStyle.None

    End Sub

    Private Sub PictureBox5_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox5.Click
        'DESPLEGAR AYUDA
        'Ayuda_Avance_Pedido.Show()
        Ayuda_General.Show()
        Ayuda_General.TabControl1.SelectedIndex = 1


    End Sub

    Private Sub Label20_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
        Inicio_Operador.Show()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'evaluar segun transiciones del automata
        If ComboBox2.Text = "" Then
            MsgBox("No ha seleccionado una inclusión", MsgBoxStyle.Information, "Error")
        Else
            Dim avance As Integer = 0
            If Label5.Text = "   LISTO" Then
                avance = 100
            ElseIf Label4.Text = "   LISTO" Then
                avance = 75
            ElseIf Label3.Text = "   LISTO" Then
                avance = 50
            ElseIf Label2.Text = "   LISTO" Then
                avance = 25
            Else
                avance = 0
            End If

            Dim orden As String = obtenerID(ComboBox1.Text)
            Dim diseno As String = obtenerID(ComboBox2.Text)

            Using CNN As New SqlConnection(enlace)
                CNN.Open()

                Dim c As String = "Select * from REPORTE_PRODUCCION where id_os = '" & orden & "' and id_diseno = '" & diseno & "'"
                Dim cmd As New SqlCommand(c, CNN)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                If dt.Rows.Count = 0 Then

                    'INSERTAR REPORTE
                    c = "INSERT INTO REPORTE_PRODUCCION(ID_OS, ID_DISENO, INFORMACION_PRODUCCION, PORCENTAJE_AVANCE) VALUES ('" & orden & "','" & diseno & "','NULL' , '" & avance & "')"
                    cmd = New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = c
                    cmd.Connection = CNN

                    Try
                        cmd.ExecuteNonQuery()
                        Modulo.insertar_auditoria(Modulo.usuario, "NOTIFICACION", "INSERT INTO REPORTE_PRODUCCION(ID_OS, ID_DISENO, INFORMACION_PRODUCCION, PORCENTAJE_AVANCE) VALUES", "I", Date.Today, "", "")
                        MsgBox("Se ha actualizado el estado de la inclusión: " & obtenerNombre(ComboBox2.Text), MsgBoxStyle.Information, "Informacion")
                    Catch ex As Exception

                    End Try

                    'INSERT INTO PRODUCTO (ID_PUESTO_TRABAJO,ID_REPORTE_PRODUCCION,DETALLE_PRODUCCION)


                Else

                    'ACTUALIZAR REPORTE

                    c = "UPDATE REPORTE_PRODUCCION SET porcentaje_avance = '" & avance & "' where id_os = '" & orden & "' and id_diseno = '" & diseno & "'"
                    'MsgBox(c)
                    cmd = New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = c
                    cmd.Connection = CNN
                    Try
                        cmd.ExecuteNonQuery()

                        Modulo.insertar_auditoria(Modulo.usuario, "NOTIFICACION", "UPDATE REPORTE_PRODUCCION SET porcentaje_avance =", "U", Date.Today, "", "")
                    Catch ex As Exception
                    End Try
                    MsgBox("Se ha actualizado el estado de la inclusión: " & obtenerNombre(ComboBox2.Text), MsgBoxStyle.Information, "Informacion")
                    'ComboBox2.SelectedItem = Nothing

                End If
            End Using

            Dim inclusion As String = obtenerID(ComboBox1.Text) & " : " & obtenerID(ComboBox2.Text)
            PictureBox1.Enabled = True


            TextBox12.Text = obtenerID(ComboBox2.Text)


            Using cnn As New SqlConnection(enlace)
                cnn.Open()
                Dim c As String = "Select * from inclusion where id_diseno = '" & obtenerID(ComboBox2.Text) & "' and id_os = '" & obtenerID(ComboBox1.Text) & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                TextBox16.Text = dt.Rows(0).Item("cantidad").ToString
                TextBox15.Text = dt.Rows(0).Item("color").ToString
                TextBox14.Text = dt.Rows(0).Item("detalles_adicionales").ToString

            End Using

            Using cnn As New SqlConnection(enlace)
                cnn.Open()
                Dim c As String = "Select * from diseno where id_diseno = '" & obtenerID(ComboBox2.Text) & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                TextBox8.Text = dt.Rows(0).Item("nombre_diseno").ToString
                TextBox9.Text = dt.Rows(0).Item("Genero_diseno").ToString
                TextBox10.Text = dt.Rows(0).Item("tallaje").ToString
                TextBox7.Text = dt.Rows(0).Item("descripcion_diseno").ToString
                TextBox6.Text = dt.Rows(0).Item("descripcion_tallaje").ToString

            End Using

            'SETEAR BOTONES
            Using CNN As New SqlConnection(enlace)
                CNN.Open()

                Dim c As String = "Select * from REPORTE_PRODUCCION where id_os = '" & obtenerID(ComboBox1.Text) & "' and id_diseno = '" & obtenerID(ComboBox2.Text) & "'"
                Dim cmd As New SqlCommand(c, CNN)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                Dim avance1 As String = dt.Rows(0).Item("Porcentaje_avance").ToString.Trim

                If avance1 = "0" Then
                    Label2.Text = "PENDIENTE"
                    Label3.Text = "PENDIENTE"
                    Label4.Text = "PENDIENTE"
                    Label5.Text = "PENDIENTE"
                ElseIf avance1 = "25" Then
                    Label2.Text = "LISTO"
                    Label3.Text = "PENDIENTE"
                    Label4.Text = "PENDIENTE"
                    Label5.Text = "PENDIENTE"

                ElseIf avance1 = "50" Then
                    Label2.Text = "   LISTO"
                    Label3.Text = "   LISTO"
                    Label4.Text = "PENDIENTE"
                    Label5.Text = "PENDIENTE"
                ElseIf avance1 = "75" Then
                    Label2.Text = "   LISTO"
                    Label3.Text = "   LISTO"
                    Label4.Text = "   LISTO"
                    Label5.Text = "PENDIENTE"
                Else
                    Label2.Text = "   LISTO"
                    Label3.Text = "   LISTO"
                    Label4.Text = "   LISTO"
                    Label5.Text = "   LISTO"


                End If

                ' MsgBox(avance)


                'EVALUAR SI TODAS LAS INCLUSIONES DEL PEDIDO ESTAN EN 100%
                'SI ES ASI CAMBIAR EL ESTADO DE LA ORDEN
                'orden
                orden = obtenerID(ComboBox1.Text)
                Dim completa As Boolean = True
                c = "Select * from REPORTE_PRODUCCION where id_os = '" & orden & "'"
                cmd = New SqlCommand(c, CNN)
                cmd.CommandType = CommandType.Text
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)
                Dim dt1 As New DataTable


                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        If dt.Rows(i).Item("porcentaje_avance").ToString.Trim = "100" Then
                        Else
                            completa = False

                        End If
                    Next
                Else
                    MsgBox("No se encontraron inclusiones", MsgBoxStyle.Information, "Error")
                End If
                If completa Then
                    MsgBox("Orden finalizada", MsgBoxStyle.Information, "Informacion")
                    c = "UPDATE ORDEN_DE_SERVICIO SET ID_ESTADO = '3' WHERE ID_OS = '" & orden & "'"

                    cmd = New SqlCommand(c, CNN)
                    cmd.CommandType = System.Data.CommandType.Text
                    ' Try
                    cmd.ExecuteNonQuery()


                    cmd = New SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "INSERT INTO HISTORIAL_DE_AVANCE(ID_OS,ID_ESTADO,FECHA_DE_AVANCE) VALUES ('" & obtenerID(ComboBox1.Text) & "','3','" & Date.Today.ToString & "')"
                    cmd.Connection = CNN

                    Try
                        cmd.ExecuteNonQuery()
                        ' MsgBox("Historial actualizada exitosamente")
                        Modulo.insertar_auditoria(Modulo.usuario, "HISTORIAL_DE_AVANCE", "INSERT INTO HISTORIAL_DE_AVANCE(ID_OS,ID_ESTADO,FECHA_DE_AVANCE) VALUES", "U", Date.Today, "", "")

                    Catch ex As Exception
                        '  MsgBox("Error en el Historial")
                    End Try


                    ' Catch ex As Exception
                    '  MsgBox("Error en la actualización de la orden. Intente más tarde")

                    ' End Try
                Else
                    MsgBox("Orden aún sin finalizar", MsgBoxStyle.Information, "Informacion")
                End If

            End Using
        End If


        


    End Sub

    Private Sub ListView3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Close()

    End Sub
End Class