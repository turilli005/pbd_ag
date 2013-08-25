Imports System.Data.SqlClient

Public Class Mantener_Reales

    Private Sub Mantener_Reales_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Modulo.cargoUser = 0 Then
            Inicio_Administrador.Show()

        Else
            Inicio_Operador.Show()
        End If


    End Sub

    Private Sub Mantener_Reales_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from DISENO"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)



            For i = 0 To dt.Rows.Count - 1
                ComboBox1.Items.Add(dt.Rows(i).Item("ID_DISENO").ToString & " : " & dt.Rows(i).Item("NOMBRE_DISENO").ToString)
            Next



        End Using


        Dim col10 As New Windows.Forms.ColumnHeader
        Dim col11 As New Windows.Forms.ColumnHeader
        Dim col12 As New Windows.Forms.ColumnHeader
        Dim col13 As New Windows.Forms.ColumnHeader
        Dim col14 As New Windows.Forms.ColumnHeader
        Dim col15 As New Windows.Forms.ColumnHeader
        Dim col16 As New Windows.Forms.ColumnHeader

        col10.Text = "Diseño"
        col11.Text = "Nombre"
        col11.Width = 110
        col12.Text = "Diseño"
        col13.Text = "Corte"
        col14.Text = "Confeccion"
        col14.Text = 110
        col15.Text = "Cantidad inclusión"
        col16.Text = "Tiempo total inclusión"

        'COLUMNAS DE MATERIALES TEORICOS
        Dim col20 As New Windows.Forms.ColumnHeader
        Dim col21 As New Windows.Forms.ColumnHeader
        Dim col22 As New Windows.Forms.ColumnHeader
        Dim col23 As New Windows.Forms.ColumnHeader
        Dim col24 As New Windows.Forms.ColumnHeader
        Dim col25 As New Windows.Forms.ColumnHeader
        Dim col26 As New Windows.Forms.ColumnHeader
        Dim col27 As New Windows.Forms.ColumnHeader
        Dim col28 As New Windows.Forms.ColumnHeader

        col20.Text = "Diseño"
        col21.Text = "Nombre"
        col22.Text = "Material"
        col23.Text = "Nombre"
        col24.Text = "Unidad"
        col25.Text = "Diseño"
        col26.Text = "Corte"
        col27.Text = "Confeccion"

        col28.Text = "Cantidad total inclusión"

        ListView2.Columns.Add(col20)
        ListView2.Columns.Add(col21)
        ListView2.Columns.Add(col22)
        ListView2.Columns.Add(col23)
        ListView2.Columns.Add(col24)
        ListView2.Columns.Add(col25)
        ListView2.Columns.Add(col26)
        ListView2.Columns.Add(col27)
        ListView2.Columns.Add(col28)

       

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim diseno As String = obtenerID(ComboBox1.Text)

        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * from diseno where id_diseno = '" & diseno & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            TextBox16.Text = dt.Rows(0).Item("nombre_diseno").ToString
            TextBox15.Text = dt.Rows(0).Item("descripcion_diseno").ToString
            TextBox12.Text = dt.Rows(0).Item("id_diseno").ToString

        End Using


    End Sub
End Class