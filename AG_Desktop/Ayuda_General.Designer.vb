<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ayuda_General
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.label_conclusion = New System.Windows.Forms.Label()
        Me.label_desarrollo = New System.Windows.Forms.Label()
        Me.pb_img2 = New System.Windows.Forms.PictureBox()
        Me.pb_img1 = New System.Windows.Forms.PictureBox()
        Me.label_cuerpo = New System.Windows.Forms.Label()
        Me.label_pie = New System.Windows.Forms.Label()
        Me.label_titulo = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AtrasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.pb_img2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_img1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(281, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(567, 519)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.label_conclusion)
        Me.TabPage1.Controls.Add(Me.label_desarrollo)
        Me.TabPage1.Controls.Add(Me.pb_img2)
        Me.TabPage1.Controls.Add(Me.pb_img1)
        Me.TabPage1.Controls.Add(Me.label_cuerpo)
        Me.TabPage1.Controls.Add(Me.label_pie)
        Me.TabPage1.Controls.Add(Me.label_titulo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(559, 493)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'label_conclusion
        '
        Me.label_conclusion.AutoSize = True
        Me.label_conclusion.Location = New System.Drawing.Point(70, 431)
        Me.label_conclusion.Name = "label_conclusion"
        Me.label_conclusion.Size = New System.Drawing.Size(39, 13)
        Me.label_conclusion.TabIndex = 6
        Me.label_conclusion.Text = "Label6"
        '
        'label_desarrollo
        '
        Me.label_desarrollo.AutoSize = True
        Me.label_desarrollo.Location = New System.Drawing.Point(70, 381)
        Me.label_desarrollo.Name = "label_desarrollo"
        Me.label_desarrollo.Size = New System.Drawing.Size(39, 13)
        Me.label_desarrollo.TabIndex = 5
        Me.label_desarrollo.Text = "Label6"
        '
        'pb_img2
        '
        Me.pb_img2.Location = New System.Drawing.Point(86, 199)
        Me.pb_img2.Name = "pb_img2"
        Me.pb_img2.Size = New System.Drawing.Size(100, 50)
        Me.pb_img2.TabIndex = 4
        Me.pb_img2.TabStop = False
        '
        'pb_img1
        '
        Me.pb_img1.Image = Global.AG_Desktop.My.Resources.Resources.close
        Me.pb_img1.Location = New System.Drawing.Point(86, 123)
        Me.pb_img1.Name = "pb_img1"
        Me.pb_img1.Size = New System.Drawing.Size(100, 50)
        Me.pb_img1.TabIndex = 3
        Me.pb_img1.TabStop = False
        '
        'label_cuerpo
        '
        Me.label_cuerpo.AutoSize = True
        Me.label_cuerpo.Location = New System.Drawing.Point(70, 350)
        Me.label_cuerpo.Name = "label_cuerpo"
        Me.label_cuerpo.Size = New System.Drawing.Size(39, 13)
        Me.label_cuerpo.TabIndex = 2
        Me.label_cuerpo.Text = "Label6"
        '
        'label_pie
        '
        Me.label_pie.AutoSize = True
        Me.label_pie.Location = New System.Drawing.Point(17, 63)
        Me.label_pie.Name = "label_pie"
        Me.label_pie.Size = New System.Drawing.Size(71, 13)
        Me.label_pie.TabIndex = 1
        Me.label_pie.Text = "pie de página"
        '
        'label_titulo
        '
        Me.label_titulo.AutoSize = True
        Me.label_titulo.Font = New System.Drawing.Font("Palatino Linotype", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_titulo.ForeColor = System.Drawing.Color.RoyalBlue
        Me.label_titulo.Location = New System.Drawing.Point(17, 16)
        Me.label_titulo.Name = "label_titulo"
        Me.label_titulo.Size = New System.Drawing.Size(254, 28)
        Me.label_titulo.TabIndex = 0
        Me.label_titulo.Text = "Establecer Programación"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(559, 493)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(275, 515)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Índice"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(24, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Recursos Reales"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(24, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Programación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(24, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Recursos Teóricos"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtrasToolStripMenuItem, Me.NextToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(848, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AtrasToolStripMenuItem
        '
        Me.AtrasToolStripMenuItem.Name = "AtrasToolStripMenuItem"
        Me.AtrasToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.AtrasToolStripMenuItem.Text = "Atrás"
        '
        'NextToolStripMenuItem
        '
        Me.NextToolStripMenuItem.Name = "NextToolStripMenuItem"
        Me.NextToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.NextToolStripMenuItem.Text = "Adelante"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'Ayuda_General
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AG_Desktop.My.Resources.Resources.white
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(848, 543)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Ayuda_General"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ayuda General 1.1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.pb_img2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_img1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AtrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents label_conclusion As System.Windows.Forms.Label
    Friend WithEvents label_desarrollo As System.Windows.Forms.Label
    Friend WithEvents pb_img2 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_img1 As System.Windows.Forms.PictureBox
    Friend WithEvents label_cuerpo As System.Windows.Forms.Label
    Friend WithEvents label_pie As System.Windows.Forms.Label
    Friend WithEvents label_titulo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
