Public Class Eisprakseis
    Dim kwdEispr As Integer

    Public Sub New(ByVal kwdPrakt As Integer, ByVal imerom As Date)

        'Dim imerom As Date = "1/1/" + etos.ToString
        InitializeComponent()
        Me.EisprakseispraktoreiaTableAdapter.FillByPraktImerom(Me.DbhotelDataSet.eisprakseispraktoreia, kwdPrakt, imerom)
        ' Add any initialization after the InitializeComponent() call.
        'init_dtgrd()
        'For j = 0 To Me.DbhotelDataSet.eisprakseispraktoreia.Count - 1

        'Next
    End Sub
    'Private Sub init_dtgrd()
    '    Dim j As Int16
    '    Dim d As Single
    '    For j = 0 To Me.EisprakseispraktoreiaBindingSource.Count - 1

    '        d = Me.DbhotelDataSet.eisprakseispraktoreia(j).eispraksi + Me.DbhotelDataSet.eisprakseispraktoreia(j).sunplin
    '        Me.DbhotelDataSet.eisprakseispraktoreia(j).eispraksi = d.ToString("N")
    '    Next
    'End Sub
    Private Sub Eisprakseis_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Finalize()
    End Sub

    Private Sub EisprakseisDtGrd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EisprakseisDtGrd.DoubleClick
        If EisprakseisDtGrd.RowCount <> 0 Then

            Try
                kwdEispr = (EisprakseisDtGrd.Item(0, EisprakseisDtGrd.CurrentRow.Index).Value)
                Me.Close()
                Me.Finalize()
                ' If praktkwd <> Nothing And Me.EthnikotitesTableAdapter.ExistEthnikotites(EthnikotitesDataGridView.Item(0, EthnikotitesDataGridView.CurrentRow.Index).Value.ToString <> 0 Then

            Catch ex As ArgumentOutOfRangeException

            Catch ex1 As IndexOutOfRangeException

            End Try
        End If
    End Sub
    Public Function return_kwd_eispraksis() As Integer
        Return kwdEispr
    End Function


    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub

   
End Class