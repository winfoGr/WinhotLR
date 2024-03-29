Public Class CustomMessageBox

    Public Sub New()


        ' This call is required by the designer.

        InitializeComponent()


        DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        DialogResult = Windows.Forms.DialogResult.Yes

        Close()

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        DialogResult = Windows.Forms.DialogResult.No

        Close()

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        DialogResult = Windows.Forms.DialogResult.Ignore

        Close()

    End Sub

    Private Sub CustomMessageBox_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Finalize()
        Me.Dispose()
    End Sub
End Class