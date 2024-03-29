<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Newsletter
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Newsletter))
        Me.excelTbx = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.sendBtn = New System.Windows.Forms.Button
        Me.emailagPnl = New System.Windows.Forms.Panel
        Me.attachTbx = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.emailagBtn = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.bodyagRTbx = New System.Windows.Forms.RichTextBox
        Me.subjectagTbx = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
        Me.emailagPnl.SuspendLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'excelTbx
        '
        Me.excelTbx.Location = New System.Drawing.Point(172, 300)
        Me.excelTbx.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.excelTbx.Name = "excelTbx"
        Me.excelTbx.Size = New System.Drawing.Size(343, 21)
        Me.excelTbx.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(50, 291)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Excel Αρχείο"
        '
        'sendBtn
        '
        Me.sendBtn.BackColor = System.Drawing.Color.White
        Me.sendBtn.Image = Global.winhotel.My.Resources.Resources.PEG08
        Me.sendBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.sendBtn.Location = New System.Drawing.Point(225, 355)
        Me.sendBtn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.sendBtn.Name = "sendBtn"
        Me.sendBtn.Size = New System.Drawing.Size(144, 27)
        Me.sendBtn.TabIndex = 9
        Me.sendBtn.Text = "SEND"
        Me.sendBtn.UseVisualStyleBackColor = False
        '
        'emailagPnl
        '
        Me.emailagPnl.BackColor = System.Drawing.Color.LightGray
        Me.emailagPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.emailagPnl.Controls.Add(Me.attachTbx)
        Me.emailagPnl.Controls.Add(Me.Label1)
        Me.emailagPnl.Controls.Add(Me.emailagBtn)
        Me.emailagPnl.Controls.Add(Me.Label26)
        Me.emailagPnl.Controls.Add(Me.Label31)
        Me.emailagPnl.Controls.Add(Me.bodyagRTbx)
        Me.emailagPnl.Controls.Add(Me.subjectagTbx)
        Me.emailagPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.emailagPnl.Location = New System.Drawing.Point(6, 8)
        Me.emailagPnl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.emailagPnl.Name = "emailagPnl"
        Me.emailagPnl.Size = New System.Drawing.Size(584, 271)
        Me.emailagPnl.TabIndex = 10
        '
        'attachTbx
        '
        Me.attachTbx.Location = New System.Drawing.Point(116, 188)
        Me.attachTbx.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.attachTbx.Name = "attachTbx"
        Me.attachTbx.Size = New System.Drawing.Size(413, 21)
        Me.attachTbx.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 191)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Attachment:"
        '
        'emailagBtn
        '
        Me.emailagBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.emailagBtn.Image = CType(resources.GetObject("emailagBtn.Image"), System.Drawing.Image)
        Me.emailagBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.emailagBtn.Location = New System.Drawing.Point(217, 228)
        Me.emailagBtn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.emailagBtn.Name = "emailagBtn"
        Me.emailagBtn.Size = New System.Drawing.Size(144, 27)
        Me.emailagBtn.TabIndex = 48
        Me.emailagBtn.Text = "SAVE"
        Me.emailagBtn.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(63, 53)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(42, 15)
        Me.Label26.TabIndex = 14
        Me.Label26.Text = "Body:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(48, 15)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(57, 15)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "subject:"
        '
        'bodyagRTbx
        '
        Me.bodyagRTbx.Location = New System.Drawing.Point(113, 51)
        Me.bodyagRTbx.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bodyagRTbx.MaxLength = 10000
        Me.bodyagRTbx.Name = "bodyagRTbx"
        Me.bodyagRTbx.Size = New System.Drawing.Size(383, 121)
        Me.bodyagRTbx.TabIndex = 4
        Me.bodyagRTbx.Text = ""
        '
        'subjectagTbx
        '
        Me.subjectagTbx.Location = New System.Drawing.Point(116, 12)
        Me.subjectagTbx.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.subjectagTbx.MaxLength = 50
        Me.subjectagTbx.Name = "subjectagTbx"
        Me.subjectagTbx.Size = New System.Drawing.Size(380, 21)
        Me.subjectagTbx.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(50, 307)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "με διευθύνσεις:"
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EtaireiaBindingSource
        '
        Me.EtaireiaBindingSource.DataMember = "etaireia"
        Me.EtaireiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EtaireiaTableAdapter
        '
        Me.EtaireiaTableAdapter.ClearBeforeFill = True
        '
        'Newsletter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(597, 395)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.emailagPnl)
        Me.Controls.Add(Me.sendBtn)
        Me.Controls.Add(Me.excelTbx)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Newsletter"
        Me.Text = "Newsletter"
        Me.emailagPnl.ResumeLayout(False)
        Me.emailagPnl.PerformLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents excelTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents sendBtn As System.Windows.Forms.Button
    Friend WithEvents emailagPnl As System.Windows.Forms.Panel
    Friend WithEvents emailagBtn As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents bodyagRTbx As System.Windows.Forms.RichTextBox
    Friend WithEvents subjectagTbx As System.Windows.Forms.TextBox
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents attachTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
