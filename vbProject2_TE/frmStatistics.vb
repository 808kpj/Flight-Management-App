Public Class frmStatistics
    Private Sub frmStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            ' Build the select statement for total customers
            'strSelect = "SELECT count(TPassengers.intPassengerID) as Total_Customers" &
            '            " From TPassengers"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand("TotalCustomers", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            drSourceTable = cmdSelect.ExecuteReader

            'reads the resualt (highest ID)
            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then

                'if the database is empty it will display zero
                lblNumberofcustomers.Text = 0
            Else

                'loads the querry into the respected field
                lblNumberofcustomers.Text = CInt(drSourceTable("Total_Customers"))
            End If




            ' Build the select statement total flights by customers
            'strSelect = "SELECT count(TFP.intFlightPassengerID) as Total_FLights_By_Customers" &
            '            " From TFlightPassengers as TFP"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand("TotalMilesFlownCustomers", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            drSourceTable = cmdSelect.ExecuteReader

            'reads the resualt (highest ID)
            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then

                'if the database is empty it will display zero
                lblAllCustomersFLights.Text = 0
            Else

                'loads the querry into the respected field
                lblAllCustomersFLights.Text = CInt(drSourceTable("Total_FLights_By_Customers"))
            End If


            ' Build the select statement average miles flown
            'strSelect = "SELECT AVG(TF.intMilesFlown) as Total_AVG_Miles_Flown" &
            '            " From TFlights as TF"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand("avgMilesFlownbyCustomers", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            drSourceTable = cmdSelect.ExecuteReader


            'reads the resualt (highest ID)
            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then

                'if the database is empty it will display zero
                lblAverageCustomerMilesFlown.Text = 0
            Else

                'loads the querry into the respected field
                lblAverageCustomerMilesFlown.Text = CInt(drSourceTable("Total_AVG_Miles_Flown"))
            End If



            ' Build the select statement average miles flown
            'strSelect = "Select TP.strFirstName + ' ' + TP.strLastName as Name, sum(isnull(TF.intMilesFlown,0)) as Total_Miles_Flown_Pilots" &
            '            " From TPilots as TP  left join TPilotFlights as TPF on TP.intPilotID = TPF.intPilotID" &
            '            " left join TFlights as TF on TF.intFlightID = TPF.intFlightID" &
            '            " Group by TP.strFirstName, TP.strLastName"

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand("avgMilesFlownPilots", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            drSourceTable = cmdSelect.ExecuteReader

            lstResultSetPilots.Items.Add("Roster of All Pilots")
            lstResultSetPilots.Items.Add("=============================")

            While drSourceTable.Read()
                lstResultSetPilots.Items.Add(" ")
                lstResultSetPilots.Items.Add("=====================================")

                lstResultSetPilots.Items.Add("Pilot Name: " & vbTab & drSourceTable("Name"))
                lstResultSetPilots.Items.Add("Total Miles Flown: " & vbTab & drSourceTable("Total_Miles_Flown_Pilots"))

            End While



            ' Build the select statement average miles flown
            'strSelect = "Select TA.strFirstName + ' ' + TA.strLastName as Name, sum(isnull(TF.intMilesFlown,0)) as Total_Miles_Flown_Attendents" &
            '            " From TAttendants as TA  left join TAttendantFlights as TAF on TA.intAttendantID = TAF.intAttendantID" &
            '            " left join TFlights as TF on TF.intFlightID = TAF.intFlightID" &
            '            " Group by TA.strFirstName, TA.strLastName"

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand("avgMilesFlownAttendents", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            drSourceTable = cmdSelect.ExecuteReader

            lstResultSetAttendents.Items.Add("Roster of All Flight Attendents")
            lstResultSetAttendents.Items.Add("=============================")

            While drSourceTable.Read()

                lstResultSetAttendents.Items.Add(" ")
                lstResultSetAttendents.Items.Add("=====================================")

                lstResultSetAttendents.Items.Add("Attendent Name: " & vbTab & drSourceTable("Name"))
                lstResultSetAttendents.Items.Add("Total Miles Flown: " & vbTab & drSourceTable("Total_Miles_Flown_Attendents"))

            End While


            ' Clean up
            drSourceTable.Close()

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