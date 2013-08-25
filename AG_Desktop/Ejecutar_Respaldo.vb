Public Class Ejecutar_Respaldo

    Private Sub Ejecutar_Respaldo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Inicio_Administrador.Show()

    End Sub

    Private Sub Ejecutar_Respaldo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Completo")
        ComboBox1.Items.Add("Clientes y Pedidos")
        ComboBox1.Items.Add("Materiales y Proveedores")

        TextBox7.Text = Modulo.usuario & " : " & Modulo.nombre
        ComboBox1.SelectedIndex = 0
        ComboBox1.Enabled = False


    End Sub

    Private Sub TextBox7_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If TextBox6.Text = "" Then
            MsgBox("Ingrese comentarios")
        Else
            'RESPALDAR!!!!



        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        TextBox7.Clear()
        TextBox6.Clear()
        Me.Close()

    End Sub
End Class