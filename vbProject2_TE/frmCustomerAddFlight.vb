Public Class frmCustomerAddFlight
    Dim IntReservedTotal As Integer
    Dim IntCheckinPrice As Integer
    Private Sub frmCustomerAddFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtFlights As DataTable = New DataTable            ' this is the table we will load from our reader
        radCheckIn.Enabled = False
        radReservedSeat.Enabled = False


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

            'Clean up
            drSourceTable.Close()



            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub cboFutureFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFutureFlights.SelectedIndexChanged
        'creating variables
        Dim intBaseCost As Integer
        Dim intReservedSeat As Integer
        Dim intCurentFlight As Integer
        Dim cmdCommand As New OleDb.OleDbCommand()
        Dim cmdPassengerCommand As New OleDb.OleDbCommand()
        Dim objReader As OleDb.OleDbDataReader
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim strCommandValue As String
        Dim intCommandValue As Integer
        Dim intRowsAffected As Integer

        radCheckIn.Enabled = True
        radReservedSeat.Enabled = True

        'declaring variables
        intCurentFlight = cboFutureFlights.SelectedValue
        intBaseCost = 250
        intReservedSeat = 125


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

            IntReservedTotal = 0
            IntCheckinPrice = 0

            'add the base calculations to the variables
            IntReservedTotal += intBaseCost + intReservedSeat
            IntCheckinPrice += intBaseCost

            'calling the stored procudure for checking miles
            cmdCommand.CommandText = "EXECUTE uspTotalMilesofFlight '" & intCurentFlight & "'"
            cmdCommand.CommandType = CommandType.StoredProcedure

            'call stored proc which will insert the record
            cmdCommand = New OleDb.OleDbCommand(cmdCommand.CommandText, m_conAdministrator)

            intCommandValue = cmdCommand.ExecuteScalar()

            '' IUpdate the row with execute the statement
            'intRowsAffected = cmdCommand.ExecuteNonQuery()

            '' have to let the user know what happened 
            'If intRowsAffected = -1 Then
            '    MessageBox.Show("Miles Cal successful")
            'Else
            '    MessageBox.Show("Miles Cal failed")
            'End If

            ' checks to see if the plane is traveling more the 750 miles and if so will add 50 dollars to the bill
            If intCommandValue > 750 Then
                IntReservedTotal += 50
                IntCheckinPrice += 50
            End If


            'calling the stored procudure for checking how many passengers is on the curent plane
            cmdPassengerCommand.CommandText = "EXECUTE uspTotalNumberofPassengers '" & intCurentFlight & "'"
            cmdPassengerCommand.CommandType = CommandType.StoredProcedure

            'call stored proc which will insert the record
            cmdPassengerCommand = New OleDb.OleDbCommand(cmdPassengerCommand.CommandText, m_conAdministrator)

            intCommandValue = cmdPassengerCommand.ExecuteScalar()

            'drSourceTable = cmdPassengerCommand.ExecuteReader()
            'drSourceTable.Read()


            '' IUpdate the row with execute the statement
            'intRowsAffected = cmdPassengerCommand.ExecuteNonQuery()

            '' have to let the user know what happened 
            'If intRowsAffected = -1 Then
            '    MessageBox.Show("plane oucupancy successful")
            'Else
            '    MessageBox.Show("plane oucupancy failed")
            'End If


            ' checks to see if the plane oucupancy is more then 8 or less then 4
            If intCommandValue > 8 Then
                IntReservedTotal += 100
                IntCheckinPrice += 100

            ElseIf intCommandValue < 4 Then
                IntReservedTotal -= 50
                IntCheckinPrice -= 50

            End If


            'calling the stored procudure for checking plane type
            cmdCommand.CommandText = "EXECUTE uspTypeofPlane '" & intCurentFlight & "'"
            cmdCommand.CommandType = CommandType.StoredProcedure

            'call stored proc which will insert the record
            cmdCommand = New OleDb.OleDbCommand(cmdCommand.CommandText, m_conAdministrator)

            strCommandValue = cmdCommand.ExecuteScalar()
            'drSourceTable = cmdCommand.ExecuteReader()
            'drSourceTable.Read()

            ''IUpdate the row with execute the statement
            'intRowsAffected = cmdCommand.ExecuteNonQuery()

            '' have to let the user know what happened 
            'If intRowsAffected = -1 Then
            '    MessageBox.Show("type of plane successful")
            'Else
            '    MessageBox.Show("type of plane failed")
            'End If


            Select Case strCommandValue
                Case = "Airbus A350"
                    IntReservedTotal += 35
                    IntCheckinPrice += 35
                Case = "Boeing 747-8"
                    IntReservedTotal -= 35
                    IntCheckinPrice -= 35
                Case = "Boeing 767-300F"
                    IntReservedTotal -= 35
                    IntCheckinPrice -= 35
            End Select


            'calling the stored procudure for checking plane landing airport code
            cmdCommand.CommandText = "EXECUTE uspToAirportCode '" & intCurentFlight & "'"
            cmdCommand.CommandType = CommandType.StoredProcedure

            'call stored proc which will insert the record
            cmdCommand = New OleDb.OleDbCommand(cmdCommand.CommandText, m_conAdministrator)

            strCommandValue = cmdCommand.ExecuteScalar()

            ' IUpdate the row with execute the statement
            intRowsAffected = cmdCommand.ExecuteNonQuery()

            '' have to let the user know what happened 
            'If intRowsAffected = -1 Then
            '    MessageBox.Show("airport code successful")
            'Else
            '    MessageBox.Show("airport code failed")
            'End If

            'If strCommandValue = "MIA" Then
            '    IntReservedTotal += 15
            '    IntCheckinPrice += 15
            'End If


            'calling the stored procudure for checking passenger age
            cmdCommand.CommandText = "EXECUTE uspPassengerAge '" & intCurentFlight & "','" & intCustomerID & "'"
            cmdCommand.CommandType = CommandType.StoredProcedure

            'call stored proc which will insert the record
            cmdCommand = New OleDb.OleDbCommand(cmdCommand.CommandText, m_conAdministrator)

            intCommandValue = cmdCommand.ExecuteScalar()

            ' IUpdate the row with execute the statement
            intRowsAffected = cmdCommand.ExecuteNonQuery()

            '' have to let the user know what happened 
            'If intRowsAffected = -1 Then
            '    MessageBox.Show("passenger age successful")
            'Else
            '    MessageBox.Show("passenger age failed")
            'End If

            If intCommandValue > 65 Then
                IntReservedTotal -= (IntReservedTotal * 0.2)
                IntCheckinPrice -= (IntCheckinPrice * 0.2)

            ElseIf intCommandValue < 5 Then
                IntReservedTotal -= (IntReservedTotal * 0.65)
                IntCheckinPrice -= (IntCheckinPrice * 0.65)
            End If


            'calling the stored procudure for checking how many flights the passenger have flown previously
            cmdCommand.CommandText = "EXECUTE uspNumberofFlights '" & intCustomerID & "'"
            cmdCommand.CommandType = CommandType.StoredProcedure

            'call stored proc which will insert the record
            cmdCommand = New OleDb.OleDbCommand(cmdCommand.CommandText, m_conAdministrator)

            intCommandValue = cmdCommand.ExecuteScalar()

            ' IUpdate the row with execute the statement
            intRowsAffected = cmdCommand.ExecuteNonQuery()

            '' have to let the user know what happened 
            'If intRowsAffected = -1 Then
            '    MessageBox.Show("number of flights passanger have taken successful")
            'Else
            '    MessageBox.Show("number of flights passanger have taken failed")
            'End If

            If intCommandValue > 10 Then
                IntReservedTotal -= (IntReservedTotal * 0.1)
                IntCheckinPrice -= (IntCheckinPrice * 0.1)

            ElseIf intCommandValue > 5 Then
                IntReservedTotal -= (IntReservedTotal * 0.2)
                IntCheckinPrice -= (IntCheckinPrice * 0.2)
            End If


            'Displayes the totals and convert to curencey
            lblCheckinPrice.Text = IntCheckinPrice.ToString("c")
            lblReservedSeatPrice.Text = IntReservedTotal.ToString("c")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'creating variables
        Dim strSeat As String
        Dim intFlightCost As Integer
        Dim intFLightID As Integer
        Dim strSelect As String
        Dim strInsert As String

        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim cmdInsert As OleDb.OleDbCommand ' this will be used for our insert statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim intNextPrimaryKey As Integer 'this will get the next advialble primapy key number for the new incert
        Dim intRowsaffected As Integer   ' how many rows were affected from the sql querry
        Dim result As DialogResult  ' this is the result of which button the user selects
        Try
            intFLightID = cboFutureFlights.SelectedValue
            strSeat = cboSeats.Text

            If radReservedSeat.Enabled Then
                intFlightCost = IntReservedTotal
            Else
                intFlightCost = IntCheckinPrice
            End If

            If cboFutureFlights.Text = String.Empty Then
                MessageBox.Show("Please select a flight")
                cboFutureFlights.Focus()
                Exit Try
            ElseIf cboSeats.Text = String.Empty Then
                MessageBox.Show("Please select a seat")
                cboSeats.Focus()
                Exit Try
            Else
                result = MessageBox.Show("Are you sure you want to book this flight on this date: " & cboFutureFlights.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

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
                        strSelect = "SELECT MAX(intFlightPassengerID) + 1 AS intNextPrimaryKey " & " From TFlightPassengers"

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
                        strInsert = "INSERT INTO TFlightPassengers (intFlightPassengerID, intFlightID, intPassengerID, strSeat, monFlightCost)" &
                                " VALUES (" & intNextPrimaryKey & "," & intFLightID & "," & intCustomerID & ",'" & strSeat & "'," & intFlightCost & ")"

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