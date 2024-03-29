Public Class BiblioPortasFormclass
    Dim connectionString As String
    Dim imeromErgasias As Date
    Dim etos As Int16
    Dim theorimOK, timesOK, eiligOK As Boolean
    Public Sub New(ByVal imerominia As Date, ByVal timOK As Boolean, ByVal theorOK As Boolean, ByVal flag As Byte)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        imeromErgasias = imerominia

        etos = imeromErgasias.Year
        theorimOK = theorOK
        timesOK = timOK
        If flag = 1 Then ' Aufruf apo Kratiseis->eilige ektiposi THEORIMENOU->DEN lambanw upopsin oti den exoun ekdothei apy anaxwrountwn!
            eiligOK = True
        Else 'Aufruf apo kleisimo ->nicht eilige ektiposi->tsekarw ean exoun bgei APY anaxwrountwn
            eiligOK = False
        End If
        ' Add any initialization after the InitializeComponent() call.
        Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
        'TODO: This line of code loads data into the 'DbhotelDataSet.praktoreia' table. You can move, or remove it, as needed.
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
        Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)
    End Sub

    'Private Sub BiblioPortasFormclass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.biblioportas' table. You can move, or remove it, as needed.


    'End Sub
    Public Function biblPortas() As Boolean
        Dim countKrat As Int16
        Dim j As Int16
        Dim kwdTemp As Integer = -1 'kwdikos kratisis gia tsekarisma

        Me.DbhotelDataSet.ekt_dynami.Clear()
        Me.DbhotelDataSet.ekt_dynami1.Clear()
        Me.DbhotelDataSet.ekt_dynami2.Clear()
        Me.DbhotelDataSet.ekt_dynami3.Clear()

        'imeromErgasias = "25/5/2007"
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        connectionString = Me.DbhotelDataSet.etaireia(0).connectionstring
        If Me.DbhotelDataSet.etaireia(0).imeromergasias <> imeromErgasias Then
            MsgBox(" Εχει αλάξει η τρέχουσα Ημερομηνία Εργασίας! " & vbCrLf & "Πρέπει να τήν ελέγξτε στους Παράμετρους Λειτουργίας της Εταιρείας  ", MsgBoxStyle.Critical, "winfo\nikEl.")
            Return False
        End If

        If theorimOK And (eiligOK = False) Then
            countKrat = Me.KratiseisTableAdapter.GetAkopesAnaxwriseisByImerTimologiostatus(imeromErgasias, 0, False)
            If countKrat <> 0 Then
                MsgBox("Υπάρχουν Αναχωρήσεις προς Τιμολόγηση ! " & vbCrLf & "Πρέπει να τις τιμολογήσετε στο Μενού <Εκδοση ΑΠΥ>  ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Exit Function
            End If
            Me.KratiseisTableAdapter.FillAnamenwntesByAfixCheckinTimol(Me.DbhotelDataSet.kratiseis, imeromErgasias, False, 0)
            If Me.DbhotelDataSet.kratiseis.Count <> 0 Then
                MsgBox("Υπάρχουν εκρεμείς Αφίξεις ! " & vbCrLf & "Πρέπει να ελεχθούν στο Μενού <Έλεγχος Αφίξεων>  ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Return False
            End If

        End If

        'edw kanw Join kratiseis,TimesKratiseis gia na kanw herauskriegen pote alazei mia touristiki periodo (gia allagi timwn sto Biblio Portas)
        'ACHTUNG->xrisimopoiw to idi uparxon katastasiAPy apo to dataset, an kai den exei na kanei me APY (gia na min kanw neu tableadapter)
        'Anfrage select me conditions->checkin=true, afixi<>imeromergasias, TIMESKRATISIS.apo=imeroergasias!!!-> gia na piasw ta EIntraege me perisoteres
        'touristikes periodous akribws panw stin alagi periodou (->menei na tsekarw apto biblioportas ean i allagi periodou sunodeuetai kai me allagi timwn)
        Me.KatastasiapyTableAdapter.FillAllagesTimeskratisisBiblioPortas(Me.DbhotelDataSet.katastasiapy, True, imeromErgasias, imeromErgasias, imeromErgasias)
        'edw kratiseis pou feugoun->prepei na exei ekdothei timologio (timologio atibute stis Kratiseis ist auf 1 gesetzt) h na einai GUARANTEE
        'stin Option  proxeiri ektiposi DEN emfanizontai oi atimologites kratiseis pou anaxwroun, stin Option Theorimeni apaiteitai logw tis
        'if-klausel oben na exoun ekdothei ta timologia auta
        Me.KratiseisTableAdapter.FillAnaxwrountesByImerTimolCkeckout(Me.DbhotelDataSet.kratiseis, imeromErgasias, 1, False, imeromErgasias, False, True)


        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim ekptPos, ekptPososto, ekptImeres, ekptCFee As Single
            Dim onoma As String = ""
            Dim enl, anl, atom As Int16
            Dim voucher, altDwm As String
            Dim praktkwd As Integer
            Dim anzethn1, anzethn2 As Byte
            Dim ethnik1, ethnik2 As Int16
            Dim ypnos, prwino, geumata, extras, synolo, ypnosEkpt, geumataEkpt, extrasEkpt As Single
            Dim command As New OleDb.OleDbCommand()
            Dim transaction As OleDb.OleDbTransaction = Nothing
            Dim myReader As OleDb.OleDbDataReader
            Dim paratiriseis As String = ""
            Dim rows As Int16
            Dim lastdatum As Date
            'Dim existschonOK As Boolean
            Try
                'existschonOK = False
                altDwm = ""
                connection.Open()
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)


                ' Assign transaction object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction

                ' edw egrafi sto biblio portas AYTOMATWN allagwn timwn (logw allagis touristikis periodou)
                For j = 0 To Me.DbhotelDataSet.katastasiapy.Count - 1
                    'kanonika kathe kratisi MONO ena Eintrag (simfona me Afrage_>checkin=true, afixi<>imeromergasias, apo=imeroergasias!)
                    If kwdTemp <> Me.DbhotelDataSet.katastasiapy(j).kwd Then 'parolatauta tsekarisma!!
                        kwdTemp = Me.DbhotelDataSet.katastasiapy(j).kwd

                        ' signalisiert ob diadikasia meta apo akyrosi kleisimatos->imerominia ergasias einai progenesteri!!!!!
                        'command.Parameters.AddWithValue("etos", etos)
                        'command.Parameters.AddWithValue("kratisi", kwdTemp)
                        'command.CommandText = "SELECT MAX(imerominia) FROM biblioportas where (etos=?) and (kratisi=?)"
                        'myReader = command.ExecuteReader(CommandBehavior.SingleResult)
                        'myReader.Read()
                        'Try
                        '    maxdatumBP = myReader.Item(0)
                        '    If maxdatumBP >= imeromErgasias Then
                        '        existschonOK = True 'imerominia ergasias einai progenesteri!!!!!->allagi tropou enimerwsis biblioou portas!
                        '        'h uparxei IDI eggrafi apo IDIA mera
                        '    End If
                        'Catch ex As InvalidCastException
                        '    'nichts machen prodatum ist default false gesetzt!
                        'End Try

                        'myReader.Close()
                        'command.Parameters.Clear()
                        'Select prepei na exei imerominia <= imeromergasias gia ton logw oti uparxei periptwsi na uparxoun kai METAGENESTERA
                        'eintraege logw AKYROSIS kleisimatos apo mia metagenesteri imerominia!
                        command.Parameters.AddWithValue("imerominia", imeromErgasias)
                        command.Parameters.AddWithValue("kratisi", kwdTemp)
                        command.CommandText = "SELECT * FROM biblioportas where (imerominia<=?) and (kratisi=?)and (status=1) ORDER BY imerominia DESC, kwd DESC"
                        myReader = command.ExecuteReader(CommandBehavior.SingleRow)
                        myReader.Read()

                        'tsekatisma ean gia opoiondipote logo exei gine IDI i egrafi (xeirokinita sto Biblio portas 'h automata apo
                        'progenesteri epilogi autou tou Button) ->aliws diploegrafi!
                        'If myReader.Item("imerominia") <> imeromErgasias Then

                        If Me.DbhotelDataSet.katastasiapy(j).ypnos <> myReader.Item("ypnos") OrElse Me.DbhotelDataSet.katastasiapy(j).prwino <> myReader.Item("prwino") OrElse _
                        (Me.DbhotelDataSet.katastasiapy(j).geuma + Me.DbhotelDataSet.katastasiapy(j).deipno) <> myReader.Item("geumata") OrElse Me.DbhotelDataSet.katastasiapy(j).extra <> myReader.Item("extras") OrElse _
                        Me.DbhotelDataSet.katastasiapy(j).xrewsikwd <> myReader.Item("xrewsi") Then

                            If myReader.Item("imerominia") = imeromErgasias Then 'uparxei eintrag sto biblio Portas
                                ' uparxei IDI eggrafi apo IDIA mera(Mporei na einai apo progenesteri kataxwrisi apo akyrosi_klismatos)
                                altDwm = myReader.Item("dwmatio") 'to dwmatio tote !!!->giati stis Kratiseis Table anafretai to 'teleutaio' dwmatio
                                lastdatum = imeromErgasias
                                myReader.Close()
                                command.Parameters.AddWithValue("imerominia", imeromErgasias)
                                command.Parameters.AddWithValue("kratisi", kwdTemp)
                                command.CommandText = "DELETE FROM biblioportas where (imerominia=?) and (kratisi=?)"
                                command.ExecuteNonQuery()
                                command.Parameters.Clear()

                                command.Parameters.AddWithValue("imerominia", imeromErgasias)
                                command.Parameters.AddWithValue("kratisi", kwdTemp)
                                command.CommandText = "SELECT * FROM biblioportas where (imerominia<?) and (kratisi=?)and (status=1) ORDER BY imerominia DESC, kwd DESC"
                                myReader = command.ExecuteReader(CommandBehavior.SingleRow)
                                myReader.Read()

                            End If

                            voucher = myReader.Item("voucher")
                            enl = myReader.Item("enilikes")
                            anl = myReader.Item("anilika")
                            atom = myReader.Item("atoma")
                            ypnos = myReader.Item("ypnos")
                            prwino = myReader.Item("prwino")
                            geumata = myReader.Item("geumata")
                            extras = myReader.Item("extras")
                            synolo = myReader.Item("synolo")
                            onoma = myReader.Item("onomateponimo")
                            anzethn1 = myReader.Item("anzethnikotita")
                            ethnik1 = myReader.Item("ethnikotita")
                            anzethn2 = myReader.Item("anzethnikotita2")
                            ethnik2 = myReader.Item("ethnikotita2")
                            praktkwd = myReader.Item("praktoreio")
                            command.Parameters.Clear()
                            '(texniki) anaxwrisi 
                            command.Parameters.AddWithValue("etos", CType(etos, Integer))
                            command.Parameters.AddWithValue("imerominia", CType(imeromErgasias, Date))
                            command.Parameters.AddWithValue("status", CType(2, Byte))
                            command.Parameters.AddWithValue("kratisi", kwdTemp)
                            command.Parameters.AddWithValue("voucher", CType(myReader.Item("voucher"), String))
                            'If myReader.Item("imerominia") < imeromErgasias Then
                            command.Parameters.AddWithValue("dwmatio", CType(myReader.Item("dwmatio"), String)) 'Me.DbhotelDataSet.kratiseis(0).dwmatio
                            'Else
                            '    command.Parameters.AddWithValue("dwmatio", altDwm) 'to dwmatio tote !!!->giati stis Kratiseis Table anafretai to 'teleutaio' dwmatio
                            'End If

                            command.Parameters.AddWithValue("enilikes", CType(myReader.Item("enilikes"), Int16))
                            command.Parameters.AddWithValue("anilika", CType(myReader.Item("anilika"), Int16))
                            command.Parameters.AddWithValue("atoma", CType(myReader.Item("atoma"), Int16))
                            command.Parameters.AddWithValue("xrewsi", CType(myReader.Item("xrewsi"), Integer))
                            command.Parameters.AddWithValue("onomateponimo", CType(myReader.Item("onomateponimo"), String))
                            command.Parameters.AddWithValue("anzethnikotita", CType(myReader.Item("anzethnikotita"), Byte))
                            command.Parameters.AddWithValue("ethnikotita", CType(myReader.Item("ethnikotita"), Int16))
                            command.Parameters.AddWithValue("anzethnikotita2", CType(myReader.Item("anzethnikotita2"), Byte))
                            command.Parameters.AddWithValue("ethnikotita2", CType(myReader.Item("ethnikotita2"), Int16))
                            command.Parameters.AddWithValue("praktoreio", CType(myReader.Item("praktoreio"), Integer))
                            command.Parameters.AddWithValue("ypnos", CType(myReader.Item("ypnos"), Single))
                            command.Parameters.AddWithValue("prwino", CType(myReader.Item("prwino"), Single))
                            command.Parameters.AddWithValue("geumata", CType(myReader.Item("geumata"), Single))
                            command.Parameters.AddWithValue("extras", CType(myReader.Item("extras"), Single))
                            command.Parameters.AddWithValue("synolo", CType(myReader.Item("synolo"), Single))
                            command.Parameters.AddWithValue("datum", CType(myReader.Item("imerominia"), Date)) 'anaxwrisi me imerominia ergasias
                            paratiriseis = "αλλ. Χρέωσης "
                            If Me.DbhotelDataSet.katastasiapy(j).dwmatio.Equals("Ov-Book") Then
                                If Me.DbhotelDataSet.katastasiapy(j).dwmatio.Equals("Ov-Book") Then
                                    paratiriseis = paratiriseis + "Ov-Book "
                                End If
                            End If
                            command.Parameters.AddWithValue("paratiriseis", paratiriseis)

                            'command.Parameters.AddWithValue("flag", flag)
                            command.CommandText = "INSERT INTO biblioportas (etos, imerominia, status, kratisi, voucher, dwmatio, enilikes, anilika, atoma, xrewsi, onomateponimo, anzethnikotita, ethnikotita, anzethnikotita2, ethnikotita2," & _
                            "praktoreio, ypnos, prwino, geumata, extras, synolo, arapy, datum, paratiriseis, flag) values (etos, imerominia, status, kratisi, voucher, dwmatio, enilikes, anilika, atoma," & _
                            "xrewsi, onomateponimo, anzethnikotita, ethnikotita, anzethnikotita2, ethnikotita2,praktoreio, ypnos, prwino, geumata, extras, synolo, 0, datum, paratiriseis, 0)"
                            myReader.Close()
                            command.ExecuteNonQuery()
                            command.Parameters.Clear()


                            'Afixi me nees Times 
                            command.Parameters.AddWithValue("etos", CType(etos, Integer))
                            command.Parameters.AddWithValue("imerominia", imeromErgasias)
                            command.Parameters.AddWithValue("status", CType(1, Byte))
                            command.Parameters.AddWithValue("kratisi", kwdTemp)
                            command.Parameters.AddWithValue("voucher", voucher)

                            If lastdatum = imeromErgasias Then
                                command.Parameters.AddWithValue("dwmatio", altDwm) 'to dwmatio tote !!!->giati stis Kratiseis Table anafretai to 'teleutaio' dwmatio
                            Else
                                command.Parameters.AddWithValue("dwmatio", Me.DbhotelDataSet.katastasiapy(j).dwmatio) 'Me.DbhotelDataSet.kratiseis(0).dwmatio
                            End If
                            command.Parameters.AddWithValue("enilikes", enl)
                            command.Parameters.AddWithValue("anilika", anl)
                            command.Parameters.AddWithValue("atoma", atom)
                            command.Parameters.AddWithValue("xrewsi", Me.DbhotelDataSet.katastasiapy(j).xrewsikwd)
                            command.Parameters.AddWithValue("onomateponimo", onoma)
                            command.Parameters.AddWithValue("anzethnikotita", anzethn1)
                            command.Parameters.AddWithValue("ethnikotita", ethnik1)
                            command.Parameters.AddWithValue("anzethnikotita2", anzethn2)
                            command.Parameters.AddWithValue("ethnikotita2", ethnik2)
                            command.Parameters.AddWithValue("praktoreio", praktkwd)
                            command.Parameters.AddWithValue("ypnos", Me.DbhotelDataSet.katastasiapy(j).ypnos)
                            command.Parameters.AddWithValue("prwino", Me.DbhotelDataSet.katastasiapy(j).prwino)
                            command.Parameters.AddWithValue("geumata", Me.DbhotelDataSet.katastasiapy(j).deipno + Me.DbhotelDataSet.katastasiapy(j).geuma)
                            command.Parameters.AddWithValue("extras", Me.DbhotelDataSet.katastasiapy(j).extra)
                            command.Parameters.AddWithValue("synolo", Me.DbhotelDataSet.katastasiapy(j).ypnos + Me.DbhotelDataSet.katastasiapy(j).prwino + Me.DbhotelDataSet.katastasiapy(j).geuma + Me.DbhotelDataSet.katastasiapy(j).deipno + Me.DbhotelDataSet.katastasiapy(j).extra)
                            command.Parameters.AddWithValue("datum", Me.DbhotelDataSet.katastasiapy(j).anaxwrisi.Date)
                            paratiriseis = "αλλ. Χρέωσης"
                            If Me.DbhotelDataSet.katastasiapy(j).dwmatio.Equals("Ov-Book") Then
                                If Me.DbhotelDataSet.katastasiapy(j).dwmatio.Equals("Ov-Book") Then
                                    paratiriseis = paratiriseis + "Ov-Book "
                                End If
                            End If
                            command.Parameters.AddWithValue("paratiriseis", CType(paratiriseis, String))
                            command.CommandText = "INSERT INTO biblioportas (etos, imerominia, status, kratisi, voucher, dwmatio, enilikes, anilika, atoma, xrewsi, onomateponimo, anzethnikotita, ethnikotita, anzethnikotita2, ethnikotita2," & _
                         "praktoreio, ypnos, prwino, geumata, extras, synolo, datum, paratiriseis, flag) values (etos, imerominia, status, kratisi, voucher, dwmatio, enilikes, anilika, atoma," & _
                         "xrewsi, onomateponimo, anzethnikotita, ethnikotita, anzethnikotita2, ethnikotita2,praktoreio, ypnos, prwino, geumata, extras, synolo, datum, paratiriseis, 0)"
                            command.ExecuteNonQuery()
                            command.Parameters.Clear()
                        Else
                            myReader.Close()
                            command.Parameters.Clear()
                        End If
                        'Else
                        '    myReader.Close()
                        '    command.Parameters.Clear()
                        'End If
                        'apothikeuw tis times tou reader giati meta prepei na kleisw ton reader->tis times autes tis xreiazomai sto 
                        'grapsimo tou bibliou portas 

                    End If
                Next
                'init local variablen 

                'TWRA OI ANAXWROUNTES POU EXEI EKDOTHEI TO TIMOLOGIO APY
                For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1
                    ypnos = 0
                    prwino = 0
                    geumata = 0
                    extras = 0
                    synolo = 0
                    onoma = ""
                    paratiriseis = ""
                    command.Parameters.AddWithValue("imerominia", imeromErgasias)
                    command.Parameters.AddWithValue("kratisi", CType(Me.DbhotelDataSet.kratiseis(j).kwd, Integer))
                    '    command.Parameters.AddWithValue("imerominia", CType(timokatalog(j - 1).apo, Date))
                    command.CommandText = "SELECT * FROM biblioportas where (imerominia<=?) and (kratisi=?)and (status=1) ORDER BY imerominia DESC, kwd DESC"
                    myReader = command.ExecuteReader(CommandBehavior.SingleRow)
                    myReader.Read()
                         'ean exei ginei IDI auti h ergasia ->oxi diploegrafi
                    If myReader.Item("imerominia") <> imeromErgasias Then 'myReader.HasRows AndAlso
                        If Me.DbhotelDataSet.kratiseis(j).ekptosi Then
                            ekptPos = Me.DbhotelDataSet.kratiseis(j).ekptposo
                            ekptPososto = Me.DbhotelDataSet.kratiseis(j).ekptpososto
                            ekptImeres = Me.DbhotelDataSet.kratiseis(j).ekptimeres
                            ekptCFee = Me.DbhotelDataSet.kratiseis(j).fee
                            ypnos = myReader.Item("ypnos")
                            prwino = myReader.Item("prwino")
                            geumata = myReader.Item("geumata")
                            extras = myReader.Item("extras")
                            synolo = myReader.Item("synolo")
                            onoma = myReader.Item("onomateponimo")
                            'paratiriseis = myReader.Item("paratiriseis")
                        End If

                        command.Parameters.Clear()
                        'anxwriseis imeras
                        command.Parameters.AddWithValue("etos", CType(etos, Integer))
                        command.Parameters.AddWithValue("imerominia", CType(imeromErgasias, Date))
                        command.Parameters.AddWithValue("status", CType(2, Byte))
                        command.Parameters.AddWithValue("kratisi", CType(Me.DbhotelDataSet.kratiseis(j).kwd, Integer))
                        'MsgBox(Me.DbhotelDataSet.kratiseis(j).kwd)
                        Try
                            command.Parameters.AddWithValue("voucher", CType(myReader.Item("voucher"), String))
                        Catch ex As InvalidCastException
                            command.Parameters.AddWithValue("voucher", "")
                        End Try
                        command.Parameters.AddWithValue("dwmatio", CType(myReader.Item("dwmatio"), String)) 'Me.DbhotelDataSet.kratiseis(0).dwmatio
                        command.Parameters.AddWithValue("enilikes", CType(myReader.Item("enilikes"), Int16))
                        command.Parameters.AddWithValue("anilika", CType(myReader.Item("anilika"), Int16))
                        command.Parameters.AddWithValue("atoma", CType(myReader.Item("atoma"), Int16))
                        command.Parameters.AddWithValue("xrewsi", CType(myReader.Item("xrewsi"), Integer))
                        command.Parameters.AddWithValue("onomateponimo", CType(myReader.Item("onomateponimo"), String))
                        command.Parameters.AddWithValue("anzethnikotita", CType(myReader.Item("anzethnikotita"), Byte))
                        command.Parameters.AddWithValue("ethnikotita", CType(myReader.Item("ethnikotita"), Int16))
                        command.Parameters.AddWithValue("anzethnikotita2", CType(myReader.Item("anzethnikotita2"), Byte))
                        command.Parameters.AddWithValue("ethnikotita2", CType(myReader.Item("ethnikotita2"), Int16))
                        command.Parameters.AddWithValue("praktoreio", CType(myReader.Item("praktoreio"), Integer))
                        command.Parameters.AddWithValue("ypnos", CType(myReader.Item("ypnos"), Single))
                        command.Parameters.AddWithValue("prwino", CType(myReader.Item("prwino"), Single))
                        command.Parameters.AddWithValue("geumata", CType(myReader.Item("geumata"), Single))
                        command.Parameters.AddWithValue("extras", CType(myReader.Item("extras"), Single))
                        command.Parameters.AddWithValue("synolo", CType(myReader.Item("synolo"), Single))
                        command.Parameters.AddWithValue("arapy", CType(Me.DbhotelDataSet.kratiseis(j).apy, Int16))
                        command.Parameters.AddWithValue("datum", CType(myReader.Item("imerominia"), Date)) 'anaxwrisi me imerominia ergasias
                        If Me.DbhotelDataSet.kratiseis(j).dwmatio.Equals("Ov-Book") OrElse Me.DbhotelDataSet.kratiseis(j).guarantie Then
                            paratiriseis = ""
                            If Me.DbhotelDataSet.kratiseis(j).dwmatio.Equals("Ov-Book") Then
                                paratiriseis = paratiriseis + "Ov-Book "
                            End If
                            If Me.DbhotelDataSet.kratiseis(j).guarantie Then
                                paratiriseis = paratiriseis + "Guarantee "
                            End If
                        End If
                        command.Parameters.AddWithValue("paratiriseis", paratiriseis)
                        'command.Parameters.AddWithValue("paratiriseis", myReader.Item("paratiriseis"))
                        command.Parameters.AddWithValue("parastatiko", Me.DbhotelDataSet.kratiseis(j).parastatiko)
                        command.CommandText = "INSERT INTO biblioportas (etos, imerominia, status, kratisi, voucher, dwmatio, enilikes, anilika, atoma, xrewsi, onomateponimo, anzethnikotita, ethnikotita, anzethnikotita2, ethnikotita2," & _
                        "praktoreio, ypnos, prwino, geumata, extras, synolo, arapy, datum, paratiriseis, flag, parastatiko) values (etos, imerominia, status, kratisi, voucher, dwmatio, enilikes, anilika, atoma," & _
                        "xrewsi, onomateponimo, anzethnikotita, ethnikotita, anzethnikotita2, ethnikotita2,praktoreio, ypnos, prwino, geumata, extras, synolo, arapy, datum, paratiriseis, 0, parastatiko)"
                        myReader.Close()
                        command.ExecuteNonQuery()
                        command.Parameters.Clear()

                        'ean uparxei ekptwsi tote extra Eintrag sto Biblio portas me tin ekptwsi ws poso analogika moirasmeno sta 3 pososta Fpa
                        If Me.DbhotelDataSet.kratiseis(j).ekptosi Then
                            If ekptPos <> 0 Then
                                paratiriseis = "Εκπτωση:" + ChrW(13) + " " + ekptPos.ToString + " €"
                                ekptPos = -ekptPos
                                If (ypnos + prwino + geumata + extras) <> 0 Then
                                    ypnosEkpt = ekptPos * ypnos / (ypnos + prwino + geumata + extras)
                                    geumataEkpt = ekptPos * (prwino + geumata) / (ypnos + prwino + geumata + extras)
                                    extrasEkpt = ekptPos * extras / (ypnos + prwino + geumata + extras)
                                Else
                                    ypnosEkpt = ekptPos
                                End If
                            ElseIf ekptPososto <> 0 Then
                                'upologizw to poso tis ekptwsis apo to pososto kai to synolo tis Kratisis (to opoio SUMPERILAMBANEI tin ekptosi)
                                ekptPos = -(ekptPososto / (100 - ekptPososto) * Me.DbhotelDataSet.kratiseis(j).synolo)
                                If (ypnos + prwino + geumata + extras) <> 0 Then
                                    ypnosEkpt = ekptPos * ypnos / (ypnos + prwino + geumata + extras)
                                    geumataEkpt = ekptPos * (prwino + geumata) / (ypnos + prwino + geumata + extras)
                                    extrasEkpt = ekptPos * extras / (ypnos + prwino + geumata + extras)
                                Else
                                    ypnosEkpt = ekptPos
                                End If
                                paratiriseis = "Εκπτωση:" + ChrW(13) + " " + ekptPososto.ToString + " %"
                            ElseIf ekptImeres <> 0 Then
                                ekptPos = -synolo * ekptImeres
                                If (ypnos + prwino + geumata + extras) <> 0 Then
                                    ypnosEkpt = ekptPos * ypnos / (ypnos + prwino + geumata + extras)
                                    geumataEkpt = ekptPos * (prwino + geumata) / (ypnos + prwino + geumata + extras)
                                    extrasEkpt = ekptPos * extras / (ypnos + prwino + geumata + extras)
                                Else
                                    ypnosEkpt = ekptPos
                                End If
                                paratiriseis = "Εκπτωση:" + ChrW(13) + " " + ekptImeres.ToString + " Ημερ."
                            ElseIf ekptCFee <> 0 Then
                                ekptPos = synolo * ekptCFee
                                If (ypnos + prwino + geumata + extras) <> 0 Then
                                    ypnosEkpt = ekptPos * ypnos / (ypnos + prwino + geumata + extras)
                                    geumataEkpt = ekptPos * (prwino + geumata) / (ypnos + prwino + geumata + extras)
                                    extrasEkpt = ekptPos * extras / (ypnos + prwino + geumata + extras)
                                Else
                                    ypnosEkpt = ekptPos
                                End If
                                paratiriseis = "Cancel. Fee:" + ChrW(13) + " " + ekptCFee.ToString + " Ημερ."
                            End If
                            command.Parameters.AddWithValue("etos", CType(etos, Integer))
                            command.Parameters.AddWithValue("imerominia", CType(imeromErgasias, Date))
                            command.Parameters.AddWithValue("status", 2)
                            command.Parameters.AddWithValue("kratisi", CType(Me.DbhotelDataSet.kratiseis(j).kwd, Integer))
                            command.Parameters.AddWithValue("onomateponimo", onoma)
                            command.Parameters.AddWithValue("ypnos", ypnosEkpt)
                            'command.Parameters.AddWithValue("prwino", CType(myReader.Item("prwino"), Single))
                            command.Parameters.AddWithValue("geumata", geumataEkpt)
                            command.Parameters.AddWithValue("extras", extrasEkpt)
                            command.Parameters.AddWithValue("synolo", ekptPos)
                            command.Parameters.AddWithValue("arapy", CType(Me.DbhotelDataSet.kratiseis(j).apy, Int16))
                            command.Parameters.AddWithValue("paratiriseis", paratiriseis)
                            command.Parameters.AddWithValue("parastatiko", Me.DbhotelDataSet.kratiseis(j).parastatiko)
                            command.CommandText = "INSERT INTO biblioportas (etos, imerominia, status, kratisi, onomateponimo,  ypnos,  geumata, extras, synolo, arapy, paratiriseis, flag, parastatiko) " & _
                            "values (etos, imerominia, status, kratisi, onomateponimo,  ypnos, geumata, extras, synolo, arapy, paratiriseis, 0, parastatiko)"

                            command.ExecuteNonQuery()
                            command.Parameters.Clear()

                        End If

                        '' edw alaksa kai kanw loeschen Ola ta MELLONTIKA eintraege tis kratisis sto biblio portas pou logw mias akyrosis enos kleisimatos mporei na uparxoun
                        'command.Parameters.AddWithValue("imerominia", imeromErgasias)
                        'command.Parameters.AddWithValue("kratisi", kwdTemp)
                        'command.CommandText = "DELETE FROM biblioportas where (imerominia>?) and (kratisi=?)"
                        'command.ExecuteNonQuery()
                        'command.Parameters.Clear()

                        'teleiotiko checkout gia pelati
                        If Me.DbhotelDataSet.kratiseis(j).dwmatio.Equals("Ov-Book") Then
                            command.Parameters.AddWithValue("mexri", imeromErgasias.AddDays(-1))
                            command.Parameters.AddWithValue("kratisi", CType(Me.DbhotelDataSet.kratiseis(j).kwd, Integer))
                            command.CommandText = "UPDATE over SET mexri=?, epistrofiOK=true where kratisi=? and epistrofiOK=false"
                            rows = command.ExecuteNonQuery()
                            command.Parameters.Clear()
                        End If


                        command.Parameters.AddWithValue("kwd", CType(Me.DbhotelDataSet.kratiseis(j).kwd, Integer))
                        command.CommandText = "UPDATE kratiseis SET checkout=true where (kwd=?)"
                        rows = command.ExecuteNonQuery()
                        command.Parameters.Clear()



                        If rows <> 1 Then
                            transaction.Rollback()
                            MsgBox("Η Διαδικασία εκτύπωσης του Βιβλίου πόρτας απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                            Return False
                        End If
                    Else
                        myReader.Close()
                        command.Parameters.Clear()
                    End If
                    ' ekptwseis apothikeuw se local variabelen _>giati to read klinei->  myReader.Close()

                Next

                transaction.Commit()

            Catch ex As Exception
                MsgBox("Η Διαδικασία εκτύπωσης του Βιβλίου πόρτας απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Try
                    transaction.Rollback()
                    Return False
                Catch
                    Return False
                End Try
            End Try
        End Using

        dynami_berechnen()

        Me.DbhotelDataSet.biblioportas.Clear()
        'imeromErgasias = "1/6/2007"
        If theorimOK Then
            Me.BiblioportasTableAdapter.FillBiblioPortasByImeromFlag(Me.DbhotelDataSet.biblioportas, imeromErgasias, 0)
        Else
            Me.BiblioportasTableAdapter.FillBiblioPortasByImerominia(Me.DbhotelDataSet.biblioportas, imeromErgasias)
        End If


        If Me.DbhotelDataSet.biblioportas.Count <> 0 Then
            Me.KratiseisenilikesTableAdapter.FillOnomataBiblioPortasByAfixiAnaxCheckin(Me.DbhotelDataSet.kratiseisenilikes, imeromErgasias, imeromErgasias, True)
            If timesOK Then
                proepiskopisi_biblioportas()
            Else
                proepiskopisi_biblioportas_ohne_times()
            End If

        Else
            Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
            Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = imeromErgasias
            proepiskopisi_biblioportas_keno()
        End If


        'exei epilegei Theorimeni ektiposi->flag wird auf 1 gesetzt, dass signalisiert dass der Eintrag schon in BibliopOrtas theorimeno Xarti
        'gedruckt ist(_>beim nochmal druecken wird nicht erscheinen!)
        If theorimOK Then
            Me.BiblioportasTableAdapter.SetFlagTheorimenisEktiposis(1, imeromErgasias)
            Me.EtaireiaTableAdapter.SetFlagEktiposisBibliouPortas(1, imeromErgasias)
        End If
        Return True
    End Function

    Private Sub dynami_berechnen()
        Dim startIndex, countIndex As Int16
        Dim dwm, enl, paid, atom, rr, bb, hb, fb, ai As Int16
        Dim ypnos, prwina, geumata, extras, synolo As Single


        'sti Berechnung DEN ypologizontao oi Ekptwseis->sta eintraege me tis ekptwseis i Xreswsi (Oroi) einai panta 0 ->
        'query mit xrewsi<>0
        Me.BiblioportasTableAdapter.FillBiblioportasBisEtos2Tag(Me.DbhotelDataSet.biblioportas, etos, imeromErgasias, 0, False, etos, imeromErgasias, 0, imeromErgasias)
        'MsgBox(Me.DbhotelDataSet.biblioportas.Count)
        startIndex = 0
        'PRWTA APO METAFORA BERECHNEN
        'Do Until startIndex > Me.DbhotelDataSet.biblioportas.Count - 1
        Do Until startIndex > Me.DbhotelDataSet.biblioportas.Count - 1 OrElse Me.DbhotelDataSet.biblioportas(startIndex).imerominia = imeromErgasias
            'MsgBox(startIndex)
            countIndex = 1 'posa eintraege 
            If startIndex < Me.DbhotelDataSet.biblioportas.Count - 1 Then
                'eintrage me tin IDia imerominia < tis Imeromergasias
                While Me.DbhotelDataSet.biblioportas(startIndex).imerominia = Me.DbhotelDataSet.biblioportas(startIndex + countIndex).imerominia 'Me.DbhotelDataSet.biblioportas(startIndex).imerominia < imeromErgasias AndAlso
                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet.biblioportas.Count - 1 Then
                        Exit While
                    End If
                End While
                'MsgBox( stepsIndex)
                'sumSumSyn = sumSumSyn + Me.DbhotelDataSet.katastasiapy(firstIndex).synolo
                apo_metafora(startIndex, countIndex, dwm, enl, paid, atom, rr, bb, hb, fb, ai, ypnos, prwina, geumata, extras, synolo) ' ana praktoreio (firstindex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                startIndex = startIndex + countIndex
                'indexPrakt = 0
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'MsgBox(countIndex)
                'sumSumSyn = sumSumSyn + Me.DbhotelDataSet.katastasiapy(firstIndex).synolo
                apo_metafora(startIndex, countIndex, dwm, enl, paid, atom, rr, bb, hb, fb, ai, ypnos, prwina, geumata, extras, synolo)

                Exit Do
            End If
        Loop

        'APO METAFORA HINSCHREIBEN
        Me.DbhotelDataSet.ekt_dynami.Rows.Add()

        Me.DbhotelDataSet.ekt_dynami(0).flag = 1
        Me.DbhotelDataSet.ekt_dynami(0).bezeichn = "Από Μεταφορά"
        Me.DbhotelDataSet.ekt_dynami(0).dwmatia = dwm
        Me.DbhotelDataSet.ekt_dynami(0).enilikes = enl
        Me.DbhotelDataSet.ekt_dynami(0).paidia = paid
        Me.DbhotelDataSet.ekt_dynami(0).atoma = atom
        Me.DbhotelDataSet.ekt_dynami(0).rr = rr
        Me.DbhotelDataSet.ekt_dynami(0).bb = bb
        Me.DbhotelDataSet.ekt_dynami(0).hb = hb
        Me.DbhotelDataSet.ekt_dynami(0).fb = fb
        Me.DbhotelDataSet.ekt_dynami(0).ai = ai
        Me.DbhotelDataSet.ekt_dynami(0).ypnos = ypnos
        Me.DbhotelDataSet.ekt_dynami(0).prwina = prwina
        Me.DbhotelDataSet.ekt_dynami(0).geumata = geumata
        Me.DbhotelDataSet.ekt_dynami(0).extras = extras
        Me.DbhotelDataSet.ekt_dynami(0).synolo = synolo
        'initiasisiern
        dwm = 0
        enl = 0
        paid = 0
        atom = 0
        rr = 0
        bb = 0
        hb = 0
        fb = 0
        ai = 0
        ypnos = 0
        prwina = 0
        geumata = 0
        extras = 0
        synolo = 0


        dynami_afixeis(startIndex, dwm, enl, paid, atom, rr, bb, hb, fb, ai, ypnos, prwina, geumata, extras, synolo) ' ana praktoreio (firstindex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou

        Me.DbhotelDataSet.ekt_dynami1.Rows.Add()

        Me.DbhotelDataSet.ekt_dynami1(0).flag = 2
        Me.DbhotelDataSet.ekt_dynami1(0).bezeichn = "Αφίξεις"
        Me.DbhotelDataSet.ekt_dynami1(0).dwmatia = dwm
        Me.DbhotelDataSet.ekt_dynami1(0).enilikes = enl
        Me.DbhotelDataSet.ekt_dynami1(0).paidia = paid
        Me.DbhotelDataSet.ekt_dynami1(0).atoma = atom
        Me.DbhotelDataSet.ekt_dynami1(0).rr = rr
        Me.DbhotelDataSet.ekt_dynami1(0).bb = bb
        Me.DbhotelDataSet.ekt_dynami1(0).hb = hb
        Me.DbhotelDataSet.ekt_dynami1(0).fb = fb
        Me.DbhotelDataSet.ekt_dynami1(0).ai = ai
        Me.DbhotelDataSet.ekt_dynami1(0).ypnos = ypnos
        Me.DbhotelDataSet.ekt_dynami1(0).prwina = prwina
        Me.DbhotelDataSet.ekt_dynami1(0).geumata = geumata
        Me.DbhotelDataSet.ekt_dynami1(0).extras = extras
        Me.DbhotelDataSet.ekt_dynami1(0).synolo = synolo
        'initiasisiern
        dwm = 0
        enl = 0
        paid = 0
        atom = 0
        rr = 0
        bb = 0
        hb = 0
        fb = 0
        ai = 0
        ypnos = 0
        prwina = 0
        geumata = 0
        extras = 0
        synolo = 0

        dynami_anaxwriseis(startIndex, dwm, enl, paid, atom, rr, bb, hb, fb, ai, ypnos, prwina, geumata, extras, synolo) ' ana praktoreio (firstindex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou

        Me.DbhotelDataSet.ekt_dynami2.Rows.Add()

        Me.DbhotelDataSet.ekt_dynami2(0).flag = 3
        Me.DbhotelDataSet.ekt_dynami2(0).bezeichn = "Αναχωρήσεις"
        Me.DbhotelDataSet.ekt_dynami2(0).dwmatia = Math.Abs(dwm)
        Me.DbhotelDataSet.ekt_dynami2(0).enilikes = Math.Abs(enl)
        Me.DbhotelDataSet.ekt_dynami2(0).paidia = Math.Abs(paid)
        Me.DbhotelDataSet.ekt_dynami2(0).atoma = Math.Abs(atom)
        Me.DbhotelDataSet.ekt_dynami2(0).rr = Math.Abs(rr)
        Me.DbhotelDataSet.ekt_dynami2(0).bb = Math.Abs(bb)
        Me.DbhotelDataSet.ekt_dynami2(0).hb = Math.Abs(hb)
        Me.DbhotelDataSet.ekt_dynami2(0).fb = Math.Abs(fb)
        Me.DbhotelDataSet.ekt_dynami2(0).ai = Math.Abs(ai)
        Me.DbhotelDataSet.ekt_dynami2(0).ypnos = Math.Abs(ypnos)
        Me.DbhotelDataSet.ekt_dynami2(0).prwina = Math.Abs(prwina)
        Me.DbhotelDataSet.ekt_dynami2(0).geumata = Math.Abs(geumata)
        Me.DbhotelDataSet.ekt_dynami2(0).extras = Math.Abs(extras)
        Me.DbhotelDataSet.ekt_dynami2(0).synolo = Math.Abs(synolo)

        Me.DbhotelDataSet.ekt_dynami3.Rows.Add()

        Me.DbhotelDataSet.ekt_dynami3(0).flag = 4
        Me.DbhotelDataSet.ekt_dynami3(0).bezeichn = "Σε Μεταφορά"
        Me.DbhotelDataSet.ekt_dynami3(0).dwmatia = Me.DbhotelDataSet.ekt_dynami(0).dwmatia + Me.DbhotelDataSet.ekt_dynami1(0).dwmatia + dwm
        Me.DbhotelDataSet.ekt_dynami3(0).enilikes = Me.DbhotelDataSet.ekt_dynami(0).enilikes + Me.DbhotelDataSet.ekt_dynami1(0).enilikes + enl
        Me.DbhotelDataSet.ekt_dynami3(0).paidia = Me.DbhotelDataSet.ekt_dynami(0).paidia + Me.DbhotelDataSet.ekt_dynami1(0).paidia + paid
        Me.DbhotelDataSet.ekt_dynami3(0).atoma = Me.DbhotelDataSet.ekt_dynami(0).atoma + Me.DbhotelDataSet.ekt_dynami1(0).atoma + atom
        Me.DbhotelDataSet.ekt_dynami3(0).rr = Me.DbhotelDataSet.ekt_dynami(0).rr + Me.DbhotelDataSet.ekt_dynami1(0).rr + rr
        Me.DbhotelDataSet.ekt_dynami3(0).bb = Me.DbhotelDataSet.ekt_dynami(0).bb + Me.DbhotelDataSet.ekt_dynami1(0).bb + bb
        Me.DbhotelDataSet.ekt_dynami3(0).hb = Me.DbhotelDataSet.ekt_dynami(0).hb + Me.DbhotelDataSet.ekt_dynami1(0).hb + hb
        Me.DbhotelDataSet.ekt_dynami3(0).fb = Me.DbhotelDataSet.ekt_dynami(0).fb + Me.DbhotelDataSet.ekt_dynami1(0).fb + fb
        Me.DbhotelDataSet.ekt_dynami3(0).ai = Me.DbhotelDataSet.ekt_dynami(0).ai + Me.DbhotelDataSet.ekt_dynami1(0).ai + ai
        Me.DbhotelDataSet.ekt_dynami3(0).ypnos = Me.DbhotelDataSet.ekt_dynami(0).ypnos + Me.DbhotelDataSet.ekt_dynami1(0).ypnos + ypnos
        Me.DbhotelDataSet.ekt_dynami3(0).prwina = Me.DbhotelDataSet.ekt_dynami(0).prwina + Me.DbhotelDataSet.ekt_dynami1(0).prwina + prwina
        Me.DbhotelDataSet.ekt_dynami3(0).geumata = Me.DbhotelDataSet.ekt_dynami(0).geumata + Me.DbhotelDataSet.ekt_dynami1(0).geumata + geumata
        Me.DbhotelDataSet.ekt_dynami3(0).extras = Me.DbhotelDataSet.ekt_dynami(0).extras + Me.DbhotelDataSet.ekt_dynami1(0).extras + extras
        Me.DbhotelDataSet.ekt_dynami3(0).synolo = Me.DbhotelDataSet.ekt_dynami(0).synolo + Me.DbhotelDataSet.ekt_dynami1(0).synolo + synolo

    End Sub
    Private Sub apo_metafora(ByVal startIndex As Int16, ByVal countIndex As Int16, ByRef dwm As Int16, ByRef enl As Int16, _
    ByRef paid As Int16, ByRef atom As Int16, ByRef rr As Int16, ByRef bb As Int16, ByRef hb As Int16, ByRef fb As Int16, ByRef ai As Int16, _
    ByRef ypnos As Single, ByRef prwina As Single, ByRef geumata As Single, ByRef extras As Single, ByRef synolo As Single)

        Dim j As Int16

        For j = startIndex To startIndex + countIndex - 1
            If Me.DbhotelDataSet.biblioportas(j).status = 1 Then 'afixi
                dwm += 1
                enl = enl + Me.DbhotelDataSet.biblioportas(j).enilikes
                paid = paid + Me.DbhotelDataSet.biblioportas(j).anilika
                atom = atom + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                Select Case Me.DbhotelDataSet.biblioportas(j).xrewsi
                    Case 1
                        rr = rr + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 2
                        bb = bb + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 3
                        hb = hb + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 4
                        fb = fb + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 6
                        ai = ai + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                End Select
                ypnos = ypnos + Me.DbhotelDataSet.biblioportas(j).ypnos
                prwina = prwina + Me.DbhotelDataSet.biblioportas(j).prwino
                geumata = geumata + Me.DbhotelDataSet.biblioportas(j).geumata
                extras = extras + Me.DbhotelDataSet.biblioportas(j).extras
                synolo = synolo + Me.DbhotelDataSet.biblioportas(j).synolo
            Else
                dwm -= 1
                enl = enl - Me.DbhotelDataSet.biblioportas(j).enilikes
                paid = paid - Me.DbhotelDataSet.biblioportas(j).anilika
                atom = atom - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                Select Case Me.DbhotelDataSet.biblioportas(j).xrewsi
                    Case 1
                        rr = rr - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 2
                        bb = bb - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 3
                        hb = hb - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 4
                        fb = fb - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 6
                        ai = ai - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                End Select
                ypnos = ypnos - Me.DbhotelDataSet.biblioportas(j).ypnos
                prwina = prwina - Me.DbhotelDataSet.biblioportas(j).prwino
                geumata = geumata - Me.DbhotelDataSet.biblioportas(j).geumata
                extras = extras - Me.DbhotelDataSet.biblioportas(j).extras
                synolo = synolo - Me.DbhotelDataSet.biblioportas(j).synolo
            End If


        Next
    End Sub
    Private Sub dynami_afixeis(ByVal startIndex As Int16, ByRef dwm As Int16, ByRef enl As Int16, _
   ByRef paid As Int16, ByRef atom As Int16, ByRef rr As Int16, ByRef bb As Int16, ByRef hb As Int16, ByRef fb As Int16, ByRef ai As Int16, _
   ByRef ypnos As Single, ByRef prwina As Single, ByRef geumata As Single, ByRef extras As Single, ByRef synolo As Single)

        Dim j As Int16

        For j = startIndex To Me.DbhotelDataSet.biblioportas.Count - 1
            If Me.DbhotelDataSet.biblioportas(j).status = 1 AndAlso Me.DbhotelDataSet.biblioportas(j).imerominia.Date = imeromErgasias Then 'afixi
                dwm += 1
                enl = enl + Me.DbhotelDataSet.biblioportas(j).enilikes
                paid = paid + Me.DbhotelDataSet.biblioportas(j).anilika
                atom = atom + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                Select Case Me.DbhotelDataSet.biblioportas(j).xrewsi
                    Case 1
                        rr = rr + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 2
                        bb = bb + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 3
                        hb = hb + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 4
                        fb = fb + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 6
                        ai = ai + Me.DbhotelDataSet.biblioportas(j).enilikes + Me.DbhotelDataSet.biblioportas(j).anilika
                End Select
                ypnos = ypnos + Me.DbhotelDataSet.biblioportas(j).ypnos
                prwina = prwina + Me.DbhotelDataSet.biblioportas(j).prwino
                geumata = geumata + Me.DbhotelDataSet.biblioportas(j).geumata
                extras = extras + Me.DbhotelDataSet.biblioportas(j).extras
                synolo = synolo + Me.DbhotelDataSet.biblioportas(j).synolo
            End If

        Next
    End Sub
    Private Sub dynami_anaxwriseis(ByVal startIndex As Int16, ByRef dwm As Int16, ByRef enl As Int16, _
  ByRef paid As Int16, ByRef atom As Int16, ByRef rr As Int16, ByRef bb As Int16, ByRef hb As Int16, ByRef fb As Int16, ByRef ai As Int16, _
  ByRef ypnos As Single, ByRef prwina As Single, ByRef geumata As Single, ByRef extras As Single, ByRef synolo As Single)

        Dim j As Int16

        For j = startIndex To Me.DbhotelDataSet.biblioportas.Count - 1
            If Me.DbhotelDataSet.biblioportas(j).status = 2 AndAlso Me.DbhotelDataSet.biblioportas(j).imerominia.Date = imeromErgasias Then 'anaxwrisi
                dwm -= 1
                enl = enl - Me.DbhotelDataSet.biblioportas(j).enilikes
                paid = paid - Me.DbhotelDataSet.biblioportas(j).anilika
                atom = atom - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                Select Case Me.DbhotelDataSet.biblioportas(j).xrewsi
                    Case 1
                        rr = rr - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 2
                        bb = bb - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 3
                        hb = hb - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 4
                        fb = fb - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                    Case 6
                        ai = ai - Me.DbhotelDataSet.biblioportas(j).enilikes - Me.DbhotelDataSet.biblioportas(j).anilika
                End Select
                ypnos = ypnos - Me.DbhotelDataSet.biblioportas(j).ypnos
                prwina = prwina - Me.DbhotelDataSet.biblioportas(j).prwino
                geumata = geumata - Me.DbhotelDataSet.biblioportas(j).geumata
                extras = extras - Me.DbhotelDataSet.biblioportas(j).extras
                synolo = synolo - Me.DbhotelDataSet.biblioportas(j).synolo
            End If

        Next
    End Sub
    Private Sub proepiskopisi_biblioportas()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New BiblioPortas()

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
    Private Sub proepiskopisi_biblioportas_keno()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New BiblioPortasKeno()

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
    Private Sub proepiskopisi_biblioportas_ohne_times()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New BiblioPortasOTimes()

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
    Private Sub BiblioPortasFormclass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.etaireia' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'DbhotelDataSet.ethnikotites' table. You can move, or remove it, as needed.


    End Sub
End Class