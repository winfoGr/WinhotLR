<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaidiaFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaidiaFrm))
        Me.PaidiaBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.PaidiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PaidiaDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaidiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.paidiaTableAdapter
        CType(Me.PaidiaBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaidiaBindingNavigator.SuspendLayout()
        CType(Me.PaidiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaidiaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PaidiaBindingNavigator
        '
        Me.PaidiaBindingNavigator.AddNewItem = Nothing
        Me.PaidiaBindingNavigator.BindingSource = Me.PaidiaBindingSource
        Me.PaidiaBindingNavigator.CountItem = Nothing
        Me.PaidiaBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.PaidiaBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.BindingNavigatorDeleteItem})
        Me.PaidiaBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.PaidiaBindingNavigator.MoveFirstItem = Nothing
        Me.PaidiaBindingNavigator.MoveLastItem = Nothing
        Me.PaidiaBindingNavigator.MoveNextItem = Nothing
        Me.PaidiaBindingNavigator.MovePreviousItem = Nothing
        Me.PaidiaBindingNavigator.Name = "PaidiaBindingNavigator"
        Me.PaidiaBindingNavigator.PositionItem = Nothing
        Me.PaidiaBindingNavigator.Size = New System.Drawing.Size(327, 25)
        Me.PaidiaBindingNavigator.TabIndex = 0
        Me.PaidiaBindingNavigator.Text = "BindingNavigator1"
        '
        'PaidiaBindingSource
        '
        Me.PaidiaBindingSource.DataMember = "paidia"
        Me.PaidiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.AutoSize = False
        Me.BindingNavigatorDeleteItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(110, 22)
        Me.BindingNavigatorDeleteItem.Text = "Διαγραφή"
        Me.BindingNavigatorDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BindingNavigatorDeleteItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.BindingNavigatorDeleteItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.AutoSize = False
        Me.SaveToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(110, 22)
        Me.SaveToolStripButton.Text = "Αποθήκευση"
        Me.SaveToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'PaidiaDataGridView
        '
        Me.PaidiaDataGridView.AutoGenerateColumns = False
        Me.PaidiaDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.cot, Me.DataGridViewTextBoxColumn4})
        Me.PaidiaDataGridView.DataSource = Me.PaidiaBindingSource
        Me.PaidiaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaidiaDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.PaidiaDataGridView.Name = "PaidiaDataGridView"
        Me.PaidiaDataGridView.Size = New System.Drawing.Size(327, 227)
        Me.PaidiaDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "kwd"
        Me.DataGridViewTextBoxColumn1.HeaderText = "kwd"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "kratisi"
        Me.DataGridViewTextBoxColumn2.HeaderText = "kratisi"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'cot
        '
        Me.cot.DataPropertyName = "cot"
        Me.cot.HeaderText = "cot"
        Me.cot.Name = "cot"
        Me.cot.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ilikia"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ηλικία"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 2
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'PaidiaTableAdapter
        '
        Me.PaidiaTableAdapter.ClearBeforeFill = True
        '
        'PaidiaFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 252)
        Me.Controls.Add(Me.PaidiaDataGridView)
        Me.Controls.Add(Me.PaidiaBindingNavigator)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PaidiaFrm"
        Me.Text = "Επιπλέον παιδί"
        CType(Me.PaidiaBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaidiaBindingNavigator.ResumeLayout(False)
        Me.PaidiaBindingNavigator.PerformLayout()
        CType(Me.PaidiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaidiaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents PaidiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaidiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.paidiaTableAdapter
    Friend WithEvents PaidiaBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents PaidiaDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
