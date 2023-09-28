Public Class Start_Menu
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            'declaring a string
            Dim intCboValue As Integer

            intCboValue = cboUsers.SelectedIndex

            Select Case intCboValue
                Case 0
                    'creating form variable
                    Dim frmCustomerLogin As New frmCustomerLogin

                    'opens the form in its own instance
                    frmCustomerLogin.ShowDialog()

                Case 1
                    'creating form variable
                    Dim frmPilotLogin As New frmPilotSignin

                    'opens the form in its own instance
                    frmPilotLogin.ShowDialog()

                Case 2
                    'creating form variable
                    Dim frmAttendentLogin As New frmAttendentLogin

                    'opens the form in its own instance
                    frmAttendentLogin.ShowDialog()


                Case 3
                    'creating form variable
                    Dim frmAdminLogin As New frmAdminPage

                    'opens the form in its own instance
                    frmAdminLogin.ShowDialog()

                Case 4
                    'creating form variable
                    Dim frmStatistics As New frmStatistics

                    'opens the form in its own instance
                    frmStatistics.ShowDialog()

                Case Else
                    MessageBox.Show("Please select an option")
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class
