<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_TrainingStatus
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_TrainingStatus))
        Me.ListBox_Msg = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ListBox_Msg
        '
        Me.ListBox_Msg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox_Msg.FormattingEnabled = True
        Me.ListBox_Msg.ItemHeight = 20
        Me.ListBox_Msg.Location = New System.Drawing.Point(18, 22)
        Me.ListBox_Msg.Name = "ListBox_Msg"
        Me.ListBox_Msg.ScrollAlwaysVisible = True
        Me.ListBox_Msg.Size = New System.Drawing.Size(914, 404)
        Me.ListBox_Msg.TabIndex = 1
        '
        'Frm_TrainingStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 450)
        Me.Controls.Add(Me.ListBox_Msg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_TrainingStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DNN Image Training Status"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox_Msg As ListBox
End Class
