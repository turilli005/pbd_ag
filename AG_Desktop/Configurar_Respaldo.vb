Public Class Configurar_Respaldo

    Private Sub Configurar_Respaldo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GroupBox2.Enabled = False

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Completo")
        ComboBox1.Items.Add("Clientes y Pedidos")
        ComboBox1.Items.Add("Materiales y Proveedores")

        ComboBox3.Items.Clear()

        ComboBox3.Items.Add("Diario")
        ComboBox3.Items.Add("Semanal")
        ComboBox3.Items.Add("Mensual")
        ComboBox3.Items.Add("Anual")

        ComboBox1.SelectedIndex = 0
        ComboBox1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Try
            With FolderBrowserDialog1

                .Reset() ' resetea  

                ' leyenda  
                .Description = " Seleccionar un directorio "
                ' Path " Mis documentos "  
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                ' deshabilita el botón " crear nueva carpeta "  
                .ShowNewFolderButton = False
                '.RootFolder = Environment.SpecialFolder.Desktop  
                '.RootFolder = Environment.SpecialFolder.StartMenu  

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then

                    TextBox1.Text = .SelectedPath.ToString


                    'Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                    'nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)

                    '  MsgBox("Total de archivos: " & CStr(nFiles.Count), _
                    '                MsgBoxStyle.Information)
                End If

                .Dispose()

            End With
        Catch ex As Exception

        End Try

    End Sub
End Class