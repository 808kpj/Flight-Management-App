Public Class frmAdminPage
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnManagePilots_Click(sender As Object, e As EventArgs) Handles btnManagePilots.Click
        'creating variable
        Dim frmAdminPilotManager As New frmAdminPilotManager

        'displaying the variable
        frmAdminPilotManager.ShowDialog()
    End Sub

    Private Sub btnManageAttendents_Click(sender As Object, e As EventArgs) Handles btnManageAttendents.Click
        'creating variable
        Dim frmAdminAttendentManager As New frmAdminAttendentManager

        'displaying the variable
        frmAdminAttendentManager.ShowDialog()
    End Sub

    Private Sub btnAddFutureFlight_Click(sender As Object, e As EventArgs) Handles btnAddFutureFlight.Click
        'creating variable
        Dim frmAdminAddFutureFlight As New frmAdminAddFutureFlight

        'displaying the variable
        frmAdminAddFutureFlight.ShowDialog()
    End Sub
End Class