Imports System.Data.SqlClient

Public Class Mantener_disenos

    Private Sub Mantener_disenos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Modulo.cargoUser = 0 Then
            Inicio_Administrador.Show()
        Else
            Inicio_Operador.Show()

        End If
    End Sub

    Private Sub Mantener_disenos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnEditar.Text = "Editar"
        Button3.Enabled = False
        Button2.Enabled = False

        Dim col1 As New Windows.Forms.ColumnHeader


        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * From diseno"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim genero As String = ""
            Dim tallaje As String = ""
            ComboBox1.Items.Clear()

            For i = 0 To dt.Rows.Count - 1

                If dt.Rows(i).Item("genero_diseno").ToString.Trim = "H" Then
                    genero = "Hombre"
                ElseIf dt.Rows(i).Item("genero_diseno").ToString.Trim = "M" Then
                    genero = "Mujer"
                Else
                    genero = "Universal"
                End If

                If dt.Rows(i).Item("tallaje").ToString.Trim = "A" Then
                    tallaje = "Adulto"
                Else
                    tallaje = "Niño"
                End If


                ComboBox1.Items.Add(dt.Rows(i).Item("id_diseno").ToString.Trim & " : " & dt.Rows(i).Item("nombre_diseno").ToString.Trim & " : " & genero & " : " & tallaje)

            Next

        End Using


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim id_diseno As String = obtenerID(ComboBox1.Text)
        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * From diseno where id_diseno = '" & id_diseno & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim genero As String = ""
            Dim tallaje As String = ""

            If dt.Rows(0).Item("genero_diseno").ToString.Trim = "H" Then
                genero = "Hombre"
            ElseIf dt.Rows(0).Item("genero_diseno").ToString.Trim = "M" Then
                genero = "Mujer"
            Else
                genero = "Universal"
            End If

            If dt.Rows(0).Item("tallaje").ToString.Trim = "A" Then
                tallaje = "Adulto"
            Else
                tallaje = "Niño"
            End If

            TextBox14.Text = dt.Rows(0).Item("id_diseno").ToString.Trim
            TextBox8.Text = dt.Rows(0).Item("nombre_diseno").ToString.Trim

            TextBox11.Text = dt.Rows(0).Item("descripcion_diseno").ToString.Trim
            TextBox13.Text = genero
            TextBox12.Text = tallaje
            TextBox9.Text = dt.Rows(0).Item("descripcion_tallaje").ToString.Trim
            TextBox8.Enabled = False
            TextBox9.Enabled = False
            TextBox11.Enabled = False
            TextBox13.Enabled = False
            TextBox12.Enabled = False


        End Using



    End Sub

    Private Sub btnCrear_Click(sender As System.Object, e As System.EventArgs) Handles btnCrear.Click
        Me.Hide()
        crear_diseno.Show()

    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        TextBox8.Enabled = True
        TextBox11.Enabled = True
        TextBox13.Enabled = True
        TextBox12.Enabled = True
        TextBox9.Enabled = True

        Button3.Enabled = True
        Button2.Enabled = True

        Button1.Enabled = False
        btnCrear.Enabled = False
        btnEliminar.Enabled = False
        btnEditar.Enabled = False





    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim Box As MsgBoxResult = MsgBox("Está seguro de eliminar el cliente: " & TextBox14.Text & "?", MsgBoxStyle.YesNo)
        If Box = MsgBoxResult.Yes Then

        Else

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Mantener_Categorias.Show()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Button3.Enabled = False
        Button2.Enabled = False


        Button1.Enabled = True
        btnCrear.Enabled = True
        btnEliminar.Enabled = True
        btnEditar.Enabled = True


    End Sub
End Class