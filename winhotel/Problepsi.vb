Public Class Problepsi
    Dim etos As Int16 = 2007
    Dim locationX() As Int16 ' speichern der Anfangs X-Koordinaten der epilefalida Labeln gia Stoixisi
    Dim status1(), afix1(), anax1(), status2(), afix2(), anax2(), status3(), afix3(), anax3() As Int16
    Dim imeromErgasias, trexImer As Date ' trexousa imerominia
    Dim kwdPrakt As Integer = -1

    Private Sub KinisiEmfBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KinisiEmfBtn.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Problepsi3Pnl.Controls.Clear()
            trexImer = ProblepsiPck.Value.Date

            If StatusRdb.Checked Then
                If trexImer.AddDays(2) > ProblepsiPck.MaxDate Then
                    trexImer = ProblepsiPck.MaxDate.AddDays(-2)
                End If
                status_problepsi(trexImer, trexImer.AddDays(2))
            Else
                prakt_problepsi(trexImer)
            End If
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Default

        
    End Sub
    Private Sub NextBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextBtn.Click
        Problepsi3Pnl.Controls.Clear()

        trexImer = trexImer.AddDays(3)

        If trexImer.AddDays(2) > ProblepsiPck.MaxDate Then
            trexImer = ProblepsiPck.MaxDate.AddDays(-2)
        End If
        status_problepsi(trexImer, trexImer.AddDays(2))


    End Sub

    Private Sub PreviousBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousBtn.Click
        Problepsi3Pnl.Controls.Clear()
        If trexImer.AddDays(-3) < imeromErgasias Then
            trexImer = imeromErgasias
        Else
            trexImer = trexImer.AddDays(-3)
        End If
        status_problepsi(trexImer, trexImer.AddDays(2))
    End Sub
    Private Sub ProblepsiTbx_enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProblepsiTbx.Enter
        Dim PraktForm As New SimbolaiaFrm()
        Dim kwdikos As Integer

        PraktForm.StartPosition = FormStartPosition.CenterParent
        PraktForm.ShowDialog()
        kwdikos = PraktForm.return_praktoreio_kwdikos

        If kwdikos = Nothing Then
            kwdPrakt = -1
            ProblepsiTbx.Clear()
        Else
            kwdPrakt = kwdikos
            ProblepsiTbx.Text = PraktForm.return_praktoreio
        End If
        KinisiEmfBtn.Focus()
    End Sub

    'dynamisches malen von epikefalida
    Private Sub male_kefalida()

        Dim stepy, stepx, xstart, ystart As Int16

        Dim kefalCount As Int16 = 0

        stepx = 100
        stepy = 100
        xstart = 2
        ystart = 10
        'Me.EggrafitakiniseisTableAdapter.FillByEggrafi(Me.DbhotelDataSet.eggrafitakiniseis, eggrafiKwd)

        Dim ImeromLbl, OverLbl, DwmLbl, EnilLbl, PaidsLbl, SynolLbl, RrLbl, BbLbl, HbLbl, FbLbl, AiLbl, EisprLbl As New Label

        ImeromLbl.Text = "Ημερομηνία"
        ImeromLbl.TextAlign = ContentAlignment.MiddleLeft
        ImeromLbl.Size = New Point(200, 20)
        ImeromLbl.Location = New Point(xstart, ystart)
        ImeromLbl.BackColor = Color.DarkKhaki
        ImeromLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart ' speichern der Anfangs X-Koordinaten der epilefalida Labeln gia Stoixisi

        OverLbl.Text = "Over"
        OverLbl.TextAlign = ContentAlignment.MiddleCenter
        OverLbl.Size = New Point(55, 20)
        OverLbl.Location = New Point(xstart + ImeromLbl.Width + 2, ystart)
        OverLbl.BackColor = Color.DarkKhaki
        OverLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2

        DwmLbl.Text = "Δωμ."
        DwmLbl.TextAlign = ContentAlignment.MiddleCenter
        DwmLbl.Size = New Point(55, 20)
        DwmLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2, ystart)
        DwmLbl.BackColor = Color.DarkKhaki
        DwmLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2

        EnilLbl.Text = "Ενηλ."
        EnilLbl.TextAlign = ContentAlignment.MiddleCenter
        EnilLbl.Size = New Point(55, 20)
        EnilLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2, ystart)
        EnilLbl.BackColor = Color.DarkKhaki
        EnilLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2

        PaidsLbl.Text = "Παιδ."
        PaidsLbl.TextAlign = ContentAlignment.MiddleCenter
        PaidsLbl.Size = New Point(55, 20)
        PaidsLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2, ystart)
        PaidsLbl.BackColor = Color.DarkKhaki
        PaidsLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2

        SynolLbl.Text = "Συν."
        SynolLbl.TextAlign = ContentAlignment.MiddleCenter
        SynolLbl.Size = New Point(55, 20)
        SynolLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2, ystart)
        SynolLbl.BackColor = Color.DarkKhaki
        SynolLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2

        RrLbl.Text = "RR"
        RrLbl.TextAlign = ContentAlignment.MiddleCenter
        RrLbl.Size = New Point(55, 20)
        RrLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2, ystart)
        RrLbl.BackColor = Color.DarkKhaki
        RrLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2

        BbLbl.Text = "BB"
        BbLbl.TextAlign = ContentAlignment.MiddleCenter
        BbLbl.Size = New Point(55, 20)
        BbLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2 + RrLbl.Width + 2, ystart)
        BbLbl.BackColor = Color.DarkKhaki
        BbLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2 + RrLbl.Width + 2

        HbLbl.Text = "HB"
        HbLbl.TextAlign = ContentAlignment.MiddleCenter
        HbLbl.Size = New Point(55, 20)
        HbLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2 + RrLbl.Width + 2 + EnilLbl.Width + 2, ystart)
        HbLbl.BackColor = Color.DarkKhaki
        HbLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2 + RrLbl.Width + 2 + BbLbl.Width + 2

        FbLbl.Text = "FB"
        FbLbl.TextAlign = ContentAlignment.MiddleCenter
        FbLbl.Size = New Point(55, 20)
        FbLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2 + RrLbl.Width + 2 + BbLbl.Width + 2 + HbLbl.Width + 2, ystart)
        FbLbl.BackColor = Color.DarkKhaki
        FbLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2 + RrLbl.Width + 2 + BbLbl.Width + 2 + HbLbl.Width + 2

        AiLbl.Text = "AI"
        AiLbl.TextAlign = ContentAlignment.MiddleCenter
        AiLbl.Size = New Point(55, 20)
        AiLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2 + RrLbl.Width + 2 + BbLbl.Width + 2 + HbLbl.Width + 2 + FbLbl.Width + 2, ystart)
        AiLbl.BackColor = Color.DarkKhaki
        AiLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2 + RrLbl.Width + 2 + BbLbl.Width + 2 + HbLbl.Width + 2 + FbLbl.Width + 2


        EisprLbl.Text = "Είσπραξη"
        EisprLbl.TextAlign = ContentAlignment.MiddleCenter
        EisprLbl.Size = New Point(100, 20)
        EisprLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2 + RrLbl.Width + 2 + BbLbl.Width + 2 + HbLbl.Width + 2 + FbLbl.Width + 2 + AiLbl.Width + 2, ystart)
        EisprLbl.BackColor = Color.DarkKhaki
        EisprLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + OverLbl.Width + 2 + DwmLbl.Width + 2 + EnilLbl.Width + 2 + PaidsLbl.Width + 2 + SynolLbl.Width + 2 + RrLbl.Width + 2 + BbLbl.Width + 2 + HbLbl.Width + 2 + FbLbl.Width + 2 + AiLbl.Width + 2

        Problepsi2Pnl.Controls.Add(ImeromLbl)
        Problepsi2Pnl.Controls.Add(OverLbl)
        Problepsi2Pnl.Controls.Add(DwmLbl)
        Problepsi2Pnl.Controls.Add(EnilLbl)
        Problepsi2Pnl.Controls.Add(PaidsLbl)
        Problepsi2Pnl.Controls.Add(SynolLbl)
        Problepsi2Pnl.Controls.Add(RrLbl)
        Problepsi2Pnl.Controls.Add(BbLbl)
        Problepsi2Pnl.Controls.Add(HbLbl)
        Problepsi2Pnl.Controls.Add(FbLbl)
        Problepsi2Pnl.Controls.Add(AiLbl)
        Problepsi2Pnl.Controls.Add(EisprLbl)
    End Sub
    'problepsi TRIHMEROU gia stastus-afixeis-anaxwriseis
    Private Sub status_problepsi(ByVal arxi As Date, ByVal telos As Date)
        Dim j, arKrat As Int16

        'DSTRuren zum speichern der werte (px status1->status tin 1. imera, anax3->anaxwrisi tin 3. imera
        'kathw mia exei 10 theseis-> 0 over, 1 Dwm, 2 Enil,...9 AI (sinfwna me tin seira stin epikefalida)
        ReDim status1(9)
        ReDim afix1(9)
        ReDim anax1(9)
        ReDim status2(9)
        ReDim afix2(9)
        ReDim anax2(9)
        ReDim status3(9)
        ReDim afix3(9)
        ReDim anax3(9)

        arKrat = 0
        'Join anfrage KratiseisXtimeskratiseis(gia xrewsi mono)
        'Me.KratiseisTableAdapter.FillJoinKratInZeitInervDailyReportByAfixiAnax(Me.DbhotelDataSet.kratiseis, arxi, arxi, telos, telos, arxi, telos)
        Me.Main_curanteTableAdapter.DailyReportMinaEtosXrewsiOverByAfixAnax(Me.DbhotelDataSet.main_curante, arxi, arxi, telos, telos, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1

            'einai Join Kratiseis X Timeakratisis->ean  se mia kratisi, die ueber mehrere TouristPeriodoi hinaus geht, wenn
            'autoi oi Tourist periodoi (kata lathos) exoun diaforetiki Xrewsi (HB,RR..)apo mia tote to Join anfrage kanei resultieren mehrere 
            'rows->atoma dipla kai tripla (jenachdem)->giauto elegxw arithmo kratisis na min epanatlifthei (anfrage einai kata arithmo kratisis sortiert !)
            'If Me.DbhotelDataSet.main_curante(j).arithmos <> arKrat Then

            'arKrat = Me.DbhotelDataSet.main_curante(j).arithmos
            If Me.DbhotelDataSet.main_curante(j).apo < arxi And Me.DbhotelDataSet.main_curante(j).mexri > telos Then ' 3 afixeis
                rechne_werte(1, 1, j) '1.mera- status- kratisiIndex
                rechne_werte(2, 1, j) '2.mera- status- kratisiIndex
                rechne_werte(3, 1, j) '3.mera- status- kratisiIndex
            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(1, 1, j) '1.mera- status- kratisiIndex
                rechne_werte(2, 1, j) '2.mera- status- kratisiIndex
                rechne_werte(3, 3, j) '3.mera- mexri- kratisiIndex
            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then 'NEO
                rechne_werte(1, 1, j)
                rechne_werte(2, 1, j)
                rechne_werte(3, 1, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri <> arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(1, 1, j) '1.mera- status- kratisiIndex
                rechne_werte(2, 3, j) '2.mera- mexri- kratisiIndex
            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri <> arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(1, 1, j)
                rechne_werte(2, 1, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri = arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(1, 3, j) '1.mera- mexri- kratisiIndex
            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri = arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(1, 1, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri > telos Then
                rechne_werte(1, 2, j) '1.mera- apo- kratisiIndex
                rechne_werte(2, 1, j) '2.mera- status- kratisiIndex
                rechne_werte(3, 1, j) '3.mera- status- kratisiIndex
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri > telos Then
                rechne_werte(1, 1, j)
                rechne_werte(2, 1, j)
                rechne_werte(3, 1, j)
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(1, 2, j) '1.mera- apo- kratisiIndex
                rechne_werte(2, 1, j) '2.mera- status- kratisiIndex
                rechne_werte(3, 3, j) '3.mera- mexri- kratisiIndex
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(1, 1, j)
                rechne_werte(2, 1, j)
                rechne_werte(3, 3, j) '
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi _
            And Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(1, 2, j)
                rechne_werte(2, 1, j)
                rechne_werte(3, 1, j)
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(1, 1, j)
                rechne_werte(2, 1, j)
                rechne_werte(3, 1, j)
                'ok

            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                rechne_werte(1, 2, j) '1.mera- apo- kratisiIndex
                rechne_werte(2, 3, j) '2.mera- mexri- kratisiIndex
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).mexri Then

                rechne_werte(1, 2, j) '1.mera- apo- kratisiIndex
                rechne_werte(2, 1, j) '2.mera- mexri- kratisiIndex
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).mexri Then
                rechne_werte(1, 2, j)


            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).mexri Then

                rechne_werte(1, 1, j)
                rechne_werte(2, 3, j)

            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).mexri Then

                rechne_werte(1, 1, j) '1.mera- apo- kratisiIndex
                rechne_werte(2, 1, j) '2.mera- mexri- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).mexri Then

                rechne_werte(1, 1, j)

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri > telos Then
                rechne_werte(2, 2, j) '2.mera- apo- kratisiIndex
                rechne_werte(3, 1, j) '3.mera- status- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                rechne_werte(2, 2, j) '2.mera- apo- kratisiIndex
                rechne_werte(3, 1, j) '3.mera- status- kratisiIndex


            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
           Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                rechne_werte(2, 2, j)
                rechne_werte(3, 3, j)



            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
           Me.DbhotelDataSet.main_curante(j).apo < telos And _
           Me.DbhotelDataSet.main_curante(j).mexri > telos Then

                rechne_werte(2, 1, j) '2.mera- apo- kratisiIndex
                rechne_werte(3, 1, j) '3.mera- status- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(2, 1, j) '2.mera- apo- kratisiIndex
                rechne_werte(3, 3, j) '3.mera- status- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                rechne_werte(2, 1, j) '2.mera- apo- kratisiIndex
                rechne_werte(3, 1, j) '3.mera- status- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos Then

                rechne_werte(2, 1, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos Then

                rechne_werte(2, 2, j)


            ElseIf Me.DbhotelDataSet.main_curante(j).apo = telos And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi Then
                rechne_werte(3, 2, j) '

            ElseIf Me.DbhotelDataSet.main_curante(j).apo = telos And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi Then
                'Me.DbhotelDataSet.main_curante(j).mexri >= telos And _
                'Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                rechne_werte(3, 1, j) '3.mera- apo- kratisiIndex
                'ElseIf Me.DbhotelDataSet.main_curante(j).apo = telos And _
                '      Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
                '      Me.DbhotelDataSet.main_curante(j).mexri > telos Then
                '    rechne_werte(3, 1, j) '3.
            Else
                MsgBox(Me.DbhotelDataSet.main_curante(j).apo)
                MsgBox(Me.DbhotelDataSet.main_curante(j).mexri)

            End If
            'End If


        Next

        male_panel_status(arxi)

    End Sub
    Private Sub male_panel_status(ByVal imerom As Date)
        Dim j, k As Int16
        Dim ystep, ypos As Int16

        ystep = 25

        For k = 0 To 2 ' laufvariabel fuer tis 3 Imeres 
            For j = 0 To 2 'laufvariabel fuer status,afixeis, anaxwriseis
                Dim ImeromLbl, LabLbl, OverLbl, DwmLbl, EnilLbl, PaidsLbl, SynolLbl, RrLbl, BbLbl, HbLbl, FbLbl, AiLbl, EisprLbl As New Label

                ypos = (k * 100) + (j * ystep + 5)

                If k = 0 Then
                    If j = 0 Then ' imeromina mono stin prwti grami
                        ImeromLbl.Text = imerom.Date.ToString
                    ElseIf j = 1 Then ' stin deuteri akoloutha i imera-> Deutera usw
                        ImeromLbl.Text = welche_tag_der_woche(imerom.DayOfWeek)
                    End If
                Else
                    If j = 0 Then
                        ImeromLbl.Text = imerom.AddDays(k).Date.ToString
                    ElseIf j = 1 Then
                        ImeromLbl.Text = welche_tag_der_woche(imerom.AddDays(k).DayOfWeek)
                    End If
                End If
                ImeromLbl.TextAlign = ContentAlignment.MiddleLeft
                ImeromLbl.Size = New Point(100, 20)
                ImeromLbl.Location = New Point(locationX(0), ypos)
                'ImeromLbl.BackColor = Color.Azure
                ImeromLbl.ForeColor = Color.Maroon

                If j = 0 Then
                    LabLbl.Text = "Status:"
                ElseIf j = 1 Then
                    LabLbl.Text = "Αφίξεις:"
                ElseIf j = 2 Then
                    LabLbl.Text = "Αναχωρήσεις:"
                End If
                LabLbl.TextAlign = ContentAlignment.MiddleRight
                LabLbl.Size = New Point(100, 20)
                LabLbl.Location = New Point(locationX(0) + ImeromLbl.Width, ypos)
                'LabLbl.BackColor = Color.Azure
                LabLbl.ForeColor = Color.Black

                If k = 0 Then '1. imera
                    If j = 0 AndAlso status1(0) <> 0 Then 'status
                        OverLbl.Text = status1(0).ToString
                    ElseIf j = 1 AndAlso afix1(0) <> 0 Then ''afixeis
                        OverLbl.Text = afix1(0).ToString
                    ElseIf j = 2 AndAlso anax1(0) <> 0 Then 'anaxwriseis
                        OverLbl.Text = anax1(0).ToString
                    End If
                ElseIf k = 1 Then '2. imera
                    If j = 0 AndAlso status2(0) <> 0 Then 'status
                        OverLbl.Text = status2(0).ToString
                    ElseIf j = 1 AndAlso afix2(0) <> 0 Then 'afixeis
                        OverLbl.Text = afix2(0).ToString
                    ElseIf j = 2 AndAlso anax2(0) <> 0 Then 'anaxwriseis
                        OverLbl.Text = anax2(0).ToString
                    End If
                ElseIf k = 2 Then '3 imera
                    If j = 0 AndAlso status3(0) <> 0 Then 'status
                        OverLbl.Text = status3(0).ToString
                    ElseIf j = 1 AndAlso afix3(0) <> 0 Then 'afixeis
                        OverLbl.Text = afix3(0).ToString
                    ElseIf j = 2 AndAlso anax3(0) <> 0 Then 'anaxwriseis
                        OverLbl.Text = anax3(0).ToString
                    End If
                End If
                OverLbl.TextAlign = ContentAlignment.MiddleCenter
                OverLbl.Size = New Point(55, 20)
                OverLbl.Location = New Point(locationX(1), ypos)
                OverLbl.BackColor = Color.Azure
                OverLbl.ForeColor = Color.Black

                If k = 0 Then
                    If j = 0 AndAlso status1(1) <> 0 Then
                        DwmLbl.Text = status1(1).ToString
                    ElseIf j = 1 AndAlso afix1(1) <> 0 Then
                        DwmLbl.Text = afix1(1).ToString
                    ElseIf j = 2 AndAlso anax1(1) <> 0 Then
                        DwmLbl.Text = anax1(1).ToString
                    End If
                ElseIf k = 1 Then
                    If j = 0 AndAlso status2(1) <> 0 Then
                        DwmLbl.Text = status2(1).ToString
                    ElseIf j = 1 AndAlso afix2(1) <> 0 Then
                        DwmLbl.Text = afix2(1).ToString
                    ElseIf j = 2 AndAlso anax2(1) <> 0 Then
                        DwmLbl.Text = anax2(1).ToString
                    End If
                ElseIf k = 2 Then
                    If j = 0 AndAlso status3(1) <> 0 Then
                        DwmLbl.Text = status3(1).ToString
                    ElseIf j = 1 AndAlso afix3(1) <> 0 Then
                        DwmLbl.Text = afix3(1).ToString
                    ElseIf j = 2 AndAlso anax3(1) <> 0 Then
                        DwmLbl.Text = anax3(1).ToString
                    End If
                End If
                DwmLbl.TextAlign = ContentAlignment.MiddleCenter
                DwmLbl.Size = New Point(55, 20)
                DwmLbl.Location = New Point(locationX(2), ypos)
                DwmLbl.BackColor = Color.Azure
                DwmLbl.ForeColor = Color.Black

                If k = 0 Then
                    If j = 0 AndAlso status1(2) <> 0 Then
                        EnilLbl.Text = status1(2).ToString
                    ElseIf j = 1 AndAlso afix1(2) <> 0 Then
                        EnilLbl.Text = afix1(2).ToString
                    ElseIf j = 2 AndAlso anax1(2) <> 0 Then
                        EnilLbl.Text = anax1(2).ToString
                    End If
                ElseIf k = 1 Then
                    If j = 0 AndAlso status2(2) <> 0 Then
                        EnilLbl.Text = status2(2).ToString
                    ElseIf j = 1 AndAlso afix2(2) <> 0 Then
                        EnilLbl.Text = afix2(2).ToString
                    ElseIf j = 2 AndAlso anax2(2) <> 0 Then
                        EnilLbl.Text = anax2(2).ToString
                    End If
                ElseIf k = 2 Then
                    If j = 0 AndAlso status3(2) <> 0 Then
                        EnilLbl.Text = status3(2).ToString
                    ElseIf j = 1 AndAlso afix3(2) <> 0 Then
                        EnilLbl.Text = afix3(2).ToString
                    ElseIf j = 2 AndAlso anax3(2) <> 0 Then
                        EnilLbl.Text = anax3(2).ToString
                    End If
                End If
                EnilLbl.TextAlign = ContentAlignment.MiddleCenter
                EnilLbl.Size = New Point(55, 20)
                EnilLbl.Location = New Point(locationX(3), ypos)
                EnilLbl.BackColor = Color.Azure
                EnilLbl.ForeColor = Color.Black

                If k = 0 Then
                    If j = 0 AndAlso status1(3) <> 0 Then
                        PaidsLbl.Text = status1(3).ToString
                    ElseIf j = 1 AndAlso afix1(3) <> 0 Then
                        PaidsLbl.Text = afix1(3).ToString
                    ElseIf j = 2 AndAlso anax1(3) <> 0 Then
                        PaidsLbl.Text = anax1(3).ToString
                    End If
                ElseIf k = 1 Then
                    If j = 0 AndAlso status2(3) <> 0 Then
                        PaidsLbl.Text = status2(3).ToString
                    ElseIf j = 1 AndAlso afix2(3) <> 0 Then
                        PaidsLbl.Text = afix2(3).ToString
                    ElseIf j = 2 AndAlso anax2(3) <> 0 Then
                        PaidsLbl.Text = anax2(3).ToString
                    End If
                ElseIf k = 2 Then
                    If j = 0 AndAlso status3(3) <> 0 Then
                        PaidsLbl.Text = status3(3).ToString
                    ElseIf j = 1 AndAlso afix3(3) <> 0 Then
                        PaidsLbl.Text = afix3(3).ToString
                    ElseIf j = 2 AndAlso anax3(3) <> 0 Then
                        PaidsLbl.Text = anax3(3).ToString
                    End If
                End If
                PaidsLbl.TextAlign = ContentAlignment.MiddleCenter
                PaidsLbl.Size = New Point(55, 20)
                PaidsLbl.Location = New Point(locationX(4), ypos)
                PaidsLbl.BackColor = Color.Azure
                PaidsLbl.ForeColor = Color.Black

                If k = 0 Then
                    If j = 0 AndAlso status1(4) <> 0 Then
                        SynolLbl.Text = status1(4).ToString
                    ElseIf j = 1 AndAlso afix1(4) <> 0 Then
                        SynolLbl.Text = afix1(4).ToString
                    ElseIf j = 2 AndAlso anax1(4) <> 0 Then
                        SynolLbl.Text = anax1(4).ToString
                    End If
                ElseIf k = 1 Then
                    If j = 0 AndAlso status2(4) <> 0 Then
                        SynolLbl.Text = status2(4).ToString
                    ElseIf j = 1 AndAlso afix2(4) <> 0 Then
                        SynolLbl.Text = afix2(4).ToString
                    ElseIf j = 2 AndAlso anax2(4) <> 0 Then
                        SynolLbl.Text = anax2(4).ToString
                    End If
                ElseIf k = 2 Then
                    If j = 0 AndAlso status3(4) <> 0 Then
                        SynolLbl.Text = status3(4).ToString
                    ElseIf j = 1 AndAlso afix3(4) <> 0 Then
                        SynolLbl.Text = afix3(4).ToString
                    ElseIf j = 2 AndAlso anax3(4) <> 0 Then
                        SynolLbl.Text = anax3(4).ToString
                    End If
                End If
                SynolLbl.TextAlign = ContentAlignment.MiddleCenter
                SynolLbl.Size = New Point(55, 20)
                SynolLbl.Location = New Point(locationX(5), ypos)
                SynolLbl.BackColor = Color.Azure
                SynolLbl.ForeColor = Color.Black

                If k = 0 Then
                    If j = 0 AndAlso status1(5) <> 0 Then
                        RrLbl.Text = status1(5).ToString
                    ElseIf j = 1 AndAlso afix1(5) <> 0 Then
                        RrLbl.Text = afix1(5).ToString
                    ElseIf j = 2 AndAlso anax1(5) <> 0 Then
                        RrLbl.Text = anax1(5).ToString
                    End If
                ElseIf k = 1 Then
                    If j = 0 AndAlso status2(5) <> 0 Then
                        RrLbl.Text = status2(5).ToString
                    ElseIf j = 1 AndAlso afix2(5) <> 0 Then
                        RrLbl.Text = afix2(5).ToString
                    ElseIf j = 2 AndAlso anax2(5) <> 0 Then
                        RrLbl.Text = anax2(5).ToString
                    End If
                ElseIf k = 2 Then
                    If j = 0 AndAlso status3(5) <> 0 Then
                        RrLbl.Text = status3(5).ToString
                    ElseIf j = 1 AndAlso afix3(5) <> 0 Then
                        RrLbl.Text = afix3(5).ToString
                    ElseIf j = 2 AndAlso anax3(5) <> 0 Then
                        RrLbl.Text = anax3(5).ToString
                    End If
                End If
                RrLbl.TextAlign = ContentAlignment.MiddleCenter
                RrLbl.Size = New Point(55, 20)
                RrLbl.Location = New Point(locationX(6), ypos)
                RrLbl.BackColor = Color.Azure
                RrLbl.ForeColor = Color.Black

                If k = 0 Then
                    If j = 0 AndAlso status1(6) <> 0 Then
                        BbLbl.Text = status1(6).ToString
                    ElseIf j = 1 AndAlso afix1(6) <> 0 Then
                        BbLbl.Text = afix1(6).ToString
                    ElseIf j = 2 AndAlso anax1(6) <> 0 Then
                        BbLbl.Text = anax1(6).ToString
                    End If
                ElseIf k = 1 Then
                    If j = 0 AndAlso status2(6) <> 0 Then
                        BbLbl.Text = status2(6).ToString
                    ElseIf j = 1 AndAlso afix2(6) <> 0 Then
                        BbLbl.Text = afix2(6).ToString
                    ElseIf j = 2 AndAlso anax2(6) <> 0 Then
                        BbLbl.Text = anax2(6).ToString
                    End If
                ElseIf k = 2 Then
                    If j = 0 AndAlso status3(6) <> 0 Then
                        BbLbl.Text = status3(6).ToString
                    ElseIf j = 1 AndAlso afix3(6) <> 0 Then
                        BbLbl.Text = afix3(6).ToString
                    ElseIf j = 2 AndAlso anax3(6) <> 0 Then
                        BbLbl.Text = anax3(6).ToString
                    End If
                End If
                BbLbl.TextAlign = ContentAlignment.MiddleCenter
                BbLbl.Size = New Point(55, 20)
                BbLbl.Location = New Point(locationX(7), ypos)
                BbLbl.BackColor = Color.Azure
                BbLbl.ForeColor = Color.Black

                If k = 0 Then
                    If j = 0 AndAlso status1(7) <> 0 Then
                        HbLbl.Text = status1(7).ToString
                    ElseIf j = 1 AndAlso afix1(7) <> 0 Then
                        HbLbl.Text = afix1(7).ToString
                    ElseIf j = 2 AndAlso anax1(7) <> 0 Then
                        HbLbl.Text = anax1(7).ToString
                    End If
                ElseIf k = 1 Then
                    If j = 0 AndAlso status2(7) <> 0 Then
                        HbLbl.Text = status2(7).ToString
                    ElseIf j = 1 AndAlso afix2(7) <> 0 Then
                        HbLbl.Text = afix2(7).ToString
                    ElseIf j = 2 AndAlso anax2(7) <> 0 Then
                        HbLbl.Text = anax2(7).ToString
                    End If
                ElseIf k = 2 Then
                    If j = 0 AndAlso status3(7) <> 0 Then
                        HbLbl.Text = status3(7).ToString
                    ElseIf j = 1 AndAlso afix3(7) <> 0 Then
                        HbLbl.Text = afix3(7).ToString
                    ElseIf j = 2 AndAlso anax3(7) <> 0 Then
                        HbLbl.Text = anax3(7).ToString
                    End If
                End If
                HbLbl.TextAlign = ContentAlignment.MiddleCenter
                HbLbl.Size = New Point(55, 20)
                HbLbl.Location = New Point(locationX(8), ypos)
                HbLbl.BackColor = Color.Azure
                HbLbl.ForeColor = Color.Black

                If k = 0 Then
                    If j = 0 AndAlso status1(8) <> 0 Then
                        FbLbl.Text = status1(8).ToString
                    ElseIf j = 1 AndAlso afix1(8) <> 0 Then
                        FbLbl.Text = afix1(8).ToString
                    ElseIf j = 2 AndAlso anax1(8) <> 0 Then
                        FbLbl.Text = anax1(8).ToString
                    End If
                ElseIf k = 1 Then
                    If j = 0 AndAlso status2(8) <> 0 Then
                        FbLbl.Text = status2(8).ToString
                    ElseIf j = 1 AndAlso afix2(8) <> 0 Then
                        FbLbl.Text = afix2(8).ToString
                    ElseIf j = 2 AndAlso anax2(8) <> 0 Then
                        FbLbl.Text = anax2(8).ToString
                    End If
                ElseIf k = 2 Then
                    If j = 0 AndAlso status3(8) <> 0 Then
                        FbLbl.Text = status3(8).ToString
                    ElseIf j = 1 AndAlso afix3(8) <> 0 Then
                        FbLbl.Text = afix3(8).ToString
                    ElseIf j = 2 AndAlso anax3(8) <> 0 Then
                        FbLbl.Text = anax3(8).ToString
                    End If
                End If
                FbLbl.TextAlign = ContentAlignment.MiddleCenter
                FbLbl.Size = New Point(55, 20)
                FbLbl.Location = New Point(locationX(9), ypos)
                FbLbl.BackColor = Color.Azure
                FbLbl.ForeColor = Color.Black

                If k = 0 Then
                    If j = 0 AndAlso status1(9) <> 0 Then
                        AiLbl.Text = status1(9).ToString
                    ElseIf j = 1 AndAlso afix1(9) <> 0 Then
                        AiLbl.Text = afix1(9).ToString
                    ElseIf j = 2 AndAlso anax1(9) <> 0 Then
                        AiLbl.Text = anax1(9).ToString
                    End If
                ElseIf k = 1 Then
                    If j = 0 AndAlso status2(9) <> 0 Then
                        AiLbl.Text = status2(9).ToString
                    ElseIf j = 1 AndAlso afix2(9) <> 0 Then
                        AiLbl.Text = afix2(9).ToString
                    ElseIf j = 2 AndAlso anax2(9) <> 0 Then
                        AiLbl.Text = anax2(9).ToString
                    End If
                ElseIf k = 2 Then
                    If j = 0 AndAlso status3(9) <> 0 Then
                        AiLbl.Text = status3(9).ToString
                    ElseIf j = 1 AndAlso afix3(9) <> 0 Then
                        AiLbl.Text = afix3(9).ToString
                    ElseIf j = 2 AndAlso anax3(9) <> 0 Then
                        AiLbl.Text = anax3(9).ToString
                    End If
                End If
                AiLbl.TextAlign = ContentAlignment.MiddleCenter
                AiLbl.Size = New Point(55, 20)
                AiLbl.Location = New Point(locationX(10), ypos)
                AiLbl.BackColor = Color.Azure
                AiLbl.ForeColor = Color.Black

                Problepsi3Pnl.Controls.Add(ImeromLbl)
                Problepsi3Pnl.Controls.Add(LabLbl)
                Problepsi3Pnl.Controls.Add(OverLbl)
                Problepsi3Pnl.Controls.Add(DwmLbl)
                Problepsi3Pnl.Controls.Add(EnilLbl)
                Problepsi3Pnl.Controls.Add(PaidsLbl)
                Problepsi3Pnl.Controls.Add(SynolLbl)
                Problepsi3Pnl.Controls.Add(RrLbl)
                Problepsi3Pnl.Controls.Add(BbLbl)
                Problepsi3Pnl.Controls.Add(HbLbl)
                Problepsi3Pnl.Controls.Add(FbLbl)
                Problepsi3Pnl.Controls.Add(AiLbl)

            Next
        Next

    End Sub
    'fuellen der Dstrukturen 
    Private Sub rechne_werte(ByVal imer As Byte, ByVal flag As Byte, ByVal j As Int16)
        If imer = 1 Then '1 imera
            If flag = 1 Then 'status
                If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("Ov-Book") Then
                    status1(0) = status1(0) + 1
                Else
                    status1(1) = status1(1) + 1
                End If
                status1(2) = status1(2) + Me.DbhotelDataSet.main_curante(j).enilikes
                status1(3) = status1(3) + Me.DbhotelDataSet.main_curante(j).paidia
                status1(4) = status1(4) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                    Case 1
                        status1(5) = status1(5) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 2
                        status1(6) = status1(6) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 3
                        status1(7) = status1(7) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 4
                        status1(8) = status1(8) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 6
                        status1(9) = status1(9) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                End Select
            ElseIf flag = 2 Then 'afixeis
                If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("Ov-Book") Then
                    afix1(0) = afix1(0) + 1
                Else
                    afix1(1) = afix1(1) + 1
                End If
                afix1(2) = afix1(2) + Me.DbhotelDataSet.main_curante(j).enilikes
                afix1(3) = afix1(3) + Me.DbhotelDataSet.main_curante(j).paidia
                afix1(4) = afix1(4) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                    Case 1
                        afix1(5) = afix1(5) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 2
                        afix1(6) = afix1(6) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 3
                        afix1(7) = afix1(7) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 4
                        afix1(8) = afix1(8) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 6
                        afix1(9) = afix1(9) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                End Select
            ElseIf flag = 3 Then 'anaxwriseis
                If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("Ov-Book") Then
                    anax1(0) = anax1(0) - 1
                Else
                    anax1(1) = anax1(1) - 1
                End If
                anax1(2) = anax1(2) - Me.DbhotelDataSet.main_curante(j).enilikes
                anax1(3) = anax1(3) - Me.DbhotelDataSet.main_curante(j).paidia
                anax1(4) = anax1(4) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                    Case 1
                        anax1(5) = anax1(5) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 2
                        anax1(6) = anax1(6) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 3
                        anax1(7) = anax1(7) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 4
                        anax1(8) = anax1(8) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 6
                        anax1(9) = anax1(9) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                End Select
            End If
        ElseIf imer = 2 Then ' 2. Imera
            If flag = 1 Then ' status
                If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("Ov-Book") Then
                    status2(0) = status2(0) + 1
                Else
                    status2(1) = status2(1) + 1
                End If
                status2(2) = status2(2) + Me.DbhotelDataSet.main_curante(j).enilikes
                status2(3) = status2(3) + Me.DbhotelDataSet.main_curante(j).paidia
                status2(4) = status2(4) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                    Case 1
                        status2(5) = status2(5) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 2
                        status2(6) = status2(6) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 3
                        status2(7) = status2(7) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 4
                        status2(8) = status2(8) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 6
                        status2(9) = status2(9) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                End Select
            ElseIf flag = 2 Then ' afixeis
                If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("Ov-Book") Then
                    afix2(0) = afix2(0) + 1
                Else
                    afix2(1) = afix2(1) + 1
                End If
                afix2(2) = afix2(2) + Me.DbhotelDataSet.main_curante(j).enilikes
                afix2(3) = afix2(3) + Me.DbhotelDataSet.main_curante(j).paidia
                afix2(4) = afix2(4) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                    Case 1
                        afix2(5) = afix2(5) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 2
                        afix2(6) = afix2(6) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 3
                        afix2(7) = afix2(7) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 4
                        afix2(8) = afix2(8) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 6
                        afix2(9) = afix2(9) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                End Select
            ElseIf flag = 3 Then ' anaxwriseis
                If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("Ov-Book") Then
                    anax2(0) = anax2(0) - 1
                Else
                    anax2(1) = anax2(1) - 1
                End If
                anax2(2) = anax2(2) - Me.DbhotelDataSet.main_curante(j).enilikes
                anax2(3) = anax2(3) - Me.DbhotelDataSet.main_curante(j).paidia
                anax2(4) = anax2(4) - Me.DbhotelDataSet.main_curante(j).enilikes - Me.DbhotelDataSet.main_curante(j).paidia
                Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                    Case 1
                        anax2(5) = anax2(5) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 2
                        anax2(6) = anax2(6) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 3
                        anax2(7) = anax2(7) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 4
                        anax2(8) = anax2(8) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 6
                        anax2(9) = anax2(9) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                End Select

            End If
        Else '3. imera
            If flag = 1 Then
                If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("Ov-Book") Then
                    status3(0) = status3(0) + 1
                Else
                    status3(1) = status3(1) + 1
                End If
                status3(2) = status3(2) + Me.DbhotelDataSet.main_curante(j).enilikes
                status3(3) = status3(3) + Me.DbhotelDataSet.main_curante(j).paidia
                status3(4) = status3(4) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                    Case 1
                        status3(5) = status3(5) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 2
                        status3(6) = status3(6) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 3
                        status3(7) = status3(7) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 4
                        status3(8) = status3(8) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 6
                        status3(9) = status3(9) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                End Select
            ElseIf flag = 2 Then
                If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("Ov-Book") Then
                    afix3(0) = afix3(0) + 1
                Else
                    afix3(1) = afix3(1) + 1
                End If
                afix3(2) = afix3(2) + Me.DbhotelDataSet.main_curante(j).enilikes
                afix3(3) = afix3(3) + Me.DbhotelDataSet.main_curante(j).paidia
                afix3(4) = afix3(4) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                    Case 1
                        afix3(5) = afix3(5) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 2
                        afix3(6) = afix3(6) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 3
                        afix3(7) = afix3(7) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 4
                        afix3(8) = afix3(8) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                    Case 6
                        afix3(9) = afix3(9) + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                End Select
            ElseIf flag = 3 Then
                If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("Ov-Book") Then
                    anax3(0) = anax3(0) - 1
                Else
                    anax3(1) = anax3(1) - 1
                End If
                anax3(2) = anax3(2) - Me.DbhotelDataSet.main_curante(j).enilikes
                anax3(3) = anax3(3) - Me.DbhotelDataSet.main_curante(j).paidia
                anax3(4) = anax3(4) - Me.DbhotelDataSet.main_curante(j).enilikes - Me.DbhotelDataSet.main_curante(j).paidia
                Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                    Case 1
                        anax3(5) = anax3(5) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 2
                        anax3(6) = anax3(6) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 3
                        anax3(7) = anax3(7) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 4
                        anax3(8) = anax3(8) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                    Case 6
                        anax3(9) = anax3(9) - (Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia)
                End Select


            End If

        End If
    End Sub
    ' EDW PRAOBLEPSI ANAXWRHSEWN
    'Ta apotelesmata tis anfrage an Kratiseis logw tou JOIN kratiseisXtimeskratisis mporei na exei 1XN logw tou oti mporei mia kratisi na exei 
    'perisoteres twn mia xrewsewn (egw to upostirizw) ->gia tin Anaxwrisi pairnw upospin to teleutaio Tupel
    Private Sub prakt_problepsi(ByVal arxi As Date)
        Dim startindex, stepsindex As Int16
        'Dim grid As New DataGridView
        Dim BindingSource1 As New BindingSource

        Problepsi3Pnl.Controls.Clear()
        Me.DbhotelDataSet.problepsi_praktoreiou.Clear()
        Me.DbhotelDataSet.kratiseis.Clear()
        If kwdPrakt <> -1 Then
            Me.KratiseisTableAdapter.FillJoinForProblesiByAnaxwrisiPrakt(Me.DbhotelDataSet.kratiseis, arxi, kwdPrakt)
        Else
            Me.KratiseisTableAdapter.FillJoinForPraoblepsiByAnaxwrisi(Me.DbhotelDataSet.kratiseis, arxi)
        End If

        Do Until startindex > Me.DbhotelDataSet.kratiseis.Count - 1
            stepsindex = 1 'posa eintraege 

            'firstIndex = startIndex
            If startindex < Me.DbhotelDataSet.kratiseis.Count - 1 Then
                'gia kathemia kRatisi
                While Me.DbhotelDataSet.kratiseis(startindex).arithmos = Me.DbhotelDataSet.kratiseis(startindex + stepsindex).arithmos
                    stepsindex += 1
                    If startindex + stepsindex > Me.DbhotelDataSet.kratiseis.Count - 1 Then
                        Exit While
                    End If
                End While
                '->gia tin Anaxwrisi pairnw upospin to teleutaio Tupel tie Kratisis
                mache_anax_problepsi(startindex + stepsindex - 1)
                startindex = startindex + stepsindex
            Else
                '->gia tin Anaxwrisi pairnw upospin to teleutaio Tupel tie Kratisis
                mache_anax_problepsi(startindex + stepsindex - 1)

                Exit Do
            End If
        Loop


        'edw kane SOrtieren kata imerominia ! 
        BindingSource1.DataSource = Me.DbhotelDataSet.problepsi_praktoreiou
        BindingSource1.Sort = "imerominia ASC"
        grid.DataSource = BindingSource1
        male_rows(BindingSource1, grid)

    End Sub
    Private Sub mache_anax_problepsi(ByVal j As Int16)
        Me.DbhotelDataSet.problepsi_praktoreiou.Rows.Add()
        Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).imerominia = Me.DbhotelDataSet.kratiseis(j).anaxwrisi
        If Me.DbhotelDataSet.kratiseis(j).dwmatio.Equals("Ov-Book") Then
            Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).over = 1
        Else
            Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).dwm = 1
        End If

        Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).enil = Me.DbhotelDataSet.kratiseis(j).enilikes
        Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).paid = Me.DbhotelDataSet.kratiseis(j).paidia
        Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).syn = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
        Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).eispr = Me.DbhotelDataSet.kratiseis(j).synolo
        Select Case Me.DbhotelDataSet.kratiseis(j).praktoreio
            Case 1
                Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).rr = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
            Case 2
                Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).bb = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
            Case 3
                Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).hb = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
            Case 4
                Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).fb = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
            Case 6
                Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).ai = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
        End Select
    End Sub


    Private Sub male_rows(ByVal bind As BindingSource, ByVal grid As DataGridView)
        Dim j, startIndex, countIndex, ypos, ystep As Int16
        Dim sumEispr As Single 'sunoliki suma ->athroisma twn imerisiwn athroismamtwn
        ystep = 25


        Do Until startIndex > bind.Count - 1
            countIndex = 1 'posa eintraege 
            If startIndex < bind.Count - 1 Then
                'idia imerominia ->EXW kanei idi sortieren kata imerominia ->ara mporw na xrisimopoiisw tin while schleife 
                While grid.Item(0, startIndex).Value = grid.Item(0, startIndex + countIndex).Value 'Me.DbhotelDataSet.biblioportas(startIndex).imerominia = Me.DbhotelDataSet.biblioportas(startIndex + countIndex).imerominia 'Me.DbhotelDataSet.biblioportas(startIndex).imerominia < imeromErgasias AndAlso
                    countIndex += 1
                    If startIndex + countIndex > bind.Count - 1 Then
                        Exit While
                    End If
                End While

                ypos = (j * ystep + 5)
                sumEispr = sumEispr + male_imerominia_row(bind, grid, startIndex, countIndex, ypos) ' ana praktoreio (firstindex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                startIndex = startIndex + countIndex
                j += 1 'j gia na balw to to sumEispr sto telos stin swsti y-position
            Else '
                ypos = (j * ystep + 5)
                sumEispr = sumEispr + male_imerominia_row(bind, grid, startIndex, countIndex, ypos)
                j += 1
                Exit Do
            End If
        Loop
        If sumEispr <> 0 Then
            male_sum_eispr(sumEispr, (j * ystep + 5))
        End If
    End Sub
    'edw kanw malen kathe mia row (imerominia)
    Private Function male_imerominia_row(ByVal bind As BindingSource, ByVal grid As DataGridView, ByVal startIndex As Int16, ByVal countIndex As Int16, ByVal ypos As Int16) As Single
        Dim j, over, dwm, enil, paid, syn, rr, bb, hb, fb, ai As Int16
        Dim eispr As Single
        Dim ImeromLbl, LabLbl, OverLbl, DwmLbl, EnilLbl, PaidsLbl, SynolLbl, RrLbl, BbLbl, HbLbl, FbLbl, AiLbl, EisprLbl As New Label
        'athroizw ola tis idias imeras
        For j = startIndex To startIndex + countIndex - 1
            over = over + grid.Item(1, j).Value
            dwm = dwm + grid.Item(2, j).Value
            enil = enil + grid.Item(3, j).Value
            paid = paid + grid.Item(4, j).Value
            syn = syn + grid.Item(5, j).Value
            rr = rr + grid.Item(6, j).Value
            bb = bb + grid.Item(7, j).Value
            hb = hb + grid.Item(8, j).Value
            fb = fb + grid.Item(9, j).Value
            ai = ai + grid.Item(10, j).Value
            eispr = eispr + grid.Item(11, j).Value
        Next

        ImeromLbl.Text = grid.Item(0, startIndex).Value
        ImeromLbl.TextAlign = ContentAlignment.MiddleRight
        ImeromLbl.Size = New Point(80, 20)
        ImeromLbl.Location = New Point(locationX(0), ypos)
        'ImeromLbl.BackColor = Color.Azure
        ImeromLbl.ForeColor = Color.Maroon
        LabLbl.Text = "Αναχωρήσεις:"
        LabLbl.TextAlign = ContentAlignment.MiddleRight
        LabLbl.Size = New Point(100, 20)
        LabLbl.Location = New Point(locationX(0) + ImeromLbl.Width, ypos)
        'LabLbl.BackColor = Color.Azure
        LabLbl.ForeColor = Color.Black

        If over <> 0 Then
            OverLbl.Text = over
        End If
        OverLbl.TextAlign = ContentAlignment.MiddleCenter
        OverLbl.Size = New Point(55, 20)
        OverLbl.Location = New Point(locationX(1), ypos)
        OverLbl.BackColor = Color.Azure
        OverLbl.ForeColor = Color.Black
        If dwm <> 0 Then
            DwmLbl.Text = dwm
        End If
        DwmLbl.TextAlign = ContentAlignment.MiddleCenter
        DwmLbl.Size = New Point(55, 20)
        DwmLbl.Location = New Point(locationX(2), ypos)
        DwmLbl.BackColor = Color.Azure
        DwmLbl.ForeColor = Color.Black

        If enil <> 0 Then
            EnilLbl.Text = enil
        End If
        EnilLbl.TextAlign = ContentAlignment.MiddleCenter
        EnilLbl.Size = New Point(55, 20)
        EnilLbl.Location = New Point(locationX(3), ypos)
        EnilLbl.BackColor = Color.Azure
        EnilLbl.ForeColor = Color.Black

        If paid <> 0 Then
            PaidsLbl.Text = paid
        End If
        PaidsLbl.TextAlign = ContentAlignment.MiddleCenter
        PaidsLbl.Size = New Point(55, 20)
        PaidsLbl.Location = New Point(locationX(4), ypos)
        PaidsLbl.BackColor = Color.Azure
        PaidsLbl.ForeColor = Color.Black

        If syn <> 0 Then
            SynolLbl.Text = syn
        End If
        SynolLbl.TextAlign = ContentAlignment.MiddleCenter
        SynolLbl.Size = New Point(55, 20)
        SynolLbl.Location = New Point(locationX(5), ypos)
        SynolLbl.BackColor = Color.Azure
        SynolLbl.ForeColor = Color.Black


        If rr <> 0 Then
            RrLbl.Text = rr
        End If
        RrLbl.TextAlign = ContentAlignment.MiddleCenter
        RrLbl.Size = New Point(55, 20)
        RrLbl.Location = New Point(locationX(6), ypos)
        RrLbl.BackColor = Color.Azure
        RrLbl.ForeColor = Color.Black

        If bb <> 0 Then
            BbLbl.Text = bb
        End If
        BbLbl.TextAlign = ContentAlignment.MiddleCenter
        BbLbl.Size = New Point(55, 20)
        BbLbl.Location = New Point(locationX(7), ypos)
        BbLbl.BackColor = Color.Azure
        BbLbl.ForeColor = Color.Black

        If hb <> 0 Then
            HbLbl.Text = hb
        End If
        HbLbl.TextAlign = ContentAlignment.MiddleCenter
        HbLbl.Size = New Point(55, 20)
        HbLbl.Location = New Point(locationX(8), ypos)
        HbLbl.BackColor = Color.Azure
        HbLbl.ForeColor = Color.Black

        If fb <> 0 Then
            FbLbl.Text = fb
        End If
        FbLbl.TextAlign = ContentAlignment.MiddleCenter
        FbLbl.Size = New Point(55, 20)
        FbLbl.Location = New Point(locationX(9), ypos)
        FbLbl.BackColor = Color.Azure
        FbLbl.ForeColor = Color.Black

        If ai <> 0 Then
            AiLbl.Text = ai
        End If
        AiLbl.TextAlign = ContentAlignment.MiddleCenter
        AiLbl.Size = New Point(55, 20)
        AiLbl.Location = New Point(locationX(10), ypos)
        AiLbl.BackColor = Color.Azure
        AiLbl.ForeColor = Color.Black

        If eispr <> 0 Then
            EisprLbl.Text = eispr.ToString("N")
        End If
        EisprLbl.TextAlign = ContentAlignment.MiddleRight
        EisprLbl.Size = New Point(100, 20)
        EisprLbl.Location = New Point(locationX(11), ypos)
        EisprLbl.BackColor = Color.Azure
        EisprLbl.ForeColor = Color.Black

        Problepsi3Pnl.Controls.Add(ImeromLbl)
        Problepsi3Pnl.Controls.Add(LabLbl)
        Problepsi3Pnl.Controls.Add(OverLbl)
        Problepsi3Pnl.Controls.Add(DwmLbl)
        Problepsi3Pnl.Controls.Add(EnilLbl)
        Problepsi3Pnl.Controls.Add(PaidsLbl)
        Problepsi3Pnl.Controls.Add(SynolLbl)
        Problepsi3Pnl.Controls.Add(RrLbl)
        Problepsi3Pnl.Controls.Add(BbLbl)
        Problepsi3Pnl.Controls.Add(HbLbl)
        Problepsi3Pnl.Controls.Add(FbLbl)
        Problepsi3Pnl.Controls.Add(AiLbl)
        Problepsi3Pnl.Controls.Add(EisprLbl)

        Return eispr ' return to athroisma imeras (gia to sunoliko athroisma meta)
    End Function
    Private Sub male_sum_eispr(ByVal eispr As Single, ByVal ypos As Int16)
        Dim labLbl, EisprLbl As New Label

        labLbl.Text = "συνολικές Εισπράξεις:"
        labLbl.TextAlign = ContentAlignment.MiddleRight
        labLbl.Size = New Point(220, 20)
        labLbl.Location = New Point(locationX(7), ypos)
        'labLbl.BackColor = Color.Azure
        labLbl.ForeColor = Color.Black
        If eispr <> 0 Then
            EisprLbl.Text = eispr.ToString("N")
        End If
        EisprLbl.TextAlign = ContentAlignment.MiddleRight
        EisprLbl.Size = New Point(100, 20)
        EisprLbl.Location = New Point(locationX(11), ypos)
        EisprLbl.BackColor = Color.Azure
        EisprLbl.ForeColor = Color.Maroon

        Problepsi3Pnl.Controls.Add(labLbl)
        Problepsi3Pnl.Controls.Add(EisprLbl)
    End Sub
    'edw ektipwsi status-afixewn-anaxwrisewn
    Private Sub EktiposBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EktiposBtn.Click
        Dim j As Int16
        Dim telos As Date
        Try
            Me.Cursor = Cursors.WaitCursor
            If ProblepsiPck.Value > MexriPck.Value Then
                telos = ProblepsiPck.Value.AddDays(7)
            Else
                telos = MexriPck.Value
            End If

            trexImer = ProblepsiPck.Value.Date

            Me.DbhotelDataSet.ektiposeis_genika.Clear()
            Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
            Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = EkdosiPck.Value.Date


            If StatusRdb.Checked Then ' status tautizetai me atoma maniki

                Me.DbhotelDataSet.ekt_problepsi_status.Clear()

                For j = trexImer.DayOfYear To telos.DayOfYear ' dimiourgia (leere) rows me imerominia moono

                    Me.DbhotelDataSet.ekt_problepsi_status.Rows.Add()
                    Me.DbhotelDataSet.ekt_problepsi_status(Me.DbhotelDataSet.ekt_problepsi_status.Count - 1).imerominia = trexImer.AddDays(j - trexImer.DayOfYear)

                Next

                ekt_status_problepsi(trexImer, telos)
                proepiskopisi_status_report()
            Else 'dwmatia maniki
                'Problepsi3Pnl.Controls.Clear()
                Me.DbhotelDataSet.problepsi_praktoreiou.Clear()
                Me.DbhotelDataSet.kratiseis.Clear()
                Me.DbhotelDataSet.ekt_problepsi_prakt.Clear()

                ekt_prakt_problepsi(trexImer, telos)
            End If

        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Default



    End Sub
    'problepsi gia stastus-afixeis-anaxwriseis->DIAFORA me panw einai oti panw MONO triimero enw edw oxi mono
    Private Sub ekt_status_problepsi(ByVal arxi As Date, ByVal telos As Date)
        Dim j, arKrat As Int16

        arKrat = 0
        'Join anfrage KratiseisXtimeskratiseis(gia xrewsi mono)
        Me.Main_curanteTableAdapter.DailyReportMinaEtosXrewsiOverByAfixAnax(Me.DbhotelDataSet.main_curante, arxi, arxi, telos, telos, arxi, telos)
        'Me.KratiseisTableAdapter.FillJoinKratInZeitInervDailyReportByAfixiAnax(Me.DbhotelDataSet.kratiseis, apo, apo, mexri, mexri, apo, mexri)

        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1
            'If Me.DbhotelDataSet.main_curante(j).arithmos <> arKrat Then
            'einai Join Kratiseis X Timeakratisis->ich unterstuetze mehrere diaforetikes xrewseis ana kratisi!!!!!
            'arKrat = Me.DbhotelDataSet.main_curante(j).arithmos

            If Me.DbhotelDataSet.main_curante(j).apo < arxi And Me.DbhotelDataSet.main_curante(j).mexri > telos Then ' 3 afixeis
                ektiposi_status_werte(arxi, telos, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                If arxi <= telos.AddDays(-1) Then
                    ektiposi_status_werte(arxi, telos.AddDays(-1), j)
                End If
                ektiposi_anaxwrisi_werte(telos, j)

            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then 'NEO

                ektiposi_status_werte(arxi, telos, j)

            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri <> arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                ektiposi_status_werte(arxi, Me.DbhotelDataSet.main_curante(j).mexri.AddDays(-1), j)
                ektiposi_anaxwrisi_werte(Me.DbhotelDataSet.main_curante(j).mexri, j)
                'rechne_werte(1, 1, j) '1.mera- status- kratisiIndex
                'rechne_werte(2, 3, j) '2.mera- mexri- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri <> arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                ektiposi_status_werte(arxi, Me.DbhotelDataSet.main_curante(j).mexri, j)
                'rechne_werte(1, 1, j)
                'rechne_werte(2, 1, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri = arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                ektiposi_anaxwrisi_werte(arxi, j)

                'rechne_werte(1, 3, j) '1.mera- mexri- kratisiIndex
            ElseIf Me.DbhotelDataSet.main_curante(j).apo < arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri = arxi And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                ektiposi_status_werte(arxi, arxi, j)
                'rechne_werte(1, 1, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri > telos Then
                ektiposi_afixi_werte(arxi, j)
                ektiposi_status_werte(arxi.AddDays(1), telos, j)
                'rechne_werte(1, 2, j) '1.mera- apo- kratisiIndex
                'rechne_werte(2, 1, j) '2.mera- status- kratisiIndex
                'rechne_werte(3, 1, j) '3.mera- status- kratisiIndex
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri > telos Then

                ektiposi_status_werte(arxi, telos, j)
                'rechne_werte(1, 1, j)
                'rechne_werte(2, 1, j)
                'rechne_werte(3, 1, j)
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                ektiposi_afixi_werte(arxi, j)
                ektiposi_status_werte(arxi.AddDays(1), telos.AddDays(-1), j)
                ektiposi_anaxwrisi_werte(telos, j)
                'rechne_werte(1, 2, j) '1.mera- apo- kratisiIndex
                'rechne_werte(2, 1, j) '2.mera- status- kratisiIndex
                'rechne_werte(3, 3, j) '3.mera- mexri- kratisiIndex
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                ektiposi_status_werte(arxi, telos.AddDays(-1), j)
                ektiposi_anaxwrisi_werte(telos, j)
                'rechne_werte(1, 1, j)
                'rechne_werte(2, 1, j)
                'rechne_werte(3, 3, j) '
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi _
            And Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                ektiposi_afixi_werte(arxi, j)
                ektiposi_status_werte(arxi.AddDays(1), telos, j)
                'rechne_werte(1, 2, j)
                'rechne_werte(2, 1, j)
                'rechne_werte(3, 1, j)
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                ektiposi_status_werte(arxi, telos, j)
                'rechne_werte(1, 1, j)
                'rechne_werte(2, 1, j)
                'rechne_werte(3, 1, j)
                'ok

            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                ektiposi_afixi_werte(arxi, j)
                If arxi.AddDays(1) <> Me.DbhotelDataSet.main_curante(j).mexri Then
                    ektiposi_status_werte(arxi.AddDays(1), Me.DbhotelDataSet.main_curante(j).mexri.AddDays(-1), j)
                End If
                ektiposi_anaxwrisi_werte(Me.DbhotelDataSet.main_curante(j).mexri, j)

                'rechne_werte(1, 2, j) '1.mera- apo- kratisiIndex
                'rechne_werte(2, 3, j) '2.mera- mexri- kratisiIndex
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).mexri Then
                ektiposi_afixi_werte(arxi, j)
                ektiposi_status_werte(arxi.AddDays(1), Me.DbhotelDataSet.main_curante(j).mexri, j)
                'rechne_werte(1, 2, j) '1.mera- apo- kratisiIndex
                'rechne_werte(2, 1, j) '2.mera- mexri- kratisiIndex
                'ok
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).mexri Then
                ektiposi_afixi_werte(arxi, j)
                'rechne_werte(1, 2, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).mexri Then
                ektiposi_status_werte(arxi, Me.DbhotelDataSet.main_curante(j).mexri.AddDays(1), j)
                ektiposi_anaxwrisi_werte(Me.DbhotelDataSet.main_curante(j).mexri, j)
                'rechne_werte(1, 1, j)
                'rechne_werte(2, 3, j)

            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).mexri Then
                ektiposi_status_werte(arxi, Me.DbhotelDataSet.main_curante(j).mexri, j)
                'rechne_werte(1, 1, j) '1.mera- apo- kratisiIndex
                'rechne_werte(2, 1, j) '2.mera- mexri- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo = arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).mexri Then
                ektiposi_status_werte(arxi, arxi, j)
                'rechne_werte(1, 1, j)

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri > telos Then
                ektiposi_afixi_werte(Me.DbhotelDataSet.main_curante(j).apo, j)
                ektiposi_status_werte(Me.DbhotelDataSet.main_curante(j).apo.AddDays(1), telos, j)
                'rechne_werte(2, 2, j) '2.mera- apo- kratisiIndex
                'rechne_werte(3, 1, j) '3.mera- status- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                ektiposi_afixi_werte(Me.DbhotelDataSet.main_curante(j).apo, j)
                ektiposi_status_werte(Me.DbhotelDataSet.main_curante(j).apo.AddDays(1), telos, j)
                'rechne_werte(2, 2, j) '2.mera- apo- kratisiIndex
                'rechne_werte(3, 1, j) '3.mera- status- kratisiIndex


            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
           Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                ektiposi_afixi_werte(Me.DbhotelDataSet.main_curante(j).apo, j)
                If Me.DbhotelDataSet.main_curante(j).apo.AddDays(1) <> Me.DbhotelDataSet.main_curante(j).mexri Then
                    ektiposi_status_werte(Me.DbhotelDataSet.main_curante(j).apo.AddDays(1), telos.AddDays(1), j)
                End If
                ektiposi_anaxwrisi_werte(telos, j)
                'rechne_werte(2, 2, j)
                'rechne_werte(3, 3, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
           Me.DbhotelDataSet.main_curante(j).apo < telos And _
           Me.DbhotelDataSet.main_curante(j).mexri > telos Then
                ektiposi_status_werte(Me.DbhotelDataSet.main_curante(j).apo, telos, j)

                'rechne_werte(2, 1, j) '2.mera- apo- kratisiIndex
                'rechne_werte(3, 1, j) '3.mera- status- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                ektiposi_status_werte(Me.DbhotelDataSet.main_curante(j).apo, telos.AddDays(-1), j)
                ektiposi_anaxwrisi_werte(telos, j)
                'rechne_werte(2, 1, j) '2.mera- apo- kratisiIndex
                'rechne_werte(3, 3, j) '3.mera- status- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                ektiposi_status_werte(Me.DbhotelDataSet.main_curante(j).apo, telos, j)

                'rechne_werte(2, 1, j) '2.mera- apo- kratisiIndex
                'rechne_werte(3, 1, j) '3.mera- status- kratisiIndex

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                ektiposi_status_werte(Me.DbhotelDataSet.main_curante(j).apo, Me.DbhotelDataSet.main_curante(j).mexri, j)
                'rechne_werte(2, 1, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                ektiposi_status_werte(Me.DbhotelDataSet.main_curante(j).apo, Me.DbhotelDataSet.main_curante(j).mexri.AddDays(-1), j)
                ektiposi_anaxwrisi_werte(Me.DbhotelDataSet.main_curante(j).mexri, j)

            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
            Me.DbhotelDataSet.main_curante(j).apo < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri < telos And _
            Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                ektiposi_afixi_werte(Me.DbhotelDataSet.main_curante(j).apo, j)
                ektiposi_status_werte(Me.DbhotelDataSet.main_curante(j).apo.AddDays(1), Me.DbhotelDataSet.main_curante(j).mexri, j)
                'rechne_werte(2, 2, j)
            ElseIf Me.DbhotelDataSet.main_curante(j).apo > arxi And _
           Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi And _
           Me.DbhotelDataSet.main_curante(j).apo < telos And _
           Me.DbhotelDataSet.main_curante(j).mexri < telos And _
           Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then

                ektiposi_afixi_werte(Me.DbhotelDataSet.main_curante(j).apo, j)
                If Me.DbhotelDataSet.main_curante(j).apo.AddDays(1) <> Me.DbhotelDataSet.main_curante(j).mexri Then
                    ektiposi_status_werte(Me.DbhotelDataSet.main_curante(j).apo.AddDays(1), Me.DbhotelDataSet.main_curante(j).mexri.AddDays(-1), j)
                End If
                ektiposi_anaxwrisi_werte(Me.DbhotelDataSet.main_curante(j).mexri, j)


            ElseIf Me.DbhotelDataSet.main_curante(j).apo = telos And _
            Me.DbhotelDataSet.main_curante(j).apo = Me.DbhotelDataSet.main_curante(j).afixi Then
                ektiposi_afixi_werte(telos, j)
                'rechne_werte(3, 2, j) '

            ElseIf Me.DbhotelDataSet.main_curante(j).apo = telos And _
            Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi Then
                ektiposi_status_werte(telos, telos, j)
                'rechne_werte(3, 3, j) '3.mera- apo- kratisiIndex
                'ElseIf Me.DbhotelDataSet.main_curante(j).apo = telos And _
                '      Me.DbhotelDataSet.main_curante(j).apo <> Me.DbhotelDataSet.main_curante(j).afixi And _
                '      Me.DbhotelDataSet.main_curante(j).mexri > telos Then
                '    rechne_werte(3, 1, j) '3.
                'Else
                '    MsgBox(Me.DbhotelDataSet.main_curante(j).apo)
                '    MsgBox(Me.DbhotelDataSet.main_curante(j).mexri)

            End If

            'End If

        Next

        'For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1
        '    If Me.DbhotelDataSet.kratiseis(j).arithmos <> arKrat Then
        '        'einai Join Kratiseis X Timeakratisis->ean  se mia kratisi, die ueber mehrere TouristPeriodoi hinaus geht, wenn
        '        'autoi oi Tourist periodoi (kata lathos) exoun diaforetiki Xrewsi (HB,RR..)apo mia tote to Join anfrage kanei resultieren mehrere 
        '        'rows->atoma dipla kai tripla (jenachdem)->giauto elegxw arithmo kratisis na min epanatlifthei (anfrage einai kata arithmo kratisis sortiert !)
        '        arKrat = Me.DbhotelDataSet.kratiseis(j).arithmos

        '        If Me.DbhotelDataSet.kratiseis(j).afixi < apo And Me.DbhotelDataSet.kratiseis(j).anaxwrisi > mexri Then
        '            ektiposi_status_werte(apo, mexri, j)
        '        ElseIf Me.DbhotelDataSet.kratiseis(j).afixi < apo And Me.DbhotelDataSet.kratiseis(j).anaxwrisi = mexri Then
        '            If apo <= mexri.AddDays(-1) Then
        '                ektiposi_status_werte(apo, mexri.AddDays(-1), j)
        '            End If
        '            ektiposi_anaxwrisi_werte(mexri, j)
        '        ElseIf Me.DbhotelDataSet.kratiseis(j).afixi < apo And Me.DbhotelDataSet.kratiseis(j).anaxwrisi > apo And Me.DbhotelDataSet.kratiseis(j).anaxwrisi < mexri Then
        '            If apo <= Me.DbhotelDataSet.kratiseis(j).anaxwrisi.AddDays(-1) Then
        '                ektiposi_status_werte(apo, Me.DbhotelDataSet.kratiseis(j).anaxwrisi.AddDays(-1), j)
        '            End If
        '            ektiposi_anaxwrisi_werte(Me.DbhotelDataSet.kratiseis(j).anaxwrisi, j)
        '        ElseIf Me.DbhotelDataSet.kratiseis(j).afixi < apo And Me.DbhotelDataSet.kratiseis(j).anaxwrisi = apo Then
        '            ektiposi_anaxwrisi_werte(apo, j)
        '        ElseIf Me.DbhotelDataSet.kratiseis(j).afixi = apo And Me.DbhotelDataSet.kratiseis(j).anaxwrisi > mexri Then
        '            ektiposi_afixi_werte(apo, j)
        '            If apo.AddDays(1) <= mexri Then
        '                ektiposi_status_werte(apo.AddDays(1), mexri, j)
        '            End If
        '        ElseIf Me.DbhotelDataSet.kratiseis(j).afixi = apo And Me.DbhotelDataSet.kratiseis(j).anaxwrisi = mexri Then
        '            ektiposi_afixi_werte(apo, j)
        '            If apo.AddDays(1) <= Me.DbhotelDataSet.kratiseis(j).anaxwrisi.AddDays(-1) Then
        '                ektiposi_status_werte(apo.AddDays(1), mexri.AddDays(-1), j)
        '            End If
        '            ektiposi_anaxwrisi_werte(mexri, j)
        '        ElseIf Me.DbhotelDataSet.kratiseis(j).afixi = apo And Me.DbhotelDataSet.kratiseis(j).anaxwrisi < mexri Then
        '            ektiposi_afixi_werte(apo, j)
        '            If apo.AddDays(1) <= Me.DbhotelDataSet.kratiseis(j).anaxwrisi.AddDays(-1) Then
        '                ektiposi_status_werte(apo.AddDays(1), Me.DbhotelDataSet.kratiseis(j).anaxwrisi.AddDays(-1), j)
        '            End If
        '            ektiposi_anaxwrisi_werte(Me.DbhotelDataSet.kratiseis(j).anaxwrisi, j)
        '        ElseIf Me.DbhotelDataSet.kratiseis(j).afixi > apo And Me.DbhotelDataSet.kratiseis(j).afixi < mexri And Me.DbhotelDataSet.kratiseis(j).anaxwrisi > mexri Then
        '            ektiposi_afixi_werte(Me.DbhotelDataSet.kratiseis(j).afixi, j)
        '            If Me.DbhotelDataSet.kratiseis(j).afixi.AddDays(1) <= mexri Then
        '                ektiposi_status_werte(Me.DbhotelDataSet.kratiseis(j).afixi.AddDays(1), mexri, j)
        '            End If
        '        ElseIf Me.DbhotelDataSet.kratiseis(j).afixi > apo And Me.DbhotelDataSet.kratiseis(j).afixi < mexri And Me.DbhotelDataSet.kratiseis(j).anaxwrisi = mexri Then
        '            ektiposi_afixi_werte(Me.DbhotelDataSet.kratiseis(j).afixi, j)
        '            If Me.DbhotelDataSet.kratiseis(j).afixi.AddDays(1) <= Me.DbhotelDataSet.kratiseis(j).anaxwrisi.AddDays(-1) Then
        '                ektiposi_status_werte(Me.DbhotelDataSet.kratiseis(j).afixi.AddDays(1), Me.DbhotelDataSet.kratiseis(j).anaxwrisi.AddDays(-1), j)
        '            End If
        '            ektiposi_anaxwrisi_werte(Me.DbhotelDataSet.kratiseis(j).anaxwrisi, j)
        '        ElseIf Me.DbhotelDataSet.kratiseis(j).afixi > apo And Me.DbhotelDataSet.kratiseis(j).afixi < mexri And Me.DbhotelDataSet.kratiseis(j).anaxwrisi < mexri Then
        '            ektiposi_afixi_werte(Me.DbhotelDataSet.kratiseis(j).afixi, j)
        '            If Me.DbhotelDataSet.kratiseis(j).afixi.AddDays(1) <= Me.DbhotelDataSet.kratiseis(j).anaxwrisi.AddDays(-1) Then
        '                ektiposi_status_werte(Me.DbhotelDataSet.kratiseis(j).afixi.AddDays(1), Me.DbhotelDataSet.kratiseis(j).anaxwrisi.AddDays(-1), j)
        '            End If
        '            ektiposi_anaxwrisi_werte(Me.DbhotelDataSet.kratiseis(j).anaxwrisi, j)
        '        ElseIf Me.DbhotelDataSet.kratiseis(j).afixi = mexri Then
        '            ektiposi_afixi_werte(mexri, j)
        '        End If
        '    End If
        'Next


    End Sub
    'fuellen der dATASET ME STATUS
    Private Sub ektiposi_status_werte(ByVal arxi As Date, ByVal telos As Date, ByVal index As Int16)
        Dim j As Int16

        For j = (arxi.DayOfYear - trexImer.DayOfYear) To (telos.DayOfYear - trexImer.DayOfYear)
            If Me.DbhotelDataSet.main_curante(index).dwmatio.Equals("Ov-Book") Then
                Me.DbhotelDataSet.ekt_problepsi_status(j).over = Me.DbhotelDataSet.ekt_problepsi_status(j).over + 1
            Else
                Me.DbhotelDataSet.ekt_problepsi_status(j).dwm = Me.DbhotelDataSet.ekt_problepsi_status(j).dwm + 1
            End If
            Me.DbhotelDataSet.ekt_problepsi_status(j).enil = Me.DbhotelDataSet.ekt_problepsi_status(j).enil + Me.DbhotelDataSet.main_curante(index).enilikes
            Me.DbhotelDataSet.ekt_problepsi_status(j).paid = Me.DbhotelDataSet.ekt_problepsi_status(j).paid + Me.DbhotelDataSet.main_curante(index).paidia
            Me.DbhotelDataSet.ekt_problepsi_status(j).syn = Me.DbhotelDataSet.ekt_problepsi_status(j).syn + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
            Select Case Me.DbhotelDataSet.main_curante(index).xrewsikwd
                Case 1
                    Me.DbhotelDataSet.ekt_problepsi_status(j).rr = Me.DbhotelDataSet.ekt_problepsi_status(j).rr + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
                Case 2
                    Me.DbhotelDataSet.ekt_problepsi_status(j).bb = Me.DbhotelDataSet.ekt_problepsi_status(j).bb + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
                Case 3
                    Me.DbhotelDataSet.ekt_problepsi_status(j).hb = Me.DbhotelDataSet.ekt_problepsi_status(j).hb + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
                Case 4
                    Me.DbhotelDataSet.ekt_problepsi_status(j).fb = Me.DbhotelDataSet.ekt_problepsi_status(j).fb + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
                Case 6
                    Me.DbhotelDataSet.ekt_problepsi_status(j).ai = Me.DbhotelDataSet.ekt_problepsi_status(j).ai + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
            End Select
        Next

    End Sub
    'fuellen der dATASET ME afixi
    Private Sub ektiposi_afixi_werte(ByVal datum As Date, ByVal index As Int16)
        Dim j As Int16

        j = datum.DayOfYear - trexImer.DayOfYear

        If Me.DbhotelDataSet.main_curante(index).dwmatio.Equals("Ov-Book") Then
            Me.DbhotelDataSet.ekt_problepsi_status(j).over1 = Me.DbhotelDataSet.ekt_problepsi_status(j).over1 + 1
        Else
            Me.DbhotelDataSet.ekt_problepsi_status(j).dwm1 = Me.DbhotelDataSet.ekt_problepsi_status(j).dwm1 + 1
        End If
        Me.DbhotelDataSet.ekt_problepsi_status(j).enil1 = Me.DbhotelDataSet.ekt_problepsi_status(j).enil1 + Me.DbhotelDataSet.main_curante(index).enilikes
        Me.DbhotelDataSet.ekt_problepsi_status(j).paid1 = Me.DbhotelDataSet.ekt_problepsi_status(j).paid1 + Me.DbhotelDataSet.main_curante(index).paidia
        Me.DbhotelDataSet.ekt_problepsi_status(j).syn1 = Me.DbhotelDataSet.ekt_problepsi_status(j).syn1 + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
        Select Case Me.DbhotelDataSet.main_curante(index).xrewsikwd
            Case 1
                Me.DbhotelDataSet.ekt_problepsi_status(j).rr1 = Me.DbhotelDataSet.ekt_problepsi_status(j).rr1 + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
            Case 2
                Me.DbhotelDataSet.ekt_problepsi_status(j).bb1 = Me.DbhotelDataSet.ekt_problepsi_status(j).bb1 + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
            Case 3
                Me.DbhotelDataSet.ekt_problepsi_status(j).hb1 = Me.DbhotelDataSet.ekt_problepsi_status(j).hb1 + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
            Case 4
                Me.DbhotelDataSet.ekt_problepsi_status(j).fb1 = Me.DbhotelDataSet.ekt_problepsi_status(j).fb1 + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
            Case 6
                Me.DbhotelDataSet.ekt_problepsi_status(j).ai1 = Me.DbhotelDataSet.ekt_problepsi_status(j).ai1 + Me.DbhotelDataSet.main_curante(index).enilikes + Me.DbhotelDataSet.main_curante(index).paidia
        End Select
    End Sub
    'fuellen der dATASET ME ANAXWRISI
    Private Sub ektiposi_anaxwrisi_werte(ByVal datum As Date, ByVal index As Int16)
        Dim j As Int16

        j = datum.DayOfYear - trexImer.DayOfYear

        If Me.DbhotelDataSet.main_curante(index).dwmatio.Equals("Ov-Book") Then
            Me.DbhotelDataSet.ekt_problepsi_status(j).over2 = Me.DbhotelDataSet.ekt_problepsi_status(j).over2 - 1
        Else
            Me.DbhotelDataSet.ekt_problepsi_status(j).dwm2 = Me.DbhotelDataSet.ekt_problepsi_status(j).dwm2 - 1
        End If
        Me.DbhotelDataSet.ekt_problepsi_status(j).enil2 = Me.DbhotelDataSet.ekt_problepsi_status(j).enil2 - Me.DbhotelDataSet.main_curante(index).enilikes
        Me.DbhotelDataSet.ekt_problepsi_status(j).paid2 = Me.DbhotelDataSet.ekt_problepsi_status(j).paid2 - Me.DbhotelDataSet.main_curante(index).paidia
        Me.DbhotelDataSet.ekt_problepsi_status(j).syn2 = Me.DbhotelDataSet.ekt_problepsi_status(j).syn2 - Me.DbhotelDataSet.main_curante(index).enilikes - Me.DbhotelDataSet.main_curante(index).paidia
        Select Case Me.DbhotelDataSet.main_curante(index).xrewsikwd
            Case 1
                Me.DbhotelDataSet.ekt_problepsi_status(j).rr2 = Me.DbhotelDataSet.ekt_problepsi_status(j).rr2 - Me.DbhotelDataSet.main_curante(index).enilikes - Me.DbhotelDataSet.main_curante(index).paidia
            Case 2
                Me.DbhotelDataSet.ekt_problepsi_status(j).bb2 = Me.DbhotelDataSet.ekt_problepsi_status(j).bb2 - Me.DbhotelDataSet.main_curante(index).enilikes - Me.DbhotelDataSet.main_curante(index).paidia
            Case 3
                Me.DbhotelDataSet.ekt_problepsi_status(j).hb2 = Me.DbhotelDataSet.ekt_problepsi_status(j).hb2 - Me.DbhotelDataSet.main_curante(index).enilikes - Me.DbhotelDataSet.main_curante(index).paidia
            Case 4
                Me.DbhotelDataSet.ekt_problepsi_status(j).fb2 = Me.DbhotelDataSet.ekt_problepsi_status(j).fb2 - Me.DbhotelDataSet.main_curante(index).enilikes - Me.DbhotelDataSet.main_curante(index).paidia
            Case 6
                Me.DbhotelDataSet.ekt_problepsi_status(j).ai2 = Me.DbhotelDataSet.ekt_problepsi_status(j).ai2 - Me.DbhotelDataSet.main_curante(index).enilikes - Me.DbhotelDataSet.main_curante(index).paidia
        End Select
    End Sub
    Private Sub proepiskopisi_status_report()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New ProblepsiStatus()
        'MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio.Count)

        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.DisplayGroupTree = False

        CrystalReportViewer1.ReportSource = ektiposi
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        CrystalReportViewer1.Visible = False
    End Sub
    ' EDW ektiposi PROBLEPSI ANAXWRHSEWN->idia logiki me panw !!! 
    Private Sub ekt_prakt_problepsi(ByVal arxi As Date, ByVal mexri As Date)
        Dim startindex, stepsindex As Int16

        'Dim grid As New DataGridView
        Dim BindingSource1 As New BindingSource

        If kwdPrakt <> -1 Then
            Me.DbhotelDataSet.ektiposeis_genika(0).perigrafi = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(kwdPrakt)
            Me.KratiseisTableAdapter.FillJoinForProblepsiEktiposiByAnaxMexrPrakt(Me.DbhotelDataSet.kratiseis, arxi, mexri, kwdPrakt)
        Else
            Me.KratiseisTableAdapter.FillJoinForProblepsiEktiposiByAnaxMexri(Me.DbhotelDataSet.kratiseis, arxi, mexri)
        End If
        Do Until startindex > Me.DbhotelDataSet.kratiseis.Count - 1
            stepsindex = 1 'posa eintraege 

            'firstIndex = startIndex
            If startindex < Me.DbhotelDataSet.kratiseis.Count - 1 Then
                'gia kathemia kRatisi
                While Me.DbhotelDataSet.kratiseis(startindex).arithmos = Me.DbhotelDataSet.kratiseis(startindex + stepsindex).arithmos
                    stepsindex += 1
                    If startindex + stepsindex > Me.DbhotelDataSet.kratiseis.Count - 1 Then
                        Exit While
                    End If
                End While
                '->gia tin Anaxwrisi pairnw upospin to teleutaio Tupel tie Kratisis
                mache_ektiposianax_problepsi(startindex + stepsindex - 1)
                startindex = startindex + stepsindex
            Else
                '->gia tin Anaxwrisi pairnw upospin to teleutaio Tupel tie Kratisis
                mache_ektiposianax_problepsi(startindex + stepsindex - 1)

                Exit Do
            End If
        Loop



        'For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1

        '    If arKrat <> Me.DbhotelDataSet.kratiseis(j).arithmos Then
        '        arKrat = Me.DbhotelDataSet.kratiseis(j).arithmos

        '        'If Me.DbhotelDataSet.kratiseis(j).afixi = arxi Then

        '        'End If

        '    End If

        'Next
        BindingSource1.DataSource = Me.DbhotelDataSet.problepsi_praktoreiou
        BindingSource1.Sort = "imerominia ASC"
        grid.DataSource = BindingSource1
        'MsgBox(grid.RowCount)
        ekt_rows(BindingSource1, grid)
        proepiskopisi_praktor_report()
    End Sub
    Private Sub mache_ektiposianax_problepsi(ByVal j As Int16)
        Me.DbhotelDataSet.problepsi_praktoreiou.Rows.Add()
        Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).imerominia = Me.DbhotelDataSet.kratiseis(j).anaxwrisi
        If Me.DbhotelDataSet.kratiseis(j).dwmatio.Equals("Ov-Book") Then
            Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).over = 1
        Else
            Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).dwm = 1
        End If

        Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).enil = Me.DbhotelDataSet.kratiseis(j).enilikes
        Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).paid = Me.DbhotelDataSet.kratiseis(j).paidia
        Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).syn = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
        Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).eispr = Me.DbhotelDataSet.kratiseis(j).synolo
        Select Case Me.DbhotelDataSet.kratiseis(j).praktoreio
            Case 1
                Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).rr = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
            Case 2
                Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).bb = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
            Case 3
                Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).hb = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
            Case 4
                Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).fb = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
            Case 6
                Me.DbhotelDataSet.problepsi_praktoreiou(Me.DbhotelDataSet.problepsi_praktoreiou.Count - 1).ai = Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia
        End Select
    End Sub
    Private Sub ekt_rows(ByVal bind As BindingSource, ByVal grid As DataGridView)
        Dim startIndex, countIndex As Int16

        Do Until startIndex > bind.Count - 1
            countIndex = 1 'posa eintraege 
            If startIndex < bind.Count - 1 Then
                'idia imerominia
                While grid.Item(0, startIndex).Value = grid.Item(0, startIndex + countIndex).Value 'Me.DbhotelDataSet.biblioportas(startIndex).imerominia = Me.DbhotelDataSet.biblioportas(startIndex + countIndex).imerominia 'Me.DbhotelDataSet.biblioportas(startIndex).imerominia < imeromErgasias AndAlso
                    countIndex += 1
                    If startIndex + countIndex > bind.Count - 1 Then
                        Exit While
                    End If
                End While
                ekt_imerominia_row(bind, grid, startIndex, countIndex, grid.Item(0, startIndex).Value) ' ana praktoreio (firstindex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                startIndex = startIndex + countIndex
            Else
                ekt_imerominia_row(bind, grid, startIndex, countIndex, grid.Item(0, startIndex).Value)
                Exit Do
            End If
        Loop
    End Sub
    Private Sub ekt_imerominia_row(ByVal bind As BindingSource, ByVal grid As DataGridView, ByVal startIndex As Int16, ByVal countIndex As Int16, ByVal datum As Date)
        Dim j, over, dwm, enil, paid, syn, rr, bb, hb, fb, ai As Int16
        Dim eispr As Single


        For j = startIndex To startIndex + countIndex - 1
            over = over + grid.Item(1, j).Value
            dwm = dwm + grid.Item(2, j).Value
            enil = enil + grid.Item(3, j).Value
            paid = paid + grid.Item(4, j).Value
            syn = syn + grid.Item(5, j).Value
            rr = rr + grid.Item(6, j).Value
            bb = bb + grid.Item(7, j).Value
            hb = hb + grid.Item(8, j).Value
            fb = fb + grid.Item(9, j).Value
            ai = ai + grid.Item(10, j).Value
            eispr = eispr + grid.Item(11, j).Value
        Next

        If j <> startIndex Then
            Me.DbhotelDataSet.ekt_problepsi_prakt.Rows.Add()
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).imerominia = datum
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).label = "Αναχωρήσεις:"
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).over = over
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).dwm = dwm
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).enil = enil
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).paid = paid
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).syn = syn
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).rr = rr
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).bb = bb
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).hb = hb
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).fb = fb
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).ai = ai
            Me.DbhotelDataSet.ekt_problepsi_prakt(Me.DbhotelDataSet.ekt_problepsi_prakt.Count - 1).eispr = eispr
        End If


    End Sub
    Private Sub proepiskopisi_praktor_report()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New ProblepsiEispraxeis()
        'MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio.Count)

        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.DisplayGroupTree = False

        CrystalReportViewer1.ReportSource = ektiposi
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        CrystalReportViewer1.Visible = False
    End Sub
    Private Function welche_tag_der_woche(ByVal day As Integer) As String
        Select Case day
            Case 0
                Return "Κυριακή"
            Case 1
                Return "Δευτέρα"
            Case 2
                Return "Τρίτη"
            Case 3
                Return "Τετάρτη"
            Case 4
                Return "Πέμπτη"
            Case 5
                Return "Παρασκευή"
            Case 6
                Return "Σάββατο"

        End Select
        Return Nothing
    End Function


    Public Sub New(ByVal imerominia As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        imeromErgasias = imerominia
        ProblepsiPck.MinDate = imeromErgasias
        ProblepsiPck.MaxDate = "31/12/" + imeromErgasias.Year.ToString
        ProblepsiPck.Value = imeromErgasias
        trexImer = ProblepsiPck.Value.Date
        MexriPck.MinDate = imeromErgasias
        MexriPck.MaxDate = "31/12/" + imeromErgasias.Year.ToString
        MexriPck.Value = imeromErgasias.AddDays(7)
        EkdosiPck.MinDate = "1/1/" + imeromErgasias.Year.ToString
        EkdosiPck.MaxDate = "31/12/" + imeromErgasias.Year.ToString
        EkdosiPck.Value = imeromErgasias

        ProblepsiTbx.Enabled = False
        PraktLbl.Enabled = False
        ' Add any initialization after the InitializeComponent() call.
        male_kefalida()
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'ReDim locationX(-1)
    End Sub

    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub

    Private Sub DwmatiaRdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EisprRdb.Click
        NextBtn.Enabled = False
        PreviousBtn.Enabled = False
        ProblepsiTbx.Enabled = True
        PraktLbl.Enabled = True
    End Sub

    Private Sub AtomaRdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusRdb.Click

        NextBtn.Enabled = True
        PreviousBtn.Enabled = True
        ProblepsiTbx.Enabled = False
        PraktLbl.Enabled = False
    End Sub
    Private Sub DwmatiaRdb_clear(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EisprRdb.CheckedChanged
        Problepsi3Pnl.Controls.Clear()
    End Sub






End Class