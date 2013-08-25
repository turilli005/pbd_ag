Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Crear_Cliente

    Private Sub Crear_Cliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If Modulo.cargoUser = 0 Then

        ''PREGUNTAR CUAL FUE EL FORM ANTERIOR
        If Modulo.ultimo_form = "Crear_pedido" Then
            Crear_pedido.Show()

        Else
            Mantener_Clientes.Show()
        End If


        ' End If
    End Sub

    Private Sub Crear_Cliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim rut As String = TextBox7.Text
        Dim insertar As Boolean = False

        Dim nombre, region, ciudad, direccion, mail, fono, organizacion As String

        If rut.Length < 8 Or rut.Length > 9 Then
            MsgBox("El rut debe tener 8 o 9 digitos", MsgBoxStyle.Information, "Error")
        Else
            If IsNumeric(rut) Then
                Using cnn As New SqlConnection(enlace)
                    cnn.Open()
                    Dim c As String = "Select * from cliente where  rut = '" & rut & "'"

                    Dim cmd As New SqlCommand(c, cnn)
                    cmd.CommandType = CommandType.Text
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    da.Fill(dt)

                    If dt.Rows.Count = 0 Then
                        'insertar

                        nombre = TextBox3.Text
                        region = ComboBox1.Text
                        ciudad = TextBox8.Text
                        direccion = TextBox1.Text
                        mail = TextBox5.Text
                        fono = TextBox6.Text
                        organizacion = TextBox2.Text

                        If nombre = "" Or region = "" Or ciudad = "" Or direccion = "" Or mail = "" Or fono = "" Or organizacion = "" Then
                            MsgBox("Campos vacíos. Debe ingresar toda la información.")
                        ElseIf IsNumeric(fono) = False Then
                            MsgBox("Ingrese el teléfono sólo con números", MsgBoxStyle.Information, "Error")

                        ElseIf Regex.IsMatch(mail, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") = False Then
                            MsgBox("Ingrese un correo electrónico válido", MsgBoxStyle.Information, "Error")

                        Else

                            insertar = True
                        End If



                    Else
                        MsgBox("Ya existe un cliente con el rut ingresado", MsgBoxStyle.Information, "Error")
                    End If


                End Using

                If insertar Then

                    Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)

                    Dim cmd As New System.Data.SqlClient.SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "INSERT INTO PERSONA (rut,nombre,region, ciudad, direccion, mail,telefono) VALUES ('" & CType(rut, Integer) & "','" & nombre & "','" & region & "','" & ciudad & "','" & direccion & "','" & mail & "','" & CType(fono, Integer) & "')"
                    cmd.Connection = sqlConnection1



                    sqlConnection1.Open()

                    Try
                        cmd.ExecuteNonQuery()
                        Modulo.insertar_auditoria(Modulo.usuario, "PERSONA", "INSERT INTO PERSONA (rut,nombre,region, ciudad, direccion, mail,telefono) VALUES", "I", Date.Today, "", "")


                        '''' 'MsgBox("Se ha creado el nuevo cliente " & nombre & " exitosamente.")
                    Catch ex As Exception
                        MsgBox("Error en el ingreso de los datos de persona", MsgBoxStyle.Information, "Error")

                    End Try

                    cmd = New SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "INSERT INTO CLIENTE(rut,organizacion) VALUES ('" & CType(rut, Integer) & "','" & organizacion & "')"
                    cmd.Connection = sqlConnection1


                    Try
                        cmd.ExecuteNonQuery()
                        MsgBox("Se ha creado el nuevo cliente " & nombre & " exitosamente. Ahora deberá completar el nuevo pedido.", MsgBoxStyle.Information, "Informacion")
                        Modulo.insertar_auditoria(Modulo.usuario, "CLIENTE", "INSERT INTO CLIENTE(rut,organizacion) VALUES", "I", Date.Today, "", "")
                        Me.Hide()

                        cmd = New SqlCommand
                        cmd.CommandType = System.Data.CommandType.Text
                        'cmd.CommandText = "INSERT INTO USUARIO(rut,organizacion) VALUES ('" & CType(rut, Integer) & "','" & organizacion & "')"
                        cmd.Connection = sqlConnection1
                        Dim pass As String = rut
                        cmd.CommandText = "INSERT INTO USUARIO(username,password,nombre, mail, fono,cargo) VALUES ('" & CType(rut, Integer) & "','" & pass & "','" & nombre & "','" & mail & "','" & fono & "','" & 3 & "')"

                        Try
                            MsgBox(cmd.CommandText)
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try


                        Using cnn As New SqlConnection(enlace)

                            cnn.Open()
                            Dim c As String = "Select * From Cliente where organizacion <> '0'"
                            cmd = New SqlCommand(c, cnn)
                            cmd.CommandType = CommandType.Text
                            Dim da As New SqlDataAdapter(cmd)
                            ' Dim dt As New DataTable
                            Dim dt As New DataTable
                            da.Fill(dt)
                            Mantener_Clientes.ListView1.Items.Clear()
                            'Mantener_Clientes.ListView1.Items
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

                                Mantener_Clientes.ListView1.Items.Add(item)
                            Next

                        End Using
                        '  Mantener_Clientes.Show()

                        'Crear_pedido.Show()

                        Using cnn As New SqlConnection(enlace)
                            cnn.Open()
                            Dim c As String = "Select * From ORDEN_DE_SERVICIO where rut = '" & TextBox7.Text & "'"
                            cmd = New SqlCommand(c, cnn)
                            cmd.CommandType = CommandType.Text
                            Dim da As New SqlDataAdapter(cmd)
                            ' Dim dt As New DataTable
                            Dim dt As New DataTable
                            da.Fill(dt)


                            Mantener_Pedidos2.TextBox4.Text = dt.Rows(0).Item("id_os").ToString.Trim & " : " & dt.Rows(0).Item("rut").ToString.Trim & " : " & dt.Rows(0).Item("comentario_os").ToString.Trim
                            ' Mantener_Pedidos2.TextBox2.Text = dt.Rows(0).Item("organizacion").ToString.Trim
                        End Using

                        'preguntar ultima ventana vista!


                        Mantener_Pedidos2.ComboBox2.Items.Clear()
                        Mantener_Pedidos2.ComboBox2.Items.Add("Creada")
                        Mantener_Pedidos2.ComboBox2.Items.Add("En proceso")
                        Mantener_Pedidos2.ComboBox2.Items.Add("Pausada")
                        Mantener_Pedidos2.ComboBox2.Items.Add("Finalizada")
                        Mantener_Pedidos2.ComboBox2.Items.Add("Cancelada")
                        Mantener_Pedidos2.ComboBox2.SelectedIndex = 0
                        Mantener_Pedidos2.TextBox2.Text = TextBox2.Text

                        Mantener_Pedidos2.Show()





                    Catch ex As Exception
                        MsgBox("Error en el ingreso de los datos de cliente", MsgBoxStyle.Information, "Error")

                    End Try

                        sqlConnection1.Close()

                End If

            Else

                MsgBox("Ingrese un valor numerico para el rut", MsgBoxStyle.Information, "Error")

            End If
        End If

        





    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()

    End Sub
End Class