Public Class frmAttendentsFutureFlights
    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader


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
            strSelect = "SELECT TA.*, TF.*, TAT.strAirportCity as ToAirport, TAR.strAirportCity as FromAirport, TPL.strPlaneNumber" &
                " FROM TAttendants as TA join TAttendantFlights as TAF on TA.intAttendantID = TAF.intAttendantID" &
                " join TFlights as TF on TF.intFlightID = TAF.intFlightID" &
                " join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID" &
                " join TAirports as TAT on TAT.intAirportID = TF.intToAirportID" &
                " join TAirports as TAR on TAR.intAirportID = TF.intFromAirportID" &
                " WHERE dtmFlightDate > GETDATE() and" &
                " TA.intAttendantID = " & intAttendentID

            MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'loop through result set and display in Listbox

            lstResultSet.Items.Add("Roster of all your Past Flights")
            lstResultSet.Items.Add("=============================")

            While drSourceTable.Read()

                lstResultSet.Items.Add("  ")

                lstResultSet.Items.Add("First Name: " & vbTab & drSourceTable("strFirstName"))
                lstResultSet.Items.Add("Last Name: " & vbTab & drSourceTable("strLastName"))
                lstResultSet.Items.Add("Date of Flight: " & vbTab & drSourceTable("dtmFlightDate"))
                lstResultSet.Items.Add("Flight Number: " & vbTab & drSourceTable("strFlightNumber"))
                lstResultSet.Items.Add("Time of Departure: " & vbTab & drSourceTable("dtmTimeofDeparture"))
                lstResultSet.Items.Add("Time of Landing: " & vbTab & drSourceTable("dtmTimeOfLanding"))
                lstResultSet.Items.Add("From Airport: " & vbTab & drSourceTable("FromAirport"))
                lstResultSet.Items.Add("To Airport: " & vbTab & drSourceTable("ToAirport"))
                lstResultSet.Items.Add("Miles Flown: " & vbTab & drSourceTable("intMilesFlown"))
                lstResultSet.Items.Add("Plane ID: " & vbTab & drSourceTable("strPlaneNumber"))


                lstResultSet.Items.Add("  ")
                lstResultSet.Items.Add("=============================")

            End While


            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class