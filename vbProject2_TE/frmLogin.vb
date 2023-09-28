Public Class frmLogin
    Private Sub btnPassengerLogin_Click(sender As Object, e As EventArgs) Handles btnPassengerLogin.Click
        'creating variable
        Dim frmCustomerLogin As New frmCustomerLogin

        'opens the form in its new instance
        frmCustomerLogin.ShowDialog()
    End Sub

    Private Sub btnEmployeeLogin_Click(sender As Object, e As EventArgs) Handles btnEmployeeLogin.Click
        'creating variable
        Dim frmEmployeeLogin As New frmEmployeeLogin

        'opens the form in its New instance
        frmEmployeeLogin.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class