Public Class PraktoreioFrm
    Dim kwdikos As Integer
    'Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.xrewseis' table. You can move, or remove it, as needed.

    '    'TODO: This line of code loads data into the 'DbhotelDataSet.praktoreia' table. You can move, or remove it, as needed.
    '    Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.xrewseis' table. You can move, or remove it, as needed.
    '    'Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)

    'End Sub

    Public Sub New(ByVal kwdpraktor As Int16)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        kwdikos = kwdpraktor
        Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
        'MsgBox("xREWSEIS COUNT" + Me.DbhotelDataSet.xrewseis.Count.ToString)
        Me.PraktoreiaTableAdapter.FillByKwdiko(Me.DbhotelDataSet.praktoreia, kwdpraktor)
        ' Add any initialization after the InitializeComponent() call.
        Me.kwdTbx.Text = Me.DbhotelDataSet.praktoreia(0).kwd
        Me.TextBox1.Text = Me.DbhotelDataSet.praktoreia(0).eponimia
        Me.TextBox2.Text = Me.DbhotelDataSet.praktoreia(0).titlostimolog
        Me.TextBox3.Text = Me.DbhotelDataSet.praktoreia(0).ipeuthinos
        Me.TextBox4.Text = Me.DbhotelDataSet.praktoreia(0).dieuthinsi
        Me.TextBox5.Text = Me.DbhotelDataSet.praktoreia(0).tilefono
        Me.TextBox6.Text = Me.DbhotelDataSet.praktoreia(0).fax
        Me.TextBox7.Text = Me.DbhotelDataSet.praktoreia(0).telex
        Me.TextBox8.Text = Me.DbhotelDataSet.praktoreia(0).afm
        Me.TextBox9.Text = Me.DbhotelDataSet.praktoreia(0).doy
        Me.CheckBox1.Checked = Me.DbhotelDataSet.praktoreia(0).imerisiatimi
        Me.CheckBox2.Checked = Me.DbhotelDataSet.praktoreia(0).garanti
        Me.SelfCheck3.Checked = Me.DbhotelDataSet.praktoreia(0).individual
        Me.TextBox10.Text = Me.DbhotelDataSet.praktoreia(0).logariasmos
        Me.TextBox15.Text = Me.DbhotelDataSet.praktoreia(0).email
        Try 'Se periptwsi DBnull
            Me.TextBox11.Text = Me.DbhotelDataSet.praktoreia(0).sentonia
            Me.TextBox12.Text = Me.DbhotelDataSet.praktoreia(0).tapeta
            Me.TextBox13.Text = Me.DbhotelDataSet.praktoreia(0).petsetes
            Me.TextBox14.Text = Me.DbhotelDataSet.praktoreia(0).mpournouzia
        Catch ex As StrongTypingException

        End Try




        Me.ComboBox1.SelectedIndex = get_position_xrewsi(Me.DbhotelDataSet.praktoreia(0).xrewsi)
        'Me.DbhotelDataSet.praktoreia(0).xrewsi(-Me.DbhotelDataSet.xrewseis(0).kwd)



    End Sub
    Private Function get_position_xrewsi(ByVal kwdikos As Integer) As Int16
        Dim i As Int16

        For i = 0 To Me.DbhotelDataSet.xrewseis.Count - 1
            If Me.DbhotelDataSet.xrewseis(i).kwd = kwdikos Then
                Return i
            End If
        Next
        Return -1
    End Function

   
   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.PraktoreiaTableAdapter.UpdatPraktoLeptomereies(Me.TextBox1.Text, Me.TextBox2.Text, Me.TextBox3.Text, Me.TextBox4.Text, Me.TextBox5.Text, Me.TextBox6.Text, _
             Me.TextBox7.Text, Me.TextBox8.Text, Me.TextBox9.Text, Me.CheckBox1.Checked, Me.TextBox10.Text, Me.DbhotelDataSet.xrewseis(Me.ComboBox1.SelectedIndex).kwd, _
             Me.CheckBox2.Checked, Me.TextBox11.Text, Me.TextBox12.Text, Me.TextBox13.Text, Me.TextBox14.Text, TextBox15.Text, CType(kwdTbx.Text, Int16), Me.SelfCheck3.Checked, kwdikos)
            MsgBox("Οι Aλλαγές αποθηκέυθηκαν επιτυχώς!", MsgBoxStyle.Information, "winfo\nikEl.")
        Catch ex1 As IndexOutOfRangeException
            MsgBox("Επιλέξτε τύπο χρέωσης !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            Me.ComboBox1.Focus()
        Catch ex2 As OleDb.OleDbException
            MsgBox("Η Αποθήκευση δεν κατέστη δυνατή. Ελέγξτε τον κωδικό !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        Catch ex3 As InvalidCastException
            MsgBox("Η Αποθήκευση δεν κατέστη δυνατή. O Kωδικός πρέπει να είναι αριθμός !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        End Try
    End Sub

    Private Sub TextBox_TextLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.Leave, TextBox12.Leave, TextBox13.Leave, TextBox14.Leave
        If TextBox11.Text.Equals("") Then
            TextBox11.Text = 0
        ElseIf TextBox12.Text.Equals("") Then
            TextBox12.Text = 0
        ElseIf TextBox13.Text.Equals("") Then
            TextBox13.Text = 0
        ElseIf TextBox14.Text.Equals("") Then
            TextBox14.Text = 0

        End If
    End Sub
    
  
    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged

        Try
            If CType(TextBox11.Text, Integer) Then
            End If
        Catch ex As InvalidCastException
            TextBox11.Text = Me.DbhotelDataSet.praktoreia(0).sentonia
        End Try
        
    End Sub
    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        Try
            If CType(TextBox13.Text, Integer) Then
            End If
        Catch ex As InvalidCastException
            TextBox13.Text = Me.DbhotelDataSet.praktoreia(0).petsetes
        End Try
    End Sub
    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged
        Try
            If CType(TextBox14.Text, Integer) Then
            End If
        Catch ex As InvalidCastException
            TextBox14.Text = Me.DbhotelDataSet.praktoreia(0).mpournouzia
        End Try
    End Sub
    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        Try
            If CType(TextBox12.Text, Integer) Then
            End If
        Catch ex As InvalidCastException
            TextBox12.Text = Me.DbhotelDataSet.praktoreia(0).tapeta
        End Try
    End Sub

    Private Sub TextBox8_TextLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.Leave
        Dim afmclass As New afm_pruefung
        If Not afmclass.ist_afm_ok(Me.TextBox8.Text) Then
            MsgBox("Λάθος Α.Φ.Μ. !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        End If
    End Sub


    Private Sub TextBox10_TextLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.Leave
        Try
            If CType(sender.text, Int64) AndAlso TextBox10.Text.Length = 10 Then
                TextBox10.Text = display_noumero(sender.Text)
            Else
                MsgBox("Ο Κωδικός Λογαριασμού πρέπει να περιέχει 10 νούμερα!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                TextBox10.Clear()
                'TextBox10.Focus()

            End If
        Catch ex As InvalidCastException
            MsgBox("Ο Κωδικός Λογαριασμού πρέπει να περιέχει μόνο νούμερα!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            TextBox10.Clear()
            'TextBox10.Focus()

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
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub

    'Private Sub PraktoreioFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.Leave
        Dim zahl As Int16 = 0
      
        Try
            zahl = Math.Abs(CType(sender.text, Int16))
            sender.text = zahl

        Catch ex As InvalidCastException
            zahl = 0
            sender.text = zahl
        End Try

    End Sub

  
  
End Class
