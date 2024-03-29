<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FreeDwmatImerom
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
        Me.FreeDwmatImeromDtGrd = New System.Windows.Forms.DataGridView
        Me.KlinesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TiposDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ArithmosDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreedwmatiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.FreeDwmatImeromPck = New System.Windows.Forms.DateTimePicker
        Me.FreeDwmatImeromBtn = New System.Windows.Forms.Button
        Me.KlinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KlinesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.klinesTableAdapter
        Me.TipoiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TipoiTableAdapter = New winhotel.dbhotelDataSetTableAdapters.tipoiTableAdapter
        Me.DwmatiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DwmatiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.dwmatiaTableAdapter
        Me.KatigoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KatigoriesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.katigoriesTableAdapter
        Me.StatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusTableAdapter = New winhotel.dbhotelDataSetTableAdapters.statusTableAdapter
        Me.EpomDwmBtn = New System.Windows.Forms.Button
        Me.PrDwmBtn = New System.Windows.Forms.Button
        CType(Me.FreeDwmatImeromDtGrd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FreedwmatiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KlinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TipoiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KatigoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FreeDwmatImeromDtGrd
        '
        Me.FreeDwmatImeromDtGrd.AllowUserToAddRows = False
        Me.FreeDwmatImeromDtGrd.AllowUserToDeleteRows = False
        Me.FreeDwmatImeromDtGrd.AutoGenerateColumns = False
        Me.FreeDwmatImeromDtGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FreeDwmatImeromDtGrd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KlinesDataGridViewTextBoxColumn, Me.TiposDataGridViewTextBoxColumn, Me.ArithmosDataGridViewTextBoxColumn})
        Me.FreeDwmatImeromDtGrd.DataSource = Me.FreedwmatiaBindingSource
        Me.FreeDwmatImeromDtGrd.Location = New System.Drawing.Point(2, 53)
        Me.FreeDwmatImeromDtGrd.Margin = New System.Windows.Forms.Padding(4)
        Me.FreeDwmatImeromDtGrd.Name = "FreeDwmatImeromDtGrd"
        Me.FreeDwmatImeromDtGrd.ReadOnly = True
        Me.FreeDwmatImeromDtGrd.Size = New System.Drawing.Size(369, 256)
        Me.FreeDwmatImeromDtGrd.TabIndex = 0
        '
        'KlinesDataGridViewTextBoxColumn
        '
        Me.KlinesDataGridViewTextBoxColumn.DataPropertyName = "klines"
        Me.KlinesDataGridViewTextBoxColumn.HeaderText = "Κλίνες"
        Me.KlinesDataGridViewTextBoxColumn.Name = "KlinesDataGridViewTextBoxColumn"
        Me.KlinesDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TiposDataGridViewTextBoxColumn
        '
        Me.TiposDataGridViewTextBoxColumn.DataPropertyName = "tipos"
        Me.TiposDataGridViewTextBoxColumn.HeaderText = "Τύπος(Θέα)"
        Me.TiposDataGridViewTextBoxColumn.Name = "TiposDataGridViewTextBoxColumn"
        Me.TiposDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ArithmosDataGridViewTextBoxColumn
        '
        Me.ArithmosDataGridViewTextBoxColumn.DataPropertyName = "arithmos"
        Me.ArithmosDataGridViewTextBoxColumn.HeaderText = "Αριθμός"
        Me.ArithmosDataGridViewTextBoxColumn.Name = "ArithmosDataGridViewTextBoxColumn"
        Me.ArithmosDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FreedwmatiaBindingSource
        '
        Me.FreedwmatiaBindingSource.DataMember = "freedwmatia"
        Me.FreedwmatiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ημερομηνία:"
        '
        'FreeDwmatImeromPck
        '
        Me.FreeDwmatImeromPck.Location = New System.Drawing.Point(100, 9)
        Me.FreeDwmatImeromPck.Name = "FreeDwmatImeromPck"
        Me.FreeDwmatImeromPck.Size = New System.Drawing.Size(200, 22)
        Me.FreeDwmatImeromPck.TabIndex = 2
        '
        'FreeDwmatImeromBtn
        '
        Me.FreeDwmatImeromBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FreeDwmatImeromBtn.Image = Global.winhotel.My.Resources.Resources.P21
        Me.FreeDwmatImeromBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FreeDwmatImeromBtn.Location = New System.Drawing.Point(306, 5)
        Me.FreeDwmatImeromBtn.Name = "FreeDwmatImeromBtn"
        Me.FreeDwmatImeromBtn.Size = New System.Drawing.Size(42, 31)
        Me.FreeDwmatImeromBtn.TabIndex = 38
        Me.FreeDwmatImeromBtn.UseVisualStyleBackColor = True
        '
        'KlinesBindingSource
        '
        Me.KlinesBindingSource.DataMember = "klines"
        Me.KlinesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KlinesTableAdapter
        '
        Me.KlinesTableAdapter.ClearBeforeFill = True
        '
        'TipoiBindingSource
        '
        Me.TipoiBindingSource.DataMember = "tipoi"
        Me.TipoiBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TipoiTableAdapter
        '
        Me.TipoiTableAdapter.ClearBeforeFill = True
        '
        'DwmatiaBindingSource
        '
        Me.DwmatiaBindingSource.DataMember = "dwmatia"
        Me.DwmatiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DwmatiaTableAdapter
        '
        Me.DwmatiaTableAdapter.ClearBeforeFill = True
        '
        'KatigoriesBindingSource
        '
        Me.KatigoriesBindingSource.DataMember = "katigories"
        Me.KatigoriesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KatigoriesTableAdapter
        '
        Me.KatigoriesTableAdapter.ClearBeforeFill = True
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
        'EpomDwmBtn
        '
        Me.EpomDwmBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EpomDwmBtn.ForeColor = System.Drawing.Color.Maroon
        Me.EpomDwmBtn.Image = Global.winhotel.My.Resources.Resources._NEXT
        Me.EpomDwmBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EpomDwmBtn.Location = New System.Drawing.Point(197, 333)
        Me.EpomDwmBtn.Name = "EpomDwmBtn"
        Me.EpomDwmBtn.Size = New System.Drawing.Size(130, 23)
        Me.EpomDwmBtn.TabIndex = 40
        Me.EpomDwmBtn.Text = "επόμενα "
        Me.EpomDwmBtn.UseVisualStyleBackColor = True
        '
        'PrDwmBtn
        '
        Me.PrDwmBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PrDwmBtn.ForeColor = System.Drawing.Color.Maroon
        Me.PrDwmBtn.Image = Global.winhotel.My.Resources.Resources.LAST
        Me.PrDwmBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PrDwmBtn.Location = New System.Drawing.Point(24, 333)
        Me.PrDwmBtn.Name = "PrDwmBtn"
        Me.PrDwmBtn.Size = New System.Drawing.Size(131, 23)
        Me.PrDwmBtn.TabIndex = 39
        Me.PrDwmBtn.Text = "προηγούμενα"
        Me.PrDwmBtn.UseVisualStyleBackColor = True
        '
        'FreeDwmatImerom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 381)
        Me.Controls.Add(Me.EpomDwmBtn)
        Me.Controls.Add(Me.PrDwmBtn)
        Me.Controls.Add(Me.FreeDwmatImeromBtn)
        Me.Controls.Add(Me.FreeDwmatImeromPck)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FreeDwmatImeromDtGrd)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FreeDwmatImerom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ελεύθερα Δωμάτια ανά Ημέρα Διαμονής"
        CType(Me.FreeDwmatImeromDtGrd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FreedwmatiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KlinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TipoiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KatigoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FreeDwmatImeromDtGrd As System.Windows.Forms.DataGridView
    Friend WithEvents FreedwmatiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents KlinesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TiposDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArithmosDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FreeDwmatImeromPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents FreeDwmatImeromBtn As System.Windows.Forms.Button
    Friend WithEvents KlinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KlinesTableAdapter As winhotel.dbhotelDataSetTableAdapters.klinesTableAdapter
    Friend WithEvents TipoiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TipoiTableAdapter As winhotel.dbhotelDataSetTableAdapters.tipoiTableAdapter
    Friend WithEvents DwmatiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DwmatiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.dwmatiaTableAdapter
    Friend WithEvents KatigoriesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KatigoriesTableAdapter As winhotel.dbhotelDataSetTableAdapters.katigoriesTableAdapter
    Friend WithEvents StatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StatusTableAdapter As winhotel.dbhotelDataSetTableAdapters.statusTableAdapter
    Friend WithEvents EpomDwmBtn As System.Windows.Forms.Button
    Friend WithEvents PrDwmBtn As System.Windows.Forms.Button
End Class
