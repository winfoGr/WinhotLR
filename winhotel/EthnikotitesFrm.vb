Public Class EthnikotitesFrm
    Dim ethnikKwd As Integer
    Dim ethnos As String
    Dim name As String

    Private Sub EthnikotitesFrm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Finalize()
    End Sub

    Private Sub EthnikotitesFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.ethnikotites' table. You can move, or remove it, as needed.
        Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)

    End Sub

    Private Sub EthnikotitesDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EthnikotitesDataGridView.DoubleClick
        If EthnikotitesDataGridView.RowCount <> 0 Then

            Try
                ethnikKwd = (EthnikotitesDataGridView.Item(0, EthnikotitesDataGridView.CurrentRow.Index).Value)

                ' If praktkwd <> Nothing And Me.EthnikotitesTableAdapter.ExistEthnikotites(EthnikotitesDataGridView.Item(0, EthnikotitesDataGridView.CurrentRow.Index).Value.ToString <> 0 Then
                If ethnikKwd <> Nothing Then
                    If Me.EthnikotitesTableAdapter.ExistEthnikotita(EthnikotitesDataGridView.Item(0, EthnikotitesDataGridView.CurrentRow.Index).Value) Then
                        'MsgBox(praktkwd)
                        ethnos = EthnikotitesDataGridView.Item(1, EthnikotitesDataGridView.CurrentRow.Index).Value
                        name = EthnikotitesDataGridView.Item(2, EthnikotitesDataGridView.CurrentRow.Index).Value
                        Me.Close()
                        Me.Finalize()
                    End If
                End If

            Catch ex As ArgumentOutOfRangeException

            Catch ex1 As IndexOutOfRangeException

            End Try
        End If
    End Sub


    Public Function return_ethnos_sintomeusi() As String
        Return ethnos
    End Function


    Public Function return_ethnos_kwdikos() As Integer
        Return ethnikKwd
    End Function
    Public Function return_ethnos_name() As String
        Return name
    End Function
 
   
  
   
    
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub

   
End Class