Public Class CustomerSignup
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

    Private Sub CustomerSignup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtState As DataTable = New DataTable            ' this is the table we will load from our reader

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
            strSelect = "SELECT * FROM TStates"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtState.Load(drSourceTable)

            'loads the result set into the cbo field 
            'the index of what is being showed to the user and what the programmer user to do other things with the user input

            CboState.ValueMember = "intStateID"

            'is what is being displayed in the combo box for the user to interact with
            CboState.DisplayMember = "strState"

            'fills the combo box with data passed into it
            CboState.DataSource = dtState


            ' Clean up
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
        Dim strAddress As String
        Dim strCity As String
        Dim intState As Integer
        Dim strZip As String
        Dim strEmail As String
        Dim strPhoneNumber As String
        Dim strLogin As String
        Dim strPassword As String
        Dim intPKID As Integer

        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim cmdInsert As OleDb.OleDbCommand ' this will be used for our insert statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim intNextPrimaryKey As Integer 'this will get the next advialble primapy key number for the new incert
        Dim intRowsaffected As Integer   ' how many rows were affected from the sql querry
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        Dim cmdAddCustomer As New OleDb.OleDbCommand()


        Try
            'enter main valadation method to ensure all fields are valadated

            If MainValidation() = True Then

                'enter the data into its respected variables
                strFirstName = txtFirstName.Text
                strLastNAme = txtLastName.Text
                strAddress = txtAddress.Text
                strCity = txtCity.Text
                strZip = txtZip.Text
                strPhoneNumber = txtPhoneNumber.Text
                strEmail = txtEmail.Text
                intState = CboState.SelectedValue
                strLogin = txtLogin.Text
                strPassword = txtPassword.Text


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
                'strSelect = "SELECT MAX(intPassengerID) + 1 AS intNextPrimaryKey " & " From TPassengers"

                ''MessageBox.Show(strSelect)

                '' Retrieve all the records 
                'cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                'drSourceTable = cmdSelect.ExecuteReader

                ''read tesult with highest ID
                'drSourceTable.Read()

                ''checking to see if the database is empty
                'If drSourceTable.IsDBNull(0) = True Then

                '    'if so then start at one
                '    intNextPrimaryKey = 1
                'Else

                '    'get the next highest value for the primary keys
                '    intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                'End If

                'create the insert statement (must match the order in the databases)

                'strInsert = "INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail)" &
                '" VALUES (" & intNextPrimaryKey & ",'" & strFirstName & "','" & strLastNAme & "','" & strAddress & "','" & strCity & "'," & intState & ",'" & strZip & "','" & strPhoneNumber & "','" & strEmail & "')"


                'uses the sql string and the connection object to talk with the database
                cmdAddCustomer.CommandText = "EXECUTE uspAddCustomer '" & intPKID & "','" & strFirstName & "','" & strLastNAme & "','" & strAddress & "','" & strCity & "','" & intState & "','" & strZip & "','" & strPhoneNumber & "','" & strEmail & "','" & strLogin & "','" & strPassword & "'"
                cmdAddCustomer.CommandType = CommandType.StoredProcedure

                'call stored proc which will insert the record
                cmdAddCustomer = New OleDb.OleDbCommand(cmdAddCustomer.CommandText, m_conAdministrator)

                'excute query to inseert data
                intRowsaffected = cmdAddCustomer.ExecuteNonQuery()


                'if not zero the insert was successful
                If intRowsaffected > 0 Then
                    MessageBox.Show("You was successfully added to the system, Please exit and sign in!")
                Else
                    MessageBox.Show("Sign in failed")
                End If


                'clears the form so another person can be enter into it
                txtFirstName.Clear()
                txtLastName.Clear()
                txtAddress.Clear()
                txtCity.Clear()
                txtZip.Clear()
                txtPhoneNumber.Clear()
                txtEmail.Clear()
                txtLogin.Clear()
                txtPassword.Clear()

                'brings the usere back to the top of the form
                txtFirstName.Focus()

                ' Clean up
                'drSourceTable.Close()

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