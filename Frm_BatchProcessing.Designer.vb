<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BatchProcessing
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BatchProcessing))
        Me.Check_EnableDNN = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox_Msg = New System.Windows.Forms.TextBox()
        Me.Cmd_RunBatchProcessing = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.FileDDBox = New AniLength.FileDragDropBox()
        Me.SuspendLayout()
        '
        'Check_EnableDNN
        '
        Me.Check_EnableDNN.AutoSize = True
        Me.Check_EnableDNN.Checked = True
        Me.Check_EnableDNN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_EnableDNN.Location = New System.Drawing.Point(611, 17)
        Me.Check_EnableDNN.Name = "Check_EnableDNN"
        Me.Check_EnableDNN.Size = New System.Drawing.Size(115, 24)
        Me.Check_EnableDNN.TabIndex = 20
        Me.Check_EnableDNN.Text = "Enable DNN"
        Me.Check_EnableDNN.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(223, 20)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Drag image files to this list box"
        '
        'TextBox_Msg
        '
        Me.TextBox_Msg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Msg.Location = New System.Drawing.Point(23, 380)
        Me.TextBox_Msg.Name = "TextBox_Msg"
        Me.TextBox_Msg.ReadOnly = True
        Me.TextBox_Msg.Size = New System.Drawing.Size(700, 27)
        Me.TextBox_Msg.TabIndex = 19
        '
        'Cmd_RunBatchProcessing
        '
        Me.Cmd_RunBatchProcessing.Location = New System.Drawing.Point(416, 9)
        Me.Cmd_RunBatchProcessing.Name = "Cmd_RunBatchProcessing"
        Me.Cmd_RunBatchProcessing.Size = New System.Drawing.Size(180, 36)
        Me.Cmd_RunBatchProcessing.TabIndex = 18
        Me.Cmd_RunBatchProcessing.Text = "Run batch processing"
        Me.Cmd_RunBatchProcessing.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Location = New System.Drawing.Point(275, 9)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(99, 36)
        Me.Cmd_Clear.TabIndex = 16
        Me.Cmd_Clear.Text = "Clear list"
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'FileDDBox
        '
        Me.FileDDBox.AllowDrop = True
        Me.FileDDBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FileDDBox.Location = New System.Drawing.Point(23, 58)
        Me.FileDDBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FileDDBox.Name = "FileDDBox"
        Me.FileDDBox.Size = New System.Drawing.Size(701, 309)
        Me.FileDDBox.TabIndex = 15
        '
        'Frm_BatchProcessing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 421)
        Me.Controls.Add(Me.Check_EnableDNN)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox_Msg)
        Me.Controls.Add(Me.Cmd_RunBatchProcessing)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.FileDDBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_BatchProcessing"
        Me.Text = "Batch Processing"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Check_EnableDNN As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox_Msg As TextBox
    Friend WithEvents Cmd_RunBatchProcessing As Button
    Friend WithEvents Cmd_Clear As Button
    Friend WithEvents FileDDBox As FileDragDropBox
End Class
