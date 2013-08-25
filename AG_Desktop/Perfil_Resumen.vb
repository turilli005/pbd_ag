Public Class Perfil_Resumen

    Private Sub Perfil_Resumen_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Modulo.cargoUser = 0 Then
            Inicio_Administrador.Show()
        ElseIf Modulo.cargoUser = 1 Then
            Inicio_Vendedor.Show()
        Else
            Inicio_Operador.Show()


        End If
    End Sub

    Private Sub Perfil_Resumen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Button2.Enabled = False

    End Sub
End Class