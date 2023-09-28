Public Class frmAdminAddAttendent
    Public Function MainValidation() As Boolean
        If ValidateFirstName() Then
            If ValidateLastName() Then
                If ValidateEmployeeID() Then
                    If ValidateHireDate() Then
                        If ValidateTerminationDate() Then
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
    End Function

    Public Function ValidateLogin() As Boolean
        If txtLog_in.Text = String.Empty Then
            MessageBox.Show("Please enter the login ID")
            txtLog_in.Focus()
            txtLog_in.BackColor = Color.Yellow
            Return False
        Else
            txtLog_in.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidatePassword() As Boolean
        If txtAttenPassword.Text = String.Empty Then
            MessageBox.Show("Please enter a Passoword")
            txtAttenPassword.Focus()
            txtAttenPassword.BackColor = Color.Yellow
            Return False
        Else
            txtAttenPassword.BackColor = Color.White
            Return True
        End If
    End Function
    Public Function ValidateEmployeeID() As Boolean
        If txtEmployeeID.Text = String.Empty Then
            MessageBox.Show("Please enter the Employee ID")
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

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'variables to hold the updated information

        Dim strSelect As String
        Dim strInsert As String
        Dim strFirstName As String
        Dim strLastNAme As String
        Dim strEmployeeID As String
        Dim dtmDateOfHire As Date
        Dim dtmDateOfTermination As Date
        Dim strEmployeeLoginID As String
        Dim strEmployeePassword As String
        Dim strEmployeeRole As String
        Dim intCurentMAxPrimaryKey As Integer 'this will get the next advialble primapy key number for the new incert
        Dim intRowsaffected As Integer   ' how many rows were affected from the sql querry
        Dim intPKID As Integer

        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim cmdInsert As OleDb.OleDbCommand ' this will be used for our insert statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim intNextPrimaryKey As Integer 'this will get the next advialble primapy key number for the new incert
        Dim intRowsEmpaffected As Integer   ' how many rows were affected from the sql querry
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim cmdAddEmployee As New OleDb.OleDbCommand()

        Try
            'enter main valadation method to ensure all fields are valadated

            If MainValidation() = True Then

                'enter the data into its respected variables
                strFirstName = txtFirstName.Text
                strLastNAme = txtLastName.Text
                strEmployeeID = txtEmployeeID.Text
                dtmDateOfHire = dtmDateHire.Text
                dtmDateOfTermination = dtmDateTermination.Text
                strEmployeeLoginID = txtLog_in.Text
                strEmployeePassword = txtAttenPassword.Text
                strEmployeeRole = "Attendant"


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
                strSelect = "SELECT MAX(intAttendantID) + 1 AS intNextPrimaryKey " & " From TAttendants"

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

                strInsert = "INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)" &
                    " VALUES (" & intNextPrimaryKey & ",'" & strFirstName & "','" & strLastNAme & "','" & strEmployeeID & "','" & dtmDateOfHire & "','" & dtmDateOfTermination & "'" & ")"


                'uses the sql string and the connection object to talk with the database
                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


                ''excute query to inseert data
                intRowsaffected = cmdInsert.ExecuteNonQuery()


                ''if not zero the insert was successful
                'If intRowsaffected > 0 Then
                '    MessageBox.Show("You successfully added the flight attendent in system!")
                'End If

                ' Clean up
                drSourceTable.Close()

                'Get the new highest primary key for the attendent table to be used in the employee stored procudure +

                ' Build the select statement using PK from name selected
                strSelect = "SELECT MAX(intAttendantID) AS intCurentMAxPrimaryKey " & " From TAttendants"

                'MessageBox.Show(strSelect)

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                'read result with highest ID
                drSourceTable.Read()

                'checking to see if the database is empty
                If drSourceTable.IsDBNull(0) = True Then

                    'if so then start at one
                    intCurentMAxPrimaryKey = 1
                Else

                    'get the next highest value for the primary keys
                    intCurentMAxPrimaryKey = CInt(drSourceTable("intCurentMAxPrimaryKey"))

                End If


                'uses the sql string and the connection object to talk with the database
                cmdAddEmployee.CommandText = "EXECUTE AddAttendantEmployee '" & intPKID & "','" & strEmployeeLoginID & "','" & strEmployeePassword & "','" & strEmployeeRole & "','" & intCurentMAxPrimaryKey & "'"
                cmdAddEmployee.CommandType = CommandType.StoredProcedure

                'call stored proc which will insert the record
                cmdAddEmployee = New OleDb.OleDbCommand(cmdAddEmployee.CommandText, m_conAdministrator)

                'excute query to inseert data
                intRowsEmpaffected = cmdAddEmployee.ExecuteNonQuery()

                'if not zero the insert was successful
                If intRowsEmpaffected > 0 Then
                    MessageBox.Show("Your successfully added to the employee table!")
                End If

                'clears the form so another person can be enter into it
                txtFirstName.Clear()
                txtLastName.Clear()
                txtEmployeeID.Clear()

                'brings the usere back to the top of the form
                txtFirstName.Focus()


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