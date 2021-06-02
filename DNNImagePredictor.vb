Imports System.IO
Imports Microsoft.ML

Public Class DNNImagePredictor

    Dim mLContext As MLContext = New MLContext(New Integer?(1))
    Dim dataViewSchema As DataViewSchema
    Dim transformer As ITransformer
    Dim predictionEngine As PredictionEngine(Of InMemoryImageData, ImagePrediction)
    Dim imagePrediction As New ImagePrediction

    Public Sub New()

    End Sub

    Public Function Load_TrainedModelZip(imageClassifierModelZipFilePath As String) As String
        transformer = mLContext.Model.Load(imageClassifierModelZipFilePath,
                                                           dataViewSchema)
        predictionEngine =
            mLContext.Model.CreatePredictionEngine(Of InMemoryImageData,
                                                    ImagePrediction)(
                                                    transformer, True, Nothing, Nothing)

        Return ""
    End Function


    Public Function Predict(ImageFolderPath As String, ImageFileName As String) As ImagePrediction
        Dim ImageByteArray As Byte() =
            Convert_ImageFile_To_ImageByteArray(ImageFolderPath, ImageFileName)

        Dim inMemoryImageData As New InMemoryImageData(ImageByteArray, "", ImageFileName)

        imagePrediction = predictionEngine.Predict(inMemoryImageData)

        Return imagePrediction
    End Function

    Public Function Convert_ImageFile_To_ImageByteArray(ImageFolderPath As String,
                                                        ImageFileName As String) As Byte()
        Return File.ReadAllBytes(ImageFolderPath + "\" + ImageFileName)
    End Function
End Class
