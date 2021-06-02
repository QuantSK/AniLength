Imports System.Math
Imports System.IO
Imports System.Text
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Animal
    Public Structure Type_ScreeningCondition
        Dim Area_Max As Integer
        Dim Area_Min As Integer
        Dim Width_Max As Integer
        Dim Width_Min As Integer
        Dim AdaptiveBoxSize As Integer
        Dim AdaptiveThreshold As Integer
        Dim IsObjectWhite As Boolean
    End Structure


    <Serializable()> Public Structure ID_Info
        Dim PixelCount As Double
        Dim AvgCenter_X As Double
        Dim AvgCenter_Y As Double
        Dim X1 As Integer
        Dim Y1 As Integer
        Dim X2 As Integer
        Dim Y2 As Integer
        Dim Width As Integer
        Dim Height As Integer
        Dim IsExcludeThisID As Boolean
        Dim AnimalCount As Integer
        Dim TrueLength As Single
        Dim ArrangedValidID As Integer
    End Structure


    'Permanent image
    Public _Image_Source,
           _Image_Gray,
           _Image_NegativeGray,
           _Image_BlackWhite,
           _Image_FinalOverLap,
           _Image_FinalOverLapWithoutLabels,
           _Image_Debug As Image


    'Temporary image
    Public _Image_RegionExtraction,
           _Image_RegionExtractionOverlap As Image



    'Image infromation
    Public _ImageWidth, _ImageHeight As Integer
    Public _ImageWidthUpperBound, _ImageHeightUpperBound As Integer



    Public _ObjectImageMargin As Integer = 50
    Public _ObjectImageDilateBoxSize As Integer = 4



    'Detected objects after region extraction
    Public _FoundRegionColorTable(,) As Byte = Nothing
    '           1st: LabelID number,  2nd: R (,0)  G (,1)   B (,2)


    Public _LabelIDMap(,) As Integer = Nothing


    'Detailed object infromation
    Public _IDInfo() As ID_Info


    'User-Interruption
    Public _UserStopped As Boolean = False


    'Screening condition to check object is an egg
    Public myScreeningCondition As Type_ScreeningCondition


    Private _DrawingFont As New Font("Microsoft Sans Serif", 18 _
                          , FontStyle.Bold, GraphicsUnit.Pixel)

    Dim TargetFolder As String
    Dim FileName_NoExt As String

    Public umPerPixels As Integer = 1



    Public Sub New()
        With myScreeningCondition
            .Area_Min = 200
            .Area_Max = 4000
            .Width_Min = 15
            .Width_Max = 200
            .AdaptiveBoxSize = 200
            .AdaptiveThreshold = 86
            .IsObjectWhite = False
        End With

    End Sub

    Public Event ProgressStatus(Msg As String, ProgressValue As Integer)


    Public Sub Stop_Processing()
        _UserStopped = True
    End Sub


    Public Function Detect_Animals(IsUseAItoPredict As Boolean,
                                SourceImageFullFilename As String,
                                Optional IsBinarizationOnly As Boolean = False,
                                Optional IsRegionExtractionOnly As Boolean = False) As Integer
        'Return 0 if OK
        'Return -1 if user stop analysis


        _UserStopped = False


        RaiseEvent ProgressStatus("Creating output folders...", 0)


        SourceFullFilename = SourceImageFullFilename
        FileName_NoExt =
                   MyFileSysEng.Get_FilenameWithoutExtension_From_FullFileName(
                                         SourceFullFilename)
        TargetFolder =
                    MyFileSysEng.Get_OnlyPath_FullFileName(SourceFullFilename) +
                                "\" + FileName_NoExt

        Dim TargetFolder_Unclassified As String = TargetFolder + "\unclassified"

        Try
            With MyFileSysEng
                .CreateFolderAndDeleteAllFiles(TargetFolder)
                .CreateFolderAndDeleteAllFiles(TargetFolder + "\0")
                .CreateFolderAndDeleteAllFiles(TargetFolder + "\1")
                .CreateFolderAndDeleteAllFiles(TargetFolder_Unclassified)
            End With
        Catch ee As Exception
            MsgBox("Could not create output folders!" + vbCrLf + vbCrLf +
                    ee.ToString, MsgBoxStyle.Critical, "Error")

            Return -1
        End Try



        RaiseEvent ProgressStatus("Preparing image analysis...", 5)
        _Image_Source = MyImgProc.Image_FromFile(SourceFullFilename)

        _ImageWidth = _Image_Source.Width
        _ImageHeight = _Image_Source.Height
        _ImageWidthUpperBound = _Image_Source.Width - 1
        _ImageHeightUpperBound = _Image_Source.Height - 1



        RaiseEvent ProgressStatus("Blurring and grayscaling...", 10)

        Dim MaskImage As Image
        Dim IsAllRegion As Boolean

        If ROI_Boundary.X = -1 Then
            MaskImage = MyImgProc.Create_MaskRectangle(_ImageWidth,
                                                              _ImageHeight,
                                                             New Rectangle(0, 0, _ImageWidth, _ImageHeight))
            IsAllRegion = True
        Else
            MaskImage = MyImgProc.Create_MaskRectangle(_ImageWidth,
                                                             _ImageHeight,
                                                             ROI_Boundary)
            IsAllRegion = False
        End If


        _Image_Gray = MyImgProc.BoxAveraging_ByIntegralMap(_Image_Source, 2)
        If _UserStopped Then
            RaiseEvent ProgressStatus("Processing terminated by a user", 100)
            Return -1
        End If
        Application.DoEvents()


        _Image_Gray = MyImgProc.GrayScaling(_Image_Gray, MaskImage, ROI_Boundary, IsAllRegion)
        If _UserStopped Then
            RaiseEvent ProgressStatus("Processing terminated by a user", 100)
            Return -1
        End If
        Application.DoEvents()


        RaiseEvent ProgressStatus("Applying adaptive thresholding...", 20)
        If myScreeningCondition.IsObjectWhite Then
            _Image_BlackWhite = MyImgProc.DeepCopy(_Image_Gray)
        Else
            _Image_BlackWhite = MyImgProc.Invert(_Image_Gray)
        End If
        Application.DoEvents()


        _Image_BlackWhite = MyImgProc.BWLeveling_Using_AdaptiveThreshold(
                                               _Image_BlackWhite,
                                               myScreeningCondition.AdaptiveBoxSize,
                                               True,
                                               myScreeningCondition.AdaptiveThreshold,
                                               MaskImage,
                                               ROI_Boundary,
                                               IsAllRegion)
        If IsBinarizationOnly Then
            '_Image_BlackWhite.Save(TargetFolder + "-binarized.jpg")
            RaiseEvent ProgressStatus("Binarized image file generated!", 100)
            Return 0
        End If

        If _UserStopped Then
            RaiseEvent ProgressStatus("Processing terminated by a user", 100)
            Return -1
        End If
        Application.DoEvents()



        RaiseEvent ProgressStatus("Extracting regions..", 30)
        _Image_RegionExtraction = MyImgProc.RegionExtract_RasterScanning(
                                  _Image_BlackWhite,
                                  _LabelIDMap,
                                  _FoundRegionColorTable,
                                  0,
                                  MaskImage, ROI_Boundary, IsAllRegion)
        If _UserStopped Then
            RaiseEvent ProgressStatus("Processing terminated by a user", 100)
            Return -1
        End If
        Application.DoEvents()

        If IsRegionExtractionOnly Then
            '_Image_RegionExtraction.Save(TargetFolder + "-regionExtracted.jpg")
            RaiseEvent ProgressStatus("Region extracted image file generated!", 100)
            Return 0
        End If



        RaiseEvent ProgressStatus("Labeling detected objects...", 40)
        _LabelIDMap = Generate_LabelID(_LabelIDMap, _FoundRegionColorTable)
        If _UserStopped Then
            RaiseEvent ProgressStatus("Processing terminated by a user", 100)
            Return -1
        End If
        Application.DoEvents()



        If _UserStopped Then
            RaiseEvent ProgressStatus("Processing terminated by a user", 100)
            Return -1
        End If


        RaiseEvent ProgressStatus("Processing detected objects...", 50)
        Dim SourceImageArray(,,) As Byte =
                    MyImgProc.Convert_RGBImage_To_RGBByteArray(_Image_Source)
        Dim IDInfoUpper As Integer = _IDInfo.GetLength(0) - 1




        For q As Integer = 1 To IDInfoUpper

            If _UserStopped Then
                RaiseEvent ProgressStatus("Processing terminated by a user", 100)
                Return -1
            End If

            Application.DoEvents()

            With _IDInfo(q)

                If q Mod 50 = 0 Then
                    RaiseEvent ProgressStatus("Processing detected objects : " +
                                              q.ToString.Trim + " of " + IDInfoUpper.ToString.Trim,
                                              50 + CInt(q / IDInfoUpper * 50))

                    Application.DoEvents()
                End If



                If .IsExcludeThisID = False Then
                    'Safe bounding box
                    Dim xUpper As Integer = Min(_LabelIDMap.GetUpperBound(0), .X2 + _ObjectImageMargin)
                    Dim yUpper As Integer = Min(_LabelIDMap.GetUpperBound(1), .Y2 + _ObjectImageMargin)
                    Dim xLower As Integer = Max(0, .X1 - _ObjectImageMargin)
                    Dim yLower As Integer = Max(0, .Y1 - _ObjectImageMargin)

                    Dim TrueLength As Single


                    Using WhiteObjectOutlineImage As Image =
                                                MyImgProc.RegionExtract_Create_WhiteObjectOutlineImage(
                                                                _LabelIDMap, q,
                                                                xLower, xUpper,
                                                                yLower, yUpper,
                                                                _ObjectImageDilateBoxSize),
                           ColorObjectOutlineImage As Image = MyImgProc.Split_Red(
                                                                WhiteObjectOutlineImage),
                           SourceObjectImage As Image = MyImgProc.Crop(_Image_Source,
                                                                             xUpper - xLower + 1,
                                                                             yUpper - yLower + 1,
                                                                             xLower,
                                                                             yLower),
                           WhiteObjectImage As Image = MyImgProc.RegionExtract_Crop_WhiteObjectImage(
                                                                _LabelIDMap, q,
                                                                xLower, xUpper,
                                                                yLower, yUpper),
                           SkeletonImage As Image = Measure_Length(WhiteObjectImage,
                                                                  umPerPixels,
                                                                  TrueLength)

                        If SkeletonImage Is Nothing Then
                            .IsExcludeThisID = True
                            Continue For
                        Else
                            .TrueLength = TrueLength
                        End If


                        Dim FileName As String = FileName_NoExt + "-" + Format(q, "00000") + ".png"
                        Using FinalColorOutlinedObjectImage = MyImgProc.Overlay_MaskImage_to_Image(
                                                        MyImgProc.Overlay_MaskImage_to_Image(
                                                                            SourceObjectImage,
                                                                            ColorObjectOutlineImage,
                                                                            0),
                                                                            MyImgProc.Split_Green(SkeletonImage),
                                                                            0)
                            FinalColorOutlinedObjectImage.Save(TargetFolder_Unclassified + "\" + FileName)
                        End Using



                        Dim OutlineObjectImageArray(,) As Byte = MyImgProc.Convert_Image_To_2DByteArray(
                                                                      WhiteObjectOutlineImage)
                        MyImgProc.Overlay_MaskImage2DArray_To_Image3DArray(SourceImageArray,
                                                                             OutlineObjectImageArray,
                                                                             255,
                                                                             0,
                                                                             0,
                                                                             xLower, yLower, 0)

                        Dim SkeletonImageArray(,) As Byte =
                                    MyImgProc.Convert_Image_To_2DByteArray(SkeletonImage)

                        MyImgProc.Overlay_MaskImage2DArray_To_Image3DArray(SourceImageArray,
                                                                            SkeletonImageArray,
                                                                            0,
                                                                            255,
                                                                            0,
                                                                            xLower, yLower, 0)

                        If IsUseAItoPredict Then
                            Dim imagePrediction As ImagePrediction =
                                 MyImgPredictor.Predict(TargetFolder_Unclassified, FileName)

                            Dim predictedWormCount As Integer = CInt(imagePrediction.PredictedLabel)
                            .AnimalCount = predictedWormCount

                            If .AnimalCount = 0 Then
                                '.IsExcludeThisID = True
                            End If


                            MyFileSysEng.MoveFile(TargetFolder_Unclassified + "\" + FileName,
                                  TargetFolder + "\" +
                                  predictedWormCount.ToString.Trim + "\" +
                                  FileName)

                        End If
                    End Using
                End If
            End With
        Next
        If _UserStopped Then
            RaiseEvent ProgressStatus("Processing terminated by a user", 100)
            Return -1
        End If


        _Image_FinalOverLapWithoutLabels = MyImgProc.Convert_RGBByteArray_To_RGBImage(SourceImageArray)


        Rearrange_ValidID()
        Create_FinalOverlapLabels()

        Save_DetectionInfo()


        RaiseEvent ProgressStatus("Analysis completed...", 100)

        Return 0
    End Function

    Public Sub Rearrange_ValidID()
        Dim CurValidID As Integer = 0
        For w As Integer = 1 To _IDInfo.GetUpperBound(0)
            With _IDInfo(w)
                If .IsExcludeThisID = False Then
                    CurValidID += 1
                    .ArrangedValidID = CurValidID
                End If

            End With
        Next
    End Sub

    Public Sub Correct_WormCount(WormIndex As Integer, NewCount As Integer)
        Dim BeforeCount As Integer = _IDInfo(WormIndex).AnimalCount
        Dim FileName As String = FileName_NoExt + "-" + Format(WormIndex, "00000") + ".png"

        If BeforeCount = NewCount Then Exit Sub

        _IDInfo(WormIndex).AnimalCount = NewCount
        MyFileSysEng.MoveFile(TargetFolder + "\" + BeforeCount.ToString.Trim + "\" + FileName,
                              TargetFolder + "\" + NewCount.ToString.Trim + "\" + FileName)

    End Sub

    Public Sub Create_FinalOverlapLabels(Optional IsIncludeInvalidAnimals As Boolean = False)
        If _Image_FinalOverLapWithoutLabels Is Nothing OrElse _IDInfo Is Nothing Then Exit Sub

        _Image_FinalOverLap = Add_DetectionLabels_To_Image(_Image_FinalOverLapWithoutLabels,
                                                         _IDInfo,
                                                         New Font("Microsoft Sans Serif", 18,
                                                                  FontStyle.Bold, GraphicsUnit.Pixel))
    End Sub

    Public Sub Do_RegionExtraction()

        Dim BoxSizeValue As Integer = 25
        Dim IsObjectWhite As Boolean = True
        Dim ThresholdLevel As Integer = 90

        RaiseEvent ProgressStatus("Binarizing...", 20)

        _Image_BlackWhite = MyImgProc.BWLeveling_Using_AdaptiveThreshold(
                                                _Image_Gray, BoxSizeValue,
                                                IsObjectWhite,
                                                ThresholdLevel)


        RaiseEvent ProgressStatus("Extracting regions..", 30)

        _Image_RegionExtraction = MyImgProc.RegionExtract_RasterScanning_NoMaskImage(
                                  _Image_BlackWhite,
                                  _LabelIDMap,
                                  _FoundRegionColorTable)


        RaiseEvent ProgressStatus("Generating a label map", 40)
        _LabelIDMap = Generate_LabelID(_LabelIDMap, _FoundRegionColorTable)


        If _UserStopped Then Exit Sub



        RaiseEvent ProgressStatus("Marking labels on the image", 50)
        _Image_FinalOverLapWithoutLabels =
                        Draw_Rectangles_Of_DetectedObjects(_Image_Source,
                                                           _IDInfo,
                                                           _IDInfo.GetUpperBound(0))
    End Sub



    Public Sub Initialize_LabelID_Info()

        For w As Integer = 0 To _IDInfo.GetUpperBound(0)
            With _IDInfo(w)
                .PixelCount = 0
                .AvgCenter_X = 0
                .AvgCenter_Y = 0
                .X1 = _ImageWidth
                .X2 = -1
                .Y1 = _ImageHeight
                .Y2 = -1
                .IsExcludeThisID = False
                .AnimalCount = 1
                .Width = 0
                .Height = 0
                .ArrangedValidID = 0
            End With
        Next
    End Sub


    Public Function Generate_LabelID(ByVal Src_IDMap(,) As Integer,
                                       ByVal Src_ColorTable(,) As Byte) As Integer(,)

        'ColorTable (IDnumber, 0:R  1:G  2:B)
        '                  IDnumber starts from 1
        'IDMap(x,y)        x,y starts from 0
        '

        Dim Temp_New_IDMap(,) As Integer

        Dim x, y As Integer


        Temp_New_IDMap = Src_IDMap
        ReDim _IDInfo(Src_ColorTable.GetUpperBound(0))


        'Initializing
        Call Initialize_LabelID_Info()


        'Adding .AvgCenter_X (or _Y) of each pixel
        'Finding Min,Max
        For y = 0 To _ImageHeightUpperBound
            For x = 0 To _ImageWidthUpperBound
                With _IDInfo(Src_IDMap(x, y))
                    .PixelCount += 1
                    .AvgCenter_X += x
                    .AvgCenter_Y += y

                    If .X1 > x Then
                        .X1 = x
                    End If
                    If .Y1 > y Then
                        .Y1 = y
                    End If
                    If .X2 < x Then
                        .X2 = x
                    End If
                    If .Y2 < y Then
                        .Y2 = y
                    End If
                End With
            Next
        Next



        'Calculating average value
        For y = 1 To _IDInfo.GetUpperBound(0)
            With _IDInfo(y)
                If .PixelCount >= myScreeningCondition.Area_Min AndAlso
                     .PixelCount < myScreeningCondition.Area_Max Then

                    .AvgCenter_X = CInt(.AvgCenter_X / .PixelCount)
                    .AvgCenter_Y = CInt(.AvgCenter_Y / .PixelCount)
                    .Width = .X2 - .X1 + 1
                    .Height = .Y2 - .Y1 + 1

                    .IsExcludeThisID = False
                Else
                    .IsExcludeThisID = True
                End If
            End With
        Next



        'Evaluting exclusion
        For y = 1 To _IDInfo.GetUpperBound(0)
            With _IDInfo(y)
                If .IsExcludeThisID = False Then
                    If .Width >= myScreeningCondition.Width_Min AndAlso
                       .Height >= myScreeningCondition.Width_Min AndAlso
                       .Width < myScreeningCondition.Width_Max AndAlso
                       .Height < myScreeningCondition.Width_Max Then
                        .IsExcludeThisID = False
                    Else
                        .IsExcludeThisID = True
                    End If
                End If

            End With
        Next



        'Removing pixels on IDMap
        For y = 0 To _ImageHeightUpperBound
            For x = 0 To _ImageWidthUpperBound
                If _IDInfo(Src_IDMap(x, y)).IsExcludeThisID Then
                    Temp_New_IDMap(x, y) = 0
                Else
                    Temp_New_IDMap(x, y) = Src_IDMap(x, y)
                End If
            Next
        Next


        Return Temp_New_IDMap
    End Function


    Public Function Draw_Rectangles_Of_DetectedObjects(ByVal Src_Image As Image,
                                                       ByRef Src_IDInfo() As ID_Info,
                                                       ByVal Src_IDInfo_Count As Integer,
                                                       Optional ByVal Magnification As Single = 1) As Image

        Using bm As New Bitmap(Src_Image),
              GraphBox As Graphics = Graphics.FromImage(bm),
              myPenRed As New Pen(Brushes.Red),
              myPenBlue As New Pen(Brushes.Blue),
              myPenGreen As New Pen(Brushes.LimeGreen)


            For w As Integer = 1 To Src_IDInfo_Count
                With Src_IDInfo(w)

                    If .IsExcludeThisID = False Then
                        GraphBox.DrawRectangle(myPenGreen, CInt(.X1 * Magnification) - 3,
                                                       CInt(.Y1 * Magnification) - 3,
                                                       CInt((.X2 - .X1) * Magnification) + 6,
                                                       CInt((.Y2 - .Y1) * Magnification) + 6)

                    End If

                End With
            Next

            Draw_Rectangles_Of_DetectedObjects = MyImgProc.DeepCopy(bm)
        End Using
    End Function




    Public Function Add_DetectionLabels_To_Image(ByVal Src_Image As Image,
                             ByRef Src_IDInfo() As ID_Info,
                             ByVal TextFont As Font,
                             Optional IsIncludeInvalidAnimals As Boolean = False) As Image

        Using bm As New Bitmap(Src_Image),
              GraphBox As Graphics = Graphics.FromImage(bm),
              myPenRed As New Pen(Brushes.Red),
              myPenBlue As New Pen(Brushes.Blue),
              myPenGreen As New Pen(Brushes.LimeGreen)


            For w As Integer = 1 To Src_IDInfo.GetUpperBound(0)
                With Src_IDInfo(w)

                    If .IsExcludeThisID = False Then


                        If .AnimalCount = 1 Then
                            GraphBox.DrawRectangle(New Pen(Brushes.Red),
                                               .X1 - 5, .Y1 - 5,
                                               .Width + 9, .Height + 9)

                            Call MyImgProc.Draw_Text_Outlined_Graphics(GraphBox,
                                                 .X2, .Y1,
                                                 .ArrangedValidID.ToString.Trim,
                                                 TextFont,
                                                 Color.Red,
                                                 Color.Black)

                        End If

                    End If

                End With
            Next

            Add_DetectionLabels_To_Image = MyImgProc.DeepCopy(bm)
        End Using
    End Function


    Public Function Extract_TrainingImage(SourceIDINfo As Integer,
                                          MarginLength As Integer,
                                          DilateBoxSize As Integer) As Image

        Dim FinalOverlapedObjectImage As Image

        With _IDInfo(SourceIDINfo)
            If .IsExcludeThisID = False Then

                'Safe bounding box
                Dim xUpper As Integer = Min(_LabelIDMap.GetUpperBound(0), .X2 + MarginLength)
                Dim yUpper As Integer = Min(_LabelIDMap.GetUpperBound(1), .Y2 + MarginLength)
                Dim xLower As Integer = Max(0, .X1 - MarginLength)
                Dim yLower As Integer = Max(0, .Y1 - MarginLength)


                Using ObjectDilatedOutlineGreenImage As Image =
                                                MyImgProc.RegionExtract_Create_GreenObjectOutlineImage(
                                                                _LabelIDMap, SourceIDINfo,
                                                                xLower, xUpper, yLower, yUpper, DilateBoxSize),
                     SourceObjectImage As Image = MyImgProc.Crop(_Image_Source,
                                                                             xUpper - xLower + 1,
                                                                             yUpper - yLower + 1,
                                                                             xLower,
                                                                             yLower)

                    FinalOverlapedObjectImage =
                                MyImgProc.Overlay_MaskImage_To_Image(SourceObjectImage,
                                                                           ObjectDilatedOutlineGreenImage,
                                                                           0)
                End Using

            Else
                Return Nothing
            End If
        End With


        Return FinalOverlapedObjectImage
    End Function

    Public Sub Export_TrainingImage(SourceIDINfo As Integer,
                                    Filename As String,
                                    MarginLength As Integer,
                                    DilateBoxSize As Integer)

        Dim FinalOverlapImage As Image =
                    Extract_TrainingImage(SourceIDINfo, MarginLength, DilateBoxSize)

        If FinalOverlapImage IsNot Nothing Then
            FinalOverlapImage.Save(Filename)
        End If
    End Sub

    Public Function Peek_Worm(CenterX As Integer, CenterY As Integer) As Integer


        For w As Integer = 1 To _IDInfo.GetUpperBound(0)
            With _IDInfo(w)

                If .IsExcludeThisID = False Then
                    If Sqrt((CenterX - .AvgCenter_X) ^ 2 + (CenterY - .AvgCenter_Y) ^ 2) < 10 Then
                        Return w
                    End If
                End If

            End With
        Next

        Return -1
    End Function


    Public Function Get_AnimalInfo() As String
        Dim curSum As Integer = 0
        Dim OutStr As New StringBuilder

        OutStr.Append("AnimalID,length(um),Area(pixels),ROI_Width,ROI_Height,ROI_ID" + vbCrLf)

        For w As Integer = 1 To _IDInfo.GetUpperBound(0)
            With _IDInfo(w)

                If .IsExcludeThisID = False AndAlso .AnimalCount = 1 Then
                    OutStr.Append(.ArrangedValidID.ToString.Trim + "," +
                              Format(.TrueLength, "0.00") + "," +
                              .PixelCount.ToString.Trim + "," +
                              .Width.ToString.Trim + "," +
                              .Height.ToString.Trim + "," +
                              w.ToString.Trim + "," +
                              vbCrLf)
                End If

            End With
        Next

        Return OutStr.ToString
    End Function



    Public Function Save_DetectionInfo() As String
        If _IDInfo Is Nothing OrElse _LabelIDMap Is Nothing OrElse
            _Image_FinalOverLapWithoutLabels Is Nothing Then Return "Analysis not performed yet"


        Try
            Dim DestFilename As String = TargetFolder + "\IDinfo.dat"

            DestFilename = TargetFolder + "\FinalOverlap.png"
            _Image_FinalOverLap.Save(DestFilename)


            DestFilename = TargetFolder + "\length.csv"
            File.WriteAllText(DestFilename, Get_AnimalInfo)

        Catch ee As Exception
            Return ee.ToString
        End Try

        Return ""
    End Function


    Public Function Load_DetectionInfo() As Boolean


        Dim DestFilename_IDinfo As String =
                    TargetFolder + "\IDinfo.dat"
        Dim DestFilename_LabelIDMap As String =
                    TargetFolder + "\LabelIDMap.dat"
        Dim DestFilename_FinalOverlapWithoutLabels As String =
                    TargetFolder + "\FinalOverlapWithoutLabels.png"


        If MyFileSysEng.FileExists(DestFilename_IDinfo) AndAlso
           MyFileSysEng.FileExists(DestFilename_LabelIDMap) AndAlso
           MyFileSysEng.FileExists(DestFilename_FinalOverlapWithoutLabels) Then


            Using fs As FileStream = New FileStream(DestFilename_IDinfo, FileMode.Open)
                Dim bf As New BinaryFormatter()
#Disable Warning SYSLIB0011 ' Type or member is obsolete
                _IDInfo = CType(bf.Deserialize(fs), ID_Info())
#Enable Warning SYSLIB0011 ' Type or member is obsolete
            End Using


            Using fs As FileStream = New FileStream(DestFilename_LabelIDMap, FileMode.Open)
                Dim bf As New BinaryFormatter()
#Disable Warning SYSLIB0011 ' Type or member is obsolete
                _LabelIDMap = CType(bf.Deserialize(fs), Integer(,))
#Enable Warning SYSLIB0011 ' Type or member is obsolete
            End Using


            _Image_FinalOverLapWithoutLabels =
               MyImgProc.Image_FromFile(DestFilename_FinalOverlapWithoutLabels)

            Return True
        Else
            _IDInfo = Nothing
            _LabelIDMap = Nothing
            _Image_FinalOverLapWithoutLabels = Nothing

            Return False
        End If


    End Function

    Public Function Measure_Length(ByRef SourceBinary As Image,
                                   ByVal umPerPixels As Single,
                                   ByRef TrueLength As Single) As Image

        Using SkeletonImage As Image = MyImgProc.Skeletonize(SourceBinary)

            Dim SrcBinaryArray(,) As Byte =
                MyImgProc.Convert_Image_To_2DByteArray(SourceBinary)
            Dim OutSkeletonArray(,) As Byte =
                MyImgProc.Convert_Image_To_2DByteArray(SkeletonImage)


            MyProc.Trim(OutSkeletonArray, 255)


            OutSkeletonArray =
                MyProc.Extend_SkeletonCurve(OutSkeletonArray, SrcBinaryArray)

            MyProc.Trim(OutSkeletonArray, 255)

            Dim endPoints As LinkedList(Of Integer()) =
                    MyProc.FindEndPoints(OutSkeletonArray, 255)
            Dim branchPoints As LinkedList(Of Integer()) =
                    MyProc.FindBranchPoints(OutSkeletonArray, 255)


            If endPoints.Count = 2 AndAlso branchPoints.Count = 0 Then
                TrueLength = MyProc.Get_TrueAnimalLen(OutSkeletonArray,
                                                     255,
                                                     umPerPixels,
                                                     16)

                Return MyImgProc.Convert_GrayByteArray_To_RGBImage(OutSkeletonArray)
            Else
                TrueLength = 0
                Return Nothing
            End If

        End Using
    End Function
End Class
