<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGVSearch = New System.Windows.Forms.DataGridView()
        Me.pid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lastname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.firstname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.middleinitial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suffix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateofbirth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mothername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fathername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.DGVSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGVSearch
        '
        Me.DGVSearch.AllowUserToAddRows = False
        Me.DGVSearch.AllowUserToResizeColumns = False
        Me.DGVSearch.AllowUserToResizeRows = False
        Me.DGVSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVSearch.BackgroundColor = System.Drawing.Color.White
        Me.DGVSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGVSearch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DGVSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVSearch.ColumnHeadersHeight = 30
        Me.DGVSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGVSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pid, Me.lastname, Me.firstname, Me.middleinitial, Me.suffix, Me.gender, Me.dateofbirth, Me.mothername, Me.fathername, Me.address, Me.btnEdit, Me.btnDelete})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVSearch.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVSearch.EnableHeadersVisualStyles = False
        Me.DGVSearch.Location = New System.Drawing.Point(9, 45)
        Me.DGVSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DGVSearch.Name = "DGVSearch"
        Me.DGVSearch.RowHeadersVisible = False
        Me.DGVSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVSearch.Size = New System.Drawing.Size(913, 465)
        Me.DGVSearch.TabIndex = 0
        '
        'pid
        '
        Me.pid.DataPropertyName = "pid"
        Me.pid.HeaderText = "ID"
        Me.pid.Name = "pid"
        Me.pid.Visible = False
        '
        'lastname
        '
        Me.lastname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.lastname.DataPropertyName = "lastname"
        Me.lastname.HeaderText = "LAST NAME"
        Me.lastname.Name = "lastname"
        Me.lastname.Width = 89
        '
        'firstname
        '
        Me.firstname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.firstname.DataPropertyName = "firstname"
        Me.firstname.HeaderText = "FIRST NAME"
        Me.firstname.Name = "firstname"
        Me.firstname.Width = 94
        '
        'middleinitial
        '
        Me.middleinitial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.middleinitial.DataPropertyName = "middleinitial"
        Me.middleinitial.HeaderText = "MI"
        Me.middleinitial.Name = "middleinitial"
        Me.middleinitial.Width = 45
        '
        'suffix
        '
        Me.suffix.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.suffix.DataPropertyName = "suffix"
        Me.suffix.HeaderText = "SUFFIX"
        Me.suffix.Name = "suffix"
        Me.suffix.Width = 67
        '
        'gender
        '
        Me.gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.gender.DataPropertyName = "gender"
        Me.gender.HeaderText = "SEX"
        Me.gender.Name = "gender"
        Me.gender.Width = 49
        '
        'dateofbirth
        '
        Me.dateofbirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dateofbirth.DataPropertyName = "dateofbirth"
        Me.dateofbirth.HeaderText = "DATE OF BIRTH"
        Me.dateofbirth.Name = "dateofbirth"
        Me.dateofbirth.Width = 109
        '
        'mothername
        '
        Me.mothername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.mothername.DataPropertyName = "mothername"
        Me.mothername.HeaderText = "MOTHER'S NAME"
        Me.mothername.Name = "mothername"
        Me.mothername.Width = 121
        '
        'fathername
        '
        Me.fathername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.fathername.DataPropertyName = "fathername"
        Me.fathername.HeaderText = "FATHER'S NAME"
        Me.fathername.Name = "fathername"
        Me.fathername.Width = 112
        '
        'address
        '
        Me.address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.address.DataPropertyName = "address"
        Me.address.HeaderText = "ADDRESS"
        Me.address.Name = "address"
        '
        'btnEdit
        '
        Me.btnEdit.HeaderText = ""
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btnDelete
        '
        Me.btnDelete.HeaderText = ""
        Me.btnDelete.Name = "btnDelete"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(851, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(71, 28)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 26)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "SEARCH INFORMATION"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(934, 46)
        Me.Panel1.TabIndex = 6
        '
        'frmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 519)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGVSearch)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmSearch"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGVSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGVSearch As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pid As DataGridViewTextBoxColumn
    Friend WithEvents lastname As DataGridViewTextBoxColumn
    Friend WithEvents firstname As DataGridViewTextBoxColumn
    Friend WithEvents middleinitial As DataGridViewTextBoxColumn
    Friend WithEvents suffix As DataGridViewTextBoxColumn
    Friend WithEvents gender As DataGridViewTextBoxColumn
    Friend WithEvents dateofbirth As DataGridViewTextBoxColumn
    Friend WithEvents mothername As DataGridViewTextBoxColumn
    Friend WithEvents fathername As DataGridViewTextBoxColumn
    Friend WithEvents address As DataGridViewTextBoxColumn
    Friend WithEvents btnEdit As DataGridViewImageColumn
    Friend WithEvents btnDelete As DataGridViewImageColumn
End Class
