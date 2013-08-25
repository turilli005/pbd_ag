Public Class Crear_categoria

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TextBox3.Text = "" Or TextBox7.Text = "" Then
            MsgBox("No pueden haber campos vacíos")
        Else
            'INSERTAR


        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        TextBox3.Clear()
        TextBox7.Clear()

    End Sub
End Class