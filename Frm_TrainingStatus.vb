

Public Class Frm_TrainingStatus
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

    Private Sub FrmTrainer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class