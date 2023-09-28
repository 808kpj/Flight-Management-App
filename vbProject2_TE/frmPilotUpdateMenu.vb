Public Class frmPilotUpdateMenu
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
            MessageBox.Show("Please enter your password")
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

    Private Sub frmPilotUpdateMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'creating variables
        Dim strSelect As String
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim dtmDateOfHire As Date
        Dim dtmDateOfTermination As Date
        Dim dtmDateOfLicense As Date
        Dim intPilotRoleID As Integer
        Dim intRowsAffected As Integer
        Dim intRowAffected As Integer
        Dim txtLogin As String
        Dim txtPassword As String

        'the command statement
        Dim cmdUpdate As OleDb.OleDbCommand
        Dim cmdStoredUpdate As New OleDb.OleDbCommand

        Try
            'ensures the fields are correct before updating the database
            If MainValidation() = True Then

                ' open database this is in module
                If OpenDatabaseConnectionSQLServer() = False Then

                    ' No, warn the user ...
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' and close the form/application
                    Me.Close()

                End If

                'declaring the variables for the update statement

                strFirstName = txtFirstName.Text
                strLastName = txtLastName.Text
                strEmployeeID = txtEmployeeID.Text
                dtmDateOfHire = dtmDateHire.Text
                dtmDateOfTermination = dtmDateTermination.Text
                dtmDateOfLicense = dtmDateLicense.Text
                intPilotRoleID = cboPilotRoles.SelectedValue
                txtLogin = txtLog_in.Text
                txtPassword = txt_Password.Text



                ' Build the select statement using PK from name selected
                strSelect = "Update TPilots Set " &
                        "strFirstName = '" & strFirstName & "', " &
                        "strLastName = '" & strLastName & "', " &
                        "strEmployeeID = '" & strEmployeeID & "', " &
                        "dtmDateofHire = '" & dtmDateOfHire & "', " &
                        "dtmDateofTermination = '" & dtmDateOfTermination & "', " &
                        "dtmDateofLicense = '" & dtmDateOfLicense & "', " &
                        "intPilotRoleID = " & intPilotRoleID &
                        " Where intPilotID = " & intPilotID.ToString

                'show the update string for viewing confermation
                MessageBox.Show(strSelect)


                'make the connection
                cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                ' IUpdate the row with execute the statement
                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                'update for the login and password
                cmdStoredUpdate.CommandText = "EXECUTE uspUpdateEmployeeLogin_Password '" & txtLogin & "','" & txtPassword & "','" & intPilotID & "'"
                cmdStoredUpdate.CommandType = CommandType.StoredProcedure

                'call stored proc which will insert the record
                cmdStoredUpdate = New OleDb.OleDbCommand(cmdStoredUpdate.CommandText, m_conAdministrator)

                ' IUpdate the row with execute the statement
                intRowAffected = cmdStoredUpdate.ExecuteNonQuery()

                ' have to let the user know what happened 
                If intRowAffected = 1 Then
                    MessageBox.Show("Update successful")
                Else
                    MessageBox.Show("Update failed")
                End If

                ' close the database connection
                CloseDatabaseConnection()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class