Imports System.Data.SqlClient


Public Class Avance_Pedido_Indicar_Consumo
    Public ETAPA As String = ""
    Public puesto As Integer = 0
    Private Sub Avance_Pedido_Indicar_Consumo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label6.Text = puesto & " : " & ETAPA

        'COLUMNAS
        Dim col1 As New Windows.Forms.ColumnHeader
        Dim col2 As New Windows.Forms.ColumnHeader
        Dim col3 As New Windows.Forms.ColumnHeader

        col1.Text = "Material"
        col2.Text = "Unidad"
        col3.Text = "Cantidad"

        col1.Width = 100
        col2.Width = 100
        col3.Width = 70

        ListView2.Columns.Add(col1)
        ListView2.Columns.Add(col2)
        ListView2.Columns.Add(col3)

        ' Dim diseno As String = 

        If ETAPA = "Diseño" Then
            PictureBox1.Image = My.Resources.diseno
        ElseIf ETAPA = "Compra" Then
            PictureBox1.Image = My.Resources.cesta_de_la_compra

        ElseIf ETAPA = "Corte" Then
            PictureBox1.Image = My.Resources.tijeras

        ElseIf ETAPA = "Confección" Then
            PictureBox1.Image = My.Resources.work_in_progress1


        End If



        Dim id_diseno As String = obtenerID(TextBox12.Text)
        Dim c As String = "Select distinct id_material from uso_teorico where id_diseno = '" & id_diseno & "'"
        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim dt_mat As New DataTable
            ComboBox2.Items.Clear()

            For i = 0 To dt.Rows.Count - 1
                c = "Select * from material where id_material = '" & dt.Rows(i).Item("id_material").ToString.Trim & "'"

                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                dt_mat = New DataTable
                da.Fill(dt_mat)

                ComboBox2.Items.Add(dt_mat.Rows(0).Item("id_material").ToString.Trim & " : " & dt_mat.Rows(0).Item("nombre_material").ToString.Trim)
            Next

            c = "Select * from tiempo_teorico where id_diseno = '" & obtenerID(TextBox12.Text) & "' and id_puesto_trabajo = '" & puesto & "'"
            cmd = New SqlCommand(c, cnn)
            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)

            TextBox4.Text = dt.Rows(0).Item("tiempo_estimado").ToString.Trim





        End Using
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox9.Clear()
        Me.Close()


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Select * from uso_teorico where id_material = '" & obtenerID(ComboBox2.Text) & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
           
            TextBox6.Text = dt.Rows(0).Item("unidad_teorica").ToString.Trim
            TextBox5.Text = dt.Rows(0).Item("cantidad_estimada").ToString.Trim


        End Using
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        If TextBox3.Text = "" Then
            MsgBox("Debe ingresar comentarios del avance", MsgBoxStyle.Information, "Error")
        Else


            'INSERCIONES EN MONITOREO


            'diseno
            'ID_PUESTO_DE_TRABAJO = 0
            'ID_REPORTE_PRODUCCION =  buscar con ID_OS ID_DISENO
            'INFORMACION_TRABAJO_REALIZADO
            Dim puesto_trabajo As String = obtenerID(Label6.Text)
            Dim orden As String = obtenerID(TextBox8.Text)
            Dim diseno As String = obtenerID(TextBox12.Text)
            Dim comentarios As String = TextBox3.Text


            Using cnn As New SqlConnection(enlace)

                cnn.Open()
                Dim c As String = "SELECT * FROM REPORTE_PRODUCCION where id_os = '" & orden & "' and id_diseno = '" & diseno & "'"
                Dim cmd As New SqlCommand(c, cnn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    Dim id_reporte As String = dt.Rows(0).Item("id_reporte_produccion").ToString.Trim

                    c = "INSERT INTO MONITOREO(ID_PUESTO_TRABAJO, ID_REPORTE_PRODUCCION, INFORMACION_TRABAJO_REALIZADO) VALUES ('" & puesto_trabajo & "','" & id_reporte & "','" & comentarios & "')"

                    cmd = New SqlCommand(c, cnn)

                    Try
                        cmd.ExecuteNonQuery()
                        Modulo.insertar_auditoria(Modulo.usuario, "MONITOREO", "INSERT INTO MONITOREO(ID_PUESTO_TRABAJO, ID_REPORTE_PRODUCCION, INFORMACION_TRABAJO_REALIZADO) VALUES", "I", Date.Today, "", "")

                    Catch ex As Exception

                    End Try


                Else

                End If

            End Using

            'compra materiales

            'corte telas

            'confeccion




            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox9.Clear()
            Me.Close()
        End If


    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If TextBox9.Text = "" Or ComboBox2.Text = "" Or TextBox6.Text = "" Then
            MsgBox("Ingrese todos los datos", MsgBoxStyle.Information, "Error")

        Else
            Dim esta As Boolean = False

            For i = 0 To ListView2.Items.Count - 1
                If ListView2.Items(i).SubItems(0).Text = ComboBox2.Text Then
                    esta = True

                End If
            Next
            If esta Then
                MsgBox("El material ya se encuentra indicado.", MsgBoxStyle.Information, "Error")
            Else

                If IsNumeric(TextBox9.Text) Then
                    Dim item As New ListViewItem(ComboBox2.Text)
                    item.SubItems.Add(TextBox6.Text)
                    item.SubItems.Add(TextBox9.Text)
                    ListView2.Items.Add(item)

                    'ComboBox2.SelectedItem = Nothing
                    TextBox9.Clear()
                    TextBox6.Clear()
                Else
                    MsgBox("La cantidad empleada debe ser un valor numérico", MsgBoxStyle.Information, "Error")
                End If

                
            End If

            



        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ListView2.SelectedItems.Count <> 1 Then
            MsgBox("Seleccione un material para quitar", MsgBoxStyle.Information, "Error")
        Else
            ListView2.SelectedItems(0).Remove()

        End If
    End Sub
End Class