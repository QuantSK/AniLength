Imports Microsoft.ML.Data


Public Class ImagePrediction
        <ColumnName("Score")>
        Public Score As Single()
        <ColumnName("PredictedLabel")>
        Public PredictedLabel As String
End Class