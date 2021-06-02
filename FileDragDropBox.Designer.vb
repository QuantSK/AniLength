<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileDragDropBox
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
        Me.ListView = New System.Windows.Forms.ListView()
        Me.Column_FileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Column_Size = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Column_Folder = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ListView
        '
        Me.ListView.AllowDrop = True
        Me.ListView.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Column_FileName, Me.Column_Size, Me.Column_Folder})
        Me.ListView.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ListView.FullRowSelect = True
        Me.ListView.GridLines = True
        Me.ListView.Location = New System.Drawing.Point(3, 35)
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(511, 180)
        Me.ListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView.TabIndex = 2
        Me.ListView.UseCompatibleStateImageBehavior = False
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'Column_FileName
        '
        Me.Column_FileName.Text = "File name"
        Me.Column_FileName.Width = 180
        '
        'Column_Size
        '
        Me.Column_Size.Text = "Size (kb)"
        Me.Column_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Column_Size.Width = 100
        '
        'Column_Folder
        '
        Me.Column_Folder.Text = "Folder"
        Me.Column_Folder.Width = 500
        '
        'FileDragDropBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListView)
        Me.Name = "FileDragDropBox"
        Me.Size = New System.Drawing.Size(543, 279)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents Column_FileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Column_Size As System.Windows.Forms.ColumnHeader
    Friend WithEvents Column_Folder As System.Windows.Forms.ColumnHeader

End Class
