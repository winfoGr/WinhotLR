Public Class SearchForm

    Private Sub DiamenBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiamenBtn.Click

        If Not EponimoTbx.Text.Equals("") And Not emailTbx.Text.Equals("") And Not dwmTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter.OldCustomersOnomMailDwm(Me.DbhotelDataSet.OldCustomers, etosPck.Value.Year, True, "%" + Trim(EponimoTbx.Text) + "%", _
                                                                etosPck.Value.Year, True, "%" + Trim(emailTbx.Text) + "%", etosPck.Value.Year, True, dwmTbx.Text)
        ElseIf Not EponimoTbx.Text.Equals("") And Not emailTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter.OldCustomOnomMail(Me.DbhotelDataSet.OldCustomers, etosPck.Value.Year, True, "%" + Trim(EponimoTbx.Text) + "%", _
                                                               etosPck.Value.Year, True, "%" + Trim(emailTbx.Text) + "%")
        ElseIf Not EponimoTbx.Text.Equals("") And Not dwmTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter.OlCustomOnomDwm(Me.DbhotelDataSet.OldCustomers, etosPck.Value.Year, True, "%" + Trim(EponimoTbx.Text) + "%", _
                                                               etosPck.Value.Year, True, dwmTbx.Text)
        ElseIf Not EponimoTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter.OldCustomOnoma(Me.DbhotelDataSet.OldCustomers, etosPck.Value.Year, "%" + Trim(EponimoTbx.Text) + "%", True)
        ElseIf Not emailTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter.OldCustomMail(Me.DbhotelDataSet.OldCustomers, etosPck.Value.Year, "%" + Trim(emailTbx.Text) + "%", True)
        ElseIf Not dwmTbx.Text.Equals("") Then
            Me.OldCustomersTableAdapter.OldCustomDwm(Me.DbhotelDataSet.OldCustomers, etosPck.Value.Year, dwmTbx.Text, True)
        Else
            Me.OldCustomersTableAdapter.OldCustomALL(Me.DbhotelDataSet.OldCustomers, etosPck.Value.Year, True)
            'Me.DbhotelDataSet.OldCustomers.Clear()
        End If
       
    End Sub

    Public Sub New(ByVal etos As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        etosPck.Value = etos

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub SearchForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Finalize()
    End Sub
End Class