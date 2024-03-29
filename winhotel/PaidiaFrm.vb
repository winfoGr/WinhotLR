Public Class PaidiaFrm
    Dim kwdikos
    'Private Sub PaidiaBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Validate()
    '    Me.PaidiaBindingSource.EndEdit()
    '    Me.PaidiaTableAdapter.Update(Me.DbhotelDataSet.paidia)

    'End Sub

    'Private Sub PaidiaFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.paidia' table. You can move, or remove it, as needed.
    '    Me.PaidiaTableAdapter.Fill(Me.DbhotelDataSet.paidia)

    'End Sub
    'Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
    '    Me.Validate()
    '    Me.PaidiaBindingSource.EndEdit()
    '    Me.PaidiaTableAdapter.Update(Me.DbhotelDataSet.paidia)
    'End Sub
    'Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
    '    Me.Validate()
    '    Me.PaidiaBindingSource.EndEdit()
    '    Me.PaidiaTableAdapter.DeletePaidi(Me.PaidiaDataGridView.Item(0, PaidiaDataGridView.CurrentRow.Index).Value)
    'End Sub
    Private Sub PaidiaDataGridView_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles PaidiaDataGridView.UserAddedRow
        Me.PaidiaDataGridView.Item(1, PaidiaDataGridView.CurrentRow.Index).Value = kwdikos
        Me.PaidiaDataGridView.Item(3, PaidiaDataGridView.CurrentRow.Index).Value = 0
    End Sub

    Public Sub New(ByVal kwdikosKratisis As Integer)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.PaidiaTableAdapter.FillByKratisi(Me.DbhotelDataSet.paidia, kwdikosKratisis)
        kwdikos = kwdikosKratisis
        AddHandler DbhotelDataSet.paidia.ColumnChanging, AddressOf Stili_ColumnChanging '
        'Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Stili_ColumnChanging(ByVal sender As Object, _
    ByVal e As System.Data.DataColumnChangeEventArgs)

        If (e.Column.ColumnName.Equals("ilikia")) Then
           
            Try
                If CType(e.ProposedValue, Byte) >= 18 Then

                    MsgBox("Η Ηλικία είναι μεγάλη για ένα παιδί!", MsgBoxStyle.Exclamation, "winfo\ma.nik")
                 
                End If
                'End If
            Catch ex As InvalidCastException
                MsgBox("Δεν έγινε σωστή επιλογή στήλης Φ.Π.Α.!" & vbCrLf & " (φυτικό =1, ζωϊκό=2, δασικό=3)", _
                MsgBoxStyle.Information, "winfo\ma.nik")
            End Try
        End If

    End Sub

    Private Sub PaidiaDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) _
       Handles PaidiaDataGridView.DataError
        MsgBox(" Δώστε αριθμό για ηλικία!", MsgBoxStyle.Exclamation, "winfo\ma.nik")
    End Sub
    Private Sub save_onoma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Dim i As Int16

        PaidiaDataGridView.EndEdit()
        For i = 0 To PaidiaBindingSource.Count - 1
            'Try

            If Me.PaidiaTableAdapter.ExistPaidi(PaidiaDataGridView.Item(0, i).Value) Then

                Try
                    Me.PaidiaTableAdapter.UpdatePaidi(PaidiaDataGridView.Item(2, i).Value, PaidiaDataGridView.Item(3, i).Value, PaidiaDataGridView.Item(0, i).Value)
                Catch ex As OleDb.OleDbException
                    MsgBox("Η Αλλαγή του" + PaidiaDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            Else
                If Not PaidiaDataGridView.Item(2, i).Value.ToString.Equals("") Then
                    Try

                        Me.PaidiaTableAdapter.InsertPaidi(PaidiaDataGridView.Item(1, i).Value, PaidiaDataGridView.Item(2, i).Value, PaidiaDataGridView.Item(3, i).Value)

                    Catch ex As OleDb.OleDbException
                        MsgBox("Η Αποθήκευση του " + PaidiaDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                End If

            End If

            'Catch ex As InvalidCastException

            'End Try


        Next
        Me.PaidiaTableAdapter.FillByKratisi(Me.DbhotelDataSet.paidia, kwdikos)

        Me.PaidiaBindingSource.MoveLast()
    End Sub
    Private Sub delete_praktoreia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        If Me.PaidiaTableAdapter.ExistPaidi((PaidiaDataGridView.Item(0, PaidiaDataGridView.CurrentRow.Index).Value)) Then
            Try

                Me.PaidiaTableAdapter.DeletePaidi(PaidiaDataGridView.Item(0, PaidiaDataGridView.CurrentRow.Index).Value)

            Catch ex As OleDb.OleDbException
                MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            End Try
        End If
    End Sub
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
End Class