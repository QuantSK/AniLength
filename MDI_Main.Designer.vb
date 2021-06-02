<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDI_Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDI_Main))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Cmd_ImageProcessing = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_BatchProcessing = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_DNNTrainer = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Menu_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Open = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Window = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ImageProcessing = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_BatchProcessing = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_DNNTrainer = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip_Status = New System.Windows.Forms.StatusStrip()
        Me.Status_Info = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status_Progressbar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Status_Info2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status_Info3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip_Status.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_ImageProcessing, Me.ToolStripSeparator2, Me.Cmd_BatchProcessing, Me.ToolStripSeparator1, Me.Cmd_DNNTrainer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1095, 27)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Cmd_ImageProcessing
        '
        Me.Cmd_ImageProcessing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Cmd_ImageProcessing.Image = CType(resources.GetObject("Cmd_ImageProcessing.Image"), System.Drawing.Image)
        Me.Cmd_ImageProcessing.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ImageProcessing.Name = "Cmd_ImageProcessing"
        Me.Cmd_ImageProcessing.Size = New System.Drawing.Size(132, 24)
        Me.Cmd_ImageProcessing.Text = "Image processing"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'Cmd_BatchProcessing
        '
        Me.Cmd_BatchProcessing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Cmd_BatchProcessing.Image = CType(resources.GetObject("Cmd_BatchProcessing.Image"), System.Drawing.Image)
        Me.Cmd_BatchProcessing.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_BatchProcessing.Name = "Cmd_BatchProcessing"
        Me.Cmd_BatchProcessing.Size = New System.Drawing.Size(128, 24)
        Me.Cmd_BatchProcessing.Text = "Batch processing"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'Cmd_DNNTrainer
        '
        Me.Cmd_DNNTrainer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Cmd_DNNTrainer.Image = CType(resources.GetObject("Cmd_DNNTrainer.Image"), System.Drawing.Image)
        Me.Cmd_DNNTrainer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_DNNTrainer.Name = "Cmd_DNNTrainer"
        Me.Cmd_DNNTrainer.Size = New System.Drawing.Size(98, 24)
        Me.Cmd_DNNTrainer.Text = "DNN Trainer"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_File, Me.Menu_Edit, Me.Menu_Window, Me.Menu_About})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1095, 28)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Menu_File
        '
        Me.Menu_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Open, Me.toolStripSeparator, Me.Menu_Exit})
        Me.Menu_File.Name = "Menu_File"
        Me.Menu_File.Size = New System.Drawing.Size(46, 24)
        Me.Menu_File.Text = "&File"
        '
        'Menu_Open
        '
        Me.Menu_Open.Image = CType(resources.GetObject("Menu_Open.Image"), System.Drawing.Image)
        Me.Menu_Open.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Menu_Open.Name = "Menu_Open"
        Me.Menu_Open.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.Menu_Open.Size = New System.Drawing.Size(186, 26)
        Me.Menu_Open.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(183, 6)
        '
        'Menu_Exit
        '
        Me.Menu_Exit.Name = "Menu_Exit"
        Me.Menu_Exit.Size = New System.Drawing.Size(186, 26)
        Me.Menu_Exit.Text = "E&xit"
        '
        'Menu_Edit
        '
        Me.Menu_Edit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Copy})
        Me.Menu_Edit.Name = "Menu_Edit"
        Me.Menu_Edit.Size = New System.Drawing.Size(49, 24)
        Me.Menu_Edit.Text = "&Edit"
        '
        'Menu_Copy
        '
        Me.Menu_Copy.Image = CType(resources.GetObject("Menu_Copy.Image"), System.Drawing.Image)
        Me.Menu_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Menu_Copy.Name = "Menu_Copy"
        Me.Menu_Copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.Menu_Copy.Size = New System.Drawing.Size(181, 26)
        Me.Menu_Copy.Text = "&Copy"
        '
        'Menu_Window
        '
        Me.Menu_Window.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_ImageProcessing, Me.Menu_BatchProcessing, Me.Menu_DNNTrainer})
        Me.Menu_Window.Name = "Menu_Window"
        Me.Menu_Window.Size = New System.Drawing.Size(79, 24)
        Me.Menu_Window.Text = "&Window"
        '
        'Menu_ImageProcessing
        '
        Me.Menu_ImageProcessing.Name = "Menu_ImageProcessing"
        Me.Menu_ImageProcessing.Size = New System.Drawing.Size(312, 26)
        Me.Menu_ImageProcessing.Text = "Image Processing"
        '
        'Menu_BatchProcessing
        '
        Me.Menu_BatchProcessing.Name = "Menu_BatchProcessing"
        Me.Menu_BatchProcessing.Size = New System.Drawing.Size(312, 26)
        Me.Menu_BatchProcessing.Text = "&Batch processing"
        '
        'Menu_DNNTrainer
        '
        Me.Menu_DNNTrainer.Name = "Menu_DNNTrainer"
        Me.Menu_DNNTrainer.Size = New System.Drawing.Size(312, 26)
        Me.Menu_DNNTrainer.Text = "&DNN image classification trainer"
        '
        'Menu_About
        '
        Me.Menu_About.Name = "Menu_About"
        Me.Menu_About.Size = New System.Drawing.Size(65, 24)
        Me.Menu_About.Text = "About"
        '
        'StatusStrip_Status
        '
        Me.StatusStrip_Status.AutoSize = False
        Me.StatusStrip_Status.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip_Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status_Info, Me.Status_Progressbar, Me.Status_Info2, Me.Status_Info3})
        Me.StatusStrip_Status.Location = New System.Drawing.Point(0, 503)
        Me.StatusStrip_Status.Name = "StatusStrip_Status"
        Me.StatusStrip_Status.Size = New System.Drawing.Size(1095, 34)
        Me.StatusStrip_Status.TabIndex = 8
        '
        'Status_Info
        '
        Me.Status_Info.AutoSize = False
        Me.Status_Info.Name = "Status_Info"
        Me.Status_Info.Size = New System.Drawing.Size(500, 28)
        Me.Status_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Status_Progressbar
        '
        Me.Status_Progressbar.AutoSize = False
        Me.Status_Progressbar.Name = "Status_Progressbar"
        Me.Status_Progressbar.Size = New System.Drawing.Size(300, 26)
        '
        'Status_Info2
        '
        Me.Status_Info2.Name = "Status_Info2"
        Me.Status_Info2.Size = New System.Drawing.Size(0, 28)
        Me.Status_Info2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Status_Info3
        '
        Me.Status_Info3.Name = "Status_Info3"
        Me.Status_Info3.Size = New System.Drawing.Size(0, 28)
        Me.Status_Info3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MDI_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 537)
        Me.Controls.Add(Me.StatusStrip_Status)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "MDI_Main"
        Me.Text = "AniLength 1.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip_Status.ResumeLayout(False)
        Me.StatusStrip_Status.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Menu_File As ToolStripMenuItem
    Friend WithEvents Menu_Open As ToolStripMenuItem
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents Menu_Edit As ToolStripMenuItem
    Friend WithEvents Menu_Copy As ToolStripMenuItem
    Friend WithEvents Menu_Window As ToolStripMenuItem
    Friend WithEvents Menu_Batch As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Menu_BatchProcessing As ToolStripMenuItem
    Friend WithEvents Menu_DNNTrainer As ToolStripMenuItem
    Friend WithEvents StatusStrip_Status As StatusStrip
    Friend WithEvents Status_Info As ToolStripStatusLabel
    Friend WithEvents Status_Progressbar As ToolStripProgressBar
    Friend WithEvents Status_Info2 As ToolStripStatusLabel
    Friend WithEvents Status_Info3 As ToolStripStatusLabel
    Friend WithEvents Cmd_BatchProcessing As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Cmd_DNNTrainer As ToolStripButton
    Friend WithEvents Cmd_ImageProcessing As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Menu_ImageProcessing As ToolStripMenuItem
    Friend WithEvents Menu_About As ToolStripMenuItem
End Class
