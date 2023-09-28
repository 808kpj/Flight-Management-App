<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPilotPastFlights
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
        Me.lblTotalMilesFlown = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPassFlights = New System.Windows.Forms.Button()
        Me.lstResultSet = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTotalMilesFlown
        '
        Me.lblTotalMilesFlown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalMilesFlown.Location = New System.Drawing.Point(123, 36)
        Me.lblTotalMilesFlown.Name = "lblTotalMilesFlown"
        Me.lblTotalMilesFlown.Size = New System.Drawing.Size(141, 23)
        Me.lblTotalMilesFlown.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Total Miles Flown:"
        '
        'btnPassFlights
        '
        Me.btnPassFlights.Location = New System.Drawing.Point(23, 448)
        Me.btnPassFlights.Margin = New System.Windows.Forms.Padding(1)
        Me.btnPassFlights.Name = "btnPassFlights"
        Me.btnPassFlights.Size = New System.Drawing.Size(133, 37)
        Me.btnPassFlights.TabIndex = 39
        Me.btnPassFlights.Text = "Past Flights"
        Me.btnPassFlights.UseVisualStyleBackColor = True
        '
        'lstResultSet
        '
        Me.lstResultSet.FormattingEnabled = True
        Me.lstResultSet.Location = New System.Drawing.Point(31, 81)
        Me.lstResultSet.Margin = New System.Windows.Forms.Padding(1)
        Me.lstResultSet.Name = "lstResultSet"
        Me.lstResultSet.Size = New System.Drawing.Size(281, 329)
        Me.lstResultSet.TabIndex = 38
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(176, 448)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(133, 37)
        Me.btnExit.TabIndex = 37
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmPilotPastFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 516)
        Me.Controls.Add(Me.lblTotalMilesFlown)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPassFlights)
        Me.Controls.Add(Me.lstResultSet)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmPilotPastFlights"
        Me.Text = "Pilot Past Flights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTotalMilesFlown As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnPassFlights As Button
    Friend WithEvents lstResultSet As ListBox
    Friend WithEvents btnExit As Button
End Class
