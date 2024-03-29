<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApyFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApyFrm))
        Me.ApyBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ApyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ApyDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApyTableAdapter = New winhotel.dbhotelDataSetTableAdapters.apyTableAdapter
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
        CType(Me.ApyBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ApyBindingNavigator.SuspendLayout()
        CType(Me.ApyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApyDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ApyBindingNavigator
        '
        Me.ApyBindingNavigator.AddNewItem = Nothing
        Me.ApyBindingNavigator.BindingSource = Me.ApyBindingSource
        Me.ApyBindingNavigator.CountItem = Nothing
        Me.ApyBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ApyBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.BindingNavigatorDeleteItem})
        Me.ApyBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ApyBindingNavigator.MoveFirstItem = Nothing
        Me.ApyBindingNavigator.MoveLastItem = Nothing
        Me.ApyBindingNavigator.MoveNextItem = Nothing
        Me.ApyBindingNavigator.MovePreviousItem = Nothing
        Me.ApyBindingNavigator.Name = "ApyBindingNavigator"
        Me.ApyBindingNavigator.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ApyBindingNavigator.PositionItem = Nothing
        Me.ApyBindingNavigator.Size = New System.Drawing.Size(797, 25)
        Me.ApyBindingNavigator.TabIndex = 0
        Me.ApyBindingNavigator.Text = "BindingNavigator1"
        '
        'ApyBindingSource
        '
        Me.ApyBindingSource.DataMember = "apy"
        Me.ApyBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(82, 22)
        Me.BindingNavigatorDeleteItem.Text = "Διαγραφή"
        Me.BindingNavigatorDeleteItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.AutoSize = False
        Me.SaveToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(103, 22)
        Me.SaveToolStripButton.Text = "Αποθήκευση"
        Me.SaveToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ApyDataGridView
        '
        Me.ApyDataGridView.AutoGenerateColumns = False
        Me.ApyDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.ApyDataGridView.DataSource = Me.ApyBindingSource
        Me.ApyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ApyDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.ApyDataGridView.Name = "ApyDataGridView"
        Me.ApyDataGridView.Size = New System.Drawing.Size(797, 256)
        Me.ApyDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "kwd"
        Me.DataGridViewTextBoxColumn1.HeaderText = "kwd"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 12
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "kratisi"
        Me.DataGridViewTextBoxColumn2.HeaderText = "kratisi"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "eponimia"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Επωνυμία"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 49
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "epaggelma"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Επάγγελμα"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 40
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 130
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "dieuthinsi"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Διεύθυνση"
        Me.DataGridViewTextBoxColumn5.MaxInputLength = 49
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 200
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "afm"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Α.Φ.Μ"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 9
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "doy"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Δ.Ο.Υ."
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'ApyTableAdapter
        '
        Me.ApyTableAdapter.ClearBeforeFill = True
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
        'ApyFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 281)
        Me.Controls.Add(Me.ApyDataGridView)
        Me.Controls.Add(Me.ApyBindingNavigator)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Name = "ApyFrm"
        Me.Text = "Στοιχεία Α.Π.Υ."
        CType(Me.ApyBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ApyBindingNavigator.ResumeLayout(False)
        Me.ApyBindingNavigator.PerformLayout()
        CType(Me.ApyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApyDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents ApyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ApyTableAdapter As winhotel.dbhotelDataSetTableAdapters.apyTableAdapter
    Friend WithEvents ApyBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ApyDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
End Class
