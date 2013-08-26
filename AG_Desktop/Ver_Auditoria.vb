Imports System.Data.SqlClient


Public Class Ver_Auditoria

    Private Sub Ver_Auditoria_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Inicio_Administrador.Show()

    End Sub

    Private Sub Ver_Auditoria_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Using cnn As New SqlConnection(enlace)
            cnn.Open()

            Dim c As String = "select * from USUARIO where cargo <> '3'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            ComboBox1.Items.Clear()

            ComboBox1.Items.Add("Todos")
            For i = 0 To dt.Rows.Count - 1
                ComboBox1.Items.Add(dt.Rows(i).Item("Username").ToString.Trim & " : " & dt.Rows(i).Item("nombre").ToString.Trim)
            Next


        End Using


        Dim col1 As New ColumnHeader
        Dim col2 As New ColumnHeader
        Dim col3 As New ColumnHeader
        Dim col4 As New ColumnHeader
        Dim col5 As New ColumnHeader
        Dim col6 As New ColumnHeader
        Dim col7 As New ColumnHeader
        Dim col8 As New ColumnHeader

        col1.Text = "Entrada"
        col2.Text = "Usuario"
        col3.Text = "Tabla"
        col4.Text = "Operacion"
        col5.Text = "Instrucción"
        col6.Text = "Fecha"
        col7.Text = "Antes"
        col8.Text = "Despues"

        col3.Width = 120
        col5.Width = 400
        col6.Width = 130
        col4.Width = 120

        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)
        ListView1.Columns.Add(col4)
        ListView1.Columns.Add(col5)
        ListView1.Columns.Add(col6)
        ListView1.Columns.Add(col7)
        ListView1.Columns.Add(col8)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Using cnn As New SqlConnection(enlace)

            Dim c As String = "Select * from Auditoria"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Dim item As ListViewItem
            ListView1.Items.Clear()
            If ComboBox1.Text = "Todos" Then

                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    item = New ListViewItem(dt.Rows(i).Item("ID_ENTRADA").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Usuario").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Nombre_tabla").ToString.Trim)

                    If dt.Rows(i).Item("Operacion").ToString.Trim = "I" Then
                        item.SubItems.Add("INSERCIÓN")
                    ElseIf dt.Rows(i).Item("Operacion").ToString.Trim = "U" Then
                        item.SubItems.Add("ACTUALIZACIÓN")
                    ElseIf dt.Rows(i).Item("Operacion").ToString.Trim = "D" Then
                        item.SubItems.Add("ELIMINAR")
                    Else
                        item.SubItems.Add("LECTURA")
                    End If


                    item.SubItems.Add(dt.Rows(i).Item("Instruccion_sql").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Fecha_y_hora").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Datos_antes").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Datos_despues").ToString.Trim)

                    ListView1.Items.Add(item)

                Next

            Else

                c = c & " where usuario = '" & obtenerID(ComboBox1.Text) & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)

                For i = 0 To dt.Rows.Count - 1
                    item = New ListViewItem(dt.Rows(i).Item("ID_ENTRADA").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Usuario").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Nombre_tabla").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Operacion").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Instruccion_sql").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Fecha_y_hora").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Datos_antes").ToString.Trim)
                    item.SubItems.Add(dt.Rows(i).Item("Datos_despues").ToString.Trim)

                    ListView1.Items.Add(item)

                Next
            End If


        End Using

    End Sub
End Class