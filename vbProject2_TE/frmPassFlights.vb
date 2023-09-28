Public Class frmPassFlights
    Private Sub btnPassFlights_Click(sender As Object, e As EventArgs) Handles btnPassFlights.Click
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader
            Dim objParam As OleDb.OleDbParameter           ' this will be used to add parameters needed for stored procedures


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
            'strSelect = "SELECT TP.*, TF.*,TA.strAirportCity as ToAirport, TAR.strAirportCity as FromAirport, TPL.strPlaneNumber" &
            '    " FROM TPassengers as TP join TFlightPassengers as TFP on TP.intPassengerID = TFP.intPassengerID" &
            '    " join TFlights as TF on TF.intFlightID = TFP.intFlightID" &
            '    " join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID" &
            '    " join TAirports as TA on TA.intAirportID = TF.intToAirportID" &
            '    " join TAirports as TAR on TAR.intAirportID = TF.intFromAirportID" &
            '    " WHERE dtmFlightDate < GETDATE() and" &
            '    " TP.intPassengerID = " & intCustomerID

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand("PastFlightDataCustomer", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@customer_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intCustomerID

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

    Private Sub frmPassFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
            Dim dtMilesFlown As DataTable = New DataTable            ' this is the table we will load from our reader
            Dim objParam As OleDb.OleDbParameter           ' this will be used to add parameters needed for stored procedures


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
            'strSelect = "SELECT Sum(TF.intMilesFlown) as Miles_Flown" &
            '    " FROM TPassengers as TP join TFlightPassengers as TFP on TP.intPassengerID = TFP.intPassengerID" &
            '    " join TFlights as TF on TF.intFlightID = TFP.intFlightID" &
            '    " join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID" &
            '    " join TAirports as TA on TA.intAirportID = TF.intToAirportID" &
            '    " WHERE dtmFlightDate < GETDATE() and" &
            '    " TP.intPassengerID = " & intCustomerID

            'MessageBox.Show(strSelect)

            'Retrieve all the records from the sql procedure
            'Telling the command the command type is a stored procedure
            'Assigning the object paramaters to the sql procedure
            'Stating its type is an input
            'Selecting the customer id as the paramater value

            cmdSelect = New OleDb.OleDbCommand("TotalPastFlightMilesCustomer", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@customer_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intCustomerID

            drSourceTable = cmdSelect.ExecuteReader

            'reads the resualt (highest ID)
            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then

                'if the database is empty it will display zero
                lblTotalMilesFlown.Text = 0
            Else

                'loads the querry into the respected field
                lblTotalMilesFlown.Text = CInt(drSourceTable("Miles_Flown"))
            End If

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class