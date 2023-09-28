Public Class frmAdminAttendentManager
    Private Sub btnAddAttendent_Click(sender As Object, e As EventArgs) Handles btnAddAttendent.Click
        Dim frmAddAttendnet As New frmAdminAddAttendent

        frmAddAttendnet.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnDeleteAttendent_Click(sender As Object, e As EventArgs) Handles btnDeleteAttendent.Click
        Dim frmAdminDeleteAttendent As New frmAdminDeleteAttendent

        frmAdminDeleteAttendent.ShowDialog()
    End Sub

    Private Sub btnAttendentFutureFlights_Click(sender As Object, e As EventArgs) Handles btnAttendentFutureFlights.Click
        Dim frmAdminAttendentFutureFlight As New frmAdminAttendentFutureFlight

        frmAdminAttendentFutureFlight.ShowDialog()
    End Sub

    Private Sub btnUpdateAtendent_Click(sender As Object, e As EventArgs) Handles btnUpdateAtendent.Click
        Dim frmAdminAttendantUpdate As New frmAdminAttendantUpdate

        frmAdminAttendantUpdate.ShowDialog()
    End Sub
End Class