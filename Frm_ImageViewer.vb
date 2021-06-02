Imports System.IO
Imports System.Drawing.Imaging


Public Class Frm_ImageViewer


    Dim _IsFormLoading As Boolean = True
    Private FileSaveDialog As New SaveFileDialog
    Dim m_PanStartPoint As Point
    Private _DrawingFont As New Font("Microsoft Sans Serif", 12,
                                    FontStyle.Regular, GraphicsUnit.Pixel)


    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Me.Hide()
    End Sub


    Private Sub Frm_ImageViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Canvas
            '.Image = New Bitmap(100, 100)
            .PanMode = True
        End With

        Combo_AnimInterval.Text = "500"
        Combo_Anim1.SelectedIndex = 0
        Combo_Anim2.SelectedIndex = 0
        _IsFormLoading = False
    End Sub


    Public Sub New()
        InitializeComponent()

        Me.MdiParent = MDI_Main
    End Sub



    Private Sub Cmd_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Copy.Click
        Copy()
    End Sub


    Public Sub Copy()
        Try
            Clipboard.Clear()
            Clipboard.SetImage(Canvas.Image)
        Catch
            MsgBox("Failed to copy image!", MsgBoxStyle.Critical)
        End Try
    End Sub



    Public Sub Cmd_Zoom100_Click(sender As Object, e As EventArgs) Handles Cmd_Zoom100.Click
        Canvas.ZoomFactor = 1
    End Sub

    Public Sub Cmd_ZoomIn_Click(sender As Object, e As EventArgs) Handles Cmd_ZoomIn.Click
        Canvas.ZoomIn()
    End Sub

    Public Sub Cmd_ZoomOut_Click(sender As Object, e As EventArgs) Handles Cmd_ZoomOut.Click
        Canvas.ZoomOut()
    End Sub

    Public Sub Menu_ResetZoom_Click(sender As Object, e As EventArgs) Handles Menu_ResetZoom.Click
        If Menu_Stretchtofit.Checked Then
            Call Menu_Stretchtofit_Click(Nothing, Nothing)
        End If

        Canvas.Origin = New Point(0, 0)
        Canvas.ZoomFactor = 1
    End Sub

    Public Sub Menu_Stretchtofit_Click(sender As Object, e As EventArgs) Handles Menu_Stretchtofit.Click
        Menu_Stretchtofit.Checked = Not (Menu_Stretchtofit.Checked)
        Canvas.StretchImageToFit = Menu_Stretchtofit.Checked

        Cmd_Zoom100.Enabled = Not (Menu_Stretchtofit.Checked)
        Cmd_ZoomIn.Enabled = Not (Menu_Stretchtofit.Checked)
        Cmd_ZoomOut.Enabled = Not (Menu_Stretchtofit.Checked)
    End Sub

    Public Sub Menu_Fittoscreen_Click(sender As Object, e As EventArgs) Handles Menu_Fittoscreen.Click
        If Menu_Stretchtofit.Checked Then
            Call Menu_Stretchtofit_Click(Nothing, Nothing)
        End If
        Canvas.fittoscreen()

    End Sub


    Public Sub Cmd_QuickAnim_Click(sender As Object, e As EventArgs) Handles Cmd_QuickAnim.Click
        If Cmd_QuickAnim.Text <> "No animation" Then
            Cmd_QuickAnim.Text = "No animation"
            Timer_Animation.Interval = CInt(Combo_AnimInterval.Text)
            Timer_Animation.Enabled = True
        Else
            Cmd_QuickAnim.Text = "Animate"
            Timer_Animation.Enabled = False
        End If
    End Sub


    Private Sub Timer_Animation_Tick(sender As Object, e As EventArgs) Handles Timer_Animation.Tick
        Static CurrentImageNum As Integer = 0

        If CurrentImageNum = 0 Then
            Select Case Combo_Anim1.SelectedIndex
                Case 0
                    Canvas.Image = CType(MyAnimal._Image_Source, Image)
                    Me.Text = "Image Viewer - Original image"
                Case 1
                    Canvas.Image = CType(MyAnimal._Image_BlackWhite, Image)
                    Me.Text = "Image Viewer - Binarized image"
                Case 2
                    Canvas.Image = CType(MyAnimal._Image_RegionExtraction, Image)
                    Me.Text = "Image Viewer - Region extracted image"
                Case 3
                    Canvas.Image = CType(MyAnimal._Image_RegionExtractionOverlap, Image)
                    Me.Text = "Image Viewer - Region labeled image"
                Case Else
            End Select
            CurrentImageNum = 1
        Else
            Select Case Combo_Anim2.SelectedIndex
                Case 0
                    Canvas.Image = CType(MyAnimal._Image_BlackWhite, Image)
                    Me.Text = "Image Viewer - Binarized image"
                Case 1
                    Canvas.Image = CType(MyAnimal._Image_RegionExtraction, Image)
                    Me.Text = "Image Viewer - Region extracted image"
                Case 2
                    Canvas.Image = CType(MyAnimal._Image_RegionExtractionOverlap, Image)
                    Me.Text = "Image Viewer - Region labeled image"
                Case 3
                    Canvas.Image = CType(MyAnimal._Image_FinalOverLap, Image)
                    Me.Text = "Image Viewer - Region labeled image"
                Case Else
            End Select

            CurrentImageNum = 0
        End If

    End Sub


    Private Sub Combo_AnimInterval_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_AnimInterval.SelectedIndexChanged
        If _IsFormLoading Then Exit Sub

        Timer_Animation.Interval = CInt(Combo_AnimInterval.Text)
    End Sub


    Private Sub Frm_ImageViewer_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Canvas.Width = Me.ClientSize.Width
        Canvas.Height = Me.ClientSize.Height - ToolStrip.Height
    End Sub


End Class