Imports System.Data.SqlClient

Module Modulo
    Public usuario As String
    Public nombre As String

    Public cargoUser As Integer
    Public enlace As String = "Data Source=HPEB\SQLEXPRESS;Initial Catalog=arte_genero;Integrated Security=True"
    Public buscando As String
    Public pedido As String
    Public traje_sesion As String
    Public directorio_baks As String = "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\Backup\"
    Public fecha_respaldo As Date
    Public ultimo_form As String = ""


    Public Function cargarPerfil()
        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "select * from usuario where username = '" & usuario & "'"
            Dim cmd As New SqlCommand(c, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            Perfil_Resumen.Label10.Text = dt.Rows(0).Item("nombre").ToString
            Perfil_Resumen.Label9.Text = dt.Rows(0).Item("username").ToString

            If dt.Rows(0).Item("cargo").ToString = "0" Then
                Perfil_Resumen.Label8.Text = "Administrador"
            ElseIf dt.Rows(0).Item("cargo").ToString = "1" Then
                Perfil_Resumen.Label8.Text = "Vendedor"
            Else
                Perfil_Resumen.Label8.Text = "Operador"
            End If

            Perfil_Resumen.Label7.Text = dt.Rows(0).Item("mail").ToString
            Perfil_Resumen.Label6.Text = dt.Rows(0).Item("fono").ToString

            Return Nothing



        End Using
    End Function

    Public Function insertar_auditoria(ByVal u As String, ByVal t As String, ByVal i As String, ByVal o As String, ByVal f As String, ByVal a As String, ByVal d As String)


        Using cnn As New SqlConnection(enlace)

            cnn.Open()
            Dim c As String = "Insert into auditoria( nombre_tabla, instruccion_sql, operacion, fecha_y_hora, datos_antes, datos_despues, usuario) VALUES ('"
            c = c & t & "','" & i & "','" & o & "','" & f & "','" & a & "','" & d & "','" & u & "')"

            Dim cmd As New SqlCommand()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = c

            
            Try
                '  MsgBox(cmd.CommandText.ToString)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Problema en la auditoría")
                MsgBox(ex.ToString)
            End Try



        End Using

        Return Nothing

    End Function

    Public Function obtenerID(ByVal texto As String) As String

        Dim cadenas As String() = texto.Split(":")
        Return cadenas(0).Trim


    End Function

    Public Function obtenerTres(ByVal texto As String) As String

        Dim cadenas As String() = texto.Split(":")
        Return cadenas(2).Trim


    End Function

    Public Function obtenerNombre(ByVal texto As String) As String

        Dim cadenas As String() = texto.Split(":")
        Return cadenas(1).Trim


    End Function

    Public Function cargo(ByVal s As String) As Integer

        If s = "Administrador" Then
            Return 0
        ElseIf s = "Vendedor" Then
            Return 1
        ElseIf s = "Operador" Then
            Return 2
        ElseIf s = "Cliente Web" Then
            Return 3
        Else
            Return -1

        End If

    End Function

    Public Function estado(ByVal s As String) As String

        If s = "0" Then
            Return "Creada"
        ElseIf s = "1" Then
            Return "En proceso"
        ElseIf s = "2" Then
            Return "Pausada"
        ElseIf s = "3" Then
            Return "Finalizada"
        Else
            Return "Cancelada"

        End If


    End Function

    Public Function estado_a_int(ByVal s As String) As Integer
        If s = "Creada" Then
            Return 0
        ElseIf s = "En proceso" Then
            Return 1
        ElseIf s = "Pausada" Then
            Return 2
        ElseIf s = "Finalizada" Then
            Return 3
        Else
            Return 4

        End If

    End Function

End Module
