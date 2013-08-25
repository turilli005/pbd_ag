Public Class Inicio_Vendedor

    Private Sub Inicio_Vendedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Modulo.usuario = ""
        Login.Show()

    End Sub

    Private Sub Inicio_Vendedor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click
        Me.Hide()
        Modulo.cargarPerfil()

        Perfil_Resumen.Show()

    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click
        Modulo.usuario = ""
        Login.TextBox1.Clear()
        Login.TextBox2.Clear()
        Login.TextBox1.Select()
        Me.Hide()

        Login.Show()

    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
        Crear_pedido.Show()

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Crear_Cliente.Show()

    End Sub

    Private Sub VerClientesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerClientesToolStripMenuItem.Click
        Me.Hide()

        Mantener_Clientes.Show()

    End Sub

   

    Private Sub MantenerPedidosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MantenerPedidosToolStripMenuItem.Click
        Me.Hide()
        Mantener_Pedidos.Show()

    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        Me.Hide()
        ver_informes.Show()


    End Sub

    Private Sub SeguirPedidoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SeguirPedidoToolStripMenuItem.Click
        Me.Hide()
        ver_informes.Show()

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

    
End Class