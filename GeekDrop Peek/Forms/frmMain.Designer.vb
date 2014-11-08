<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.llGD = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnInstall_Uninstall = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.lblState2 = New System.Windows.Forms.Label()
        Me.lblState = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblCallviaMethod = New System.Windows.Forms.Label()
        Me.lblCallvia = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 199)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(432, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 3
        '
        'tsLabel
        '
        Me.tsLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tsLabel.ForeColor = System.Drawing.Color.White
        Me.tsLabel.Name = "tsLabel"
        Me.tsLabel.Size = New System.Drawing.Size(44, 17)
        Me.tsLabel.Text = "Version"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Light", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.DarkGray
        Me.lblTitle.Location = New System.Drawing.Point(50, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(150, 30)
        Me.lblTitle.TabIndex = 11
        Me.lblTitle.Text = "GeekDrop Peek"
        '
        'llGD
        '
        Me.llGD.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.llGD.AutoSize = True
        Me.llGD.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llGD.LinkColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.llGD.Location = New System.Drawing.Point(252, 164)
        Me.llGD.Name = "llGD"
        Me.llGD.Size = New System.Drawing.Size(170, 13)
        Me.llGD.TabIndex = 15
        Me.llGD.TabStop = True
        Me.llGD.Text = "GeekDrop.com / J. Scott Elblein"
        Me.llGD.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnInstall_Uninstall)
        Me.Panel1.Controls.Add(Me.btnAbout)
        Me.Panel1.Location = New System.Drawing.Point(12, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(407, 91)
        Me.Panel1.TabIndex = 18
        '
        'btnInstall_Uninstall
        '
        Me.btnInstall_Uninstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnInstall_Uninstall.FlatAppearance.BorderSize = 2
        Me.btnInstall_Uninstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnInstall_Uninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInstall_Uninstall.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInstall_Uninstall.ForeColor = System.Drawing.Color.White
        Me.btnInstall_Uninstall.Image = Global.GeekDrop_Peek.My.Resources.Resources.arrow
        Me.btnInstall_Uninstall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInstall_Uninstall.Location = New System.Drawing.Point(20, 27)
        Me.btnInstall_Uninstall.Name = "btnInstall_Uninstall"
        Me.btnInstall_Uninstall.Size = New System.Drawing.Size(226, 39)
        Me.btnInstall_Uninstall.TabIndex = 17
        Me.btnInstall_Uninstall.Text = "INSTALL GEEKDROP PEEK"
        Me.btnInstall_Uninstall.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnAbout.FlatAppearance.BorderSize = 2
        Me.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbout.ForeColor = System.Drawing.Color.White
        Me.btnAbout.Image = Global.GeekDrop_Peek.My.Resources.Resources.about
        Me.btnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAbout.Location = New System.Drawing.Point(252, 27)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(134, 39)
        Me.btnAbout.TabIndex = 16
        Me.btnAbout.Text = "ABOUT"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'lblState2
        '
        Me.lblState2.AutoSize = True
        Me.lblState2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblState2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblState2.Location = New System.Drawing.Point(106, 156)
        Me.lblState2.Name = "lblState2"
        Me.lblState2.Size = New System.Drawing.Size(71, 13)
        Me.lblState2.TabIndex = 21
        Me.lblState2.Text = "Not Installed"
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblState.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblState.Location = New System.Drawing.Point(12, 156)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(98, 13)
        Me.lblState.TabIndex = 20
        Me.lblState.Text = "Engine is currently"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Image = Global.GeekDrop_Peek.My.Resources.Resources.close
        Me.btnExit.Location = New System.Drawing.Point(400, 0)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(32, 23)
        Me.btnExit.TabIndex = 19
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'picLogo
        '
        Me.picLogo.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.picLogo.Image = Global.GeekDrop_Peek.My.Resources.Resources.GeekDrop
        Me.picLogo.Location = New System.Drawing.Point(12, 9)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(32, 32)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picLogo.TabIndex = 14
        Me.picLogo.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.Image = Global.GeekDrop_Peek.My.Resources.Resources.GeekDrop_Peek
        Me.PictureBox1.Location = New System.Drawing.Point(362, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'lblCallviaMethod
        '
        Me.lblCallviaMethod.AutoSize = True
        Me.lblCallviaMethod.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCallviaMethod.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblCallviaMethod.Location = New System.Drawing.Point(54, 176)
        Me.lblCallviaMethod.Name = "lblCallviaMethod"
        Me.lblCallviaMethod.Size = New System.Drawing.Size(133, 13)
        Me.lblCallviaMethod.TabIndex = 24
        Me.lblCallviaMethod.Text = "Windows' Shell Extension"
        Me.lblCallviaMethod.Visible = False
        '
        'lblCallvia
        '
        Me.lblCallvia.AutoSize = True
        Me.lblCallvia.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCallvia.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCallvia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblCallvia.Location = New System.Drawing.Point(12, 176)
        Me.lblCallvia.Name = "lblCallvia"
        Me.lblCallvia.Size = New System.Drawing.Size(44, 13)
        Me.lblCallvia.TabIndex = 23
        Me.lblCallvia.Text = "Call via"
        Me.lblCallvia.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(432, 221)
        Me.Controls.Add(Me.lblCallviaMethod)
        Me.Controls.Add(Me.lblCallvia)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblState2)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.llGD)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Opacity = 0.0R
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeekDrop Peek"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents llGD As System.Windows.Forms.LinkLabel
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents btnInstall_Uninstall As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblState2 As System.Windows.Forms.Label
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCallviaMethod As System.Windows.Forms.Label
    Friend WithEvents lblCallvia As System.Windows.Forms.Label

End Class
