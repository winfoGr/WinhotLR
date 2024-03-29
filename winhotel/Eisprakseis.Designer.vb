<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Eisprakseis
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.EisprakseisDtGrd = New System.Windows.Forms.DataGridView
        Me.EisprakseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.EisprakseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.eisprakseispraktoreiaTableAdapter
        Me.KwdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Parast2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Parast3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ImerominiaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EispraksiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.EisprakseisDtGrd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EisprakseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EisprakseisDtGrd
        '
        Me.EisprakseisDtGrd.AllowUserToAddRows = False
        Me.EisprakseisDtGrd.AllowUserToDeleteRows = False
        Me.EisprakseisDtGrd.AutoGenerateColumns = False
        Me.EisprakseisDtGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EisprakseisDtGrd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KwdDataGridViewTextBoxColumn, Me.Parast2DataGridViewTextBoxColumn, Me.Parast3DataGridViewTextBoxColumn, Me.ImerominiaDataGridViewTextBoxColumn, Me.EispraksiDataGridViewTextBoxColumn})
        Me.EisprakseisDtGrd.DataSource = Me.EisprakseispraktoreiaBindingSource
        Me.EisprakseisDtGrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EisprakseisDtGrd.Location = New System.Drawing.Point(0, 0)
        Me.EisprakseisDtGrd.Margin = New System.Windows.Forms.Padding(4)
        Me.EisprakseisDtGrd.Name = "EisprakseisDtGrd"
        Me.EisprakseisDtGrd.Size = New System.Drawing.Size(398, 169)
        Me.EisprakseisDtGrd.TabIndex = 0
        '
        'EisprakseispraktoreiaBindingSource
        '
        Me.EisprakseispraktoreiaBindingSource.DataMember = "eisprakseispraktoreia"
        Me.EisprakseispraktoreiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EisprakseispraktoreiaTableAdapter
        '
        Me.EisprakseispraktoreiaTableAdapter.ClearBeforeFill = True
        '
        'KwdDataGridViewTextBoxColumn
        '
        Me.KwdDataGridViewTextBoxColumn.DataPropertyName = "kwd"
        Me.KwdDataGridViewTextBoxColumn.HeaderText = "kwd"
        Me.KwdDataGridViewTextBoxColumn.Name = "KwdDataGridViewTextBoxColumn"
        Me.KwdDataGridViewTextBoxColumn.Visible = False
        '
        'Parast2DataGridViewTextBoxColumn
        '
        Me.Parast2DataGridViewTextBoxColumn.DataPropertyName = "parast2"
        Me.Parast2DataGridViewTextBoxColumn.HeaderText = ""
        Me.Parast2DataGridViewTextBoxColumn.Name = "Parast2DataGridViewTextBoxColumn"
        Me.Parast2DataGridViewTextBoxColumn.ReadOnly = True
        Me.Parast2DataGridViewTextBoxColumn.Width = 20
        '
        'Parast3DataGridViewTextBoxColumn
        '
        Me.Parast3DataGridViewTextBoxColumn.DataPropertyName = "parast3"
        Me.Parast3DataGridViewTextBoxColumn.HeaderText = "Παραστ."
        Me.Parast3DataGridViewTextBoxColumn.Name = "Parast3DataGridViewTextBoxColumn"
        Me.Parast3DataGridViewTextBoxColumn.ReadOnly = True
        '
        'ImerominiaDataGridViewTextBoxColumn
        '
        Me.ImerominiaDataGridViewTextBoxColumn.DataPropertyName = "imerominia"
        Me.ImerominiaDataGridViewTextBoxColumn.HeaderText = "Ημερομηνία"
        Me.ImerominiaDataGridViewTextBoxColumn.Name = "ImerominiaDataGridViewTextBoxColumn"
        Me.ImerominiaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EispraksiDataGridViewTextBoxColumn
        '
        Me.EispraksiDataGridViewTextBoxColumn.DataPropertyName = "eispraksi"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.EispraksiDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.EispraksiDataGridViewTextBoxColumn.HeaderText = "Είσπραξη"
        Me.EispraksiDataGridViewTextBoxColumn.Name = "EispraksiDataGridViewTextBoxColumn"
        Me.EispraksiDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Eisprakseis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 169)
        Me.Controls.Add(Me.EisprakseisDtGrd)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Eisprakseis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Εισπράξεις Πρακτορείου"
        CType(Me.EisprakseisDtGrd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EisprakseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents EisprakseispraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EisprakseispraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.eisprakseispraktoreiaTableAdapter
    Friend WithEvents EisprakseisDtGrd As System.Windows.Forms.DataGridView
    Friend WithEvents KwdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parast2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parast3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImerominiaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EispraksiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
