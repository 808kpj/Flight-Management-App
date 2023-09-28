<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminAttendentManager
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
        Me.btnAddAttendent = New System.Windows.Forms.Button()
        Me.btnUpdateAtendent = New System.Windows.Forms.Button()
        Me.btnDeleteAttendent = New System.Windows.Forms.Button()
        Me.btnAttendentFutureFlights = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAddAttendent)
        Me.GroupBox1.Controls.Add(Me.btnUpdateAtendent)
        Me.GroupBox1.Controls.Add(Me.btnDeleteAttendent)
        Me.GroupBox1.Controls.Add(Me.btnAttendentFutureFlights)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 191)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Attendent Manager"
        '
        'btnAddAttendent
        '
        Me.btnAddAttendent.Location = New System.Drawing.Point(30, 26)
        Me.btnAddAttendent.Name = "btnAddAttendent"
        Me.btnAddAttendent.Size = New System.Drawing.Size(134, 23)
        Me.btnAddAttendent.TabIndex = 0
        Me.btnAddAttendent.Text = "Add Attendent"
        Me.btnAddAttendent.UseVisualStyleBackColor = True
        '
        'btnUpdateAtendent
        '
        Me.btnUpdateAtendent.Location = New System.Drawing.Point(30, 103)
        Me.btnUpdateAtendent.Name = "btnUpdateAtendent"
        Me.btnUpdateAtendent.Size = New System.Drawing.Size(134, 23)
        Me.btnUpdateAtendent.TabIndex = 0
        Me.btnUpdateAtendent.Text = "Update Attendent"
        Me.btnUpdateAtendent.UseVisualStyleBackColor = True
        '
        'btnDeleteAttendent
        '
        Me.btnDeleteAttendent.Location = New System.Drawing.Point(30, 64)
        Me.btnDeleteAttendent.Name = "btnDeleteAttendent"
        Me.btnDeleteAttendent.Size = New System.Drawing.Size(134, 23)
        Me.btnDeleteAttendent.TabIndex = 0
        Me.btnDeleteAttendent.Text = "Delete Attendent"
        Me.btnDeleteAttendent.UseVisualStyleBackColor = True
        '
        'btnAttendentFutureFlights
        '
        Me.btnAttendentFutureFlights.Location = New System.Drawing.Point(30, 138)
        Me.btnAttendentFutureFlights.Name = "btnAttendentFutureFlights"
        Me.btnAttendentFutureFlights.Size = New System.Drawing.Size(134, 23)
        Me.btnAttendentFutureFlights.TabIndex = 0
        Me.btnAttendentFutureFlights.Text = "Add Future Flight"
        Me.btnAttendentFutureFlights.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(75, 251)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmAdminAttendentManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(247, 296)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmAdminAttendentManager"
        Me.Text = "Admin Attendent Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAddAttendent As Button
    Friend WithEvents btnDeleteAttendent As Button
    Friend WithEvents btnAttendentFutureFlights As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnUpdateAtendent As Button
End Class
