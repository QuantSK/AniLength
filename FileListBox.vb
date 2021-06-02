Imports System.Collections.Generic
Imports System.IO

Public Class FileListBox
    Dim ihwnd As IntPtr
    Dim ico As Icon
    Dim _CurrentFullPath As String
    Dim _ExtFilter As String = ""
    Dim _IsScanning As Boolean = False

    Declare Auto Function ExtractIcon Lib "Shell32" (
                            ByVal spz As Int32,
                            ByVal spathtoextracticonfrom As String,
                            ByVal iconindex As Int32) As IntPtr

    Private lvwColumnSorter As ListViewColumnSorter

    Public Event FileSelected(ByVal FileName As String, ByVal FullPath As String, ByVal SelectedIndex As Integer)
    Public Event UpdatingList(ByVal FilesCount As Integer, ByVal CurrentFileIndex As Integer)
    Public Event ListUpdated()

    Dim _IsLoading As Boolean = True



    Public Sub FileListBox_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        With ListView
            .Width = Me.Width
            .Height = Me.Height
            .Left = 0
            .Top = 0
            .AllowColumnReorder = False
            .View = View.Details
        End With

        _CurrentFullPath = Application.StartupPath
        Call ReScan()

        _IsLoading = False
    End Sub

    Private Sub FilerListBox_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        If _IsLoading Then Exit Sub


        With ListView
            .Width = Me.Width
            .Height = Me.Height
            .Left = 0
            .Top = 0

            .Columns(0).Width = CInt((Me.Width - 20) * 0.7)
            .Columns(1).Width = CInt((Me.Width - 20) * 0.3)
        End With
    End Sub


    Public Sub ReScan()
        If _IsLoading Then Exit Sub


        Dim myFile As String
        Dim myItem As ListViewItem
        Dim myItemDetails(1) As String
        Dim AdvSelVisible As Boolean

        If _IsScanning Then
            Exit Sub
        End If



        _IsScanning = True

        ImageList.Images.Clear()
        ListView.Items.Clear()



        If MyFileSysEng.FolderExists(_CurrentFullPath) = False Or
            _CurrentFullPath = "" Then
            _IsScanning = False
            Exit Sub
        End If


        Dim files() As String = Directory.GetFiles(_CurrentFullPath)



        Dim FilesCount As Integer = files.GetUpperBound(0) - 1
        Dim CurrentFileIndex As Integer = 0

        'If Frm_Workspace.Visible = True Then
        ' AdvSelVisible = True
        ' Frm_Workspace.AdvSel.AnimationFreezed = True
        ' Else
        ' AdvSelVisible = False
        ' End If


        Me.ListView.ListViewItemSorter = Nothing


        Dim ListViewVirtual As New List(Of ListViewItem)


        Dim UpdatingModValue As Integer
        UpdatingModValue = Math.Max(CInt(files.GetUpperBound(0) / 100), 1)

        Try
            For Each myFile In files

                CurrentFileIndex += 1

                If CurrentFileIndex Mod UpdatingModValue = 0 Then
                    Application.DoEvents()
                    RaiseEvent UpdatingList(FilesCount, CurrentFileIndex)
                End If

                If _ExtFilter = "" OrElse InStr(_ExtFilter, Path.GetExtension(myFile).ToLower) <> 0 Then


                    If False Then
                        ico = Icon.ExtractAssociatedIcon(myFile)

                        ImageList.Images.Add(Path.GetFileName(myFile),
                                            ico.ToBitmap)
                    End If


                    myItemDetails(0) = Path.GetFileName(myFile)
                    myItemDetails(1) = Format(GetFileSize(myFile) / 1024, ".0")
                    myItem = New ListViewItem(myItemDetails,
                                              Path.GetFileName(myFile))
                    ListViewVirtual.Add(myItem)
                End If
            Next
        Catch
        End Try


        ListView.Items.AddRange(ListViewVirtual.ToArray())


        _IsScanning = False

        Me.ListView.ListViewItemSorter = lvwColumnSorter

        RaiseEvent ListUpdated()



        If AdvSelVisible Then
            'Frm_Workspace.AdvSel.AnimationFreezed = False
        End If

    End Sub

    Private Function GetFileSize(ByVal MyFilePath As String) As Long
        Dim MyFile As New FileInfo(MyFilePath)
        Dim FileSize As Long = MyFile.Length
        Return FileSize
    End Function

    Private Sub ListView_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView.ColumnClick
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


    Private Sub ListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView.SelectedIndexChanged
        If ListView.SelectedItems.Count = 1 Then
            RaiseEvent FileSelected(ListView.SelectedItems(0).Text,
                                    _CurrentFullPath,
                                    ListView.SelectedIndices(0))
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        lvwColumnSorter = New ListViewColumnSorter()
        Me.ListView.ListViewItemSorter = lvwColumnSorter
    End Sub
End Class
