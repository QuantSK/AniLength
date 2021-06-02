Imports Microsoft.ML.Data

Public Class ImageData
    <LoadColumn(0)>
    Public ImagePath As String

    <LoadColumn(1)>
    Public Label As String
End Class