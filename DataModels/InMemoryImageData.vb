
Public Class InMemoryImageData
    Public Sub New(ByVal image As Byte(), ByVal label As String, ByVal imageFileName As String)
        Me.Image = image
        Me.Label = label
        Me.ImageFileName = imageFileName
    End Sub

    Public ReadOnly Image As Byte()
    Public ReadOnly Label As String
    Public ReadOnly ImageFileName As String
End Class
