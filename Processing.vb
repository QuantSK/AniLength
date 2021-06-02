Public Class Processing

	Public _FloodFilledDoneMap(,) As Boolean
	Public FloodFillQue As New LinkedList(Of Point)()


	Public Function Distance(P1 As Point, P2 As Point) As Single
		Return Math.Sqrt(Math.Pow(P2.X - P1.X, 2) + Math.Pow(P2.Y - P1.Y, 2))
	End Function


	Public Function Get_TrueAnimalLen(ByVal skelWorm(,) As Byte,
									 ByVal foreground As Integer,
									 ByVal umPerPixels As Single,
									 SplineVertexCount As Integer) As Single

		'Clipboard.SetImage(MyImgProc.Convert_GrayByteArray_To_RGBImage(skelWorm))

		Dim skeletonPoints() As Point =
				Extract_SkeletonPoints(skelWorm, foreground)
		Dim skeletonPointCount As Integer = skeletonPoints.Length
		Dim skeletonExtractInterval As Single
		Dim SplineVertex(SplineVertexCount - 1) As Point
		Dim CurSplineVertexCount As Integer
		Dim PixelLength As Single


		If skeletonPointCount > SplineVertexCount Then
			skeletonExtractInterval =
				CSng(skeletonPointCount) / CSng(SplineVertexCount - 1)
		Else
			skeletonExtractInterval = 1
		End If


		CurSplineVertexCount = 0
		For curPoint As Single = 0 To skeletonPointCount - 1 Step skeletonExtractInterval
			SplineVertex(CurSplineVertexCount) = skeletonPoints(Math.Round(curPoint))
			CurSplineVertexCount += 1
		Next
		SplineVertex(SplineVertexCount - 1) = skeletonPoints(skeletonPointCount - 1)


		PixelLength = 0
		For q As Integer = 0 To SplineVertexCount - 2
			PixelLength += Distance(SplineVertex(q), SplineVertex(q + 1))
		Next


		Return PixelLength * umPerPixels
	End Function


	Public Function Extract_SkeletonPoints(ByRef skelWorm(,) As Byte,
										   ByVal foreground As Integer) As Point()
		Dim template(,) As Byte = skelWorm.Clone

		Dim width As Integer = skelWorm.GetUpperBound(0) + 1
		Dim height As Integer = skelWorm.GetUpperBound(1) + 1
		Dim skeletonPixelCount As Integer = Count_Pixels(skelWorm, foreground)

		Dim ePoints As LinkedList(Of Integer()) = FindEndPoints(skelWorm, foreground)

		Dim endPoint() As Integer = ePoints(0)
		Dim lastW As Integer = endPoint(0)
		Dim lastH As Integer = endPoint(1)
		Dim jump As Integer = 0
		Dim count As Integer = 0
		Dim lastcount As Integer
		Dim SkeletonVertices(skeletonPixelCount - 1) As Point

		SkeletonVertices(0) = New Point(lastW, lastH)

		Do While count < skeletonPixelCount

			lastcount = count
			template(lastW, lastH) = 0
			Dim fail As Integer = 0

			Dim starti As Integer = lastW - 1
			Dim startj As Integer = lastH - 1
			Dim endi As Integer = lastW + 1
			Dim endj As Integer = lastH + 1
			If lastW = 0 Then
				starti = 0
			End If
			If lastW = width - 1 Then
				endi = width - 1
			End If
			If lastH = 0 Then
				startj = 0
			End If
			If lastH = height - 1 Then
				endj = height - 1
			End If

			For i As Integer = starti To endi
				For j As Integer = startj To endj

					If template(i, j) = foreground Then
						SkeletonVertices(count + 1) = New Point(i, j)
						lastW = i
						lastH = j
						count += 1
						jump = 1
						Exit For
					End If
					fail += 1
					If fail = 9 Then
						jump = 1
						Exit For
					End If
				Next j
				If jump = 1 Then
					jump = 0
					Exit For
				End If
			Next i

			If count = lastcount Then
				Exit Do
			End If
		Loop

		Return SkeletonVertices
	End Function


	Public Sub Trim(ByRef skelWorm(,) As Byte, ByVal foreground As Integer)
		TrimSingleRound(skelWorm, foreground, 1)
		TrimSingleRound(skelWorm, foreground, 2)
	End Sub


	Public Sub TrimSingleRound(ByRef skelWorm(,) As Byte,
									  ByVal foreground As Integer,
									  ByVal mode As Integer)

		Dim background As Integer = If(foreground = 255, 0, 255)
		Dim width As Integer = skelWorm.GetUpperBound(0) + 1
		Dim height As Integer = skelWorm.GetUpperBound(1) + 1
		For i As Integer = 0 To width - 2
			For j As Integer = 0 To height - 2
				If skelWorm(i, j) = foreground Then
					Dim starti As Integer = i - 1
					Dim startj As Integer = j - 1
					Dim endi As Integer = i + 1
					Dim endj As Integer = j + 1
					If i = 0 Then
						starti = i
					End If
					If i = width - 1 Then
						endi = width - 1
					End If
					If j = 0 Then
						startj = j
					End If
					If j = height - 1 Then
						endj = height - 1
					End If
					Dim sum As Integer = 0
					For m As Integer = starti To endi
						For n As Integer = startj To endj
							If skelWorm(m, n) = foreground Then
								sum += 1
							End If
						Next n
					Next m
					If mode = 1 Then
						If sum = 3 Then
							If i > 0 AndAlso i < width - 2 AndAlso j > 0 AndAlso j < height - 2 Then
								Dim b1 As Boolean = (skelWorm(i - 1, j - 1) = foreground AndAlso skelWorm(i - 1, j) = foreground)
								Dim b2 As Boolean = (skelWorm(i - 1, j - 1) = foreground AndAlso skelWorm(i, j - 1) = foreground)
								Dim b3 As Boolean = (skelWorm(i, j - 1) = foreground AndAlso skelWorm(i + 1, j - 1) = foreground)
								Dim b4 As Boolean = (skelWorm(i + 1, j - 1) = foreground AndAlso skelWorm(i + 1, j) = foreground)
								Dim b5 As Boolean = (skelWorm(i + 1, j) = foreground AndAlso skelWorm(i + 1, j + 1) = foreground)
								Dim b6 As Boolean = (skelWorm(i + 1, j + 1) = foreground AndAlso skelWorm(i, j + 1) = foreground)
								Dim b7 As Boolean = (skelWorm(i, j + 1) = foreground AndAlso skelWorm(i - 1, j + 1) = foreground)
								Dim b8 As Boolean = (skelWorm(i - 1, j + 1) = foreground AndAlso skelWorm(i - 1, j) = foreground)
								If b1 OrElse b2 OrElse b3 OrElse b4 OrElse b5 OrElse b6 OrElse b7 OrElse b8 Then
									skelWorm(i, j) = background
								End If
							End If
						End If
						If sum = 4 Then
							If i > 0 AndAlso i < width - 2 AndAlso j > 0 AndAlso j < height - 2 Then
								Dim b1 As Boolean = (skelWorm(i + 1, j) = background AndAlso skelWorm(i - 1, j - 1) = foreground AndAlso skelWorm(i - 1, j) = foreground AndAlso skelWorm(i - 1, j + 1) = foreground)
								Dim b2 As Boolean = (skelWorm(i - 1, j) = background AndAlso skelWorm(i + 1, j - 1) = foreground AndAlso skelWorm(i + 1, j) = foreground AndAlso skelWorm(i + 1, j + 1) = foreground)
								Dim b3 As Boolean = (skelWorm(i, j + 1) = background AndAlso skelWorm(i - 1, j - 1) = foreground AndAlso skelWorm(i, j - 1) = foreground AndAlso skelWorm(i + 1, j - 1) = foreground)
								Dim b4 As Boolean = (skelWorm(i, j - 1) = background AndAlso skelWorm(i - 1, j + 1) = foreground AndAlso skelWorm(i, j + 1) = foreground AndAlso skelWorm(i + 1, j + 1) = foreground)
								If b1 OrElse b2 OrElse b3 OrElse b4 Then
									skelWorm(i, j) = background
								End If
							End If

						End If
						End If
					If mode = 2 Then
						If sum >= 3 Then
							If i > 0 AndAlso i < width - 2 AndAlso j > 0 AndAlso j < height - 2 Then
								Dim b1 As Boolean = (skelWorm(i, j - 1) = foreground AndAlso skelWorm(i + 1, j) = foreground AndAlso skelWorm(i - 1, j + 1) = background)
								Dim b2 As Boolean = (skelWorm(i + 1, j) = foreground AndAlso skelWorm(i, j + 1) = foreground AndAlso skelWorm(i - 1, j - 1) = background)
								Dim b3 As Boolean = (skelWorm(i, j + 1) = foreground AndAlso skelWorm(i - 1, j) = foreground AndAlso skelWorm(i + 1, j - 1) = background)
								Dim b4 As Boolean = (skelWorm(i - 1, j) = foreground AndAlso skelWorm(i, j - 1) = foreground AndAlso skelWorm(i + 1, j + 1) = background)
								If b1 OrElse b2 OrElse b3 OrElse b4 Then
									skelWorm(i, j) = background
								End If
							End If

						End If
						End If
				End If
			Next j 'end of loop j
		Next i ' end of loop i
	End Sub


	Public Function Extend_SkeletonCurve(ByVal srcGrayArray(,) As Byte,
												ByVal maskGrayArray(,) As Byte) As Byte(,)

		Dim clipwidth As Integer = srcGrayArray.GetUpperBound(0)
		Dim clipheight As Integer = srcGrayArray.GetUpperBound(1)


		For i As Integer = 0 To clipwidth - 1
			For j As Integer = 0 To clipheight - 1



				'Finding end point
				If srcGrayArray(i, j) = 255 Then
					Dim neighborhoodPixelCount As Integer = 0
					Dim processedTailFound As Boolean = False
					Dim emptyMaskAreaFound As Boolean = False

					neighborhoodPixelCount = countValidNeighborhoodPixel(srcGrayArray, 255, i, j)


					If countValidNeighborhoodPixel(srcGrayArray, 125, i, j) > 0 Then
						processedTailFound = True
					End If

					If countValidNeighborhoodPixel(maskGrayArray, 0, i, j) > 0 Then
						emptyMaskAreaFound = True
					End If


					If (neighborhoodPixelCount = 1) AndAlso (processedTailFound = False) AndAlso (emptyMaskAreaFound = False) Then


						'Finding skeleton tail
						Dim tailLength As Integer = 10
						Dim foundTailLocation(tailLength - 1) As Point


						foundTailLocation = Search_SkeletonTail(srcGrayArray, i, j, 255, 0, tailLength)


						If foundTailLocation IsNot Nothing Then

							If isBifurcationFound(foundTailLocation) = False Then

								'Calculating vector
								Dim avgvectorX As Double = 0
								Dim avgvectorY As Double = 0
								Dim k As Integer = 0
								Do While k < tailLength - 1
									avgvectorX = avgvectorX + foundTailLocation(k).X - foundTailLocation(k + 1).X
									avgvectorY = avgvectorY + foundTailLocation(k).Y - foundTailLocation(k + 1).Y
									k += 1
								Loop
								avgvectorX = avgvectorX / tailLength
								avgvectorY = avgvectorY / tailLength


								'Extrapolate vector to empty region in maskimage
								Dim startX As Single = foundTailLocation(0).X
								Dim startY As Single = foundTailLocation(0).Y
								Dim lastValidPoint As New Point()
								Dim curValidPoint As New Point()
								lastValidPoint.X = foundTailLocation(0).X
								lastValidPoint.Y = foundTailLocation(0).Y

								Do
									startX = CSng(startX + avgvectorX / 5)
									startY = CSng(startY + avgvectorY / 5)

									curValidPoint.X = CInt(Math.Round(startX, MidpointRounding.AwayFromZero))
									curValidPoint.Y = CInt(Math.Round(startY, MidpointRounding.AwayFromZero))

									If curValidPoint.X < 0 OrElse
										curValidPoint.X > clipwidth - 1 OrElse
										curValidPoint.Y < 0 OrElse
										curValidPoint.Y > clipheight - 1 Then
										Exit Do
									End If


									If (lastValidPoint.X <> curValidPoint.X) OrElse
										(lastValidPoint.Y <> curValidPoint.Y) Then
										lastValidPoint.X = curValidPoint.X
										lastValidPoint.Y = curValidPoint.Y


										If maskGrayArray(lastValidPoint.X, lastValidPoint.Y) = 0 Then
											Exit Do
										End If
										srcGrayArray(lastValidPoint.X, lastValidPoint.Y) = 255

									End If

								Loop
							End If

						End If
					End If
				End If


			Next j
		Next i


		Return srcGrayArray
	End Function


	Public Function Count_Pixels(ByVal skelWorm(,) As Byte, ByVal foreground As Integer) As Integer
		Dim wormLen As Integer = 0
		Dim width As Integer = skelWorm.GetUpperBound(0)
		Dim height As Integer = skelWorm.GetUpperBound(1)
		For i As Integer = 0 To width - 1
			For j As Integer = 0 To height - 1
				If skelWorm(i, j) = foreground Then
					wormLen += 1
				End If
			Next j
		Next i
		Return wormLen
	End Function



	Public Function CountValidNeighborhoodPixel(ByVal srcGrayArray(,) As Byte,
												ByVal searchPixelGrayColor As Integer,
												ByVal i As Integer,
												ByVal j As Integer) As Integer

		Dim clipwidth As Integer = srcGrayArray.GetUpperBound(0)
		Dim clipheight As Integer = srcGrayArray.GetUpperBound(1)
		Dim neighborhoodPixelCount As Integer = 0



		If (i - 1 >= 0) AndAlso (j - 1 >= 0) Then
			If srcGrayArray(i - 1, j - 1) = searchPixelGrayColor Then
				neighborhoodPixelCount += 1
			End If

		End If

		If j - 1 >= 0 Then
			If srcGrayArray(i, j - 1) = searchPixelGrayColor Then
				neighborhoodPixelCount += 1
			End If
		End If

		If (i + 1 < clipwidth) AndAlso (j - 1 >= 0) Then
			If srcGrayArray(i + 1, j - 1) = searchPixelGrayColor Then
				neighborhoodPixelCount += 1
			End If
		End If
		'-----------------------
		If i - 1 >= 0 Then
			If srcGrayArray(i - 1, j) = searchPixelGrayColor Then
				neighborhoodPixelCount += 1
			End If
		End If

		If i + 1 < clipwidth Then
			If srcGrayArray(i + 1, j) = searchPixelGrayColor Then
				neighborhoodPixelCount += 1
			End If
		End If
		'------------------------
		If (i - 1 >= 0) AndAlso (j + 1 < clipheight) Then
			If srcGrayArray(i - 1, j + 1) = searchPixelGrayColor Then
				neighborhoodPixelCount += 1
			End If
		End If

		If j + 1 < clipheight Then
			If srcGrayArray(i, j + 1) = searchPixelGrayColor Then
				neighborhoodPixelCount += 1
			End If
		End If

		If (i + 1 < clipwidth) AndAlso (j + 1 < clipheight) Then
			If srcGrayArray(i + 1, j + 1) = searchPixelGrayColor Then
				neighborhoodPixelCount += 1
			End If

		End If

		Return neighborhoodPixelCount
	End Function

	Friend Shared Function isBifurcationFound(ByVal foundTailLocation() As Point) As Boolean

		Dim foundTailLocationLength As Integer = foundTailLocation.Length


		For i As Integer = 0 To foundTailLocationLength - 1
			Dim neightborhoodPixelCount As Integer = 0
			For j As Integer = 0 To foundTailLocationLength - 1
				If (Math.Abs(foundTailLocation(i).X - foundTailLocation(j).X) <= 1) AndAlso (Math.Abs(foundTailLocation(i).Y - foundTailLocation(j).Y) <= 1) Then
					neightborhoodPixelCount += 1
				End If
			Next j

			If neightborhoodPixelCount >= 4 Then
				Return True
			End If

		Next i

		Return False

	End Function

	Public Overridable Function Search_SkeletonTail(ByVal SrcGrayShortArray(,) As Byte,
													ByVal CenterX As Integer,
													ByVal CenterY As Integer,
													ByVal FillColorG As Short,
													ByVal ToleranceG As Integer,
													ByVal MaxTrackingCount As Integer) As Point()


		Dim SrcImageWidth As Integer = SrcGrayShortArray.GetUpperBound(0)
		Dim SrcImageHeight As Integer = SrcGrayShortArray.GetUpperBound(1)
		Dim curTrackingCount As Integer = 0

		Dim Cur_Location As New Point()
		Dim neighborhoodPixelLocation(MaxTrackingCount - 1) As Point
		Dim foundPixelLocation(MaxTrackingCount - 1) As Point

		Dim CenterColor_G As Integer


		Dim QueueMap(SrcImageWidth - 1, SrcImageHeight - 1) As Boolean

		Dim outPixels(,) As Byte = SrcGrayShortArray
		ReDim _FloodFilledDoneMap(SrcImageWidth, SrcImageHeight)

		FloodFillQue.Clear()
		Cur_Location.X = CenterX
		Cur_Location.Y = CenterY
		FloodFillQue.AddLast(Cur_Location)
		QueueMap(Cur_Location.X, Cur_Location.Y) = True
		_FloodFilledDoneMap(Cur_Location.X, Cur_Location.Y) = True

		CenterColor_G = SrcGrayShortArray(Cur_Location.X, Cur_Location.Y)



		Do
			Cur_Location = FloodFillQue(0)
			'Cur_Location.X = tempPoint.X
			'Cur_Location.Y = tempPoint.Y

			outPixels(Cur_Location.X, Cur_Location.Y) = FillColorG
			_FloodFilledDoneMap(Cur_Location.X, Cur_Location.Y) = True


			curTrackingCount += 1
			foundPixelLocation(curTrackingCount - 1) = New Point(Cur_Location)
			If curTrackingCount = MaxTrackingCount Then
				Exit Do
			End If


			FloodFillQue.RemoveFirst()
			QueueMap(Cur_Location.X, Cur_Location.Y) = False


			'Initializing pixel locations
			neighborhoodPixelLocation(1) = New Point(Cur_Location.X - 1, Cur_Location.Y - 1)
			neighborhoodPixelLocation(2) = New Point(Cur_Location.X, Cur_Location.Y - 1)
			neighborhoodPixelLocation(3) = New Point(Cur_Location.X + 1, Cur_Location.Y - 1)
			neighborhoodPixelLocation(4) = New Point(Cur_Location.X - 1, Cur_Location.Y)
			neighborhoodPixelLocation(5) = New Point(-1, -1)
			neighborhoodPixelLocation(6) = New Point(Cur_Location.X + 1, Cur_Location.Y)
			neighborhoodPixelLocation(7) = New Point(Cur_Location.X - 1, Cur_Location.Y + 1)
			neighborhoodPixelLocation(8) = New Point(Cur_Location.X, Cur_Location.Y + 1)
			neighborhoodPixelLocation(9) = New Point(Cur_Location.X + 1, Cur_Location.Y + 1)



			'Excluding invalid pixel locations
			If Cur_Location.Y = 0 Then
				neighborhoodPixelLocation(1).X = -1
				neighborhoodPixelLocation(2).X = -1
				neighborhoodPixelLocation(3).X = -1
			End If

			If Cur_Location.Y = SrcImageHeight - 1 Then
				neighborhoodPixelLocation(7).X = -1
				neighborhoodPixelLocation(8).X = -1
				neighborhoodPixelLocation(9).X = -1
			End If

			If Cur_Location.X = 0 Then
				neighborhoodPixelLocation(1).X = -1
				neighborhoodPixelLocation(4).X = -1
				neighborhoodPixelLocation(7).X = -1
			End If

			If Cur_Location.X = SrcImageWidth - 1 Then
				neighborhoodPixelLocation(3).X = -1
				neighborhoodPixelLocation(6).X = -1
				neighborhoodPixelLocation(9).X = -1
			End If


			'Processing for valid pixel locations
			For i As Integer = 1 To 9

				If neighborhoodPixelLocation(i).X <> -1 Then
					If QueueMap(neighborhoodPixelLocation(i).X, neighborhoodPixelLocation(i).Y) = False Then
						If _FloodFilledDoneMap(neighborhoodPixelLocation(i).X, neighborhoodPixelLocation(i).Y) = False AndAlso
							Math.Abs(CenterColor_G - SrcGrayShortArray(neighborhoodPixelLocation(i).X, neighborhoodPixelLocation(i).Y)) <= ToleranceG Then
							FloodFillQue.AddLast(neighborhoodPixelLocation(i))
							QueueMap(neighborhoodPixelLocation(i).X, neighborhoodPixelLocation(i).Y) = True
						End If
					End If
				End If
			Next i

		Loop While FloodFillQue.Count <> 0



		If curTrackingCount < MaxTrackingCount Then
			Return Nothing
		Else
			Return foundPixelLocation
		End If
	End Function

	Public Function FindBranchPoints(ByVal skelWorm(,) As Byte,
											ByVal foreground As Integer) As LinkedList(Of Integer())

		Dim width As Integer = skelWorm.GetUpperBound(0)
		Dim height As Integer = skelWorm.GetUpperBound(1)
		Dim branchList As New LinkedList(Of Integer())()
		For i As Integer = 0 To width - 1
			For j As Integer = 0 To height - 1
				If skelWorm(i, j) = foreground Then
					Dim starti As Integer = i - 1
					Dim startj As Integer = j - 1
					Dim endi As Integer = i + 1
					Dim endj As Integer = j + 1
					If i = 0 Then
						starti = i
					End If
					If i = width - 1 Then
						endi = width - 1
					End If
					If j = 0 Then
						startj = j
					End If
					If j = height - 1 Then
						endj = height - 1
					End If
					Dim sum As Integer = 0
					For m As Integer = starti To endi
						For n As Integer = startj To endj
							If skelWorm(m, n) = foreground Then
								sum += 1
							End If
						Next n
					Next m
					If sum >= 4 Then
						Dim cord() As Integer = {i, j}
						branchList.AddLast(cord)
					End If
				End If
			Next j 'end of loop j
		Next i ' end of loop i

		'clear the extra points


		Dim finalBranchList As New LinkedList(Of Integer())()
		Dim initSize As Integer = branchList.Count
		Dim available(initSize - 1) As Integer 'flags
		For t As Integer = 0 To initSize - 1
			available(t) = 0
		Next t
		If initSize > 1 Then
			For q As Integer = 0 To initSize - 1
				If available(q) = 0 Then
					Dim point() As Integer = CType(branchList(q), Integer())
					finalBranchList.AddLast(point)
					Dim r1 As Integer = point(0)
					Dim r2 As Integer = point(1)
					For s As Integer = q + 1 To initSize - 1
						Dim point2() As Integer = CType(branchList(s), Integer())
						Dim v1 As Integer = point2(0)
						Dim v2 As Integer = point2(1)
						If Math.Abs(v1 - r1) <= 2 AndAlso Math.Abs(v2 - r2) <= 2 Then
							available(s) = 1
						End If
					Next s
				End If
			Next q
			Return finalBranchList
		End If
		Return branchList
	End Function


	Public Function FindEndPoints(ByVal skelWorm(,) As Byte,
										 ByVal foreground As Integer) As LinkedList(Of Integer())

		Dim width As Integer = skelWorm.GetUpperBound(0)
		Dim height As Integer = skelWorm.GetUpperBound(1)
		Dim endList As New LinkedList(Of Integer())()
		For i As Integer = 0 To width - 1
			For j As Integer = 0 To height - 1
				If skelWorm(i, j) = foreground Then
					Dim starti As Integer = i - 1
					Dim startj As Integer = j - 1
					Dim endi As Integer = i + 1
					Dim endj As Integer = j + 1
					If i = 0 Then
						starti = i
					End If
					If i = width - 1 Then
						endi = width - 1
					End If
					If j = 0 Then
						startj = j
					End If
					If j = height - 1 Then
						endj = height - 1
					End If
					Dim sum As Integer = 0
					For m As Integer = starti To endi
						For n As Integer = startj To endj
							If skelWorm(m, n) = foreground Then
								sum += 1
							End If
						Next n
					Next m
					If sum = 2 Then
						Dim cord() As Integer = {i, j}
						endList.AddLast(cord)
					End If
				End If
			Next j 'end of loop j
		Next i ' end of loop i
		Return endList
	End Function

End Class
