<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPilotsMainMenu
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFutureFlights = New System.Windows.Forms.Button()
        Me.btnPastFlights = New System.Windows.Forms.Button()
        Me.btnUpdateCustomerProfile = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(101, 246)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(78, 23)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFutureFlights)
        Me.GroupBox1.Controls.Add(Me.btnPastFlights)
        Me.GroupBox1.Controls.Add(Me.btnUpdateCustomerProfile)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(234, 169)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pilot Options"
        '
        'btnFutureFlights
        '
        Me.btnFutureFlights.Location = New System.Drawing.Point(30, 112)
        Me.btnFutureFlights.Name = "btnFutureFlights"
        Me.btnFutureFlights.Size = New System.Drawing.Size(167, 23)
        Me.btnFutureFlights.TabIndex = 3
        Me.btnFutureFlights.Text = "Show Future Flights"
        Me.btnFutureFlights.UseVisualStyleBackColor = True
        '
        'btnPastFlights
        '
        Me.btnPastFlights.Location = New System.Drawing.Point(30, 77)
        Me.btnPastFlights.Name = "btnPastFlights"
        Me.btnPastFlights.Size = New System.Drawing.Size(167, 23)
        Me.btnPastFlights.TabIndex = 2
        Me.btnPastFlights.Text = "Show Past Flights"
        Me.btnPastFlights.UseVisualStyleBackColor = True
        '
        'btnUpdateCustomerProfile
        '
        Me.btnUpdateCustomerProfile.Location = New System.Drawing.Point(30, 41)
        Me.btnUpdateCustomerProfile.Name = "btnUpdateCustomerProfile"
        Me.btnUpdateCustomerProfile.Size = New System.Drawing.Size(167, 23)
        Me.btnUpdateCustomerProfile.TabIndex = 0
        Me.btnUpdateCustomerProfile.Text = "Update Profile"
        Me.btnUpdateCustomerProfile.UseVisualStyleBackColor = True
        '
        'frmPilotsMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 297)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmPilotsMainMenu"
        Me.Text = "Pilots Main Menu"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnFutureFlights As Button
    Friend WithEvents btnPastFlights As Button
    Friend WithEvents btnUpdateCustomerProfile As Button
End Class
