Imports System.Data.SqlClient

Public Class Crear_Usuario

    Private Sub Crear_Usuario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing


        '  Mantener_usuarios.initializecomponents()
        Mantener_usuarios.actualizar()

        Mantener_usuarios.Show()
        ' Mantener_usuarios.Update()






    End Sub

    Private Sub Crear_Usuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Administrador")
        ComboBox1.Items.Add("Vendedor")
        ComboBox1.Items.Add("Operador")
        ComboBox1.Items.Add("Cliente Web")

        ' ComboBox1.SelectedIndex = 
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        If TextBox3.Text = "" Then
            MsgBox("Ingrese el nombre completo")
        ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Ingrese contraseñas")
        ElseIf TextBox1.Text <> TextBox2.Text Then
            MsgBox("Las contraseñas no coinciden")
        ElseIf TextBox7.Text = "" Then
            MsgBox("Ingrese un nombre de usuario")
        ElseIf TextBox5.Text = "" Then
            MsgBox("Ingrese un correo")
        ElseIf TextBox6.Text = "" Then
            MsgBox("Ingrese un telefono")
        ElseIf ComboBox1.Text = "" Then
            MsgBox("Seleccione un cargo")

        Else
            Dim existe As Integer = 0
            Using cnn As New SqlConnection(enlace)
                cnn.Open()
                Dim c As String = "Select * From usuario where username = '" & TextBox7.Text & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                Else
                    existe = 1
                    MsgBox("Ya existe ese nombre de usuario pruebe con otro", MsgBoxStyle.Information, "Error")
                End If
            End Using
            If existe = 0 Then
                Dim cargo As Integer = 0
                If ComboBox1.SelectedIndex = 0 Then
                    cargo = 0
                ElseIf ComboBox1.SelectedIndex = 1 Then
                    cargo = 1
                ElseIf ComboBox1.SelectedIndex = 2 Then
                    cargo = 2
                Else
                    cargo = 3
                End If
                Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)
                Dim cmd As New System.Data.SqlClient.SqlCommand
                cmd.CommandType = System.Data.CommandType.Text
                Dim en As New Encriptar
                Dim pass, username As String
                username = TextBox7.Text
                pass = en.Cifrar(TextBox1.Text(), username)
                cmd.CommandText = "INSERT INTO USUARIO(username,password,nombre, mail, fono,cargo) VALUES ('" & username & "','" & pass & "','" & TextBox3.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & cargo & "')"
                cmd.Connection = sqlConnection1
                sqlConnection1.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MsgBox("Se ha creado el nuevo usuario " & TextBox7.Text & " exitosamente.", MsgBoxStyle.Information, "Informacion")
                    Modulo.insertar_auditoria(Modulo.usuario, "USUARIO", "INSERT INTO USUARIO(username,password,nombre, mail, fono,cargo) VALUES", "I", Date.Today, "", "")
                    TextBox1.Clear()
                    TextBox2.Clear()

                    TextBox3.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    TextBox7.Clear()



                Catch ex As Exception
                    MsgBox("Error en el ingreso de los datos", MsgBoxStyle.Information, "Error")
                End Try
                sqlConnection1.Close()
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




    End Sub
End Class