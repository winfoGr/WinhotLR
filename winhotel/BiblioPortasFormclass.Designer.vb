<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BiblioPortasFormclass
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
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
        Me.BiblioportasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BiblioportasTableAdapter = New winhotel.dbhotelDataSetTableAdapters.biblioportasTableAdapter
        Me.KatastasiapyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KatastasiapyTableAdapter = New winhotel.dbhotelDataSetTableAdapters.katastasiapyTableAdapter
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.KratiseisenilikesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisenilikesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisenilikesTableAdapter
        Me.PraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
        Me.XrewseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrewseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseisTableAdapter
        Me.EthnikotitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EthnikotitesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.ethnikotitesTableAdapter
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BiblioportasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KatastasiapyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisenilikesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrewseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EthnikotitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'BiblioportasBindingSource
        '
        Me.BiblioportasBindingSource.DataMember = "biblioportas"
        Me.BiblioportasBindingSource.DataSource = Me.DbhotelDataSet
        '
        'BiblioportasTableAdapter
        '
        Me.BiblioportasTableAdapter.ClearBeforeFill = True
        '
        'KatastasiapyBindingSource
        '
        Me.KatastasiapyBindingSource.DataMember = "katastasiapy"
        Me.KatastasiapyBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KatastasiapyTableAdapter
        '
        Me.KatastasiapyTableAdapter.ClearBeforeFill = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(278, 88)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(10, 139)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'KratiseisenilikesBindingSource
        '
        Me.KratiseisenilikesBindingSource.DataMember = "kratiseisenilikes"
        Me.KratiseisenilikesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KratiseisenilikesTableAdapter
        '
        Me.KratiseisenilikesTableAdapter.ClearBeforeFill = True
        '
        'PraktoreiaBindingSource
        '
        Me.PraktoreiaBindingSource.DataMember = "praktoreia"
        Me.PraktoreiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'PraktoreiaTableAdapter
        '
        Me.PraktoreiaTableAdapter.ClearBeforeFill = True
        '
        'XrewseisBindingSource
        '
        Me.XrewseisBindingSource.DataMember = "xrewseis"
        Me.XrewseisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'XrewseisTableAdapter
        '
        Me.XrewseisTableAdapter.ClearBeforeFill = True
        '
        'EthnikotitesBindingSource
        '
        Me.EthnikotitesBindingSource.DataMember = "ethnikotites"
        Me.EthnikotitesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EthnikotitesTableAdapter
        '
        Me.EthnikotitesTableAdapter.ClearBeforeFill = True
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
        'BiblioPortasFormclass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 266)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "BiblioPortasFormclass"
        Me.Text = "BiblioPortasFormclass"
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BiblioportasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KatastasiapyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisenilikesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrewseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EthnikotitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
    Friend WithEvents BiblioportasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BiblioportasTableAdapter As winhotel.dbhotelDataSetTableAdapters.biblioportasTableAdapter
    Friend WithEvents KatastasiapyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KatastasiapyTableAdapter As winhotel.dbhotelDataSetTableAdapters.katastasiapyTableAdapter
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents KratiseisenilikesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisenilikesTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisenilikesTableAdapter
    Friend WithEvents PraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
    Friend WithEvents XrewseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XrewseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.xrewseisTableAdapter
    Friend WithEvents EthnikotitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EthnikotitesTableAdapter As winhotel.dbhotelDataSetTableAdapters.ethnikotitesTableAdapter
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
End Class
