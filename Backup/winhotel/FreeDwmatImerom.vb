Public Class FreeDwmatImerom
    Dim dwmArithmos As String
    Dim klinesKwd, tiposKwd As Integer
    Dim dwmBesetzt() As String
    Dim zeigerDwm1, zeigerDwm2 As Int16

    Public Sub New(ByVal klins As Integer, ByVal tips As Integer, ByVal apo As Date, ByVal mexri As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        klinesKwd = klins
        tiposKwd = tips
        FreeDwmatImeromPck.MinDate = apo
        FreeDwmatImeromPck.MaxDate = mexri
        FreeDwmatImeromPck.Value = apo
        Me.TipoiTableAdapter.Fill(Me.DbhotelDataSet.tipoi)
        'TODO: This line of code loads data into the 'DbhotelDataSet.klines' table. You can move, or remove it, as needed.
        Me.KlinesTableAdapter.Fill(Me.DbhotelDataSet.klines)


    End Sub
    Private Sub FreeDwmatImeromBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FreeDwmatImeromBtn.Click
        Dim j, count As Int16

        count = 0
        Me.DbhotelDataSet.freedwmatia.Clear()
        Try
            Me.StatusTableAdapter.DwmatiaMeStatusByDiamoni(Me.DbhotelDataSet.status, FreeDwmatImeromPck.Value.Date, FreeDwmatImeromPck.Value.Date, FreeDwmatImeromPck.Value.Date, FreeDwmatImeromPck.Value.Date, FreeDwmatImeromPck.Value.Date, FreeDwmatImeromPck.Value.Date)
            For j = 0 To Me.DbhotelDataSet.status.Count - 1
                count += 1
                ReDim Preserve dwmBesetzt(count - 1)
                dwmBesetzt(count - 1) = Me.DbhotelDataSet.status(j).dwmatio
            Next
            If klinesKwd <> 0 And tiposKwd <> 0 Then
                Me.DwmatiaTableAdapter.FillDwmatiaByKlinesTipos(Me.DbhotelDataSet.dwmatia, klinesKwd, tiposKwd)
            ElseIf klinesKwd = 0 And tiposKwd = 0 Then
                Me.DwmatiaTableAdapter.FillDwmatiaOlwnKatigoriwn(Me.DbhotelDataSet.dwmatia)
            ElseIf klinesKwd <> 0 And tiposKwd = 0 Then
                Me.DwmatiaTableAdapter.FillDwmatiaByKlines(Me.DbhotelDataSet.dwmatia, klinesKwd)
            ElseIf klinesKwd = 0 And tiposKwd <> 0 Then
                Me.DwmatiaTableAdapter.FillDwmatiaByTipos(Me.DbhotelDataSet.dwmatia, tiposKwd)
            End If

            If Me.DbhotelDataSet.dwmatia.Count <> 0 Then
                zeigerDwm1 = 0
                If Me.DbhotelDataSet.dwmatia.Count - 1 < 9 Then
                    zeigerDwm2 = Me.DbhotelDataSet.dwmatia.Count
                Else
                    zeigerDwm2 = 9
                End If
            End If

            fuehle_dwmatia_free(zeigerDwm1, zeigerDwm2, klinesKwd, tiposKwd, dwmBesetzt, 1)



        Catch ex As InvalidOperationException

        End Try

    End Sub
    Private Sub FreeDwmatImeromPck_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FreeDwmatImeromPck.ValueChanged
        Me.DbhotelDataSet.freedwmatia.Clear()
        zeigerDwm1 = 0
        zeigerDwm2 = 0
    End Sub
    Private Sub fuehle_dwmatia_free(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal klines As Integer, ByVal tipos As Integer, ByVal dwmBesetzt() As String, ByVal flag As Int16)
        Dim j, i As Int16
        Dim klinName, tipName As String

        j = zeiger1
        i = zeiger2

        'If i <> j Then
        klinName = ""
        tipName = ""
        If klines <> 0 Then
            klinName = get_klines_by_kwdikos(klines)
        End If
        If tipos <> 0 Then
            tipName = get_tipos_by_kwdikos(tipos)

        End If



        Me.DbhotelDataSet.freedwmatia.Clear()

        If flag = 1 Then
            ' j= zeiger1 deixnei aristeera opws virtual blepw til lista Dwmatiwn i=zeiger2 deksia
            'ean flag =1 tote EPOMENO ->while schleife gia j bis zeiger1=zeiger2
            'ena flag =-1 tote proigoumeno ->while schleife me -1 step  gia to zeiger2 bis pali zeiger1=zeiger2
            'ARA panta meta to telos zeiger1=zeigeer2 !!!!!!!
            While j <> i
                If Not kommt_vor(Me.DbhotelDataSet.dwmatia(j).arithmos, dwmBesetzt) Then
                    Me.DbhotelDataSet.freedwmatia.Rows.Add()
                    Me.DbhotelDataSet.freedwmatia(Me.DbhotelDataSet.freedwmatia.Count - 1).arithmos = Me.DbhotelDataSet.dwmatia(j).arithmos
                    If klines <> 0 Then
                        Me.DbhotelDataSet.freedwmatia(Me.DbhotelDataSet.freedwmatia.Count - 1).klines = klinName
                    Else
                        Me.DbhotelDataSet.freedwmatia(Me.DbhotelDataSet.freedwmatia.Count - 1).klines = Me.DbhotelDataSet.dwmatia(j).perigrafi
                    End If
                    If tipos <> 0 Then
                        Me.DbhotelDataSet.freedwmatia(Me.DbhotelDataSet.freedwmatia.Count - 1).tipos = tipName
                    Else
                        Me.DbhotelDataSet.freedwmatia(Me.DbhotelDataSet.freedwmatia.Count - 1).tipos = get_tipos_by_kwdikos(Me.DbhotelDataSet.dwmatia(j).tipos)
                    End If
                    j += 1
                Else
                    If i + 1 <= Me.DbhotelDataSet.dwmatia.Count - 1 Then
                        i += 1
                        j += 1
                    Else
                        j += 1
                    End If
                End If
            End While
            zeigerDwm1 = j
            zeigerDwm2 = zeigerDwm1
        ElseIf flag = -1 Then

            While i <> j
                If Not kommt_vor(Me.DbhotelDataSet.dwmatia(i).arithmos, dwmBesetzt) Then
                    Me.DbhotelDataSet.freedwmatia.Rows.Add()
                    Me.DbhotelDataSet.freedwmatia(Me.DbhotelDataSet.freedwmatia.Count - 1).arithmos = Me.DbhotelDataSet.dwmatia(i).arithmos
                    If klines <> 0 Then
                        Me.DbhotelDataSet.freedwmatia(Me.DbhotelDataSet.freedwmatia.Count - 1).klines = klinName
                    Else
                        Me.DbhotelDataSet.freedwmatia(Me.DbhotelDataSet.freedwmatia.Count - 1).klines = Me.DbhotelDataSet.dwmatia(i).perigrafi
                    End If
                    If tipos <> 0 Then
                        Me.DbhotelDataSet.freedwmatia(Me.DbhotelDataSet.freedwmatia.Count - 1).tipos = tipName
                    Else
                        Me.DbhotelDataSet.freedwmatia(Me.DbhotelDataSet.freedwmatia.Count - 1).tipos = get_tipos_by_kwdikos(Me.DbhotelDataSet.dwmatia(i).tipos)
                    End If
                    i -= 1
                Else
                    If j - 1 > 0 Then
                        i -= 1
                        j -= 1
                    Else
                        i -= 1
                    End If
                End If
            End While
            zeigerDwm1 = j
            zeigerDwm2 = zeigerDwm1


        End If

        'End If


    End Sub
    Private Function kommt_vor(ByVal dwmatio As String, ByVal dwmBesetzt() As String) As Boolean
        Dim j As Int16
        Try
            For j = 0 To dwmBesetzt.Length - 1
                If dwmatio.Equals(dwmBesetzt(j)) Then
                    Return True
                End If
            Next
            Return False
        Catch ex As NullReferenceException
            Return False
        End Try


    End Function
    Private Sub PrDwmBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrDwmBtn.Click
        If Me.DbhotelDataSet.dwmatia.Count <> 0 Then
            If zeigerDwm1 = Me.DbhotelDataSet.dwmatia.Count Then
                'init zeiger2 st0 telos tis lista (zeiget asuf leztes element) 
                zeigerDwm2 = Me.DbhotelDataSet.dwmatia.Count - 1
            End If

            If zeigerDwm1 - 9 >= -1 Then
                'meiwsw kata 9 ton prwto zeiger
                zeigerDwm1 -= 9
            Else
                'proto zeiger zeigigt PRIN to prwto element!(->logw while schleife )
                zeigerDwm1 = -1
            End If
            fuehle_dwmatia_free(zeigerDwm1, zeigerDwm2, klinesKwd, tiposKwd, dwmBesetzt, -1)
        End If
    End Sub
    Private Sub EpomDwmBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EpomDwmBtn.Click
        If Me.DbhotelDataSet.dwmatia.Count <> 0 Then
            If zeigerDwm2 = -1 Then
                'init zeiger1 stin arxi tis lista (zeiget auf erstes element) 
                zeigerDwm1 = 0
            End If
            If zeigerDwm2 < Me.DbhotelDataSet.dwmatia.Count + 1 Then
                If zeigerDwm2 + 9 < Me.DbhotelDataSet.dwmatia.Count + 1 Then
                    zeigerDwm2 += 9
                Else
                    'zeiger2 zeigigt META to teleuatao element!(->logw while schleife )
                    zeigerDwm2 = Me.DbhotelDataSet.dwmatia.Count
                End If
            End If
            fuehle_dwmatia_free(zeigerDwm1, zeigerDwm2, klinesKwd, tiposKwd, dwmBesetzt, 1)
        End If
    End Sub
    Private Sub FreeDwmatImeromDtGrd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FreeDwmatImeromDtGrd.DoubleClick
        If FreeDwmatImeromDtGrd.RowCount <> 0 Then
            dwmArithmos = FreeDwmatImeromDtGrd.Item(2, FreeDwmatImeromDtGrd.CurrentRow.Index).Value.ToString
            klinesKwd = Me.get_kwd_by_klines(FreeDwmatImeromDtGrd.Item(0, FreeDwmatImeromDtGrd.CurrentRow.Index).Value.ToString)
            tiposKwd = Me.get_kwd_by_tipos(FreeDwmatImeromDtGrd.Item(1, FreeDwmatImeromDtGrd.CurrentRow.Index).Value.ToString)
            Me.Close()
            Me.Finalize()
        End If
    End Sub
    Private Function get_tipos_by_kwdikos(ByVal kwdikos As Integer) As String
        Dim i As Int16
        For i = 0 To Me.DbhotelDataSet.tipoi.Count - 1
            If kwdikos = Me.DbhotelDataSet.tipoi(i).kwd Then
                Return Me.DbhotelDataSet.tipoi(i).tipos
            End If
        Next
        Return Nothing
    End Function
    Private Function get_kwd_by_tipos(ByVal tipos As String) As Integer
        Dim i As Int16
        For i = 0 To Me.DbhotelDataSet.tipoi.Count - 1
            If tipos = Me.DbhotelDataSet.tipoi(i).tipos Then
                Return Me.DbhotelDataSet.tipoi(i).kwd
            End If
        Next
        Return Nothing

    End Function
    Private Function get_klines_by_kwdikos(ByVal kwdikos As Integer) As String
        Dim i As Int16

        For i = 0 To Me.DbhotelDataSet.klines.Count - 1
            If kwdikos = Me.DbhotelDataSet.klines(i).kwd Then
                Return Me.DbhotelDataSet.klines(i).perigrafi
            End If
        Next

        Return Nothing

    End Function
    Private Function get_kwd_by_klines(ByVal klines As String) As Integer
        Dim i As Int16

        For i = 0 To Me.DbhotelDataSet.klines.Count - 1
            If klines = Me.DbhotelDataSet.klines(i).perigrafi Then
                Return Me.DbhotelDataSet.klines(i).kwd
            End If
        Next

        Return Nothing

    End Function
    Public Function return_arithmo_dwmatiou() As String
        Return dwmArithmos
    End Function
    Public Function return_klines_dwmatiou() As Integer
        Return klinesKwd
    End Function
    Public Function return_tipos_dwmatiou() As Integer
        Return tiposKwd
    End Function

    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
    

    'Private Sub FreeDwmatImerom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.status' table. You can move, or remove it, as needed.
    '    Me.StatusTableAdapter.Fill(Me.DbhotelDataSet.status)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.katigories' table. You can move, or remove it, as needed.
    '    Me.KatigoriesTableAdapter.Fill(Me.DbhotelDataSet.katigories)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.dwmatia' table. You can move, or remove it, as needed.
    '    Me.DwmatiaTableAdapter.Fill(Me.DbhotelDataSet.dwmatia)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.tipoi' table. You can move, or remove it, as needed.
    '    Me.TipoiTableAdapter.Fill(Me.DbhotelDataSet.tipoi)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.klines' table. You can move, or remove it, as needed.
    '    Me.KlinesTableAdapter.Fill(Me.DbhotelDataSet.klines)

    'End Sub

   
End Class