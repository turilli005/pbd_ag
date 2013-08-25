Imports System.Data.SqlClient


Public Class Ver_Productos

    Private Sub Ver_Productos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Inicio_Administrador.Show()

    End Sub

    Private Sub Ver_Productos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim col1 As New ColumnHeader
        Dim col2 As New ColumnHeader
        Dim col3 As New ColumnHeader
        Dim col4 As New ColumnHeader
        Dim col5 As New ColumnHeader

        col1.Text = "Orden"
        col2.Text = "Diseño"
        col3.Text = "Puesto"
        col4.Text = "Avance"
        col5.Text = "Detalles"

        col5.Width = 200


        ListView1.Columns.Add(col1)
        ListView1.Columns.Add(col2)
        ListView1.Columns.Add(col3)
        ListView1.Columns.Add(col4)
        ListView1.Columns.Add(col5)

        Using cnn As New SqlConnection(enlace)
            cnn.Open()


            Dim c As String = "Select * from PRODUCTO"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Dim dt_reporte As New DataTable
            Dim dt_diseno As New DataTable
            Dim dt_puesto As New DataTable
            Dim item As ListViewItem

            da.Fill(dt)
            ListView1.Items.Clear()

            Dim id_reporte As String = ""

            For i = 0 To dt.Rows.Count - 1

                'id_reporte_produccion
                id_reporte = dt.Rows(i).Item("ID_REPORTE_PRODUCCION").ToString.Trim

                c = "Select * from REPORTE_PRODUCCION where id_reporte_produccion = '" & id_reporte & "'"
                cmd = New SqlCommand(c, cnn)
                da = New SqlDataAdapter(cmd)
                dt_reporte = New DataTable
                da.Fill(dt_reporte)

                If dt_reporte.Rows.Count > 0 Then
                    item = New ListViewItem(dt_reporte.Rows(0).Item("ID_OS").ToString.Trim)

                    c = "Select * from diseno where id_diseno = '" & dt_reporte.Rows(0).Item("id_diseno").ToString.Trim & "'"

                    cmd = New SqlCommand(c, cnn)
                    da = New SqlDataAdapter(cmd)
                    dt_diseno = New DataTable
                    da.Fill(dt_diseno)

                    item.SubItems.Add(dt_diseno.Rows(0).Item("nombre_diseno").ToString.Trim())

                    c = "Select * from PUESTO_TRABAJO where ID_PUESTO_DE_TRABAJO = '" & dt.Rows(i).Item("ID_PUESTO_DE_TRABAJO").ToString.Trim & "'"
                    cmd = New SqlCommand(c, cnn)
                    da = New SqlDataAdapter(cmd)
                    dt_puesto = New DataTable
                    da.Fill(dt_puesto)

                    item.SubItems.Add(dt_puesto.Rows(0).Item("nombre_puesto").ToString.Trim())
                    item.SubItems.Add(dt_reporte.Rows(0).Item("procentaje_avance").ToString.Trim())
                    item.SubItems.Add(dt.Rows(0).Item("detalle_producto").ToString.Trim())

                    ListView1.Items.Add(item)
                End If



            Next

        End Using


    End Sub
End Class