Public Class frmAdminPilotDelete
    Private Sub frmAdminPilotDelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtPilot As DataTable = New DataTable            ' this is the table we will load from our reader
        Try

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement
            strSelect = "SELECT intPilotID, strFirstName + ' ' + strLastName as FullName  FROM TPilots"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'loads the result set into the cbo field 
            dtPilot.Load(drSourceTable)


            'the index of what is being showed to the user and what the programmer user to do other things with the user input

            cboPilots.ValueMember = "intPilotID"

            'is what is being displayed in the combo box for the user to interact with
            cboPilots.DisplayMember = "FullName"

            'fills the combo box with data passed into it

            cboPilots.DataSource = dtPilot

            'selects the first item in the list by default
            If cboPilots.Items.Count > 0 Then
                cboPilots.SelectedIndex = 0
            End If

            'Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As New OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult  ' this is the result of which button the user selects
        Dim intPKID As Integer

        'sets the current login in user primiary key to the variable
        intPKID = cboPilots.SelectedIndex.ToString

        Try
            ' open the database this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' always ask before deleting!!!!
            result = MessageBox.Show("Are you sure you want to Delete Pilot: " & cboPilots.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    ' Build the delete statement using PK from name selected

                    'strDelete = "Delete FROM TPilots Where intPilotID = " & cboPilots.SelectedValue.ToString

                    ' Delete the record(s) 
                    'cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)



                    ''uses the sql string and the connection object to talk with the database
                    cmdDelete.CommandText = "EXECUTE uspDeleteCustomer '" & cboPilots.SelectedValue & "'"
                    cmdDelete.CommandType = CommandType.StoredProcedure

                    'call stored proc which will insert the record
                    cmdDelete = New OleDb.OleDbCommand(cmdDelete.CommandText, m_conAdministrator)

                    'save the number of rows affected to an variable
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    ' Did it work?
                    If intRowsAffected > 0 Then

                        ' Yes, success
                        MessageBox.Show("Delete successful")
                    Else
                        MessageBox.Show("Delete Failed")

                    End If

            End Select


            ' close the database connection
            CloseDatabaseConnection()

            ' call the Form Load sub to refresh the combo box data after a delete
            frmAdminPilotDelete_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class