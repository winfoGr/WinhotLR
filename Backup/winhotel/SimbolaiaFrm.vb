Public Class SimbolaiaFrm
    Dim praktkwd As Integer
    Dim xrewsikwd As Integer
    Dim praktoreio As String

    Private Sub SimbolaiaFrm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Finalize()
    End Sub
   
  

    Private Sub SimbolaiaFrm_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.praktoreia' table. You can move, or remove it, as needed.
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)

    End Sub

    Private Sub PraktoreiaDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PraktoreiaDataGridView.DoubleClick
        If PraktoreiaDataGridView.RowCount <> 0 Then

            Try
                praktkwd = (PraktoreiaDataGridView.Item(0, PraktoreiaDataGridView.CurrentRow.Index).Value)

                ' If praktkwd <> Nothing And Me.PraktoreiaTableAdapter.ExistPraktoreia(PraktoreiaDataGridView.Item(0, PraktoreiaDataGridView.CurrentRow.Index).Value.ToString <> 0 Then
                If praktkwd <> Nothing Then
                    If Me.PraktoreiaTableAdapter.ExistPraktoreia(PraktoreiaDataGridView.Item(0, PraktoreiaDataGridView.CurrentRow.Index).Value) Then
                        'MsgBox(praktkwd)
                        praktoreio = PraktoreiaDataGridView.Item(1, PraktoreiaDataGridView.CurrentRow.Index).Value
                        xrewsikwd = PraktoreiaDataGridView.Item(2, PraktoreiaDataGridView.CurrentRow.Index).Value
                        Me.Close()
                        Me.Finalize()
                    Else
                        If PraktoreiaDataGridView.Item(1, PraktoreiaDataGridView.CurrentRow.Index).Value.ToString.Equals("") Then
                            MsgBox(" Δεν επιλέχθηκε Πρακτορείο!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        Else
                            MsgBox(" Το Πρακτορείο πρεπει πρώτα να αποθηκευθεί (κλικ στο εικονίδιο της Δισκέτας) πριν επιλεχθεί!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        End If

                    End If
                End If

            Catch ex As ArgumentOutOfRangeException

            Catch ex1 As IndexOutOfRangeException
            Catch ex2 As InvalidCastException
                MsgBox(" Δεν επιλέχθηκε Πρακτορείο!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            End Try


        End If

    End Sub


    Public Function return_praktoreio()
        Return praktoreio
    End Function


    Public Function return_praktoreio_kwdikos()
        Return praktkwd
    End Function
    Public Function return_praktoreio_xrewsi()
        Return xrewsikwd
    End Function
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
    
End Class