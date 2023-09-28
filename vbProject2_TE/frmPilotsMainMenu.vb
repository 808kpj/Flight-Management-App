Public Class frmPilotsMainMenu
    Private Sub btnUpdateCustomerProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomerProfile.Click
        'creating variable
        Dim frmPilotProfileUpdate As New frmPilotUpdateMenu

        'opens the object in its owens instance 
        frmPilotProfileUpdate.ShowDialog()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        'creating variable
        Dim frmPilotPastFlights As New frmPilotPastFlights

        'opens the object in its owens instance 
        frmPilotPastFlights.ShowDialog()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        'creating variable
        Dim frmPilotFutureFlights As New frmPilotFutureFlights

        'opens the object in its owens instance 
        frmPilotFutureFlights.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub frmPilotsMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class