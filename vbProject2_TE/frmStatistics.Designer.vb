<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStatistics
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
        Me.lblNumberofcustomers = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstResultSetPilots = New System.Windows.Forms.ListBox()
        Me.lstResultSetAttendents = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAllCustomersFLights = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblAverageCustomerMilesFlown = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblNumberofcustomers
        '
        Me.lblNumberofcustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumberofcustomers.Location = New System.Drawing.Point(209, 44)
        Me.lblNumberofcustomers.Name = "lblNumberofcustomers"
        Me.lblNumberofcustomers.Size = New System.Drawing.Size(141, 23)
        Me.lblNumberofcustomers.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Total Number of Customers:"
        '
        'lstResultSetPilots
        '
        Me.lstResultSetPilots.FormattingEnabled = True
        Me.lstResultSetPilots.Location = New System.Drawing.Point(387, 44)
        Me.lstResultSetPilots.Margin = New System.Windows.Forms.Padding(1)
        Me.lstResultSetPilots.Name = "lstResultSetPilots"
        Me.lstResultSetPilots.Size = New System.Drawing.Size(281, 329)
        Me.lstResultSetPilots.TabIndex = 42
        '
        'lstResultSetAttendents
        '
        Me.lstResultSetAttendents.FormattingEnabled = True
        Me.lstResultSetAttendents.Location = New System.Drawing.Point(685, 44)
        Me.lstResultSetAttendents.Margin = New System.Windows.Forms.Padding(1)
        Me.lstResultSetAttendents.Name = "lstResultSetAttendents"
        Me.lstResultSetAttendents.Size = New System.Drawing.Size(281, 329)
        Me.lstResultSetAttendents.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Total flights by all customers:"
        '
        'lblAllCustomersFLights
        '
        Me.lblAllCustomersFLights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAllCustomersFLights.Location = New System.Drawing.Point(209, 108)
        Me.lblAllCustomersFLights.Name = "lblAllCustomersFLights"
        Me.lblAllCustomersFLights.Size = New System.Drawing.Size(141, 23)
        Me.lblAllCustomersFLights.TabIndex = 44
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(183, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Average miles flown for all customers:"
        '
        'lblAverageCustomerMilesFlown
        '
        Me.lblAverageCustomerMilesFlown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAverageCustomerMilesFlown.Location = New System.Drawing.Point(209, 176)
        Me.lblAverageCustomerMilesFlown.Name = "lblAverageCustomerMilesFlown"
        Me.lblAverageCustomerMilesFlown.Size = New System.Drawing.Size(141, 23)
        Me.lblAverageCustomerMilesFlown.TabIndex = 44
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(120, 281)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(149, 47)
        Me.btnExit.TabIndex = 45
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseMnemonic = False
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 401)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblAverageCustomerMilesFlown)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblAllCustomersFLights)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNumberofcustomers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstResultSetAttendents)
        Me.Controls.Add(Me.lstResultSetPilots)
        Me.Name = "frmStatistics"
        Me.Text = "Statistics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNumberofcustomers As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lstResultSetPilots As ListBox
    Friend WithEvents lstResultSetAttendents As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAllCustomersFLights As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblAverageCustomerMilesFlown As Label
    Friend WithEvents btnExit As Button
End Class
