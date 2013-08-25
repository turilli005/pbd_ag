Imports System.Data.SqlClient

Public Class Mantener_Materiales

    Private Sub Mantener_Materiales_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cargoUser = 0 Then
            Inicio_Administrador.Show()
        Else
            Inicio_Operador.Show()

        End If
    End Sub

    Private Sub Mantener_Materiales_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Todos")

        Using cnn As New SqlConnection(enlace)
            cnn.Open()
            Dim c As String = "Select * From proveedor"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            For i = 0 To dt.Rows.Count - 1

                c = "Select * from persona where rut = '" & dt.Rows(i).Item("rut").ToString & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                Dim dt_persona As New DataTable
                da.Fill(dt_persona)


                ComboBox1.Items.Add(dt.Rows(i).Item("rut").ToString & " : " & dt_persona.Rows(i).Item("nombre").ToString & " : " & dt_persona.Rows(i).Item("ciudad").ToString)


            Next


        End Using

        Dim col1 As New Windows.Forms.ColumnHeader
        Dim col2 As New Windows.Forms.ColumnHeader
        Dim col3 As New Windows.Forms.ColumnHeader
        Dim col4 As New Windows.Forms.ColumnHeader

        col1.Text = "Material"
        col2.Text = "Nombre"
        col3.Text = "Especificaciones"

        col1.Width = 70
        col2.Width = 140
        col3.Width = 250

        ListView2.Columns.Add(col1)
        ListView2.Columns.Add(col2)
        ListView2.Columns.Add(col3)

        GroupBox2.Enabled = False

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim prov As String = ComboBox1.Text
        If prov = "Todos" Then

            Using cnn As New SqlConnection(enlace)

                cnn.Open()
                Dim c As String = "Select * From MATERIAL"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable

                da.Fill(dt)

                Dim item As New ListViewItem



                For i = 0 To dt.Rows.Count - 1

                    item = New ListViewItem(dt.Rows(i).Item("id_material").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("nombre_material").ToString)
                    item.SubItems.Add(dt.Rows(i).Item("especificacion").ToString)
                    'item.SubItems.Add(dt.Rows(0).Item("genero_diseno").ToString)
                    'item.SubItems.Add(dt.Rows(0).Item("tallaje").ToString)
                    'item.SubItems.Add(dt.Rows(i).Item("color").ToString)
                    'item.SubItems.Add(dt.Rows(i).Item("detalles_adicionales").ToString)

                    ListView2.Items.Add(item)
                Next


            End Using

        Else

        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ListView2.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione un material para editar")
        Else

            Button1.Enabled = False
            Button3.Enabled = False


            Dim id As String = ListView2.SelectedItems(0).SubItems(0).Text
            Dim nombre As String = ListView2.SelectedItems(0).SubItems(1).Text
            Dim esp As String = ListView2.SelectedItems(0).SubItems(2).Text

            GroupBox2.Enabled = True
            TextBox3.Text = id
            TextBox7.Text = nombre
            TextBox5.Text = esp

        End If

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If TextBox5.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Debe llenar los campos de nombre y especificación")
        Else

            Dim cnn As New SqlConnection(enlace)
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn
            cmd.CommandText = "UPDATE ON MATERIAL SET "

            'cmd.ExecuteNonQuery()


            MsgBox("Datos Actualizados")
            Button1.Enabled = True
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        GroupBox2.Enabled = False
        'ListView2.SelectedItems = Nothing
        Button1.Enabled = True
        Button3.Enabled = True

    End Sub
End Class