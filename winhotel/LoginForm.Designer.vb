<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.components = New System.ComponentModel.Container()
        Me.PassWordTbx = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.okBtn = New System.Windows.Forms.Button()
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.RechteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RechteTableAdapter = New winhotel.dbhotelDataSetTableAdapters.rechteTableAdapter()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RechteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PassWordTbx
        '
        Me.PassWordTbx.Location = New System.Drawing.Point(84, 31)
        Me.PassWordTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.PassWordTbx.MaxLength = 9
        Me.PassWordTbx.Name = "PassWordTbx"
        Me.PassWordTbx.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassWordTbx.Size = New System.Drawing.Size(63, 22)
        Me.PassWordTbx.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(47, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "password:"
        '
        'okBtn
        '
        Me.okBtn.BackColor = System.Drawing.Color.Silver
        Me.okBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.okBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.okBtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.okBtn.Location = New System.Drawing.Point(84, 68)
        Me.okBtn.Name = "okBtn"
        Me.okBtn.Size = New System.Drawing.Size(63, 30)
        Me.okBtn.TabIndex = 51
        Me.okBtn.Text = "ΟΚ!"
        Me.okBtn.UseVisualStyleBackColor = False
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RechteBindingSource
        '
        Me.RechteBindingSource.DataMember = "rechte"
        Me.RechteBindingSource.DataSource = Me.DbhotelDataSet
        '
        'RechteTableAdapter
        '
        Me.RechteTableAdapter.ClearBeforeFill = True
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(246, 118)
        Me.Controls.Add(Me.okBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PassWordTbx)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RechteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PassWordTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents okBtn As System.Windows.Forms.Button
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents RechteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RechteTableAdapter As winhotel.dbhotelDataSetTableAdapters.rechteTableAdapter
End Class
