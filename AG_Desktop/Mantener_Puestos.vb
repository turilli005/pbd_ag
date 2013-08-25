Imports System.Data.SqlClient

Public Class Mantener_Puestos

    Dim accion As String = "Nada"

    Private Sub Mantener_Puestos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Modulo.cargoUser = 0 Then
            Inicio_Administrador.Show()
        ElseIf Modulo.cargoUser = 1 Then
            Inicio_Vendedor.Show()
        Else
            Inicio_Operador.Show()

        End If
        accion = "Nada"
    End Sub

 

   

    

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        If PictureBox1.BorderStyle = BorderStyle.None Then
            PictureBox1.BorderStyle = BorderStyle.Fixed3D
        Else
            PictureBox1.BorderStyle = BorderStyle.None

        End If
    End Sub
End Class