Public Class XrewseisPrakt

    Dim kwdXrews, kwdTim As Integer
    Public Sub New(ByVal kwdPrakt As Integer, ByVal imerom As Date)
        'Dim imerom As Date = "1/1/" + etos.ToString
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        fill_dt_grid(kwdPrakt, imerom)
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub fill_dt_grid(ByVal kwdPrakt As Integer, ByVal imerom As Date)
        Dim j As Int16
        Dim d As Single
        'fortwse Extra Parastatika
        Me.TimologiaTableAdapter.FillByPraktImeromMauroAkyrExtra(Me.DbhotelDataSet.timologia, kwdPrakt, imerom, False, False, True)
        For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Rows.Add()

            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).kwdTimol = Me.DbhotelDataSet.timologia(j).kwd

            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).kwdXrewsPrakt = Nothing
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).parast1 = Nothing
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).parast2 = Me.DbhotelDataSet.timologia(j).parastatiko
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).parast3 = Me.DbhotelDataSet.timologia(j).aa
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).imerom = Me.DbhotelDataSet.timologia(j).imerominia
            d = Me.DbhotelDataSet.timologia(j).synola
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).xrewsi = d.ToString("N")

        Next
        Me.XrewseispraktoreiaTableAdapter.FillByPraktImerom(Me.DbhotelDataSet.xrewseispraktoreia, kwdPrakt, imerom)
        For j = 0 To Me.DbhotelDataSet.xrewseispraktoreia.Count - 1
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Rows.Add()
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).kwdTimol = Nothing
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).kwdXrewsPrakt = Me.DbhotelDataSet.xrewseispraktoreia(j).kwd
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).parast1 = Nothing
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).parast2 = Me.DbhotelDataSet.xrewseispraktoreia(j).parast2
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).parast3 = Me.DbhotelDataSet.xrewseispraktoreia(j).parast3
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).imerom = Me.DbhotelDataSet.xrewseispraktoreia(j).imerominia
            d = Me.DbhotelDataSet.xrewseispraktoreia(j).xrewsi
            Me.DbhotelDataSet.xrewseis_timologia_praktoreiou(Me.DbhotelDataSet.xrewseis_timologia_praktoreiou.Count - 1).xrewsi = d.ToString("N")
        Next

    End Sub
    Private Sub XrewseisPraktDtGrd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Finalize()
    End Sub

    Private Sub XrewseisPraktDtGrd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles XrewseisPraktDtGrd.DoubleClick
        If XrewseisPraktDtGrd.RowCount <> 0 Then

            Try
                Try
                    kwdTim = (XrewseisPraktDtGrd.Item(0, XrewseisPraktDtGrd.CurrentRow.Index).Value)
                Catch ex As InvalidCastException
                    kwdTim = -1
                End Try
                Try
                    kwdXrews = (XrewseisPraktDtGrd.Item(1, XrewseisPraktDtGrd.CurrentRow.Index).Value)
                Catch ex As InvalidCastException
                    kwdXrews = -1
                End Try

                Me.Close()
                Me.Finalize()
                ' If praktkwd <> Nothing And Me.EthnikotitesTableAdapter.ExistEthnikotites(EthnikotitesDataGridView.Item(0, EthnikotitesDataGridView.CurrentRow.Index).Value.ToString <> 0 Then

            Catch ex As ArgumentOutOfRangeException

            Catch ex1 As IndexOutOfRangeException

            End Try
        End If
    End Sub
    Public Function return_kwd_xrewsisprakt() As Integer
        Return kwdXrews
    End Function
    Public Function return_kwd_timolog() As Integer
        Return kwdTim
    End Function

  
    Private Sub XrewseisPrakt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.timologia' table. You can move, or remove it, as needed.
        Me.TimologiaTableAdapter.Fill(Me.DbhotelDataSet.timologia)

    End Sub

  
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub

    
    
End Class