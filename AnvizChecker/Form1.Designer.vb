<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirArchivoDeFichajesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ComprobarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.openXLS = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsText = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsPB = New System.Windows.Forms.ToolStripProgressBar()
        Me.txtReport = New System.Windows.Forms.TextBox()
        Me.lstEmpleados = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.mnuMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Padding = New System.Windows.Forms.Padding(3, 1, 0, 1)
        Me.mnuMain.Size = New System.Drawing.Size(1046, 24)
        Me.mnuMain.TabIndex = 0
        Me.mnuMain.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarUsuariosToolStripMenuItem, Me.AbrirArchivoDeFichajesToolStripMenuItem, Me.ToolStripMenuItem2, Me.ComprobarToolStripMenuItem, Me.ToolStripMenuItem3, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 22)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'ImportarUsuariosToolStripMenuItem
        '
        Me.ImportarUsuariosToolStripMenuItem.Name = "ImportarUsuariosToolStripMenuItem"
        Me.ImportarUsuariosToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ImportarUsuariosToolStripMenuItem.Text = "Importar usuarios..."
        '
        'AbrirArchivoDeFichajesToolStripMenuItem
        '
        Me.AbrirArchivoDeFichajesToolStripMenuItem.Enabled = False
        Me.AbrirArchivoDeFichajesToolStripMenuItem.Name = "AbrirArchivoDeFichajesToolStripMenuItem"
        Me.AbrirArchivoDeFichajesToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.AbrirArchivoDeFichajesToolStripMenuItem.Text = "A&brir archivo de fichajes..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(207, 6)
        '
        'ComprobarToolStripMenuItem
        '
        Me.ComprobarToolStripMenuItem.Name = "ComprobarToolStripMenuItem"
        Me.ComprobarToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ComprobarToolStripMenuItem.Text = "&Comprobar"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(207, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcercadeToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripMenuItem1.Text = "A&yuda"
        '
        'AcercadeToolStripMenuItem
        '
        Me.AcercadeToolStripMenuItem.Name = "AcercadeToolStripMenuItem"
        Me.AcercadeToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.AcercadeToolStripMenuItem.Text = "Acerca &de..."
        '
        'openXLS
        '
        Me.openXLS.Title = "Seleccione el archivo XLS con la lista de usuarios"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsText, Me.tsPB})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 415)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 8, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1046, 23)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsText
        '
        Me.tsText.ForeColor = System.Drawing.Color.Black
        Me.tsText.Name = "tsText"
        Me.tsText.Size = New System.Drawing.Size(766, 18)
        Me.tsText.Spring = True
        Me.tsText.Text = "Listo."
        Me.tsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsPB
        '
        Me.tsPB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsPB.Name = "tsPB"
        Me.tsPB.Size = New System.Drawing.Size(269, 17)
        '
        'txtReport
        '
        Me.txtReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReport.Location = New System.Drawing.Point(371, 54)
        Me.txtReport.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.txtReport.Multiline = True
        Me.txtReport.Name = "txtReport"
        Me.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReport.Size = New System.Drawing.Size(661, 348)
        Me.txtReport.TabIndex = 3
        '
        'lstEmpleados
        '
        Me.lstEmpleados.FormattingEnabled = True
        Me.lstEmpleados.ItemHeight = 15
        Me.lstEmpleados.Location = New System.Drawing.Point(19, 54)
        Me.lstEmpleados.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.lstEmpleados.Name = "lstEmpleados"
        Me.lstEmpleados.Size = New System.Drawing.Size(350, 349)
        Me.lstEmpleados.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Lista de empleados:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(371, 38)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Reporte de fichajes:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(491, 105)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(380, 247)
        Me.TextBox1.TabIndex = 9
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 438)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstEmpleados)
        Me.Controls.Add(Me.txtReport)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnuMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.mnuMain
        Me.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Depurador de Informes Anviz"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnuMain As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AbrirArchivoDeFichajesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ComprobarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercadeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportarUsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents openXLS As OpenFileDialog
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsPB As ToolStripProgressBar
    Friend WithEvents tsText As ToolStripStatusLabel
    Friend WithEvents txtReport As TextBox
    Friend WithEvents lstEmpleados As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
End Class
