<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminAddFutureFlight
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.txtMilesFlown = New System.Windows.Forms.TextBox()
        Me.dtmDateofFlight = New System.Windows.Forms.DateTimePicker()
        Me.cboFromAirport = New System.Windows.Forms.ComboBox()
        Me.cboToAirport = New System.Windows.Forms.ComboBox()
        Me.cboPlaneID = New System.Windows.Forms.ComboBox()
        Me.dtmDeparture = New System.Windows.Forms.DateTimePicker()
        Me.dtmLandingForm = New System.Windows.Forms.DateTimePicker()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date of Flight"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Flight Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Time of Departure"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(60, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Time of Landing"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Miles Flown"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(63, 262)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "From Airport"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(63, 296)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "To Airport"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 333)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "PlaneID"
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Location = New System.Drawing.Point(196, 98)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(203, 20)
        Me.txtFlightNumber.TabIndex = 8
        '
        'txtMilesFlown
        '
        Me.txtMilesFlown.Location = New System.Drawing.Point(193, 220)
        Me.txtMilesFlown.Name = "txtMilesFlown"
        Me.txtMilesFlown.Size = New System.Drawing.Size(206, 20)
        Me.txtMilesFlown.TabIndex = 8
        '
        'dtmDateofFlight
        '
        Me.dtmDateofFlight.Location = New System.Drawing.Point(196, 58)
        Me.dtmDateofFlight.Name = "dtmDateofFlight"
        Me.dtmDateofFlight.Size = New System.Drawing.Size(200, 20)
        Me.dtmDateofFlight.TabIndex = 9
        Me.dtmDateofFlight.Value = New Date(2022, 12, 15, 0, 0, 0, 0)
        '
        'cboFromAirport
        '
        Me.cboFromAirport.FormattingEnabled = True
        Me.cboFromAirport.Location = New System.Drawing.Point(193, 253)
        Me.cboFromAirport.Name = "cboFromAirport"
        Me.cboFromAirport.Size = New System.Drawing.Size(206, 21)
        Me.cboFromAirport.TabIndex = 10
        '
        'cboToAirport
        '
        Me.cboToAirport.FormattingEnabled = True
        Me.cboToAirport.Location = New System.Drawing.Point(193, 293)
        Me.cboToAirport.Name = "cboToAirport"
        Me.cboToAirport.Size = New System.Drawing.Size(206, 21)
        Me.cboToAirport.TabIndex = 10
        '
        'cboPlaneID
        '
        Me.cboPlaneID.FormattingEnabled = True
        Me.cboPlaneID.Location = New System.Drawing.Point(193, 333)
        Me.cboPlaneID.Name = "cboPlaneID"
        Me.cboPlaneID.Size = New System.Drawing.Size(206, 21)
        Me.cboPlaneID.TabIndex = 10
        '
        'dtmDeparture
        '
        Me.dtmDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtmDeparture.Location = New System.Drawing.Point(196, 141)
        Me.dtmDeparture.Name = "dtmDeparture"
        Me.dtmDeparture.Size = New System.Drawing.Size(200, 20)
        Me.dtmDeparture.TabIndex = 9
        Me.dtmDeparture.Value = New Date(2022, 12, 15, 0, 0, 0, 0)
        '
        'dtmLandingForm
        '
        Me.dtmLandingForm.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtmLandingForm.Location = New System.Drawing.Point(193, 178)
        Me.dtmLandingForm.Name = "dtmLandingForm"
        Me.dtmLandingForm.Size = New System.Drawing.Size(200, 20)
        Me.dtmLandingForm.TabIndex = 9
        Me.dtmLandingForm.Value = New Date(2022, 12, 15, 0, 0, 0, 0)
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(63, 395)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(126, 23)
        Me.btnSubmit.TabIndex = 11
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(273, 395)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(126, 23)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmAdminAddFutureFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 454)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cboPlaneID)
        Me.Controls.Add(Me.cboToAirport)
        Me.Controls.Add(Me.cboFromAirport)
        Me.Controls.Add(Me.dtmLandingForm)
        Me.Controls.Add(Me.dtmDeparture)
        Me.Controls.Add(Me.dtmDateofFlight)
        Me.Controls.Add(Me.txtMilesFlown)
        Me.Controls.Add(Me.txtFlightNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAdminAddFutureFlight"
        Me.Text = "Admin Add Future Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents txtMilesFlown As TextBox
    Friend WithEvents dtmDateofFlight As DateTimePicker
    Friend WithEvents cboFromAirport As ComboBox
    Friend WithEvents cboToAirport As ComboBox
    Friend WithEvents cboPlaneID As ComboBox
    Friend WithEvents dtmDeparture As DateTimePicker
    Friend WithEvents dtmLandingForm As DateTimePicker
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
End Class
