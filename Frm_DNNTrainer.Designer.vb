<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DNNTrainer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_DNNTrainer))
        Me.Cmd_ReloadModel = New System.Windows.Forms.Button()
        Me.Cmd_BeginValidation = New System.Windows.Forms.Button()
        Me.Cmd_BeginTraining = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Text_LearningRate = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Text_BatchSize = New System.Windows.Forms.TextBox()
        Me.Text_Epoch = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Combo_Architecture = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Text_TestFraction = New System.Windows.Forms.TextBox()
        Me.Text_Seed = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cmd_SelectImageFolder = New System.Windows.Forms.Button()
        Me.Text_SourceImageFolder = New System.Windows.Forms.TextBox()
        Me.FolderDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.Cmd_ShowStatus = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmd_ReloadModel
        '
        Me.Cmd_ReloadModel.Location = New System.Drawing.Point(23, 343)
        Me.Cmd_ReloadModel.Name = "Cmd_ReloadModel"
        Me.Cmd_ReloadModel.Size = New System.Drawing.Size(196, 50)
        Me.Cmd_ReloadModel.TabIndex = 27
        Me.Cmd_ReloadModel.Text = "Reload Trained Model"
        Me.Cmd_ReloadModel.UseVisualStyleBackColor = True
        '
        'Cmd_BeginValidation
        '
        Me.Cmd_BeginValidation.Location = New System.Drawing.Point(577, 343)
        Me.Cmd_BeginValidation.Name = "Cmd_BeginValidation"
        Me.Cmd_BeginValidation.Size = New System.Drawing.Size(150, 50)
        Me.Cmd_BeginValidation.TabIndex = 26
        Me.Cmd_BeginValidation.Text = "Begin validation"
        Me.Cmd_BeginValidation.UseVisualStyleBackColor = True
        '
        'Cmd_BeginTraining
        '
        Me.Cmd_BeginTraining.Location = New System.Drawing.Point(263, 343)
        Me.Cmd_BeginTraining.Name = "Cmd_BeginTraining"
        Me.Cmd_BeginTraining.Size = New System.Drawing.Size(150, 50)
        Me.Cmd_BeginTraining.TabIndex = 25
        Me.Cmd_BeginTraining.Text = "Begin training"
        Me.Cmd_BeginTraining.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Text_LearningRate)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Text_BatchSize)
        Me.GroupBox4.Controls.Add(Me.Text_Epoch)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Combo_Architecture)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Text_TestFraction)
        Me.GroupBox4.Controls.Add(Me.Text_Seed)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Location = New System.Drawing.Point(23, 150)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(704, 176)
        Me.GroupBox4.TabIndex = 24
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "DNN training parameters"
        '
        'Text_LearningRate
        '
        Me.Text_LearningRate.Location = New System.Drawing.Point(437, 125)
        Me.Text_LearningRate.Name = "Text_LearningRate"
        Me.Text_LearningRate.Size = New System.Drawing.Size(67, 27)
        Me.Text_LearningRate.TabIndex = 21
        Me.Text_LearningRate.Text = "0.2"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(291, 128)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 20)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Learning rate"
        '
        'Text_BatchSize
        '
        Me.Text_BatchSize.Location = New System.Drawing.Point(156, 128)
        Me.Text_BatchSize.Name = "Text_BatchSize"
        Me.Text_BatchSize.Size = New System.Drawing.Size(67, 27)
        Me.Text_BatchSize.TabIndex = 19
        Me.Text_BatchSize.Text = "100"
        '
        'Text_Epoch
        '
        Me.Text_Epoch.Location = New System.Drawing.Point(437, 82)
        Me.Text_Epoch.Name = "Text_Epoch"
        Me.Text_Epoch.Size = New System.Drawing.Size(67, 27)
        Me.Text_Epoch.TabIndex = 17
        Me.Text_Epoch.Text = "500"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(30, 131)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 20)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Batch size"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(291, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 20)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Epoch"
        '
        'Combo_Architecture
        '
        Me.Combo_Architecture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_Architecture.FormattingEnabled = True
        Me.Combo_Architecture.Items.AddRange(New Object() {"ResnetV2101", "InceptionV3", "MobilenetV2", "ResnetV250"})
        Me.Combo_Architecture.Location = New System.Drawing.Point(433, 35)
        Me.Combo_Architecture.Name = "Combo_Architecture"
        Me.Combo_Architecture.Size = New System.Drawing.Size(187, 28)
        Me.Combo_Architecture.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(291, 37)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 20)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Architecture"
        '
        'Text_TestFraction
        '
        Me.Text_TestFraction.Location = New System.Drawing.Point(156, 85)
        Me.Text_TestFraction.Name = "Text_TestFraction"
        Me.Text_TestFraction.Size = New System.Drawing.Size(67, 27)
        Me.Text_TestFraction.TabIndex = 13
        Me.Text_TestFraction.Text = "0.2"
        '
        'Text_Seed
        '
        Me.Text_Seed.Location = New System.Drawing.Point(156, 37)
        Me.Text_Seed.Name = "Text_Seed"
        Me.Text_Seed.Size = New System.Drawing.Size(67, 27)
        Me.Text_Seed.TabIndex = 3
        Me.Text_Seed.Text = "3"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(30, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 20)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Test fraction"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(30, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Seed number"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(147, 20)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Source image folder"
        '
        'Cmd_SelectImageFolder
        '
        Me.Cmd_SelectImageFolder.Location = New System.Drawing.Point(502, 22)
        Me.Cmd_SelectImageFolder.Name = "Cmd_SelectImageFolder"
        Me.Cmd_SelectImageFolder.Size = New System.Drawing.Size(225, 36)
        Me.Cmd_SelectImageFolder.TabIndex = 22
        Me.Cmd_SelectImageFolder.Text = "Select image folder"
        Me.Cmd_SelectImageFolder.UseVisualStyleBackColor = True
        '
        'Text_SourceImageFolder
        '
        Me.Text_SourceImageFolder.AllowDrop = True
        Me.Text_SourceImageFolder.Location = New System.Drawing.Point(23, 66)
        Me.Text_SourceImageFolder.Multiline = True
        Me.Text_SourceImageFolder.Name = "Text_SourceImageFolder"
        Me.Text_SourceImageFolder.Size = New System.Drawing.Size(704, 61)
        Me.Text_SourceImageFolder.TabIndex = 21
        '
        'Cmd_ShowStatus
        '
        Me.Cmd_ShowStatus.Location = New System.Drawing.Point(446, 343)
        Me.Cmd_ShowStatus.Name = "Cmd_ShowStatus"
        Me.Cmd_ShowStatus.Size = New System.Drawing.Size(111, 50)
        Me.Cmd_ShowStatus.TabIndex = 28
        Me.Cmd_ShowStatus.Text = "Show status"
        Me.Cmd_ShowStatus.UseVisualStyleBackColor = True
        '
        'Frm_DNNTrainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 411)
        Me.Controls.Add(Me.Cmd_ShowStatus)
        Me.Controls.Add(Me.Cmd_ReloadModel)
        Me.Controls.Add(Me.Cmd_BeginValidation)
        Me.Controls.Add(Me.Cmd_BeginTraining)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Cmd_SelectImageFolder)
        Me.Controls.Add(Me.Text_SourceImageFolder)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_DNNTrainer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DNN Trainer For Image Classification"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Cmd_ReloadModel As Button
    Friend WithEvents Cmd_BeginValidation As Button
    Friend WithEvents Cmd_BeginTraining As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Text_LearningRate As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Text_BatchSize As TextBox
    Friend WithEvents Text_Epoch As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Combo_Architecture As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Text_TestFraction As TextBox
    Friend WithEvents Text_Seed As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Cmd_SelectImageFolder As Button
    Friend WithEvents Text_SourceImageFolder As TextBox
    Friend WithEvents FolderDialog As FolderBrowserDialog
    Friend WithEvents Cmd_ShowStatus As Button
End Class
