Imports System.IO
Imports DNNTrainer

Public Class Frm_DNNTrainer

    Public WithEvents MyImgTrainer As New DNNBinaryImageClassificationTrainer
    Dim IsStopByUser As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.MdiParent = MDI_Main
    End Sub

    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Me.Hide()

    End Sub

    Private Sub Frm_DNNTrainer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text_SourceImageFolder.Text =
            Application.StartupPath + "Training images\C elegans (small set)"

        ' Application.SetHighDpiMode(HighDpiMode.PerMonitorV2)

        Combo_Architecture.SelectedIndex = 3
    End Sub


    Private Sub Cmd_SelectImageFolder_Click(sender As Object, e As EventArgs) Handles Cmd_SelectImageFolder.Click
        If MyFileSysEng.FolderExists(Text_SourceImageFolder.Text) Then
            FolderDialog.RootFolder = Environment.SpecialFolder.MyComputer
            FolderDialog.SelectedPath = Text_SourceImageFolder.Text
        End If

        If FolderDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Text_SourceImageFolder.Text = FolderDialog.SelectedPath
        End If
    End Sub

    Private Sub Cmd_ReloadModel_Click(sender As Object, e As EventArgs) Handles Cmd_ReloadModel.Click
        Frm_ImageAnalysis.Cmd_LoadTrainedModel_Click(Nothing, Nothing)
    End Sub

    Private Sub Cmd_BeginTraining_Click(sender As Object, e As EventArgs) Handles Cmd_BeginTraining.Click

        If MyFileSysEng.FolderExists(Text_SourceImageFolder.Text) = False Then
            MsgBox("Image folder not found!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If


        Dim Seed As Integer
        Dim Epoch As Integer
        Dim BatchSize As Integer
        Dim TestFraction As Single
        Dim LearningRate As Single
        Dim Architect As Integer

        Try
            Seed = CInt(Text_Seed.Text)
        Catch
            MsgBox("Seed number is wrong", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
        Try
            Epoch = CInt(Text_Epoch.Text)
        Catch
            MsgBox("Epoch is wrong", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
        Try
            BatchSize = CInt(Text_BatchSize.Text)
        Catch
            MsgBox("Batch is wrong", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
        Try
            TestFraction = CSng(Text_TestFraction.Text)
        Catch
            MsgBox("Test fraction is wrong", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
        Try
            LearningRate = CSng(Text_LearningRate.Text)
        Catch
            MsgBox("Learning rate is wrong", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try

        Architect = Combo_Architecture.SelectedIndex


        Dim SrcImgFolder As String = Text_SourceImageFolder.Text.Trim




        If Cmd_BeginTraining.Text = "Begin training" Then
            Cmd_BeginTraining.Text = "Stop training"
            Cmd_BeginValidation.Enabled = False

            UpdateStatus("Training initiated", 0)

            Frm_TrainingStatus.Show()
            Frm_TrainingStatus.BringToFront()
            Frm_TrainingStatus.ListBox_Msg.Items.Clear()

            MyImgTrainer.StartTraining(SrcImgFolder,
                                   SrcImgFolder,
                                   Seed,
                                   TestFraction,
                                   Architect,
                                   Epoch,
                                   BatchSize,
                                   LearningRate)
        Else
            MyImgTrainer.AbortTraining()
        End If


    End Sub

    Private Sub Cmd_BeginValidation_Click(sender As Object, e As EventArgs) Handles Cmd_BeginValidation.Click

        If Cmd_BeginValidation.Text = "Begin validation" Then
            Cmd_BeginValidation.Text = "Stop validation"
            Cmd_BeginTraining.Enabled = False
            IsStopByUser = False

            UpdateStatus("Validation initiated", 0)
            StartValidation()
            UpdateStatus("Validation completed", 100)

            Cmd_BeginValidation.Text = "Begin validation"
            Cmd_BeginTraining.Enabled = True
        Else
            IsStopByUser = True
        End If

    End Sub


    Public Sub StartValidation()
        IsStopByUser = False

        Dim SourceFolder As String = Text_SourceImageFolder.Text
        Dim Folder_0 As String = SourceFolder + "\0"
        Dim Folder_1 As String = SourceFolder + "\1"
        Dim imagePrediction As ImagePrediction
        Dim OutStr As New Text.StringBuilder
        Dim Filenames() As String
        Dim TN, FN, TP, FP As Integer

        UpdateStatus("Preparing DNN prediction...", 0)


        OutStr.Append("File,real,predicted,correct" + vbCrLf)


        Filenames = MyFileSysEng.Get_AllFileNamesInFolder(Folder_0)

        If IsStopByUser Then
            UpdateStatus("Validation aborted", 100)
            Exit Sub
        End If

        For q As Integer = 0 To Filenames.GetUpperBound(0)
            If IsStopByUser Then
                UpdateStatus("Validation aborted", 100)
                Exit Sub
            End If

            imagePrediction = MyImgPredictor.Predict(Folder_0, Filenames(q))

            OutStr.Append(Folder_0 + "\" + Filenames(q) + ",0," +
                          imagePrediction.PredictedLabel + "," +
                          If(imagePrediction.PredictedLabel = "0", "1", "0") + vbCrLf)
            If imagePrediction.PredictedLabel = "0" Then
                TN += 1
            Else
                FN += 1
            End If


            UpdateStatus("Processing  ...\0\" + Filenames(q) +
                              "    [" + (q + 1).ToString.Trim + " of " +
                              Filenames.GetUpperBound(0).ToString.Trim + "]",
                         (q + 1) / Filenames.GetUpperBound(0) * 100)

            Application.DoEvents()

        Next


        If IsStopByUser Then
            UpdateStatus("Validation aborted", 100)
            Exit Sub
        End If

        Filenames = MyFileSysEng.Get_AllFileNamesInFolder(Folder_1)

        If IsStopByUser Then
            UpdateStatus("Validation aborted", 100)
            Exit Sub
        End If


        For q As Integer = 0 To Filenames.GetUpperBound(0)
            If IsStopByUser Then
                UpdateStatus("Validation aborted", 100)
                Exit Sub
            End If


            imagePrediction = MyImgPredictor.Predict(Folder_1, Filenames(q))

            OutStr.Append(Folder_1 + "\" + Filenames(q) + ",0," +
                          imagePrediction.PredictedLabel + "," +
                          If(imagePrediction.PredictedLabel = "1", "1", "0") + vbCrLf)
            If imagePrediction.PredictedLabel = "1" Then
                TP += 1
            Else
                FP += 1
            End If

            UpdateStatus("Processing  ...\1\" + Filenames(q) +
                              "    [" + (q + 1).ToString.Trim + " of " +
                              Filenames.GetUpperBound(0).ToString.Trim + "]",
                         (q + 1) / Filenames.GetUpperBound(0) * 100)

            Application.DoEvents()
        Next

        If IsStopByUser Then
            UpdateStatus("Validation aborted", 100)
            Exit Sub
        End If

        OutStr.Append("----------------------------------------------------------" + vbCrLf +
              "True negative  : " + TN.ToString.Trim +
                  " of " + (TN + FN).ToString.Trim +
                  vbTab + "Accuracy of " + Format(TN / (TN + FN) * 100, "0.000") + "%" + vbCrLf +
              "False negative : " + FN.ToString.Trim +
                  " of " + (TN + FN).ToString.Trim +
                  vbTab + "Accuracy of " + Format(FN / (TN + FN) * 100, "0.000") + "%" + vbCrLf +
              "True positive  : " + TP.ToString.Trim +
                  " of " + (TP + FP).ToString.Trim +
                  vbTab + "Accuracy of " + Format(TP / (TP + FP) * 100, "0.000") + "%" + vbCrLf +
              "False positive : " + FP.ToString.Trim +
                  " of " + (TP + FP).ToString.Trim +
                  vbTab + "Accuracy of " + Format(FP / (TP + FP) * 100, "0.000") + "%" + vbCrLf +
              "----------------------------------------------------------" + vbCrLf +
              "Correct: " + (TN + TP).ToString.Trim + " of " + (TN + FN + TP + FP).ToString.Trim +
                  vbTab + "Accuracy of " + Format((TN + TP) / (TN + FN + TP + FP) * 100, "0.000") + "%" + vbCrLf +
              "Wrong  : " + (FN + FP).ToString.Trim + " of " + (TN + FN + TP + FP).ToString.Trim +
                  vbTab + "Accuracy of " + Format((FN + FP) / (TN + FN + TP + FP) * 100, "0.000") + "%" + vbCrLf +
                  "")

        If IsStopByUser Then
            UpdateStatus("Validation aborted", 100)
            Exit Sub
        End If

        File.WriteAllText(SourceFolder + "\Validation.csv", OutStr.ToString)

        If IsStopByUser Then
            UpdateStatus("Validation aborted", 100)
            Exit Sub
        End If


        UpdateStatus("Processing completed", 100)

        MsgBox("Validation has been completed!" + vbCrLf +
               "'Validation.csv' created." + vbCrLf,
               MsgBoxStyle.OkOnly, "Validation")
    End Sub



    Private Sub Frm_DNNTrainer_ProgressMessage(JobID As Integer, Msg As String) Handles MyImgTrainer.ProgressMessage
        With Frm_TrainingStatus.ListBox_Msg
            .BeginUpdate()
            .Items.Add(Msg)
            .SelectedIndex = .Items.Count - 1
            .EndUpdate()
        End With
    End Sub

    Private Sub Cmd_ShowStatus_Click(sender As Object, e As EventArgs) Handles Cmd_ShowStatus.Click
        With Frm_TrainingStatus
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub Frm_DNNTrainer_TrainingCompleted(IsTrainingAbortedByUser As Boolean) Handles MyImgTrainer.TrainingCompleted
        If IsTrainingAbortedByUser Then
            UpdateStatus("Training aborted", 100)
        Else
            UpdateStatus("Training completed", 100)

            MsgBox("Training has been completed!" + vbCrLf +
            "The trained model zip file created." + vbCrLf +
            "You may want to replace the original 'TrainedModel.zip' with a new one",
            MsgBoxStyle.OkOnly, "Training")
        End If

        Cmd_BeginTraining.Text = "Begin training"
        Cmd_BeginTraining.Enabled = True
        Cmd_BeginValidation.Enabled = True
    End Sub
End Class