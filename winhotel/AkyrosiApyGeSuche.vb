Public Class AkyrosiApyGeSuche
    Dim imeromErgasias As Date
    Dim etos As Int16
    Dim kwdTim, kwdGE As Int32
    Dim aa As Int16
    Dim eponimia As String
    Dim brutoPos As Single
    Dim status As Byte

    Public Sub New(ByVal imerominia As Date, ByVal stat As Byte, ByVal parast As Integer)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        imeromErgasias = imerominia
        etos = imerominia.Year
        status = stat
        kwdTim = -1
        kwdGE = -1
        'kane laden timologia IMERAS pou DEN einai akyromena
        If status = 1 Then
            GEAkyrosiDgrdView.Visible = False
            EpanekdosiDgrdView.Dock = DockStyle.Fill
            Me.Text = "Α.Π.Υ. της " + imeromErgasias.ToShortDateString
            Me.EpanekdositimologiouTableAdapter.FillTimolImerasProsAkyrosiByImeromParst(Me.DbhotelDataSet.epanekdositimologiou, imeromErgasias, False, parast)
        ElseIf status = 2 Then
            EpanekdosiDgrdView.Visible = False
            GEAkyrosiDgrdView.Dock = DockStyle.Fill
            Me.Text = "Γραμμάτια Είσπραξης της " + imeromErgasias.ToShortDateString
            Me.GramatiaTableAdapter.FillJoinGramatiaOnomaByImerAkyro(Me.DbhotelDataSet.gramatia, imeromErgasias, False)
        End If


    End Sub
    

    Private Sub EpanekdosiDgrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EpanekdosiDgrdView.DoubleClick
        If status = 1 Then
            If EpanekdosiDgrdView.RowCount <> 0 Then

                Try
                    kwdTim = (EpanekdosiDgrdView.Item(0, EpanekdosiDgrdView.CurrentRow.Index).Value)


                    ' If praktkwd <> Nothing And Me.EthnikotitesTableAdapter.ExistEthnikotites(KratiseisenilikesDataGridView.Item(0, KratiseisenilikesDataGridView.CurrentRow.Index).Value.ToString <> 0 Then
                    If kwdTim <> Nothing Then
                        Me.TimologiaTableAdapter.FillTimologioByKwdikoAkyr(Me.DbhotelDataSet.timologia, kwdTim, False)
                        If Me.DbhotelDataSet.timologia.Count <> 0 Then
                            'MsgBox(praktkwd)
                            aa = EpanekdosiDgrdView.Item(1, EpanekdosiDgrdView.CurrentRow.Index).Value.ToString
                            eponimia = EpanekdosiDgrdView.Item(3, EpanekdosiDgrdView.CurrentRow.Index).Value.ToString
                            brutoPos = EpanekdosiDgrdView.Item(5, EpanekdosiDgrdView.CurrentRow.Index).Value.ToString

                            Me.Close()
                            Me.Finalize()
                        Else
                            kwdTim = -1
                            Me.Close()
                            Me.Finalize()
                        End If
                    Else
                        kwdTim = -1
                        Me.Close()
                        Me.Finalize()
                    End If

                Catch ex As ArgumentOutOfRangeException

                Catch ex1 As IndexOutOfRangeException

                End Try
            End If
        End If
        
    End Sub
    Private Sub GEAkyrosiDgrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GEAkyrosiDgrdView.DoubleClick
        If status = 2 Then
            If GEAkyrosiDgrdView.RowCount <> 0 Then

                Try
                    kwdGE = (GEAkyrosiDgrdView.Item(0, GEAkyrosiDgrdView.CurrentRow.Index).Value)


                    ' If praktkwd <> Nothing And Me.EthnikotitesTableAdapter.ExistEthnikotites(KratiseisenilikesDataGridView.Item(0, KratiseisenilikesDataGridView.CurrentRow.Index).Value.ToString <> 0 Then
                    If kwdGE <> Nothing Then
                       
                        'MsgBox(praktkwd)
                        aa = GEAkyrosiDgrdView.Item(1, GEAkyrosiDgrdView.CurrentRow.Index).Value.ToString
                        eponimia = GEAkyrosiDgrdView.Item(3, GEAkyrosiDgrdView.CurrentRow.Index).Value.ToString
                        brutoPos = GEAkyrosiDgrdView.Item(4, GEAkyrosiDgrdView.CurrentRow.Index).Value.ToString

                        Me.Close()
                        Me.Finalize()
                  
                    Else
                        kwdGE = -1
                        Me.Close()
                        Me.Finalize()
                    End If

                Catch ex As ArgumentOutOfRangeException

                Catch ex1 As IndexOutOfRangeException

                End Try
            End If
        End If
    End Sub
    Public Function return_kwdiko_apy() As Integer
        Return kwdTim
    End Function
    Public Function return_kwdiko_ge() As Integer
        Return kwdGE
    End Function
    Public Function return_aa_apy() As Int16
        Return aa
    End Function
    Public Function return_aa_ge() As Int16
        Return aa
    End Function
    Public Function return_eponimia_apy() As String
        Return eponimia
    End Function
    Public Function return_eponimia_ge() As String
        Return eponimia
    End Function
    Public Function return_synol_poso_apy() As Single
        Return brutoPos
    End Function
    Public Function return_synol_poso_ge() As Single
        Return brutoPos
    End Function
    'Private Sub AkyrosiApyGeSuche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.gramatia' table. You can move, or remove it, as needed.
    '    Me.GramatiaTableAdapter.Fill(Me.DbhotelDataSet.gramatia)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.kratiseisenilikes' table. You can move, or remove it, as needed.
    '    Me.KratiseisenilikesTableAdapter.Fill(Me.DbhotelDataSet.kratiseisenilikes)

    'End Sub

 
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
End Class