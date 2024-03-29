Public Class OverUnterkuenfteFrm
    Dim kwdOver As Integer
    Dim imeromErg, imeromAnax As Date
    Dim saved As Boolean
    Dim status As Byte
    'Private Sub OverunterkuenfteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Validate()
    '    Me.OverunterkuenfteBindingSource.EndEdit()
    '    Me.OverunterkuenfteTableAdapter.Update(Me.DbhotelDataSet.overunterkuenfte)

    'End Sub

    'Private Sub OverUnterkuenfteFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.overunterkuenfte' table. You can move, or remove it, as needed.
    '    Me.OverunterkuenfteTableAdapter.Fill(Me.DbhotelDataSet.overunterkuenfte)

    'End Sub

   

    Public Sub New(ByVal kwdikosOver As Integer, ByVal imerom As Date, ByVal anaxwrisi As Date, ByVal stats As Byte)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        kwdOver = kwdikosOver
        imeromErg = imerom
        imeromAnax = anaxwrisi
        status = stats
        If kwdOver = -1 Then
            saved = True
        Else
            saved = False
        End If

        Me.OverunterkuenfteTableAdapter.FillByOver(Me.DbhotelDataSet.overunterkuenfte, kwdOver)
        ' Add any initialization after the InitializeComponent() call.
        AddHandler DbhotelDataSet.overunterkuenfte.ColumnChanging, AddressOf Stili_ColumnChanging '
    End Sub
    Private Sub Stili_ColumnChanging(ByVal sender As Object, _
       ByVal e As System.Data.DataColumnChangeEventArgs)

        If (e.Column.ColumnName.Equals("mexri")) Then
            Try
                If CType(e.ProposedValue, Date) >= imeromAnax Then ' CType(e.ProposedValue, Date) <= imeromErg Or
                    MsgBox("Λανθασμένη Ημερομηνία !", MsgBoxStyle.Exclamation, "winfo\ma.nik")
                    e.ProposedValue = imeromAnax.AddDays(-1)
                End If
                'End If
            Catch ex As InvalidCastException
                'Me.EnilikesDataGridView.Item(4, EnilikesDataGridView.CurrentRow.Index).Value = Nothing
                MsgBox("Μορφή Ημερομηνίας: HM/MH/ΕΤΟΣ ,π.χ. 1/2/1990", MsgBoxStyle.Information, "winfo\ma.nik")
            End Try
        End If

    End Sub

    Private Sub OverunterkuenfteDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles OverunterkuenfteDataGridView.DataError
        MsgBox("Μορφή Ημερομηνιας: HM/MH/ΕΤΟΣ ,π.χ. 1/2/1978", MsgBoxStyle.Information, "winfo\ma.nik")
    End Sub



    Private Sub OverunterkuenfteDataGridView_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles OverunterkuenfteDataGridView.UserAddedRow

        Me.OverunterkuenfteDataGridView.Item(3, OverunterkuenfteDataGridView.CurrentRow.Index).Value = imeromErg
        Me.OverunterkuenfteDataGridView.Item(4, OverunterkuenfteDataGridView.CurrentRow.Index).Value = imeromAnax.AddDays(-1)
        Me.OverunterkuenfteDataGridView.Item(1, OverunterkuenfteDataGridView.CurrentRow.Index).Value = 0
        saved = False
        If status = 1 Then
            If (kwdOver = -1 And OverunterkuenfteBindingSource.Count > 1) Then
                MsgBox(" Μόνο μία εισαγωγή ανά Ημερομηνία Εργασίας!", MsgBoxStyle.Exclamation, "winfo\ma.nik")
                OverunterkuenfteBindingSource.RemoveCurrent()
            End If
        ElseIf status = 2 Then

            If (OverunterkuenfteBindingSource.Count > 1 AndAlso Me.OverunterkuenfteDataGridView.Item(3, OverunterkuenfteDataGridView.CurrentRow.Index).Value <= Me.OverunterkuenfteDataGridView.Item(4, OverunterkuenfteDataGridView.CurrentRow.Index - 1).Value) Then
                MsgBox(" Λάθος Ημερομηνία !", MsgBoxStyle.Exclamation, "winfo\ma.nik")
                OverunterkuenfteBindingSource.RemoveCurrent()
            End If
        End If

    End Sub
    Private Sub save_unterkunft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Dim i As Int16

        OverunterkuenfteDataGridView.EndEdit()

        For i = 0 To OverunterkuenfteBindingSource.Count - 1
            Try
                If Me.OverunterkuenfteDataGridView.Item(1, i).Value = 0 Then
                    Try
                        If CType(OverunterkuenfteDataGridView.Item(4, i).Value, Date) < imeromAnax Then
                            Me.OverunterkuenfteTableAdapter.InsertUnterkunft(kwdOver, LTrim(OverunterkuenfteDataGridView.Item(2, i).Value.ToString), OverunterkuenfteDataGridView.Item(5, i).Value.ToString, OverunterkuenfteDataGridView.Item(3, i).Value, OverunterkuenfteDataGridView.Item(4, i).Value, OverunterkuenfteDataGridView.Item(6, i).Value.ToString)
                        Else
                            Me.OverunterkuenfteTableAdapter.InsertUnterkunft(kwdOver, LTrim(OverunterkuenfteDataGridView.Item(2, i).Value.ToString), OverunterkuenfteDataGridView.Item(5, i).Value.ToString, OverunterkuenfteDataGridView.Item(3, i).Value, imeromAnax, OverunterkuenfteDataGridView.Item(6, i).Value.ToString)
                        End If
                    Catch ex As InvalidCastException
                        Me.OverunterkuenfteTableAdapter.InsertUnterkunft(kwdOver, LTrim(OverunterkuenfteDataGridView.Item(2, i).Value.ToString), OverunterkuenfteDataGridView.Item(5, i).Value.ToString, OverunterkuenfteDataGridView.Item(3, i).Value, #1/1/1900#, OverunterkuenfteDataGridView.Item(6, i).Value.ToString)
                    End Try
                Else
                    Try
                        Me.OverunterkuenfteTableAdapter.UpdateUnterkunft(kwdOver, LTrim(OverunterkuenfteDataGridView.Item(2, i).Value.ToString), OverunterkuenfteDataGridView.Item(5, i).Value.ToString, OverunterkuenfteDataGridView.Item(3, i).Value, OverunterkuenfteDataGridView.Item(4, i).Value, OverunterkuenfteDataGridView.Item(6, i).Value.ToString, Me.OverunterkuenfteDataGridView.Item(0, i).Value)
                    Catch ex As InvalidCastException
                        Me.OverunterkuenfteTableAdapter.UpdateUnterkunft(kwdOver, LTrim(OverunterkuenfteDataGridView.Item(2, i).Value.ToString), OverunterkuenfteDataGridView.Item(5, i).Value.ToString, OverunterkuenfteDataGridView.Item(3, i).Value, OverunterkuenfteDataGridView.Item(4, i).Value, OverunterkuenfteDataGridView.Item(6, i).Value.ToString, Me.OverunterkuenfteDataGridView.Item(0, i).Value)
                    End Try

                End If
            Catch ex As InvalidCastException

            End Try

        Next
        saved = True
        Me.OverunterkuenfteTableAdapter.FillByOver(Me.DbhotelDataSet.overunterkuenfte, kwdOver)
        Me.OverunterkuenfteBindingSource.MoveLast()
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        Try
            If Me.OverunterkuenfteTableAdapter.ExistXenodoxeio((OverunterkuenfteDataGridView.Item(1, OverunterkuenfteDataGridView.CurrentRow.Index).Value), LTrim(OverunterkuenfteDataGridView.Item(2, OverunterkuenfteDataGridView.CurrentRow.Index).Value)) Then
                Try
                    Me.OverunterkuenfteTableAdapter.DeleteUnterkunft((OverunterkuenfteDataGridView.Item(0, OverunterkuenfteDataGridView.CurrentRow.Index).Value))

                Catch ex As OleDb.OleDbException
                    MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try
            End If
        Catch ex As InvalidCastException

        End Try
    End Sub

    Private Sub OverUnterkuenfteFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim response As MsgBoxResult
        If Not saved Then
            response = MsgBox(" Να αποθηκεθούν οι Αλλαγές;", MsgBoxStyle.YesNo, "winfo\nikEl.")
            If response = MsgBoxResult.Yes Then
                save_unterkunft_Click(sender, e)
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