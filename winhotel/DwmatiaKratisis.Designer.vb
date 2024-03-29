<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DwmatiaKratisis
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
        Me.DwmatiaKratPnl = New System.Windows.Forms.Panel
        Me.DwmatKratPck = New System.Windows.Forms.DateTimePicker
        Me.DwmatKratBtn = New System.Windows.Forms.Button
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.StatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusTableAdapter = New winhotel.dbhotelDataSetTableAdapters.statusTableAdapter
        Me.OverBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OverTableAdapter = New winhotel.dbhotelDataSetTableAdapters.overTableAdapter
        Me.DwmatiaKratLbl = New System.Windows.Forms.Label
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OverBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DwmatiaKratPnl
        '
        Me.DwmatiaKratPnl.AutoScroll = True
        Me.DwmatiaKratPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.DwmatiaKratPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DwmatiaKratPnl.Location = New System.Drawing.Point(2, 51)
        Me.DwmatiaKratPnl.Name = "DwmatiaKratPnl"
        Me.DwmatiaKratPnl.Size = New System.Drawing.Size(472, 55)
        Me.DwmatiaKratPnl.TabIndex = 0
        '
        'DwmatKratPck
        '
        Me.DwmatKratPck.Location = New System.Drawing.Point(133, 17)
        Me.DwmatKratPck.Name = "DwmatKratPck"
        Me.DwmatKratPck.Size = New System.Drawing.Size(233, 20)
        Me.DwmatKratPck.TabIndex = 1
        '
        'DwmatKratBtn
        '
        Me.DwmatKratBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DwmatKratBtn.Image = Global.winhotel.My.Resources.Resources.P21
        Me.DwmatKratBtn.Location = New System.Drawing.Point(374, 9)
        Me.DwmatKratBtn.Name = "DwmatKratBtn"
        Me.DwmatKratBtn.Size = New System.Drawing.Size(37, 36)
        Me.DwmatKratBtn.TabIndex = 31
        Me.DwmatKratBtn.UseVisualStyleBackColor = True
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StatusBindingSource
        '
        Me.StatusBindingSource.DataMember = "status"
        Me.StatusBindingSource.DataSource = Me.DbhotelDataSet
        '
        'StatusTableAdapter
        '
        Me.StatusTableAdapter.ClearBeforeFill = True
        '
        'OverBindingSource
        '
        Me.OverBindingSource.DataMember = "over"
        Me.OverBindingSource.DataSource = Me.DbhotelDataSet
        '
        'OverTableAdapter
        '
        Me.OverTableAdapter.ClearBeforeFill = True
        '
        'DwmatiaKratLbl
        '
        Me.DwmatiaKratLbl.AutoSize = True
        Me.DwmatiaKratLbl.Location = New System.Drawing.Point(21, 21)
        Me.DwmatiaKratLbl.Name = "DwmatiaKratLbl"
        Me.DwmatiaKratLbl.Size = New System.Drawing.Size(106, 13)
        Me.DwmatiaKratLbl.TabIndex = 32
        Me.DwmatiaKratLbl.Text = "Από Ημερομηνία:"
        '
        'DwmatiaKratisis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(476, 110)
        Me.Controls.Add(Me.DwmatiaKratLbl)
        Me.Controls.Add(Me.DwmatKratBtn)
        Me.Controls.Add(Me.DwmatKratPck)
        Me.Controls.Add(Me.DwmatiaKratPnl)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Name = "DwmatiaKratisis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DwmatiaKratisis"
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OverBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DwmatiaKratPnl As System.Windows.Forms.Panel
    Friend WithEvents DwmatKratPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents DwmatKratBtn As System.Windows.Forms.Button
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents StatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StatusTableAdapter As winhotel.dbhotelDataSetTableAdapters.statusTableAdapter
    Friend WithEvents OverBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OverTableAdapter As winhotel.dbhotelDataSetTableAdapters.overTableAdapter
    Friend WithEvents DwmatiaKratLbl As System.Windows.Forms.Label
End Class
