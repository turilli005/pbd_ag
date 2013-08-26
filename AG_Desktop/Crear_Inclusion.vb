Imports System.Data.SqlClient


Public Class Crear_Inclusion

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MsgBox("Seleccione un diseño para agregar", MsgBoxStyle.Information, "Error")
        Else
            Dim diseno As String = ComboBox1.Text
            If TextBox1.Text = "" Then
                MsgBox("Ingrese una cantidad de diseños", MsgBoxStyle.Information, "Error")
            Else
                If IsNumeric(TextBox1.Text) Then

                    If TextBox12.Text = "" Then
                        MsgBox("Debe ingresar un color", MsgBoxStyle.Information, "Error")
                    Else
                        Dim item As New ListViewItem()

                        Using cnn As New SqlConnection(enlace)

                            Dim c As String = "select * from diseno where id_diseno = '" & obtenerID(ComboBox1.Text) & "'"
                            Dim cmd As New SqlCommand(c, cnn)
                            cmd.CommandType = CommandType.Text
                            Dim da As New SqlDataAdapter(cmd)
                            Dim dt As New DataTable
                            da.Fill(dt)

                            item = New ListViewItem(obtenerID(ComboBox1.Text))
                            item.SubItems.Add(dt.Rows(0).Item("nombre_diseno").ToString)
                            item.SubItems.Add(TextBox1.Text)
                            item.SubItems.Add(dt.Rows(0).Item("descripcion_diseno").ToString)
                            item.SubItems.Add(dt.Rows(0).Item("genero_diseno").ToString)
                            item.SubItems.Add(dt.Rows(0).Item("tallaje").ToString)
                            item.SubItems.Add(TextBox12.Text)
                            item.SubItems.Add(TextBox13.Text)
                            ListView1.Items.Add(item)
                            ComboBox1.SelectedItem = Nothing
                            TextBox1.Clear()
                            TextBox12.Clear()
                            TextBox13.Clear()
                        End Using
                        GroupBox1.Enabled = True
                        GroupBox2.Enabled = True
                        TextBox1.Clear()
                        TextBox12.Clear()
                        TextBox13.Clear()
                        ComboBox1.ResetText()
                    End If
                Else
                    MsgBox("Debe ingresar un valor numerico", MsgBoxStyle.Information, "Error")
                End If
            End If

            End If
    End Sub

   

    Private Sub Crear_Inclusion_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        
    End Sub

    Private Sub Crear_Inclusion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        
        If ListView1.Items.Count > 0 Then
            Dim Box As MsgBoxResult = MsgBox("Cerrará la ventana sin guardar las inclusiones. Desea continuar?", MsgBoxStyle.YesNo)
            If Box = MsgBoxResult.Yes Then
                Crear_pedido.Show()
            Else
                'crear.Show()
                Crear_pedido.Show()

            End If
        Else
            Crear_pedido.Show()
        End If



    End Sub

    Private Sub Crear_Inclusion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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
        col5.text = "Género"
        col6.text = "Tallaje"
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

        ComboBox1.Items.Clear()
        Dim genero As String = "Unisex"
        Dim tallaje As String = "Adulto"

        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * From DISENO"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            'MsgBox(dt.Rows.Count)

            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("genero_diseno").ToString.Trim = "H" Then
                    genero = "Hombre"
                ElseIf dt.Rows(i).Item("genero_diseno").ToString.Trim = "M" Then
                    genero = "Mujer"
                Else
                    genero = "Unisex"

                End If

                If dt.Rows(i).Item("tallaje").ToString.Trim = "Adulto" Then
                    tallaje = "A"
                ElseIf dt.Rows(i).Item("tallaje").ToString.Trim = "Niño" Then
                    tallaje = "N"
                End If


                ComboBox1.Items.Add(dt.Rows(i).Item("id_diseno").ToString & " : " & dt.Rows(i).Item("nombre_diseno").ToString & " : " & genero & " : " & tallaje)

            Next

        End Using

        ComboBox2.Items.Add("Hombre")
        ComboBox2.Items.Add("Mujer")
        ComboBox2.Items.Add("Unisex")

        ComboBox3.Items.Add("Adulto")
        ComboBox3.Items.Add("Niño")
        'ComboBox3.Items.Add("A")
        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * from categoria"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            ComboBox4.Items.Clear()

            For i = 0 To dt.Rows.Count - 1
                ComboBox4.Items.Add(dt.Rows(i).Item("id_categoria").ToString.Trim & " : " & dt.Rows(i).Item("Nombre_categoria").ToString.Trim)
            Next

        End Using

    End Sub



    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim item As New ListViewItem

        For i = 0 To ListView1.Items.Count - 1
            item = ListView1.Items(0)
            ListView1.Items.RemoveAt(0)
            Crear_pedido.ListView1.Items.Add(item)

        Next
        Me.Hide()
        Crear_pedido.Show()
        Crear_pedido.BringToFront()


    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox5.Text = "" Or TextBox5.Text = "" Or TextBox14.Text = "" Or TextBox15.Text = "" Or TextBox16.Text = "" Then
            MsgBox("Debe llenar todos los campos del nuevo diseño", MsgBoxStyle.Information, "Error")
        ElseIf IsNumeric(TextBox16.Text) = False Then
            MsgBox("El campo de cantidad debe ser numérico", MsgBoxStyle.Information, "Error")
        Else

            Dim genero As String = "U"
            Dim tallaje As String = "A"

            If ComboBox2.Text = "Hombre" Then
                genero = "H"
            ElseIf ComboBox2.Text = "Mujer" Then
                genero = "M"
            Else
                genero = "U"
            End If

            If ComboBox3.Text = "Adulto" Then
                tallaje = "A"
            Else
                tallaje = "N"
            End If

            Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "INSERT INTO DISENO (nombre_diseno,descripcion_diseno, genero_diseno, tallaje, descripcion_tallaje) VALUES ('" & TextBox2.Text & "','" & TextBox6.Text & "','" & genero & "','" & tallaje & "','" & TextBox5.Text & "')"
            cmd.Connection = sqlConnection1
            sqlConnection1.Open()

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Diseño creado exitosamente.", MsgBoxStyle.Information, "Informacion")
                Modulo.insertar_auditoria(Modulo.usuario, "DISENO", "INSERT INTO DISENO (nombre_diseno,descripcion_diseno, genero_diseno, tallaje, descripcion_tallaje) VALUES", "I", Date.Today, "", "")
                ComboBox1.Items.Clear()


                Using cnn As New SqlConnection(enlace)
                    cnn.Open()
                    Dim c As String = "Select * From DISENO "
                    Dim cmd1 As New SqlCommand(c, cnn)
                    cmd1.CommandType = CommandType.Text
                    Dim da As New SqlDataAdapter(cmd1)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    'MsgBox(dt.Rows.Count)

                    For i = 0 To dt.Rows.Count - 1
                        ComboBox1.Items.Add(dt.Rows(i).Item("id_diseno").ToString & " : " & dt.Rows(i).Item("nombre_diseno").ToString & " : " & dt.Rows(i).Item("genero_diseno").ToString & " : " & dt.Rows(i).Item("tallaje").ToString)
                    Next



                End Using
                'Dim item As newlistviewitem()
                Using cnn As New SqlConnection(enlace)
                    cnn.Open()
                    Dim c As String = "Select * From DISENO  where nombre_diseno = '" & TextBox2.Text & "'"
                    Dim cmd1 As New SqlCommand(c, cnn)
                    cmd1.CommandType = CommandType.Text
                    Dim da As New SqlDataAdapter(cmd1)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    ' MsgBox(dt.Rows.Count)
                    Dim item As ListViewItem

                    item = New ListViewItem(dt.Rows(0).Item("id_diseno").ToString)
                    item.SubItems.Add(dt.Rows(0).Item("nombre_diseno").ToString)
                    item.SubItems.Add(TextBox16.Text)
                    item.SubItems.Add(dt.Rows(0).Item("descripcion_diseno").ToString)
                    item.SubItems.Add(dt.Rows(0).Item("genero_diseno").ToString)
                    item.SubItems.Add(dt.Rows(0).Item("tallaje").ToString)
                    item.SubItems.Add(TextBox15.Text)
                    item.SubItems.Add(TextBox14.Text)

                    ListView1.Items.Add(item)


                    

                End Using


               
            Catch ex As Exception
                MsgBox("Error en el ingreso de los datos de diseño", MsgBoxStyle.Information, "Error")

            End Try
            sqlConnection1.Close()

            Dim nombre_diseno As String = TextBox2.Text
            Dim id_diseno As String = ""
            Using cnn As New SqlConnection(enlace)
                cnn.Open()
                Dim c As String = "Select * from diseno where nombre_diseno = '" & TextBox2.Text & "'"
                cmd = New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                If dt.Rows.Count > 0 Then
                    id_diseno = dt.Rows(0).Item("id_diseno").ToString.Trim
                    sqlConnection1.Open()

                    cmd = New SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.Connection = sqlConnection1

                    cmd.CommandText = "INSERT INTO CATEGORIZACION (ID_CATEGORIA,ID_DISENO) VALUES ('" & obtenerID(ComboBox1.Text) & "','" & id_diseno & "')"
                    Try
                        cmd.ExecuteNonQuery()
                        Modulo.insertar_auditoria(Modulo.usuario, "CATEGORIZACION", "INSERT INTO CATEGORIZACION (ID_CATEGORIA,ID_DISENO) VALUES (", "I", Date.Today, "", "")

                    Catch ex As Exception
                        ' MsgBox(ex.ToString)
                        'MsgBox("Error en el ingreso de los datos de diseño", MsgBoxStyle.Information, "Error")

                    End Try

                    
                Else

                End If
            End Using

            TextBox2.Clear()
            TextBox6.Clear()
            TextBox5.Clear()
            TextBox16.Clear()
            TextBox15.Clear()
            TextBox14.Clear()

            ComboBox2.SelectedItem = Nothing
            ComboBox3.SelectedItem = Nothing


        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class