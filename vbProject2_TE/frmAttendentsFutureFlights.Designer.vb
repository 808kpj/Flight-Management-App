<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendentsFutureFlights
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
        Me.btnFutureFlights = New System.Windows.Forms.Button()
        Me.lstResultSet = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnFutureFlights
        '
        Me.btnFutureFlights.Location = New System.Drawing.Point(41, 377)
        Me.btnFutureFlights.Margin = New System.Windows.Forms.Padding(1)
        Me.btnFutureFlights.Name = "btnFutureFlights"
        Me.btnFutureFlights.Size = New System.Drawing.Size(133, 37)
        Me.btnFutureFlights.TabIndex = 45
        Me.btnFutureFlights.Text = "Future Flights"
        Me.btnFutureFlights.UseVisualStyleBackColor = True
        '
        'lstResultSet
        '
        Me.lstResultSet.FormattingEnabled = True
        Me.lstResultSet.Location = New System.Drawing.Point(49, 10)
        Me.lstResultSet.Margin = New System.Windows.Forms.Padding(1)
        Me.lstResultSet.Name = "lstResultSet"
        Me.lstResultSet.Size = New System.Drawing.Size(281, 329)
        Me.lstResultSet.TabIndex = 44
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(194, 377)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(133, 37)
        Me.btnExit.TabIndex = 43
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmAttendentsFutureFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 450)
        Me.Controls.Add(Me.btnFutureFlights)
        Me.Controls.Add(Me.lstResultSet)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmAttendentsFutureFlights"
        Me.Text = "Attendents Future Flights"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnFutureFlights As Button
    Friend WithEvents lstResultSet As ListBox
    Friend WithEvents btnExit As Button
End Class
