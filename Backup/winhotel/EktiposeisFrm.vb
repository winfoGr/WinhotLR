Public Class EktiposeisFrm

   
    Private Sub EktiposeisFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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