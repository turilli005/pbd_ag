
Imports System.Data.SqlClient

Public Class Inicio_Operador

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Mantener_Teoricos.Show()


    End Sub

    Private Sub PedidosEnCursoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Ver_Pedido.labelEstado.Text = "* Pedidos en Curso"
        Ver_Pedido.Show()


    End Sub

    Private Sub PedidosFinalizadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Ver_Pedido.labelEstado.Text = "* Pedidos Finalizados"
        Ver_Pedido.Show()
    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click
        Me.Hide()
        Modulo.usuario = ""
        Modulo.cargoUser = 0

        Login.TextBox1.Clear()
        Login.TextBox2.Clear()


        Login.Show()
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click
        Me.Hide()
        Perfil_Resumen.Show()
    End Sub

    Private Sub Operador_Inicio_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        Modulo.usuario = ""
        Modulo.cargoUser = 0

        Login.TextBox1.Clear()
        Login.TextBox2.Clear()
        Login.Show()
    End Sub

    Private Sub Operador_Inicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from ORDEN_DE_SERVICIO where id_estado = '0'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Label8.Text = "Pedidos con Programación Pendiente"
                PictureBox4.Image = My.Resources.uncheck
            Else
                Label8.Text = "No Hay Pedidos Pendientes"
                PictureBox4.Image = My.Resources.Symbol___Check
            End If
        End Using
    End Sub

    Private Sub MantenerRealesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MantenerRealesToolStripMenuItem.Click
        Me.Hide()
        Mantener_Reales.Show()

    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()

        ver_informes.Show()

    End Sub

    Private Sub VerMaterialesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerMaterialesToolStripMenuItem.Click
        Me.Hide()
        Mantener_Materiales.Show()

    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Avance_Pedido.Show()

    End Sub

    Private Sub ActualizarPedidoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ActualizarPedidoToolStripMenuItem.Click
        Me.Hide()
        Avance_Pedido.Show()
    End Sub

    Private Sub VerPedidosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerPedidosToolStripMenuItem.Click
        Me.Hide()
        Mantener_Pedidos.Show()

    End Sub

    Private Sub PedidosPausadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PedidosPausadosToolStripMenuItem.Click
        Me.Hide()
        Mantener_Pausados.Show()

    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.BorderStyle = BorderStyle.Fixed3D

    End Sub


    Private Sub PictureBox1_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BorderStyle = BorderStyle.None

    End Sub
    Private Sub PictureBox2_MouseHover(sender As Object, e As System.EventArgs) Handles PictureBox2.MouseHover
        PictureBox2.BorderStyle = BorderStyle.Fixed3D

    End Sub


    Private Sub PictureBox2_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.BorderStyle = BorderStyle.None

    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.BorderStyle = BorderStyle.Fixed3D

    End Sub


    Private Sub PictureBox3_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.BorderStyle = BorderStyle.None

    End Sub

    Private Sub Inicio_Operador_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from ORDEN_DE_SERVICIO where id_estado = '0'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Label8.Text = "Pedidos con Programación Pendiente"
                PictureBox4.Image = My.Resources.uncheck
            Else
                Label8.Text = "No Hay Pedidos Pendientes"
                PictureBox4.Image = My.Resources.Symbol___Check
            End If
        End Using
    End Sub
End Class