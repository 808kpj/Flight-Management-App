Public Class frmAdminAttendentFutureFlight
    Private Sub frmAdminAttendentFutureFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtFlights As DataTable = New DataTable            ' this is the table we will load from our reader
        Dim dtAttendent As DataTable = New DataTable            ' this is the table we will load from our reader

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

            ' Build the select statement for flight dates
            strSelect = "SELECT intFlightID, dtmFlightDate FROM TFlights Where dtmFlightDate > GETDATE()"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtFlights.Load(drSourceTable)

            'the index of what is being showed to the user and what the programmer user to do other things with the user input
            cboFutureFlights.ValueMember = "intFlightID"
            'is what is being displayed in the combo box for the user to interact with
            cboFutureFlights.DisplayMember = "dtmFlightDate"
            'fills the combo box with data passed into it
            cboFutureFlights.DataSource = dtFlights


            ' Build the select statement for pilots names
            strSelect = "SELECT intAttendantID, strFirstName + ' ' + strLastName as FullName FROM TAttendants"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtAttendent.Load(drSourceTable)

            'the index of what is being showed to the user and what the programmer user to do other things with the user input
            cboAttendents.ValueMember = "intAttendantID"
            'is what is being displayed in the combo box for the user to interact with
            cboAttendents.DisplayMember = "FullName"
            'fills the combo box with data passed into it
            cboAttendents.DataSource = dtAttendent

            'Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'creating variables
        Dim strSeat As String
        Dim intFLightID As Integer
        Dim strSelect As String
        Dim strInsert As String
        Dim intAttendentID As Integer

        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim cmdInsert As OleDb.OleDbCommand ' this will be used for our insert statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim intNextPrimaryKey As Integer 'this will get the next advialble primapy key number for the new incert
        Dim intRowsaffected As Integer   ' how many rows were affected from the sql querry
        Dim result As DialogResult  ' this is the result of which button the user selects
        Try
            intFLightID = cboFutureFlights.SelectedValue
            intAttendentID = cboAttendents.SelectedValue

            If cboFutureFlights.Text = String.Empty Then
                MessageBox.Show("Please select a flight")
                cboFutureFlights.Focus()
                Exit Try
            ElseIf cboAttendents.Text = String.Empty Then
                MessageBox.Show("Please select a Attendent")
                cboAttendents.Focus()
                Exit Try
            Else
                result = MessageBox.Show("Are you sure you want to assign this attendent " & cboAttendents.Text & " to this date: " & cboFutureFlights.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                Select Case result
                    Case DialogResult.Cancel
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.No
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.Yes

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

                        ' Build the select statement using PK from name selected
                        strSelect = "SELECT MAX(intAttendantFlightID) + 1 AS intNextPrimaryKey " & " From TAttendantFlights"

                        'MessageBox.Show(strSelect)

                        ' Retrieve all the records 
                        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                        drSourceTable = cmdSelect.ExecuteReader

                        'read tesult with highest ID
                        drSourceTable.Read()

                        'checking to see if the database is empty
                        If drSourceTable.IsDBNull(0) = True Then

                            'if so then start at one
                            intNextPrimaryKey = 1
                        Else

                            'get the next highest value for the primary keys
                            intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                        End If

                        'create the insert statement (must match the order in the databases)
                        strInsert = "INSERT INTO TAttendantFlights (intAttendantFlightID, intAttendantID, intFlightID)" &
                                " VALUES (" & intNextPrimaryKey & "," & intAttendentID & "," & intFLightID & ")"

                        MessageBox.Show(strInsert)

                        'uses the sql string and the connection object to teh database
                        cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                        'excute query to inseert data
                        intRowsaffected = cmdInsert.ExecuteNonQuery()

                        'if not zero the insert was successful
                        If intRowsaffected > 0 Then
                            MessageBox.Show("Flight was successfully added")
                        End If

                        'Clean up
                        drSourceTable.Close()

                        ' close the database connection
                        CloseDatabaseConnection()

                End Select
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class