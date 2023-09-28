<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerAddFlight
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
        Me.cboFutureFlights = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSeats = New System.Windows.Forms.ComboBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.radReservedSeat = New System.Windows.Forms.RadioButton()
        Me.radCheckIn = New System.Windows.Forms.RadioButton()
        Me.lblReservedSeatPrice = New System.Windows.Forms.Label()
        Me.lblCheckinPrice = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboFutureFlights
        '
        Me.cboFutureFlights.FormattingEnabled = True
        Me.cboFutureFlights.Location = New System.Drawing.Point(160, 45)
        Me.cboFutureFlights.Name = "cboFutureFlights"
        Me.cboFutureFlights.Size = New System.Drawing.Size(175, 21)
        Me.cboFutureFlights.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Future Flights"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Seat Number"
        '
        'cboSeats
        '
        Me.cboSeats.FormattingEnabled = True
        Me.cboSeats.Items.AddRange(New Object() {"1A", "1B", "3C", "1A", "2B", "3C"})
        Me.cboSeats.Location = New System.Drawing.Point(160, 93)
        Me.cboSeats.Name = "cboSeats"
        Me.cboSeats.Size = New System.Drawing.Size(175, 21)
        Me.cboSeats.TabIndex = 3
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(79, 237)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 4
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(209, 237)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'radReservedSeat
        '
        Me.radReservedSeat.AutoSize = True
        Me.radReservedSeat.Location = New System.Drawing.Point(38, 131)
        Me.radReservedSeat.Name = "radReservedSeat"
        Me.radReservedSeat.Size = New System.Drawing.Size(96, 17)
        Me.radReservedSeat.TabIndex = 5
        Me.radReservedSeat.TabStop = True
        Me.radReservedSeat.Text = "Reserved Seat"
        Me.radReservedSeat.UseVisualStyleBackColor = True
        '
        'radCheckIn
        '
        Me.radCheckIn.AutoSize = True
        Me.radCheckIn.Location = New System.Drawing.Point(41, 176)
        Me.radCheckIn.Name = "radCheckIn"
        Me.radCheckIn.Size = New System.Drawing.Size(67, 17)
        Me.radCheckIn.TabIndex = 6
        Me.radCheckIn.TabStop = True
        Me.radCheckIn.Text = "Check in"
        Me.radCheckIn.UseVisualStyleBackColor = True
        '
        'lblReservedSeatPrice
        '
        Me.lblReservedSeatPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReservedSeatPrice.Location = New System.Drawing.Point(181, 131)
        Me.lblReservedSeatPrice.Name = "lblReservedSeatPrice"
        Me.lblReservedSeatPrice.Size = New System.Drawing.Size(133, 23)
        Me.lblReservedSeatPrice.TabIndex = 7
        '
        'lblCheckinPrice
        '
        Me.lblCheckinPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCheckinPrice.Location = New System.Drawing.Point(181, 170)
        Me.lblCheckinPrice.Name = "lblCheckinPrice"
        Me.lblCheckinPrice.Size = New System.Drawing.Size(133, 23)
        Me.lblCheckinPrice.TabIndex = 7
        '
        'frmCustomerAddFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 302)
        Me.Controls.Add(Me.lblCheckinPrice)
        Me.Controls.Add(Me.lblReservedSeatPrice)
        Me.Controls.Add(Me.radCheckIn)
        Me.Controls.Add(Me.radReservedSeat)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cboSeats)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFutureFlights)
        Me.Name = "frmCustomerAddFlight"
        Me.Text = "Book Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboFutureFlights As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboSeats As ComboBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents radReservedSeat As RadioButton
    Friend WithEvents radCheckIn As RadioButton
    Friend WithEvents lblReservedSeatPrice As Label
    Friend WithEvents lblCheckinPrice As Label
End Class
