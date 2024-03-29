<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeyFrm
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
        Me.keyTbx = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.okBtn = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'keyTbx
        '
        Me.keyTbx.Location = New System.Drawing.Point(86, 38)
        Me.keyTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.keyTbx.MaxLength = 15
        Me.keyTbx.Name = "keyTbx"
        Me.keyTbx.Size = New System.Drawing.Size(121, 22)
        Me.keyTbx.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Δώστε κλειδί εφαρμογής:"
        '
        'okBtn
        '
        Me.okBtn.BackColor = System.Drawing.Color.Silver
        Me.okBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.okBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.okBtn.ForeColor = System.Drawing.Color.Green
        Me.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.okBtn.Location = New System.Drawing.Point(106, 67)
        Me.okBtn.Name = "okBtn"
        Me.okBtn.Size = New System.Drawing.Size(63, 30)
        Me.okBtn.TabIndex = 52
        Me.okBtn.Text = "ΟΚ!"
        Me.okBtn.UseVisualStyleBackColor = False
        '
        'KeyFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(312, 102)
        Me.Controls.Add(Me.okBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.keyTbx)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "KeyFrm"
        Me.Text = "Product Key"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents keyTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents okBtn As System.Windows.Forms.Button
End Class
