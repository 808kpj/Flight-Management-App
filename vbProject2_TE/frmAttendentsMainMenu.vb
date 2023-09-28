Public Class frmAttendentsMainMenu
    Private Sub btnUpdateCustomerProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomerProfile.Click
        Dim frmupdateformAttendent As New frmAttendentUpdateFom

        frmupdateformAttendent.ShowDialog()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        Dim frmAttendentsFutureFlights As New frmAttendentsFutureFlights

        frmAttendentsFutureFlights.ShowDialog()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        Dim frmAttendentsPastFlights As New frmAttendentsPastFlights

        frmAttendentsPastFlights.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class