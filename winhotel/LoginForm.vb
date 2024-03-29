Public Class LoginForm
    Dim flags(2) As Byte

    Private Sub okBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okBtn.Click
        Dim j As Int16
        Dim pwdIsCorrect As Boolean = False
        For j = 0 To Me.DbhotelDataSet.rechte.Count - 1
           
            If EncodeBase64(PassWordTbx.Text) Like (Trim(Me.DbhotelDataSet.rechte(j).password)) Then
                If Me.DbhotelDataSet.rechte(j).kwd = 1 Then
                    flags(0) = 1
                    flags(1) = 0
                    flags(2) = 0
                ElseIf Me.DbhotelDataSet.rechte(j).kwd = 2 Then
                    flags(0) = 0
                    flags(1) = 0
                    flags(2) = 1
                ElseIf Me.DbhotelDataSet.rechte(j).kwd = 3 Then
                    flags(0) = 0
                    flags(1) = 0
                    flags(2) = 1
                End If
                pwdIsCorrect = True
                Me.Close()
                '  Me.Finalize()

            End If
        Next
        If pwdIsCorrect = False Then
            MsgBox(" Λάθος Password ! ", MsgBoxStyle.Exclamation, "winfo/ma.nik")
            PassWordTbx.Clear()
            PassWordTbx.Focus()
        End If


    End Sub
    Public Function EncodeBase64(base64Decoded As String) As String
        '  Dim base64Decoded As String = "base64 encoded string"
        Dim base64Encoded As String
        Dim data As Byte()
        data = System.Text.ASCIIEncoding.ASCII.GetBytes(base64Decoded)
        base64Encoded = System.Convert.ToBase64String(data)
        Return base64Encoded
    End Function

    'Public Function DecodeBase64(input As String) As String
    '    Return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(input))
    'End Function
    Public Function return_rechte() As Byte()
        Return flags
    End Function

    Private Sub LoginForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Me.Finalize()
        'Me.Dispose()
    End Sub

    'Private Sub LoginForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    If Not enterOK Then
    '        MsgBox(" Δεν επιτρέπεται η είσοδος ! ", MsgBoxStyle.Critical, "winfo/ma.nik")
    '        Application.Exit()
    '    End If
    'End Sub
   

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.rechte' table. You can move, or remove it, as needed.
        Me.RechteTableAdapter.Fill(Me.DbhotelDataSet.rechte)
        init_flags()


    End Sub

    Private Sub init_flags()
        Dim j As Int16

        For j = 0 To flags.Length - 1
            flags(j) = 0
        Next
    End Sub
End Class