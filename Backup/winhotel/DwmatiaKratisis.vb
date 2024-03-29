Public Class DwmatiaKratisis
    Dim kwdKratisis As Integer
    Dim afixi, anaxwrisi As Date
    Dim chkInOk As Boolean
    Public Sub New(ByVal kratisiKwd As Integer, ByVal afixiDate As Date, ByVal anaxwrisiDate As Date, ByVal chkIn As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        kwdKratisis = kratisiKwd
        afixi = afixiDate
        anaxwrisi = anaxwrisiDate
        chkInOk = chkIn
        DwmatKratPck.MinDate = afixiDate
        DwmatKratPck.MaxDate = anaxwrisiDate.AddDays(-1)
        DwmatKratPck.Value = afixiDate
        ' Add akratisiKwdny initialization after the InitializeComponent() call.

    End Sub



    Private Sub DwmatKratBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DwmatKratBtn.Click
        DwmatiaKratPnl.Controls.Clear()
        If chkInOk Then 'Ptwta abfrage gia stay
            Me.StatusTableAdapter.FillByKratisStatus(Me.DbhotelDataSet.status, kwdKratisis, 5)
            If Me.DbhotelDataSet.status.Count <> 0 Then
                zeig_dwmatia_kratisis()
            Else 'over???

            End If
        Else
            Me.StatusTableAdapter.FillByKratisStatus(Me.DbhotelDataSet.status, kwdKratisis, 1)
            If Me.DbhotelDataSet.status.Count <> 0 Then
                zeig_dwmatia_kratisis()
            End If
        End If




    End Sub
    Private Sub zeig_dwmatia_kratisis()
        Dim j, k, pos As Int16
        Dim imeresCount As Int16
        Dim arDwm As String
        Dim count As Integer


        k = DwmatKratPck.Value.Date.DayOfYear - afixi.DayOfYear
        imeresCount = anaxwrisi.DayOfYear - DwmatKratPck.Value.Date.DayOfYear 'afixi.DayOfYear

        pos = 0
        For j = 0 To imeresCount - 1
            If Not chkInOk Then
                Dim dwmLbl As New Label
                dwmLbl.ForeColor = Color.Blue
                dwmLbl.Size = New Point(50, 30)
                dwmLbl.Text = Me.DbhotelDataSet.status(0).dwmatio
                dwmLbl.Location = New Point((pos + 1) * dwmLbl.Width, 5)
                DwmatiaKratPnl.Controls.Add(dwmLbl)
            Else
                arDwm = get_dwm_at_day(afixi.Date.AddDays(j + k))

                If arDwm Is Nothing Then
                    count = Me.OverTableAdapter.ExistOverByKratsisi(kwdKratisis)
                    If count <> 0 Then
                        arDwm = "Ov-Book"
                    End If
                End If
                Dim dwmLbl As New Label
                dwmLbl.ForeColor = Color.Blue
                dwmLbl.Size = New Point(50, 30)
                dwmLbl.Text = arDwm
                dwmLbl.Location = New Point((pos + 1) * dwmLbl.Width, 5)
                DwmatiaKratPnl.Controls.Add(dwmLbl)
            End If
            pos = pos + 1
        Next
    End Sub
    Private Function get_dwm_at_day(ByVal datum As Date) As String
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.status.Count - 1
            If Me.DbhotelDataSet.status(j).enarxi <= datum And Me.DbhotelDataSet.status(j).lixi >= datum Then
                Return Me.DbhotelDataSet.status(j).dwmatio
            End If
        Next
        Return Nothing

    End Function

    Private Sub DwmatiaKratisis_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Finalize()
    End Sub


    Private Sub DwmatiaKratisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.over' table. You can move, or remove it, as needed.
        'Me.OverTableAdapter.Fill(Me.DbhotelDataSet.over)
        'TODO: This line of code loads data into the 'DbhotelDataSet.status' table. You can move, or remove it, as needed.
        'Me.StatusTableAdapter.Fill(Me.DbhotelDataSet.status)

    End Sub

    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
End Class