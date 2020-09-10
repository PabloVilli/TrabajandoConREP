<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtCntRegistros = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbTipoFiltro = New System.Windows.Forms.ComboBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbEgresos = New System.Windows.Forms.RadioButton()
        Me.rbPagos = New System.Windows.Forms.RadioButton()
        Me.rbIngresos = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pgbFacturas = New System.Windows.Forms.ProgressBar()
        Me.pnlMensajes = New System.Windows.Forms.Panel()
        Me.pbAlerta = New System.Windows.Forms.PictureBox()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlMensajes.SuspendLayout()
        CType(Me.pbAlerta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCntRegistros
        '
        Me.txtCntRegistros.BackColor = System.Drawing.SystemColors.Window
        Me.txtCntRegistros.Location = New System.Drawing.Point(871, 40)
        Me.txtCntRegistros.Name = "txtCntRegistros"
        Me.txtCntRegistros.ReadOnly = True
        Me.txtCntRegistros.Size = New System.Drawing.Size(98, 20)
        Me.txtCntRegistros.TabIndex = 71
        Me.txtCntRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(783, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "No. Registros"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbTipoFiltro)
        Me.GroupBox3.Controls.Add(Me.txtFiltro)
        Me.GroupBox3.Location = New System.Drawing.Point(291, 122)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(677, 47)
        Me.GroupBox3.TabIndex = 69
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filtros"
        '
        'cmbTipoFiltro
        '
        Me.cmbTipoFiltro.FormattingEnabled = True
        Me.cmbTipoFiltro.Location = New System.Drawing.Point(6, 15)
        Me.cmbTipoFiltro.Name = "cmbTipoFiltro"
        Me.cmbTipoFiltro.Size = New System.Drawing.Size(126, 21)
        Me.cmbTipoFiltro.TabIndex = 53
        '
        'txtFiltro
        '
        Me.txtFiltro.BackColor = System.Drawing.SystemColors.Window
        Me.txtFiltro.Location = New System.Drawing.Point(138, 16)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(519, 20)
        Me.txtFiltro.TabIndex = 52
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbEgresos)
        Me.GroupBox2.Controls.Add(Me.rbPagos)
        Me.GroupBox2.Controls.Add(Me.rbIngresos)
        Me.GroupBox2.Controls.Add(Me.rbTodos)
        Me.GroupBox2.Location = New System.Drawing.Point(291, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(677, 47)
        Me.GroupBox2.TabIndex = 68
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Documento"
        '
        'rbEgresos
        '
        Me.rbEgresos.AutoSize = True
        Me.rbEgresos.Location = New System.Drawing.Point(403, 19)
        Me.rbEgresos.Name = "rbEgresos"
        Me.rbEgresos.Size = New System.Drawing.Size(63, 17)
        Me.rbEgresos.TabIndex = 59
        Me.rbEgresos.TabStop = True
        Me.rbEgresos.Text = "Egresos"
        Me.rbEgresos.UseVisualStyleBackColor = True
        '
        'rbPagos
        '
        Me.rbPagos.AutoSize = True
        Me.rbPagos.Location = New System.Drawing.Point(591, 19)
        Me.rbPagos.Name = "rbPagos"
        Me.rbPagos.Size = New System.Drawing.Size(55, 17)
        Me.rbPagos.TabIndex = 58
        Me.rbPagos.TabStop = True
        Me.rbPagos.Text = "Pagos"
        Me.rbPagos.UseVisualStyleBackColor = True
        '
        'rbIngresos
        '
        Me.rbIngresos.AutoSize = True
        Me.rbIngresos.Location = New System.Drawing.Point(205, 19)
        Me.rbIngresos.Name = "rbIngresos"
        Me.rbIngresos.Size = New System.Drawing.Size(65, 17)
        Me.rbIngresos.TabIndex = 57
        Me.rbIngresos.TabStop = True
        Me.rbIngresos.Text = "Ingresos"
        Me.rbIngresos.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(17, 19)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbTodos.TabIndex = 56
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.dtpFechaIni)
        Me.GroupBox1.Controls.Add(Me.lblRuta)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 96)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Fecha Final"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(125, 63)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaFin.TabIndex = 59
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(125, 23)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaIni.TabIndex = 58
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(20, 28)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(67, 13)
        Me.lblRuta.TabIndex = 57
        Me.lblRuta.Text = "Fecha Inicial"
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(37, 33)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(35, 34)
        Me.btnActualizar.TabIndex = 65
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.pgbFacturas)
        Me.Panel1.Controls.Add(Me.pnlMensajes)
        Me.Panel1.Location = New System.Drawing.Point(0, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 24)
        Me.Panel1.TabIndex = 64
        '
        'pgbFacturas
        '
        Me.pgbFacturas.Location = New System.Drawing.Point(1, 0)
        Me.pgbFacturas.Name = "pgbFacturas"
        Me.pgbFacturas.Size = New System.Drawing.Size(982, 23)
        Me.pgbFacturas.TabIndex = 41
        Me.pgbFacturas.Visible = False
        '
        'pnlMensajes
        '
        Me.pnlMensajes.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlMensajes.Controls.Add(Me.pbAlerta)
        Me.pnlMensajes.Controls.Add(Me.lblMensaje)
        Me.pnlMensajes.Location = New System.Drawing.Point(4, 0)
        Me.pnlMensajes.Name = "pnlMensajes"
        Me.pnlMensajes.Size = New System.Drawing.Size(802, 24)
        Me.pnlMensajes.TabIndex = 26
        '
        'pbAlerta
        '
        Me.pbAlerta.Location = New System.Drawing.Point(4, 1)
        Me.pbAlerta.Name = "pbAlerta"
        Me.pbAlerta.Size = New System.Drawing.Size(22, 21)
        Me.pbAlerta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbAlerta.TabIndex = 5
        Me.pbAlerta.TabStop = False
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.Location = New System.Drawing.Point(29, 5)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(47, 14)
        Me.lblMensaje.TabIndex = 1
        Me.lblMensaje.Text = "Mensaje"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(72, 33)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(35, 34)
        Me.btnSalir.TabIndex = 63
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(2, 33)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(35, 34)
        Me.btnEnviar.TabIndex = 62
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(16, 176)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(952, 424)
        Me.DataGridView1.TabIndex = 72
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(984, 612)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtCntRegistros)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEnviar)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlMensajes.ResumeLayout(False)
        Me.pnlMensajes.PerformLayout()
        CType(Me.pbAlerta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCntRegistros As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbEgresos As System.Windows.Forms.RadioButton
    Friend WithEvents rbPagos As System.Windows.Forms.RadioButton
    Friend WithEvents rbIngresos As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pgbFacturas As System.Windows.Forms.ProgressBar
    Friend WithEvents pnlMensajes As System.Windows.Forms.Panel
    Friend WithEvents pbAlerta As System.Windows.Forms.PictureBox
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView

End Class
