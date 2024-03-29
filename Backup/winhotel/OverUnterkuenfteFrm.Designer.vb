<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OverUnterkuenfteFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OverUnterkuenfteFrm))
        Me.OverunterkuenfteBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.OverunterkuenfteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.OverunterkuenfteDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OverunterkuenfteTableAdapter = New winhotel.dbhotelDataSetTableAdapters.overunterkuenfteTableAdapter
        CType(Me.OverunterkuenfteBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OverunterkuenfteBindingNavigator.SuspendLayout()
        CType(Me.OverunterkuenfteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OverunterkuenfteDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OverunterkuenfteBindingNavigator
        '
        Me.OverunterkuenfteBindingNavigator.AddNewItem = Nothing
        Me.OverunterkuenfteBindingNavigator.BindingSource = Me.OverunterkuenfteBindingSource
        Me.OverunterkuenfteBindingNavigator.CountItem = Nothing
        Me.OverunterkuenfteBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.OverunterkuenfteBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.BindingNavigatorDeleteItem})
        Me.OverunterkuenfteBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.OverunterkuenfteBindingNavigator.MoveFirstItem = Nothing
        Me.OverunterkuenfteBindingNavigator.MoveLastItem = Nothing
        Me.OverunterkuenfteBindingNavigator.MoveNextItem = Nothing
        Me.OverunterkuenfteBindingNavigator.MovePreviousItem = Nothing
        Me.OverunterkuenfteBindingNavigator.Name = "OverunterkuenfteBindingNavigator"
        Me.OverunterkuenfteBindingNavigator.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.OverunterkuenfteBindingNavigator.PositionItem = Nothing
        Me.OverunterkuenfteBindingNavigator.Size = New System.Drawing.Size(764, 25)
        Me.OverunterkuenfteBindingNavigator.TabIndex = 0
        Me.OverunterkuenfteBindingNavigator.Text = "BindingNavigator1"
        '
        'OverunterkuenfteBindingSource
        '
        Me.OverunterkuenfteBindingSource.DataMember = "overunterkuenfte"
        Me.OverunterkuenfteBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.AutoSize = False
        Me.BindingNavigatorDeleteItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(120, 22)
        Me.BindingNavigatorDeleteItem.Text = "Διαγραφή"
        Me.BindingNavigatorDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BindingNavigatorDeleteItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.AutoSize = False
        Me.SaveToolStripButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(120, 22)
        Me.SaveToolStripButton.Text = "Αποθήκευση"
        Me.SaveToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'OverunterkuenfteDataGridView
        '
        Me.OverunterkuenfteDataGridView.AutoGenerateColumns = False
        Me.OverunterkuenfteDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn7})
        Me.OverunterkuenfteDataGridView.DataSource = Me.OverunterkuenfteBindingSource
        Me.OverunterkuenfteDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OverunterkuenfteDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.OverunterkuenfteDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.OverunterkuenfteDataGridView.Name = "OverunterkuenfteDataGridView"
        Me.OverunterkuenfteDataGridView.Size = New System.Drawing.Size(764, 320)
        Me.OverunterkuenfteDataGridView.TabIndex = 1
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "over"
        Me.DataGridViewTextBoxColumn2.HeaderText = "over"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "xenodoxeio"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Ξενοδοχείο"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 40
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "apo"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Απο"
        Me.DataGridViewTextBoxColumn5.MaxInputLength = 10
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "mexri"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Μεχρι"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 10
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "dwmatio"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Αρ.Δωμ."
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 15
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "simioseis"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Σημειώσεις"
        Me.DataGridViewTextBoxColumn7.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 250
        '
        'OverunterkuenfteTableAdapter
        '
        Me.OverunterkuenfteTableAdapter.ClearBeforeFill = True
        '
        'OverUnterkuenfteFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 345)
        Me.Controls.Add(Me.OverunterkuenfteDataGridView)
        Me.Controls.Add(Me.OverunterkuenfteBindingNavigator)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "OverUnterkuenfteFrm"
        Me.Text = "Over: Διαμονές εκτός Ξενοδοχείου "
        CType(Me.OverunterkuenfteBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OverunterkuenfteBindingNavigator.ResumeLayout(False)
        Me.OverunterkuenfteBindingNavigator.PerformLayout()
        CType(Me.OverunterkuenfteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OverunterkuenfteDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents OverunterkuenfteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OverunterkuenfteTableAdapter As winhotel.dbhotelDataSetTableAdapters.overunterkuenfteTableAdapter
    Friend WithEvents OverunterkuenfteBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents OverunterkuenfteDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
