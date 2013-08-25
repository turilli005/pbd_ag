Imports System.IO

Public Class Mantener_Respaldos

    Private Sub GroupBox1_Click(sender As Object, e As System.EventArgs) Handles GroupBox1.Click
        Me.Hide()
        Ejecutar_Respaldo.Show()
    End Sub

    Private Sub GroupBox1_DoubleClick(sender As Object, e As System.EventArgs) Handles GroupBox1.DoubleClick
        Me.Hide()
        Ejecutar_Respaldo.Show()
    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter
        ' Me.Hide()
        ' Ejecutar_Respaldo.Show()
    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Mantener_Respaldos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Inicio_Administrador.Show()

    End Sub

    Private Sub Mantener_Respaldos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GroupBox2.Enabled = False

        Dim col0 As New Windows.Forms.ColumnHeader
        Dim col1 As New Windows.Forms.ColumnHeader
        Dim col2 As New Windows.Forms.ColumnHeader
        Dim col3 As New Windows.Forms.ColumnHeader
        Dim col4 As New Windows.Forms.ColumnHeader
        Dim col5 As New Windows.Forms.ColumnHeader

        col0.Text = "Nombre"
        col1.Text = "Fecha"
        col2.Text = "Usuario"
        col3.Text = "Tipo"
        col4.Text = "Tamaño"
        col5.Text = "Versión"

        col0.Width = 150
        col1.Width = 150
        col2.Width = 150
        col3.Width = 150
        col4.Width = 150
        col5.Width = 150


        ListView1.Columns.Add(col0)
        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)
        ListView1.Columns.Add(col4)
        ListView1.Columns.Add(col5)


        'BUSCAR EN DIRECTORIO DE BAK LOS DISTINTOS .BAK QUE HAY

        Dim dir As New DirectoryInfo(Modulo.directorio_baks)
        Dim dir_s As String = ""
        Dim item As New ListViewItem

        For Each f As FileInfo In dir.GetFiles
            dir_s = f.Name.ToString.Trim
            'MsgBox(dir_s & "E")
            item = New ListViewItem(f.Name.ToString.Trim)
            item.SubItems.Add(f.CreationTime.ToString.Trim)
            item.SubItems.Add("admin")
            item.SubItems.Add("completo")
            item.SubItems.Add(f.Length.ToString)
            item.SubItems.Add("1.0")

            ListView1.Items.Add(item)



        Next
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Ejecutar_Respaldo.Show()

    End Sub

    Private Sub GroupBox3_Click(sender As Object, e As System.EventArgs) Handles GroupBox3.Click
        Configurar_Respaldo.Show()
    End Sub

    Private Sub GroupBox3_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox3.Enter
        Configurar_Respaldo.Show()

    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        Configurar_Respaldo.Show()
    End Sub
End Class