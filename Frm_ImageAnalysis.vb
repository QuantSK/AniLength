Imports System.IO

Public Class Frm_ImageAnalysis

    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        Me.MdiParent = MDI_Main
    End Sub


    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub Frm_ImageAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text_SourceImage.Text = Application.StartupPath +
                                "Test source images\" +
                                "LS1.jpeg"

        If MyFileSysEng.FileExists(Text_SourceImage.Text) Then
            MyAnimal._Image_Source = MyImgProc.Image_FromFile(Text_SourceImage.Text)
            Frm_ImageViewer.Canvas.Image = CType(MyAnimal._Image_Source.Clone, Bitmap)
        Else
            Frm_ImageViewer.Canvas.Image = New Bitmap(100, 100)
        End If

        Cmd_LoadTrainedModel_Click(Nothing, Nothing)

    End Sub



    Private Sub Cmd_RunAnalysis_Click(sender As Object, e As EventArgs) Handles Cmd_RunAnalysis.Click
        If MyFileSysEng.FileExists(Text_SourceImage.Text) = False Then
            MsgBox("Image file not found!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If


        If MyFileSysEng.FileExists(Application.StartupPath + "TrainedModel.zip") = False Then
            MsgBox("TrainedModel.zip not found!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If


        If Cmd_RunAnalysis.Text = "Stop processing" Then
            MyAnimal.Stop_Processing()
            Exit Sub
        End If


        Cmd_RunAnalysis.Text = "Stop processing"
        Cmd_RunAnalysis.Refresh()


        With Frm_ImageViewer
            If .Cmd_QuickAnim.Text <> "Animate" Then
                .Cmd_QuickAnim_Click(Nothing, Nothing)
            End If
        End With

        Read_ImageProcessingParameters()

        MyAnimal.Detect_Animals(
                        Check_EnableDNNImageClassification.Checked,
                        Text_SourceImage.Text)


        If MyAnimal._Image_FinalOverLap IsNot Nothing Then
            Frm_ImageViewer.Canvas.Image =
                CType(MyAnimal._Image_FinalOverLap.Clone, Bitmap)
        End If


        Cmd_RunAnalysis.Text = "Run analysis"


        If MyAnimal._UserStopped = False Then
            With Frm_ImageViewer
                .Combo_Anim1.SelectedIndex = 0
                .Combo_Anim2.SelectedIndex = 3

                If .Cmd_QuickAnim.Text = "Animate" Then
                    .Cmd_QuickAnim_Click(Nothing, Nothing)
                End If
            End With
        End If

    End Sub


    Public Sub Read_ImageProcessingParameters()
        With MyAnimal.myScreeningCondition
            Try
                .Area_Min = CInt(Text_AreaMin.Text)
            Catch
                MsgBox("Area min is wrong!", MsgBoxStyle.Critical, "Error")
                Text_AreaMin.Text = "200"
            End Try

            Try
                .Area_Max = CInt(Text_AreaMax.Text)
            Catch
                MsgBox("Area max is wrong!", MsgBoxStyle.Critical, "Error")
                Text_AreaMax.Text = "4000"
            End Try

            Try
                .Width_Min = CInt(Text_WidthMin.Text)
            Catch
                MsgBox("Width min is wrong!", MsgBoxStyle.Critical, "Error")
                Text_WidthMin.Text = "15"
            End Try

            Try
                .Width_Max = CInt(Text_WidthMax.Text)
            Catch
                MsgBox("Width max is wrong!", MsgBoxStyle.Critical, "Error")
                Text_WidthMax.Text = "200"
            End Try

            Try
                .AdaptiveBoxSize = CInt(Text_Adaptive_BoxSize.Text)
            Catch
                MsgBox("Box size is wrong!", MsgBoxStyle.Critical, "Error")
                Text_Adaptive_BoxSize.Text = "200"
            End Try

            Try
                .AdaptiveThreshold = CInt(Text_Adaptive_Threshold.Text)
            Catch
                MsgBox("Threshold is wrong!", MsgBoxStyle.Critical, "Error")
                Text_Adaptive_Threshold.Text = "86"
            End Try

            .IsObjectWhite = Not (Check_AnimalInBlack.Checked)
        End With


        Try
            MyAnimal.umPerPixels = (CSng(Text_um.Text) / CSng(Text_Pixels.Text))
        Catch
            MsgBox("Trheshold is wrong!", MsgBoxStyle.Critical, "Error")
            Text_Adaptive_Threshold.Text = "86"
        End Try

    End Sub



    Private Sub Cmd_Test_AdaptiveThresholding_Click(sender As Object, e As EventArgs) Handles Cmd_Test_AdaptiveThresholding.Click
        If MyFileSysEng.FileExists(Text_SourceImage.Text) = False Then
            MsgBox("Image file not found!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If


        With Frm_ImageViewer
            If .Cmd_QuickAnim.Text <> "Animate" Then
                .Cmd_QuickAnim_Click(Nothing, Nothing)
            End If
        End With


        Read_ImageProcessingParameters()

        MyAnimal.Detect_Animals(
                        Check_EnableDNNImageClassification.Checked,
                        Text_SourceImage.Text,
                        True)

        Frm_ImageViewer.Canvas.Image = CType(MyAnimal._Image_BlackWhite.Clone, Bitmap)

        With Frm_ImageViewer
            .Combo_Anim1.SelectedIndex = 0
            .Combo_Anim2.SelectedIndex = 0

            If .Cmd_QuickAnim.Text = "Animate" Then
                .Cmd_QuickAnim_Click(Nothing, Nothing)
            End If
        End With

    End Sub



    Public Sub Cmd_LoadTrainedModel_Click(sender As Object, e As EventArgs) Handles Cmd_LoadTrainedModel.Click
        Dim TrainedModelFilename As String
        TrainedModelFilename = Application.StartupPath + "TrainedModel.zip"

        If MyFileSysEng.FileExists(TrainedModelFilename) Then
            MyImgPredictor.Load_TrainedModelZip(TrainedModelFilename)
        Else
            MsgBox("TrainedModel.zip not found!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
    End Sub


    Private Sub Text_SourceImage_DragDrop(sender As Object, e As DragEventArgs) Handles Text_SourceImage.DragDrop
        TextBox_DragDropImageFile(sender, e)
    End Sub

    Private Sub Text_SourceImage_DragEnter(sender As Object, e As DragEventArgs) Handles Text_SourceImage.DragEnter
        TextBox_DragEnterImageFile(sender, e, ".jpg .jpeg .bmp .png .gif .tif .tiff")
    End Sub

    Public Sub Cmd_SelectFile_Click(sender As Object, e As EventArgs) Handles Cmd_SelectFile.Click
        Static Pre_Path As String = ""

        With OpenFileDialog
            If Pre_Path = "" Then
                If MyFileSysEng.FolderExists(
                        MyFileSysEng.Get_OnlyPath_FullFileName(
                                Text_SourceImage.Text)) Then
                    Pre_Path = MyFileSysEng.Get_OnlyPath_FullFileName(
                                        Text_SourceImage.Text)
                Else
                    Pre_Path = .InitialDirectory
                End If
            End If
            .InitialDirectory = Pre_Path

            .FileName = ""
            .Title = "Select image file"
            .CheckFileExists = True
            .CheckPathExists = True
            .ShowReadOnly = False
            .Filter = "Image file|*.jpeg;*.jpg;*.png;*.bmp;*.gif;*.tiff;*.tif"
            .FilterIndex = 1

            If .ShowDialog = DialogResult.OK Then
                Text_SourceImage.Text = .FileName

                Cmd_ReadImage_Click(Nothing, Nothing)
            End If
        End With
    End Sub

    Private Sub Cmd_Test_Screening_Click(sender As Object, e As EventArgs) Handles Cmd_Test_Screening.Click
        If MyFileSysEng.FileExists(Text_SourceImage.Text) = False Then
            MsgBox("Image file not found!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        With Frm_ImageViewer
            If .Cmd_QuickAnim.Text <> "Animate" Then
                .Cmd_QuickAnim_Click(Nothing, Nothing)
            End If
        End With

        Read_ImageProcessingParameters()

        MyAnimal.Detect_Animals(
                        Check_EnableDNNImageClassification.Checked,
                        Text_SourceImage.Text,
                        False,
                        True)

        With Frm_ImageViewer
            .Combo_Anim1.SelectedIndex = 0
            .Combo_Anim2.SelectedIndex = 1

            If .Cmd_QuickAnim.Text = "Animate" Then
                .Cmd_QuickAnim_Click(Nothing, Nothing)
            End If
        End With
    End Sub



    Private Sub Cmd_ReadImage_Click(sender As Object, e As EventArgs) Handles Cmd_ReadImage.Click
        If MyFileSysEng.FileExists(Text_SourceImage.Text) = False Then
            MsgBox("Image file not found!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If


        Dim FileName_NoExt As String =
                   MyFileSysEng.Get_FilenameWithoutExtension_From_FullFileName(
                                         Text_SourceImage.Text)
        Dim TargetFolder As String =
                    MyFileSysEng.Get_OnlyPath_FullFileName(Text_SourceImage.Text) +
                                PathDelimit + FileName_NoExt
        Dim OutputImageFile As String = TargetFolder + PathDelimit + "FinalOverlap.png"


        If MyFileSysEng.FileExists(OutputImageFile) Then
            MyAnimal._Image_Source = MyImgProc.Image_FromFile(Text_SourceImage.Text)
            MyAnimal._Image_FinalOverLap = MyImgProc.Image_FromFile(OutputImageFile)

            With Frm_ImageViewer
                .Combo_Anim1.SelectedIndex = 0
                .Combo_Anim2.SelectedIndex = 3

                If .Cmd_QuickAnim.Text = "Animate" Then
                    .Cmd_QuickAnim_Click(Nothing, Nothing)
                End If
            End With
        Else
            With Frm_ImageViewer
                If .Cmd_QuickAnim.Text <> "Animate" Then
                    .Cmd_QuickAnim_Click(Nothing, Nothing)
                End If
            End With
            MyAnimal._Image_Source = MyImgProc.Image_FromFile(Text_SourceImage.Text)
            Frm_ImageViewer.Canvas.Image = CType(MyAnimal._Image_Source.Clone, Image)
        End If

    End Sub

End Class



