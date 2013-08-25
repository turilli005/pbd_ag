
Imports System.Data.SqlClient


Public Class Mantener_Pedidos

    Private Sub Mantener_Pedidos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Modulo.cargoUser = 0 Then
            Inicio_Administrador.Show()
        ElseIf Modulo.cargoUser = 1 Then

            Inicio_Vendedor.Show()
        Else
            Inicio_Operador.Show()

        End If



    End Sub

    Private Sub Mantener_Pedidos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TabPage1.Select()


        btnEditar.Enabled = False
        btnEliminar.Enabled = False


        Dim col1 As New Windows.Forms.ColumnHeader
        Dim col2 As New Windows.Forms.ColumnHeader
        Dim col3 As New Windows.Forms.ColumnHeader
        Dim col4 As New Windows.Forms.ColumnHeader

        col1.Text = "Id Orden"
        col2.Text = "Rut cliente"
        col3.Text = "Comentarios"

        col1.Width = 80
        col2.Width = 100
        col3.Width = 300

        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)

        Dim col11 As New Windows.Forms.ColumnHeader
        Dim col12 As New Windows.Forms.ColumnHeader
        Dim col13 As New Windows.Forms.ColumnHeader
        Dim col14 As New Windows.Forms.ColumnHeader
        Dim col15 As New Windows.Forms.ColumnHeader
        Dim col16 As New Windows.Forms.ColumnHeader

        col11.Text = "Id Orden"
        col12.Text = "Diseno"
        col13.Text = "Color"
        col14.Text = "Cantidad"
        col15.text = "Detalles"

        col11.Width = 70
        col12.Width = 70
        col13.Width = 100
        col14.Width = 70
        col15.Width = 200

        ListView2.Columns.Add(col11)
        ListView2.Columns.Add(col12)
        ListView2.Columns.Add(col13)
        ListView2.Columns.Add(col14)
        ListView2.Columns.Add(col15)

        Dim col111 As New Windows.Forms.ColumnHeader
        Dim col121 As New Windows.Forms.ColumnHeader
        Dim col131 As New Windows.Forms.ColumnHeader
        Dim col141 As New Windows.Forms.ColumnHeader
        Dim col151 As New Windows.Forms.ColumnHeader
        Dim col161 As New Windows.Forms.ColumnHeader

        col111.Text = "Id Orden"
        col121.Text = "Diseno"
        col131.Text = "Color"
        col141.Text = "Cantidad"
        col151.Text = "Detalles"

        col111.Width = 70
        col121.Width = 70
        col131.Width = 100
        col141.Width = 70
        col151.Width = 200

        ListView9.Columns.Add(col111)
        ListView9.Columns.Add(col121)
        ListView9.Columns.Add(col131)
        ListView9.Columns.Add(col141)
        ListView9.Columns.Add(col151)

        Dim col21 As New Windows.Forms.ColumnHeader
        Dim col22 As New Windows.Forms.ColumnHeader
        Dim col23 As New Windows.Forms.ColumnHeader
        Dim col24 As New Windows.Forms.ColumnHeader

        col21.Text = "Id Orden"
        col22.Text = "Rut cliente"
        col23.Text = "Comentarios"

        col21.Width = 80
        col22.Width = 100
        col23.Width = 300

        ListView4.Columns.Add(col21)
        ListView4.Columns.Add(col22)
        ListView4.Columns.Add(col23)

        Dim col31 As New Windows.Forms.ColumnHeader
        Dim col32 As New Windows.Forms.ColumnHeader
        Dim col33 As New Windows.Forms.ColumnHeader
        Dim col34 As New Windows.Forms.ColumnHeader

        col31.Text = "Id Orden"
        col32.Text = "Rut cliente"
        col33.Text = "Comentarios"

        col31.Width = 80
        col32.Width = 100
        col33.Width = 300

        ListView6.Columns.Add(col31)
        ListView6.Columns.Add(col32)
        ListView6.Columns.Add(col33)

        Dim col41 As New Windows.Forms.ColumnHeader
        Dim col42 As New Windows.Forms.ColumnHeader
        Dim col43 As New Windows.Forms.ColumnHeader
        Dim col44 As New Windows.Forms.ColumnHeader

        col41.Text = "Id Orden"
        col42.Text = "Rut cliente"
        col43.Text = "Comentarios"

        col41.Width = 80
        col42.Width = 100
        col43.Width = 300

        ListView10.Columns.Add(col41)
        ListView10.Columns.Add(col42)
        ListView10.Columns.Add(col43)

        Dim col51 As New Windows.Forms.ColumnHeader
        Dim col52 As New Windows.Forms.ColumnHeader
        Dim col53 As New Windows.Forms.ColumnHeader
        Dim col54 As New Windows.Forms.ColumnHeader

        col51.Text = "Id Orden"
        col52.Text = "Cliente"
        col54.Text = "Estado"
        col53.Text = "Comentarios"

        col51.Width = 80
        col52.Width = 150
        col53.Width = 200
        col54.Width = 100


        ListView8.Columns.Add(col51)
        ListView8.Columns.Add(col52)

        ListView8.Columns.Add(col53)
        ListView8.Columns.Add(col54)


        Dim col1111 As New Windows.Forms.ColumnHeader
        Dim col1211 As New Windows.Forms.ColumnHeader
        Dim col1311 As New Windows.Forms.ColumnHeader
        Dim col1411 As New Windows.Forms.ColumnHeader
        Dim col1511 As New Windows.Forms.ColumnHeader
        Dim col1611 As New Windows.Forms.ColumnHeader

        col1111.Text = "Id Orden"
        col1211.Text = "Diseno"
        col1311.Text = "Color"
        col1411.Text = "Cantidad"
        col1511.Text = "Detalles"

        col1111.Width = 70
        col1211.Width = 70
        col1311.Width = 100
        col1411.Width = 70
        col1511.Width = 200

        ListView7.Columns.Add(col1111)
        ListView7.Columns.Add(col1211)
        ListView7.Columns.Add(col1311)
        ListView7.Columns.Add(col1411)
        ListView7.Columns.Add(col1511)


        Dim item As New ListViewItem

        Using cnn As New SqlConnection(enlace)
            cnn.Open()

            Dim c As String = "Select * From Orden_de_servicio where id_estado = '0'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            ListView1.Items.Clear()
            Dim dt_cli As New DataTable

            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("Id_os").ToString.Trim)

                'c = "select * from cliente where rut = '" & dt.Rows(i).Item("RUT").ToString.Trim & "'"
                'cmd = New SqlCommand(c, cnn)
                'da = New SqlDataAdapter(cmd)
                'dt_cli = New DataTable
                'da.Fill(dt_cli)


                item.SubItems.Add(dt.Rows(i).Item("RUT").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("Comentario_os").ToString.Trim)

                ListView1.Items.Add(item)

            Next

            c = "Select * From Orden_de_servicio where id_estado = '1'"
            cmd = New SqlCommand(c, cnn)
            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            ListView10.Items.Clear()
            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("Id_os").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("RUT").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("Comentario_os").ToString.Trim)

                ListView10.Items.Add(item)

            Next


        End Using

        Using cnn As New SqlConnection(enlace)
            cnn.Open()

            Dim c As String = "Select * From Orden_de_servicio where id_estado = '3'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            ListView4.Items.Clear()

            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("Id_os").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("RUT").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("Comentario_os").ToString.Trim)

                ListView4.Items.Add(item)

            Next

            


        End Using

        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            ListView8.Items.Clear()

            Dim c As String = "Select * From Orden_de_servicio"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            ListView8.Items.Clear()
            Dim dt_cli As New DataTable

            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("Id_os").ToString.Trim)

                c = "select * from cliente where rut = '" & dt.Rows(i).Item("RUT").ToString.Trim & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                dt_cli = New DataTable
                da.Fill(dt_cli)


                item.SubItems.Add(dt.Rows(i).Item("RUT").ToString.Trim & " : " & dt_cli.Rows(0).Item("Organizacion").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("Comentario_os").ToString.Trim)
                item.SubItems.Add(Modulo.estado(dt.Rows(i).Item("id_estado").ToString.Trim))
                ListView8.Items.Add(item)

            Next

            c = "Select * From Orden_de_servicio where id_estado = '4'"
            cmd = New SqlCommand(c, cnn)
            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            ListView6.Items.Clear()
            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("Id_os").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("RUT").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("Comentario_os").ToString.Trim)

                ListView6.Items.Add(item)

            Next


        End Using

        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * From Cliente"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            For i = 0 To dt.Rows.Count - 1

                Dim c1 As String = "select * from persona where rut = '" & dt.Rows(i).Item("RUT").ToString.Trim & "'"
                Dim cmd1 As New SqlCommand(c1, cnn)
                cmd1.CommandType = CommandType.Text
                Dim da1 As New SqlDataAdapter(cmd1)
                Dim dt1 As New DataTable
                da1.Fill(dt1)
                ComboBox1.Items.Add(dt.Rows(i).Item("RUT").ToString.Trim & " : " & dt1.Rows(0).Item("nombre").ToString.Trim & " : " & dt.Rows(i).Item("organizacion").ToString.Trim)
                ComboBox2.Items.Add(dt.Rows(i).Item("RUT").ToString.Trim & " : " & dt1.Rows(0).Item("nombre").ToString.Trim & " : " & dt.Rows(i).Item("organizacion").ToString.Trim)
                ComboBox3.Items.Add(dt.Rows(i).Item("RUT").ToString.Trim & " : " & dt1.Rows(0).Item("nombre").ToString.Trim & " : " & dt.Rows(i).Item("organizacion").ToString.Trim)
                'ComboBox4.Items.Add(dt.Rows(i).Item("RUT").ToString.Trim & " : " & dt1.Rows(0).Item("nombre").ToString.Trim & " : " & dt.Rows(0).Item("organizacion").ToString.Trim)
                ComboBox5.Items.Add(dt.Rows(i).Item("RUT").ToString.Trim & " : " & dt1.Rows(0).Item("nombre").ToString.Trim & " : " & dt.Rows(i).Item("organizacion").ToString.Trim)

            Next


        End Using


    End Sub

    Private Sub TabPage2_Click(sender As System.Object, e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TabPage1_Click(sender As System.Object, e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then

            btnCrear.Enabled = True
            btnEditar.Enabled = True


            Dim id_os As String = ListView1.SelectedItems(0).SubItems(0).Text
            Using cnn As New SqlConnection(enlace)
                cnn.Open()

                Dim c As String = "Select * From INCLUSION where id_os = '" & id_os & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                ListView2.Items.Clear()
                Dim dt_diseno As New DataTable
                Dim item As New ListViewItem
                For i = 0 To dt.Rows.Count - 1

                    c = "SELECT * FROM DISENO WHERE ID_DISENO = '" & dt.Rows(i).Item("id_diseno").ToString.Trim & "'"
                    cmd = New SqlCommand(c, cnn)
                    da = New SqlDataAdapter(cmd)
                    dt_diseno = New DataTable
                    da.Fill(dt_diseno)




                    item = New ListViewItem(dt_diseno.Rows(0).Item("ID_DISENO").ToString)
                    item.SubItems.Add(dt_diseno.Rows(0).Item("NOMBRE_DISENO").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("COLOR").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("CANTIDAD").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("DETALLES_ADICIONALES").ToString)
                    ListView2.Items.Add(item)

                Next

            End Using

        Else

            ' btnCrear.Enabled = False
            btnEditar.Enabled = False

        End If
        
       


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim seleccion As String = obtenerID(ComboBox1.Text)
        ListView1.Items.Clear()
        ListView2.Items.Clear()

        Using cnn As New SqlConnection(enlace)
            cnn.Open()

            Dim c As String = "Select * From ORDEN_DE_SERVICIO where rut = '" & seleccion & "' and id_estado = '0'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            Dim item As New ListViewItem
            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("ID_OS").ToString.Trim)

                item.SubItems.Add(dt.Rows(i).Item("rut").ToString.Trim)


                item.SubItems.Add(dt.Rows(i).Item("COMENTARIO_OS").ToString.Trim)

                ListView1.Items.Add(item)

            Next

        End Using
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim seleccion As String = obtenerID(ComboBox2.Text)
        ListView3.Items.Clear()
        ListView4.Items.Clear()

        Using cnn As New SqlConnection(enlace)
            cnn.Open()

            Dim c As String = "Select * From ORDEN_DE_SERVICIO where rut = '" & seleccion & "' AND ID_ESTADO = '4'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            Dim item As New ListViewItem
            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("ID_OS").ToString)


                item.SubItems.Add(dt.Rows(i).Item("COMENTARIO_OS").ToString)

                ListView1.Items.Add(item)

            Next

        End Using
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        Dim seleccion As String = obtenerID(ComboBox5.Text)
        ListView10.Items.Clear()
        ListView9.Items.Clear()

        Using cnn As New SqlConnection(enlace)
            cnn.Open()

            Dim c As String = "Select * From ORDEN_DE_SERVICIO where rut = '" & seleccion & "' AND ID_ESTADO = '1'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            Dim item As New ListViewItem
            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("ID_OS").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("RUT").ToString.Trim)
                item.SubItems.Add(dt.Rows(i).Item("COMENTARIO_OS").ToString.Trim)

                ListView10.Items.Add(item)

            Next

        End Using
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
       
        Dim orden As String = ""

        If TabControl1.SelectedIndex = 0 Then

            orden = ListView1.SelectedItems(0).SubItems(0).Text

        ElseIf TabControl1.SelectedIndex = 1 Then

            orden = ListView4.SelectedItems(0).SubItems(0).Text

        ElseIf TabControl1.SelectedIndex = 2 Then
           
            orden = ListView6.SelectedItems(0).SubItems(0).Text

        ElseIf TabControl1.SelectedIndex = 3 Then

            orden = ListView8.SelectedItems(0).SubItems(0).Text

        Else

            orden = ListView10.SelectedItems(0).SubItems(0).Text

        End If


        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * from orden_de_servicio where id_os = '" & orden & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            ' Dim dt As New DataTable
            Dim dt As New DataTable
            da.Fill(dt)

            Mantener_Pedidos2.ComboBox2.Items.Clear()
            Mantener_Pedidos2.ComboBox2.Items.Add("Creada")
            Mantener_Pedidos2.ComboBox2.Items.Add("En proceso")
            Mantener_Pedidos2.ComboBox2.Items.Add("Pausada")
            Mantener_Pedidos2.ComboBox2.Items.Add("Finalizada")
            Mantener_Pedidos2.ComboBox2.Items.Add("Cancelada")



            Mantener_Pedidos2.TextBox4.Text = dt.Rows(0).Item("id_os").ToString.Trim & " : " & dt.Rows(0).Item("rut").ToString.Trim & " : " & dt.Rows(0).Item("comentario_os").ToString.Trim
            Mantener_Pedidos2.ComboBox2.SelectedIndex = CType(dt.Rows(0).Item("id_estado").ToString.Trim, Integer)
            'MsgBox(CType(dt.Rows(0).Item("id_estado").ToString.Trim, Integer))

            Mantener_Pedidos2.TextBox1.Text = dt.Rows(0).Item("comentario_os").ToString.Trim

        End Using
        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * from cliente where rut = '" & obtenerNombre(Mantener_Pedidos2.TextBox4.Text) & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            ' Dim dt As New DataTable
            Dim dt As New DataTable
            da.Fill(dt)

            Mantener_Pedidos2.TextBox2.Text = dt.Rows(0).Item("organizacion").ToString.Trim
        End Using

        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * from persona where rut = '" & obtenerNombre(Mantener_Pedidos2.TextBox4.Text) & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            ' Dim dt As New DataTable
            Dim dt As New DataTable
            da.Fill(dt)

            Mantener_Pedidos2.TextBox2.Text = Mantener_Pedidos2.TextBox2.Text & " : " & dt.Rows(0).Item("nombre").ToString.Trim
        End Using


        Me.Hide()

        Mantener_Pedidos2.Show()

    End Sub

    Private Sub btnCrear_Click(sender As System.Object, e As System.EventArgs) Handles btnCrear.Click
        Dim id_os As String = ""
        Dim cliente As String = ""
        Dim selecciono As Boolean = False




        If TabControl1.SelectedIndex = 0 Then

            If ListView1.SelectedItems.Count <> 1 Then
                MsgBox("Seleccione una orden para visualizar")
            Else
                id_os = ListView1.SelectedItems(0).SubItems(0).Text
                selecciono = True
            End If


        ElseIf TabControl1.SelectedIndex = 1 Then
            If ListView4.SelectedItems.Count <> 1 Then
                MsgBox("Seleccione una orden para visualizar")
            Else
                id_os = ListView4.SelectedItems(0).SubItems(0).Text
                selecciono = True
            End If

        ElseIf TabControl1.SelectedIndex = 2 Then
            If ListView6.SelectedItems.Count <> 1 Then
                MsgBox("Seleccione una orden para visualizar")
            Else
                id_os = ListView6.SelectedItems(0).SubItems(0).Text
                selecciono = True
            End If

        ElseIf TabControl1.SelectedIndex = 3 Then
            If ListView8.SelectedItems.Count <> 1 Then
                MsgBox("Seleccione una orden para visualizar")
            Else
                id_os = ListView8.SelectedItems(0).SubItems(0).Text
                selecciono = True
            End If

        Else
            If ListView10.SelectedItems.Count <> 1 Then
                MsgBox("Seleccione una orden para visualizar")
            Else
                id_os = ListView10.SelectedItems(0).SubItems(0).Text
                selecciono = True
            End If

        End If

        If selecciono Then
            Using cnn As New SqlConnection(enlace)
                cnn.Open()

                Dim c As String = "Select * from ORDEN_DE_SERVICIO where id_os = '" & id_os & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                Ver_Pedido.TextBox1.Text = dt.Rows(0).Item("id_os").ToString.Trim
                Ver_Pedido.TextBox13.Text = dt.Rows(0).Item("comentario_os").ToString.Trim
                c = "Select * from cliente where rut = '" & dt.Rows(0).Item("rut").ToString.Trim & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                Dim dt_cliente As New DataTable
                da.Fill(dt_cliente)

                Ver_Pedido.TextBox11.Text = dt_cliente.Rows(0).Item("organizacion").ToString.Trim


                c = "Select * from persona where rut = '" & dt.Rows(0).Item("rut").ToString.Trim & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                Dim dt_persona As New DataTable
                da.Fill(dt_persona)

                Ver_Pedido.TextBox2.Text = dt_persona.Rows(0).Item("rut").ToString.Trim & " : " & dt_persona.Rows(0).Item("nombre").ToString.Trim
                Ver_Pedido.TextBox5.Text = estado(dt.Rows(0).Item("id_estado").ToString.Trim)



            End Using

            Me.Hide()
            Ver_Pedido.Show()
        End If

       



    End Sub

    Private Sub ListView4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView4.SelectedIndexChanged
        If ListView4.SelectedItems.Count = 1 Then

            btnCrear.Enabled = True
            btnEditar.Enabled = True


            Dim id_os As String = ListView4.SelectedItems(0).SubItems(0).Text
            Using cnn As New SqlConnection(enlace)
                cnn.Open()

                Dim c As String = "Select * From INCLUSION where id_os = '" & id_os & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                ListView3.Items.Clear()
                Dim dt_diseno As New DataTable
                Dim item As New ListViewItem
                For i = 0 To dt.Rows.Count - 1

                    c = "SELECT * FROM DISENO WHERE ID_DISENO = '" & dt.Rows(i).Item("id_diseno").ToString.Trim & "'"
                    cmd = New SqlCommand(c, cnn)
                    da = New SqlDataAdapter(cmd)
                    dt_diseno = New DataTable
                    da.Fill(dt_diseno)




                    item = New ListViewItem(dt_diseno.Rows(0).Item("ID_DISENO").ToString)
                    item.SubItems.Add(dt_diseno.Rows(0).Item("NOMBRE_DISENO").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("COLOR").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("CANTIDAD").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("DETALLES_ADICIONALES").ToString)
                    ListView3.Items.Add(item)

                Next

            End Using

        Else

            ' btnCrear.Enabled = False
            btnEditar.Enabled = False

        End If
    End Sub

    Private Sub ListView6_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView6.SelectedIndexChanged
        If ListView6.SelectedItems.Count = 1 Then

            btnCrear.Enabled = True
            btnEditar.Enabled = True


            Dim id_os As String = ListView6.SelectedItems(0).SubItems(0).Text
            Using cnn As New SqlConnection(enlace)
                cnn.Open()

                Dim c As String = "Select * From INCLUSION where id_os = '" & id_os & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                ListView5.Items.Clear()
                Dim dt_diseno As New DataTable
                Dim item As New ListViewItem
                For i = 0 To dt.Rows.Count - 1

                    c = "SELECT * FROM DISENO WHERE ID_DISENO = '" & dt.Rows(i).Item("id_diseno").ToString.Trim & "'"
                    cmd = New SqlCommand(c, cnn)
                    da = New SqlDataAdapter(cmd)
                    dt_diseno = New DataTable
                    da.Fill(dt_diseno)




                    item = New ListViewItem(dt_diseno.Rows(0).Item("ID_DISENO").ToString)
                    item.SubItems.Add(dt_diseno.Rows(0).Item("NOMBRE_DISENO").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("COLOR").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("CANTIDAD").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("DETALLES_ADICIONALES").ToString)
                    ListView5.Items.Add(item)

                Next

            End Using

        Else

            ' btnCrear.Enabled = False
            btnEditar.Enabled = False

        End If
    End Sub

    Private Sub ListView8_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView8.SelectedIndexChanged
        If ListView8.SelectedItems.Count = 1 Then

            btnCrear.Enabled = True
            btnEditar.Enabled = True


            Dim id_os As String = ListView8.SelectedItems(0).SubItems(0).Text
            Using cnn As New SqlConnection(enlace)
                cnn.Open()

                Dim c As String = "Select * From INCLUSION where id_os = '" & id_os & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                ListView7.Items.Clear()
                Dim dt_diseno As New DataTable
                Dim item As New ListViewItem
                For i = 0 To dt.Rows.Count - 1

                    c = "SELECT * FROM DISENO WHERE ID_DISENO = '" & dt.Rows(i).Item("id_diseno").ToString.Trim & "'"
                    cmd = New SqlCommand(c, cnn)
                    da = New SqlDataAdapter(cmd)
                    dt_diseno = New DataTable

                    da.Fill(dt_diseno)




                    item = New ListViewItem(dt_diseno.Rows(0).Item("ID_DISENO").ToString)
                    item.SubItems.Add(dt_diseno.Rows(0).Item("NOMBRE_DISENO").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("COLOR").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("CANTIDAD").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("DETALLES_ADICIONALES").ToString)
                    ListView7.Items.Add(item)


                Next

            End Using

        Else

            ' btnCrear.Enabled = False
            btnEditar.Enabled = False

        End If
    End Sub

    Private Sub ListView10_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView10.SelectedIndexChanged
        If ListView10.SelectedItems.Count = 1 Then

            btnCrear.Enabled = True
            btnEditar.Enabled = True


            Dim id_os As String = ListView10.SelectedItems(0).SubItems(0).Text
            Using cnn As New SqlConnection(enlace)
                cnn.Open()

                Dim c As String = "Select * From INCLUSION where id_os = '" & id_os & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                ListView9.Items.Clear()
                Dim dt_diseno As New DataTable
                Dim item As New ListViewItem
                For i = 0 To dt.Rows.Count - 1

                    c = "SELECT * FROM DISENO WHERE ID_DISENO = '" & dt.Rows(i).Item("id_diseno").ToString.Trim & "'"
                    cmd = New SqlCommand(c, cnn)
                    da = New SqlDataAdapter(cmd)
                    dt_diseno = New DataTable
                    da.Fill(dt_diseno)




                    item = New ListViewItem(dt_diseno.Rows(0).Item("ID_DISENO").ToString)
                    item.SubItems.Add(dt_diseno.Rows(0).Item("NOMBRE_DISENO").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("COLOR").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("CANTIDAD").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("DETALLES_ADICIONALES").ToString)
                    ListView9.Items.Add(item)

                Next

            End Using

        Else

            ' btnCrear.Enabled = False
            btnEditar.Enabled = False

        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub
End Class