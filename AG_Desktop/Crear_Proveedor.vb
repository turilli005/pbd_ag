Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Crear_Proveedor

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
    End Sub

    Private Sub Crear_Proveedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Mantener_Proveedores.Show()

    End Sub

    Private Sub Crear_Proveedor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
                    Dim c As String = "Select * from proveedor where  rut = '" & rut & "'"

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
                            MsgBox("Campos vacíos. Debe ingresar toda la información.", MsgBoxStyle.Information, "Error")
                        ElseIf IsNumeric(fono) = False Then
                            MsgBox("Ingrese el teléfono sólo con números", MsgBoxStyle.Information, "Error")

                        ElseIf Regex.IsMatch(mail, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") = False Then
                            MsgBox("Ingrese un correo electrónico válido", MsgBoxStyle.Information, "Error")

                        Else

                            insertar = True
                        End If



                    Else
                        MsgBox("Ya existe un proveedor con el rut ingresado", MsgBoxStyle.Information, "Error")
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
                        '''' 'MsgBox("Se ha creado el nuevo cliente " & nombre & " exitosamente.")
                    Catch ex As Exception
                        MsgBox("Error en el ingreso de los datos de persona", MsgBoxStyle.Information, "Error")

                    End Try

                    cmd = New SqlCommand
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "INSERT INTO PROVEEDOR(rut,informacion_adicional) VALUES ('" & CType(rut, Integer) & "','" & organizacion & "')"
                    cmd.Connection = sqlConnection1


                    Try
                        cmd.ExecuteNonQuery()
                        MsgBox("Se ha creado el nuevo proveedor " & nombre & " exitosamente.", MsgBoxStyle.Information, "Informacion")
                        Me.Hide()
                       
                        Mantener_Proveedores.Show()




                    Catch ex As Exception
                        MsgBox("Error en el ingreso de los datos de proveedor", MsgBoxStyle.Information, "Error")

                    End Try

                    sqlConnection1.Close()

                End If

            Else

                MsgBox("Ingrese un valor numerico para el rut", MsgBoxStyle.Information, "Error")

            End If
        End If
    End Sub
End Class