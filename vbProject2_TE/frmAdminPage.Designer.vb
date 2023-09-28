<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminPage
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
        Me.btnManagePilots = New System.Windows.Forms.Button()
        Me.btnManageAttendents = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAddFutureFlight = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnManagePilots
        '
        Me.btnManagePilots.Location = New System.Drawing.Point(28, 37)
        Me.btnManagePilots.Name = "btnManagePilots"
        Me.btnManagePilots.Size = New System.Drawing.Size(142, 23)
        Me.btnManagePilots.TabIndex = 0
        Me.btnManagePilots.Text = "Manage Pilots"
        Me.btnManagePilots.UseVisualStyleBackColor = True
        '
        'btnManageAttendents
        '
        Me.btnManageAttendents.Location = New System.Drawing.Point(28, 76)
        Me.btnManageAttendents.Name = "btnManageAttendents"
        Me.btnManageAttendents.Size = New System.Drawing.Size(142, 23)
        Me.btnManageAttendents.TabIndex = 0
        Me.btnManageAttendents.Text = "Manage Attendents"
        Me.btnManageAttendents.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(79, 208)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(97, 23)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAddFutureFlight)
        Me.GroupBox1.Controls.Add(Me.btnManageAttendents)
        Me.GroupBox1.Controls.Add(Me.btnManagePilots)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 170)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Admin Options"
        '
        'btnAddFutureFlight
        '
        Me.btnAddFutureFlight.Location = New System.Drawing.Point(28, 121)
        Me.btnAddFutureFlight.Name = "btnAddFutureFlight"
        Me.btnAddFutureFlight.Size = New System.Drawing.Size(142, 23)
        Me.btnAddFutureFlight.TabIndex = 1
        Me.btnAddFutureFlight.Text = "Future Flight"
        Me.btnAddFutureFlight.UseVisualStyleBackColor = True
        '
        'frmAdminPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(265, 258)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmAdminPage"
        Me.Text = "Admin Page"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnManagePilots As Button
    Friend WithEvents btnManageAttendents As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAddFutureFlight As Button
End Class
