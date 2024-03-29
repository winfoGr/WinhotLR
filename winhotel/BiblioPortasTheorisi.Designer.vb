<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BiblioPortasTheorisi
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
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.PortaPnl = New System.Windows.Forms.Panel
        Me.EktiposBtn = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.PlithosTbx = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.AATbx = New System.Windows.Forms.TextBox
        Me.TheorRdb = New System.Windows.Forms.RadioButton
        Me.AploRdb = New System.Windows.Forms.RadioButton
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PortaPnl.SuspendLayout()
        Me.SuspendLayout()
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
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(267, -2)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(10, 150)
        Me.CrystalReportViewer1.TabIndex = 52
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'PortaPnl
        '
        Me.PortaPnl.BackColor = System.Drawing.Color.Silver
        Me.PortaPnl.Controls.Add(Me.AploRdb)
        Me.PortaPnl.Controls.Add(Me.TheorRdb)
        Me.PortaPnl.Controls.Add(Me.EktiposBtn)
        Me.PortaPnl.Controls.Add(Me.Label2)
        Me.PortaPnl.Controls.Add(Me.PlithosTbx)
        Me.PortaPnl.Controls.Add(Me.Label1)
        Me.PortaPnl.Controls.Add(Me.AATbx)
        Me.PortaPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PortaPnl.Location = New System.Drawing.Point(0, 0)
        Me.PortaPnl.Name = "PortaPnl"
        Me.PortaPnl.Size = New System.Drawing.Size(279, 145)
        Me.PortaPnl.TabIndex = 53
        '
        'EktiposBtn
        '
        Me.EktiposBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EktiposBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.EktiposBtn.Location = New System.Drawing.Point(109, 102)
        Me.EktiposBtn.Name = "EktiposBtn"
        Me.EktiposBtn.Size = New System.Drawing.Size(36, 31)
        Me.EktiposBtn.TabIndex = 56
        Me.EktiposBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 70)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 16)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Πλήθος σελίδων:"
        '
        'PlithosTbx
        '
        Me.PlithosTbx.ForeColor = System.Drawing.Color.Maroon
        Me.PlithosTbx.Location = New System.Drawing.Point(161, 70)
        Me.PlithosTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.PlithosTbx.MaxLength = 4
        Me.PlithosTbx.Name = "PlithosTbx"
        Me.PlithosTbx.Size = New System.Drawing.Size(67, 22)
        Me.PlithosTbx.TabIndex = 54
        Me.PlithosTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 16)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Α/Α πρώτης σελίδας:"
        '
        'AATbx
        '
        Me.AATbx.ForeColor = System.Drawing.Color.Maroon
        Me.AATbx.Location = New System.Drawing.Point(161, 31)
        Me.AATbx.Margin = New System.Windows.Forms.Padding(4)
        Me.AATbx.MaxLength = 5
        Me.AATbx.Name = "AATbx"
        Me.AATbx.Size = New System.Drawing.Size(67, 22)
        Me.AATbx.TabIndex = 52
        Me.AATbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TheorRdb
        '
        Me.TheorRdb.AutoSize = True
        Me.TheorRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TheorRdb.Checked = True
        Me.TheorRdb.Location = New System.Drawing.Point(45, 3)
        Me.TheorRdb.Name = "TheorRdb"
        Me.TheorRdb.Size = New System.Drawing.Size(88, 20)
        Me.TheorRdb.TabIndex = 57
        Me.TheorRdb.TabStop = True
        Me.TheorRdb.Text = "Θεώρηση"
        Me.TheorRdb.UseVisualStyleBackColor = True
        '
        'AploRdb
        '
        Me.AploRdb.AutoSize = True
        Me.AploRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AploRdb.Location = New System.Drawing.Point(149, 4)
        Me.AploRdb.Name = "AploRdb"
        Me.AploRdb.Size = New System.Drawing.Size(63, 20)
        Me.AploRdb.TabIndex = 58
        Me.AploRdb.Text = "Απλο"
        Me.AploRdb.UseVisualStyleBackColor = True
        '
        'BiblioPortasTheorisi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(279, 145)
        Me.Controls.Add(Me.PortaPnl)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "BiblioPortasTheorisi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Βιβλίο Πόρτας για Θεώρηση"
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PortaPnl.ResumeLayout(False)
        Me.PortaPnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents PortaPnl As System.Windows.Forms.Panel
    Friend WithEvents EktiposBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PlithosTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AATbx As System.Windows.Forms.TextBox
    Friend WithEvents AploRdb As System.Windows.Forms.RadioButton
    Friend WithEvents TheorRdb As System.Windows.Forms.RadioButton
End Class
