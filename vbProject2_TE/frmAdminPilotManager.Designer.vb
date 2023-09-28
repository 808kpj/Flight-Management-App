<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminPilotManager
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAddPilot = New System.Windows.Forms.Button()
        Me.btnDeletePilot = New System.Windows.Forms.Button()
        Me.btnPilotFutureFlights = New System.Windows.Forms.Button()
        Me.btnUpdatePilots = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAddPilot)
        Me.GroupBox1.Controls.Add(Me.btnDeletePilot)
        Me.GroupBox1.Controls.Add(Me.btnPilotFutureFlights)
        Me.GroupBox1.Controls.Add(Me.btnUpdatePilots)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 195)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pilot Manager"
        '
        'btnAddPilot
        '
        Me.btnAddPilot.Location = New System.Drawing.Point(30, 26)
        Me.btnAddPilot.Name = "btnAddPilot"
        Me.btnAddPilot.Size = New System.Drawing.Size(134, 23)
        Me.btnAddPilot.TabIndex = 0
        Me.btnAddPilot.Text = "Add Pilot"
        Me.btnAddPilot.UseVisualStyleBackColor = True
        '
        'btnDeletePilot
        '
        Me.btnDeletePilot.Location = New System.Drawing.Point(30, 64)
        Me.btnDeletePilot.Name = "btnDeletePilot"
        Me.btnDeletePilot.Size = New System.Drawing.Size(134, 23)
        Me.btnDeletePilot.TabIndex = 0
        Me.btnDeletePilot.Text = "Delete Pilot"
        Me.btnDeletePilot.UseVisualStyleBackColor = True
        '
        'btnPilotFutureFlights
        '
        Me.btnPilotFutureFlights.Location = New System.Drawing.Point(30, 148)
        Me.btnPilotFutureFlights.Name = "btnPilotFutureFlights"
        Me.btnPilotFutureFlights.Size = New System.Drawing.Size(134, 23)
        Me.btnPilotFutureFlights.TabIndex = 0
        Me.btnPilotFutureFlights.Text = "Add Future Flight"
        Me.btnPilotFutureFlights.UseVisualStyleBackColor = True
        '
        'btnUpdatePilots
        '
        Me.btnUpdatePilots.Location = New System.Drawing.Point(30, 106)
        Me.btnUpdatePilots.Name = "btnUpdatePilots"
        Me.btnUpdatePilots.Size = New System.Drawing.Size(134, 23)
        Me.btnUpdatePilots.TabIndex = 0
        Me.btnUpdatePilots.Text = "Update Pilot"
        Me.btnUpdatePilots.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(88, 266)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 23)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmAdminPilotManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 342)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmAdminPilotManager"
        Me.Text = "Admin Pilot Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAddPilot As Button
    Friend WithEvents btnPilotFutureFlights As Button
    Friend WithEvents btnDeletePilot As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnUpdatePilots As Button
End Class
