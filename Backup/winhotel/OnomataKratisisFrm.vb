Public Class OnomataKratisisFrm
    Dim kwdikos As Integer
    Dim kwdEnilik() As Integer
    Dim saved As Boolean = True
    Dim imeromErgasias As Date
    Dim TypeOfLanguage = New System.Globalization.CultureInfo("en")
    Dim praktAdapter As New dbhotelDataSetTableAdapters.praktoreiaTableAdapter
    Dim praktkwdikos As Integer
    'Private Sub EnilikesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Validate()
    '    Me.EnilikesBindingSource.EndEdit()
    '    Me.EnilikesTableAdapter.Update(Me.DbhotelDataSet.enilikes)

    'End Sub

    'Private Sub OnomataKratisisFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.enilikes' table. You can move, or remove it, as needed.

    'End Sub

   
    Public Sub New(ByVal kwdikosKratisis As Integer, ByVal imerom As Date, ByVal praktkwd As Integer)
        'Dim i As Int16
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        imeromErgasias = imerom
        ' Dim TypeOfLanguage = New System.Globalization.CultureInfo("el-GR") 
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)
        Me.EnilikesTableAdapter.FillByKratisi(Me.DbhotelDataSet.enilikes, kwdikosKratisis)

        kwdikos = kwdikosKratisis
        praktkwdikos = praktkwd
        AddHandler DbhotelDataSet.enilikes.ColumnChanging, AddressOf Stili_ColumnChanging '

    End Sub
   
    Private Sub Stili_ColumnChanging(ByVal sender As Object, _
       ByVal e As System.Data.DataColumnChangeEventArgs)

        If (e.Column.ColumnName.Equals("genisi")) Then
            Try
                If CType(e.ProposedValue, Date) > imeromErgasias Then
                    MsgBox("Λάθος Ημερομηνία Γεννήσεως!", MsgBoxStyle.Exclamation, "winfo\ma.nik")
                Else
                    Me.EnilikesDataGridView.Item(4, EnilikesDataGridView.CurrentRow.Index).Value = imeromErgasias.Year - CType(e.ProposedValue, Date).Year
                End If
                'End If
            Catch ex As InvalidCastException
                Me.EnilikesDataGridView.Item(4, EnilikesDataGridView.CurrentRow.Index).Value = Nothing
                MsgBox("Μορφή Ημερομηνίας: HM/MH/ΕΤΟΣ ,π.χ. 1/2/1990", MsgBoxStyle.Information, "winfo\ma.nik")
            End Try
        End If

    End Sub

    Private Sub EnilikesDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles EnilikesDataGridView.DataError
        'MsgBox("Μορφή Ημερομηνιας: HM/MH/ΕΤΟΣ ,π.χ. 1/2/1978", MsgBoxStyle.Information, "winfo\ma.nik")

    End Sub

    Private Sub EnilikesDataGridView_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnilikesDataGridView.Enter
        Dim i As Int16
        For i = 0 To EnilikesBindingSource.Count - 1
            'MsgBox(Me.EnilikesDataGridView.Item(0, i).Value.ToString)
            Try
                Me.EnilikesDataGridView.Item(4, i).Value = imeromErgasias.Year - CType(Me.EnilikesDataGridView.Item(3, i).Value, Date).Year
            Catch ex As InvalidCastException

            End Try

        Next
    End Sub

  

    Private Sub EnilikesDataGridView_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles EnilikesDataGridView.UserAddedRow

        Me.EnilikesDataGridView.Item(1, EnilikesDataGridView.CurrentRow.Index).Value = 0
        saved = False
    End Sub
    Private Sub save_onoma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Dim i As Int16

        ReDim kwdEnilik(EnilikesBindingSource.Count - 1)
        EnilikesDataGridView.EndEdit()

        For i = 0 To EnilikesBindingSource.Count - 1
            Try
                If Me.EnilikesDataGridView.Item(1, i).Value = 0 Then
                    Try
                        If CType(EnilikesDataGridView.Item(3, i).Value, Date) <= imeromErgasias Then
                            Me.EnilikesTableAdapter.InsertOnoma2(kwdikos, LTrim(EnilikesDataGridView.Item(2, i).Value.ToString), EnilikesDataGridView.Item(3, i).Value, EnilikesDataGridView.Item(5, i).Value.ToString, EnilikesDataGridView.Item(6, i).Value)
                        End If
                    Catch ex As InvalidCastException
                        Me.EnilikesTableAdapter.InsertOnoma2(kwdikos, LTrim(EnilikesDataGridView.Item(2, i).Value.ToString), Nothing, EnilikesDataGridView.Item(5, i).Value.ToString, EnilikesDataGridView.Item(6, i).Value)
                    End Try
                Else
                    Try
                        Me.EnilikesTableAdapter.UpdateOnoma2(LTrim(EnilikesDataGridView.Item(2, i).Value.ToString), EnilikesDataGridView.Item(3, i).Value, EnilikesDataGridView.Item(5, i).Value.ToString, EnilikesDataGridView.Item(6, i).Value, EnilikesDataGridView.Item(0, i).Value)
                    Catch ex As InvalidCastException
                        Me.EnilikesTableAdapter.UpdateOnoma2(LTrim(EnilikesDataGridView.Item(2, i).Value.ToString), Nothing, EnilikesDataGridView.Item(5, i).Value.ToString, EnilikesDataGridView.Item(6, i).Value, EnilikesDataGridView.Item(0, i).Value)
                    End Try
                End If
            Catch ex As InvalidCastException
            End Try
        Next
        saved = True
        Me.EnilikesTableAdapter.Fill(Me.DbhotelDataSet.enilikes, kwdikos)
        For i = 0 To EnilikesBindingSource.Count - 1
            Try
                Me.EnilikesDataGridView.Item(4, i).Value = imeromErgasias.Year - CType(Me.EnilikesDataGridView.Item(3, i).Value, Date).Year
            Catch ex As InvalidCastException
            End Try
        Next
        Me.EnilikesBindingSource.MoveLast()
        If praktkwdikos > 0 Then
            If praktAdapter.IstIndividualByKwd(praktkwdikos) Then
                save_apy()
            End If
        End If
       

    End Sub
    Private Sub save_apy()
        Dim apyAdapter As New dbhotelDataSetTableAdapters.apyTableAdapter
        Try
            apyAdapter.FillByKratisi(Me.DbhotelDataSet.apy, kwdikos)
            If Me.DbhotelDataSet.apy.Count = 0 Then
                apyAdapter.InsertApy(kwdikos, LTrim(EnilikesDataGridView.Item(2, 0).Value.ToString), "", "", "", "")
            Else
                apyAdapter.UpdateEponimoByKratisi(LTrim(EnilikesDataGridView.Item(2, 0).Value.ToString), kwdikos)
            End If

        Catch ex1 As OleDb.OleDbException '  Sitn Db sto APy Table den epitrepontai diplotipa bei kkratisi!!!!!!!!!!
            'MsgBox("Δεν επιτρέπεται πολλαπλή καταχώριση", MsgBoxStyle.Information, "winfo\nikEl.")

        End Try
    End Sub
    Private Sub delete_praktoreia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        Try
            If Me.EnilikesTableAdapter.ExistOnoma((EnilikesDataGridView.Item(1, EnilikesDataGridView.CurrentRow.Index).Value), LTrim(EnilikesDataGridView.Item(2, EnilikesDataGridView.CurrentRow.Index).Value)) Then
                Try
                    Me.EnilikesTableAdapter.DeleteOnoma((EnilikesDataGridView.Item(0, EnilikesDataGridView.CurrentRow.Index).Value))

                Catch ex As OleDb.OleDbException
                    MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try
            End If
        Catch ex As InvalidCastException
            Me.Close()
            Me.Finalize()
        End Try

    End Sub
   

    Private Sub OnomataKratisisFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim response As MsgBoxResult
        If Not saved Then
            response = MsgBox(" Να αποθηκεθούν οι Αλλαγές;", MsgBoxStyle.YesNo, "winfo\nikEl.")
            If response = MsgBoxResult.Yes Then
                save_onoma_Click(sender, e)
            End If
        End If
        Me.Finalize()
    End Sub

    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub

    
   
  
End Class