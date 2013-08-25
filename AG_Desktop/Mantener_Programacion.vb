Imports System.Data.SqlClient


Public Class Mantener_Programacion

    Private Sub Mantener_Programacion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Mantener_Teoricos.Show()

    End Sub

    Private Sub Mantener_Programacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ListView1.Items.Clear()
        ListView2.Items.Clear()


        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from ORDEN_DE_SERVICIO where ID_ESTADO = '0'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Dim id_os As String = dt.Rows(0).Item("ID_OS").ToString.Trim
                For i = 0 To dt.Rows.Count - 1

                    ComboBox1.Items.Add(dt.Rows(i).Item("ID_OS").ToString.Trim & " : " & dt.Rows(i).Item("RUT").ToString.Trim & " : " & dt.Rows(i).Item("COMENTARIO_OS").ToString.Trim)

                Next

                c = "Select * from PUESTO_TRABAJO"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)

                For i = 0 To dt.Rows.Count - 1

                    ComboBox3.Items.Add(dt.Rows(i).Item("ID_puesto_de_trabajo").ToString.Trim & " : " & dt.Rows(i).Item("nombre_puesto").ToString.Trim & " : " & dt.Rows(i).Item("descripcion_puesto").ToString.Trim)

                Next

                ' dt = New DataTable
                c = "Select * from inclusion where id_os = '" & id_os & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)
                Dim item As New ListViewItem
                Dim dt_diseno As New DataTable

               

                For i = 0 To dt.Rows.Count - 1

                    c = "select * from diseno where id_diseno = '" & dt.Rows(i).Item("id_diseno").ToString.Trim & "'"
                    cmd = New SqlCommand(c, cnn)
                    da = New SqlDataAdapter(cmd)
                    dt_diseno = New DataTable
                    da.Fill(dt_diseno)



                    item = New ListViewItem(dt_diseno.Rows(0).Item("nombre_diseno").ToString.Trim)

                    ' ListView2.Items.Add(item)



                Next



                Dim col1 As New ColumnHeader
                Dim col2 As New ColumnHeader
                Dim col3 As New ColumnHeader
                Dim col4 As New ColumnHeader
                col1.Text = "Lugar"
                col2.Text = "Id"
                col3.Text = "Nombre"
                col4.Text = "Descripcion"

                col1.Width = 50
                col2.Width = 50
                col3.Width = 110
                col4.Width = 200

                ListView1.Columns.Add(col1)
                ListView1.Columns.Add(col2)
                ListView1.Columns.Add(col3)
                ListView1.Columns.Add(col4)

                Dim col11 As New ColumnHeader
                Dim col21 As New ColumnHeader
                col11.Text = "Inclusión"
                col21.Text = "Estado"
                col11.Width = 150
                col21.Width = 120
                ListView2.Columns.Add(col11)
                ListView2.Columns.Add(col21)

            Else

            End If

        End Using


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim orden = Modulo.obtenerID(ComboBox1.Text)
        ListView1.Items.Clear()
        ListView2.Items.Clear()


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

                c = "Select * from diseno where id_diseno = '" & id_diseno & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                dt1 = New DataTable
                da.Fill(dt1)
                ComboBox2.Items.Add(dt1.Rows(0).Item("nombre_diseno").ToString.Trim & " : " & dt.Rows(i).Item("cantidad").ToString.Trim & " : " & dt1.Rows(0).Item("genero_diseno").ToString.Trim)


                ' item = New ListViewItem(id_diseno)

                Dim dt_estado_prog As New DataTable
                c = "Select * from programacion where id_diseno = '" & id_diseno & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                'dt1 = New DataTable
                da.Fill(dt_estado_prog)

                If dt_estado_prog.Rows.Count > 0 Then
                    item = New ListViewItem(dt1.Rows(0).Item("nombre_diseno").ToString.Trim)
                    item.SubItems.Add("LISTO")


                    ListView2.Items.Add(item)

                Else
                    item = New ListViewItem(dt1.Rows(0).Item("nombre_diseno").ToString.Trim)
                    item.SubItems.Add("PENDIENTE")

                    ListView2.Items.Add(item)
                End If

                





                'item.SubItems.Add(dt1.Rows(0).Item("nombre_diseno").ToString.Trim)
                'item.SubItems.Add(dt.Rows(i).Item("cantidad").ToString.Trim)
                'item.SubItems.Add(dt1.Rows(0).Item("genero_diseno").ToString.Trim)
                'item.SubItems.Add(dt1.Rows(0).Item("tallaje").ToString.Trim)
                'item.SubItems.Add(dt.Rows(i).Item("color").ToString.Trim)
                'item.SubItems.Add(dt.Rows(i).Item("detalles_adicionales").ToString.Trim)

                'ListView1.Items.Add(item)
            Next
            For j = 0 To ListView2.Items.Count - 1

                If ListView2.Items(j).SubItems(1).Text.ToString = "LISTO" Then
                    ListView2.Items(j).SubItems(1).ForeColor = Color.Green
                Else
                    ListView2.Items(j).SubItems(1).ForeColor = Color.Red
                End If
            Next

            ListView2.Refresh()



        End Using
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TextBox7.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Ingrese el nombre y la descripción para el nuevo puesto")
        Else
            Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "INSERT INTO PUESTO_TRABAJO (nombre_puesto,descripcion_puesto) VALUES ('" & TextBox7.Text & "','" & TextBox5.Text & "')"
            cmd.Connection = sqlConnection1
            sqlConnection1.Open()

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Puesto creado exitosamente.", MsgBoxStyle.Information, "Informacion")

                Dim c As String = "Select * from PUESTO_TRABAJO"
                cmd = New SqlCommand(c, sqlConnection1)
                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                ComboBox3.Items.Clear()

                For i = 0 To dt.Rows.Count - 1

                    ComboBox3.Items.Add(dt.Rows(i).Item("ID_puesto_de_trabajo").ToString.Trim & " : " & dt.Rows(i).Item("nombre_puesto").ToString.Trim & " : " & dt.Rows(i).Item("descripcion_puesto").ToString.Trim)

                Next

                TextBox7.Clear()
                TextBox5.Clear()



            Catch ex As Exception
                MsgBox("No se pudo ingresar el puesto. Intente mas tarde")

            End Try

        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If ComboBox3.Text = "" Then
            MsgBox("Seleccione un puesto")
        Else

            'VER SI YA ESTA EN EL LV
            Dim esta As Boolean = False
            For i = 0 To ListView1.Items.Count - 1

                If ListView1.Items(i).SubItems(1).Text = obtenerID(ComboBox3.Text) Then
                    esta = True

                End If

            Next

            If esta Then
                MsgBox("Ya se encuentra en la lista")
            Else

                Dim item As New ListViewItem
                item = New ListViewItem(ListView1.Items.Count)
                item.SubItems.Add(obtenerID(ComboBox3.Text))
                item.SubItems.Add(obtenerNombre(ComboBox3.Text))
                item.SubItems.Add(obtenerTres(ComboBox3.Text))

                ListView1.Items.Add(item)
            End If

           
        End If
       
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If ListView1.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione un puesto")
        Else

            Dim sel As Integer = ListView1.SelectedItems(0).Index.ToString
            ListView1.SelectedItems(0).Remove()
            For i = 0 To ListView1.Items.Count - 1
                If i >= sel Then
                    ListView1.Items(i).SubItems(0).Text = CType(ListView1.Items(i).SubItems(0).Text, Integer) - 1
                Else

                End If

            Next
        End If
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Dim inclusion As String = obtenerID(ComboBox2.Text)
        If ListView1.Items.Count = 0 Then
            MsgBox("No ha ingresado puestos de trabajo")
        Else

        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione un puesto")
        Else
            If ListView1.SelectedItems(0).Index = 0 Then
            Else
                Dim lugar As Integer = ListView1.SelectedItems(0).Index


            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If ListView1.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione un puesto")
        Else
            If ListView1.SelectedItems(0).Index = 0 Then
            Else
                Dim lugar As Integer = ListView1.SelectedItems(0).Index


            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        TextBox5.Clear()
        TextBox7.Clear()

        Me.Hide()
        Mantener_Teoricos.Show()


    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'INSERTAR EN AUTOMATA
        'INSERTAR EN PROGRAMACION


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class