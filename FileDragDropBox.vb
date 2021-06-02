Imports System.IO

Public Class FileDragDropBox

    Dim FileNameArray() As Integer
    Private lvwColumnSorter As ListViewColumnSorter

    Public Event FileClicked(ByVal FileName As String,
                                ByVal DirectoryPath As String)
    Public Event FileSelected(ByVal FileName As String,
                                ByVal DirectoryPath As String)
    Public Event FilesAdded(ByVal FileCount As Integer)
    Public Event FileAdding(ByVal FileCount As Integer)
    Public FileExtStrArray As String = ".jpg .jpeg .bmp .png .gif .tif .tiff"

    Public ReadOnly Property FilesCount As Integer
        Get
            Return ListView.Items.Count
        End Get
    End Property

    Public ReadOnly Property FileName(ByVal FileIndex As Integer) As String
        Get
            With ListView
                If .Items.Count < 1 Then Return ""
                If FileIndex > .Items.Count Then Return ""

                Return .Items(FileIndex).SubItems(0).Text

                '    .Items(.SelectedIndices(FileIndex)).SubItems(2).Text)
            End With

            Return ""
        End Get
    End Property


    Public ReadOnly Property FolderName(ByVal FileIndex As Integer) As String
        Get
            With ListView
                If .Items.Count < 1 Then Return ""
                If FileIndex > .Items.Count Then Return ""

                Return .Items(FileIndex).SubItems(2).Text

            End With

            Return ""
        End Get
    End Property



    Public Sub Clear()
        ListView.Items.Clear()
    End Sub

    Private Sub FileDragDropBox_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        With ListView
            .Width = Me.Width
            .Height = Me.Height
            .Left = 0
            .Top = 0
            .AllowColumnReorder = False
            .View = View.Details
        End With
    End Sub

    Private Sub FileDragDropBox_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        With ListView
            .Width = Me.Width
            .Height = Me.Height
            .Left = 0
            .Top = 0

            ListView.Columns(2).Width = Me.Width -
                    ListView.Columns(0).Width -
                    ListView.Columns(1).Width -
                    25

        End With
    End Sub

    Private Sub ListView_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView.ColumnClick
        If e.Column = 1 Then Exit Sub

        If (e.Column = lvwColumnSorter.SortColumn) Then
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If
        '
        Me.ListView.Sort()
    End Sub

    Private Sub ListView_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ListView.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String

            MyFiles = CType(e.Data.GetData(DataFormats.FileDrop), String())

            Call Me.Add(MyFiles)
        Else


            If e.Data.GetDataPresent(DataFormats.Bitmap) Then

                Dim ReturnImage As Image

                ReturnImage = CType(e.Data.GetData(GetType(Bitmap)), Image)

                If ReturnImage.Tag.ToString <> "" Then
                    Dim FileName(0) As String
                    FileName(0) = ReturnImage.Tag.ToString
                    Call Me.Add(FileName)
                End If
            End If
        End If
    End Sub

    Private Sub ListView_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ListView.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String

            MyFiles = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If InStr(FileExtStrArray,
                        Path.GetExtension(MyFiles(0)).ToLower) <> 0 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
                If e.Data.GetDataPresent(DataFormats.Bitmap) Then

                Dim ReturnImage As Image

                ReturnImage = CType(e.Data.GetData(GetType(Bitmap)), Image)

                If ReturnImage.Tag.ToString <> "" Then
                    e.Effect = DragDropEffects.Copy
                End If

            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    Private Sub ListView_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ListView.KeyUp
        With ListView
            If .Items.Count < 1 Then Exit Sub

            Try
                If ListView.SelectedIndices(0) > -1 Then
                    RaiseEvent FileClicked(
                        .Items(.SelectedIndices(0)).SubItems(0).Text,
                        .Items(.SelectedIndices(0)).SubItems(2).Text)
                End If
            Catch
            End Try
        End With
    End Sub

    Private Sub ListView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView.MouseUp
        With ListView
            If .Items.Count < 1 Then Exit Sub

            Try

                If ListView.SelectedIndices(0) > -1 Then
                    RaiseEvent FileClicked(
                        .Items(.SelectedIndices(0)).SubItems(0).Text,
                        .Items(.SelectedIndices(0)).SubItems(2).Text)
                End If
            Catch
            End Try
        End With
    End Sub


    Private Sub Add(ByVal FileListArray() As String)
        Dim myItem As ListViewItem
        Dim myItemDetails(2) As String
        Dim FileUpBound As Integer
        Dim q As Integer

        Me.ListView.ListViewItemSorter = Nothing

        ListView.BeginUpdate()


        FileUpBound = FileListArray.GetUpperBound(0)

        For q = 0 To FileUpBound
            If InStr(FileExtStrArray,
                        Path.GetExtension(FileListArray(q)).ToLower) <> 0 Then

                myItemDetails(2) = Path.GetDirectoryName(FileListArray(q))
                myItemDetails(0) = Path.GetFileName(FileListArray(q))
                myItemDetails(1) = Format(GetFileSize(FileListArray(q)) / 1024,
                                          ".0")

                myItem = New ListViewItem(myItemDetails)
                ListView.Items.Add(myItem)

                Application.DoEvents()
                RaiseEvent FileAdding(ListView.Items.Count)
            End If
        Next


        ListView.EndUpdate()

        Me.ListView.ListViewItemSorter = lvwColumnSorter

        RaiseEvent FilesAdded(ListView.Items.Count)
    End Sub


    Private Function GetFileSize(ByVal MyFilePath As String) As Long
        Dim MyFile As New FileInfo(MyFilePath)
        Dim FileSize As Long = MyFile.Length
        Return FileSize
    End Function

    Private Sub ListView_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView.SelectedIndexChanged
        With ListView
            If .Items.Count < 1 Then Exit Sub

            Try

                If ListView.SelectedIndices(0) > -1 Then
                    RaiseEvent FileSelected(
                        .Items(.SelectedIndices(0)).SubItems(0).Text,
                        .Items(.SelectedIndices(0)).SubItems(2).Text)
                End If
            Catch
            End Try
        End With
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        lvwColumnSorter = New ListViewColumnSorter()
        Me.ListView.ListViewItemSorter = lvwColumnSorter
    End Sub
End Class
