Imports System.Data.SqlClient

Public Class Login

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim ingreso As Integer = 0
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Ingrese usuario y contraseña")
        Else
            Dim en As New Encriptar
            Dim user As String = TextBox1.Text
            Dim pass As String = en.Cifrar(Me.TextBox2.Text, user)

            Using cnn As New SqlConnection(enlace)
                cnn.Open()

                Dim c As String = "Select * From Usuario where username = '" & user & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)


                If dt.Rows.Count = 0 Then
                    MsgBox("Nombre de Usuario Incorrecto", MsgBoxStyle.Information, "Error")
                Else
                    Dim passEnBD As String = dt.Rows(0).Item("PASSWORD").ToString.Trim
                    If passEnBD = pass Then

                        Dim cargo As Integer = dt.Rows(0).Item("cargo")
                        cargoUser = cargo
                        Modulo.usuario = user
                        Modulo.nombre = dt.Rows(0).Item("nombre").ToString.Trim

                        If cargo = 0 Then
                            Me.Hide()
                            Inicio_Administrador.Show()
                            ingreso = 1
                        ElseIf cargo = 1 Then
                            Me.Hide()
                            Inicio_Vendedor.Show()
                            ingreso = 1
                        ElseIf cargo = 2 Then
                            Me.Hide()
                            Inicio_Operador.Show()
                            ingreso = 1
                        Else
                            MsgBox("Nombre de Usuario Incorrecto", MsgBoxStyle.Information, "Error")
                            ingreso = 0
                        End If


                        If ingreso = 1 Then
                            '  cmd = New System.Data.SqlClient.SqlCommand()
                            ' cmd.CommandType = System.Data.CommandType.Text
                            ' cmd.CommandText = "INSERT INTO AUDITORIA (nombre_tabla,operacion,instruccion_sql,fecha_y_hora, usuario) VALUES ('" & "USUARIO' ,'" & "I','" & "Inicio_de_sesion" & "','" & Date.Today & "','" & user & "')"
                            ' cmd.Connection = cnn
                            '  Try
                            'cmd.ExecuteNonQuery()
                            '  Catch ex As Exception
                            'MsgBox(ex.ToString)

                            ' End Try
                        Else

                        End If
                        



                    Else
                        MsgBox("Contraseña incorrecta", MsgBoxStyle.Information, "Error")
                    End If
                End If

            End Using


        End If
    End Sub

    Private Sub Login_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Select()

    End Sub

    

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress

        If Asc(e.KeyChar) = Keys.Enter Then

            e.Handled = True

        End If

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If Asc(e.KeyChar) = Keys.Enter Then

            e.Handled = True

        End If

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
