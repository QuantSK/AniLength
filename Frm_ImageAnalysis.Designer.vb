<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_ImageAnalysis
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
    Public components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImageAnalysis))
        Me.Cmd_RunAnalysis = New System.Windows.Forms.Button()
        Me.Cmd_SelectFile = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Text_SourceImage = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Text_um = New System.Windows.Forms.TextBox()
        Me.Text_Pixels = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Cmd_LoadTrainedModel = New System.Windows.Forms.Button()
        Me.Check_EnableDNNImageClassification = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Check_AnimalInBlack = New System.Windows.Forms.CheckBox()
        Me.Cmd_Test_AdaptiveThresholding = New System.Windows.Forms.Button()
        Me.Text_Adaptive_Threshold = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Text_Adaptive_BoxSize = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cmd_Test_Screening = New System.Windows.Forms.Button()
        Me.Text_WidthMax = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Text_WidthMin = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Text_AreaMax = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Text_AreaMin = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.FolderDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.Cmd_ReadImage = New System.Windows.Forms.Button()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmd_RunAnalysis
        '
        Me.Cmd_RunAnalysis.Location = New System.Drawing.Point(542, 516)
        Me.Cmd_RunAnalysis.Name = "Cmd_RunAnalysis"
        Me.Cmd_RunAnalysis.Size = New System.Drawing.Size(154, 67)
        Me.Cmd_RunAnalysis.TabIndex = 8
        Me.Cmd_RunAnalysis.Text = "Run analysis"
        Me.Cmd_RunAnalysis.UseVisualStyleBackColor = True
        '
        'Cmd_SelectFile
        '
        Me.Cmd_SelectFile.Location = New System.Drawing.Point(397, 13)
        Me.Cmd_SelectFile.Name = "Cmd_SelectFile"
        Me.Cmd_SelectFile.Size = New System.Drawing.Size(145, 36)
        Me.Cmd_SelectFile.TabIndex = 3
        Me.Cmd_SelectFile.Text = "Select file"
        Me.Cmd_SelectFile.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(382, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(335, 20)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Alternatively, drag an image file to this text box"
        '
        'Text_SourceImage
        '
        Me.Text_SourceImage.AllowDrop = True
        Me.Text_SourceImage.Location = New System.Drawing.Point(16, 55)
        Me.Text_SourceImage.Multiline = True
        Me.Text_SourceImage.Name = "Text_SourceImage"
        Me.Text_SourceImage.Size = New System.Drawing.Size(701, 72)
        Me.Text_SourceImage.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Source image file"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.Text_um)
        Me.GroupBox5.Controls.Add(Me.Text_Pixels)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Location = New System.Drawing.Point(16, 413)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(701, 75)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Length measurement (user must measure the conversion factor)"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(460, 36)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 20)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "micro meter"
        '
        'Text_um
        '
        Me.Text_um.Location = New System.Drawing.Point(387, 33)
        Me.Text_um.Name = "Text_um"
        Me.Text_um.Size = New System.Drawing.Size(67, 27)
        Me.Text_um.TabIndex = 3
        Me.Text_um.Text = "23.39"
        '
        'Text_Pixels
        '
        Me.Text_Pixels.Location = New System.Drawing.Point(220, 35)
        Me.Text_Pixels.Name = "Text_Pixels"
        Me.Text_Pixels.Size = New System.Drawing.Size(67, 27)
        Me.Text_Pixels.TabIndex = 2
        Me.Text_Pixels.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(293, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 20)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Pixels   = "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Conversion factor"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Cmd_LoadTrainedModel)
        Me.GroupBox3.Controls.Add(Me.Check_EnableDNNImageClassification)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 504)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(483, 88)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DNN image classification"
        '
        'Cmd_LoadTrainedModel
        '
        Me.Cmd_LoadTrainedModel.Location = New System.Drawing.Point(220, 34)
        Me.Cmd_LoadTrainedModel.Name = "Cmd_LoadTrainedModel"
        Me.Cmd_LoadTrainedModel.Size = New System.Drawing.Size(227, 36)
        Me.Cmd_LoadTrainedModel.TabIndex = 14
        Me.Cmd_LoadTrainedModel.Text = "Reload Trained Model"
        Me.Cmd_LoadTrainedModel.UseVisualStyleBackColor = True
        '
        'Check_EnableDNNImageClassification
        '
        Me.Check_EnableDNNImageClassification.AutoSize = True
        Me.Check_EnableDNNImageClassification.Checked = True
        Me.Check_EnableDNNImageClassification.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_EnableDNNImageClassification.Location = New System.Drawing.Point(27, 41)
        Me.Check_EnableDNNImageClassification.Name = "Check_EnableDNNImageClassification"
        Me.Check_EnableDNNImageClassification.Size = New System.Drawing.Size(77, 24)
        Me.Check_EnableDNNImageClassification.TabIndex = 0
        Me.Check_EnableDNNImageClassification.Text = "Enable"
        Me.Check_EnableDNNImageClassification.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Check_AnimalInBlack)
        Me.GroupBox2.Controls.Add(Me.Cmd_Test_AdaptiveThresholding)
        Me.GroupBox2.Controls.Add(Me.Text_Adaptive_Threshold)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Text_Adaptive_BoxSize)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(702, 111)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Adaptive thresholding binarization"
        '
        'Check_AnimalInBlack
        '
        Me.Check_AnimalInBlack.AutoSize = True
        Me.Check_AnimalInBlack.Checked = True
        Me.Check_AnimalInBlack.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_AnimalInBlack.Location = New System.Drawing.Point(29, 80)
        Me.Check_AnimalInBlack.Name = "Check_AnimalInBlack"
        Me.Check_AnimalInBlack.Size = New System.Drawing.Size(231, 24)
        Me.Check_AnimalInBlack.TabIndex = 9
        Me.Check_AnimalInBlack.Text = "Animals shaded in the image"
        Me.Check_AnimalInBlack.UseVisualStyleBackColor = True
        '
        'Cmd_Test_AdaptiveThresholding
        '
        Me.Cmd_Test_AdaptiveThresholding.Location = New System.Drawing.Point(526, 26)
        Me.Cmd_Test_AdaptiveThresholding.Name = "Cmd_Test_AdaptiveThresholding"
        Me.Cmd_Test_AdaptiveThresholding.Size = New System.Drawing.Size(154, 62)
        Me.Cmd_Test_AdaptiveThresholding.TabIndex = 8
        Me.Cmd_Test_AdaptiveThresholding.Text = "Create binarized image"
        Me.Cmd_Test_AdaptiveThresholding.UseVisualStyleBackColor = True
        '
        'Text_Adaptive_Threshold
        '
        Me.Text_Adaptive_Threshold.Location = New System.Drawing.Point(414, 37)
        Me.Text_Adaptive_Threshold.Name = "Text_Adaptive_Threshold"
        Me.Text_Adaptive_Threshold.Size = New System.Drawing.Size(69, 27)
        Me.Text_Adaptive_Threshold.TabIndex = 7
        Me.Text_Adaptive_Threshold.Text = "86"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(293, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 20)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Threshold"
        '
        'Text_Adaptive_BoxSize
        '
        Me.Text_Adaptive_BoxSize.Location = New System.Drawing.Point(160, 37)
        Me.Text_Adaptive_BoxSize.Name = "Text_Adaptive_BoxSize"
        Me.Text_Adaptive_BoxSize.Size = New System.Drawing.Size(67, 27)
        Me.Text_Adaptive_BoxSize.TabIndex = 5
        Me.Text_Adaptive_BoxSize.Text = "200"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(29, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 20)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Box size"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cmd_Test_Screening)
        Me.GroupBox1.Controls.Add(Me.Text_WidthMax)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Text_WidthMin)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Text_AreaMax)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Text_AreaMin)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 299)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(702, 102)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Screening condition  (using appropriate values greatly reduces the processing tim" &
    "e!)"
        '
        'Cmd_Test_Screening
        '
        Me.Cmd_Test_Screening.Location = New System.Drawing.Point(524, 25)
        Me.Cmd_Test_Screening.Name = "Cmd_Test_Screening"
        Me.Cmd_Test_Screening.Size = New System.Drawing.Size(154, 67)
        Me.Cmd_Test_Screening.TabIndex = 12
        Me.Cmd_Test_Screening.Text = "Create region extracted image"
        Me.Cmd_Test_Screening.UseVisualStyleBackColor = True
        '
        'Text_WidthMax
        '
        Me.Text_WidthMax.Location = New System.Drawing.Point(412, 68)
        Me.Text_WidthMax.Name = "Text_WidthMax"
        Me.Text_WidthMax.Size = New System.Drawing.Size(69, 27)
        Me.Text_WidthMax.TabIndex = 7
        Me.Text_WidthMax.Text = "200"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(291, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Width max"
        '
        'Text_WidthMin
        '
        Me.Text_WidthMin.Location = New System.Drawing.Point(158, 68)
        Me.Text_WidthMin.Name = "Text_WidthMin"
        Me.Text_WidthMin.Size = New System.Drawing.Size(67, 27)
        Me.Text_WidthMin.TabIndex = 5
        Me.Text_WidthMin.Text = "15"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Width min"
        '
        'Text_AreaMax
        '
        Me.Text_AreaMax.Location = New System.Drawing.Point(412, 38)
        Me.Text_AreaMax.Name = "Text_AreaMax"
        Me.Text_AreaMax.Size = New System.Drawing.Size(69, 27)
        Me.Text_AreaMax.TabIndex = 3
        Me.Text_AreaMax.Text = "4000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(291, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Area max"
        '
        'Text_AreaMin
        '
        Me.Text_AreaMin.Location = New System.Drawing.Point(158, 38)
        Me.Text_AreaMin.Name = "Text_AreaMin"
        Me.Text_AreaMin.Size = New System.Drawing.Size(67, 27)
        Me.Text_AreaMin.TabIndex = 1
        Me.Text_AreaMin.Text = "300"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Area min"
        '
        'Cmd_ReadImage
        '
        Me.Cmd_ReadImage.Location = New System.Drawing.Point(572, 12)
        Me.Cmd_ReadImage.Name = "Cmd_ReadImage"
        Me.Cmd_ReadImage.Size = New System.Drawing.Size(145, 36)
        Me.Cmd_ReadImage.TabIndex = 13
        Me.Cmd_ReadImage.Text = "Read image"
        Me.Cmd_ReadImage.UseVisualStyleBackColor = True
        '
        'Frm_ImageAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 608)
        Me.Controls.Add(Me.Cmd_ReadImage)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Cmd_SelectFile)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Cmd_RunAnalysis)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Text_SourceImage)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ImageAnalysis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Image Analysis"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cmd_RunAnalysis As Button
    Friend WithEvents Text_SourceImage As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Text_AreaMin As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Text_AreaMax As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Text_WidthMax As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Text_WidthMin As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Text_Adaptive_Threshold As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Text_Adaptive_BoxSize As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Check_EnableDNNImageClassification As CheckBox
    Friend WithEvents Cmd_Test_AdaptiveThresholding As Button
    Friend WithEvents Cmd_LoadTrainedModel As Button
    Friend WithEvents Cmd_SelectFile As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents Check_AnimalInBlack As CheckBox
    Friend WithEvents FolderDialog As FolderBrowserDialog
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Text_um As TextBox
    Friend WithEvents Text_Pixels As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Cmd_Test_Screening As Button
    Friend WithEvents Cmd_ReadImage As Button
End Class
