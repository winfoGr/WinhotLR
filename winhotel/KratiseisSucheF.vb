Public Class KratiseisSucheF
    Dim etos As Int16
    Dim imeromErgasias, kratisiAnax, kratisiAfixi As Date
    Dim kratisiDwmatio As String
    Dim kwdikoKratisisDB As Integer = -1
    Dim kratisiArithmos As Int16
    Dim kratisiOnoma As String = Nothing
    Dim status As Byte = 0 'von wo kommte der Aufruf 1->kratiseis,diamenontes Aufruf 2->memonomena Timologia, 3->apo Grammatio Eispraksis!
    Dim checkIn, checkOut As Boolean
    Dim user As Byte '=0 xenodoxeioy, 1 ola
    'Private Sub KratiseisSucheF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.kratiseisenilikes' table. You can move, or remove it, as needed.
    '    Me.KratiseisenilikesTableAdapter.Fill(Me.DbhotelDataSet.kratiseisenilikes)

    'End Sub
   
    Public Sub New(ByVal imerominia As Date, ByVal check1 As Boolean, ByVal check2 As Boolean, ByVal aufruf As Byte, ByVal flag As Byte)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        imeromErgasias = imerominia
        etos = imerominia.Year
        checkIn = check1
        checkOut = check2
        status = aufruf
        user = flag
        If user = 0 Then
            hotelRdb.Checked = True
            olaRdb.Enabled = False
            villasRdb.Enabled = False
        End If
        'timologio=0->kanena, timolgio=1->exei ekdothei, timolo=2->upo ekdosi    
        'oles oi kratiseisenilikes xwris timologio stis kratiseis
        If status = 2 Then 'aufruf apo mem timologia
            Me.KratiseisenilikesTableAdapter1.FillByEtosStatusTimologioAnaxwrisi(Me.DbhotelDataSet1.kratiseisenilikes, etos, checkIn, checkOut, 0, imeromErgasias)

        ElseIf status = 1 Then
            Me.KratiseisenilikesTableAdapter1.FillByEtosStatus(Me.DbhotelDataSet1.kratiseisenilikes, etos, checkIn, checkOut)

        ElseIf status = 3 Then
            'MONO onomata pou exoun Logariasmo KAI den exoun xoflisei(aagramat=0!->aagrammat einai o aa grammatiou apo gramatia Table EAN exei xoflisei
            Me.KratiseisenilikesTableAdapter1.FillJoinLogariasmoidiamenwnByEtosCheckinChkout(Me.DbhotelDataSet1.kratiseisenilikes, etos, checkIn, checkOut, 0)
            Me.TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox4.Enabled = False
        End If
    End Sub
    Public Sub New(ByVal imerominia As Date, ByVal check1 As Boolean, ByVal check2 As Boolean, ByVal dwm As String, ByVal aufruf As Byte, ByVal flag As Byte)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        imeromErgasias = imerominia
        etos = imerominia.Year
        checkIn = check1
        checkOut = check2
        status = aufruf
        TextBox2.Text = dwm
        TextBox1.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        Button13.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        user = flag
        If user = 0 Then
            hotelRdb.Checked = True
            olaRdb.Enabled = False
            villasRdb.Enabled = False
        End If
        If status = 2 Then
            Me.KratiseisenilikesTableAdapter1.FillByDwmatioEtosStatusTimologio(Me.DbhotelDataSet1.kratiseisenilikes, dwm, etos, checkIn, checkOut, 0)
        ElseIf status = 1 Then
            Me.KratiseisenilikesTableAdapter1.FillByDwmatioEtosStatus(Me.DbhotelDataSet1.kratiseisenilikes, dwm, etos, checkIn, checkOut)
        ElseIf status = 3 Then
            Me.KratiseisenilikesTableAdapter1.FillJoinLogarisndiamenByDwmatioEtosChkinAAgram(Me.DbhotelDataSet1.kratiseisenilikes, dwm, etos, True, False, 0)
        End If

    End Sub
    Private Sub KratiseisenilikesDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles KratiseisenilikesDataGridView.DoubleClick
        If KratiseisenilikesDataGridView.RowCount <> 0 Then

            Try
                kwdikoKratisisDB = (KratiseisenilikesDataGridView.Item(0, KratiseisenilikesDataGridView.CurrentRow.Index).Value)

                ' If praktkwd <> Nothing And Me.EthnikotitesTableAdapter.ExistEthnikotites(KratiseisenilikesDataGridView.Item(0, KratiseisenilikesDataGridView.CurrentRow.Index).Value.ToString <> 0 Then
                If kwdikoKratisisDB <> Nothing Then
                    If Me.KratiseisenilikesTableAdapter1.ExistKratisi(KratiseisenilikesDataGridView.Item(0, KratiseisenilikesDataGridView.CurrentRow.Index).Value) Then
                        'MsgBox(praktkwd)
                        kratisiArithmos = KratiseisenilikesDataGridView.Item(1, KratiseisenilikesDataGridView.CurrentRow.Index).Value.ToString
                        kratisiDwmatio = KratiseisenilikesDataGridView.Item(2, KratiseisenilikesDataGridView.CurrentRow.Index).Value.ToString
                        kratisiOnoma = KratiseisenilikesDataGridView.Item(3, KratiseisenilikesDataGridView.CurrentRow.Index).Value.ToString
                        kratisiAfixi = KratiseisenilikesDataGridView.Item(5, KratiseisenilikesDataGridView.CurrentRow.Index).Value
                        kratisiAnax = KratiseisenilikesDataGridView.Item(6, KratiseisenilikesDataGridView.CurrentRow.Index).Value
                        Me.Close()
                        Me.Finalize()
                    Else
                        kwdikoKratisisDB = -1
                        kratisiDwmatio = -1
                        Me.Close()
                        Me.Finalize()
                    End If
                Else
                    kwdikoKratisisDB = -1
                    kratisiDwmatio = -1
                    Me.Close()
                    Me.Finalize()
                End If

            Catch ex As ArgumentOutOfRangeException

            Catch ex1 As IndexOutOfRangeException

            End Try
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim s As String

        s = "%" & LTrim(sender.text) & "%"
        If status = 1 Then
            Me.KratiseisenilikesTableAdapter1.FillByOnomaEtosStatus(Me.DbhotelDataSet1.kratiseisenilikes, s, etos, checkIn, checkOut)
        ElseIf status = 2 Then
            Me.KratiseisenilikesTableAdapter1.FillByOnomaEtosStatusTimol(Me.DbhotelDataSet1.kratiseisenilikes, s, etos, checkIn, checkOut, 0)
        ElseIf status = 3 Then
            Me.KratiseisenilikesTableAdapter1.FillJoinLogariasmdiamenByOnomaEtosChkinChkout(Me.DbhotelDataSet1.kratiseisenilikes, s, etos, checkIn, checkOut, 0)
        End If



    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Dim s As String

        s = LTrim(sender.text) & "%"
        If status = 1 Then
            Me.KratiseisenilikesTableAdapter1.FillByVoucherBiblPortasEtosStatus(Me.DbhotelDataSet1.kratiseisenilikes, s, etos, checkIn, checkOut)
        ElseIf status = 2 Then
            Me.KratiseisenilikesTableAdapter1.FillByVoucherBiblPortasEtosStatusTimol(Me.DbhotelDataSet1.kratiseisenilikes, s, etos, checkIn, checkOut, 0)
        End If


    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim arKratisis As Int16

        Try
            arKratisis = CType(TextBox1.Text, Int16)
            If status = 1 Then
                Me.KratiseisenilikesTableAdapter1.FilByArithmEtosStatus(Me.DbhotelDataSet1.kratiseisenilikes, arKratisis, etos, checkIn, checkOut)
            ElseIf status = 2 Then
                Me.KratiseisenilikesTableAdapter1.FillByArithEtosStatusTimol(Me.DbhotelDataSet1.kratiseisenilikes, arKratisis, etos, checkIn, checkOut, 0)
            End If

        Catch ex As InvalidCastException
            TextBox1.Clear()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not LTrim(TextBox2.Text).Equals("") Then
            If status = 1 Then
                Me.KratiseisenilikesTableAdapter1.FillByDwmatioEtosStatus(Me.DbhotelDataSet1.kratiseisenilikes, LTrim(TextBox2.Text), etos, checkIn, checkOut)
            ElseIf status = 2 Then
                Me.KratiseisenilikesTableAdapter1.FillByDwmatioEtosStatusTimologio(Me.DbhotelDataSet1.kratiseisenilikes, LTrim(TextBox2.Text), etos, checkIn, checkOut, 0)
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        If status = 1 Then
            Me.KratiseisenilikesTableAdapter1.FillByEtosStatus(Me.DbhotelDataSet1.kratiseisenilikes, etos, checkIn, checkOut)
        ElseIf status = 2 Then
            Me.KratiseisenilikesTableAdapter1.FillByEtosStatusTimologioAnaxwrisi(Me.DbhotelDataSet1.kratiseisenilikes, etos, checkIn, checkOut, 0, imeromErgasias)
        End If
    End Sub

    Public Function return_kwdiko_kratisis() As Integer
        Return kwdikoKratisisDB
    End Function
    Public Function return_arithmo_kratisis() As String
        Return kratisiArithmos
    End Function
    Public Function return_onoma() As String
        Return kratisiOnoma
    End Function
    Public Function return_dwmatio() As String
        Return kratisiDwmatio
    End Function
    Public Function return_afixi() As String
        Return kratisiAfixi.ToShortDateString
    End Function
    Public Function return_anaxwrisi() As String
        Return kratisiAnax.ToShortDateString
    End Function
    Private Sub KratiseisSucheF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Finalize()
    End Sub
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                kwdikoKratisisDB = -1
                kratisiDwmatio = -1
                Me.Close()
                Me.Finalize()
        End Select


    End Sub

  
    
    Private Sub olaRdb_CheckedChanged(sender As Object, e As EventArgs) Handles olaRdb.CheckedChanged
        If sender.checked Then
          
            KratiseisenilikesBindingSource1.RemoveFilter()
        End If
    End Sub

    Private Sub villasRdb_CheckedChanged(sender As Object, e As EventArgs) Handles villasRdb.CheckedChanged
        If sender.checked Then
            KratiseisenilikesBindingSource1.RemoveFilter()
            KratiseisenilikesBindingSource1.Filter = "tipos>0 and tipos<13"

        End If
     
    End Sub

    Private Sub hotelRdb_CheckedChanged(sender As Object, e As EventArgs) Handles hotelRdb.CheckedChanged
        If sender.checked Then
            KratiseisenilikesBindingSource1.RemoveFilter()
            KratiseisenilikesBindingSource1.Filter = "tipos=0 or (tipos>=13 and tipos<=25)"
        End If
    End Sub
End Class