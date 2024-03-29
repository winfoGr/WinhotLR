Public Class SearchForm

    Private Sub DiamenBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiamenBtn.Click

        If Not EponimoTbx.Text.Equals("") And Not emailTbx.Text.Equals("") And Not dwmTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter1.OldCustomersOnomMailDwm(Me.DbhotelDataSet1.OldCustomers, True, "%" + Trim(EponimoTbx.Text) + "%", _
                                                                True, "%" + Trim(emailTbx.Text) + "%", True, dwmTbx.Text)
        ElseIf Not EponimoTbx.Text.Equals("") And Not emailTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter1.OldCustomOnomMail(Me.DbhotelDataSet1.OldCustomers, True, "%" + Trim(EponimoTbx.Text) + "%", _
                                                               True, "%" + Trim(emailTbx.Text) + "%")
        ElseIf Not EponimoTbx.Text.Equals("") And Not dwmTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter1.OlCustomOnomDwm(Me.DbhotelDataSet1.OldCustomers, True, "%" + Trim(EponimoTbx.Text) + "%", _
                                                                True, dwmTbx.Text)
        ElseIf Not EponimoTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter1.OldCustomOnoma(Me.DbhotelDataSet1.OldCustomers, "%" + Trim(EponimoTbx.Text) + "%", True)
        ElseIf Not emailTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter1.OldCustomMail(Me.DbhotelDataSet1.OldCustomers, "%" + Trim(emailTbx.Text) + "%", True)
        ElseIf Not dwmTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter1.OldCustomDwm(Me.DbhotelDataSet1.OldCustomers, dwmTbx.Text, True)
        Else
            Me.OldCustomersTableAdapter1.OldCustomALL(Me.DbhotelDataSet1.OldCustomers, True)
            'Me.DbhotelDataSet.OldCustomers.Clear()
        End If

    End Sub

    Public Sub New(ByVal etos As Date)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'etosPck.Value = etos
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub SearchForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Finalize()
    End Sub

   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.OldCustomersTableAdapter1.FillMaillist(Me.DbhotelDataSet1.OldCustomers)
        Dim i As Int16
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New MailList()


        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        ektiposi.SetDataSource(DbhotelDataSet1)
        CrystalReportViewer1.ReportSource = ektiposi
        'CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()

    End Sub
End Class