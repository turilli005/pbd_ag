Imports System.Data.SqlClient
Public Class ver_informes

    Private Sub ver_informes_FontChanged(sender As Object, e As System.EventArgs) Handles Me.FontChanged
        If Modulo.cargoUser = 0 Then
            Inicio_Administrador.Show()
        Else
            Inicio_Vendedor.Show()

        End If


    End Sub

    Private Sub ver_informes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Modulo.cargoUser = 0 Then
            Inicio_Administrador.Show()
        Else
            Inicio_Vendedor.Show()

        End If
    End Sub

    Private Sub ver_informes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from ORDEN_DE_SERVICIO"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)




            For i = 0 To dt.Rows.Count - 1

                ComboBox1.Items.Add(dt.Rows(i).Item("ID_OS").ToString.Trim & " : " & dt.Rows(i).Item("RUT").ToString.Trim & " : " & estado(dt.Rows(i).Item("ID_ESTADO").ToString.Trim) & " : " & dt.Rows(i).Item("COMENTARIO_OS").ToString.Trim)

            Next



        End Using
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox6.Clear()

        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim id_os As String = obtenerID(ComboBox1.Text)

            Dim c As String = "Select * from ORDEN_DE_SERVICIO where id_os = '" & id_os & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            TextBox1.Text = dt.Rows(0).Item("id_os").ToString.Trim
            TextBox7.Text = dt.Rows(0).Item("comentario_os").ToString.Trim

            c = "Select * from cliente where rut = '" & dt.Rows(0).Item("rut").ToString.Trim & "'"
            cmd = New SqlCommand(c, cnn)
            da = New SqlDataAdapter(cmd)
            Dim dt_cliente As New DataTable
            da.Fill(dt_cliente)

            TextBox11.Text = dt_cliente.Rows(0).Item("organizacion").ToString.Trim


            c = "Select * from persona where rut = '" & dt.Rows(0).Item("rut").ToString.Trim & "'"
            cmd = New SqlCommand(c, cnn)
            da = New SqlDataAdapter(cmd)
            Dim dt_persona As New DataTable
            da.Fill(dt_persona)

            TextBox2.Text = dt_persona.Rows(0).Item("rut").ToString.Trim & " : " & dt_persona.Rows(0).Item("nombre").ToString.Trim
            TextBox5.Text = estado(dt.Rows(0).Item("id_estado").ToString.Trim)

            c = "Select * from inclusion where id_os = '" & id_os & "'"
            cmd = New SqlCommand(c, cnn)
            da = New SqlDataAdapter(cmd)
            Dim dt_inclusion As New DataTable
            da.Fill(dt_inclusion)
            Dim dt_diseno As New DataTable
            Dim dt_reporte As New DataTable
            For i = 0 To dt_inclusion.Rows.Count - 1
                c = "Select * from diseno where id_diseno = '" & dt_inclusion.Rows(i).Item("id_diseno").ToString.Trim & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                dt_diseno = New DataTable

                da.Fill(dt_diseno)

                TextBox6.Text = TextBox6.Text & dt_inclusion.Rows(i).Item("id_diseno").ToString.Trim & " : " & dt_diseno.Rows(0).Item("nombre_diseno").ToString.Trim & vbCr
                dt_reporte = New DataTable

                c = "Select * from reporte_produccion where id_os = '" & id_os & "' and id_diseno = '" & dt_inclusion.Rows(i).Item("id_diseno").ToString.Trim & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                da.Fill(dt_reporte)


                TextBox6.Text = TextBox6.Text & " " & dt_reporte.Rows(0).Item("porcentaje_avance").ToString.Trim & "%" & vbCrLf
                TextBox6.Text = TextBox6.Text & "--------------------------------" & vbCrLf & vbCrLf
                If dt_reporte.Rows(0).Item("porcentaje_avance").ToString.Trim = "0" Then

                    TextBox6.Text = TextBox6.Text & "Inclusión se encuentra en etapa de Diseño" & vbCrLf

                ElseIf dt_reporte.Rows(0).Item("porcentaje_avance").ToString.Trim = "25" Then

                    TextBox6.Text = TextBox6.Text & "Etapa de Diseño finalizada." & vbCrLf & "Inclusión se encuentra en etapa de Compra de Materiales" & vbCrLf

                ElseIf dt_reporte.Rows(0).Item("porcentaje_avance").ToString.Trim = "50" Then

                    TextBox6.Text = TextBox6.Text & "Etapa de Diseño finalizada." & vbCrLf & "Compra de Materiales finalizada." & vbCrLf & "Inclusión se encuentra en etapa de Cortes" & vbCrLf

                ElseIf dt_reporte.Rows(0).Item("porcentaje_avance").ToString.Trim = "75" Then

                    TextBox6.Text = TextBox6.Text & "Etapa de Diseño finalizada." & vbCrLf & "Compra de Materiales finalizada." & vbCrLf & "Etapa de Corte finalizada." & vbCrLf & "Inclusión se encuentra en etapa de Confección" & vbCrLf

                Else

                    TextBox6.Text = TextBox6.Text & "Etapa de Diseño finalizada." & vbCrLf
                    TextBox6.Text = TextBox6.Text & "Compra de Materiales finalizada." & vbCrLf
                    TextBox6.Text = TextBox6.Text & "Etapa de Corte finalizada." & vbCrLf
                    TextBox6.Text = TextBox6.Text & "Etapa de Confección finalizada." & vbCrLf




                End If
                TextBox6.Text = TextBox6.Text & "--------------------------------" & vbCrLf & vbCrLf

            Next


        End Using
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        'TextBox6.Clear()
        Dim id_os As String = obtenerID(ComboBox1.Text)
        Dim c As String = "declare @id_os int set @id_os = " & id_os & " exec generar_informe @id_os"

        If ComboBox1.Text = "" Then

            MsgBox("Seleccione una Orden")

        Else
            Using cnn As New SqlConnection(enlace)
                cnn.Open()
                Dim cmd As New SqlCommand '("generar_informe", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "generar_informe"
                cmd.Connection = cnn
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@id_os", Data.SqlDbType.NVarChar)
                cmd.Parameters("@id_os").Value = id_os
                cmd.Parameters.Add("@info_msj ", SqlDbType.VarChar, 1024)
                cmd.Parameters("@info_msj ").Direction = ParameterDirection.Output
                Dim retorno As String = ""
                Try
                    cmd.ExecuteNonQuery()
                    retorno = cmd.Parameters("@info_msj ").Value
                    'MsgBox(retorno)

                Catch ex As Exception
                    ' MsgBox(ex.ToString)

                End Try
            End Using

        End If


       
    End Sub
End Class