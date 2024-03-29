Public Class DiamenwntesStoixeia
    Dim etos As Int16
    Dim currentTbx As New TextBox
    Dim kwdikoKratisisDB, kwdEnilDB As Integer
    Dim imeromErgasias As Date '= "25/5/2007"
    Private Sub DiabaTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiabaTbx.TextChanged
        'DateTimePicker2.CustomFormat = " dd/MM/yy  -  H:mm "
    End Sub

    Private Sub DiamStoixBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiamStoixBtn.Click
        Dim kratisiArithm As String
        Dim kwdKratTemp As Integer

        DiamenwnStoix1Pnl.Controls.Clear()

        Try
            If KratisiTbx.Text > 0 Then

                Dim count As Int16
                count = Me.KratiseisTableAdapter.ExistArKratisis(KratisiTbx.Text, etos)
                If count = 1 Then 'yparxei autos o arithmos kRatisis
                    'ANfrage kratiseis pou DEN exoun elthei!!!!!!!!!!!!!!!!!!!!(DEN Eexoun kanei CHECKIN)
                    'Me.KratiseisTableAdapter.FillStatus1ByArithmEtos(Me.DbhotelDataSet.kratiseis, KratisiTbx.Text, etos)
                    Me.KratiseisTableAdapter.FillStatusByArithmEtos(Me.DbhotelDataSet.kratiseis, KratisiTbx.Text, etos, True, False)
                    If Me.DbhotelDataSet.kratiseis.Count <> 0 Then
                        'menei MESA!!!!!!!ι
                        kwdikoKratisisDB = Me.DbhotelDataSet.kratiseis(0).kwd
                        'DiamenwnStoix2Pnl.Enabled = True
                        'KataxBtn.Enabled = True
                    Else 'KOITW EAN EXOYN FYGEI
                        Me.KratiseisTableAdapter.FillStatusByArithmEtos(Me.DbhotelDataSet.kratiseis, KratisiTbx.Text, etos, True, True)
                        If Me.DbhotelDataSet.kratiseis.Count <> 0 Then
                            MsgBox("O Πελάτης έχει φύγει! ", MsgBoxStyle.Information, "winfo\nikEl.")
                        Else
                            MsgBox("Ο Πελάτης δεν έχει έρθει ακόμα ! ", MsgBoxStyle.Information, "winfo\nikEl.")
                        End If
                        init_panel_2()
                        DiamenwnStoix2Pnl.Enabled = False
                        KataxBtn.Enabled = False
                        Exit Sub
                    End If
                Else
                    init_panel_2()
                    DiamenwnStoix2Pnl.Enabled = False
                    KataxBtn.Enabled = False
                    MsgBox("Δεν βρέθηκε κράτηση με αυτόν τον Αριθμό. Δώστε έναν άλλον αριθμό ή επιλέξτε απο λίστα. " & vbCrLf & "(Για επιλογή απο λίστα αφήστε κενό και κάνετε κλίκ στον φακό!)", MsgBoxStyle.Information, "winfo\nikEl.")
                    KratisiTbx.Clear()
                    kwdikoKratisisDB = -1

                    Exit Sub
                End If
            End If

        Catch ex As InvalidCastException
            'oloi oi Diamenwntes (checkiN=true checkout=false)
            Dim form As New KratiseisSucheF(imeromErgasias, True, False, 1)

            form.ShowDialog()
            kwdKratTemp = form.return_kwdiko_kratisis()
            kratisiArithm = form.return_arithmo_kratisis
            form.Dispose()
            If kwdKratTemp <> -1 Then
                kwdikoKratisisDB = kwdKratTemp
                'DiamenwnStoix2Pnl.Enabled = True

                KratisiTbx.Text = kratisiArithm

            Else
                Exit Sub
            End If
        End Try
        init_panel_2()
        DiamenwnStoix2Pnl.Enabled = False
        KataxBtn.Enabled = False
        male_panel_1()

    End Sub
    Private Sub male_panel_1()
        Dim height As Single
        Dim j As Int16
        If kwdikoKratisisDB <> -1 Then
            Me.EnilikesTableAdapter.FillByKratisi(Me.DbhotelDataSet.enilikes, kwdikoKratisisDB)
            For j = 0 To Me.DbhotelDataSet.enilikes.Count - 1
                Dim EnilikasTbx As New TextBox 'Button '
                EnilikasTbx.BackColor = Color.LightYellow
                EnilikasTbx.ForeColor = Color.Blue
                EnilikasTbx.Name = "Enil" + Me.DbhotelDataSet.enilikes(j).kwd.ToString
                EnilikasTbx.Size = New Point(DiamenwnStoix1Pnl.Width - 30, 30)
                EnilikasTbx.TextAlign = HorizontalAlignment.Center
                EnilikasTbx.Location = New Point(5, 10 + j * 2 * EnilikasTbx.Height)
                EnilikasTbx.Text = Me.DbhotelDataSet.enilikes(j).onomateponimo
                EnilikasTbx.ReadOnly = True

                DiamenwnStoix1Pnl.Controls.Add(EnilikasTbx)

                If j = Me.DbhotelDataSet.enilikes.Count - 1 Then
                    height = 10 + j * 2 * EnilikasTbx.Height
                End If
                AddHandler EnilikasTbx.Enter, AddressOf fuelle_felder
            Next
            Dim NeosBtn As New Button

            NeosBtn.BackColor = Color.Azure
            NeosBtn.ForeColor = Color.Maroon
            NeosBtn.Text = "Εισαγωγή Νέου"
            NeosBtn.Size = New Point(140, 30)
            NeosBtn.Cursor = Cursors.Hand
            NeosBtn.Size = New Point(DiamenwnStoix1Pnl.Width - 30, 30)
            'SpeicherButton.Location = New Point(Allotm3Pnl.Width / 2 - 80, locy + ImerLbl.Height + k * (ImerLbl.Height + 10))
            NeosBtn.Location = New Point(5, height + 30) '*20 + j * 2 * 25
            DiamenwnStoix1Pnl.Controls.Add(NeosBtn)
            AddHandler NeosBtn.Click, AddressOf clear_felder_fuer_nea_eisagwgi   'MsgBox
        End If

    End Sub

    Private Sub fuelle_felder(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kwdXora, kwdEtnik As Int16
        Try
            kwdEnilDB = CType(sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4), Integer)
            currentTbx.Name = sender.name
            DiamenwnStoix2Pnl.Enabled = True

            KataxBtn.Enabled = True
        Catch ex As InvalidCastException
            Exit Sub
        End Try
        init_panel_2()
        Me.EnilikesTableAdapter.FillByKwdiko(Me.DbhotelDataSet.enilikes, kwdEnilDB)
        OnomTbx.Text = Me.DbhotelDataSet.enilikes(0).onomateponimo
        Me.PatrTbx.Text = Me.DbhotelDataSet.enilikes(0).patronimo
        Try
            Me.ImerGenisisPck.Value = Me.DbhotelDataSet.enilikes(0).genisi
            Me.DiabatirioPck.Value = Me.DbhotelDataSet.enilikes(0).ekdosi
            Me.EortiPck.Value = Me.DbhotelDataSet.enilikes(0).eorti
            Me.GamosPck.Value = Me.DbhotelDataSet.enilikes(0).gamos
        Catch ex As StrongTypingException

        End Try
        Try
            kwdEtnik = Me.DbhotelDataSet.enilikes(0).ethnikotita
        Catch ex As StrongTypingException
            kwdEtnik = -1
        End Try
        If kwdEtnik = Nothing Then
            Me.EthnikTbx.Text = "<κλίκ για επιλογή>"
        Else
            Me.EthnikTbx.Text = Me.EthnikotitesTableAdapter.GetEthnikotitaByKwd(kwdEtnik)
        End If

        Me.EthnikKwdTbx.Text = kwdEtnik
        Me.DiabaTbx.Text = Me.DbhotelDataSet.enilikes(0).diabatirio

        Me.ToposGenisTbx.Text = Me.DbhotelDataSet.enilikes(0).toposgenisis
        Me.DieuthTbx.Text = Me.DbhotelDataSet.enilikes(0).dieuthinsi
        Try
            kwdXora = Me.DbhotelDataSet.enilikes(0).xora
        Catch ex As StrongTypingException
            kwdXora = -1
        End Try
        If kwdXora = Nothing Then
            Me.XoraTbx.Text = "<κλίκ για επιλογή>"
        Else
            Me.XoraTbx.Text = Me.EthnikotitesTableAdapter.GetSintomeusiByKwd(kwdXora)
        End If

        Me.XoraKwdTbx.Text = kwdXora
        Me.PoliTbx.Text = Me.DbhotelDataSet.enilikes(0).poli
        Me.EppagelmaTbx.Text = Me.DbhotelDataSet.enilikes(0).epaggelma
        Me.TilefTbx.Text = Me.DbhotelDataSet.enilikes(0).tilefono
        Me.ProsfTbx.Text = Me.DbhotelDataSet.enilikes(0).prosfonisi
        Me.SimioseisTbx.Text = Me.DbhotelDataSet.enilikes(0).simiosi

        Me.PalaiosPelatisChk.Checked = Me.DbhotelDataSet.enilikes(0).palaios
        Me.AxiologisiTbx.Text = Me.DbhotelDataSet.enilikes(0).axiologisi
    End Sub
    Private Sub clear_felder_fuer_nea_eisagwgi(ByVal sender As System.Object, ByVal e As System.EventArgs)
        kwdEnilDB = -1
        init_panel_2()
        DiamenwnStoix2Pnl.Enabled = True
        KataxBtn.Enabled = True
        Me.OnomTbx.Focus()
    End Sub
    'Private Sub KratiseisBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Validate()
    '    Me.KratiseisBindingSource.EndEdit()
    '    Me.KratiseisTableAdapter.Update(Me.DbhotelDataSet.kratiseis)

    'End Sub

    Private Sub init_panel_2()
        Me.OnomTbx.Clear()
        Me.PatrTbx.Clear()
        Me.ImerGenisisPck.Value = imeromErgasias
        Me.EthnikTbx.Text = "<κλίκ για επιλογή>"
        Me.EthnikKwdTbx.Text = 0
        Me.DiabaTbx.Clear()
        Me.DiabatirioPck.Value = imeromErgasias
        Me.ToposGenisTbx.Clear()
        Me.DieuthTbx.Clear()
        Me.XoraTbx.Text = "<κλίκ για επιλογή>"
        Me.XoraKwdTbx.Text = 0
        Me.PoliTbx.Clear()
        Me.EppagelmaTbx.Clear()
        Me.TilefTbx.Clear()
        Me.ProsfTbx.Clear()
        Me.SimioseisTbx.Clear()
        Me.EortiPck.Value = "01/01/2000"
        Me.GamosPck.Value = "01/01/2000"
        Me.PalaiosPelatisChk.Checked = False
        Me.AxiologisiTbx.Clear()


    End Sub
    Public Sub New(ByVal imerominia As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.ImerGenisisPck.CustomFormat = " dd/MM/yy "
        Me.DiabatirioPck.CustomFormat = " dd/MM/yy "
        Me.EortiPck.CustomFormat = " dd/MM "
        Me.GamosPck.CustomFormat = " dd/MM "
        kwdikoKratisisDB = -1
        DiamenwnStoix2Pnl.Enabled = False
        KataxBtn.Enabled = False
        kwdEnilDB = -1
        imeromErgasias = imerominia
        etos = imeromErgasias.Year
        'DateTimePicker2.CustomFormat = " dd/MM/yy  -  H:mm "
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DiamenwntesStoixeia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Finalize()
        Me.Dispose()
    End Sub

    Private Sub DiamenwntesStoixeia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.xores' table. You can move, or remove it, as needed.
        'Me.XoresTableAdapter.Fill(Me.DbhotelDataSet.xores)
        ''TODO: This line of code loads data into the 'DbhotelDataSet.ethnikotites' table. You can move, or remove it, as needed.
        'Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)

    End Sub

    Private Sub KataxBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KataxBtn.Click
        Dim find() As Control

        If kwdikoKratisisDB <> -1 Then
            If kwdEnilDB <> -1 Then 'UPDATE
                Try
                    Me.Cursor = Cursors.WaitCursor
                    Me.EnilikesTableAdapter.UpdateEnilika(kwdikoKratisisDB, Me.OnomTbx.Text, Me.PatrTbx.Text, Me.ImerGenisisPck.Value.Date, Me.EthnikKwdTbx.Text, Me.DiabaTbx.Text, _
                                  Me.DiabatirioPck.Value.Date, Me.ToposGenisTbx.Text, Me.DieuthTbx.Text, Me.PoliTbx.Text, Me.XoraKwdTbx.Text, Me.EppagelmaTbx.Text, Me.TilefTbx.Text, Me.ProsfTbx.Text, _
                                  Me.SimioseisTbx.Text, Me.PalaiosPelatisChk.Checked, Me.EortiPck.Value.Date, Me.GamosPck.Value.Date, Me.AxiologisiTbx.Text, kwdEnilDB)
                    find = DiamenwnStoix1Pnl.Controls.Find(currentTbx.Name, False)
                    find(0).Text = OnomTbx.Text
                    Me.Cursor = Cursors.Default
                    MsgBox(" Οι αλλαγές καταχωρήθηκαν επιτυχώς ! ", MsgBoxStyle.Information, "winfo\nikEl.")
                Catch ex As System.Exception
                    Me.Cursor = Cursors.Default
                    System.Windows.Forms.MessageBox.Show(ex.Message)

                End Try
                Me.Cursor = Cursors.Default

            ElseIf Not Me.OnomTbx.Text.Equals("") Then
                'Insert Neo Try
                Try
                    Me.Cursor = Cursors.WaitCursor
                    Me.EnilikesTableAdapter.InsertNeoEnilika(kwdikoKratisisDB, Me.OnomTbx.Text, Me.PatrTbx.Text, Me.ImerGenisisPck.Value.Date, Me.EthnikKwdTbx.Text, Me.DiabaTbx.Text, _
               Me.DiabatirioPck.Value.Date, Me.ToposGenisTbx.Text, Me.DieuthTbx.Text, Me.PoliTbx.Text, Me.XoraKwdTbx.Text, Me.EppagelmaTbx.Text, Me.TilefTbx.Text, Me.ProsfTbx.Text, _
               Me.SimioseisTbx.Text, Me.PalaiosPelatisChk.Checked, Me.EortiPck.Value.Date, Me.GamosPck.Value.Date, Me.AxiologisiTbx.Text)
                    DiamenwnStoix1Pnl.Controls.Clear()
                    male_panel_1()
                    DiamenwnStoix2Pnl.Enabled = False
                    KataxBtn.Enabled = False
                    Me.Cursor = Cursors.Default
                    MsgBox(" Επιτυχής καταχώρηση ! Ελέγξτε τον δηλωμένο αριθμό Ενηλίκων της Κράτησης " & vbCrLf & "(στο μενού <Αλλαγή στοιχείων Διαμενόντων>)", MsgBoxStyle.Information, "winfo\nikEl.")

                Catch ex As System.Exception
                    Me.Cursor = Cursors.Default
                    System.Windows.Forms.MessageBox.Show(ex.Message)
                End Try

            End If
        End If
      
    End Sub
   
    Private Sub EthnikTbx_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EthnikTbx.Click
        Dim EthnForm As New EthnikotitesFrm()
        Dim ethnikKwd As Integer

        EthnForm.StartPosition = FormStartPosition.CenterParent
        EthnForm.ShowDialog()
        ethnikKwd = EthnForm.return_ethnos_kwdikos
        'praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        'EthnKwd1.Clear()
        If ethnikKwd = Nothing Then
            MsgBox("Δεν επιλέχθηκε Εθνικότητα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            If EthnikKwdTbx.Text = 0 Then
                EthnikTbx.Clear()
            End If
            Exit Sub
        Else
            Me.EthnikKwdTbx.Text = ethnikKwd
            Me.EthnikTbx.Text = Me.EthnikotitesTableAdapter.GetEthnikotitaByKwd(ethnikKwd)
        End If
        ' edw kanw herauskriegen ola ta simbolaia tou praktoreiou gia to etos

        EthnForm.Dispose()

    End Sub

    Private Sub XoraTbx_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XoraTbx.Click
        Dim XoresForm As New XoresFrm()
        Dim xoraKwd As Integer

        XoresForm.StartPosition = FormStartPosition.CenterParent
        XoresForm.ShowDialog()
        xoraKwd = XoresForm.return_xora_kwdikos
        'praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        'EthnKwd1.Clear()
        If xoraKwd = Nothing Then
            XoraKwdTbx.Text = 0
            XoraTbx.Clear()
            Exit Sub
        Else
            Me.XoraKwdTbx.Text = xoraKwd
            Me.XoraTbx.Text = Me.XoresTableAdapter.GetXoraByKwd(xoraKwd)
        End If
        ' edw kanw herauskriegen ola ta simbolaia tou praktoreiou gia to etos

        XoresForm.Dispose()
    End Sub

    Private Sub ClearBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBtn.Click
        Dim count As Int16

        If kwdikoKratisisDB <> -1 Then

            If kwdEnilDB <> -1 Then
                'koitazw posoi enilikes einai doilwmenoi stin kratisi kai posoi einai oi pragmatikoi (->sto Enilikes table) 
                'anzEnil1 = Me.KratiseisTableAdapter.GetAnzahlEnilikwnByKwd(kwdikoKratisisDB)
                'anzEnil2 = Me.EnilikesTableAdapter.GetAnzahlEnilByKratisi(kwdikoKratisisDB)
                'If anzEnil1 < anzEnil2 Then
                count = Me.EnilikesTableAdapter.DeleteOnoma(kwdEnilDB)
                If count <> 0 Then
                    DiamenwnStoix1Pnl.Controls.Clear()
                    male_panel_1()
                    DiamenwnStoix2Pnl.Enabled = False
                    KataxBtn.Enabled = False
                    'Else
                    MsgBox("Αλλάξτε τον δηλωμένο αριθμό Ενηλίκων της Κράτησης " & vbCrLf & "(στο μενού <Αλλαγή στοιχείων Διαμενόντων>)", MsgBoxStyle.Information, "winfo\nikEl.")
                End If
              
                'End If
            End If
        End If
    End Sub

  
    Private Sub KratisiTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KratisiTbx.Click
        sender.SelectAll()

    End Sub
  

    Private Sub EthnikKwdTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EthnikKwdTbx.Leave, XoraKwdTbx.Leave


        Try
            If CType(sender.text, Int16) > 0 Then

                Try
                    If sender.name.Equals("EthnikKwdTbx") Then
                        EthnikTbx.Text = Me.EthnikotitesTableAdapter.GetEthnikotitaByKwd(CType(sender.text, Int16))
                    Else
                        XoraTbx.Text = Me.XoresTableAdapter.GetXoraByKwd(CType(sender.text, Int16))
                    End If
                Catch ex As Exception
                    MsgBox("O κωδικός δεν αντιστοιχεί σε Εθνικότητα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    sender.text = 0
                    'sender.focus()
                    Exit Sub
                End Try

            Else
                MsgBox("O κωδικός δεν αντιστοιχεί σε Εθνικότητα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                sender.text = 0
                If sender.name.Equals("EthnikKwdTbx") Then
                    Me.EthnikTbx.Text = "<κλίκ για επιλογή>"
                Else
                    Me.XoraTbx.Text = "<κλίκ για επιλογή>"
                End If
                Exit Sub
            End If
        Catch ex As InvalidCastException
            MsgBox(" Δώστε κωδικό Εθνικότητας !", MsgBoxStyle.Information, "winfo\nikEl.")
            sender.text = 0
            If sender.name.Equals("EthnikKwdTbx") Then
                Me.EthnikTbx.Text = "<κλίκ για επιλογή>"
            Else
                Me.XoraTbx.Text = "<κλίκ για επιλογή>"
            End If
        End Try

    End Sub
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
End Class