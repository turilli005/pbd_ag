Imports System.Data.SqlClient

Public Class crear_diseno

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        If TextBox2.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox5.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Debe llenar todos los campos del nuevo diseño", MsgBoxStyle.Information, "Error")
       
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
            Dim val As String = TextBox2.Text & "','" & TextBox6.Text & "','" & genero & "','" & tallaje & "','" & TextBox5.Text
            cmd.CommandText = "INSERT INTO DISENO (nombre_diseno,descripcion_diseno, genero_diseno, tallaje, descripcion_tallaje) VALUES ('" & TextBox2.Text & "','" & TextBox6.Text & "','" & genero & "','" & tallaje & "','" & TextBox5.Text & "')"
            cmd.Connection = sqlConnection1
            sqlConnection1.Open()

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Diseño creado exitosamente.", MsgBoxStyle.Information, "Informacion")
                Modulo.insertar_auditoria(Modulo.usuario, "DISENO", "INSERT INTO DISENO (nombre_diseno,descripcion_diseno, genero_diseno, tallaje, descripcion_tallaje) VALUES", "I", Date.Today, "", "")

                   



            Catch ex As Exception
                ' MsgBox(ex.ToString)
                MsgBox("Error en el ingreso de los datos de diseño", MsgBoxStyle.Information, "Error")

            End Try


            'INSERTAR EN CATEGORIZACION
            cmd = New SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            'cmd.CommandText = "INSERT INTO CATEGORIZACION (ID_CATEGORIA,ID_DISENO) VALUES ('"& obtenerID(ComboBox1.text) & "','" & 

            sqlConnection1.Close()
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
                    sqlConnection1.Close()
                    TextBox2.Clear()
                    TextBox6.Clear()
                    TextBox5.Clear()


                    ComboBox2.SelectedItem = Nothing
                    ComboBox3.SelectedItem = Nothing
                Else

                End If
            End Using

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Mantener_disenos.Show()

    End Sub

    Private Sub crear_diseno_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Mantener_disenos.Show()

    End Sub

    Private Sub crear_diseno_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave

    End Sub

    Private Sub crear_diseno_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("Hombre")
        ComboBox2.Items.Add("Mujer")
        ComboBox2.Items.Add("Universal")

        ComboBox3.Items.Clear()
        ComboBox3.Items.Add("Adulto")
        ComboBox3.Items.Add("Niño")


        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * from categoria"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            ComboBox1.Items.Clear()

            For i = 0 To dt.Rows.Count - 1
                ComboBox1.Items.Add(dt.Rows(i).Item("id_categoria").ToString.Trim & " : " & dt.Rows(i).Item("Nombre_categoria").ToString.Trim)


            Next

        End Using




    End Sub

    Private Sub GroupBox2_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class