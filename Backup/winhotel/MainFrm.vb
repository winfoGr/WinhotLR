'Imports System.Configuration
Public Class MainFrm
    Dim imeromErgasias As Date
    Dim rechte(2) As Byte
    Dim kleidi As String
    Const version As String = "100"


    Private Sub MainFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim key As String
        Try

            'MsgBox(AppDomain.CurrentDomain.ToString)
            If IO.File.Exists("n:\winfo\dbhotel.mdb") Then
                AppDomain.CurrentDomain.SetData("DataDirectory", "n:\winfo")
            ElseIf IO.File.Exists("c:\winfo\dbhotel.mdb") Then
                AppDomain.CurrentDomain.SetData("DataDirectory", "c:\winfo")
            End If


            'ReadConnectionStrings()

            Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
            imeromErgasias = Me.DbhotelDataSet.etaireia(0).imeromergasias
            Try 'kleidi= hex(system_etos * 4_Letzte_Zifern_afm_xwris_midenika)
                kleidi = rechne_key(vier_letzte_zifern_afm_ohne_nullen("099704760"))
            Catch ex As StrongTypingException
                kleidi = Nothing
            End Try
            key = Me.LizensTableAdapter.GetKeyByEtos(System.DateTime.Today.Year) 'System.DateTime.Today.YearimeromErgasias.Year

            If key = Nothing Or kleidi = Nothing Then
                Me.KratiseisTableAdapter.FillByEtos(Me.DbhotelDataSet.kratiseis, System.DateTime.Today.Year) 'System.DateTime.Today.Year'System.DateTime.Today.Year
                If Me.DbhotelDataSet.kratiseis.Count > 30 Then
                    Dim form2 As New KeyFrm(kleidi)
                    Dim flag As Byte
                    form2.ShowDialog()
                    flag = form2.return_flag()
                    If flag = 0 Then
                        MsgBox(" Δεν επιτρέπεται η είσοδος ! ", MsgBoxStyle.Critical, "winfo/ma.nik")
                        Me.Close()
                        Me.Finalize()
                        Me.Dispose()
                        Exit Sub
                    ElseIf flag = 1 Then
                        Try
                            Me.LizensTableAdapter.InsertEtosKleidi(System.DateTime.Today.Year, kleidi.ToUpper) 'System.DateTime.Today.Year
                        Catch ex As OleDb.OleDbException
                            MsgBox(" Διπλότυπο κλειδί ! ", MsgBoxStyle.Critical, "winfo/ma.nik")
                            Me.Close()
                            Me.Finalize()
                            Me.Dispose()
                            Exit Sub
                        End Try

                    End If
                End If
            Else
                If Not key.Equals(kleidi) Then
                    Dim form2 As New KeyFrm(kleidi)
                    Dim flag As Byte
                    form2.ShowDialog()
                    flag = form2.return_flag()
                    If flag = 0 Then
                        MsgBox(" Δεν επιτρέπεται η είσοδος ! ", MsgBoxStyle.Critical, "winfo/ma.nik")
                        Me.Close()
                        Me.Finalize()
                        Me.Dispose()
                        Exit Sub
                    ElseIf flag = 1 Then
                        Me.LizensTableAdapter.UpdateKleidiByEtos(kleidi.ToUpper, System.DateTime.Today.Year)
                    End If

                End If
            End If

            'Dim form1 As New LoginForm
            'form1.ShowDialog()
            'rechte = form1.return_rechte()
            'If Not allow_enter() Then
            '    MsgBox(" Δεν επιτρέπεται η είσοδος ! ", MsgBoxStyle.Critical, "winfo/ma.nik")
            '    Me.Close()
            '    Me.Finalize()
            '    Exit Sub
            'End If

            init_menue()


        Catch ex As OleDb.OleDbException
            MsgBox(" No Data ! ", MsgBoxStyle.Critical, "winfo/ma.nik")
            Me.Close()
        End Try



    End Sub
    Private Function rechne_key(ByVal vierafm As String) As String
        Dim zahl As Int32
        zahl = (System.DateTime.Today.Year) * CType(vierafm, Int32) 'afm.Substring(afm.Length - 4, 4), Int32
        Return Hex(zahl)
    End Function
    '4_Letzte_Zifern_afm_xwris_midenika(->ean to afm exei polla midenika kai den simplirwnontai ta 4 ziffer tote mprosta bazw einsen!) 
    Private Function vier_letzte_zifern_afm_ohne_nullen(ByVal afm As String) As String
        Dim j As Int16
        Dim vierZiff As String = Nothing

        For j = afm.Length - 1 To 0 Step -1

            If CType(afm(j).ToString, Int16) <> 0 Then
                vierZiff = afm(j).ToString + vierZiff
                If vierZiff.Length > 3 Then
                    Return vierZiff
                End If
            End If

        Next
        If vierZiff <> Nothing Then
            While vierZiff.Length <= 3
                vierZiff = "1" + vierZiff
            End While
        Else
            vierZiff = "1111"
        End If

        Return vierZiff
    End Function
    'Private Sub versioning(ByVal versnummer As String)
    '    MsgBox(Application.ProductVersion)
    'End Sub
    Private Sub init_menue()
        If rechte(0) = 1 Then 'aplos user->den exei dikaiwma simfonies, parametroi
            MenuStrip1.Items(1).Enabled = False
            MenuStrip1.Items(4).Enabled = False
            'MenuStrip1.Items(5).in
        ElseIf rechte(1) = 1 Then 'premium->den exei dikaiwma  parametroi
            MenuStrip1.Items(4).Enabled = False
        End If
    End Sub
    Private Sub init_rechte()
        Dim j As Int16

        For j = 0 To rechte.Length - 1
            rechte(j) = 0
        Next
    End Sub
    Private Function allow_enter() As Boolean
        Dim j As Int16

        For j = 0 To rechte.Length - 1
            If rechte(j) <> 0 Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub ErgasiesHmeras(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErgasiesHmerasStrip.Click
        Dim form As New ErgasiesHmerasF(imeromErgasias)

        form.Show()
    End Sub
    Private Sub Simfonies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimfoniesStrip.Click

        Dim form As New SimfoniesFrm

        form.Show()

    End Sub

    Private Sub ParametroiStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParametroiStripMenuItem.Click
        Dim form As New ParametroiF
        form.Show()
    End Sub

    Private Sub DiamenwntesStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiamenwntesStrip.Click
        Dim form As New DiamenwntesStoixeia(imeromErgasias)
        form.Show()
    End Sub

    Private Sub KleisimoStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KleisimoStripMenuItem.Click
        Try
            Dim form1 As New KleisimoHmeras(imeromErgasias)
            form1.ShowDialog()
            imeromErgasias = form1.get_imeromergasias
            'form1.set_imerominia_ergasias()
            'form1.ShowDialog()
            'form1.Dispose()
            'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
            'imeromErgasias = Me.DbhotelDataSet.etaireia(0).imeromergasias
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TelosMinaStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TelosMinaStrip.Click
        Dim form1 As New TelosMinaErgasies(imeromErgasias)

        form1.Show()

    End Sub

    Private Sub PraktoreiaStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktoreiaStrip.Click
        Dim form1 As New Praktoreia(imeromErgasias)

        form1.Show()

    End Sub

    Private Sub TelosEtousStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TelosEtousStrip.Click
        Dim form1 As New ErgasiesTelosEtous(imeromErgasias)
        form1.Show()
    End Sub

    Private Sub SProblpsiKinisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProblpsiKinisiItem.Click

        Dim form1 As New Problepsi(imeromErgasias)
        form1.ShowDialog()
        form1.Dispose()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click


        Dim counter As Int16 = 0
        Try
            For Each foundFile As String In My.Computer.FileSystem.GetFiles( _
           Me.DbhotelDataSet.etaireia(0).basi.Substring(0, Me.DbhotelDataSet.etaireia(0).basi.Length - 11), _
           FileIO.SearchOption.SearchTopLevelOnly, Me.DbhotelDataSet.etaireia(0).basi.Substring(Me.DbhotelDataSet.etaireia(0).basi.Length - 11, 11))
                'MsgBox(My.MySettings.Default.efpaConnectionString.ToString.Remove(0, My.MySettings.Default.efpaConnectionString.ToString.Length - 24))
                'MsgBox(My.Computer.FileSystem.CurrentDirectory)
                counter += 1

                Dim newname As String
                newname = imeromErgasias + Me.DbhotelDataSet.etaireia(0).basi.Substring(Me.DbhotelDataSet.etaireia(0).basi.Length - 11, 11) ' Me.DbhotelDataSet.etaireia(0).basi.Length - 3
                newname = newname.Replace("/", "-")
                'MsgBox(newname)
                Try '
                    'My.Computer.FileSystem.CopyFile(foundFile, Me.EfpaDataSet.parametroi(0).fakelosbackup & newname & ".mdb", FileIO.UIOption.AllDialogs, _
                    '          FileIO.UICancelOption.ThrowException)
                    My.Computer.FileSystem.CopyFile(foundFile, Me.DbhotelDataSet.etaireia(0).fakelosbackup & newname, True) '& Me.DbhotelDataSet.etaireia(0).basi.Substring(Me.DbhotelDataSet.etaireia(0).basi.Length - 4, 4)
                Catch ex As Exception
                    MsgBox(" Η Διαδικασία ακυρώθηκε ", MsgBoxStyle.Information, "winfo/ma.nik")
                    Exit Sub
                End Try
            Next
            For Each foundFile As String In My.Computer.FileSystem.GetFiles( _
               Me.DbhotelDataSet.etaireia(0).version.Substring(0, Me.DbhotelDataSet.etaireia(0).version.Length - 13), _
               FileIO.SearchOption.SearchTopLevelOnly, Me.DbhotelDataSet.etaireia(0).version.Substring(Me.DbhotelDataSet.etaireia(0).version.Length - 13, 13))
                'MsgBox(My.MySettings.Default.efpaConnectionString.ToString.Remove(0, My.MySettings.Default.efpaConnectionString.ToString.Length - 24))
                'MsgBox(My.Computer.FileSystem.CurrentDirectory)
                counter += 1

                Dim newname As String
                newname = imeromErgasias + Me.DbhotelDataSet.etaireia(0).version.Substring(Me.DbhotelDataSet.etaireia(0).version.Length - 13, 13) ' Me.DbhotelDataSet.etaireia(0).basi.Length - 3
                newname = newname.Replace("/", "-")
                'MsgBox(newname)
                Try '
                    'My.Computer.FileSystem.CopyFile(foundFile, Me.EfpaDataSet.parametroi(0).fakelosbackup & newname & ".mdb", FileIO.UIOption.AllDialogs, _
                    '          FileIO.UICancelOption.ThrowException)
                    My.Computer.FileSystem.CopyFile(foundFile, Me.DbhotelDataSet.etaireia(0).fakelosbackup & newname, True) '& Me.DbhotelDataSet.etaireia(0).basi.Substring(Me.DbhotelDataSet.etaireia(0).basi.Length - 4, 4)
                Catch ex As Exception
                    MsgBox(" Η Διαδικασία ακυρώθηκε ", MsgBoxStyle.Information, "winfo/ma.nik")
                    Exit Sub
                End Try
            Next
        Catch ex As System.IO.DirectoryNotFoundException
            MsgBox(" Δεν βρέθηκε το αρχείο ", MsgBoxStyle.Exclamation, "winfo/ma.nik")
            Exit Sub
        End Try

        Dim deleteFile As String
        Dim imerom As Date
        Dim count As Integer = 0
        'MsgBox("*." + Me.DbhotelDataSet.etaireia(0).basi.Substring(Me.DbhotelDataSet.etaireia(0).basi.Length - 4, 4))
        For Each foundFile As String In My.Computer.FileSystem.GetFiles( _
                 Me.DbhotelDataSet.etaireia(0).fakelosbackup, _
                   FileIO.SearchOption.SearchTopLevelOnly, "*" + Me.DbhotelDataSet.etaireia(0).basi.Substring(Me.DbhotelDataSet.etaireia(0).basi.Length - 4, 4))

            deleteFile = foundFile
            foundFile = foundFile.Remove(0, 19)
            foundFile = foundFile.Replace("-", "/")
            foundFile = foundFile.Remove(foundFile.Length - 11, 11)
            Try
                imerom = foundFile

                If imerom.AddDays(30) < Date.Today Then 'AndAlso count > 2 

                    My.Computer.FileSystem.DeleteFile(deleteFile)

                End If
            Catch ex As InvalidCastException

            End Try


        Next
        If counter <> 0 Then
            MsgBox(" Δημιουργήθηκε στον φάκελο " + Me.DbhotelDataSet.etaireia(0).fakelosbackup + " Backup αρχείο των πιο πρόσφατων Δεδομένων με μορφή: 'ΗMερα-MHνας-ΕΤΟΣ.'' !", MsgBoxStyle.Information, "winfo/ma.nik")
        End If



    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        Dim neuerstedatei As String = Nothing
        Dim xfile As String
        Dim imerom As Date
        Dim aktuellste As Date = "1/1/1900"
        Dim response As MsgBoxResult
        'Dim count As Integer = 0

        If rechte(2) = 1 Then ' mono o visor
            MsgBox(" Θα επιχειρηθεί ανάκτηση Δεδομένων :" & vbCrLf & " Η Εφαρμογή θα ανακτήσει αυτόματα τα Δεδομένα μέχρι και το τελευταίο Backup" _
                     & vbCrLf & " Ανατρέξτε στον φάκελο " + Me.DbhotelDataSet.etaireia(0).fakelosbackup + ", αφού πρώτα κλείσετε όλα τα ανοικτά παράθυρα " _
                     & vbCrLf & " της εφαρμογής, για να δείτε την ημερομηνία του τελευταίου Backup ( ΗΜερα-ΜΗνας-ΕΤΟΣ)" _
                     & vbCrLf & " Δεδομένα που δημιουργήθηκαν απο τυχόν μετέπειτα εργασία θα χαθούν για πάντα !", MsgBoxStyle.Exclamation, "winfo/ma.nik")
            response = MsgBox(" Nα αντικατασταθεί το υπάρχον αρχείο Δεδομένων με το πιο πρόσφατο Backup-αρχείο; ", MsgBoxStyle.YesNo, "winfo/ma.nik")

            If response = MsgBoxResult.Yes Then


                Try
                    For Each foundFile As String In My.Computer.FileSystem.GetFiles( _
                                         Me.DbhotelDataSet.etaireia(0).fakelosbackup, _
                                          FileIO.SearchOption.SearchTopLevelOnly, "*" + Me.DbhotelDataSet.etaireia(0).basi.Substring(Me.DbhotelDataSet.etaireia(0).basi.Length - 4, 4))
                        xfile = foundFile

                        xfile = xfile.Remove(0, 19)
                        xfile = xfile.Replace("-", "/")
                        xfile = xfile.Remove(xfile.Length - 11, 11)
                        Try
                            imerom = xfile
                            If imerom > aktuellste Then
                                aktuellste = imerom
                                neuerstedatei = foundFile
                            End If
                        Catch ex As InvalidCastException
                        End Try
                    Next
                    'MsgBox(neuerstedatei)
                    If neuerstedatei <> Nothing Then
                        My.Computer.FileSystem.CopyFile(neuerstedatei, Me.DbhotelDataSet.etaireia(0).basi, FileIO.UIOption.AllDialogs, _
                                              FileIO.UICancelOption.DoNothing)
                        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
                        imeromErgasias = Me.DbhotelDataSet.etaireia(0).imeromergasias
                    Else
                        MsgBox(" Η Διαδικασία απέτυχε: Δεν βρέθηκε συμβατό Backup αρχείο Δεδομένων στον φάκελο " + Me.DbhotelDataSet.etaireia(0).fakelosbackup + " ο οποίος περιέχει τα Αρχεία Backup!", MsgBoxStyle.Critical, "winfo/ma.nik")
                    End If

                Catch ex As Exception 'DirectoryNotFoundException
                    MsgBox(" Δεν βρέθηκε ο φάκελος " + Me.DbhotelDataSet.etaireia(0).fakelosbackup + " ο οποίος περιέχει τα Αρχεία Backup!", MsgBoxStyle.Critical, "winfo/ma.nik")
                End Try
            End If
        Else
            MsgBox(" Δεν έχετε δικαίωμα αυτής της επιλογής ! ", MsgBoxStyle.Exclamation, "winfo/ma.nik")
        End If

    End Sub


    Private Sub BiblPortasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BiblPortasToolStripMenuItem.Click
        Dim form1 As New BiblioPortasTheorisi(1)
        form1.ShowDialog()
        form1.Dispose()
    End Sub



    Private Sub ExitStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitStripMenuItem.Click
        exodos()
    End Sub
    Private Sub exodos()
        Dim response As MsgBoxResult

        response = MsgBox(" Θέλετε να κλείσετε την Εφαρμογή;", MsgBoxStyle.YesNo, "winfo\nikEl.")
        If response = MsgBoxResult.Yes Then
            Me.Close()
            Me.Finalize()
            Me.Dispose()
        End If
    End Sub
    'Private Sub MainFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    exodos()
    'End Sub

    Private Sub SearchOldCustomersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OldCustomersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OldCustomersToolStripMenuItem.Click
        Dim form1 As New SearchForm(imeromErgasias)
        form1.Show()
        'form1.Dispose()
    End Sub

    Private Sub UnconfirmedBookingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnconfirmedBookingsToolStripMenuItem.Click
        Dim j As Int16
        Dim kwdTemp As Integer

        Dim datum As Date
        Dim unconfirmedadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseisTableAdapter
        datum = imeromErgasias.AddDays(-Me.DbhotelDataSet.etaireia(0).timolkwd)

        unconfirmedadapter.FillUnconfirmedKratByChkinImeromkratProk(Me.DbhotelDataSet.AfixeisAnaxwriseis, False, datum, 0)

        Me.DbhotelDataSet.AfixeisAnaxwriseis2.Clear()

        For j = 0 To Me.DbhotelDataSet.AfixeisAnaxwriseis.Count - 1
            If Me.DbhotelDataSet.AfixeisAnaxwriseis(j).kwd <> kwdTemp Then

                kwdTemp = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).kwd

                Me.DbhotelDataSet.AfixeisAnaxwriseis2.Rows.Add()
                Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).enilikes = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).enilikes
                Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).paidia = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).paidia
                If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis(j).Item("onomateponimo")) Then
                    Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).onomateponimo = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).onomateponimo
                End If
                Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).afixi = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).afixi
                Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).anaxwrisi = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).anaxwrisi
                Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).eponimia = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).eponimia
                Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).voucher = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).voucher
                Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).arithmos = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).arithmos
                Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).dwmatio = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).dwmatio
                Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).synolo = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).synolo
                ' Imeromkratisis
                Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).enarxi = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).imeromkratisis
                If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis(j).Item("palaios")) Then
                    Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).checkout = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).palaios
                End If


            End If

        Next
        Dim CrystalReportViewer1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim ektiposi As New NotConfirmed()
        Dim Form1 As New EktiposeisFrm()
        'Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(praktStKwd)
        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'sender.Enabled = False
        Me.DbhotelDataSet.ektiposeis_genika.Clear()
        Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
        Me.DbhotelDataSet.ektiposeis_genika(0).perigrafi = "Not confirmed Bookings"
        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
    End Sub

    Private Sub KatharToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KathToolStripMenuItem.Click
        Dim form1 As New katharismata(imeromErgasias)
        form1.ShowDialog()
        form1.Dispose()
    End Sub

    Private Sub ΕισπράξειςToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ΕισπράξειςToolStripMenuItem.Click
        Dim form1 As New ProblEisprakseis(imeromErgasias)
        form1.Show()
    End Sub

    Private Sub SendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToolStripMenuItem.Click
        Dim form1 As New Newsletter()
        form1.Show()
    End Sub

    Private Sub PaymrntNotCompletedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymrntNotCompletedToolStripMenuItem.Click
        Dim j As Int16
        Me.DbhotelDataSet.AfixeisAnaxwriseis2.Clear()
        Dim payadadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseisTableAdapter
        payadadapter.FillDiamenontesPaymentsByCheckinAnax(Me.DbhotelDataSet.AfixeisAnaxwriseis, True, imeromErgasias)
        Using connection As New OleDb.OleDbConnection(Me.DbhotelDataSet.etaireia(0).connectionstring)
            Dim command As New OleDb.OleDbCommand()
            Dim myReader As OleDb.OleDbDataReader
            Dim apy As Int16
            Dim parastatiko As Integer
            Dim addRowOK As Boolean = False
            connection.Open()
            command.Connection = connection

            For j = 0 To Me.DbhotelDataSet.AfixeisAnaxwriseis.Count - 1
                command.Parameters.AddWithValue("kwd", Me.DbhotelDataSet.AfixeisAnaxwriseis(j).kwd)
                command.CommandText = "SELECT apy, parastatiko FROM kratiseis where (kwd=?)"
                myReader = command.ExecuteReader(CommandBehavior.SingleRow)
                myReader.Read()
                command.Parameters.Clear()
                Try
                    apy = myReader.Item(0)
                    parastatiko = myReader.Item(1)
                    myReader.Close()
                    If apy <> 0 AndAlso parastatiko <> 0 Then

                        command.Parameters.AddWithValue("parastatiko", parastatiko)
                        command.Parameters.AddWithValue("imerominia", Me.DbhotelDataSet.AfixeisAnaxwriseis(j).afixi)
                        command.Parameters.AddWithValue("imerominia", Me.DbhotelDataSet.AfixeisAnaxwriseis(j).anaxwrisi)
                        command.Parameters.AddWithValue("aa", apy)
                        command.Parameters.AddWithValue("akyromeno", False)
                        command.CommandText = "SELECT exoflithi FROM timologia where (parastatiko=?) and (imerominia>=?) and (imerominia<=?) and (aa=?) and (akyromeno=?)" '   where (aa=?) and (imerominia>=?) and (imerominia<=?) and (parastatiko=?)
                        myReader = command.ExecuteReader(CommandBehavior.SingleRow)
                        myReader.Read()
                        Try
                            If (CType(myReader.Item(0), Boolean) = False) Then
                                addRowOK = True
                            End If
                        Catch ex As InvalidOperationException
                            addRowOK = True
                        End Try
                       
                    Else
                        addRowOK = True
                    End If

                    If addRowOK Then
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2.Rows.Add()
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).enilikes = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).enilikes
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).paidia = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).paidia
                        If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis(j).Item("onomateponimo")) Then
                            Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).onomateponimo = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).onomateponimo
                        End If
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).afixi = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).afixi
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).anaxwrisi = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).anaxwrisi
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).eponimia = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).eponimia
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).voucher = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).voucher
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).arithmos = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).arithmos
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).dwmatio = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).dwmatio
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).synolo = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).synolo
                        ' Imeromkratisis
                        Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).enarxi = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).imeromkratisis
                        If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis(j).Item("palaios")) Then
                            Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).checkout = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).palaios
                        End If
                        addRowOK = False
                    End If
                Catch ex As InvalidCastException
                    myReader.Close()
                    command.Parameters.Clear()

                End Try
                command.Parameters.Clear()
                myReader.Close()
            Next

          
            
        End Using
        If Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count <> 0 Then
            Dim CrystalReportViewer1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
            Dim ektiposi As New NotConfirmed()
            Dim Form1 As New EktiposeisFrm()
            'Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(praktStKwd)
            'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
            'sender.Enabled = False
            Me.DbhotelDataSet.ektiposeis_genika.Clear()
            Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
            Me.DbhotelDataSet.ektiposeis_genika(0).perigrafi = "Εκκρεμείς Πληρωμές Διαμένοντων"
            ektiposi.SetDataSource(DbhotelDataSet)
            CrystalReportViewer1.ReportSource = ektiposi
            CrystalReportViewer1.DisplayGroupTree = False
            Form1.Controls.Add(CrystalReportViewer1)
            CrystalReportViewer1.Dock = DockStyle.Fill
            CrystalReportViewer1.Visible = True

            Form1.ShowDialog()

            ektiposi.Close()
            ektiposi.Dispose()
        Else
            MsgBox(" Δεν υπάρχουν εκκρεμότητες με τους Διαμένοντες", MsgBoxStyle.Information)
        End If
        
    End Sub
End Class