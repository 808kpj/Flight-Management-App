Public Class frmAttendentLogin
    Private Sub frmAttendentLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtattendent As DataTable = New DataTable            ' this is the table we will load from our reader
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
            strSelect = "SELECT intAttendantID, strFirstName + ' ' + strLastName as FullName  FROM TAttendants"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'loads the result set into the cbo field 
            dtattendent.Load(drSourceTable)


            'the index of what is being showed to the user and what the programmer user to do other things with the user input

            cboAttendent.ValueMember = "intAttendantID"

            'is what is being displayed in the combo box for the user to interact with
            cboAttendent.DisplayMember = "FullName"

            'fills the combo box with data passed into it

            cboAttendent.DataSource = dtattendent

            'selects the first item in the list by default
            If cboAttendent.Items.Count > 0 Then
                cboAttendent.SelectedIndex = 0
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
        Try
            If cboAttendent.Text = String.Empty Then
                MessageBox.Show("Please select your name from the drop down, if you dont see your name exit the menu")
            Else
                'saves the curent user ID to the customer variable
                intAttendentID = cboAttendent.SelectedValue

                'creating form variable
                Dim frmAttendentsMainMenu As New frmAttendentsMainMenu

                'opens the form in its own instance
                frmAttendentsMainMenu.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class