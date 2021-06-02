
Imports System.IO

Module Bas_Main

    Public SourceFullFilename As String
    Public ROI_Boundary As New Rectangle(-1, -1, 1, 1)

    Public WithEvents MyAnimal As New Animal
    Public WithEvents MyFileSysEng As New FileSystemEngine
    Public WithEvents MyImgProc As New CompactImgProcessing
    Public WithEvents MyProc As New Processing
    Public WithEvents MyImgPredictor As New DNNImagePredictor

    Public PathDelimit As String = "/"


    Public Sub UpdateStatus(Msg As String, ProgressValue As Integer)
        With MDI_Main
            .Status_Progressbar.Value = ProgressValue
            .Status_Progressbar.Visible = True
            .Status_Info.Text = Msg
            '.StatusStrip_Status.Update()
            .StatusStrip_Status.Refresh()
        End With
    End Sub





    Public Sub TextBox_DragDropImageFile(sender As TextBox, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            MyFiles = CType(e.Data.GetData(DataFormats.FileDrop), String())
            sender.Text = MyFiles(0)
        End If
    End Sub

    Public Sub TextBox_DragEnterImageFile(sender As TextBox, e As DragEventArgs, FileExtStr As String)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String

            MyFiles = CType(e.Data.GetData(DataFormats.FileDrop), String())

            If InStr(FileExtStr, Path.GetExtension(MyFiles(0)).ToLower) <> 0 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        End If

    End Sub

    Private Sub MyAnimal_ProgressStatus(Msg As String, ProgressValue As Integer) Handles MyAnimal.ProgressStatus

        UpdateStatus(Msg, ProgressValue)

    End Sub

End Module
