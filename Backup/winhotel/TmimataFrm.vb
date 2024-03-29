Public Class TmimataFrm
    Dim tmimaKwd As Integer
    Dim tmima As String
    'Private Sub TmimataBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Validate()
    '    Me.TmimataBindingSource.EndEdit()
    '    Me.TmimataTableAdapter.Update(Me.DbhotelDataSet.tmimata)

    'End Sub

    'Private Sub TninataFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.tmimata' table. You can move, or remove it, as needed.
    '    Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True)

    'End Sub
    Public Sub New(ByVal zentralTmOK As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        If zentralTmOK Then
            Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True)
        Else
            Me.TmimataTableAdapter.FillOla(Me.DbhotelDataSet.tmimata)
        End If


        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub TmimataDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TmimataDataGridView.DoubleClick
        If TmimataDataGridView.RowCount <> 0 Then

            Try
                tmimaKwd = (TmimataDataGridView.Item(0, TmimataDataGridView.CurrentRow.Index).Value)

                ' If praktkwd <> Nothing And Me.PraktoreiaTableAdapter.ExistPraktoreia(PraktoreiaDataGridView.Item(0, PraktoreiaDataGridView.CurrentRow.Index).Value.ToString <> 0 Then
                If tmimaKwd <> Nothing Then
                    If Me.TmimataTableAdapter.ExistTmima(TmimataDataGridView.Item(0, TmimataDataGridView.CurrentRow.Index).Value) Then
                        'MsgBox(praktkwd)
                        tmima = TmimataDataGridView.Item(1, TmimataDataGridView.CurrentRow.Index).Value
                        Me.Close()
                        Me.Finalize()
                    Else
                        If TmimataDataGridView.Item(1, TmimataDataGridView.CurrentRow.Index).Value.ToString.Equals("") Then
                            MsgBox(" Δεν επιλέχθηκε Τμήμα!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        End If

                    End If
                End If

            Catch ex As ArgumentOutOfRangeException

            Catch ex1 As IndexOutOfRangeException

            End Try


        End If

    End Sub


    Public Function return_tmima()
        Return tmima
    End Function


    Public Function return_tmima_kwdikos()
        Return tmimaKwd
    End Function


  
   
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
End Class