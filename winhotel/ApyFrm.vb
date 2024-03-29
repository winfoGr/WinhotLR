Public Class ApyFrm
    Dim kwdikos As Integer
    Dim saved As Boolean = True


    Private Sub ApyFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim response As MsgBoxResult
        If Not saved Then
            response = MsgBox(" Να αποθηκεθούν οι Αλλαγές;", MsgBoxStyle.YesNo, "winfo\nikEl.")
            If response = MsgBoxResult.Yes Then
                save_apy_Click(sender, e)
            End If
        End If
      
    End Sub


    'Private Sub ApyFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.apy' table. You can move, or remove it, as needed.
    '    Me.ApyTableAdapter.Fill(Me.DbhotelDataSet.apy)

    'End Sub

    Public Sub New(ByVal kwdikosKratisis As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.ApyTableAdapter.FillByKratisi(Me.DbhotelDataSet.apy, kwdikosKratisis)

        kwdikos = kwdikosKratisis

        AddHandler DbhotelDataSet.apy.ColumnChanging, AddressOf Stili_ColumnChanging '

    End Sub
    Private Sub Stili_ColumnChanging(ByVal sender As Object, _
      ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim AfmPrf As New afm_pruefung

        If (e.Column.ColumnName.Equals("afm")) Then
            Try
                If Not AfmPrf.ist_afm_ok(CType(e.ProposedValue, String)) Then
                    MsgBox("Λάθος ΑΦΜ!", MsgBoxStyle.Exclamation, "winfo\ma.nik")
                    'Me.ApyDataGridView.Item(5, ApyDataGridView.CurrentRow.Index).Value = Nothing
                End If

            Catch ex As InvalidCastException
                'Me.ApyDataGridView.Item(5, ApyDataGridView.CurrentRow.Index).Value = Nothing
                MsgBox("Το ΑΦΜ πρέπει να είναι ενας 9-ψήφιος Αριθμός ", MsgBoxStyle.Information, "winfo\ma.nik")
            End Try
        End If

    End Sub

    Private Sub ApyDataGridView_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles ApyDataGridView.UserAddedRow
        Me.ApyDataGridView.Item(1, ApyDataGridView.CurrentRow.Index).Value = 0
        saved = False
    End Sub


    Private Sub save_apy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Dim i As Int16
        'MsgBox(ApyBindingSource.Count)

        ApyDataGridView.EndEdit()
        'MsgBox(ApyBindingSource.Count)
        For i = 0 To ApyBindingSource.Count - 1
            Try
                If Me.ApyDataGridView.Item(1, i).Value = 0 Then
                    Me.ApyTableAdapter.InsertApy(kwdikos, LTrim(ApyDataGridView.Item(2, i).Value.ToString), ApyDataGridView.Item(3, i).Value.ToString, ApyDataGridView.Item(4, i).Value.ToString, ApyDataGridView.Item(5, i).Value.ToString, ApyDataGridView.Item(6, i).Value.ToString, ApyDataGridView.Item(7, i).Value.ToString, ApyDataGridView.Item(8, i).Value.ToString)
                Else
                    Me.ApyTableAdapter.UpdateApy(LTrim(ApyDataGridView.Item(2, i).Value.ToString), ApyDataGridView.Item(3, i).Value.ToString, ApyDataGridView.Item(4, i).Value.ToString, ApyDataGridView.Item(5, i).Value.ToString, ApyDataGridView.Item(6, i).Value.ToString, ApyDataGridView.Item(7, i).Value.ToString, ApyDataGridView.Item(8, i).Value.ToString, ApyDataGridView.Item(0, i).Value.ToString)
                End If
            Catch ex As InvalidCastException


            Catch ex1 As OleDb.OleDbException '  Sitn Db sto APy Table den epitrepontai diplotipa bei kkratisi!!!!!!!!!!
                MsgBox("Δεν επιτρέπεται πολλαπλή καταχώριση", MsgBoxStyle.Information, "winfo\nikEl.")

            End Try

        Next
        saved = True
        Try
            Me.ApyTableAdapter.FillByKratisi(Me.DbhotelDataSet.apy, kwdikos)

        Catch ex As OleDb.OleDbException

        End Try

        If Me.KratiseisTableAdapter.ExistKwdikoskratisis(kwdikos) Then
            If Me.DbhotelDataSet.apy.Count <> 0 Then
                Me.KratiseisTableAdapter.SetPrivatTimolByKwd(True, kwdikos)
            Else
                Me.KratiseisTableAdapter.SetPrivatTimolByKwd(False, kwdikos)
            End If
        End If

    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click

        Try
            If Me.ApyTableAdapter.ExistEponimia((Me.ApyDataGridView.Item(1, Me.ApyDataGridView.CurrentRow.Index).Value), LTrim(Me.ApyDataGridView.Item(2, Me.ApyDataGridView.CurrentRow.Index).Value)) Then
                Try
                    Me.ApyTableAdapter.DeleteApy((ApyDataGridView.Item(0, ApyDataGridView.CurrentRow.Index).Value))

                Catch ex As OleDb.OleDbException
                    MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try
            End If
        Catch ex As InvalidCastException
            Me.Close()
            Me.Finalize()
        End Try
        saved = False
      

    End Sub
   
    
   
    Private Sub ApyFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.kratiseis' table. You can move, or remove it, as needed.
        'Me.KratiseisTableAdapter.FillByEtos(Me.DbhotelDataSet.kratiseis, etos)

    End Sub
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
    
   
End Class