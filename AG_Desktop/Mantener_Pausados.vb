Imports System.Data.SqlClient

Public Class Mantener_Pausados

    Private Sub Mantener_Pausados_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Modulo.cargoUser = 0 Then
            Inicio_Administrador.Show()
        Else
            Inicio_Operador.Show()

        End If
    End Sub

    Private Sub Mantener_Pausados_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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

        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from ORDEN_DE_SERVICIO where id_estado = '2'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count = 0 Then
                MsgBox("No hay pedidos pausados")
            End If


            Dim item As New ListViewItem
            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("ID_OS").ToString.Trim)

                item.SubItems.Add(dt.Rows(i).Item("rut").ToString.Trim)


                item.SubItems.Add(dt.Rows(i).Item("COMENTARIO_OS").ToString.Trim)

                ListView1.Items.Add(item)

            Next



        End Using
    End Sub
End Class