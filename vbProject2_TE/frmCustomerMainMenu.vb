Public Class frmCustomerMainMenu
    Private Sub btnUpdateCustomerProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomerProfile.Click
        'creating variable
        Dim frmUpdateCustomerProfile As New frmUpdateCustomerProfile

        'call the form to be opened
        frmUpdateCustomerProfile.ShowDialog()
    End Sub

    Private Sub btnAddFlight_Click(sender As Object, e As EventArgs) Handles btnAddFlight.Click
        'creating variable
        Dim frmUpdateAddFlight As New frmCustomerAddFlight

        'call the form to be opened
        frmUpdateAddFlight.ShowDialog()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        'creating variable
        Dim frmPassFlights As New frmPassFlights

        'call the form to be opened
        frmPassFlights.ShowDialog()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        'creating variable
        Dim frmFutureFlights As New frmFutureFlights

        'call the form to be opened
        frmFutureFlights.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub frmCustomerMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class