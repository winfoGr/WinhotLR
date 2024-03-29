Public Class EkptoseisFrm
    Dim synolo As Single
    Dim imeres As Int16
    Dim pososto, poso, fee, free As Single

    Public Sub New(ByVal syn As Single, ByVal days As Int16, ByVal ekptPoso As Single, ByVal ekptPososto As Single, ByVal ekptFree As Single, ByVal ekptCFee As Single)
        ' This call is required by the Windows Form Designer.
        ' Add any initialization after the InitializeComponent() call.
        InitializeComponent()
        synolo = syn
        imeres = days
        pososto = ekptPososto
        poso = ekptPoso
        free = ekptFree
        fee = ekptCFee
        MemApyPosostoTbx.Text = pososto.ToString("F")
        MemApyPosoTbx.Text = poso.ToString("F")
        MemApyImerFreeTbx.Text = free.ToString("N1")
        MemApyFeeTbx.Text = fee.ToString("N1")
    End Sub
    Private Sub init_ekpt_felder(ByVal index1 As Byte, ByVal index2 As Byte, ByVal index3 As Byte, ByVal index4 As Byte)
        Dim s As Single = 0
        If index1 = 0 Then
            MemApyPosostoTbx.Text = s.ToString("N")
            pososto = 0
        End If
        If index2 = 0 Then
            MemApyPosoTbx.Text = s.ToString("N")
            poso = 0
        End If
        If index3 = 0 Then
            MemApyImerFreeTbx.Text = s.ToString("N1")
            free = 0
        End If
        If index4 = 0 Then
            MemApyFeeTbx.Text = s.ToString("N1")
            fee = 0
        End If
    End Sub
    Private Sub MemApyPosostoTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemApyPosostoTbx.Leave
        Dim zahl As Single

        Try
            zahl = Math.Abs(CType(sender.text, Single)).ToString("F")
            If zahl > 100 Then
                zahl = 100
                sender.text = zahl.ToString("F")
                Exit Sub
            End If
            sender.text = zahl.ToString("F")
            pososto = sender.text
            If zahl <> 0 Then
                init_ekpt_felder(1, 0, 0, 0)
            End If

        Catch ex As InvalidCastException
            zahl = 0
            pososto = 0
            sender.text = zahl.ToString("F")
        End Try
    End Sub
    Private Sub MemApyPosoTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemApyPosoTbx.Leave
        Dim zahl As Single

        Try
            'zahl = Math.Abs(CType(sender.text, Single)).ToString("F")
            zahl = CType(sender.text, Single).ToString("F")
            Try
                If synolo >= 0 AndAlso zahl > synolo Then
                    MsgBox("Πολύ μεγάλο ποσό για έκπτωση !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    zahl = 0
                    sender.text = zahl.ToString("F")
                    Exit Sub
                End If
                sender.text = zahl.ToString("F")
                poso = sender.text
                If zahl <> 0 Then
                    init_ekpt_felder(0, 1, 0, 0)
                End If

            Catch ex As IndexOutOfRangeException
                zahl = 0
                sender.text = zahl.ToString("F")
            End Try

        Catch ex As InvalidCastException
            zahl = 0
            poso = 0
            sender.text = zahl.ToString("F")
        End Try
    End Sub
    Private Sub MemApyImerFreeTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemApyImerFreeTbx.Leave
        Dim zahl As Single

        Try
            zahl = Math.Abs(CType(sender.text, Single)).ToString("N1")
            If zahl > imeres Then
                MsgBox("Πολλές Ημέρες για έκπτωση !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                zahl = 0
                sender.text = zahl
                Exit Sub
            Else
                If zahl <> 0 Then
                    init_ekpt_felder(0, 0, 1, 0)
                End If
            End If
            sender.text = zahl.ToString("N1")
            free = sender.text
        Catch ex As InvalidCastException
            zahl = 0
            sender.text = zahl.ToString("N1")
            free = 0
        End Try
    End Sub
    Private Sub MemApyFeeTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemApyFeeTbx.Leave
        Dim zahl As Single

        Try
            zahl = Math.Abs(CType(sender.text, Single)).ToString("N1")
            If zahl > imeres + 10 Then
                zahl = 0
                sender.text = zahl
                Exit Sub
            Else
                sender.text = zahl.ToString("N1")
                fee = sender.text
                If zahl <> 0 Then
                    init_ekpt_felder(0, 0, 0, 1)
                End If
            End If
        Catch ex As InvalidCastException
            zahl = 0
            fee = 0
            sender.text = zahl.ToString("N1")
        End Try
    End Sub
    Public Function return_pososto() As Single
        Return pososto
    End Function
    Public Function return_poso() As Single
        Return poso
    End Function
    Public Function return_free() As Single
        Return free
    End Function
    Public Function return_fee() As Single
        Return fee
    End Function
    Private Sub TextBox_SelectAllText(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemApyPosostoTbx.Click, MemApyPosoTbx.Click, MemApyImerFreeTbx.Click, _
 MemApyFeeTbx.Click
        sender.SelectAll()
    End Sub

    Private Sub MemApyEkdBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemApyEkdBtn.Click

        Me.Close()
    End Sub
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
    Private Sub EkdosiParastYpnosTbx_Keypress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles MemApyPosostoTbx.KeyPress, MemApyPosoTbx.KeyPress, _
  MemApyImerFreeTbx.KeyPress, MemApyFeeTbx.KeyPress
        komma_einschalten(sender, e)

    End Sub
    Private Sub komma_einschalten(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        Select Case e.KeyChar
            ' Modify '.' to ',' and forward the key.
            Case ChrW(46)
                e.KeyChar = ","
                e.Handled = False
                ' Modify 'b' to 'a' and forward the key.
        End Select


    End Sub
End Class