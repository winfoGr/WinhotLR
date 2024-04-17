
Imports WebConnect
Imports System.Configuration
Imports System.Data.SqlClient
Imports winhotel.EmailSchedulerModule
Imports System.ComponentModel

Public Class MainFrm
    Dim imeromErgasias As Date
    ' Dim rechte(2) As Byte
    Dim rechte As Byte() = New Byte(2) {0, 0, 1}
    Dim kleidi As String
    Const version As String = "100"
    'Dim jroReplica As New JRO.Replica
    'Dim repMaster As New JRO.Replica
    'Dim repClient As New JRO.Replica
    'Dim conn As New ADODB.Connection
    'Dim schedulerThread As Threading.Thread
    Private Sub MainFrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        'If (Environment.MachineName = "DESKTOP-K9QR7KQ") OrElse (Environment.MachineName = "ACER-PC") Then
        '    Try
        '        conn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=z:\winfo\dbhotel.mdb;Mode=12")
        '        repMaster.ActiveConnection = conn
        '        repMaster.Synchronize("c:\winfo\dbhotel.mdb", SyncTypeEnum.jrSyncTypeImpExp, SyncModeEnum.jrSyncModeDirect)

        '        conn.Close()
        '        set_conn_string("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=z:\winfo\dbhotel.mdb", "z:\winfo\dbhotel.mdb", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=z:\winfo\dbhotel.mdb")
        '        Kill("C:\winfo\dbhotel.mdb")
        '    Catch ex As System.Runtime.InteropServices.COMException
        '        conn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\192.168.16.5\katask2\winfo\dbhotel.mdb;Mode=12")
        '        repMaster.ActiveConnection = conn
        '        repMaster.Synchronize("c:\winfo\dbhotel.mdb", SyncTypeEnum.jrSyncTypeImpExp, SyncModeEnum.jrSyncModeDirect)

        '        conn.Close()
        '        set_conn_string("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\192.168.16.5\katask2\winfo\dbhotel.mdb", "z:\winfo\dbhotel.mdb", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=z:\winfo\dbhotel.mdb")
        '        Kill("C:\winfo\dbhotel.mdb")
        '    End Try


        'End If

    End Sub
    Private Sub MainFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim key As String
        'MsgBox(Environment.MachineName)

        'If (Environment.MachineName = "DESKTOP-K9QR7KQ") OrElse (Environment.MachineName = "ACER-PC") Then '"DESKTOP-K9QR7KQ" ACER-PC
        '    Try
        '        conn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=z:\winfo\dbhotel.mdb;Mode=12")

        '    Catch ex As System.Runtime.InteropServices.COMException
        '        conn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\192.168.16.5\katask2\winfo\dbhotel.mdb;Mode=12")
        '        Environment.SetEnvironmentVariable("location", "\\192.168.16.2\Data")
        '    End Try

        '    repMaster.ActiveConnection = conn
        '    '  repMaster.MakeReplicable()
        '    If (Dir("c:\winfo\dbhotel.mdb") <> "") Then
        '        MsgBox("Η ΕΦΑΡΜΟΓΗ ΔΕΝ ΜΠΟΡΕΙ ΝΑ ΞΕΚΙΝΗΣΕΙ ΛΟΓΩ ΠΡΟΒΛΗΜΑΤΟΣ ΣΥΓΧΡΟΝΙΣΜΟΥ ΜΕ MASTER" + vbCrLf + "              ΚΑΝΕΤΕ ΕΠΑΝΕΚΚΙΝΗΣΗ!", MsgBoxStyle.Critical)
        '        conn.Close()
        '        Me.Close()
        '        Return
        '    End If


        '    ' Create a new replica of the database.
        '    Try
        '        repMaster.CreateReplica("c:\winfo\dbhotel.mdb", "dbhotel.mdb", ReplicaTypeEnum.jrRepTypeFull, VisibilityEnum.jrRepVisibilityGlobal, -1, UpdatabilityEnum.jrRepUpdFull)
        '    Catch ex As Exception

        '    End Try

        '    '"dbhotel.mdb", _
        '    '"Replica dbhotel.mdb", _
        '    'ReplicaTypeEnum.jrRepTypeFull, VisibilityEnum.jrRepVisibilityGlobal)
        '    ' New values are put into tab1.
        '    conn.Close()
        '    AppDomain.CurrentDomain.SetData("DataDirectory", "c:\winfo")
        '    set_conn_string("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\winfo\dbhotel.mdb", "c:\winfo\dbhotel.mdb", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\winfo\dbhotel.mdb")
        '    AppDomain.CurrentDomain.SetData("DataDirectory", "c:\winfo")
        'ElseIf IO.File.Exists("z:\winfo\dbhotel.mdb") Then
        '    AppDomain.CurrentDomain.SetData("DataDirectory", "z:\winfo")
        'Else

        '    MsgBox("dbhotel don't exist on z")
        'End If
        'If IO.File.Exists("c:\winfo\dbhotel.mdb") Then
        '    AppDomain.CurrentDomain.SetData("DataDirectory", "c:\winfo")
        'Else

        '    MsgBox("dbhotel don't exist on z")
        'End If
        Try

            '  MsgBox(AppDomain.CurrentDomain.ToString)
            'If IO.File.Exists("z:\winfo\dbhotel.mdb") Then
            '    AppDomain.CurrentDomain.SetData("DataDirectory", "z:\winfo")
            '    'ElseIf IO.File.Exists("\\Domisiserver\katask2\winfo\dbhotel.mdb") Then
            '    '    AppDomain.CurrentDomain.SetData("DataDirectory", "\\Domisiserver\katask2\winfo")
            'ElseIf IO.File.Exists("c:\winfo\dbhotel.mdb") Then
            '    AppDomain.CurrentDomain.SetData("DataDirectory", "c:\winfo")
            'Else
            '    MsgBox("dbhotel don't exist on z, c")
            'End If

            Me.Cursor = Cursors.Default
            '   ReadConnectionStrings()

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
                'MsgBox(Me.DbhotelDataSet.kratiseis.Count)
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



            init_menue()
            'CalendarInternalInit.Main(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString, "2024")

            If (Environment.MachineName.Equals("HP-Winfo", StringComparison.OrdinalIgnoreCase)) OrElse (Environment.MachineName.Equals("DESKTOP-K9QR7KQ", StringComparison.OrdinalIgnoreCase)) Then
                EmailSchedulerModule.Main()
            End If

            'schedulerThread = MailScheduler()



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "winfo/ma.nik")
            Me.Close()
        End Try



    End Sub
    'Function MailScheduler() As Threading.Thread
    '    Dim theThread _
    '        As New Threading.Thread(AddressOf EmailSchedulerModule.Main)
    '    theThread.Start()

    '    Return theThread

    'End Function
    'Private Sub set_conn_string(ByVal connectionString As String, ByVal basi As String, ByVal connstring As String)

    '    Using connection As New OleDb.OleDbConnection(connectionString)
    '        Dim command As New OleDb.OleDbCommand()

    '        connection.Open()
    '        command.Connection = connection
    '        command.Parameters.AddWithValue("basi", basi)
    '        command.Parameters.AddWithValue("connectionstring", connstring)
    '        command.CommandText = "UPDATE etaireia SET basi=? , connectionstring=?"
    '        command.ExecuteNonQuery()
    '        ' Always call Read before accessing data.

    '    End Using

    'End Sub
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
        'If rechte(0) = 1 Then 'aplos user->den exei dikaiwma simfonies, parametroi
        '    MenuStrip1.Items(1).Enabled = False
        '    MenuStrip1.Items(4).Enabled = False
        '    'MenuStrip1.Items(5).in
        'ElseIf rechte(1) = 1 Then 'premium->den exei dikaiwma  parametroi
        '    MenuStrip1.Items(4).Enabled = False
        'End If
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
        Dim form As New ErgasiesHmerasF(imeromErgasias, rechte(2))
        form.Show()
    End Sub
    Private Sub Simfonies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimfoniesStrip.Click
        If rechte(2) = 1 Then
            Dim form As New SimfoniesFrm
            form.Show()
        End If

    End Sub
    Private Sub ParametroiStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParametroiStripMenuItem.Click
        If rechte(2) = 1 Then
            Dim form As New ParametroiF
            form.Show()
        End If

    End Sub
    Private Sub DiamenwntesStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiamenwntesStrip.Click

        Dim form As New DiamenwntesStoixeia(imeromErgasias)
        form.Show()
    End Sub
    Private Sub KleisimoStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KleisimoStripMenuItem.Click
        Try
            Dim form1 As New KleisimoHmeras(imeromErgasias, rechte(2))
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
        If rechte(2) = 1 Then
            Dim form1 As New TelosMinaErgasies(imeromErgasias)

            form1.Show()
        End If


    End Sub

    Private Sub PraktoreiaStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktoreiaStrip.Click
        If rechte(2) = 1 Then
            Dim form1 As New Praktoreia(imeromErgasias)

            form1.Show()
        End If


    End Sub

    Private Sub TelosEtousStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TelosEtousStrip.Click
        If rechte(2) = 1 Then
            Dim form1 As New ErgasiesTelosEtous(imeromErgasias)
            form1.Show()
        End If

    End Sub

    Private Sub SProblpsiKinisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProblpsiKinisiItem.Click
        If rechte(2) = 1 Then
            Dim form1 As New Problepsi(imeromErgasias)
            form1.ShowDialog()
            form1.Dispose()
        End If

    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click

        Dim counter As Int16 = 0
        Try

            For Each foundFile As String In My.Computer.FileSystem.GetFiles(
         Me.DbhotelDataSet.etaireia(0).basi.Substring(0, Me.DbhotelDataSet.etaireia(0).basi.Length - 11),
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
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(
               Me.DbhotelDataSet.etaireia(0).version.Substring(0, Me.DbhotelDataSet.etaireia(0).version.Length - 13),
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
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
                 Me.DbhotelDataSet.etaireia(0).fakelosbackup,
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
                    For Each foundFile As String In My.Computer.FileSystem.GetFiles(
                                         Me.DbhotelDataSet.etaireia(0).fakelosbackup,
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
                        My.Computer.FileSystem.CopyFile(neuerstedatei, Me.DbhotelDataSet.etaireia(0).basi, FileIO.UIOption.AllDialogs,
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
        If rechte(2) = 1 Then
            Dim form1 As New BiblioPortasTheorisi(1)
            form1.ShowDialog()
            form1.Dispose()
        End If

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
                If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis(j).Item("imeromkratisis")) Then

                    Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).enarxi = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).imeromkratisis
                Else
                    Me.DbhotelDataSet.AfixeisAnaxwriseis2(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1).enarxi = Me.DbhotelDataSet.AfixeisAnaxwriseis(j).afixi
                End If

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
        If rechte(2) = 1 Then
            Dim form1 As New katharismata(imeromErgasias, ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString)
            form1.ShowDialog()
            form1.Dispose()
        End If

    End Sub

    Private Sub ΕισπράξειςToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ΕισπράξειςToolStripMenuItem.Click
        If rechte(2) = 1 Then
            Dim form1 As New ProblEisprakseis(imeromErgasias)
            form1.Show()
        End If

    End Sub

    Private Sub SendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToolStripMenuItem.Click
        If rechte(2) = 1 Then
            Dim form1 As New Newsletter()
            form1.Show()
        End If

    End Sub
    Private Sub ΔιαμένοντεςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΔιαμένοντεςToolStripMenuItem.Click
        If rechte(2) = 1 Then
            Dim form1 As New SendMailDiamenontes()
            form1.Show()
        End If

    End Sub
    Private Sub PaymrntNotCompletedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymrntNotCompletedToolStripMenuItem.Click
        Dim j As Int16
        Me.DbhotelDataSet.AfixeisAnaxwriseis2.Clear()
        Dim payadadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseisTableAdapter
        payadadapter.FillDiamenontesPaymentsByCheckinAnax(Me.DbhotelDataSet.AfixeisAnaxwriseis, True, imeromErgasias)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString)
            Dim command As New SqlCommand()
            Dim myReader As SqlDataReader
            Dim apy As Int16
            Dim parastatiko As Integer
            Dim addRowOK As Boolean = False
            connection.Open()
            command.Connection = connection

            For j = 0 To Me.DbhotelDataSet.AfixeisAnaxwriseis.Count - 1
                command.Parameters.AddWithValue("@kwd", Me.DbhotelDataSet.AfixeisAnaxwriseis(j).kwd)
                command.CommandText = "SELECT apy, parastatiko FROM kratiseis where (kwd=@kwd)"
                myReader = command.ExecuteReader(CommandBehavior.SingleRow)
                myReader.Read()
                command.Parameters.Clear()
                Try
                    apy = myReader.Item(0)
                    parastatiko = myReader.Item(1)
                    myReader.Close()
                    If apy <> 0 AndAlso parastatiko <> 0 Then

                        command.Parameters.AddWithValue("@parastatiko", parastatiko)
                        command.Parameters.AddWithValue("@imerominia1", Me.DbhotelDataSet.AfixeisAnaxwriseis(j).afixi)
                        command.Parameters.AddWithValue("@imerominia2", Me.DbhotelDataSet.AfixeisAnaxwriseis(j).anaxwrisi)
                        command.Parameters.AddWithValue("@aa", apy)
                        command.Parameters.AddWithValue("@akyromeno", 0)
                        command.CommandText = "SELECT exoflithi FROM timologia where (parastatiko=@parastatiko) and (imerominia>=@imerominia1) and (imerominia<=@imerominia2) and (aa=@aa) and (akyromeno=@akyromeno)" '   where (aa=?) and (imerominia>=?) and (imerominia<=?) and (parastatiko=?)
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

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click


        'Dim hotel As New SetMainCalendar("https://hotelavailabilities.com/pmsapi")

        'If hotel.send_request() Then
        '    MsgBox("OK!!!!!!!!!!")
        'Else
        '    MsgBox("errorrrrrrr")
        'End If


        '  End If
        'Dim file As String
        'file = "c:\winfo\SetMainCalendar.xls"
        'Dim hotel As New SetMainCalendar("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", file)
        'hotel.make_XML_file_for_request()
        'Dim hotel As New RoomRateTypes(Me.DbhotelDataSet.etaireia(0).connectionstring, "https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502")
        'If hotel.make_XML_request Then
        '    MsgBox("OK!!!!!!!!!!")
        'Else
        '    MsgBox("errorrrrrrr")
        'End If


        'Dim apo As Date = "22/7/2019"
        'Dim mexri As Date = "23/7/2019"
        'Dim hotel As New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", apo, mexri, "1")
        'hotel.set_roomratetype_id("17511")
        'hotel.set_availabilities_operator("minus")
        'If hotel.make_send_XML_file_for_request() Then
        '    MsgBox("OK!!!!!!!!!!")
        'Else
        '    MsgBox("errorrrrrrr")
        'End If


        ' MsgBox(hotel.request)
        'If hotel.make_XML_request Then
        '    MsgBox("OK!!!!!!!!!!")
        'Else
        '    MsgBox("errorrrrrrr")
        'End If

    End Sub
    Private Function get_max_date(ByVal connectionstring As String) As Date
        Dim datum As Date
        Using connection As New OleDb.OleDbConnection(connectionstring)
            Dim command As New OleDb.OleDbCommand()

            connection.Open()
            command.Connection = connection

            Dim myReader As OleDb.OleDbDataReader
            command.CommandText = "select MAX(modified_date) FROM Reservations"
            myReader = command.ExecuteReader(CommandBehavior.SingleResult)
            myReader.Read()
            Try
                datum = myReader.GetDateTime(0)
                Return datum.Date
            Catch ex As InvalidCastException
                myReader.Close()
                command.Parameters.Clear()
                Return "1/6/2019"
            Catch ex1 As InvalidOperationException
                myReader.Close()
                command.Parameters.Clear()
                Return "1/6/2019"
            End Try
            myReader.Close()
            command.Parameters.Clear()
            ' Always call Read before accessing data.

        End Using

    End Function
    Private Sub ImportReservationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportReservationsToolStripMenuItem.Click
        Dim from, body, smtpServer, smtpUsername, smtpPassword, subject As String
        Dim datum As Date = "1/6/2019"
        Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
        DbhotelDataSet.EnforceConstraints = False
        mailadapter.Fill(Me.DbhotelDataSet.Mail)
        from = Me.DbhotelDataSet.Mail(0).ffrom
        subject = "Informations to the Hotel you booked in Crete"
        smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
        smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
        smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
        body = Me.DbhotelDataSet.Mail(2).body
        datum = get_max_date(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString).ToString
        ' datum = "22/12/2019"
        MsgBox("Εισαγωγή Κρατήσεων από " + DateTime.Parse(datum).ToString("dd/MM/yyyy"))
        Dim hotel As New GetReservations(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString, "https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", datum, DateTime.Now.AddDays(+1), "1/6/2019", "31/12/2020")
        hotel.set_email_parameter(from, subject, smtpServer, smtpUsername, smtpPassword, body)
        hotel.request()
        Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
        System.Threading.Thread.CurrentThread.CurrentCulture = greekCulture
    End Sub

    Private Sub SetAvailabilitiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAvailabilitiesToolStripMenuItem.Click



        'Dim hotel As New SetMainCalendar("https://hotelavailabilities.com/pmsapi")

        'If hotel.send_request() Then
        '    MsgBox("OK!!!!!!!!!!")
        'Else
        '    MsgBox("errorrrrrrr")
        'End If
    End Sub

    Private Sub SetPricesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetPricesToolStripMenuItem.Click
        'Dim apo As Date = "22/8/2019"

        'Dim kratDwm() As Int16

        'kratDwm = {4, 1, 1, 1, 1, 1, 4}
        'Dim hotel As New SetAvailabilities("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", apo, kratDwm, 5)
        'hotel.set_roomratetype_id("17517")
        'hotel.make_send_XML_file_for_Availabilities_request()
    End Sub

    Private Sub SetPricesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SetPricesToolStripMenuItem1.Click
        'Dim hotel As New SetPricesCalendar("https://hotelavailabilities.com/pmsapi")

        'If hotel.send_request() Then
        '    MsgBox("OK!!!!!!!!!!")
        'Else
        '    MsgBox("errorrrrrrr")
        'End If
        'Using connection As New OleDb.OleDbConnection(Me.DbhotelDataSet.etaireia(0).connectionstring)

        '    Dim command As New OleDb.OleDbCommand()
        '    Dim transaction As OleDb.OleDbTransaction = Nothing
        '    Try
        '        connection.Open()
        '        transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

        '         Assign transaction object for a pending local transaction.
        '        command.Connection = connection
        '        command.Transaction = transaction




        '        command.Parameters.AddWithValue("afixi", "1/1/1900")
        '        command.Parameters.AddWithValue("anaxwrisii", "1/1/1900")
        '        command.CommandText = "update Reservations INNER JOIN kratiseis ON Reservations.kratisi=kratiseis.kwd set Reservations.afixi=[kratiseis.afixi], Reservations.anaxwrisi=[kratiseis.anaxwrisi]"

        '        command.CommandText = "update Reservations  set afixi=? , anaxwrisi=?"
        '        MsgBox(command.ExecuteNonQuery())
        '        command.Parameters.Clear()




        '        transaction.Commit()

        '    Catch ex As Exception
        '        transaction.Rollback()
        '        MsgBox("H ΑΠΥ δεν πορεί να εκδοθεί !", MsgBoxStyle.Information, "winfo\nikEl.")
        '    End Try
        'End Using
    End Sub


    Private Sub SendSMSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendSMSToolStripMenuItem.Click

        Dim form As New SendWhatsApp
        form.Show()


    End Sub


    Private Sub SynchronizeWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SynchronizeWebToolStripMenuItem.Click
        Dim webcon As New WebConnect.WebConnect
        Dim appSettings = ConfigurationManager.AppSettings


        If webcon.Synchronize(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString, Me.DbhotelDataSet.etaireia(0).aakratisis + 1, appSettings("Individual"), appSettings("Simbolaio"), appSettings("Touristperiod")) Then


            MsgBox("Επιτυχής συγχρονισμός!", MsgBoxStyle.Information, "winfo\nikEl.")

        End If
    End Sub

    Private Sub WebhotelierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebhotelierToolStripMenuItem.Click
        'Dim webhotel As New WebHotelier.RoomRateTypes(Me.DbhotelDataSet.etaireia(0).connectionstring, "https://rest.reserve-online.net/manage/availability/", "WINHOTEST", "922EF87595A93C769FB5B42DF89C13A51DDACE3C", "WINHOTEST")
        'Dim webhotel As New WebHotelier.RoomRateTypes(Me.DbhotelDataSet.etaireia(0).connectionstring, "https://rest.reserve-online.net/manage/rates", "WINHOTEST", "922EF87595A93C769FB5B42DF89C13A51DDACE3C", "WINHOTEST")
        Dim from, body, smtpServer, smtpUsername, smtpPassword, subject As String
        'Dim datum As Date = "1/6/2019"
        Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
        DbhotelDataSet.EnforceConstraints = False
        mailadapter.Fill(Me.DbhotelDataSet.Mail)
        from = Me.DbhotelDataSet.Mail(0).ffrom
        subject = "Informations to the villa you booked in Crete"
        smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
        smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
        smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
        body = Me.DbhotelDataSet.Mail(2).body

        Dim webhotel As New WebHotelier.RoomRateTypes(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString, "https://rest.reserve-online.net/reservation/", "THALASSES", "0845A70BBB0AA9E7C68F08530391D7084DF9A25D", "THALASSES")
        'webhotel.make_JSON_httprequest()
        '    webhotel.manage_rates()
        webhotel.set_email_parameter(from, subject, smtpServer, smtpUsername, smtpPassword, body)
        webhotel.list_pending_bookings()
        'Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
        'System.Threading.Thread.CurrentThread.CurrentCulture = greekCulture
    End Sub

    Private Sub StoreRatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoreRatesToolStripMenuItem.Click
        Dim webhotel As New WebHotelier.RoomRateTypes(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString, "https://rest.reserve-online.net/rate/", "THALASSES", "0845A70BBB0AA9E7C68F08530391D7084DF9A25D", "THALASSES")
        webhotel.store_rates_local()

    End Sub

    Private Sub StopSalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopSalesToolStripMenuItem.Click
        Dim webhotel As New WebHotelier.RoomRateTypes(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString, "https://rest.reserve-online.net/manage/availability", "WINHOTEST", "922EF87595A93C769FB5B42DF89C13A51DDACE3C", "WINHOTEST")
        webhotel.StopSells("MAIL", "1/5/2023", "3/5/2023", True)
    End Sub

    Private Sub GetReservationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetReservationToolStripMenuItem.Click
        Dim userInput As String = InputBox("Enter Reservation ID:", "Input Dialog")
        Dim resid As Long

        ' Check if the user entered a value
        If Not String.IsNullOrEmpty(userInput) AndAlso Long.TryParse(userInput, resid) Then
            ' Process the user input
            Console.WriteLine("Reservation ID: " & resid)
        Else
            ' Handle case when user didn't enter a valid number
            MessageBox.Show("Invalid input or user canceled")
            Console.WriteLine("Invalid input or user canceled.")
            Return
        End If

        Dim webhotel As New WebHotelier.RoomRateTypes(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString, "https://rest.reserve-online.net/reservation/", "THALASSES", "0845A70BBB0AA9E7C68F08530391D7084DF9A25D", "THALASSES")
        webhotel.retrieve_booking(resid)
    End Sub

    Private Sub TemlpateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TemlpateToolStripMenuItem.Click
        If rechte(2) = 1 Then
            Dim form1 As New SendEmailTemplate()
            form1.Show()
        End If

    End Sub


End Class
