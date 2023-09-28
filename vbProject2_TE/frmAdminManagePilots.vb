Public Class frmAdminManagePilots
    Public Function MainValidation() As Boolean
        If ValidateFirstName() Then
            If ValidateLastName() Then
                If ValidateEmployeeID() Then
                    If ValidateHireDate() Then
                        If ValidateTerminationDate() Then
                            If ValidateLicenseDate() Then
                                If ValidatePilotRole() Then
                                    If ValidateLogin() Then
                                        If ValidatePassword() Then
                                            Return True
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

    Public Function ValidateLogin() As Boolean
        If txtLog_in.Text = String.Empty Then
            MessageBox.Show("Please enter your id")
            txtLog_in.Focus()
            txtLog_in.BackColor = Color.Yellow
            Return False
        Else
            txtLog_in.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidatePassword() As Boolean
        If txt_Password.Text = String.Empty Then
            MessageBox.Show("Please enter your id")
            txt_Password.Focus()
            txt_Password.BackColor = Color.Yellow
            Return False
        Else
            txt_Password.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateEmployeeID() As Boolean
        If txtEmployeeID.Text = String.Empty Then
            MessageBox.Show("Please enter your first name")
            txtEmployeeID.Focus()
            txtEmployeeID.BackColor = Color.Yellow
            Return False
        Else
            txtEmployeeID.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateHireDate() As Boolean
        If dtmDateHire.Text = String.Empty Then
            MessageBox.Show("Please enter the date of hire")
            dtmDateHire.Focus()
            dtmDateHire.BackColor = Color.Yellow
            Return False
        Else
            dtmDateHire.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateTerminationDate() As Boolean
        If dtmDateTermination.Text = String.Empty Then
            MessageBox.Show("Please enter the date of termination")
            dtmDateTermination.Focus()
            dtmDateTermination.BackColor = Color.Yellow
            Return False
        Else
            dtmDateTermination.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateLicenseDate() As Boolean
        If dtmDateLicense.Text = String.Empty Then
            MessageBox.Show("Please enter the date of termination")
            dtmDateLicense.Focus()
            dtmDateLicense.BackColor = Color.Yellow
            Return False
        Else
            dtmDateLicense.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidatePilotRole() As Boolean
        If txtEmployeeID.Text = String.Empty Then
            MessageBox.Show("Please enter the date of termination")
            txtEmployeeID.Focus()
            txtEmployeeID.BackColor = Color.Yellow
            Return False
        Else
            txtEmployeeID.BackColor = Color.White
            Return True
        End If
    End Function
    Public Function ValidateFirstName() As Boolean
        If txtFirstName.Text = String.Empty Then
            txtFirstName.Focus()
            txtFirstName.BackColor = Color.Yellow
            MessageBox.Show("Please enter your first name")
            Return False
        ElseIf IsNumeric(txtFirstName.Text) Then
            txtFirstName.Focus()
            txtFirstName.BackColor = Color.Yellow
            MessageBox.Show("Your first name can not include numbers")
            Return False
        Else
            txtFirstName.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateLastName() As Boolean
        If txtLastName.Text = String.Empty Then
            txtLastName.Focus()
            txtLastName.BackColor = Color.Yellow
            MessageBox.Show("Please enter your last name")
            Return False
        ElseIf IsNumeric(txtLastName.Text) Then
            txtLastName.Focus()
            txtLastName.BackColor = Color.Yellow
            MessageBox.Show("Your last name can not include numbers")
            Return False
        Else
            txtLastName.BackColor = Color.White
            Return True
        End If
    End Function

    Private Sub frmAdminManagePilots_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dtPilotRole As DataTable = New DataTable ' this is the table we will load from our reader


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
            strSelect = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtPilotRole.Load(drSourceTable)

            'the index of what is being showed to the user and what the programmer user to do other things with the user input
            cboPilotRoles.ValueMember = "intPilotRoleID"
            'is what is being displayed in the combo box for the user to interact with
            cboPilotRoles.DisplayMember = "strPilotRole"
            'fills the combo box with data passed into it
            cboPilotRoles.DataSource = dtPilotRole

            'Clean up
            drSourceTable.Close()

            ' Build the select statement using PK from name selected
            strSelect = "SELECT strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfLicense, dtmDateOfTermination, intPilotRoleID" &
                        " FROM TPilots Where intPilotID = " & intPilotID

            MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            'display the data into the respected fields
            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtEmployeeID.Text = drSourceTable("strEmployeeID")
            dtmDateHire.Text = drSourceTable("dtmDateOfHire")
            dtmDateLicense.Text = drSourceTable("dtmDateOfLicense")
            dtmDateTermination.Text = drSourceTable("dtmDateOfTermination")
            cboPilotRoles.SelectedValue = drSourceTable("intPilotRoleID")

            'Clean up
            drSourceTable.Close()



            'select statement to populate the login and password boxes
            strSelect = "SELECT strEmployeeLoginID, strEmployeePassword" &
                        " FROM TEmployees Where intPilotID = " & intPilotID

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()


            'display the data into the respected fields
            txtLog_in.Text = drSourceTable("strEmployeeLoginID")
            txt_Password.Text = drSourceTable("strEmployeePassword")

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
        'variables to hold the updated information

        Dim strSelect As String
        Dim strInsert As String
        Dim strFirstName As String
        Dim strLastNAme As String
        Dim strEmployeeID As String
        Dim dtmDateOfHire As Date
        Dim dtmDateOfTermination As Date
        Dim dtmDateOfLicense As Date
        Dim intPilotRoleID As Integer


        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim cmdInsert As OleDb.OleDbCommand ' this will be used for our insert statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim intNextPrimaryKey As Integer 'this will get the next advialble primapy key number for the new incert
        Dim intRowsaffected As Integer   ' how many rows were affected from the sql querry
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader


        Try
            'enter main valadation method to ensure all fields are valadated

            If MainValidation() = True Then

                'enter the data into its respected variables
                strFirstName = txtFirstName.Text
                strLastNAme = txtLastName.Text
                strEmployeeID = txtEmployeeID.Text
                dtmDateOfHire = dtmDateHire.Text
                dtmDateOfTermination = dtmDateTermination.Text
                dtmDateOfLicense = dtmDateLicense.Text
                intPilotRoleID = cboPilotRoles.SelectedValue



                ' open the database if it is not open
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
                strSelect = "SELECT MAX(intPilotID) + 1 AS intNextPrimaryKey " & " From TPilots"

                'MessageBox.Show(strSelect)

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                'read result with highest ID
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

                strInsert = "INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)" &
                    " VALUES (" & intNextPrimaryKey & ",'" & strFirstName & "','" & strLastNAme & "','" & strEmployeeID & "','" & dtmDateOfHire & "'," & dtmDateOfTermination & ",'" & dtmDateOfLicense & "'," & intPilotRoleID & ")"


                'uses the sql string and the connection object to talk with the database
                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


                'excute query to inseert data
                intRowsaffected = cmdInsert.ExecuteNonQuery()

                'if not zero the insert was successful
                If intRowsaffected > 0 Then
                    MessageBox.Show("You successfully added the pilot in system!")
                End If


                'clears the form so another person can be enter into it
                txtFirstName.Clear()
                txtLastName.Clear()
                txtEmployeeID.Clear()

                'brings the usere back to the top of the form
                txtFirstName.Focus()

                ' Clean up
                drSourceTable.Close()

                'close database connection
                CloseDatabaseConnection()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class