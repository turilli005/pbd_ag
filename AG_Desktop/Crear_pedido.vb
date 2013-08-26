Imports System.Data.SqlClient

Public Class Crear_pedido

    Private Sub Crear_pedido_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Inicio_Vendedor.Show()

    End Sub

    Private Sub Crear_pedido_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox2.Items.Add("Creada")
        ComboBox2.Items.Add("En Proceso")
        ComboBox2.Items.Add("Pausada")
        ComboBox2.Items.Add("Finalizada")
        ComboBox2.Items.Add("Eliminada")

        GroupBox1.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False



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


        'cargar CB de clientes
        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * FROM Cliente C, Persona P where C.rut = P.rut"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            For i = 0 To dt.Rows.Count - 1

                If dt.Rows(i).Item("organizacion").ToString.Trim <> "0" Then
                    ComboBox1.Items.Add(dt.Rows(i).Item("Rut").ToString.Trim & " : " & dt.Rows(i).Item("Nombre").ToString.Trim & " : " & dt.Rows(i).Item("organizacion").ToString.Trim)
                Else

                End If


            Next
        End Using



        'Listview1

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim cliente_rut As String = ComboBox1.Text
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

        Crear_Inclusion.TextBox10.Text = cliente_rut
        Crear_Inclusion.TextBox7.Text = fecha_ini
        Crear_Inclusion.TextBox9.Text = fecha_fin
        Crear_Inclusion.TextBox8.Text = ComboBox2.Text
        Crear_Inclusion.TextBox11.Text = "Sin asignar"

        Me.Hide()
        Crear_Inclusion.Show()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text <> "" Then
            GroupBox1.Enabled = True

        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'MsgBox(ListView1.Items.Count)

        If ListView1.Items.Count = 0 Then
            Dim Box As MsgBoxResult = MsgBox("Creará un pedido sin inclusiones. Está seguro?", MsgBoxStyle.YesNo)
            If Box = MsgBoxResult.Yes Then

                Dim rut As String = obtenerID(ComboBox1.Text)
                Dim INI As String = DateTimePicker1.Value.ToString
                Dim estado1 As String = estado_a_int(ComboBox2.Text)

                Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)

                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                cmd.CommandText = "INSERT INTO ORDEN_DE_SERVICIO (ID_ESTADO ,RUT,COMENTARIO_OS, FECHA_INICIO) VALUES ('" & estado1 & "' , '" & CType(rut, Integer) & "','" & TextBox1.Text & "','" & INI & "')"

                cmd.Connection = sqlConnection1
                sqlConnection1.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MsgBox("Orden creada exitosamente", MsgBoxStyle.Information, "Informacion")
                    Modulo.insertar_auditoria(Modulo.usuario, "ORDEN_DE_SERVICIO", "INSERT INTO ORDEN_DE_SERVICIO VALUES", "I", Date.Today, "", "")

                Catch ex As Exception
                    MsgBox("Error en el ingreso de los datos de la orden", MsgBoxStyle.Information, "Error")
                End Try
                sqlConnection1.Close()
            Else

            End If
        Else
            'crear orden e inclusiones
            Dim rut As String = obtenerID(ComboBox1.Text)

            Dim estado1 As String = estado_a_int(ComboBox2.Text)

            Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)

            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "INSERT INTO ORDEN_DE_SERVICIO (ID_ESTADO ,RUT,COMENTARIO_OS, FECHA_INICIO) VALUES ('" & estado1 & "' , '" & CType(rut, Integer) & "','" & TextBox1.Text & "','" & DateTimePicker1.Value.ToString & "')"

            cmd.Connection = sqlConnection1
            sqlConnection1.Open()
            Dim orden_ingresada As Boolean = False

            Dim id_ORDEN_actual As Integer = 0
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Orden creada exitosamente")
                Modulo.insertar_auditoria(Modulo.usuario, "ORDEN_DE_SERVICIO", "INSERT INTO ORDEN_DE_SERVICIO VALUES", "I", Date.Today, "", "")
                Dim sqlIdentity As String = "SELECT @@IDENTITY FROM ORDEN_DE_SERVICIO"
                Dim cmdIdentity As New SqlCommand(sqlIdentity, sqlConnection1)
                cmd.CommandType = CommandType.Text
                cmd.Connection = sqlConnection1
                id_ORDEN_actual = Convert.ToInt32(cmdIdentity.ExecuteScalar())
                orden_ingresada = True
            Catch ex As Exception
                MsgBox("Error en el ingreso de los datos de la orden", MsgBoxStyle.Information, "Error")
            End Try

            'ARREGLAR
            'AQUI TENIA +2

            sqlConnection1.Close()


            Using cnn As New SqlConnection(enlace)

                Dim c As String = "Select * from orden_de_servicio where rut = '" & rut & "' and fecha_inicio = '" & DateTimePicker1.Value.ToString & "'"
                cmd = New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    id_ORDEN_actual = CType(dt.Rows(0).Item("id_os").ToString.Trim, Integer)
                    'MsgBox(id_ORDEN_actual)

                Else
                    MsgBox("No encontro", MsgBoxStyle.Information, "Error")

                End If



            End Using
            




            ComboBox1.SelectedItem = Nothing
            ComboBox2.SelectedItem = Nothing
            TextBox1.Clear()
            Dim insercion_inclusiones As Boolean = True
            If orden_ingresada Then
                For i = 0 To ListView1.Items.Count - 1
                    ' MsgBox("PERRITO")
                    cmd = New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = sqlConnection1
                    sqlConnection1.Open()

                    Dim id_diseno, cantidad, color, detalles As String
                    id_diseno = ListView1.Items(i).SubItems(0).Text
                    cantidad = ListView1.Items(i).SubItems(2).Text
                    color = ListView1.Items(i).SubItems(6).Text
                    detalles = ListView1.Items(i).SubItems(7).Text

                    cmd.CommandText = "INSERT INTO INCLUSION (ID_OS ,ID_DISENO,COLOR, CANTIDAD, DETALLES_ADICIONALES) VALUES ('" & id_ORDEN_actual & "' , '" & id_diseno & "','" & color & "','" & cantidad & "' , '" & detalles & "')"

                    'MsgBox(cmd.CommandText)

                    Try
                        cmd.ExecuteNonQuery()
                        Modulo.insertar_auditoria(Modulo.usuario, "INCLUSION", "INSERT INTO ORDEN_DE_SERVICIO VALUES", "I", Date.Today, "", "")
                    Catch ex As Exception
                        insercion_inclusiones = False
                    End Try

                    sqlConnection1.Close()
                Next
                If insercion_inclusiones = True Then
                    MsgBox("Inclusiones ingresadas exitosamente. Pedido ingresado al Sistema", MsgBoxStyle.Information, "Informacion")
                    ListView1.Items.Clear()
                    TextBox1.Clear()
                    ComboBox1.SelectedItem = Nothing
                    ComboBox2.SelectedItem = Nothing
                    Me.Hide()

                    'INSERTAR EN REPORTE_PRODUCCION POR CADA INCLUSION
                    ' ID_REPORTE_PRODUCCION ID_OS ID_DISENO INFORMACION_PRODUCCION PORCENTAJE_AVANCE
                    If Modulo.cargoUser = 0 Then
                        Inicio_Administrador.Show()

                    Else
                        Inicio_Vendedor.Show()

                    End If

                Else
                    MsgBox("No se ingresaron las inclusiones", MsgBoxStyle.Information, "Error")

                End If
            Else

            End If

           

            

            

        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text <> "" Then
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True

        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("Seleccione inclusiones para remover del pedido", MsgBoxStyle.Information, "Error")
        Else
            Dim mb As MsgBoxResult = MsgBox("Esta seguro de remover las inclusiones seleccionadas?", MsgBoxStyle.YesNo)
            If mb = MsgBoxResult.Yes Then
                For i = 0 To ListView1.CheckedItems.Count - 1
                    ListView1.CheckedItems.Item(0).Remove()

                Next

            End If
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        'MsgBox(DateTimePicker2.Value & " " & DateTimePicker1.Value)
        ' If DateTimePicker2.Value > DateTimePicker1.Value Then

        'Button1.Enabled = False
        'Button2.Enabled = False
        'Button3.Enabled = False

        '        MsgBox("Seleccione una fecha posterior a la de inicio")
        '       Else
        '      Button1.Enabled = True
        '     Button2.Enabled = True
        ''    Button3.Enabled = True

        'End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        Modulo.ultimo_form = "Crear_pedido"
        Crear_Cliente.Show()

    End Sub
End Class