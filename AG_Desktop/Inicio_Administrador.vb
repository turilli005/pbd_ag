Imports System.Data.SqlClient

Public Class Inicio_Administrador

    Private Sub Administrador_Inicio_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Me.Hide()
        Modulo.usuario = ""
        Modulo.cargoUser = 0

        Login.TextBox1.Clear()
        Login.TextBox2.Clear()
        Login.Show()
        Login.BringToFront()


    End Sub

    Private Sub Administrador_Inicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Label5.Text = Modulo.nombre

        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * from orden_de_servicio where id_estado = '0'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                PictureBox1.Image = My.Resources.uncheck
                Label1.Text = "Hay Pedidos Pendientes"

            Else

                PictureBox1.Image = My.Resources.Symbol___Check
                Label1.Text = "No Hay Pedidos Pendientes"


            End If

        End Using

    End Sub

    Private Sub MantenerClientesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MantenerClientesToolStripMenuItem.Click
        Me.Hide()
        Mantener_Clientes.Show()

    End Sub

    Private Sub MantenerProveedoresToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MantenerProveedoresToolStripMenuItem.Click
        Me.Hide()
        Mantener_Proveedores.Show()

    End Sub

    Private Sub MantenerPedidosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Hide()
        Mantener_Pedidos.Show()

    End Sub

    Private Sub MantenerUsuariosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MantenerUsuariosToolStripMenuItem.Click
        Me.Hide()
        Mantener_usuarios.Show()

    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click
        Me.Hide()
        Modulo.cargarPerfil()

        Perfil_Resumen.Show()

    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click
        Me.Hide()
        Modulo.usuario = ""
        Modulo.cargoUser = 0

        Login.TextBox1.Clear()
        Login.TextBox2.Clear()


        Login.Show()
        Login.TextBox1.Select()



    End Sub



    Private Sub MantenerMaterialesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub MantenerPuestosDeTrabajoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Mantener_Puestos.Show()

    End Sub

    Private Sub MantenerMaterialesToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles MantenerMaterialesToolStripMenuItem.Click
        Me.Hide()
        Mantener_Materiales.Show()

    End Sub

    Private Sub PedidosPausadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from ORDEN_DE_SERVICIO where id_estado = '2'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count = 0 Then
                MsgBox("No hay pedidos pausados", MsgBoxStyle.Information, "Informacion")
            Else
                Me.Hide()
                Mantener_Pausados.Show()
            End If






        End Using



    End Sub

    Private Sub TeóricosYConsumidosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TeóricosYConsumidosToolStripMenuItem.Click
        Me.Hide()
        Mantener_Reales.Show()

    End Sub

    Private Sub MantenerDiseñosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MantenerDiseñosToolStripMenuItem.Click
        Me.Hide()
        Mantener_disenos.Show()

    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()

        ver_informes.Show()

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub MantenerCategoríasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MantenerCategoríasToolStripMenuItem.Click
        Me.Hide()
        Mantener_Categorias.Show()

    End Sub

    Private Sub ProgramarRespaldoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProgramarRespaldoToolStripMenuItem.Click
        Me.Hide()
        Mantener_Respaldos.Show()

    End Sub

    Private Sub EjecutarRespaldoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EjecutarRespaldoToolStripMenuItem.Click
        Ejecutar_Respaldo.Show()

    End Sub

    Private Sub MantenerPedidosToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles MantenerPedidosToolStripMenuItem1.Click
        Me.Hide()
        Mantener_Pedidos.Show()
    End Sub

    Private Sub PedidosPausadosToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles PedidosPausadosToolStripMenuItem1.Click
        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from ORDEN_DE_SERVICIO where id_estado = '2'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count = 0 Then
                MsgBox("No hay pedidos pausados", MsgBoxStyle.Information, "Informacion")
            Else

                Me.Hide()
                Mantener_Pausados.Show()
            End If






        End Using
    End Sub

    Private Sub VerAuditoríaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerAuditoríaToolStripMenuItem.Click
        Me.Hide()
        Ver_Auditoria.Show()

    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Ver_Productos.Show()

    End Sub
End Class