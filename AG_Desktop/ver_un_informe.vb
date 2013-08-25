Imports System.Data.SqlClient

Public Class ver_un_informe

    Private Sub ver_un_informe_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Mantener_Pedidos.Show()

    End Sub

    Private Sub ver_un_informe_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim id_os As String = TextBox1.Text


            Dim c As String = "Select * from ORDEN_DE_SERVICIO where id_os = '" & id_os & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            TextBox13.Text = dt.Rows(0).Item("comentario_os").ToString.Trim

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

                TextBox6.Text = TextBox6.Text & i & ": " & dt_inclusion.Rows(i).Item("id_diseno").ToString.Trim & " : " & dt_diseno.Rows(0).Item("nombre_diseno").ToString.Trim & vbCr
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

    End Sub
End Class