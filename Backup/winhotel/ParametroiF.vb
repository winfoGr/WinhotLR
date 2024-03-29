Public Class ParametroiF
    Dim connectionString As String
    Dim imeromErgasias As Date ' ACHTUNG ->NACHTRAEGLICH (10/4/2007) EINGETRAGEN BEI MIR-> DEN EIXA XRISIMOPOIISEI IMEROM ERGASIAS OTAN

    Dim etos As Int16 = 2007
    Dim currentuser As Int16

    Dim katigories(0, 0) As Int16 ' Dunami dwmatiwn->1.Dimension eiani oi KLINES, 2.Dimension o TIPOS dwmatioy->gia tin Apothikeusi stin Database
    Dim kwdikoitipwn() As Integer ' apothikeusi tvn DB kwdikwn twn tipwn (stis katigories(i,j))
    Dim kwdikoiklinwn() As Integer ' apothikeusi tvn DB kwdikwn twn klinvn(stis katigories(i,j))
    Dim s() As String
    Dim maxklines As Int16
    Dim klins As Int16  ' oi klines pou epilexthikan gia toys arithmous dwmatiwn
    Dim tips As Int16 ' o tipos pou epilexthike gia toys arithmous dwmatiwn
    Dim dwmatalt(), dwmatneu() As String ' apothikeusi arithmwn dwmatiwn pou uparxoun idi->dwmatalt , eisagwgi/allagi newn arithmwn-> dwmatneu



    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        Select Case Me.TreeView1.SelectedNode.Name.ToString

            Case "Node111"
                'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                'Me.etaireia_zeig()
            Case "Node112"
                'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.fpa_ipnou_zeig()
            Case "Node113"
                'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.parastatika_zeig()
            Case "Node114"
                Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.leitourgia_zeig()
                'Case "Node115"
                '    If currentuser = 1 Then
                '        Me.UsersTableAdapter.Fill(Me.DbhotelDataSet.users) 'edw twra oloi oi user (admin,admin).Ean aplos user tote FillByUser (opou user o kwd tou)
                '    Else
                '        Me.UsersTableAdapter.FillByUser(Me.DbhotelDataSet.users, currentuser)
                '    End If
                '    Me.HauptPnl.Controls.Clear()
                '    Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                '    Me.HauptPnl.Dock = DockStyle.Fill
                '    Me.users_zeig()
            Case "Node12"
                'EtaireiaPnl.Size = New Point(0, 0)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.ethnikotites_zeig()
            Case "xores"
                'EtaireiaPnl.Size = New Point(0, 0)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.xores_zeig()
            Case "dinami"
                'EtaireiaPnl.Size = New Point(0, 0)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill

                Me.katigories_zeig()
            Case "arithmoi"
                'EtaireiaPnl.Size = New Point(0, 0)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                dwmatia_combo_boxen()
            Case "status"
                Me.HauptPnl.Controls.Clear()
                Me.DwmatiastatusTableAdapter.Fill(Me.DbhotelDataSet.dwmatiastatus)
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.status_dwmatiwn_zeig()
            Case "Node15"
                'EtaireiaPnl.Size = New Point(0, 0)
                Me.DbhotelDataSet.tmimata.Clear()
                TmimaPnl.Controls.Clear()
                EkdosiPnl.Controls.Clear()
                FpaPnl.Controls.Clear()
                ForoiPnl.Controls.Clear()
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True)
                tmimata()
            Case "Node16"
                'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.pistwtikes_zeig()
            Case "Node17"
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.seasons_zeig()
            Case "ekt_ethnikotites"
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                ektiposi_ethnikotites()
            Case "email"
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                email_settings()
            Case "emailag"
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                email_agencies_settings()
            Case "arrival"
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                email_arrival_settings()
        End Select
    End Sub


    '*******************status DWMATIWN*******************status DWMATIWN*******************status DWMATIWN**************status DWMATIWN*******************SIMFONIES
    Private Sub status_dwmatiwn_zeig()
        Dim locx, locy As Int16

        locx = 30
        locy = 2 * EtiketaLbl.Height + 80
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "STATUS ΔΩΜΑΤΙΩΝ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        Dim InfoLbl As New Label
        InfoLbl.TextAlign = ContentAlignment.MiddleCenter
        InfoLbl.ForeColor = Color.Black
        InfoLbl.Text = "<Εισάγετε, αλλάξτε ή διαγράψτε Καταστάσεις Δωματίων χρησιμοποιώντας τα αντίστοιχα εικονίδια." & vbCrLf & " (Αποθήκευση-> εικονίδιο δισκέτας. Διαγραφή -> Χ-εικονίδιο)>"

        InfoLbl.Size = New Point(SeasonPnl.Width, 50)
        InfoLbl.Location = New Point(locx, locy - 50)
        HauptPnl.Controls.Add(InfoLbl)
        HauptPnl.Controls.Add(DwmStatusPnl)
        DwmStatusPnl.Size = New Point(600, 370)
        InfoLbl.Width = DwmStatusPnl.Width
        DwmStatusPnl.Location = New Point(locx, locy)

    End Sub
    Private Sub ToolStripButton42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton42.Click
        Dim i As Int16
        DwmatiastatusDataGridView.EndEdit()
        For i = 0 To DwmatiastatusBindingSource.Count - 1
            'Try

            If Me.DwmatiastatusTableAdapter.ExistStatus(DwmatiastatusDataGridView.Item(0, i).Value) Then

                Try
                    Me.DwmatiastatusTableAdapter.UpdateStatus(DwmatiastatusDataGridView.Item(1, i).Value, DwmatiastatusDataGridView.Item(2, i).Value.ToString, DwmatiastatusDataGridView.Item(0, i).Value)
                Catch ex As OleDb.OleDbException
                    MsgBox("Η Αλλαγή του" + DwmatiastatusDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            Else
                If Not DwmatiastatusDataGridView.Item(1, i).Value.ToString.Equals("") Then
                    Try

                        Me.DwmatiastatusTableAdapter.InsertStatus(DwmatiastatusDataGridView.Item(1, i).Value, DwmatiastatusDataGridView.Item(2, i).Value)

                    Catch ex As OleDb.OleDbException
                        MsgBox("Η Αποθήκευση του " + DwmatiastatusDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                End If

            End If

            'Catch ex As InvalidCastException

            'End Try


        Next
        Me.DwmatiastatusTableAdapter.Fill(Me.DbhotelDataSet.dwmatiastatus)
    End Sub
    Private Sub ToolStripButton37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton37.Click
        MsgBox("Αυτή η Επιλογή δεν είναι διαθέσιμη!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        Exit Sub
        'If Me.DwmatiastatusBindingSource.Count <> 0 Then
        '    If (DwmatiastatusDataGridView.Item(0, DwmatiastatusDataGridView.CurrentRow.Index).Value) <> 1 OrElse (DwmatiastatusDataGridView.Item(0, DwmatiastatusDataGridView.CurrentRow.Index).Value) <> 5 Then


        '        Try
        '            Me.DwmatiastatusTableAdapter.DeleteStatus((DwmatiastatusDataGridView.Item(0, DwmatiastatusDataGridView.CurrentRow.Index).Value))
        '        Catch ex As OleDb.OleDbException
        '            MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        '        End Try
        '    End If

        'End If

    End Sub
    Private Sub DwmatiastatusBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles DwmatiastatusBindingSource.AddingNew
        If DwmatiastatusBindingSource.Count = 0 Then
            ToolStripButton37.Visible = False
        Else
            ToolStripButton37.Visible = True
        End If

    End Sub


    Private Sub seasons_zeig()
        Dim locx, locy As Int16

        locx = 30
        locy = 2 * EtiketaLbl.Height + 80
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "SEASONS"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        Dim InfoLbl As New Label
        InfoLbl.TextAlign = ContentAlignment.MiddleCenter
        InfoLbl.ForeColor = Color.Black
        InfoLbl.Text = "<Εισάγετε, αλλάξτε ή διαγράψτε Seasons χρησιμοποιώντας τα αντίστοιχα εικονίδια." & vbCrLf & " (Αποθήκευση-> εικονίδιο δισκέτας. Διαγραφή -> Χ-εικονίδιο)>"

        InfoLbl.Size = New Point(SeasonPnl.Width, 50)
        InfoLbl.Location = New Point(locx, locy - 50)
        HauptPnl.Controls.Add(InfoLbl)
        HauptPnl.Controls.Add(SeasonPnl)
        SeasonPnl.Size = New Point(600, 370)
        InfoLbl.Width = SeasonPnl.Width
        SeasonPnl.Location = New Point(locx, locy)
    End Sub
    Private Sub ToolStripButton35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton35.Click
        Dim i As Int16
        SeasonsDataGridView.EndEdit()
        For i = 0 To SeasonsBindingSource.Count - 1
            'Try

            If Me.SeasonsTableAdapter.ExistSeason(SeasonsDataGridView.Item(0, i).Value) Then

                Try
                    Me.SeasonsTableAdapter.UpdateSeason(SeasonsDataGridView.Item(1, i).Value, SeasonsDataGridView.Item(2, i).Value.ToString, SeasonsDataGridView.Item(0, i).Value)
                Catch ex As OleDb.OleDbException
                    MsgBox("Η Αλλαγή του" + SeasonsDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            Else
                If Not SeasonsDataGridView.Item(1, i).Value.ToString.Equals("") Then
                    Try

                        Me.SeasonsTableAdapter.InsertSeason(SeasonsDataGridView.Item(1, i).Value, SeasonsDataGridView.Item(2, i).Value)

                    Catch ex As OleDb.OleDbException
                        MsgBox("Η Αποθήκευση του " + SeasonsDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                End If

            End If

            'Catch ex As InvalidCastException

            'End Try

        Next
        Me.SeasonsTableAdapter.Fill(Me.DbhotelDataSet.seasons)
    End Sub
    Private Sub ToolStripButton30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton30.Click
        If Me.SeasonsTableAdapter.ExistSeason((SeasonsDataGridView.Item(0, SeasonsDataGridView.CurrentRow.Index).Value)) Then
            Try

                Me.SeasonsTableAdapter.DeleteSeason((SeasonsDataGridView.Item(0, SeasonsDataGridView.CurrentRow.Index).Value))

            Catch ex As OleDb.OleDbException
                MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            End Try
        End If
    End Sub
    Private Sub SeasonsBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles SeasonsBindingSource.AddingNew
        If SeasonsBindingSource.Count = 0 Then
            ToolStripButton30.Visible = False
        Else
            ToolStripButton30.Visible = True
        End If

    End Sub




    Private Sub users_zeig() 'kwd einai o current user 

        Dim locx, locy As Int16

        locx = 30
        locy = 2 * EtiketaLbl.Height + 80
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "USERS ACCOUNTS !!!!!!!!!!!!!!!!!"


        Dim InfoLbl As New Label

        InfoLbl.TextAlign = ContentAlignment.MiddleCenter

        InfoLbl.ForeColor = Color.Black

        '  o currentuser eiani globalvariable kai exei twn kwd (table users) tou user auti tin stigmi
        ' ->PROOPOTHESI OTI TO PRWTO EINTRAG (me kwd=1!!!) STIN USERS-TABLE THA EINAI TOY ADMINISTRATOR!!!
        If currentuser = 1 Then
            'currentuser=1 ->administrator->exei das Recht alles zu tun 
            InfoLbl.Text = "<Εισάγετε, αλλάξτε ή διαγράψτε Users accounts χρησιμοποιώντας τα αντίστοιχα εικονίδια." & vbCrLf & " (Αποθήκευση-> εικονίδιο δισκέτας. Διαγραφή -> Χ-εικονίδιο)>"
        Else 'aplos user (OXI administrator) -> mono to diko tou allages
            InfoLbl.Text = "<Aλλάξτε το Username ή το Password σας χρησιμοποιώντας τα αντίστοιχα εικονίδια." & vbCrLf & " (Αποθήκευση-> εικονίδιο δισκέτας)>"
            Me.UsersBindingSource.AllowNew = False
            BindingNavigator3.Items.Remove(ToolStripButton8)
            BindingNavigator3.Items.Remove(ToolStripButton9)
            'BindingNavigator3.DeleteItem.Enabled = False
        End If

        ' "Διαγράψτε τμήμα σβήνοντας απλα τον τίτλο του. (Ολες οι αλλαγές επικυρώνονται τελειωτικά αφού πατήσετε το κουμπι της Αποθήκευσης!)>"
        InfoLbl.Size = New Point(UsersPnl.Width, 50)
        InfoLbl.Location = New Point(locx, locy - 50)
        HauptPnl.Controls.Add(InfoLbl)
        HauptPnl.Controls.Add(UsersPnl)
        UsersPnl.Size = New Point(600, 370)
        InfoLbl.Width = UsersPnl.Width
        UsersPnl.Location = New Point(locx, locy)


    End Sub
    Private Sub delete_users_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        If Me.UsersTableAdapter.ExistUser((UsersDataGridView.Item(0, UsersDataGridView.CurrentRow.Index).Value)) Then
            Try
                If (UsersDataGridView.Item(0, UsersDataGridView.CurrentRow.Index).Value) <> 1 Then
                    Me.UsersTableAdapter.DeleteUser((UsersDataGridView.Item(0, UsersDataGridView.CurrentRow.Index).Value))
                Else
                    MsgBox("O Administrator δεν μπορεί να διαγραφεί!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End If

            Catch ex As OleDb.OleDbException
                MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            End Try
        End If
        'Me.UsersTableAdapter.Fill(Me.DbhotelDataSet.users)
    End Sub
    Private Sub save_users_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton14.Click
        Dim i As Int16

        UsersDataGridView.EndEdit()
        For i = 0 To UsersBindingSource.Count - 1
            'Try

            If Me.UsersTableAdapter.ExistUser(UsersDataGridView.Item(0, i).Value) Then

                Try
                    Me.UsersTableAdapter.UpdateUsers(UsersDataGridView.Item(1, i).Value, UsersDataGridView.Item(2, i).Value, 1, UsersDataGridView.Item(0, i).Value)
                Catch ex As OleDb.OleDbException
                    MsgBox("Η Αλλαγή του" + UsersDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            Else
                If Not UsersDataGridView.Item(1, i).Value.ToString.Equals("") And Not UsersDataGridView.Item(2, i).Value.ToString.Equals("") Then
                    Try

                        Me.UsersTableAdapter.InsertUsers(UsersDataGridView.Item(1, i).Value, UsersDataGridView.Item(2, i).Value, 1)

                    Catch ex As OleDb.OleDbException
                        MsgBox("Η Αποθήκευση του " + UsersDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                End If

            End If

            'Catch ex As InvalidCastException

            'End Try


        Next
        If currentuser = 1 Then
            Me.UsersTableAdapter.Fill(Me.DbhotelDataSet.users)
        Else
            Me.UsersTableAdapter.FillByUser(Me.DbhotelDataSet.users, currentuser)
        End If

    End Sub
    Private Sub UsersBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles UsersBindingSource.AddingNew
        If UsersBindingSource.Count = 0 Then
            ToolStripButton9.Visible = False
        Else
            ToolStripButton9.Visible = True
        End If

    End Sub
    Private Sub pistwtikes_zeig()
        Dim locx, locy As Int16

        locx = 30
        locy = 2 * EtiketaLbl.Height + 80
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)


        EtiketaLbl.Text = "ΠΙΣΤΩΤΙΚΕΣ ΚΑΡΤΕΣ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)

        Dim InfoLbl As New Label

        InfoLbl.TextAlign = ContentAlignment.MiddleCenter

        InfoLbl.ForeColor = Color.Black
        InfoLbl.Text = "<Εισάγετε, αλλάξτε ή διαγράψτε Πιστωτικές κάρτες χρησιμοποιώντας τα αντίστοιχα εικονίδια." & vbCrLf & " Δώστε για νούμερο εναν 10-ψήφιο αριθμό (χωρίς παύλες) " & vbCrLf & " (Αποθήκευση-> εικονίδιο δισκέτας. Διαγραφή -> Χ-εικονίδιο)>"

        ' "Διαγράψτε τμήμα σβήνοντας απλα τον τίτλο του. (Ολες οι αλλαγές επικυρώνονται τελειωτικά αφού πατήσετε το κουμπι της Αποθήκευσης!)>"
        InfoLbl.Size = New Point(ParastPnl.Width, 50)
        InfoLbl.Location = New Point(locx, locy - 50)
        HauptPnl.Controls.Add(InfoLbl)
        HauptPnl.Controls.Add(PistwtikesPnl)
        PistwtikesPnl.Size = New Point(600, 370)
        InfoLbl.Width = PistwtikesPnl.Width
        PistwtikesPnl.Location = New Point(locx, locy)




    End Sub
    Private Sub PistwtikesDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PistwtikesDataGridView.CellValueChanged

        Try ' TO PRWTO TRY EIANI GIATI ME TO PRWTO LADEN TOY PANEL MPAINEI SE AUTHN THN PROZEDURE 

            If PistwtikesDataGridView.CurrentCell.ColumnIndex = 2 Then
                Try
                    If CType(PistwtikesDataGridView.CurrentCell.Value, Int64) Then  'iNT64 GIATI MPOREI NA 10-PSIFIOS ARITHMOS EINAI MEGALYTERO APO APLO INTEGER(32-BIT)
                        If PistwtikesDataGridView.CurrentCell.Value.ToString.Length = 10 Then 'kanonika 10 noumera xwris paules

                            PistwtikesDataGridView.CurrentCell.Value = display_noumero(PistwtikesDataGridView.CurrentCell.Value)
                        Else
                            MsgBox("Ο Αριθμός λογαριαμού πρέπει να περιέχει συνολικά 10 αριθμούς", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        End If

                    End If
                    'Catch ex As InvalidCastException

                    '    MsgBox("Ο Αριθμός λογαριαμού πρέπει να περιέχει μόνο αριθμούς", MsgBoxStyle.Exclamation, "winfo\nikEl.")

                Catch EX2 As Exception

                End Try


            End If
        Catch ex As Exception 'OTAN FORTVNEITO PROGRAMMA 
        End Try
    End Sub
    Function display_noumero(ByVal noumero As String) As String 'dinei se'na 10-psifio noumero to  FORMAT XX-XX-XX-XXXX OPOY X EINAI ARITHMOS
        Dim neonoum As String = "as"
        If noumero.Length = 10 Then
            neonoum = noumero.Substring(0, 2) + "-" + noumero.Substring(2, 2) + "-" + noumero.Substring(4, 2) + "-" + noumero.Substring(6, 4)
            Return neonoum
        Else
            Return neonoum
        End If

    End Function

    Function richtiges_format(ByVal noumero As String) As Boolean 'PRUEFT OB NOUMERO PISTWTIKIS EXEI TO FORMAT XX-XX-XX-XXXX OPOY X EINAI ARITHMOS

        If noumero.Length = 13 Then
            Try

                If CType(noumero.Substring(0, 2), Integer) AndAlso noumero.Substring(2, 1).Equals("-") AndAlso CType(noumero.Substring(3, 2), Integer) _
                AndAlso noumero.Substring(5, 1).Equals("-") AndAlso CType(noumero.Substring(6, 2), Integer) AndAlso noumero.Substring(8, 1).Equals("-") AndAlso CType(noumero.Substring(9, 4), Integer) Then
                    Return True
                Else
                    Return False
                End If
                '  And CType(noumero.Substring(3, 2), Integer) Then

            Catch ex As InvalidCastException
                Return False
            End Try
        Else
            Return False
        End If

    End Function



    Private Sub pistwtikes_binndNavigator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Dim i As Int16

        PistwtikesDataGridView.EndEdit()
        For i = 0 To PistwtikesBindingSource.Count - 1
            Try 'richtiges_forΜΑΤ  wurdfe ausgeschaltet
                'If richtiges_format(PistwtikesDataGridView.Item(2, i).Value) Then
                If Me.PistwtikesTableAdapter.ExistKwdikos(PistwtikesDataGridView.Item(0, i).Value) Then
                    Try
                        Me.PistwtikesTableAdapter.UpdatePistwtikes(PistwtikesDataGridView.Item(1, i).Value, PistwtikesDataGridView.Item(2, i).Value, PistwtikesDataGridView.Item(0, i).Value)
                    Catch ex As OleDb.OleDbException
                        MsgBox("Η Αλλαγή της" + PistwtikesDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                Else
                    If Not PistwtikesDataGridView.Item(1, i).Value.ToString.Equals("") Then
                        Try
                            Me.PistwtikesTableAdapter.InsertPistwtikes(PistwtikesDataGridView.Item(1, i).Value, PistwtikesDataGridView.Item(2, i).Value)
                        Catch ex As OleDb.OleDbException
                            MsgBox("Η Αποθήκευση του " + PistwtikesDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        End Try
                    End If
                End If
                'End If
            Catch ex As InvalidCastException

            End Try


        Next

        Me.PistwtikesTableAdapter.Fill(Me.DbhotelDataSet.pistwtikes)
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If Me.PistwtikesTableAdapter.ExistKwdikos((PistwtikesDataGridView.Item(0, PistwtikesDataGridView.CurrentRow.Index).Value)) Then
            Try
                Me.PistwtikesTableAdapter.DeletePistwt((PistwtikesDataGridView.Item(0, PistwtikesDataGridView.CurrentRow.Index).Value))
            Catch ex As OleDb.OleDbException
                MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            End Try

        End If
    End Sub
    Private Sub PistwtikesBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles PistwtikesBindingSource.AddingNew
        If PistwtikesBindingSource.Count = 0 Then
            ToolStripButton2.Visible = False
        Else
            ToolStripButton2.Visible = True
        End If

    End Sub


    Private Sub leitourgia_zeig()
        Dim locx, locy As Int16
        Dim maxKrat, minDwm, anzKlin As Int16
        locx = 30
        locy = 2 * EtiketaLbl.Height + 20
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren

        EtiketaPnl.Location = New Point(5, 5)

        EtiketaLbl.Text = "ΛΕΙΤΟΥΡΓΙΑ ΞΕΝΟΔΟΧΕΙΟΥ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)

        LeitourgiaPnl.Size = New Point(608, 599)
        LeitourgiaPnl.Location = New Point(locx, locy)
        Button3.BackColor = Color.Azure
        Button3.ForeColor = Color.Maroon
        Button3.Text = "Αποθήκευση"
        Button3.Size = New Point(120, 30)
        Button3.Cursor = Cursors.Hand

        Try
            maxKrat = Me.KratiseisTableAdapter.GetMaxArithKratisis(etos) '=>GIA INSERT
        Catch ex As InvalidOperationException
            maxKrat = 0
        End Try
        'minDwm = Me.DbhotelDataSet.etaireia(0).maxdwmatia
        'Try
        '    minDwm = Me.KatigoriesTableAdapter.AnzahlBy()
        'Catch ex As InvalidOperationException
        '    minDwm = 0
        'End Try
        'Try
        '    anzKlin = Me.DwmatiaTableAdapter.GetKlinesXenodoxeiou
        'Catch ex As InvalidOperationException
        '    anzKlin = 0
        'End Try
        'TextBox1.Text = maxKrat.ToString
        TextBox1.Text = Me.DbhotelDataSet.etaireia(0).aakratisis
        TextBox2.Text = Me.DbhotelDataSet.etaireia(0).mindwmatia
        TextBox3.Text = Me.DbhotelDataSet.etaireia(0).maxdwmatia
        TextBox4.Text = Me.DbhotelDataSet.etaireia(0).maxklines
        TextBox5.Text = Me.DbhotelDataSet.etaireia(0).minklines
        TextBox6.Text = Me.DbhotelDataSet.etaireia(0).biblportas
        TextBox7.Text = Me.DbhotelDataSet.etaireia(0).theorisiapy
        TextBox8.Text = Me.DbhotelDataSet.etaireia(0).timologia
        CheckBox3.Checked = Me.DbhotelDataSet.etaireia(0).biblportastimes
        Try
            LeitourgiaAAGEtbx.Text = Me.DbhotelDataSet.etaireia(0).aage
            LeitourgiaAAAPYtbx.Text = Me.DbhotelDataSet.etaireia(0).aaapy
            LeitPistotikTbx.Text = Me.DbhotelDataSet.etaireia(0).aagramatio
            LeitAAAPYBSeiratbx.Text = Me.DbhotelDataSet.etaireia(0).aabapy
        Catch ex As StrongTypingException
            MsgBox("Προέκυψε σφάλμα στην ανάγνωση Α/Αριθμού ΓΕ/ΑΠΥ ", MsgBoxStyle.Critical, "winfo\nikEl.")
        End Try

        CheckBox1.Checked = Me.DbhotelDataSet.etaireia(0).guaranti
        CheckBox2.Checked = Me.DbhotelDataSet.etaireia(0).ktimis
        ImeromErgPck.Value = Me.DbhotelDataSet.etaireia(0).imeromergasias
        Me.KleismImerPck.Value = Me.DbhotelDataSet.etaireia(0).kleismenidate
        BiblportFlag.Text = Me.DbhotelDataSet.etaireia(0).ektportasflag
        BiblApyFlag.Text = Me.DbhotelDataSet.etaireia(0).ektportasapyflag


        EtiketaPnl.Controls.Add(EtiketaLbl)
        HauptPnl.Controls.Add(EtiketaPnl)
        HauptPnl.Controls.Add(LeitourgiaPnl)
    End Sub
    Private Sub TextBox6_TextLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.Leave
        Try

            Select Case CType(TextBox6.Text, Int16)
                Case Is < 1

                    TextBox6.Text = 1
                Case Is > 3
                    MsgBox("1 (ενα) 3(τρία) Ονόματα", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    TextBox6.Text = 1
                Case 2
                    MsgBox("1 (ενα) 3(τρία) Ονόματα", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    TextBox6.Text = 1

            End Select
        Catch ex As InvalidCastException
            TextBox6.Text = 1
        End Try

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.EtaireiaTableAdapter.UpdateLeitourgia(TextBox1.Text, TextBox6.Text, CheckBox1.Checked, CheckBox2.Checked, TextBox3.Text, _
            TextBox4.Text, TextBox2.Text, TextBox5.Text, TextBox7.Text, TextBox8.Text, CType(LeitourgiaAAGEtbx.Text, Int16), CType(LeitourgiaAAAPYtbx.Text, Int16), CheckBox3.Checked, Me.ImeromErgPck.Value, Me.KleismImerPck.Value, CType(BiblportFlag.Text, Byte), CType(BiblApyFlag.Text, Byte), CType(LeitPistotikTbx.Text, Int16), CType(LeitAAAPYBSeiratbx.Text, Int16), Me.DbhotelDataSet.etaireia(0).kwd)
        Catch ex As Exception
            MsgBox("Η Αποθήκευση απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
            Exit Sub
        End Try
        imeromErgasias = ImeromErgPck.Value.Date
        MsgBox("Επιτυχής Αποθήκευση !", MsgBoxStyle.Information, "winfo\nikEl.")
    End Sub
    '***********PARASTATIKA***********PARASTATIKA***********PARASTATIKA***********PARASTATIKA
    '***********PARASTATIKA***********PARASTATIKA***********PARASTATIKA***********PARASTATIKA
    '***********PARASTATIKA***********PARASTATIKA***********PARASTATIKA***********PARASTATIKA
    '***********PARASTATIKA***********PARASTATIKA***********PARASTATIKA***********PARASTATIKA
    Private Sub parastatika_zeig()
        Dim locx, locy As Int16
        Dim InfoLbl As New Label

        locx = 30
        locy = 2 * EtiketaLbl.Height + 20
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)


        EtiketaLbl.Text = "  ΠΑΡΑΣΤΑΤΙΚΑ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)

        InfoLbl.TextAlign = ContentAlignment.MiddleCenter
        InfoLbl.ForeColor = Color.Black
        InfoLbl.Text = "<Εισάγετε, αλλάξτε ή διαγράψτε Παραστατικά χρησιμοποιώντας τα αντίστοιχα εικονίδια." & vbCrLf & " (Αποθήκευση-> εικονίδιο δισκέτας. Διαγραφή -> Χ-εικονίδιο)>"

        ' "Διαγράψτε τμήμα σβήνοντας απλα τον τίτλο του. (Ολες οι αλλαγές επικυρώνονται τελειωτικά αφού πατήσετε το κουμπι της Αποθήκευσης!)>"
        InfoLbl.Size = New Point(ParastPnl.Width, 50)
        InfoLbl.Location = New Point(locx, locy)
        HauptPnl.Controls.Add(InfoLbl)
        HauptPnl.Controls.Add(ParastPnl)
        ParastPnl.Size = New Point(600, 370)
        InfoLbl.Width = ParastPnl.Width
        ParastPnl.Location = New Point(locx, locy + InfoLbl.Height)


    End Sub
    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        'MsgBox(ParastatikaBindingSource.Count)
        'MsgBox((ParastatikaDataGridView.Item(1, ParastatikaDataGridView.CurrentRow.Index).Value))
        Dim i As Int16

        ParastatikaDataGridView.EndEdit()
        For i = 0 To ParastatikaBindingSource.Count - 1

            If Me.ParastatikaTableAdapter.ExistKwdiko(ParastatikaDataGridView.Item(0, i).Value) Then

                Try

                    If IsDBNull(ParastatikaDataGridView.Item(2, i).Value) Then
                        ParastatikaDataGridView.Item(2, i).Value = ""
                    End If
                    Me.ParastatikaTableAdapter.UpdateParastByKwdiko(ParastatikaDataGridView.Item(1, i).Value, ParastatikaDataGridView.Item(2, i).Value, Math.Abs(CType(ParastatikaDataGridView.Item(3, i).Value, Integer)), 1, ParastatikaDataGridView.Item(0, i).Value)
                Catch ex As InvalidCastException
                    MsgBox("Η Αλλαγή του " + ParastatikaDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή" & vbCrLf & _
                        "Ο Αριθμός του Παραστατικού πρεπει να περιέχει μόνο νούμερα!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            Else
                If Not ParastatikaDataGridView.Item(3, i).Value.ToString.Equals("") Then
                    Try


                        Me.ParastatikaTableAdapter.InsertParastatiko(ParastatikaDataGridView.Item(1, i).Value, ParastatikaDataGridView.Item(2, i).Value, Math.Abs(CType(ParastatikaDataGridView.Item(3, i).Value, Integer)), 1)
                    Catch ex As InvalidCastException
                        MsgBox("Η Αποθήκευση του " + ParastatikaDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή:" & vbCrLf & _
                        "Ο Αριθμός του Παραστατικού πρεπει να περιέχει μόνο νούμερα!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    Catch ex2 As OleDb.OleDbException
                        MsgBox("Η Αποθήκευση του " + ParastatikaDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                End If

            End If
        Next

        Me.ParastatikaTableAdapter.Fill(Me.DbhotelDataSet.parastatika)
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click

        If Me.ParastatikaTableAdapter.ExistKwdiko((ParastatikaDataGridView.Item(0, ParastatikaDataGridView.CurrentRow.Index).Value)) Then
            Try
                Me.ParastatikaTableAdapter.DelParastByKwdiko((ParastatikaDataGridView.Item(0, ParastatikaDataGridView.CurrentRow.Index).Value))
            Catch ex As OleDb.OleDbException
                MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            End Try

        End If
    End Sub

    Private Sub fpa_ipnou_zeig()
        'Dim locx, locy As Int16

        'locx = 30
        'locy = 2 * EtiketaLbl.Height + 80
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "Φ.Π.Α. ΤΜΗΜΑΤΩΝ - ΦΟΡΟΙ "
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        HauptPnl.Controls.Add(FpaYpnouPnl)
        FpaYpnouPnl.Size = New Point(650, 370)
        FpaYpnouPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        Button2.BackColor = Color.Azure
        Button2.ForeColor = Color.Maroon
        Button2.Text = "Αποθήκευση"
        Button2.Size = New Point(120, 30)
        Button2.Cursor = Cursors.Hand

        'Fpatrofis1TextBox.Text = (Format(Me.DbhotelDataSet.etaireia(0).fpatrofis1.ToString("F2") / 100, "Percent"))

        Fpatrofis1TextBox.Text = Me.DbhotelDataSet.etaireia(0).fpatrofis1.ToString("F2")
        Fpatrofis2TextBox.Text = Me.DbhotelDataSet.etaireia(0).fpatrofis2.ToString("F2")
        Fpatrofis3TextBox.Text = Me.DbhotelDataSet.etaireia(0).fpatrofis3.ToString("F2")
        Dimforos1TextBox.Text = Me.DbhotelDataSet.etaireia(0).dimforos1.ToString("F2")
        Dimforos2TextBox.Text = Me.DbhotelDataSet.etaireia(0).dimforos2.ToString("F2")
        Fparepid1TextBox.Text = Me.DbhotelDataSet.etaireia(0).fparepid1.ToString("F2")
        Fparepid2TextBox.Text = Me.DbhotelDataSet.etaireia(0).fparepid2.ToString("F2")
        Fpatmima1TextBox.Text = Me.DbhotelDataSet.etaireia(0).fpatmima1.ToString("F2")
        Fpatmima2TextBox.Text = Me.DbhotelDataSet.etaireia(0).fpatmima2.ToString("F2")
        Fpatmima3TextBox.Text = Me.DbhotelDataSet.etaireia(0).fpatmima3.ToString("F2")
        Fpatmima4TextBox.Text = Me.DbhotelDataSet.etaireia(0).fpatmima4.ToString("F2")
        ExtrasTextBox.Text = Me.DbhotelDataSet.etaireia(0).extras.ToString("F2")
    End Sub

    Private Sub Prwino_komma_einschalten(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Fpatrofis1TextBox.KeyPress, Fpatrofis2TextBox.KeyPress, Fpatrofis3TextBox.KeyPress, Dimforos1TextBox.KeyPress, Dimforos2TextBox.KeyPress, _
    Fparepid1TextBox.KeyPress, Fparepid2TextBox.KeyPress, Fpatmima1TextBox.KeyPress, Fpatmima2TextBox.KeyPress, Fpatmima3TextBox.KeyPress, Fpatmima4TextBox.KeyPress, ExtrasTextBox.KeyPress
        komma_einschalten(sender, e)
    End Sub
    Private Sub Prwino_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fpatrofis1TextBox.Click, Fpatrofis2TextBox.Click, Fpatrofis3TextBox.Click, Dimforos1TextBox.Click, Dimforos2TextBox.Click, _
    Fparepid1TextBox.Click, Fparepid2TextBox.Click, Fpatmima1TextBox.Click, Fpatmima2TextBox.Click, Fpatmima3TextBox.Click, Fpatmima4TextBox.Click, ExtrasTextBox.Click
        selectall(sender, e)
    End Sub
    Private Sub FpatrofisTextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fpatrofis1TextBox.Leave, Fpatrofis2TextBox.Leave, Fpatrofis3TextBox.Leave, _
       Dimforos1TextBox.Leave, Dimforos2TextBox.Leave, Fparepid1TextBox.Leave, Fparepid2TextBox.Leave, Fpatmima1TextBox.Leave, _
       Fpatmima2TextBox.Leave, Fpatmima3TextBox.Leave, ExtrasTextBox.Leave, Fpatmima4TextBox.Leave

        Try
            sender.text = CType(sender.text, Double).ToString("F2")
        Catch ex As InvalidCastException
            sender.text = "0,00"
        End Try


    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim afmclass As New afm_pruefung

        If afmclass.ist_afm_ok(AfmTextBox.Text) Then
            Try
                Me.EtaireiaTableAdapter.UpdateEpixeirisi(EpixirisiTextBox.Text, XenodoxeioTextBox.Text, DieuthinsiTextBox.Text, TilefonoTextBox.Text, AfmTextBox.Text, DoyTextBox.Text, Me.DbhotelDataSet.etaireia(0).kwd)
                MsgBox(" Επιτυχής Αποθήκευση !", MsgBoxStyle.Information, "winfo\nikEl.")
            Catch ex As OleDb.OleDbException
                MsgBox(" Η Αποθήκευση των αλλαγών δεν κατέστη δυνατή!", MsgBoxStyle.Critical, "winfo\nikEl.")

            End Try

        Else
            MsgBox("Λάθος Α.Φ.Μ. Η Αποθήκευση των αλλαγών δεν κατέστη δυνατή!", MsgBoxStyle.Exclamation, "winfo\nikEl.")

        End If

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.EtaireiaTableAdapter.UpdateFpa(Fpatrofis1TextBox.Text, Fpatrofis2TextBox.Text, Fpatrofis3TextBox.Text, _
                    Dimforos1TextBox.Text, Dimforos2TextBox.Text, Fparepid1TextBox.Text, Fparepid2TextBox.Text, Fpatmima1TextBox.Text, _
                    Fpatmima2TextBox.Text, Fpatmima3TextBox.Text, Fpatmima4TextBox.Text, ExtrasTextBox.Text, Me.DbhotelDataSet.etaireia(0).kwd)
            MsgBox(" Επιτυχής Αποθήκευση !", MsgBoxStyle.Information, "winfo\nikEl.")
        Catch ex As OleDb.OleDbException
            MsgBox(" Η Αποθήκευση των αλλαγών δεν κατέστη δυνατή!", MsgBoxStyle.Critical, "winfo\nikEl.")
        End Try


    End Sub

    Private Sub etaireia_zeig()
        'Dim locx, locy As Int16

        'locx = 30
        'locy = 2 * EtiketaLbl.Height + 80
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "ΣΤΟΙΧΕΙΑ ΕΠΙΧΕΙΡΗΣΗΣ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)

        EtaireiaPnl.Size = New Point(700, 400)
        EtaireiaPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        Button1.BackColor = Color.Azure
        Button1.ForeColor = Color.Maroon
        Button1.Text = "Αποθήκευση"
        Button1.Size = New Point(120, 30)
        Button1.Cursor = Cursors.Hand
        HauptPnl.Controls.Add(EtaireiaPnl)

    End Sub
    '***************ΤΜΗΜΑΤΑ*************************ΤΜΗΜΑΤΑ*********************************************************
    '***************ΤΜΗΜΑΤΑ*************************ΤΜΗΜΑΤΑ*********************************************************
    '***************ΤΜΗΜΑΤΑ*************************ΤΜΗΜΑΤΑ*********************************************************
    '***************ΤΜΗΜΑΤΑ*************************ΤΜΗΜΑΤΑ*********************************************************
    Private Sub tmimata()
        Dim i, locx, locy As Int16
        Dim SpeicherButton As New Button
        'InitializeMyScrollBar()
        locx = 30
        locy = 2 * EtiketaLbl.Height + 80

        HauptPnl.Controls.Remove(SpeicherButton)

        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        'EtiketaLbl.ForeColor = Color.Maroon

        EtiketaLbl.Text = "TMHMATA - Φ.Π.Α. ΤΜΗΜΑΤΩΝ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        Me.HauptPnl.Controls.Add(EtiketaPnl)

        'Inizialisieren Epikefalides Stilwn

        Dim TmimaLbl As New Label
        TmimaLbl.ForeColor = Color.Blue

        TmimaLbl.Text = "ΤΜΗΜΑΤΑ"
        TmimaPnl.Controls.Add(TmimaLbl)
        TmimaLbl.Location = New Point(10, 5)

        Dim TitlosLbl As New Label
        TitlosLbl.ForeColor = Color.Maroon

        TitlosLbl.Text = "Τίτλος"
        TmimaPnl.Controls.Add(TitlosLbl)
        TitlosLbl.Size = New Point(50, 20)
        TitlosLbl.Location = New Point(30, 5 + TmimaLbl.Height)


        Dim EkdosiLbl As New Label
        EkdosiLbl.ForeColor = Color.Blue
        EkdosiLbl.Text = "ΕΚΔΟΣΗ ΠΑΡΑΣΤΑΤΙΚΟΥ"
        EkdosiLbl.Size = New Point(170, 20)
        EkdosiLbl.Location = New Point(10, 5)
        EkdosiPnl.Controls.Add(EkdosiLbl)

        Dim EidosLbl As New Label
        EidosLbl.ForeColor = Color.Maroon
        EidosLbl.Text = "Είδος(ΑΠΥ,ΑΠΛ,)- A/Α" ' -Συμμετ.στις μ.τιμές"
        EidosLbl.Size = New Point(135, 20)
        EidosLbl.Location = New Point(5, 5 + TmimaLbl.Height)
        EkdosiPnl.Controls.Add(EidosLbl)

        Dim SimetLbl As New Label
        SimetLbl.ForeColor = Color.Maroon
        SimetLbl.Text = "Συμμετ.στις μ.τιμές"
        SimetLbl.Size = New Point(55, 40)
        SimetLbl.Location = New Point(5 + EidosLbl.Width + 75, 5 + TmimaLbl.Height - 20)
        EkdosiPnl.Controls.Add(SimetLbl)

        Dim FpaLbl As New Label
        FpaLbl.Location = New Point(10, 5)
        FpaLbl.ForeColor = Color.Blue
        FpaLbl.Text = "Φ.Π.Α."
        FpaPnl.Controls.Add(FpaLbl)

        Dim ForoiLbl As New Label
        ForoiLbl.Location = New Point(10, 5)
        ForoiLbl.ForeColor = Color.Blue
        ForoiLbl.Text = "ΦΟΡΟΙ"
        ForoiPnl.Controls.Add(ForoiLbl)

        Dim DimforLbl As New Label
        DimforLbl.ForeColor = Color.Maroon
        DimforLbl.Text = "ΔΦ"
        DimforLbl.Size = New Point(40, 20)
        DimforLbl.Location = New Point(5, 5 + ForoiLbl.Height)
        ForoiPnl.Controls.Add(DimforLbl)

        Dim ParepforLbl As New Label
        ParepforLbl.ForeColor = Color.Maroon
        ParepforLbl.Text = "ΦΠ"
        ParepforLbl.Size = New Point(40, 20)
        ParepforLbl.Location = New Point(5 + DimforLbl.Width, 5 + ForoiLbl.Height)
        ForoiPnl.Controls.Add(ParepforLbl)

        Dim SxedioLbl As New Label
        SxedioLbl.ForeColor = Color.Blue
        SxedioLbl.Text = "ΛΟΓΙΣΤΚΟ ΣΧΕΔΙΟ"
        SxedioPnl.Controls.Add(SxedioLbl)


        For i = 0 To Me.DbhotelDataSet.tmimata.Count + 4

            Dim ArithmTbx As New TextBox
            Dim ArithmLbl As New Label
            If i > Me.DbhotelDataSet.tmimata.Count - 1 Then
                ArithmTbx.Name = "Ari_" + i.ToString
                ArithmTbx.ForeColor = Color.Black


                ArithmTbx.TextAlign = HorizontalAlignment.Center
                ArithmTbx.MaxLength = 2
                ArithmTbx.Size = New Point(30, 20)
                ArithmTbx.Location = New Point(TmimaLbl.Location.X, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)
                TmimaPnl.Controls.Add(ArithmTbx)
            Else

                ArithmLbl.Name = "Ari" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
                ArithmLbl.ForeColor = Color.Black
                ArithmLbl.TextAlign = ContentAlignment.MiddleCenter

                ArithmLbl.Text = Me.DbhotelDataSet.tmimata(i).kwd
                ArithmLbl.Size = New Point(30, 20)
                ArithmLbl.Location = New Point(TmimaLbl.Location.X, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)

            End If
            ArithmLbl.Width = 30
            'ArithmLbl.Location = New Point(20, 5)





            Dim TmimaTbx As New TextBox
            If i < Me.DbhotelDataSet.tmimata.Count Then
                TmimaTbx.Text = Me.DbhotelDataSet.tmimata(i).tmima
                TmimaTbx.Name = "Tmi" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
            Else
                TmimaTbx.Name = "Tmi_" + i.ToString
            End If



            TmimaTbx.MaxLength = 30
            TmimaTbx.TextAlign = HorizontalAlignment.Center
            TmimaTbx.ForeColor = Color.Black
            TmimaTbx.Size = New Point(150, 20)
            TmimaTbx.Location = New Point(TmimaLbl.Location.X + ArithmLbl.Width, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)
            TmimaPnl.Controls.Add(TmimaTbx)

            TmimaPnl.Size = New Point(ArithmLbl.Width + TmimaTbx.Width + 15, TmimaTbx.Height + TmimaLbl.Height + TitlosLbl.Height + 20 + i * 40)

            TmimaPnl.Controls.Add(TmimaTbx)
            TmimaPnl.Controls.Add(ArithmLbl)
            'TmimaPnl.Controls.Add(ArithmTbx)

            Dim ParastTbx As New TextBox
            If i < Me.DbhotelDataSet.tmimata.Count Then
                ParastTbx.Text = Me.DbhotelDataSet.tmimata(i).tiposparast
                ParastTbx.Name = "Par" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
            Else
                ParastTbx.Name = "Par_" + i.ToString
            End If


            ParastTbx.MaxLength = 3
            ParastTbx.TextAlign = HorizontalAlignment.Center
            ParastTbx.ForeColor = Color.Black
            ParastTbx.Size = New Point(60, 20)
            EkdosiPnl.Controls.Add(ParastTbx)




            'ParastTbx.Location = New Point(TmimaLbl.Location.X + ArithmLbl.Width + TmimaTbx.Width, TmimaLbl.Location.Y + TmimaLbl.Height)
            ParastTbx.Location = New Point(5, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)

            EkdosiPnl.Controls.Add(ParastTbx)




            Dim SeiraTbx As New TextBox
            If i < Me.DbhotelDataSet.tmimata.Count Then
                SeiraTbx.Text = Me.DbhotelDataSet.tmimata(i).seira
                SeiraTbx.Name = "Sra" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
            Else
                SeiraTbx.Name = "Sra_" + i.ToString
            End If


            SeiraTbx.MaxLength = 1
            SeiraTbx.TextAlign = HorizontalAlignment.Center
            SeiraTbx.ForeColor = Color.Black
            SeiraTbx.Size = New Point(30, 20)


            EkdosiPnl.Controls.Add(SeiraTbx)
            SeiraTbx.Location = New Point(5 + ParastTbx.Width, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)
            'EkdosiPnl.Size = New Point(EkdosiLbl.Width + SeiraTbx.Width, (i + 1) * TmimaTbx.Height + TmimaLbl.Height + 20)


            Dim AAParTbx As New TextBox
            If i < Me.DbhotelDataSet.tmimata.Count Then
                AAParTbx.Text = Me.DbhotelDataSet.tmimata(i).aaparast
                AAParTbx.Name = "AAp" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
            Else
                AAParTbx.Name = "AAp_" + i.ToString
            End If


            AAParTbx.MaxLength = 6
            AAParTbx.TextAlign = HorizontalAlignment.Center
            AAParTbx.ForeColor = Color.Black
            AAParTbx.Size = New Point(80, 20)

            EkdosiPnl.Controls.Add(AAParTbx)
            AAParTbx.Location = New Point(5 + ParastTbx.Width + SeiraTbx.Width, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)


            Dim SimetoxiChk As New CheckBox ' Eixa pROBLIMA sto Update gia ayto to Value(true h false) to grafw sto ONOMA tou Control->ALLAGH?=>ALLAZW TO ONOMA (Simetoxi_changed)
            If i < Me.DbhotelDataSet.tmimata.Count Then
                SimetoxiChk.Checked = Me.DbhotelDataSet.tmimata(i).simetoxi
                SimetoxiChk.Name = "Sim" + Me.DbhotelDataSet.tmimata(i).kwd.ToString + "_" + Me.DbhotelDataSet.tmimata(i).simetoxi.ToString
            Else
                SimetoxiChk.Name = "Simx" + i.ToString + "_" + "FALSE"
            End If
            AddHandler SimetoxiChk.CheckedChanged, AddressOf Simetoxi_changed



            SimetoxiChk.Size = New Point(30, 20)
            EkdosiPnl.Controls.Add(SimetoxiChk)
            SimetoxiChk.Location = New Point(5 + ParastTbx.Width + SeiraTbx.Width + AAParTbx.Width + 50, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)


            EkdosiPnl.Size = New Point(ParastTbx.Width + SeiraTbx.Width + AAParTbx.Width + SimetoxiChk.Width + 65 + 15, TmimaTbx.Height + TmimaLbl.Height + TitlosLbl.Height + 20 + i * 40)


            Dim Fpa1Tbx As New TextBox
            If i < Me.DbhotelDataSet.tmimata.Count Then
                Fpa1Tbx.Text = Me.DbhotelDataSet.tmimata(i).fpa1.ToString("F")
                Fpa1Tbx.Name = "Fp1" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
            Else
                Fpa1Tbx.Name = "Fp1_" + i.ToString
            End If


            Fpa1Tbx.MaxLength = 5
            Fpa1Tbx.TextAlign = HorizontalAlignment.Center
            Fpa1Tbx.ForeColor = Color.Black
            Fpa1Tbx.Size = New Point(40, 20)
            Fpa1Tbx.Location = New Point(5, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)
            FpaPnl.Controls.Add(Fpa1Tbx)

            'AddHandler Fpa1Tbx.Enter, AddressOf fpa1Tbx_enter
            AddHandler Fpa1Tbx.Leave, AddressOf fpaTbx_leave


            Dim Fpa2Tbx As New TextBox
            If i < Me.DbhotelDataSet.tmimata.Count Then
                Fpa2Tbx.Text = Me.DbhotelDataSet.tmimata(i).fpa2.ToString("F")
                Fpa2Tbx.Name = "Fp2" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
            Else
                Fpa2Tbx.Name = "Fp2_" + i.ToString
            End If


            Fpa2Tbx.MaxLength = 5
            Fpa2Tbx.TextAlign = HorizontalAlignment.Center
            Fpa2Tbx.ForeColor = Color.Black
            Fpa2Tbx.Size = New Point(40, 20)
            Fpa2Tbx.Location = New Point(5 + Fpa1Tbx.Width, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)
            FpaPnl.Controls.Add(Fpa2Tbx)
            AddHandler Fpa2Tbx.Leave, AddressOf fpaTbx_leave

            Dim Fpa3Tbx As New TextBox
            If i < Me.DbhotelDataSet.tmimata.Count Then
                Fpa3Tbx.Text = Me.DbhotelDataSet.tmimata(i).fpa3.ToString("F")
                Fpa3Tbx.Name = "Fp3" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
            Else
                Fpa3Tbx.Name = "Fp3_" + i.ToString
            End If


            Fpa3Tbx.MaxLength = 5
            Fpa3Tbx.TextAlign = HorizontalAlignment.Center
            Fpa3Tbx.ForeColor = Color.Black
            Fpa3Tbx.Size = New Point(40, 20)
            Fpa3Tbx.Location = New Point(5 + Fpa1Tbx.Width + Fpa2Tbx.Width, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)
            AddHandler Fpa3Tbx.Leave, AddressOf fpaTbx_leave

            FpaPnl.Controls.Add(Fpa3Tbx)


            Dim Fpa4Tbx As New TextBox
            If i < Me.DbhotelDataSet.tmimata.Count Then
                Fpa4Tbx.Text = Me.DbhotelDataSet.tmimata(i).fpa4.ToString("F")
                Fpa4Tbx.Name = "Fp4" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
            Else
                Fpa4Tbx.Name = "Fp4_" + i.ToString
            End If


            Fpa4Tbx.MaxLength = 5
            Fpa4Tbx.TextAlign = HorizontalAlignment.Center
            Fpa4Tbx.ForeColor = Color.Black
            Fpa4Tbx.Size = New Point(40, 20)
            Fpa4Tbx.Location = New Point(5 + Fpa1Tbx.Width + Fpa2Tbx.Width + Fpa3Tbx.Width, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)
            AddHandler Fpa4Tbx.Leave, AddressOf fpaTbx_leave

            FpaPnl.Controls.Add(Fpa4Tbx)

            FpaPnl.Size = New Point(Fpa1Tbx.Width + Fpa2Tbx.Width + +Fpa3Tbx.Width + Fpa4Tbx.Width + 15, TmimaTbx.Height + TmimaLbl.Height + TitlosLbl.Height + 20 + i * 40)


            Dim DimforTbx As New TextBox
            If i < Me.DbhotelDataSet.tmimata.Count Then
                DimforTbx.Text = Me.DbhotelDataSet.tmimata(i).dimotikosf.ToString("F")
                DimforTbx.Name = "Fdm" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
            Else
                DimforTbx.Name = "Fdm_" + i.ToString
            End If



            DimforTbx.MaxLength = 5
            DimforTbx.TextAlign = HorizontalAlignment.Center
            DimforTbx.ForeColor = Color.Black
            DimforTbx.Size = New Point(40, 20)
            DimforTbx.Location = New Point(5, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)
            AddHandler DimforTbx.Leave, AddressOf fpaTbx_leave

            ForoiPnl.Controls.Add(DimforTbx)

            Dim ParepforTbx As New TextBox
            If i < Me.DbhotelDataSet.tmimata.Count Then
                ParepforTbx.Text = Me.DbhotelDataSet.tmimata(i).dimotikosf.ToString("F")
                ParepforTbx.Name = "Fpd" + Me.DbhotelDataSet.tmimata(i).kwd.ToString
            Else
                ParepforTbx.Name = "Fpd_" + i.ToString
            End If


            ParepforTbx.MaxLength = 5
            ParepforTbx.TextAlign = HorizontalAlignment.Center
            ParepforTbx.ForeColor = Color.Black
            ParepforTbx.Size = New Point(40, 20)
            ParepforTbx.Location = New Point(5 + DimforTbx.Width, TmimaLbl.Location.Y + TmimaLbl.Height + TitlosLbl.Height + i * 40)
            AddHandler ParepforTbx.Leave, AddressOf fpaTbx_leave
            ForoiPnl.Controls.Add(ParepforTbx)

            ForoiPnl.Size = New Point(ParepforTbx.Width + DimforTbx.Width + 15, TmimaTbx.Height + TmimaLbl.Height + TitlosLbl.Height + 20 + i * 40)



        Next


        SpeicherButton.BackColor = Color.Azure
        SpeicherButton.ForeColor = Color.Maroon
        SpeicherButton.Text = "Αποθήκευση"
        SpeicherButton.Size = New Point(120, 30)
        SpeicherButton.Cursor = Cursors.Hand
        SpeicherButton.Location = New Point((locx + TmimaPnl.Width + EkdosiPnl.Width + FpaPnl.Width) / 2, locy + TmimaPnl.Height + 30)
        HauptPnl.Controls.Add(SpeicherButton)
        AddHandler SpeicherButton.Click, AddressOf tmimata_speichern

        HauptPnl.Controls.Add(TmimaPnl)
        HauptPnl.Controls.Add(EkdosiPnl)
        HauptPnl.Controls.Add(FpaPnl)
        HauptPnl.Controls.Add(ForoiPnl)
        TmimaPnl.Location = New Point(locx, locy)
        EkdosiPnl.Location = New Point(locx + TmimaPnl.Width, locy)
        FpaPnl.Location = New Point(locx + TmimaPnl.Width + EkdosiPnl.Width, locy)
        ForoiPnl.Location = New Point(locx + TmimaPnl.Width + EkdosiPnl.Width + FpaPnl.Width, locy)


        Dim InfoLbl As New Label
        InfoLbl.TextAlign = ContentAlignment.MiddleCenter

        InfoLbl.ForeColor = Color.Black
        InfoLbl.Text = "<Εισάγετε νέα τμήματα στις κενές σειρές κάτω. Διαγράψτε τμήμα σβήνοντας απλά τον τίτλο του." & vbCrLf & " (Ολες οι αλλαγές επικυρώνονται τελειωτικά αφού κάνετε απλό κλίκ στο κουμπί της Αποθήκευσης!)>"

        ' "Διαγράψτε τμήμα σβήνοντας απλα τον τίτλο του. (Ολες οι αλλαγές επικυρώνονται τελειωτικά αφού πατήσετε το κουμπι της Αποθήκευσης!)>"
        InfoLbl.Size = New Point(TmimaPnl.Width + EkdosiPnl.Width + FpaPnl.Width + ForoiPnl.Width, 50)
        InfoLbl.Location = New Point(locx, locy - 50)
        HauptPnl.Controls.Add(InfoLbl)

    End Sub
    Private Sub Simetoxi_changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Eixa pROBLIMA sto Update gia ayto to Value(true h false) to grafw sto ONOMA tou Control->ALLAGH?=>ALLAZW TO ONOMA (Simetoxi_changed)(morfi: SimX_TRUE)


        Dim split As String() = sender.NAME.ToString.Split(New [Char]() {"_"c})
        If sender.checked = True Then
            sender.name = split(0) + "_" + "True"

        Else
            sender.name = split(0) + "_" + "False"

        End If

    End Sub
    Private Sub tmimata_speichern(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Int16
        Dim Ari(), Tmi(), Par(), Sra(), Aap(), Sim(), Fp1(), Fp2(), Fp3(), Fp4(), Fdm(), Fpd() As Control
        Dim refresh As Boolean = False
        Dim enimerwsiOK As Boolean = False

        Me.Cursor = Cursors.WaitCursor


        For i = 0 To Me.DbhotelDataSet.tmimata.Count - 1
            Dim simetoxi As Boolean
            'Tmi = Me.Panel1.Controls.Find("Tmi1", False)
            Tmi = Me.TmimaPnl.Controls.Find("Tmi" + Me.DbhotelDataSet.tmimata(i).kwd.ToString, False)
            Par = Me.EkdosiPnl.Controls.Find("Par" + Me.DbhotelDataSet.tmimata(i).kwd.ToString, False)
            Sra = Me.EkdosiPnl.Controls.Find("Sra" + Me.DbhotelDataSet.tmimata(i).kwd.ToString, False)
            Aap = Me.EkdosiPnl.Controls.Find("AAp" + Me.DbhotelDataSet.tmimata(i).kwd.ToString, False)
            Sim = Me.EkdosiPnl.Controls.Find("Sim" + Me.DbhotelDataSet.tmimata(i).kwd.ToString + "_" + "TRUE", False) 'koitazw to onoma morfi: SimX_TRUE
            If Sim.Length <> 0 Then
                simetoxi = True
            Else
                simetoxi = False
            End If
            Fp1 = Me.FpaPnl.Controls.Find("Fp1" + Me.DbhotelDataSet.tmimata(i).kwd.ToString, False)
            Fp2 = Me.FpaPnl.Controls.Find("Fp2" + Me.DbhotelDataSet.tmimata(i).kwd.ToString, False)
            Fp3 = Me.FpaPnl.Controls.Find("Fp3" + Me.DbhotelDataSet.tmimata(i).kwd.ToString, False)
            Fp4 = Me.FpaPnl.Controls.Find("Fp4" + Me.DbhotelDataSet.tmimata(i).kwd.ToString, False)
            Fdm = Me.ForoiPnl.Controls.Find("Fdm" + Me.DbhotelDataSet.tmimata(i).kwd.ToString, False)
            Fpd = Me.ForoiPnl.Controls.Find("Fpd" + Me.DbhotelDataSet.tmimata(i).kwd.ToString, False)


            If Tmi(0).Text.Equals("") Then
                Try
                    Me.TmimataTableAdapter.DeleteTmima(Me.DbhotelDataSet.tmimata(i).kwd)
                    refresh = True
                    enimerwsiOK = True
                Catch ex As OleDb.OleDbException
                    MsgBox("Η Διαγραφή του τμήματος " + Me.DbhotelDataSet.tmimata(i).tmima + " απέτυχε", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            Else
                Try
                    Me.TmimataTableAdapter.UpdateTmimata(Tmi(0).Text, Aap(0).Text, Par(0).Text, simetoxi, Fp1(0).Text, Fp2(0).Text, Fp3(0).Text, Fp4(0).Text, Fdm(0).Text, Fpd(0).Text, Sra(0).Text, Me.DbhotelDataSet.tmimata(i).kwd)
                    enimerwsiOK = True
                Catch ex As OleDb.OleDbException
                    MsgBox("Η Αποθήκευση των αλλαγών δεν κατέστη δυνατή!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try
            End If
        Next

        Dim maxkwd As Int16

        For i = Me.DbhotelDataSet.tmimata.Count To (Me.DbhotelDataSet.tmimata.Count + 4)
            Dim simetoxi As Boolean
            Try
                maxkwd = Me.TmimataTableAdapter.MaxKwdiko()
            Catch ex As InvalidOperationException
                maxkwd = 0
            End Try

            Ari = Me.TmimaPnl.Controls.Find("Ari_" + i.ToString, False)
            Tmi = Me.TmimaPnl.Controls.Find("Tmi_" + i.ToString, False)
            If Not Tmi(0).Text.Equals("") Then
                If Ari(0).Text.Equals("") Then
                    Ari(0).Text = maxkwd + 1
                End If
                Par = Me.EkdosiPnl.Controls.Find("Par_" + i.ToString, False)
                Sra = Me.EkdosiPnl.Controls.Find("Sra_" + i.ToString, False)
                Aap = Me.EkdosiPnl.Controls.Find("AAp_" + i.ToString, False)
                Sim = Me.EkdosiPnl.Controls.Find("Simx" + i.ToString + "_" + "TRUE", False) 'koitazw to onoma morfi: SimX_TRUE
                If Sim.Length <> 0 Then
                    simetoxi = True
                Else
                    simetoxi = False
                End If
                Fp1 = Me.FpaPnl.Controls.Find("Fp1_" + i.ToString, False)
                If Fp1(0).Text.Equals("") Then
                    Fp1(0).Text = 0
                End If
                Fp2 = Me.FpaPnl.Controls.Find("Fp2_" + i.ToString, False)
                If Fp2(0).Text.Equals("") Then
                    Fp2(0).Text = 0
                End If
                Fp3 = Me.FpaPnl.Controls.Find("Fp3_" + i.ToString, False)
                If Fp3(0).Text.Equals("") Then
                    Fp3(0).Text = 0
                End If

                Fp4 = Me.FpaPnl.Controls.Find("Fp4_" + i.ToString, False)
                If Fp4(0).Text.Equals("") Then
                    Fp4(0).Text = 0
                End If

                Fdm = Me.ForoiPnl.Controls.Find("Fdm_" + i.ToString, False)
                If Fdm(0).Text.Equals("") Then
                    Fdm(0).Text = 0
                End If

                Fpd = Me.ForoiPnl.Controls.Find("Fpd_" + i.ToString, False)
                If Fpd(0).Text.Equals("") Then
                    Fpd(0).Text = 0
                End If


                Try
                    Me.TmimataTableAdapter.InsertTmima(Ari(0).Text, Tmi(0).Text, Aap(0).Text, Par(0).Text, simetoxi, Fp1(0).Text, Fp2(0).Text, Fp3(0).Text, Fp4(0).Text, Fdm(0).Text, Fpd(0).Text, Sra(0).Text, True)
                    refresh = True
                    enimerwsiOK = True
                Catch ex As Exception
                    MsgBox("Η Εισαγωγή του νέου τμήματος " + Tmi(0).Text + " δεν κατέστη δυνατή!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            End If

        Next



        If refresh Then ' Ananewsi twn Panel meta tin Diagrafi tmimatos
            Me.DbhotelDataSet.tmimata.Clear()
            TmimaPnl.Controls.Clear()
            EkdosiPnl.Controls.Clear()
            FpaPnl.Controls.Clear()
            ForoiPnl.Controls.Clear()
            Me.HauptPnl.Controls.Clear()
            Me.HauptPnl.BorderStyle = BorderStyle.Fixed3D
            Me.HauptPnl.Dock = DockStyle.Fill
            Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True)
            tmimata()
        End If

        If enimerwsiOK Then
            MsgBox(" Επιτυχής Ενημέρωση!", MsgBoxStyle.Information, "winfo\nikEl.")
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub fpaTbx_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            sender.text = CType(sender.text, Single).ToString("F")
        Catch ex As InvalidCastException
            sender.text = "0,00"
        End Try
    End Sub
    Private Sub fpa1Tbx_enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("emfanisi log sxediou")


    End Sub
    '*********************ARITHMOI DWMATIWN*****************************************************************************************
    '*********************ARITHMOI DWMATIWN*****************************************************************************************
    '*********************ARITHMOI DWMATIWN*****************************************************************************************
    Private Sub dwmatia_combo_boxen()
        Dim locx, locy As Int16
        Dim SpeicherButton As New Button
        Dim KlinesCbx, TiposCbx As New ComboBox
        Dim KlinesLbl, TiposLbl As New Label


        KlinesLbl.ForeColor = Color.Blue
        'KlinesLbl.BackColor = Color.Yellow
        KlinesLbl.Text = "Επιλέξτε αριθμό κλινών:"
        KlinesLbl.Size = New Point(160, 20)

        KlinesCbx.Name = "KlinesCbx"
        KlinesCbx.ForeColor = Color.Maroon
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        'EtiketaLbl.ForeColor = Color.Maroon

        EtiketaLbl.Text = " ΑΡΙΘΜΟΙ ΔΩΜΑΤΙΩΝ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        Me.HauptPnl.Controls.Add(EtiketaPnl)
        locx = 50
        locy = 2 * EtiketaLbl.Height + 50
        Me.KlinesTableAdapter.GetAktuelKlines(Me.DbhotelDataSet.klines, maxklines)
        KlinesCbx.DataSource = Me.KlinesBindingSource

        KlinesCbx.DisplayMember = "perigrafi"
        KlinesCbx.Location = New Point(locx, locy)
        KlinesLbl.Location = New Point(locx - 45, locy - 20)

        Me.HauptPnl.Controls.Add(KlinesLbl)
        Me.HauptPnl.Controls.Add(KlinesCbx)

        AddHandler KlinesCbx.SelectedIndexChanged, AddressOf KlinesCbx_index_changed


        TiposLbl.ForeColor = Color.Blue
        'KlinesLbl.BackColor = Color.Yellow
        TiposLbl.Size = New Point(190, 20)
        TiposLbl.Text = "Επιλέξτε κατηγορία (θέα):"



        TiposCbx.DataSource = Me.TipoiBindingSource
        TiposCbx.ForeColor = Color.Maroon
        TiposCbx.DisplayMember = "tipos"

        TiposCbx.Location = New Point(locx + 2 * KlinesCbx.Width, locy)
        TiposLbl.Location = New Point(locx + 2 * KlinesCbx.Width - 50, locy - 20)
        Me.HauptPnl.Controls.Add(TiposLbl)
        Me.HauptPnl.Controls.Add(TiposCbx)

        AddHandler TiposCbx.SelectedIndexChanged, AddressOf TiposCbx_index_changed


        klins = Me.KlinesTableAdapter.GetKwdByPerigrafi(KlinesCbx.Text)
        tips = Me.TipoiTableAdapter.GetKwdByTipo(TiposCbx.Text)
        HauptPnl.Controls.Add(Panel3)
        arithmous_dwmatia_setzen()
    End Sub
    Private Sub KlinesCbx_index_changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.selectedindex <> -1 Then
            'MsgBox(Me.KlinesTableAdapter.GetKwdByPerigrafi(sender.text))
            klins = Me.KlinesTableAdapter.GetKwdByPerigrafi(sender.text)
            arithmous_dwmatia_setzen()

        End If

    End Sub
    Private Sub TiposCbx_index_changed(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If sender.selectedindex <> -1 Then
            'MsgBox(Me.TipoiTableAdapter.GetKwdByTipo(sender.text))
            tips = Me.TipoiTableAdapter.GetKwdByTipo(sender.text)
            arithmous_dwmatia_setzen()
        End If

    End Sub
    Private Sub arithmous_dwmatia_setzen()
        Dim j, locx, locy, stepx, stepy, k, y As Int16
        Dim KlinesCbx() As Control

        Const line As Int16 = 15 ' arithmos dwmatiwn pou emfanizontai se mia seira

        ReDim dwmatalt(0)
        ReDim dwmatneu(0)
        Panel3.Controls.Clear()
        Panel3.Width = 0
        k = 1
        y = 0
        KlinesCbx = Me.HauptPnl.Controls.Find("KlinesCbx", False)


        If klins > 0 And tips > 0 Then
            'MsgBox("kaligoulas")
            Try
                Me.KatigoriesTableAdapter.Fill_Katigoria_klines(Me.DbhotelDataSet.katigories, klins, tips) 'tupel(klines,tipos)->kanonika MONO 1 row epistrofi! 

                Me.DwmatiaTableAdapter.GetDwmatiaByKatigoria(Me.DbhotelDataSet.dwmatia, Me.DbhotelDataSet.katigories(0).kwd)
                Dim TextLbl As New Label
                TextLbl.ForeColor = Color.Blue
                TextLbl.BackColor = Color.Yellow
                TextLbl.Text = "Αριθμοί Δωματίων:"
                TextLbl.Size = New Point(120, 20)
                TextLbl.Location = New Point(KlinesCbx(0).Location.X, KlinesCbx(0).Location.Y + 3 * TextLbl.Height)



                Me.HauptPnl.Controls.Add(TextLbl)
                locx = KlinesCbx(0).Location.X
                locy = KlinesCbx(0).Location.Y + 4 * TextLbl.Height

                'Panel3.Height = Panel2.Height - locy

                Panel3.Location = New Point(locx, locy)
                ReDim dwmatalt(Me.DbhotelDataSet.katigories(0).anzahl - 1)
                ReDim dwmatneu(Me.DbhotelDataSet.katigories(0).anzahl - 1)
                For j = 0 To Me.DbhotelDataSet.katigories(0).anzahl - 1
                    Dim DwmatiaTbx As New TextBox
                    DwmatiaTbx.Name = "Dwm" + j.ToString
                    DwmatiaTbx.MaxLength = 5
                    DwmatiaTbx.TextAlign = HorizontalAlignment.Center
                    DwmatiaTbx.ForeColor = Color.Black
                    Try
                        DwmatiaTbx.Text = Me.DbhotelDataSet.dwmatia(j).arithmos
                        dwmatalt(j) = DwmatiaTbx.Text 'laden ton arithmo dwmatiou kai speichern sto dwmatalt()
                        dwmatneu(j) = dwmatalt(j)
                    Catch ex As IndexOutOfRangeException 'den exoun dwthei akoma arithmoi dwmatiwn (i dynami exei HDH dwthei! Anzahl(j,i)>0 !)
                        dwmatalt(j) = "-1"
                        dwmatneu(j) = "-1"
                    End Try

                    DwmatiaTbx.Size = New Point(45, 30)
                    stepx = DwmatiaTbx.Width + 10
                    stepy = DwmatiaTbx.Height + 20
                    If j Mod (line) = 0 Then
                        k = 1
                        y = y + 1
                    Else
                        k = k + 1
                    End If
                    'MsgBox(y)

                    DwmatiaTbx.Location = New Point(10 + (k - 1) * stepx, 10 + (y - 1) * stepy)

                    Me.Panel3.Controls.Add(DwmatiaTbx)

                    AddHandler DwmatiaTbx.Leave, AddressOf arith_dwmat_leave


                Next
                Dim SpeicherButton As New Button
                SpeicherButton.BackColor = Color.Azure
                SpeicherButton.ForeColor = Color.Maroon
                SpeicherButton.Text = "Αποθήκευση"
                SpeicherButton.Size = New Point(120, 30)
                SpeicherButton.Cursor = Cursors.Hand

                Panel3.Width = stepx * line + 20
                Panel3.Height = stepy * y + 2 * SpeicherButton.Height

                SpeicherButton.Location = New Point(Panel3.Width / 2 - SpeicherButton.Width / 2, 10 + (y - 1) * stepy + 2 * SpeicherButton.Height)
                AddHandler SpeicherButton.Click, AddressOf dwmatia_speichern_Click
                Me.Panel3.Controls.Add(SpeicherButton)


            Catch ex As IndexOutOfRangeException ' Ean DEN yparxei kataxvrish stiw katigories(Tupel(klines,tipos)->Anzahl 0, table katigories  ή ΔΕΝ exoun kataxwrithei noumera dwmatiwn (->Table Dwmatia)

            End Try

        End If

    End Sub
    Private Sub arith_dwmat_leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not sender.text.Equals("") And Not sender.text.Equals("-1") Then
            dwmatneu(CType(sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3), Int16)) = sender.text
        Else 'If sender.text.Equals("") Then
            dwmatneu(CType(sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3), Int16)) = "-1"
        End If


    End Sub
    Private Sub dwmatia_speichern_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim i As Int16
        Dim enimerosiOK As Boolean = False
        Dim dynamiDwm, dynamiKlines As Int16
        Me.Cursor = Cursors.WaitCursor
        For i = 0 To dwmatneu.Length - 1
            If dwmatalt(i) <> dwmatneu(i) AndAlso dwmatalt(i) = "-1" Then
                Try
                    Me.DwmatiaTableAdapter.InsertAritmKatigKlines(dwmatneu(i), Me.DbhotelDataSet.katigories(0).kwd, klins)
                    dwmatalt(i) = dwmatneu(i)
                    enimerosiOK = True
                Catch ex As OleDb.OleDbException
                    MsgBox("Ο Αριθμός δωματίου " + dwmatneu(i) + " υπάρχει ήδη!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            ElseIf dwmatalt(i) <> dwmatneu(i) AndAlso dwmatneu(i) = "-1" Then '
                Try
                    Me.DwmatiaTableAdapter.DeleteArithmo(dwmatalt(i))
                    dwmatalt(i) = "-1"
                    enimerosiOK = True
                Catch ex As OleDb.OleDbException
                    MsgBox("Δεν έγινε η Διαγραφή του αριθμού δωματίου " + dwmatalt(i), MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            ElseIf dwmatalt(i) <> dwmatneu(i) Then
                Try
                    Me.DwmatiaTableAdapter.UpdateAritmos(dwmatneu(i), dwmatalt(i))
                    dwmatalt(i) = dwmatneu(i)
                    enimerosiOK = True
                Catch ex As OleDb.OleDbException
                    MsgBox("Δεν έγινε η αλλαγή του αριθμού δωματίου " + dwmatneu(i), MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            End If
        Next

        If enimerosiOK Then
            Try
                dynamiDwm = Me.DwmatiaTableAdapter.GetDynamiXenodoxeiou()
                dynamiKlines = Me.DwmatiaTableAdapter.GetKlinesXenodoxeiou()
                Me.EtaireiaTableAdapter.UpdateMinDwmatia(dynamiDwm, Me.DbhotelDataSet.etaireia(0).kwd)
                Me.EtaireiaTableAdapter.UpdateminKlinesXenodoxiou(dynamiKlines, Me.DbhotelDataSet.etaireia(0).kwd)
            Catch ex As Exception

            End Try
            arithmous_dwmatia_setzen()
            MsgBox(" Επιτυχής Ενημέρωση!", MsgBoxStyle.Information, "winfo\nikEl.")
        End If

        Me.Cursor = Cursors.Default

    End Sub
    '**************************dynami xenodoxeiou**************************************************************************
    '**************************dynami xenodoxeiou**************************************************************************
    '**************************dynami xenodoxeiou**************************************************************************
    '**************************dynami xenodoxeiou**************************************************************************
    Private Sub katigories_zeig()

        Dim locx, locy, stepx, stepy, i, j, width, height As Int16 'locx-> start x stin foram, stepx bima..ktl
        Dim SpeicherButton As New Button
        'Const maxklines As Int16 = 4 'anwtato orio gia klines dil. edw mexri tetraklina -> kala tha itan sa parametros tou Xenodxeioy 
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        'EtiketaLbl.ForeColor = Color.Maroon

        EtiketaLbl.Text = " ΔΥΝΑΜΗ ΔΩΜΑΤΙΩΝ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        Me.HauptPnl.Controls.Add(EtiketaPnl)
        Me.KlinesTableAdapter.Fill(Me.DbhotelDataSet.klines)
        i = 0
        locx = 140
        locy = 240
        stepy = 40
        stepx = 100
        width = 100
        height = 23
        'Me.KatigoriesTableAdapter.Fill(Me.DbhotelDataSet.katigories)
        'Me.Katigories1TableAdapter.Get_Katigories(Me.DbhotelDataSet.katigories1)
        Dim MaxklinesLbl As New Label
        MaxklinesLbl.Text = "Μάξιμουμ " & vbCrLf & "κλίνες:"
        MaxklinesLbl.ForeColor = Color.Blue
        MaxklinesLbl.TextAlign = ContentAlignment.TopRight
        MaxklinesLbl.Size = New Point(width / 2 + 30, 2 * MaxklinesLbl.Height)

        MaxklinesLbl.Location = New Point(locx - width, locy - 3 * MaxklinesLbl.Height - 0)
        Me.HauptPnl.Controls.Add(MaxklinesLbl)

        Dim MaxklinesTbx As New TextBox
        'MaxklinesTbx.Name = maxklines
        MaxklinesTbx.MaxLength = 1
        MaxklinesTbx.TextAlign = HorizontalAlignment.Center
        MaxklinesTbx.BackColor = Color.Yellow
        MaxklinesTbx.TabStop = False
        MaxklinesTbx.Text = maxklines     'Kalutera apo parametroys xenodoxeiou laden kai an alaksei tote ekei pali speichern
        MaxklinesTbx.Size = New Point(30, 30)
        MaxklinesTbx.Location = New Point(locx, locy - 3 * MaxklinesLbl.Height)
        Me.HauptPnl.Controls.Add(MaxklinesTbx)
        AddHandler MaxklinesTbx.KeyPress, AddressOf MaxklinesTbx_KeyPress

        Dim NeaKatigoriaLbl As New Label
        NeaKatigoriaLbl.Text = "Νέος τύπος" + vbCrLf & "δωματίου:"
        NeaKatigoriaLbl.ForeColor = Color.Blue
        NeaKatigoriaLbl.Size = New Point(width / 2 + 20, 2 * height)
        NeaKatigoriaLbl.Location = New Point(locx + 2 * width / 2 + 20, locy - 3 * 2 * height - 20)
        Me.HauptPnl.Controls.Add(NeaKatigoriaLbl)

        Dim NeaKatigoriaTbx As New TextBox
        NeaKatigoriaTbx.Name = "NeaKatigoria"
        'MaxklinesTbx.MaxLength = 1
        NeaKatigoriaTbx.TextAlign = HorizontalAlignment.Center
        NeaKatigoriaTbx.BackColor = Color.GreenYellow
        NeaKatigoriaTbx.TabStop = False

        'MaxklinesTbx.Size = New Point(30, 30)
        NeaKatigoriaTbx.Location = New Point(locx + 3 * width / 2 + 40, locy - 3 * MaxklinesLbl.Height)
        Me.HauptPnl.Controls.Add(NeaKatigoriaTbx)
        AddHandler NeaKatigoriaTbx.KeyPress, AddressOf NeaKatigoriatbx_keypress
        'AddHandler NeaKatigoriaTbx.Enter, AddressOf NeaKatigoriatbx_enter

        Dim InfoLbl As New Label
        InfoLbl.TextAlign = ContentAlignment.MiddleCenter
        InfoLbl.ForeColor = Color.Black
        InfoLbl.Text = "<Δώστε Max. Κλίνες σε Δωμάτιο και έπειτα πατήστε ENTER!" & vbCrLf & " Δώστε νέο τύπο (θέα) Δωματίου (+ENTER) !" & vbCrLf & "Γιά αλλαγή ονόματος πηγαίνετε στην επικεφαλίδα (+ENTER)" & vbCrLf & _
        "Για Διαγραφή τύπου (μόνο όταν η στήλη έχει μηδενικά)" & vbCrLf & " πηγαίνετε στην επικεφαλίδα και σβήστε το όνομα (+ENTER)>"

        InfoLbl.Size = New Point(500, 70)
        InfoLbl.Location = New Point(locx - 80, locy - 2.2 * MaxklinesLbl.Height)
        HauptPnl.Controls.Add(InfoLbl)

        ReDim katigories(maxklines - 1, Me.DbhotelDataSet.tipoi.Count - 1)
        ReDim kwdikoitipwn(Me.DbhotelDataSet.tipoi.Count - 1)
        ReDim kwdikoiklinwn(Me.DbhotelDataSet.klines.Count - 1)
        For j = 1 To maxklines  ' tha mporoyse na dothei sa paramertiko pedio stous prametroys tou xenodoxeio san MEGISTOS arithm. klinwn se dwmatio

            Dim KlinesLbl As New Label
            KlinesLbl.TextAlign = ContentAlignment.MiddleCenter
            'KlinesLbl.Enabled = False
            KlinesLbl.ForeColor = Color.Blue
            KlinesLbl.BackColor = Color.Yellow
            KlinesLbl.TabStop = False
            KlinesLbl.Size = New Point(120, 20)
            kwdikoiklinwn(j - 1) = Me.DbhotelDataSet.klines(j - 1).kwd
            Select Case Me.DbhotelDataSet.klines(j - 1).kwd 'Klines!

                Case 1
                    KlinesLbl.Text = Me.DbhotelDataSet.klines(j - 1).perigrafi
                    KlinesLbl.Location = New Point(locx - width, locy + stepy * (j - 1))

                Case 2
                    KlinesLbl.Text = Me.DbhotelDataSet.klines(j - 1).perigrafi
                    KlinesLbl.Location = New Point(locx - width, locy + stepy * (j - 1))

                Case 3
                    KlinesLbl.Text = Me.DbhotelDataSet.klines(j - 1).perigrafi
                    KlinesLbl.Location = New Point(locx - width, locy + stepy * (j - 1))
                Case 4
                    KlinesLbl.Text = Me.DbhotelDataSet.klines(j - 1).perigrafi
                    KlinesLbl.Location = New Point(locx - width, locy + stepy * (j - 1))
                Case 5
                    KlinesLbl.Text = Me.DbhotelDataSet.klines(j - 1).perigrafi
                    KlinesLbl.Location = New Point(locx - width, locy + stepy * (j - 1))
                Case 6
                    KlinesLbl.Text = Me.DbhotelDataSet.klines(j - 1).perigrafi
                    KlinesLbl.Location = New Point(locx - width, locy + stepy * (j - 1))
                Case 7
                    KlinesLbl.Text = Me.DbhotelDataSet.klines(j - 1).perigrafi
                    KlinesLbl.Location = New Point(locx - width, locy + stepy * (j - 1))
                Case 8
                    KlinesLbl.Text = Me.DbhotelDataSet.klines(j - 1).perigrafi
                    KlinesLbl.Location = New Point(locx - width, locy + stepy * (j - 1))
                Case 9
                    KlinesLbl.Text = Me.DbhotelDataSet.klines(j - 1).perigrafi
                    KlinesLbl.Location = New Point(locx - width, locy + stepy * (j - 1))

            End Select

            For i = 0 To Me.DbhotelDataSet.tipoi.Count - 1 'Anzahl ana tipo i

                If j = 1 Then

                    Dim KatigTbx As New TextBox
                    'KatigTbx.Name = "KatigTbx" + i.ToString
                    KatigTbx.TextAlign = HorizontalAlignment.Center
                    KatigTbx.Name = "KatigTbx" + j.ToString + "_" + i.ToString
                    KatigTbx.ForeColor = Color.Blue
                    KatigTbx.BackColor = Color.GreenYellow
                    KatigTbx.TabStop = False
                    KatigTbx.Size = New Point(100, 20)
                    KatigTbx.Text = Me.DbhotelDataSet.tipoi(i).tipos
                    'MsgBox(KatigLbl.Text)
                    KatigTbx.Location = New Point(locx - 30 + stepx * i, locy - height)
                    kwdikoitipwn(i) = Me.DbhotelDataSet.tipoi(i).kwd

                    Me.HauptPnl.Controls.Add(KatigTbx)
                    AddHandler KatigTbx.Enter, AddressOf KatigTbx_enter
                    AddHandler KatigTbx.KeyPress, AddressOf KatigTbx_keypress
                End If
                'MsgBox(kwdikoitipwn(3))
                Dim AnzTbx As New TextBox
                AnzTbx.Name = "Anz" + (j - 1).ToString + "_" + i.ToString
                AnzTbx.TextAlign = HorizontalAlignment.Center
                AnzTbx.MaxLength = 3
                AnzTbx.Size = New Point(40, 40)
                AnzTbx.Location = New Point(locx + stepx * i, locy + stepy * (j - 1))
                'rwtaw ana klines-tipo-> to tupel (klines,tipos) prepei na einai MONADIKO (->den to kaluptei i Database )
                Me.KatigoriesTableAdapter.Fill_Katigoria_klines(Me.DbhotelDataSet.katigories, j, Me.DbhotelDataSet.tipoi(i).kwd)
                If Me.DbhotelDataSet.katigories.Count <> 0 Then
                    AnzTbx.Text = Me.DbhotelDataSet.katigories(0).anzahl
                    AnzTbx.ForeColor = Color.Red
                    katigories(j - 1, i) = AnzTbx.Text
                Else
                    AnzTbx.Text = 0
                    katigories(j - 1, i) = AnzTbx.Text
                End If
                AddHandler AnzTbx.Leave, AddressOf AnzBox_Leave
                'AddHandler AnzTbx.KeyPress, AddressOf AnzBox_KeyPress
                Me.HauptPnl.Controls.Add(AnzTbx)
                Me.HauptPnl.Controls.Add(KlinesLbl)
            Next

        Next
        SpeicherButton.ForeColor = Color.Maroon
        SpeicherButton.Text = "Αποθήκευση"
        SpeicherButton.Size = New Point(120, 30)
        SpeicherButton.Cursor = Cursors.Hand
        SpeicherButton.Location = New Point((locx + stepx * Me.DbhotelDataSet.tipoi.Count - 1) / 2, locy + stepy * (j - 1))
        AddHandler SpeicherButton.Click, AddressOf katigories_Speichern_Click
        Me.HauptPnl.Controls.Add(SpeicherButton)

    End Sub
    Private Sub katigories_Speichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim j, i, kwdikos, maxDwm As Int16
        'MsgBox(katigories.GetLength(0))
        'MsgBox(katigories.GetLength(1))

        Me.Cursor = Cursors.WaitCursor


        For j = 0 To katigories.GetLength(0) - 1    'Length ana dimension abfragen -> j klines, i tipos dwmatiou
            For i = 0 To katigories.GetLength(1) - 1
                'MsgBox(Me.KatigoriesTableAdapter.Get_Kwd_ByklinesTipos(j + 1, i + 1))
                Try
                    kwdikos = Me.KatigoriesTableAdapter.Get_Kwd_ByklinesTipos(kwdikoiklinwn(j), kwdikoitipwn(i))
                    If kwdikos > 0 Then
                        If katigories(j, i) > 0 Then
                            If Me.DwmatiaTableAdapter.AnzahlAnaKatigoria(kwdikos).ToString <= katigories(j, i) Then
                                Try
                                    Me.KatigoriesTableAdapter.UpdateAnzahl(katigories(j, i), kwdikos) 'diaforetika apla UPDATE
                                Catch ex As OleDb.OleDbException
                                    MsgBox("Παρουσιάστηκε πρόβλημα στην Ενημέρωση!", MsgBoxStyle.Critical, "winfo\nikEl.")
                                End Try
                            Else

                                MsgBox("Υπάρχουν περισσότεροι συνδεμένοι αριθμοί Δωμάτιων ! ", MsgBoxStyle.Exclamation, "winfo\nikEl.")


                            End If

                        Else
                            If Me.DwmatiaTableAdapter.AnzahlAnaKatigoria(kwdikos).ToString = 0 Then
                                Try
                                    'MsgBox(kwdikos)
                                    Me.KatigoriesTableAdapter.DeleteEintrag(kwdikos)
                                Catch ex As OleDb.OleDbException
                                    MsgBox(" Διαγράψτε πρώτα τους  συνδεμένους Αριθμούς δωματίων πρίν μηδενίσετε την Δυναμικότητα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                                End Try
                            Else
                                MsgBox(" Διαγράψτε πρώτα τους συνδεμένους Αριθμούς δωματίων πρίν μηδενίσετε την Δυναμικότητα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            End If


                        End If


                    End If

                Catch ex As InvalidOperationException
                    'MsgBox(katigories(j, i))
                    If katigories(j, i) > 0 Then
                        'Me.TipoiTableAdapter.CountTipoi(i)
                        Try
                            Me.KatigoriesTableAdapter.Insertkatigoria(kwdikoiklinwn(j), kwdikoitipwn(i), katigories(j, i))

                        Catch exe As OleDb.OleDbException
                            MsgBox("Παρουσιάστηκε πρόβλημα στην Ενημέρωση!", MsgBoxStyle.Critical, "winfo\nikEl.")
                        End Try
                        'MsgBox(kwdikoitipwn(i))


                    End If
                End Try
            Next
        Next
        Try
            If maxklines <> Me.DbhotelDataSet.etaireia(0).maxklines Then
                Me.EtaireiaTableAdapter.UpdateMaxKlinesDwmatiou(maxklines, Me.DbhotelDataSet.etaireia(0).kwd)
            End If
            Try
                maxDwm = Me.KatigoriesTableAdapter.AnzahlBy()
                Me.EtaireiaTableAdapter.UpdateMaxDwmatia(maxDwm, Me.DbhotelDataSet.etaireia(0).kwd)
            Catch ex As InvalidOperationException

            End Try
        Catch ex As InvalidCastException
            MsgBox("Δώστε αριθμό κλινών μεγαλύτερου Δωματίου !", MsgBoxStyle.Critical, "winfo\nikEl.")
            Exit Sub
        End Try
        MsgBox(" Επιτυχής Ενημέρωση!", MsgBoxStyle.Information, "winfo\nikEl.")

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub NeaKatigoriatbx_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Me.TipoiTableAdapter.InsertKatigoria(sender.text, "")
            Me.HauptPnl.Controls.Clear()
            Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
            Me.HauptPnl.Dock = DockStyle.Fill
            'MsgBox("ok12")
            Me.TipoiTableAdapter.Fill(Me.DbhotelDataSet.tipoi)
            katigories_zeig()
        End If

    End Sub

    Private Sub MaxklinesTbx_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Try
                If sender.text > 0 Then
                    'MsgBox("ok")
                    maxklines = sender.text
                    Me.HauptPnl.Controls.Clear()
                    Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                    Me.HauptPnl.Dock = DockStyle.Fill
                    'MsgBox("ok12")
                    katigories_zeig()
                End If
            Catch ex As InvalidCastException
                sender.clear()
            End Try

        End If


    End Sub
    'Private Sub NeaKatigoriatbx_enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    MsgBox("Δώστε νέο τύπο (θέα) Δωματίου και επειτα πατήστε ENTER !" & vbCrLf & "Γιά αλλαγή ονόματος πηγαίνετε στην επικεφαλίδα (+ENTER)" & vbCrLf & _
    '    "Για Διαγραφή (εάν η στήλη εχει ΜΟΝΟ μηδενικά)" & vbCrLf & " πηγαίνετε στην επικεφαλίδα και σβήστε το όνομα (+ENTER)", MsgBoxStyle.Information, "winfo\nikEl.")
    'End Sub
    Private Sub KatigTbx_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim split As String() = sender.NAME.ToString.Substring(8, sender.NAME.ToString.Length - 8).Split(New [Char]() {"_"c})

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            If Not sender.text.Equals("") Then
                Try
                    Me.TipoiTableAdapter.UpdateTipo(sender.text, kwdikoitipwn(split(1)))
                    MsgBox("Ο τύπος (θέα) Δωματίου άλλαξε επιτυχώς !", MsgBoxStyle.Information, "winfo\nikEl.")
                Catch ex As Exception
                    MsgBox("Η αλλαγή τύπος (θέα) Δωματίου δεν κατέστη δυνατή !", MsgBoxStyle.Critical, "winfo\nikEl.")
                End Try

            Else
                'MsgBox(Me.KatigoriesTableAdapter.ExistEintrag(kwdikoitipwn(split(1))))
                'MsgBox(kwdikoitipwn(split(1)))
                If CType(Me.KatigoriesTableAdapter.ExistEintrag(kwdikoitipwn(split(1))), Integer) = 0 Then
                    Try
                        Me.KatigoriesTableAdapter.DeleteTipos(kwdikoitipwn(split(1)))
                        Me.TipoiTableAdapter.DeleteTipo(kwdikoitipwn(split(1)))
                        Me.HauptPnl.Controls.Clear()
                        Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                        Me.HauptPnl.Dock = DockStyle.Fill

                        Me.TipoiTableAdapter.Fill(Me.DbhotelDataSet.tipoi)
                        Me.KatigoriesTableAdapter.Fill(Me.DbhotelDataSet.katigories)
                        katigories_zeig()
                        MsgBox("Ο τύπος (θέα) Δωματίου διαγράφηκε επιτυχώς !", MsgBoxStyle.Information, "winfo\nikEl.")
                    Catch ex As Exception
                        MsgBox("Η Διαγραφή τύπου (θέας) Δωματίου απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    End Try
                Else
                    MsgBox(" Για να γίνει Διαγραφή δεν πρεπει να υπάρχουν Δωμάτια  αυτού του τύπου" & vbCrLf & _
                    "στο Ξενοδοχείο: H στήλη πρέπει να περιέχει μόνο μηδενικά !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    Me.TipoiTableAdapter.GetTiposByKwd(Me.DbhotelDataSet.tipoi, kwdikoitipwn(split(1)))
                    sender.Text = Me.DbhotelDataSet.tipoi(0).tipos
                    Me.DbhotelDataSet.tipoi.Clear()
                    Me.TipoiTableAdapter.Fill(Me.DbhotelDataSet.tipoi)
                End If
            End If
        End If

    End Sub
    Private Sub KatigTbx_enter(ByVal sender As Object, ByVal e As System.EventArgs)
        MsgBox("Αλλάξτε το ονομα και πατήστε (+ENTER)" & vbCrLf & _
        "Διαγράψτε τον τύπο Δωματιου σβήνωντας απλα το ονομα (+ENTER)" & vbCrLf & _
        "(Για Διαγραφή πρεπει η στήλη να περιέχει ΜΟΝΟ μηδενικά!)", MsgBoxStyle.Information, "winfo\nikEl.")
    End Sub
    Private Sub AnzBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles TextBox1.Leave
        'Substring 3 giati to NAME tou textbox einai 'ANZj_i' ara 3 mprosta feugoun aki meta SPLIT sto "_" gia na dw se pio ARRAY(j,i) apothikeuw
        Dim split As String() = sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3).Split(New [Char]() {"_"c})
        Try
            If CType(sender.text, Int16) > 0 Then
                sender.forecolor = Color.Red
                'MsgBox(split(0))
                'MsgBox(split(1))
                katigories(split(0), split(1)) = sender.text
            Else
                sender.text = 0
                katigories(split(0), split(1)) = sender.text
                sender.forecolor = Color.Black
            End If
        Catch ex As InvalidCastException
            sender.text = 0
            katigories(split(0), split(1)) = sender.text
            sender.forecolor = Color.Black
        End Try
    End Sub

    Private Function get_kwd_klins_byname(ByVal name As String) As Integer

        Try
            Return Me.KlinesTableAdapter.GetKwdByPerigrafi(name)
        Catch ex As Exception
            Return -1
        End Try


    End Function
    Private Function get_kwd_tipos_byname(ByVal name As String) As Integer

        Try
            Return Me.TipoiTableAdapter.GetKwdByTipo(name)
        Catch ex As Exception
            Return -1
        End Try


    End Function
    Private Sub xores_zeig()
        Dim locx, locy, stepy, i As Int16
        locx = 80
        locy = 120
        stepy = 20
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        Me.HauptPnl.Controls.Add(EtiketaPnl)
        EtiketaPnl.Location = New Point(5, 5)
        'EtiketaLbl.ForeColor = Color.Maroon

        EtiketaLbl.Text = "ΧΩΡΕΣ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 180, 25)

        Me.XoresTableAdapter.Fill(Me.DbhotelDataSet.xores)
        Dim sires As Int16 = 14

        If Me.DbhotelDataSet.xores.Count <= sires Then
            sires = Me.DbhotelDataSet.xores.Count
        End If

        Dim k As Int16 = 0

        For i = 0 To Me.DbhotelDataSet.xores.Count - 1

            Dim CountLbl As New Label
            Dim SintomTbx, EthnosTbx As New TextBox

            CountLbl.TextAlign = ContentAlignment.MiddleCenter
            CountLbl.ForeColor = Color.Blue
            SintomTbx.TextAlign = HorizontalAlignment.Center
            SintomTbx.MaxLength = 3
            SintomTbx.ForeColor = Color.Maroon
            EthnosTbx.TextAlign = HorizontalAlignment.Center
            EthnosTbx.MaxLength = 20
            CountLbl.Name = "Cnt" + Me.DbhotelDataSet.xores(i).kwd.ToString
            CountLbl.Text = Me.DbhotelDataSet.xores(i).kwd
            SintomTbx.Name = "Snt" + Me.DbhotelDataSet.xores(i).kwd.ToString
            SintomTbx.Text = Me.DbhotelDataSet.xores(i).sintomeusi
            EthnosTbx.Name = "Xor" + Me.DbhotelDataSet.xores(i).kwd.ToString
            EthnosTbx.Text = Me.DbhotelDataSet.xores(i).xora
            CountLbl.Size = New Point(30, 20)
            SintomTbx.Size = New Point(35, 20)
            EthnosTbx.Size = New Point(100, 20)
            Me.HauptPnl.Controls.Add(CountLbl)
            Me.HauptPnl.Controls.Add(SintomTbx)
            Me.HauptPnl.Controls.Add(EthnosTbx)
            CountLbl.Location = New Point(locx, locy + stepy * k)
            SintomTbx.Location = New Point(CountLbl.Width + locx, locy + stepy * k)
            EthnosTbx.Location = New Point(locx + CountLbl.Width + SintomTbx.Width, locy + stepy * k)

            If i = Me.DbhotelDataSet.xores.Count - 1 Then
                neue_xora_boxen(locx, locy + stepy * (k + 1), Me.XoresTableAdapter.Counter)
            End If

            If sires = (k + 1) Then
                locx = locx + CountLbl.Width + SintomTbx.Width + EthnosTbx.Width
                k = 0
            Else
                k = k + 1
            End If
        Next

    End Sub
    Private Sub neue_xora_boxen(ByVal locx As Int16, ByVal locy As Int16, ByVal count As Int16)

        Dim Lbl, CountLbl As New Label
        Dim SintomTbx, EthnosTbx As New TextBox
        Dim SpeicherButton As New Button

        'Lbl.TextAlign = ContentAlignment.MiddleRight
        'Lbl.ForeColor = Color.Blue
        'Lbl.Text = "Νέα:"
        CountLbl.TextAlign = ContentAlignment.MiddleCenter
        CountLbl.ForeColor = Color.Blue
        SpeicherButton.ForeColor = Color.Maroon
        SintomTbx.TextAlign = HorizontalAlignment.Center
        SintomTbx.MaxLength = 3
        EthnosTbx.TextAlign = HorizontalAlignment.Center
        EthnosTbx.MaxLength = 20
        SpeicherButton.Cursor = Cursors.Hand
        CountLbl.Name = "Count_neu"
        CountLbl.Text = count + 1
        SintomTbx.Name = "Sintom_neu"

        EthnosTbx.Name = "Ethnos_neu"
        SpeicherButton.Text = "Αποθήκευση"
        Lbl.Size = New Point(100, 20)
        CountLbl.Size = New Point(30, 20)
        SintomTbx.Size = New Point(30, 20)
        EthnosTbx.Size = New Point(100, 20)
        SpeicherButton.Size = New Point(130, 20)
        'Me.Panel1.Controls.Add(Lbl)
        Me.HauptPnl.Controls.Add(CountLbl)
        Me.HauptPnl.Controls.Add(SintomTbx)
        Me.HauptPnl.Controls.Add(EthnosTbx)
        Me.HauptPnl.Controls.Add(SpeicherButton)
        CountLbl.Location = New Point(locx, locy)
        Lbl.Location = New Point(locx - Lbl.Width, locy)
        SintomTbx.Location = New Point(CountLbl.Width + locx, locy)
        EthnosTbx.Location = New Point(locx + CountLbl.Width + SintomTbx.Width, locy)
        SpeicherButton.Location = New Point(CountLbl.Width + locx, locy + 2 * CountLbl.Height)

        AddHandler SpeicherButton.Click, AddressOf Xores_Speichern_Click
    End Sub
    Private Sub Xores_Speichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim count(), sintom(), ethnos() As Control
        Dim i As Int16

        Me.Cursor = Cursors.WaitCursor

        count = Me.HauptPnl.Controls.Find("Count_neu", False)
        sintom = Me.HauptPnl.Controls.Find("Sintom_neu", False)
        ethnos = Me.HauptPnl.Controls.Find("Ethnos_neu", False)
        If Not (ethnos(0).Text.Equals("") OrElse sintom(0).Equals("")) Then
            Try
                Me.XoresTableAdapter.InsertXora(count(0).Text, sintom(0).Text, ethnos(0).Text)
            Catch ex As OleDb.OleDbException
                MsgBox("Δεν πέτυχε η Αποθήκευση !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Me.Cursor = Cursors.Default
            End Try

            'MsgBox("ok APOTHIKEUSI")
        End If

        For i = 0 To Me.DbhotelDataSet.xores.Count - 1
            sintom = Me.HauptPnl.Controls.Find("Snt" + Me.DbhotelDataSet.xores(i).kwd.ToString, False)
            ethnos = Me.HauptPnl.Controls.Find("Xor" + Me.DbhotelDataSet.xores(i).kwd.ToString, False)
            count = Me.HauptPnl.Controls.Find("Cnt" + Me.DbhotelDataSet.xores(i).kwd.ToString, False)

            Try
                Me.XoresTableAdapter.UpdateXores(sintom(0).Text, ethnos(0).Text, count(0).Text)

                'Me.XoresTableAdapter.UpdateXores(sintom(0).Text, ethnos(0).Text, count(0).Text)
            Catch ex As OleDb.OleDbException
                MsgBox("Δεν πέτυχε η Ενημέρωση !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Me.Cursor = Cursors.Default
            End Try

        Next
        Me.HauptPnl.Controls.Clear()
        xores_zeig()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ethnikotites_zeig()
        Dim locx, locy, stepy, i As Int16
        locx = 80
        locy = 120
        stepy = 20
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        Me.HauptPnl.Controls.Add(EtiketaPnl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaLbl.Text = "ΕΘΝΙΚΟΤΗΤΕΣ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 180, 25)
        Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)

        Dim sires As Int16 = 14

        If Me.DbhotelDataSet.ethnikotites.Count <= sires Then
            sires = Me.DbhotelDataSet.ethnikotites.Count
        End If

        Dim k As Int16 = 0

        For i = 0 To Me.DbhotelDataSet.ethnikotites.Count - 1
            Dim CountLbl As New Label
            Dim SintomTbx, EthnosTbx As New TextBox
            CountLbl.TextAlign = ContentAlignment.MiddleCenter
            CountLbl.ForeColor = Color.Blue
            SintomTbx.TextAlign = HorizontalAlignment.Center
            SintomTbx.MaxLength = 3
            SintomTbx.ForeColor = Color.Maroon
            EthnosTbx.TextAlign = HorizontalAlignment.Center
            EthnosTbx.MaxLength = 20
            CountLbl.Name = "Lbl" + Me.DbhotelDataSet.ethnikotites(i).kwd.ToString
            CountLbl.Text = Me.DbhotelDataSet.ethnikotites(i).kwd
            SintomTbx.Name = "Sin" + Me.DbhotelDataSet.ethnikotites(i).kwd.ToString
            SintomTbx.Text = Me.DbhotelDataSet.ethnikotites(i).sintomeusi
            EthnosTbx.Name = "Eth" + Me.DbhotelDataSet.ethnikotites(i).kwd.ToString
            EthnosTbx.Text = Me.DbhotelDataSet.ethnikotites(i).ethnikotita
            CountLbl.Size = New Point(30, 20)
            SintomTbx.Size = New Point(35, 20)
            EthnosTbx.Size = New Point(100, 20)
            Me.HauptPnl.Controls.Add(CountLbl)
            Me.HauptPnl.Controls.Add(SintomTbx)
            Me.HauptPnl.Controls.Add(EthnosTbx)
            CountLbl.Location = New Point(locx, locy + stepy * k)
            SintomTbx.Location = New Point(CountLbl.Width + locx, locy + stepy * k)
            EthnosTbx.Location = New Point(locx + CountLbl.Width + SintomTbx.Width, locy + stepy * k)

            If i = Me.DbhotelDataSet.ethnikotites.Count - 1 Then
                neue_ethnikotita_boxen(locx, locy + stepy * (k + 1), Me.EthnikotitesTableAdapter.Counter)
            End If

            If sires = (k + 1) Then
                locx = locx + CountLbl.Width + SintomTbx.Width + EthnosTbx.Width
                k = 0
            Else
                k = k + 1
            End If


        Next

    End Sub

    Private Sub neue_ethnikotita_boxen(ByVal locx As Int16, ByVal locy As Int16, ByVal count As Int16)

        Dim Lbl, CountLbl As New Label
        Dim SintomTbx, EthnosTbx As New TextBox
        Dim SpeicherButton As New Button

        'Lbl.TextAlign = ContentAlignment.MiddleRight
        'Lbl.ForeColor = Color.Blue
        'Lbl.Text = "Νέα:"
        CountLbl.TextAlign = ContentAlignment.MiddleCenter
        CountLbl.ForeColor = Color.Blue
        SpeicherButton.ForeColor = Color.Maroon
        SintomTbx.TextAlign = HorizontalAlignment.Center
        SintomTbx.MaxLength = 3
        EthnosTbx.TextAlign = HorizontalAlignment.Center
        EthnosTbx.MaxLength = 20
        SpeicherButton.Cursor = Cursors.Hand
        CountLbl.Name = "Count_neu"
        CountLbl.Text = count + 1
        SintomTbx.Name = "Sintom_neu"

        EthnosTbx.Name = "Ethnos_neu"
        SpeicherButton.Text = "Αποθήκευση"
        Lbl.Size = New Point(100, 20)
        CountLbl.Size = New Point(30, 20)
        SintomTbx.Size = New Point(30, 20)
        EthnosTbx.Size = New Point(100, 20)
        SpeicherButton.Size = New Point(130, 20)
        'Me.Panel1.Controls.Add(Lbl)
        Me.HauptPnl.Controls.Add(CountLbl)
        Me.HauptPnl.Controls.Add(SintomTbx)
        Me.HauptPnl.Controls.Add(EthnosTbx)
        Me.HauptPnl.Controls.Add(SpeicherButton)
        CountLbl.Location = New Point(locx, locy)
        Lbl.Location = New Point(locx - Lbl.Width, locy)
        SintomTbx.Location = New Point(CountLbl.Width + locx, locy)
        EthnosTbx.Location = New Point(locx + CountLbl.Width + SintomTbx.Width, locy)
        SpeicherButton.Location = New Point(CountLbl.Width + locx, locy + 2 * CountLbl.Height)

        AddHandler SpeicherButton.Click, AddressOf Button_Speichern_Click
    End Sub
    Private Sub Button_Speichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim count(), sintom(), ethnos() As Control
        Dim i As Int16

        Me.Cursor = Cursors.WaitCursor

        count = Me.HauptPnl.Controls.Find("Count_neu", False)
        sintom = Me.HauptPnl.Controls.Find("Sintom_neu", False)
        ethnos = Me.HauptPnl.Controls.Find("Ethnos_neu", False)
        If Not (ethnos(0).Text.Equals("") OrElse sintom(0).Equals("")) Then
            Try
                Me.EthnikotitesTableAdapter.InsertEthnos(count(0).Text, sintom(0).Text, ethnos(0).Text)
            Catch ex As OleDb.OleDbException
                MsgBox("Δεν πέτυχε η Αποθήκευση !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Me.Cursor = Cursors.Default
            End Try

            'MsgBox("ok APOTHIKEUSI")
        End If

        For i = 0 To Me.DbhotelDataSet.ethnikotites.Count - 1
            count = Me.HauptPnl.Controls.Find("Lbl" + Me.DbhotelDataSet.ethnikotites(i).kwd.ToString, False)
            sintom = Me.HauptPnl.Controls.Find("Sin" + Me.DbhotelDataSet.ethnikotites(i).kwd.ToString, False)
            ethnos = Me.HauptPnl.Controls.Find("Eth" + Me.DbhotelDataSet.ethnikotites(i).kwd.ToString, False)
            Try
                Me.EthnikotitesTableAdapter.UpdateEthnos(sintom(0).Text, ethnos(0).Text, count(0).Text)
            Catch ex As OleDb.OleDbException
                MsgBox("Δεν πέτυχε η Ενημέρωση !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Me.Cursor = Cursors.Default
            End Try

        Next
        Me.HauptPnl.Controls.Clear()
        ethnikotites_zeig()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ektiposi_ethnikotites()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New Ethnikotites()

        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)
        Me.XoresTableAdapter.Fill(Me.DbhotelDataSet.xores)


        'Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(praktStKwd)
        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'sender.Enabled = False
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
    '*********EMAIL *********EMAIL *********EMAIL *********EMAIL *********EMAIL *********EMAIL *********EMAIL 
    '*********EMAIL *********EMAIL *********EMAIL *********EMAIL *********EMAIL *********EMAIL *********EMAIL 
    '*********EMAIL *********EMAIL *********EMAIL *********EMAIL *********EMAIL *********EMAIL *********EMAIL 
    Private Sub email_settings()
        'locy = 2 * EtiketaLbl.Height + 80
        EtiketaPnl.Size = New Point(482, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "ΣΤΟΙΧΕΙΑ e-MAIL ΑΝΑΧΩΡΗΣΗ "
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 150, EtiketaPnl.Height / 2)

        emailPnl.Size = New Point(482, 410)
        emailPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        'emailPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(emailPnl)
        fuehle_mail_felder()
    End Sub
    Private Sub fuehle_mail_felder()
        Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter

        mailadapter.Fill(Me.DbhotelDataSet.Mail)
        fromTbx.Text = Me.DbhotelDataSet.Mail(0).ffrom
        subjectTbx.Text = Me.DbhotelDataSet.Mail(0).subject
        attachTbx.Text = Me.DbhotelDataSet.Mail(0).attachment
        bodyRTbx.Text = Me.DbhotelDataSet.Mail(0).body
        serverTbx.Text = Me.DbhotelDataSet.Mail(0).smtpServer
        userTbx.Text = Me.DbhotelDataSet.Mail(0).smtpUsername
        PswdMTbx.Text = Me.DbhotelDataSet.Mail(0).smtpPassword

    End Sub
    Private Sub emailBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles emailBtn.Click
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim command As New OleDb.OleDbCommand()
            'Dim myReader As OleDb.OleDbDataReader
            connection.Open()
            command.Connection = connection
            command.Parameters.AddWithValue("ffrom", fromTbx.Text)
            command.Parameters.AddWithValue("subject", subjectTbx.Text)
            command.Parameters.AddWithValue("body", bodyRTbx.Text)
            command.Parameters.AddWithValue("attachment", attachTbx.Text)
            command.Parameters.AddWithValue("smtpServer", serverTbx.Text)
            command.Parameters.AddWithValue("smtpUsername", userTbx.Text)
            command.Parameters.AddWithValue("smtpPassword", PswdMTbx.Text)
            command.CommandText = "UPDATE Mail SET ffrom=?,subject=?,body=?,attachment=?,smtpServer=?,smtpUsername=?,smtpPassword=? WHERE (kwd=1)" '  FROM parastatika INNER JOIN afm ON parastatika.etaireia=afm.kwd WHERE (parastatika.kwd=?)" 'and (identifikation=?)
            command.ExecuteNonQuery()
            ' Always call Read before accessing data.
        End Using

    End Sub
    Private Sub email_agencies_settings()
        'locy = 2 * EtiketaLbl.Height + 80
        EtiketaPnl.Size = New Point(482, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "e-MAIL to agencies"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 100, EtiketaPnl.Height / 2)

        emailagPnl.Size = New Point(482, 248)
        emailagPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        'emailPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(emailagPnl)
        fuehle_mail_ag_felder()
    End Sub
    Private Sub emailagBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles emailagBtn.Click
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim command As New OleDb.OleDbCommand()
            'Dim myReader As OleDb.OleDbDataReader
            connection.Open()
            command.Connection = connection
            command.Parameters.AddWithValue("subject", subjectagTbx.Text)
            command.Parameters.AddWithValue("body", bodyagRTbx.Text)
            command.CommandText = "UPDATE Mail SET subject=?,body=? WHERE (kwd=2)" '  FROM parastatika INNER JOIN afm ON parastatika.etaireia=afm.kwd WHERE (parastatika.kwd=?)" 'and (identifikation=?)
            command.ExecuteNonQuery()
            ' Always call Read before accessing data.
        End Using
    End Sub
    Private Sub fuehle_mail_ag_felder()
        Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter

        mailadapter.Fill(Me.DbhotelDataSet.Mail)
        subjectagTbx.Text = Me.DbhotelDataSet.Mail(1).subject
        bodyagRTbx.Text = Me.DbhotelDataSet.Mail(1).body

    End Sub
    Private Sub email_arrival_settings()
        'locy = 2 * EtiketaLbl.Height + 80
        EtiketaPnl.Size = New Point(482, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "e-MAIL with Directions"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 100, EtiketaPnl.Height / 2)

        directPnl.Size = New Point(482, 248)
        directPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        'emailPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(directPnl)
        fuehle_mail_directions_felder()
    End Sub
    Private Sub fuehle_mail_directions_felder()
        Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter

        mailadapter.Fill(Me.DbhotelDataSet.Mail)
        If Me.DbhotelDataSet.Mail.Count >= 3 Then
            directSubject.Text = Me.DbhotelDataSet.Mail(2).subject
            directBody.Text = Me.DbhotelDataSet.Mail(2).body
        End If
    

    End Sub
    Private Sub directionBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles directBtn.Click
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim command As New OleDb.OleDbCommand()
            'Dim myReader As OleDb.OleDbDataReader
            connection.Open()
            command.Connection = connection
            command.Parameters.AddWithValue("subject", directSubject.Text)
            command.Parameters.AddWithValue("body", directBody.Text)
            command.CommandText = "UPDATE Mail SET subject=?,body=? WHERE (kwd=3)" '  FROM parastatika INNER JOIN afm ON parastatika.etaireia=afm.kwd WHERE (parastatika.kwd=?)" 'and (identifikation=?)
            command.ExecuteNonQuery()
            ' Always call Read before accessing data.
        End Using
    End Sub
    Private Sub selectall(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.SelectAll()

    End Sub
    Private Sub komma_einschalten(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        Select Case e.KeyChar
            ' Modify '.' to ',' and forward the key.
            Case ChrW(46)
                e.KeyChar = ","
                e.Handled = False
                ' Modify 'b' to 'a' and forward the key.
        End Select


    End Sub

    Private Sub ParametroiF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Finalize()
        Me.Dispose()
    End Sub
    Private Sub AllotmentF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.SeasonsTableAdapter.Fill(Me.DbhotelDataSet.seasons)
        'TODO: This line of code loads data into the 'DbhotelDataSet.praktoreia' table. You can move, or remove it, as needed.
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.xrewseis' table. You can move, or remove it, as needed.
        Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
        'TODO: This line of code loads data into the 'DbhotelDataSet.users' table. You can move, or remove it, as needed.
        'Me.UsersTableAdapter.Fill(Me.DbhotelDataSet.users)
        'TODO: This line of code loads data into the 'DbhotelDataSet.pistwtikes' table. You can move, or remove it, as needed.
        currentuser = 1 'Ocurrent User 1=admin ,ktl. tha erthei san Parametros apo to Aufruf
        Me.PistwtikesTableAdapter.Fill(Me.DbhotelDataSet.pistwtikes)
        'TODO: This line of code loads data into the 'DbhotelDataSet.parastatika' table. You can move, or remove it, as needed.
        Me.ParastatikaTableAdapter.Fill(Me.DbhotelDataSet.parastatika)

        Me.TipoiTableAdapter.Fill(Me.DbhotelDataSet.tipoi)
        'TODO: This line of code loads data into the 'DbhotelDataSet.katigories1' table. You can move, or remove it, as needed.
        'Me.Katigories1TableAdapter.Fill(Me.DbhotelDataSet.katigories1)
        'TODO: This line of code loads data into the 'DbhotelDataSet.katigories' table. You can move, or remove it, as needed.
        Me.KatigoriesTableAdapter.Fill(Me.DbhotelDataSet.katigories)
        'TODO: This line of code loads data into the 'DbhotelDataSet.ethnikotites' table. You can move, or remove it, as needed.
        HauptPnl.AutoScroll = True
        HauptPnl.Controls.Clear()
        'InitializeMyScrollBar()
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        connectionString = Me.DbhotelDataSet.etaireia(0).connectionstring
        maxklines = Me.DbhotelDataSet.etaireia(0).maxklines
        imeromErgasias = Me.DbhotelDataSet.etaireia(0).imeromergasias
    End Sub






  
End Class