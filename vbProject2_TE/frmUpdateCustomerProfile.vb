Public Class frmUpdateCustomerProfile
    Public Function MainValidation() As Boolean
        If ValidateFirstName() Then
            If ValidateLastName() Then
                If ValidateAddress() Then
                    If ValidiateCity() Then
                        If ValidateState() Then
                            If ValidateZip() Then
                                If ValidatephoneNumber() Then
                                    If ValidateEmail() Then
                                        If ValidateLogin() Then
                                            If ValidatePasword() Then
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
        Else
            Return False
        End If
    End Function

    Public Function ValidateBirthdate() As Boolean
        If txtLogin.Text = String.Empty Then
            txtLogin.Focus()
            txtLogin.BackColor = Color.Yellow
            MessageBox.Show("Please enter your Login in")
            Return False
        Else
            txtLogin.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateLogin() As Boolean
        If txtLogin.Text = String.Empty Then
            txtLogin.Focus()
            txtLogin.BackColor = Color.Yellow
            MessageBox.Show("Please enter your Login in")
            Return False
        Else
            txtLogin.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidatePasword() As Boolean
        If txtPassword.Text = String.Empty Then
            txtPassword.Focus()
            txtPassword.BackColor = Color.Yellow
            MessageBox.Show("Please enter your password")
            Return False
        Else
            txtPassword.BackColor = Color.White
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

    Public Function ValidateAddress() As Boolean
        If txtAddress.Text = String.Empty Then
            txtAddress.Focus()
            txtAddress.BackColor = Color.Yellow
            MessageBox.Show("Please enter your address")
            Return False
        Else
            txtAddress.BackColor = Color.White
            Return True
        End If
    End Function


    Public Function ValidiateCity() As Boolean
        If txtCity.Text = String.Empty Then
            txtCity.Focus()
            txtCity.BackColor = Color.Yellow
            MessageBox.Show("Please enter a city")
            Return False

        ElseIf IsNumeric(txtCity.Text) Then
            txtCity.Focus()
            txtCity.BackColor = Color.Yellow
            MessageBox.Show("Please enter a valid city")
            Return False

        Else
            txtCity.BackColor = Color.White
            Return True
        End If
    End Function


    Public Function ValidateState() As Boolean
        If CboState.Text = String.Empty Then
            CboState.Focus()
            CboState.BackColor = Color.Yellow
            MessageBox.Show("Please select a State")
            Return False

        ElseIf IsNumeric(CboState.Text) Then
            CboState.Focus()
            CboState.BackColor = Color.Yellow
            MessageBox.Show("Please enter a valid State")
            Return False
        Else
            CboState.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateZip() As Boolean
        If txtZip.Text = String.Empty Then
            txtZip.Focus()
            txtZip.BackColor = Color.Yellow
            MessageBox.Show("Please enter your ZIP code")
            Return False
        Else
            txtZip.BackColor = Color.White
            Return True
        End If
    End Function


    Public Function ValidatephoneNumber() As Boolean
        If txtPhoneNumber.Text = String.Empty Then
            txtPhoneNumber.Focus()
            txtPhoneNumber.BackColor = Color.Yellow
            MessageBox.Show("Please enter your Phone Number")
            Return False
        Else
            txtPhoneNumber.BackColor = Color.White
            Return True
        End If
    End Function

    Public Function ValidateEmail() As Boolean
        'creating a variable 
        Dim strEmailValid As String
        Dim intAtSymbleChecker As Integer

        'declaring varible
        strEmailValid = txtEmail.Text.Trim.ToLower
        intAtSymbleChecker = 0

        For Each letter As Char In strEmailValid
            If letter = "@" Then
                intAtSymbleChecker += 1
            End If
        Next



        If txtEmail.Text = String.Empty Then

            txtEmail.Focus()
            txtEmail.BackColor = Color.Yellow
            MessageBox.Show("Please enter your Email address")
            Return False

        ElseIf intAtSymbleChecker = 0 Then
            txtEmail.Focus()
            txtEmail.BackColor = Color.Yellow
            MessageBox.Show("Please ensure you have an @ symble in your Email address")
            Return False

        Else
            txtEmail.BackColor = Color.White
            Return True
        End If
    End Function

    Private Sub frmUpdateCustomerProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dtStates As DataTable = New DataTable ' this is the table we will load from our reader


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
            strSelect = "SELECT intStateID, strState FROM TStates"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtStates.Load(drSourceTable)

            'the index of what is being showed to the user and what the programmer user to do other things with the user input
            CboState.ValueMember = "intStateID"
            'is what is being displayed in the combo box for the user to interact with
            CboState.DisplayMember = "strState"
            'fills the combo box with data passed into it
            CboState.DataSource = dtStates



            ' Build the select statement using PK from name selected
            strSelect = "SELECT strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strPassengerLoginID, strPassengerPassword " & " FROM TPassengers  Where intPassengerID = " & intCustomerID
            MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            'display the data into the respected fields
            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtAddress.Text = drSourceTable("strAddress")
            txtCity.Text = drSourceTable("strCity")
            CboState.SelectedValue = drSourceTable("intStateID")
            txtPhoneNumber.Text = drSourceTable("strPhoneNumber")
            txtZip.Text = drSourceTable("strZip")
            txtEmail.Text = drSourceTable("strEmail")
            txtLogin.Text = drSourceTable("strPassengerLoginID")
            txtPassword.Text = drSourceTable("strPassengerPassword")


            'Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'creating variables
        Dim strSelect As String
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim intState As Integer
        Dim strZip As String
        Dim strPhoneNumber As String
        Dim strEmail As String
        Dim intRowsAffected As Integer
        Dim strLogin As String
        Dim strPassword As String
        Dim intPKID As Integer

        'the command statement
        Dim cmdUpdate As New OleDb.OleDbCommand()

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
                strAddress = txtAddress.Text
                strCity = txtCity.Text
                intState = CboState.SelectedValue
                strZip = txtZip.Text
                strPhoneNumber = txtPhoneNumber.Text
                strEmail = txtEmail.Text
                intPKID = intCustomerID
                strLogin = txtLogin.Text
                strPassword = txtPassword.Text



                ' Build the select statement using PK from name selected
                'strSelect = "Update TPassengers Set " &
                '        "strFirstName = '" & strFirstName & "', " &
                '        "strLastName = '" & strLastName & "', " &
                '        "strAddress = '" & strAddress & "', " &
                '        "strCity = '" & strCity & "', " &
                '        "intStateID = " & intState & ", " &
                '        "strZip = '" & strZip & "', " &
                '        "strPhoneNumber = '" & strPhoneNumber & "', " &
                '        "strEmail = '" & strEmail & "'" &
                '        "Where intPassengerID = " & intCustomerID.ToString

                'show the update string for viewing confermation
                'MessageBox.Show(strSelect)


                'uses the sql string and the connection object to talk with the database
                cmdUpdate.CommandText = "EXECUTE uspUpdateCustomer '" & intPKID & "','" & strFirstName & "','" & strLastName & "','" & strAddress & "','" & strCity & "','" & intState & "','" & strZip & "','" & strPhoneNumber & "','" & strEmail & "','" & strLogin & "','" & strPassword & "'"
                cmdUpdate.CommandType = CommandType.StoredProcedure

                'call stored proc which will insert the record
                cmdUpdate = New OleDb.OleDbCommand(cmdUpdate.CommandText, m_conAdministrator)

                ' IUpdate the row with execute the statement
                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                ' have to let the user know what happened 
                If intRowsAffected = 1 Then
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class