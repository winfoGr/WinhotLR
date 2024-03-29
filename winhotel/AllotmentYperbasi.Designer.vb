<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AllotmentYperbasi
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
        Me.YperbasiPnl = New System.Windows.Forms.Panel
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.AllotmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AllotmentTableAdapter = New winhotel.dbhotelDataSetTableAdapters.allotmentTableAdapter
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllotmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'YperbasiPnl
        '
        Me.YperbasiPnl.AutoScroll = True
        Me.YperbasiPnl.BackColor = System.Drawing.SystemColors.Control
        Me.YperbasiPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.YperbasiPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.YperbasiPnl.ForeColor = System.Drawing.Color.Blue
        Me.YperbasiPnl.Location = New System.Drawing.Point(0, 0)
        Me.YperbasiPnl.Name = "YperbasiPnl"
        Me.YperbasiPnl.Size = New System.Drawing.Size(360, 54)
        Me.YperbasiPnl.TabIndex = 0
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AllotmentBindingSource
        '
        Me.AllotmentBindingSource.DataMember = "allotment"
        Me.AllotmentBindingSource.DataSource = Me.DbhotelDataSet
        '
        'AllotmentTableAdapter
        '
        Me.AllotmentTableAdapter.ClearBeforeFill = True
        '
        'KratiseisBindingSource
        '
        Me.KratiseisBindingSource.DataMember = "kratiseis"
        Me.KratiseisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KratiseisTableAdapter
        '
        Me.KratiseisTableAdapter.ClearBeforeFill = True
        '
        'AllotmentYperbasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 54)
        Me.Controls.Add(Me.YperbasiPnl)
        Me.KeyPreview = True
        Me.Name = "AllotmentYperbasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Υπέρβαση Allotment ανά  Ημερ. Διαμονής"
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllotmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents YperbasiPnl As System.Windows.Forms.Panel
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents AllotmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AllotmentTableAdapter As winhotel.dbhotelDataSetTableAdapters.allotmentTableAdapter
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
End Class
