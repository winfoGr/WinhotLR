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
        Me.wbrWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.userTbx = New System.Windows.Forms.TextBox()
        Me.linkTbx = New System.Windows.Forms.TextBox()
        Me.passwdTbx = New System.Windows.Forms.TextBox()
        Me.Login = New System.Windows.Forms.Button()
        Me.ReloadBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.linkwimdu = New System.Windows.Forms.TextBox()
        Me.userwimdu = New System.Windows.Forms.TextBox()
        Me.logimwimdu = New System.Windows.Forms.Button()
        Me.pwdwimdu = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.linkholiday = New System.Windows.Forms.TextBox()
        Me.userholiday = New System.Windows.Forms.TextBox()
        Me.loginholiday = New System.Windows.Forms.Button()
        Me.icalholiday = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.userTbx.Location = New System.Drawing.Point(1, 56)
        Me.userTbx.Name = "userTbx"
        Me.userTbx.Size = New System.Drawing.Size(81, 20)
        Me.userTbx.TabIndex = 7
        '
        'linkTbx
        '
        Me.linkTbx.Location = New System.Drawing.Point(1, 30)
        Me.linkTbx.Name = "linkTbx"
        Me.linkTbx.Size = New System.Drawing.Size(81, 20)
        Me.linkTbx.TabIndex = 6
        '
        'passwdTbx
        '
        Me.passwdTbx.Location = New System.Drawing.Point(1, 82)
        Me.passwdTbx.Name = "passwdTbx"
        Me.passwdTbx.Size = New System.Drawing.Size(81, 20)
        Me.passwdTbx.TabIndex = 8
        '
        'Login
        '
        Me.Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Login.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Login.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.Login.Location = New System.Drawing.Point(21, 108)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(31, 28)
        Me.Login.TabIndex = 9
        Me.Login.UseVisualStyleBackColor = True
        '
        'ReloadBtn
        '
        Me.ReloadBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ReloadBtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ReloadBtn.Location = New System.Drawing.Point(6, 709)
        Me.ReloadBtn.Name = "ReloadBtn"
        Me.ReloadBtn.Size = New System.Drawing.Size(75, 39)
        Me.ReloadBtn.TabIndex = 10
        Me.ReloadBtn.Text = "RE-LOAD PAGE"
        Me.ReloadBtn.UseVisualStyleBackColor = True
        Me.ReloadBtn.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.linkTbx)
        Me.Panel1.Controls.Add(Me.userTbx)
        Me.Panel1.Controls.Add(Me.Login)
        Me.Panel1.Controls.Add(Me.passwdTbx)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(88, 146)
        Me.Panel1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Leisure"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.linkwimdu)
        Me.Panel2.Controls.Add(Me.userwimdu)
        Me.Panel2.Controls.Add(Me.logimwimdu)
        Me.Panel2.Controls.Add(Me.pwdwimdu)
        Me.Panel2.Location = New System.Drawing.Point(0, 149)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(88, 146)
        Me.Panel2.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Wimdu"
        '
        'linkwimdu
        '
        Me.linkwimdu.Location = New System.Drawing.Point(1, 30)
        Me.linkwimdu.Name = "linkwimdu"
        Me.linkwimdu.Size = New System.Drawing.Size(81, 20)
        Me.linkwimdu.TabIndex = 6
        '
        'userwimdu
        '
        Me.userwimdu.Location = New System.Drawing.Point(1, 56)
        Me.userwimdu.Name = "userwimdu"
        Me.userwimdu.Size = New System.Drawing.Size(81, 20)
        Me.userwimdu.TabIndex = 7
        '
        'logimwimdu
        '
        Me.logimwimdu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.logimwimdu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.logimwimdu.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.logimwimdu.Location = New System.Drawing.Point(21, 108)
        Me.logimwimdu.Name = "logimwimdu"
        Me.logimwimdu.Size = New System.Drawing.Size(31, 28)
        Me.logimwimdu.TabIndex = 9
        Me.logimwimdu.UseVisualStyleBackColor = True
        '
        'pwdwimdu
        '
        Me.pwdwimdu.Location = New System.Drawing.Point(1, 82)
        Me.pwdwimdu.Name = "pwdwimdu"
        Me.pwdwimdu.Size = New System.Drawing.Size(81, 20)
        Me.pwdwimdu.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.linkholiday)
        Me.Panel3.Controls.Add(Me.userholiday)
        Me.Panel3.Controls.Add(Me.loginholiday)
        Me.Panel3.Controls.Add(Me.icalholiday)
        Me.Panel3.Location = New System.Drawing.Point(0, 296)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(88, 143)
        Me.Panel3.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "holidaylett"
        '
        'linkholiday
        '
        Me.linkholiday.Location = New System.Drawing.Point(1, 30)
        Me.linkholiday.Name = "linkholiday"
        Me.linkholiday.Size = New System.Drawing.Size(81, 20)
        Me.linkholiday.TabIndex = 6
        '
        'userholiday
        '
        Me.userholiday.Location = New System.Drawing.Point(0, 56)
        Me.userholiday.Name = "userholiday"
        Me.userholiday.Size = New System.Drawing.Size(81, 20)
        Me.userholiday.TabIndex = 7
        '
        'loginholiday
        '
        Me.loginholiday.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.loginholiday.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.loginholiday.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.loginholiday.Location = New System.Drawing.Point(22, 108)
        Me.loginholiday.Name = "loginholiday"
        Me.loginholiday.Size = New System.Drawing.Size(31, 28)
        Me.loginholiday.TabIndex = 9
        Me.loginholiday.UseVisualStyleBackColor = True
        '
        'icalholiday
        '
        Me.icalholiday.Location = New System.Drawing.Point(1, 82)
        Me.icalholiday.Name = "icalholiday"
        Me.icalholiday.Size = New System.Drawing.Size(81, 20)
        Me.icalholiday.TabIndex = 8
        '
        'Leisure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1224, 750)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ReloadBtn)
        Me.Controls.Add(Me.wbrWebBrowser)
        Me.Name = "Leisure"
        Me.Text = "Leisure"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wbrWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents userTbx As System.Windows.Forms.TextBox
    Friend WithEvents linkTbx As System.Windows.Forms.TextBox
    Friend WithEvents passwdTbx As System.Windows.Forms.TextBox
    Friend WithEvents Login As System.Windows.Forms.Button
    Friend WithEvents ReloadBtn As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents linkwimdu As System.Windows.Forms.TextBox
    Friend WithEvents userwimdu As System.Windows.Forms.TextBox
    Friend WithEvents logimwimdu As System.Windows.Forms.Button
    Friend WithEvents pwdwimdu As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents linkholiday As System.Windows.Forms.TextBox
    Friend WithEvents userholiday As System.Windows.Forms.TextBox
    Friend WithEvents loginholiday As System.Windows.Forms.Button
    Friend WithEvents icalholiday As System.Windows.Forms.TextBox
End Class
