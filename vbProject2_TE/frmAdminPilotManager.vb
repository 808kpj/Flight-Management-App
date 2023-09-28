Public Class frmAdminPilotManager
    Private Sub btnAddPilot_Click(sender As Object, e As EventArgs) Handles btnAddPilot.Click
        'creating variable
        Dim frmAdminAddPiolot As New frmAdminAddPiolot

        'displaying the variable
        frmAdminAddPiolot.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnDeletePilot_Click(sender As Object, e As EventArgs) Handles btnDeletePilot.Click
        'creating variable
        Dim frmAdminPilotDelete As New frmAdminPilotDelete

        'displaying the variable
        frmAdminPilotDelete.ShowDialog()
    End Sub

    Private Sub btnPilotFutureFlights_Click(sender As Object, e As EventArgs) Handles btnPilotFutureFlights.Click
        'creating variable
        Dim frmAdminAddFutureFlightPilot As New frmAdminAddFutureFlightPilot

        'displaying the variable
        frmAdminAddFutureFlightPilot.ShowDialog()
    End Sub

    Private Sub btnUpdatePilots_Click(sender As Object, e As EventArgs) Handles btnUpdatePilots.Click
        'creating variable
        Dim frmAdminPilotUpdate As New frmAdminPilotUpdate

        'displaying the variable
        frmAdminPilotUpdate.ShowDialog()
    End Sub


End Class