Public Class frmPilotFutureFlights
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
            strSelect = "SELECT TP.*, TF.*" &
                " FROM TPilots as TP join TPilotFlights as TPF on TP.intPilotID = TPF.intPilotID" &
                " join TFlights as TF on TF.intFlightID = TPF.intFlightID" &
                " join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID" &
                " join TAirports as TA on TA.intAirportID = TF.intToAirportID" &
                " WHERE dtmFlightDate > GETDATE() and" &
                " TP.intPilotID = " & intPilotID

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
                lstResultSet.Items.Add("Date of Flight: " & vbTab & vbTab & drSourceTable("dtmFlightDate"))
                lstResultSet.Items.Add("Flight Number: " & vbTab & vbTab & drSourceTable("strFlightNumber"))
                lstResultSet.Items.Add("Time of Departure: " & vbTab & vbTab & drSourceTable("dtmTimeofDeparture"))
                lstResultSet.Items.Add("Time of Landing: " & vbTab & drSourceTable("dtmTimeOfLanding"))
                lstResultSet.Items.Add("From Airport: " & vbTab & vbTab & drSourceTable("intFromAirportID"))
                lstResultSet.Items.Add("To Airport: " & vbTab & vbTab & drSourceTable("intToAirportID"))
                lstResultSet.Items.Add("Miles Flown: " & vbTab & vbTab & drSourceTable("intMilesFlown"))
                lstResultSet.Items.Add("Plane ID: " & vbTab & drSourceTable("intPlaneID"))


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