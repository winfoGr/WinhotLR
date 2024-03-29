Public Class KeyFrm
    Dim kleidi As String
    Dim flag As Byte = 0
    Private Sub okBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okBtn.Click
        If kleidi.Equals(LTrim(Me.keyTbx.Text.ToUpper)) Then
            flag = 1
            Me.Close()
            Me.Finalize()
        End If
        MsgBox(" Λάθος κλειδί ! ", MsgBoxStyle.Exclamation, "winfo/ma.nik")
        keyTbx.Clear()
        keyTbx.Focus()

    End Sub
    Public Function return_flag() As Byte
        Return flag
    End Function
    Public Sub New(ByVal key As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        kleidi = key
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class