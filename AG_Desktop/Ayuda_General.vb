Public Class Ayuda_General
    Dim pagina As Integer
    Private Sub AtrasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AtrasToolStripMenuItem.Click



    End Sub

    Private Sub Ayuda_General_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AtrasToolStripMenuItem.Image = My.Resources.back
        NextToolStripMenuItem.Image = My.Resources._next
        pagina = 0


    End Sub

    Private Sub TabPage2_Click(sender As System.Object, e As System.EventArgs) Handles TabPage2.Click
        'TabPage2.Text = "Nueva pestaña"


    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then


            TabPage2.Text = "Nueva Pestaña"
            'TabPage'()


        End If
    End Sub




    Private Sub TabControl1_TabIndexChanged(sender As Object, e As System.EventArgs) Handles TabControl1.TabIndexChanged

       


    End Sub

    Private Sub TabPage1_Click(sender As System.Object, e As System.EventArgs) Handles TabPage1.Click

    End Sub
End Class
