Public Class frmAdminAddFutureFlight
    Dim currentTime As Date


    Public Function MainValid()
        If ValidateFlightDate() Then
            If ValidateFlightNumber() Then
                If ValidateDateofDeparture() Then
                    If ValidateDateofLanding() Then
                        If ValidateToAirport() Then
                            If ValidateFromAirport() Then
                                If ValidateMilesFlown() Then
                                    If ValidatePlaneID() Then
                                        Return True
                                    Else
                                        Return False
                                    End If
                                End If
                            Else
                                    Return False
                            End If
                        Else
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function




    Public Function ValidateFlightDate()
        If dtmDateofFlight.Text = String.Empty Then
            dtmDateofFlight.Focus()
            dtmDateofFlight.BackColor = Color.Yellow
            MessageBox.Show("Please enter your flight date")
            Return False
        ElseIf dtmDateofFlight.Value < DateString Then
            dtmDateofFlight.Focus()
            dtmDateofFlight.BackColor = Color.Yellow
            MessageBox.Show("You can only pick days grather than today ")
            Return False
        Else
            dtmDateofFlight.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateDateofDeparture()
        If dtmDeparture.Text = String.Empty Then
            dtmDeparture.Focus()
            dtmDeparture.BackColor = Color.Yellow
            MessageBox.Show("Please enter your departure time")
            Return False
            'ElseIf dtmDeparture.Value < currentTime Then
            '    dtmDeparture.Focus()
            '    dtmDeparture.BackColor = Color.Yellow
            '    MessageBox.Show("You can only pick times grather than today ")
            '    Return False
        Else
            dtmDeparture.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateDateofLanding()
        If dtmLandingForm.Text = String.Empty Then
            dtmLandingForm.Focus()
            dtmLandingForm.BackColor = Color.Yellow
            MessageBox.Show("Please enter landing time ")
            Return False
            'ElseIf dtmLandingForm.Value < currentTime Then
            '    dtmLandingForm.Focus()
            '    dtmLandingForm.BackColor = Color.Yellow
            '    MessageBox.Show("You can only pick times grather than today ")
            '    Return False
        Else
            dtmLandingForm.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateToAirport()
        If cboToAirport.Text = String.Empty Then
            cboToAirport.Focus()
            cboToAirport.BackColor = Color.Yellow
            MessageBox.Show("Please select an to airport")
            Return False

        Else
            cboToAirport.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateFromAirport()
        If cboFromAirport.Text = String.Empty Then
            cboFromAirport.Focus()
            cboFromAirport.BackColor = Color.Yellow
            MessageBox.Show("Please select an from airport")
            Return False

        Else
            cboFromAirport.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateMilesFlown()
        If txtMilesFlown.Text = String.Empty Then
            txtMilesFlown.Focus()
            txtMilesFlown.BackColor = Color.Yellow
            MessageBox.Show("Please enter the miles flown")
            Return False

        ElseIf IsNumeric(txtMilesFlown.Text) = False Then
            txtMilesFlown.Focus()
            txtMilesFlown.BackColor = Color.Yellow
            MessageBox.Show("Please enter numbers only")
            Return False
        Else
            txtMilesFlown.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidatePlaneID()
        If cboPlaneID.Text = String.Empty Then
            cboPlaneID.Focus()
            cboPlaneID.BackColor = Color.Yellow
            MessageBox.Show("Please select an from airport")
            Return False

        Else
            cboPlaneID.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateFlightNumber()

        If txtFlightNumber.Text = String.Empty Then
            MessageBox.Show("Please enter the flight number")
            txtFlightNumber.Focus()
            txtFlightNumber.BackColor = Color.Yellow
            Return False

        ElseIf IsNumeric(txtFlightNumber.Text) = False Then
            MessageBox.Show("Please only enter numbers for the flight number")
            txtFlightNumber.Focus()
            txtFlightNumber.BackColor = Color.Yellow
            Return False

        Else
            txtFlightNumber.BackColor = Color.White
            Return True
        End If

    End Function


    Private Sub frmAdminAddFutureFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'creating variables
        Dim dtPlaneID As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dtToAirport As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dtAirport As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dtFromAirport As DataTable = New DataTable ' this is the table we will load from our reader
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement

        currentTime = TimeOfDay


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

            ' Build the select statement
            strSelect = "SELECT intPlaneID, strPlaneNumber FROM TPlanes"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtPlaneID.Load(drSourceTable)

            'the index of what is being showed to the user and what the programmer user to do other things with the user input
            cboPlaneID.ValueMember = "intPlaneID"
            'is what is being displayed in the combo box for the user to interact with
            cboPlaneID.DisplayMember = "strPlaneNumber"
            'fills the combo box with data passed into it
            cboPlaneID.DataSource = dtPlaneID

            'Clean up
            drSourceTable.Close()


            ' Build the select statement
            strSelect = "SELECT intAirportID, strAirportCity FROM TAirports"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtToAirport.Load(drSourceTable)

            'the index of what is being showed to the user and what the programmer user to do other things with the user input
            cboToAirport.ValueMember = "intAirportID"
            'is what is being displayed in the combo box for the user to interact with
            cboToAirport.DisplayMember = "strAirportCity"
            'fills the combo box with data passed into it
            cboToAirport.DataSource = dtToAirport

            'Clean up
            drSourceTable.Close()


            ' Build the select statement
            strSelect = "SELECT intAirportID, strAirportCity FROM TAirports"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtAirport.Load(drSourceTable)

            'the index of what is being showed to the user and what the programmer user to do other things with the user input
            cboFromAirport.ValueMember = "intAirportID"
            'is what is being displayed in the combo box for the user to interact with
            cboFromAirport.DisplayMember = "strAirportCity"
            'fills the combo box with data passed into it
            cboFromAirport.DataSource = dtAirport

            'Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'crating variables
        Dim cmdCommand As New OleDb.OleDbCommand ' this will be used for our Select statement
        Dim dtmFlightDate As Date
        Dim strFlightNumber As String
        Dim dtmDepature As Date
        Dim dtmLanding As Date
        Dim intToAirport As Integer
        Dim intFromAirport As Integer
        Dim intMilesFlown As String
        Dim intPlaneID As Integer
        Dim intPKID As Integer
        Dim intRowsaffected As Integer   ' how many rows were affected from the sql querry



        'declaring variables
        dtmFlightDate = dtmDateofFlight.Value
        strFlightNumber = txtFlightNumber.Text
        dtmDepature = dtmDeparture.Value
        dtmLanding = dtmLandingForm.Value
        intToAirport = cboToAirport.SelectedValue
        intFromAirport = cboFromAirport.SelectedValue
        intMilesFlown = txtMilesFlown.Text
        intPlaneID = cboPlaneID.SelectedValue

        Try

            'ensures the fields are correct before updating the database
            If MainValid() = True Then

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

                'call stored procudure to insert the future flight
                cmdCommand.CommandText = "EXECUTE uspAddFutureFlight '" & intPKID & "','" & dtmFlightDate & "','" & strFlightNumber & "','" & dtmDepature & "','" & dtmLanding & "','" & intFromAirport & "','" & intToAirport & "','" & intMilesFlown & "','" & intPlaneID & "'"
                cmdCommand.CommandType = CommandType.StoredProcedure

                'call stored proc which will insert the record
                cmdCommand = New OleDb.OleDbCommand(cmdCommand.CommandText, m_conAdministrator)

                'excute query to inseert data
                intRowsaffected = cmdCommand.ExecuteNonQuery()

                'if not zero the insert was successful
                If intRowsaffected > 0 Then
                    MessageBox.Show("Your flight was added!")
                Else
                    MessageBox.Show("Your flight was not added!")

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class