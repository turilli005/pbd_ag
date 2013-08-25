Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Mantener_usuarios

    Private Sub btnCrear_Click(sender As System.Object, e As System.EventArgs) Handles btnCrear.Click
        Me.Hide()
        Crear_Usuario.Show()

    End Sub

    Private Sub Mantener_usuarios_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Inicio_Administrador.Show()

    End Sub

    Public Sub actualizar()
        Using cnn As New SqlConnection(enlace)

            ListView1.Items.Clear()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()



            cnn.Open()
            Dim c As String = "Select * From Usuario"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim cargo As String
            Dim item As New ListViewItem

            ListView1.Items.Clear()


            'MsgBox(dt.Rows.Count)
            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("username").ToString)
                item.SubItems.Add(dt.Rows(i).Item("Nombre").ToString)
                item.SubItems.Add(dt.Rows(i).Item("mail").ToString)
                cargo = dt.Rows(i).Item("cargo").ToString
                If cargo = "0" Then
                    item.SubItems.Add("Administrador")
                ElseIf cargo = "1" Then
                    item.SubItems.Add("Vendedor")
                ElseIf cargo = "2" Then
                    item.SubItems.Add("Operador")
                Else
                    item.SubItems.Add("Diseñador")

                End If


                item.SubItems.Add(dt.Rows(i).Item("fono").ToString)
                ListView1.Items.Add(item)


            Next


        End Using
    End Sub

    Private Sub Mantener_usuarios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnEditar.Enabled = False
        btnEliminar.Enabled = False

        Dim col1 As New Windows.Forms.ColumnHeader
        Dim col2 As New Windows.Forms.ColumnHeader
        Dim col3 As New Windows.Forms.ColumnHeader
        Dim col4 As New Windows.Forms.ColumnHeader
        Dim col5 As New Windows.Forms.ColumnHeader
        Dim col6 As New Windows.Forms.ColumnHeader
        Dim col7 As New Windows.Forms.ColumnHeader

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()

        col1.Text = "Username"
        col2.Text = "Nombre"
        col3.Text = "Mail"
        col4.Text = "Cargo"
        col5.Text = "Telefono"
        'col6.Text = "Region"
        'col7.Text = "Ciudad"

        col1.Width = 100
        col2.Width = 200
        col3.Width = 150
        col4.Width = 100
        col5.Width = 100
        ' col6.Width = 70
        ' col7.Width = 100

        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)
        ListView1.Columns.Add(col4)
        ListView1.Columns.Add(col5)
        ' ListView1.Columns.Add(col6)
        ' ListView1.Columns.Add(col7)

        Dim item As New ListViewItem

        ListView1.Items.Clear()

        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * From Usuario"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim cargo As String

            'MsgBox(dt.Rows.Count)
            For i = 0 To dt.Rows.Count - 1
                item = New ListViewItem(dt.Rows(i).Item("username").ToString)
                item.SubItems.Add(dt.Rows(i).Item("Nombre").ToString)
                item.SubItems.Add(dt.Rows(i).Item("mail").ToString)
                cargo = dt.Rows(i).Item("cargo").ToString
                If cargo = "0" Then
                    item.SubItems.Add("Administrador")
                ElseIf cargo = "1" Then
                    item.SubItems.Add("Vendedor")
                ElseIf cargo = "2" Then
                    item.SubItems.Add("Operador")
                Else
                    item.SubItems.Add("Cliente Web")

                End If


                item.SubItems.Add(dt.Rows(i).Item("fono").ToString)
                ListView1.Items.Add(item)


            Next


        End Using

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then
            btnEditar.Enabled = True
            btnEliminar.Enabled = True
        Else
            btnEditar.Enabled = False
            btnEliminar.Enabled = False
            GroupBox1.Enabled = False


        End If
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click

        Dim item As New ListViewItem

        ComboBox1.Items.Clear()


        ComboBox1.Items.Add("Administrador")
        ComboBox1.Items.Add("Vendedor")
        ComboBox1.Items.Add("Operador")
        ComboBox1.Items.Add("Cliente Web")


        GroupBox1.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True

        item = ListView1.SelectedItems(0)
        TextBox4.Text = item.SubItems(0).Text
        TextBox1.Text = item.SubItems(1).Text
        TextBox2.Text = item.SubItems(2).Text
        TextBox3.Text = item.SubItems(4).Text




    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Ingrese un nombre")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Ingrese un correo")
        ElseIf TextBox3.Text = "" Then
            MsgBox("Ingrese un telefono")
        ElseIf ComboBox1.SelectedItem = "" Then
            MsgBox("Seleccione un cargo")
        ElseIf Regex.IsMatch(TextBox2.Text, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") = False Then
            MsgBox("Ingrese un correo electrónico válido")
        ElseIf IsNumeric(TextBox3.Text) = False Then
            MsgBox("Ingrese un teléfono sólo con números")
        Else
            'update
            Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(enlace)
            Dim cmd As New System.Data.SqlClient.SqlCommand
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "UPDATE Usuario SET nombre='" & TextBox1.Text.Trim & "', mail='" & TextBox2.Text.Trim & "', fono='" & TextBox3.Text.Trim & "', cargo = '" & cargo(ComboBox1.Text.Trim) & "' WHERE username = '" & TextBox4.Text.Trim & "'"
            cmd.Connection = sqlConnection1
            'MsgBox("UPDATE Usuario SET nombre='" & TextBox1.Text.Trim & "', mail='" & TextBox2.Text.Trim & "', fono='" & TextBox3.Text.Trim & "', cargo = '" & cargo(ComboBox1.Text.Trim) & "' WHERE username = '" & TextBox4.Text.Trim & "'")
            sqlConnection1.Open()

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Usuario actualizado correctamente.")
                Modulo.insertar_auditoria(Modulo.usuario, "USUARIO", "UPDATE Usuario SET nombre=", "U", Date.Today, "", "")
            Catch ex As Exception
                MsgBox("Error en la actualización de los datos")

            End Try
            sqlConnection1.Close()
            actualizar()
            GroupBox1.Enabled = False



        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If ListView1.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione sólo un usuario para eliminar")
        Else
            Dim id As String = ListView1.SelectedItems(0).SubItems(0).Text.Trim


            'borrar
            Dim borrar As Boolean = False

            Dim Box As MsgBoxResult = MsgBox("Está seguro de eliminar el usuario " & id & "?", MsgBoxStyle.YesNo)
            If Box = MsgBoxResult.Yes Then
                'MsgBox("Done")
                Using cnn As New SqlConnection(enlace)
                    cnn.Open()
                    Dim c As String = "SELECT * FROM USUARIO Where USERNAME =  '" & id & "'"
                    Dim cmd As New SqlCommand(c, cnn)
                    cmd.CommandType = CommandType.Text
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    If dt.Rows.Count = 0 Then
                        borrar = False
                    Else
                        borrar = True
                    End If
                End Using

                If borrar Then
                    Using cnn As New SqlConnection(enlace)
                        cnn.Open()
                        Dim c As String = "DELETE FROM usuario Where username =  '" & id & "'"
                        Dim cmd As New SqlCommand(c, cnn)
                        cmd.CommandType = CommandType.Text

                        Try
                            cmd.ExecuteNonQuery()
                            Modulo.insertar_auditoria(Modulo.usuario, "USUARIO", "DELETE FROM usuario Where username =", "U", Date.Today, "", "")
                        Catch ex As Exception

                        End Try
                        actualizar()

                    End Using
                Else
                    MsgBox("No es posible borrar el usuario")
                End If



            Else
                'MsgBox("Not Done")
            End If


        End If
    End Sub
End Class