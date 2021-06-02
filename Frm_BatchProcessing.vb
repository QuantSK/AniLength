Public Class Frm_BatchProcessing
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


    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        FileDDBox.Clear()
    End Sub

    Private Sub Cmd_RunBatchProcessing_Click(sender As Object, e As EventArgs) Handles Cmd_RunBatchProcessing.Click
        If Cmd_RunBatchProcessing.Text = "Stop processing" Then
            MyAnimal.Stop_Processing()
            Exit Sub
        End If


        Cmd_RunBatchProcessing.Text = "Stop processing"

        With Frm_ImageViewer
            If .Cmd_QuickAnim.Text <> "Animate" Then
                .Cmd_QuickAnim_Click(Nothing, Nothing)
            End If
        End With


        Dim CurIndex As Integer

        Frm_ImageAnalysis.Read_ImageProcessingParameters()


        For CurIndex = 0 To FileDDBox.FilesCount - 1
            TextBox_Msg.Text = "Processing  " + FileDDBox.FileName(CurIndex) +
                              "    [" + (CurIndex + 1).ToString.Trim + " of " +
                              FileDDBox.FilesCount.ToString.Trim + "]"
            TextBox_Msg.Refresh()
            Application.DoEvents()

            MyAnimal.Detect_Animals(
                        Check_EnableDNN.Checked,
                        FileDDBox.FolderName(CurIndex) + "\" +
                        FileDDBox.FileName(CurIndex))

            If MyAnimal._Image_FinalOverLap IsNot Nothing Then
                Frm_ImageViewer.Canvas.Image =
                        CType(MyAnimal._Image_FinalOverLap.Clone, Bitmap)
            End If

            Application.DoEvents()

            If MyAnimal._UserStopped Then Exit For
        Next


        If MyAnimal._UserStopped Then
            TextBox_Msg.Text = "Batch processing terminated by user"
        Else
            TextBox_Msg.Text = "Batch processing completed"
        End If
        Cmd_RunBatchProcessing.Text = "Run batch processing"
    End Sub
End Class