<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFrm))
        Me.WinHotLbl = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.EnergiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ErgasiesHmerasStrip = New System.Windows.Forms.ToolStripMenuItem
        Me.DiamenwntesStrip = New System.Windows.Forms.ToolStripMenuItem
        Me.KleisimoStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PraktoreiaStrip = New System.Windows.Forms.ToolStripMenuItem
        Me.TelosMinaStrip = New System.Windows.Forms.ToolStripMenuItem
        Me.TelosEtousStrip = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ΑναζήτησηToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OldCustomersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnconfirmedBookingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PaymrntNotCompletedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SimofiniesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SimfoniesStrip = New System.Windows.Forms.ToolStripMenuItem
        Me.ProblepseisToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ProblpsiKinisiItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ΕισπράξειςToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TheorisiMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.BiblPortasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParametroiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParametroiStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SecureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.KatharismataMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.KathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewsletterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
        Me.LizensBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LizensTableAdapter = New winhotel.dbhotelDataSetTableAdapters.lizensTableAdapter
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LizensBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WinHotLbl
        '
        Me.WinHotLbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WinHotLbl.AutoSize = True
        Me.WinHotLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.WinHotLbl.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.WinHotLbl.Location = New System.Drawing.Point(218, 105)
        Me.WinHotLbl.Name = "WinHotLbl"
        Me.WinHotLbl.Size = New System.Drawing.Size(343, 108)
        Me.WinHotLbl.TabIndex = 0
        Me.WinHotLbl.Text = "winHot"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LightGray
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnergiesToolStripMenuItem, Me.ΑναζήτησηToolStripMenuItem, Me.SimofiniesToolStripMenuItem, Me.ProblepseisToolStripMenuItem1, Me.TheorisiMenuItem1, Me.ParametroiToolStripMenuItem, Me.SecureToolStripMenuItem, Me.KatharismataMenuItem, Me.NewsletterToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(849, 24)
        Me.MenuStrip1.TabIndex = 182
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EnergiesToolStripMenuItem
        '
        Me.EnergiesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ErgasiesHmerasStrip, Me.DiamenwntesStrip, Me.KleisimoStripMenuItem, Me.PraktoreiaStrip, Me.TelosMinaStrip, Me.TelosEtousStrip, Me.ExitStripMenuItem})
        Me.EnergiesToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EnergiesToolStripMenuItem.Name = "EnergiesToolStripMenuItem"
        Me.EnergiesToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.EnergiesToolStripMenuItem.Text = " Εργασίες"
        '
        'ErgasiesHmerasStrip
        '
        Me.ErgasiesHmerasStrip.Name = "ErgasiesHmerasStrip"
        Me.ErgasiesHmerasStrip.Size = New System.Drawing.Size(315, 22)
        Me.ErgasiesHmerasStrip.Text = "Εργασίες Ημέρας"
        '
        'DiamenwntesStrip
        '
        Me.DiamenwntesStrip.Name = "DiamenwntesStrip"
        Me.DiamenwntesStrip.Size = New System.Drawing.Size(315, 22)
        Me.DiamenwntesStrip.Text = "Συμπλήρωση στοιχείων Διαμενόντων"
        '
        'KleisimoStripMenuItem
        '
        Me.KleisimoStripMenuItem.Name = "KleisimoStripMenuItem"
        Me.KleisimoStripMenuItem.Size = New System.Drawing.Size(315, 22)
        Me.KleisimoStripMenuItem.Text = "Κλείσιμο Ημέρας"
        '
        'PraktoreiaStrip
        '
        Me.PraktoreiaStrip.Name = "PraktoreiaStrip"
        Me.PraktoreiaStrip.Size = New System.Drawing.Size(315, 22)
        Me.PraktoreiaStrip.Text = "Κίνηση Λογαριασμών Πρακτορείων"
        '
        'TelosMinaStrip
        '
        Me.TelosMinaStrip.Name = "TelosMinaStrip"
        Me.TelosMinaStrip.Size = New System.Drawing.Size(315, 22)
        Me.TelosMinaStrip.Text = "Εργασίες τέλος Μήνα"
        '
        'TelosEtousStrip
        '
        Me.TelosEtousStrip.Name = "TelosEtousStrip"
        Me.TelosEtousStrip.Size = New System.Drawing.Size(315, 22)
        Me.TelosEtousStrip.Text = "Εργασίες αρχής - τέλους Season"
        '
        'ExitStripMenuItem
        '
        Me.ExitStripMenuItem.Name = "ExitStripMenuItem"
        Me.ExitStripMenuItem.Size = New System.Drawing.Size(315, 22)
        Me.ExitStripMenuItem.Text = "Εξοδος"
        '
        'ΑναζήτησηToolStripMenuItem
        '
        Me.ΑναζήτησηToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OldCustomersToolStripMenuItem, Me.UnconfirmedBookingsToolStripMenuItem, Me.PaymrntNotCompletedToolStripMenuItem})
        Me.ΑναζήτησηToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ΑναζήτησηToolStripMenuItem.Name = "ΑναζήτησηToolStripMenuItem"
        Me.ΑναζήτησηToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.ΑναζήτησηToolStripMenuItem.Text = "Αναζήτηση"
        '
        'OldCustomersToolStripMenuItem
        '
        Me.OldCustomersToolStripMenuItem.Name = "OldCustomersToolStripMenuItem"
        Me.OldCustomersToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.OldCustomersToolStripMenuItem.Text = "former Customers"
        '
        'UnconfirmedBookingsToolStripMenuItem
        '
        Me.UnconfirmedBookingsToolStripMenuItem.Name = "UnconfirmedBookingsToolStripMenuItem"
        Me.UnconfirmedBookingsToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.UnconfirmedBookingsToolStripMenuItem.Text = "not confirmed bookings"
        '
        'PaymrntNotCompletedToolStripMenuItem
        '
        Me.PaymrntNotCompletedToolStripMenuItem.Name = "PaymrntNotCompletedToolStripMenuItem"
        Me.PaymrntNotCompletedToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.PaymrntNotCompletedToolStripMenuItem.Text = "payments not completed"
        '
        'SimofiniesToolStripMenuItem
        '
        Me.SimofiniesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SimfoniesStrip})
        Me.SimofiniesToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SimofiniesToolStripMenuItem.Name = "SimofiniesToolStripMenuItem"
        Me.SimofiniesToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.SimofiniesToolStripMenuItem.Text = "Συμφωνίες"
        '
        'SimfoniesStrip
        '
        Me.SimfoniesStrip.Name = "SimfoniesStrip"
        Me.SimfoniesStrip.Size = New System.Drawing.Size(363, 22)
        Me.SimfoniesStrip.Text = "Συμφωνίες - Booking Pοsitions Πρακτορείων"
        '
        'ProblepseisToolStripMenuItem1
        '
        Me.ProblepseisToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProblpsiKinisiItem, Me.ΕισπράξειςToolStripMenuItem})
        Me.ProblepseisToolStripMenuItem1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ProblepseisToolStripMenuItem1.Name = "ProblepseisToolStripMenuItem1"
        Me.ProblepseisToolStripMenuItem1.Size = New System.Drawing.Size(91, 20)
        Me.ProblepseisToolStripMenuItem1.Text = "Προβλέψεις"
        '
        'ProblpsiKinisiItem
        '
        Me.ProblpsiKinisiItem.Name = "ProblpsiKinisiItem"
        Me.ProblpsiKinisiItem.Size = New System.Drawing.Size(137, 22)
        Me.ProblpsiKinisiItem.Text = "Κίνηση"
        '
        'ΕισπράξειςToolStripMenuItem
        '
        Me.ΕισπράξειςToolStripMenuItem.Name = "ΕισπράξειςToolStripMenuItem"
        Me.ΕισπράξειςToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ΕισπράξειςToolStripMenuItem.Text = "Εισπράξεις"
        '
        'TheorisiMenuItem1
        '
        Me.TheorisiMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BiblPortasToolStripMenuItem})
        Me.TheorisiMenuItem1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TheorisiMenuItem1.Name = "TheorisiMenuItem1"
        Me.TheorisiMenuItem1.Size = New System.Drawing.Size(77, 20)
        Me.TheorisiMenuItem1.Text = "Θεώρηση"
        '
        'BiblPortasToolStripMenuItem
        '
        Me.BiblPortasToolStripMenuItem.Name = "BiblPortasToolStripMenuItem"
        Me.BiblPortasToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.BiblPortasToolStripMenuItem.Text = "Βιβλίο Πόρτας"
        '
        'ParametroiToolStripMenuItem
        '
        Me.ParametroiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParametroiStripMenuItem})
        Me.ParametroiToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ParametroiToolStripMenuItem.Name = "ParametroiToolStripMenuItem"
        Me.ParametroiToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.ParametroiToolStripMenuItem.Text = "Παράμετροι"
        '
        'ParametroiStripMenuItem
        '
        Me.ParametroiStripMenuItem.Name = "ParametroiStripMenuItem"
        Me.ParametroiStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ParametroiStripMenuItem.Text = "Συντήρηση Παραμέτρων Εφαρμογής"
        '
        'SecureToolStripMenuItem
        '
        Me.SecureToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupToolStripMenuItem, Me.RestoreToolStripMenuItem})
        Me.SecureToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SecureToolStripMenuItem.Name = "SecureToolStripMenuItem"
        Me.SecureToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.SecureToolStripMenuItem.Text = "Ασφάλεια"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.RestoreToolStripMenuItem.Text = "Restore"
        '
        'KatharismataMenuItem
        '
        Me.KatharismataMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KathToolStripMenuItem})
        Me.KatharismataMenuItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KatharismataMenuItem.Name = "KatharismataMenuItem"
        Me.KatharismataMenuItem.Size = New System.Drawing.Size(101, 20)
        Me.KatharismataMenuItem.Text = "Καθαρίσματα"
        '
        'KathToolStripMenuItem
        '
        Me.KathToolStripMenuItem.Name = "KathToolStripMenuItem"
        Me.KathToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.KathToolStripMenuItem.Text = "Υπολογισμός"
        '
        'NewsletterToolStripMenuItem
        '
        Me.NewsletterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendToolStripMenuItem})
        Me.NewsletterToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.NewsletterToolStripMenuItem.Name = "NewsletterToolStripMenuItem"
        Me.NewsletterToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.NewsletterToolStripMenuItem.Text = "Newsletter"
        '
        'SendToolStripMenuItem
        '
        Me.SendToolStripMenuItem.Name = "SendToolStripMenuItem"
        Me.SendToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.SendToolStripMenuItem.Text = "Send"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(314, 205)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(166, 94)
        Me.PictureBox1.TabIndex = 184
        Me.PictureBox1.TabStop = False
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
        'LizensBindingSource
        '
        Me.LizensBindingSource.DataMember = "lizens"
        Me.LizensBindingSource.DataSource = Me.DbhotelDataSet
        '
        'LizensTableAdapter
        '
        Me.LizensTableAdapter.ClearBeforeFill = True
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
        'MainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(849, 353)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.WinHotLbl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "winHot (DOMISI-Distribution)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LizensBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WinHotLbl As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents EnergiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErgasiesHmerasStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiamenwntesStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KleisimoStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PraktoreiaStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SimofiniesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SimfoniesStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParametroiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParametroiStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SecureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProblepseisToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TelosMinaStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TelosEtousStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProblpsiKinisiItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents TheorisiMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BiblPortasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LizensBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LizensTableAdapter As winhotel.dbhotelDataSetTableAdapters.lizensTableAdapter
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
    Friend WithEvents ExitStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΑναζήτησηToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OldCustomersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents UnconfirmedBookingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KatharismataMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΕισπράξειςToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewsletterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymrntNotCompletedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
