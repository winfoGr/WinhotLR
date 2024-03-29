Public Class BiblioPortasTheorisi
    Dim status As Byte
    Dim flag As Byte
    Dim theorisiOK As Boolean


    Private Sub EktiposBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EktiposBtn.Click
        Dim j As Int32
        Try
            If CType(AATbx.Text, Int32) > 0 AndAlso CType(PlithosTbx.Text, Int16) > 0 Then
                For j = CType(AATbx.Text, Int32) To ((CType(AATbx.Text, Int32) + CType(PlithosTbx.Text, Int16)) - 1)
                    'MsgBox(j)
                    Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
                    Me.DbhotelDataSet.ektiposeis_genika(j - CType(AATbx.Text, Int32)).aa = j
                    Me.DbhotelDataSet.ektiposeis_genika(j - CType(AATbx.Text, Int32)).flag = flag
                Next
                Me.Close()
                Me.Finalize()
                proepiskopisi_theorimenwn()
            Else
                MsgBox("Δώστε ΑΑ αρχής και πλήθος σελίδων !", MsgBoxStyle.Information, "winfo\ma.nik")
            End If
        Catch ex As InvalidCastException
            MsgBox("Δώστε ΑΑ αρχής και πλήθος σελίδων !", MsgBoxStyle.Information, "winfo\ma.nik")
        End Try

    End Sub
    Private Sub proepiskopisi_theorimenwn()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New BiblioKinisis()
        'MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio.Count)

        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.DisplayGroupTree = False

        CrystalReportViewer1.ReportSource = ektiposi
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        CrystalReportViewer1.Visible = False
    End Sub
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
    Private Sub BiblioPortasTheorisi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.etaireia' table. You can move, or remove it, as needed.
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)

    End Sub

   
  
    Public Sub New(ByVal stat As Byte)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        status = stat
        flag = status

        If status = 1 Then
            TheorRdb.Visible = False
            AploRdb.Visible = False
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub AploRdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AploRdb.Click
        If status = 2 Then
            AATbx.Text = 1
            AATbx.Enabled = False
            flag = 3
        Else
            AATbx.Enabled = True
        End If
    End Sub
End Class