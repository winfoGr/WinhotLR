Public Class XoresFrm

    Dim xoresKwd As Integer
    Dim xora As String

    Private Sub EthnikotitesFrm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Finalize()
    End Sub

    Private Sub XoresFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.ethnikotites' table. You can move, or remove it, as needed.
        Me.XoresTableAdapter.Fill(Me.DbhotelDataSet.xores)

    End Sub

    Private Sub XoresDtGrd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles XoresDtGrd.DoubleClick
        If XoresDtGrd.RowCount <> 0 Then

            Try
                xoresKwd = (XoresDtGrd.Item(0, XoresDtGrd.CurrentRow.Index).Value)

                ' If praktkwd <> Nothing And Me.EthnikotitesTableAdapter.ExistEthnikotites(EthnikotitesDataGridView.Item(0, EthnikotitesDataGridView.CurrentRow.Index).Value.ToString <> 0 Then
                If xoresKwd <> Nothing Then
                    If Me.XoresTableAdapter.ExistXora(XoresDtGrd.Item(0, XoresDtGrd.CurrentRow.Index).Value) Then
                        'MsgBox(praktkwd)
                        xora = XoresDtGrd.Item(1, XoresDtGrd.CurrentRow.Index).Value
                        Me.Close()
                        Me.Finalize()
                    End If
                End If

            Catch ex As ArgumentOutOfRangeException

            Catch ex1 As IndexOutOfRangeException

            End Try
        End If
    End Sub


    Public Function return_xora_sintomeusi() As String
        Return xora
    End Function


    Public Function return_xora_kwdikos() As Integer
        Return xoresKwd
    End Function




    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
End Class