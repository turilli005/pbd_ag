Imports System.Security.Cryptography
Imports System.Text

Public Class Encriptar

    Private des As New TripleDESCryptoServiceProvider 'Algorithmo TripleDES
    Private hashmd5 As New MD5CryptoServiceProvider 'objeto md5
    'Private myKey As String = "MyKey2012" 'Clave secreta(puede alterarse)

    'Funcion para el Encriptado de Cadenas de Texto
    Public Function Cifrar(ByVal texto As String, ByVal myKey As String) As String

        If Trim(texto) = "" Then
            Cifrar = ""
        Else
            des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(myKey))
            des.Mode = CipherMode.ECB
            Dim encrypt As ICryptoTransform = des.CreateEncryptor()
            Dim buff() As Byte = UnicodeEncoding.ASCII.GetBytes(texto)
            Cifrar = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length))
        End If
        Return Cifrar
    End Function

End Class
