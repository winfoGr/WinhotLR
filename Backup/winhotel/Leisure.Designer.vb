<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Leisure
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.wbrWebBrowser = New System.Windows.Forms.WebBrowser
        Me.userTbx = New System.Windows.Forms.TextBox
        Me.linkTbx = New System.Windows.Forms.TextBox
        Me.passwdTbx = New System.Windows.Forms.TextBox
        Me.Login = New System.Windows.Forms.Button
        Me.ReloadBtn = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'wbrWebBrowser
        '
        Me.wbrWebBrowser.Location = New System.Drawing.Point(90, 1)
        Me.wbrWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbrWebBrowser.Name = "wbrWebBrowser"
        Me.wbrWebBrowser.Size = New System.Drawing.Size(1122, 751)
        Me.wbrWebBrowser.TabIndex = 2
        '
        'userTbx
        '
        Me.userTbx.Location = New System.Drawing.Point(3, 75)
        Me.userTbx.Name = "userTbx"
        Me.userTbx.Size = New System.Drawing.Size(81, 20)
        Me.userTbx.TabIndex = 7
        '
        'linkTbx
        '
        Me.linkTbx.Location = New System.Drawing.Point(3, 49)
        Me.linkTbx.Name = "linkTbx"
        Me.linkTbx.Size = New System.Drawing.Size(81, 20)
        Me.linkTbx.TabIndex = 6
        '
        'passwdTbx
        '
        Me.passwdTbx.Location = New System.Drawing.Point(3, 101)
        Me.passwdTbx.Name = "passwdTbx"
        Me.passwdTbx.Size = New System.Drawing.Size(81, 20)
        Me.passwdTbx.TabIndex = 8
        '
        'Login
        '
        Me.Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Login.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Login.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.Login.Location = New System.Drawing.Point(23, 139)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(31, 33)
        Me.Login.TabIndex = 9
        Me.Login.UseVisualStyleBackColor = True
        '
        'ReloadBtn
        '
        Me.ReloadBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ReloadBtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ReloadBtn.Location = New System.Drawing.Point(9, 4)
        Me.ReloadBtn.Name = "ReloadBtn"
        Me.ReloadBtn.Size = New System.Drawing.Size(75, 39)
        Me.ReloadBtn.TabIndex = 10
        Me.ReloadBtn.Text = "RE-LOAD PAGE"
        Me.ReloadBtn.UseVisualStyleBackColor = True
        '
        'Leisure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1224, 764)
        Me.Controls.Add(Me.ReloadBtn)
        Me.Controls.Add(Me.Login)
        Me.Controls.Add(Me.passwdTbx)
        Me.Controls.Add(Me.userTbx)
        Me.Controls.Add(Me.linkTbx)
        Me.Controls.Add(Me.wbrWebBrowser)
        Me.Name = "Leisure"
        Me.Text = "Leisure"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wbrWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents userTbx As System.Windows.Forms.TextBox
    Friend WithEvents linkTbx As System.Windows.Forms.TextBox
    Friend WithEvents passwdTbx As System.Windows.Forms.TextBox
    Friend WithEvents Login As System.Windows.Forms.Button
    Friend WithEvents ReloadBtn As System.Windows.Forms.Button
End Class
