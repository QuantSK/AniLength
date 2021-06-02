<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileListBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView = New System.Windows.Forms.ListView()
        Me.Column_FileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Column_Size = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ImageList
        '
        Me.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'ListView
        '
        Me.ListView.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ListView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Column_FileName, Me.Column_Size})
        Me.ListView.GridLines = True
        Me.ListView.HideSelection = False
        Me.ListView.Location = New System.Drawing.Point(23, 22)
        Me.ListView.MultiSelect = False
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(360, 180)
        Me.ListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView.TabIndex = 1
        Me.ListView.UseCompatibleStateImageBehavior = False
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'Column_FileName
        '
        Me.Column_FileName.Text = "File name"
        Me.Column_FileName.Width = 250
        '
        'Column_Size
        '
        Me.Column_Size.Text = "Size (kb)"
        Me.Column_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Column_Size.Width = 100
        '
        'FileListBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.ListView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FileListBox"
        Me.Size = New System.Drawing.Size(530, 231)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents Column_FileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Column_Size As System.Windows.Forms.ColumnHeader

End Class
