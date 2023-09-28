<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.btnPassengerLogin = New System.Windows.Forms.Button()
        Me.btnEmployeeLogin = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Passenger Login:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Employee Login:"
        '
        'btnPassengerLogin
        '
        Me.btnPassengerLogin.Location = New System.Drawing.Point(140, 39)
        Me.btnPassengerLogin.Name = "btnPassengerLogin"
        Me.btnPassengerLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnPassengerLogin.TabIndex = 2
        Me.btnPassengerLogin.Text = "Log in"
        Me.btnPassengerLogin.UseVisualStyleBackColor = True
        '
        'btnEmployeeLogin
        '
        Me.btnEmployeeLogin.Location = New System.Drawing.Point(140, 101)
        Me.btnEmployeeLogin.Name = "btnEmployeeLogin"
        Me.btnEmployeeLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnEmployeeLogin.TabIndex = 3
        Me.btnEmployeeLogin.Text = "Login"
        Me.btnEmployeeLogin.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(88, 151)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(266, 186)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnEmployeeLogin)
        Me.Controls.Add(Me.btnPassengerLogin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmLogin"
        Me.Text = "frmLogin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPassengerLogin As Button
    Friend WithEvents btnEmployeeLogin As Button
    Friend WithEvents btnExit As Button
End Class
