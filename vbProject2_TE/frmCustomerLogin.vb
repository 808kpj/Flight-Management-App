Public Class frmCustomerLogin
    'Public Sub frmCustomerLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim strSelect As String
    '    Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
    '    Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
    '    Dim dtPassengers As DataTable = New DataTable            ' this is the table we will load from our reader
    '    Dim dtStates As DataTable = New DataTable            ' this is the table we will load from our reader
    '    Try

    '        ' open the DB
    '        If OpenDatabaseConnectionSQLServer() = False Then

    '            ' No, warn the user ...
    '            MessageBox.Show(Me, "Database connection error." & vbNewLine &
    '                                "The application will now close.",
    '                                Me.Text + " Error",
    '                                MessageBoxButtons.OK, MessageBoxIcon.Error)

    '            ' and close the form/application
    '            Me.Close()

    '        End If

    '        ' Build the select statement
    '        strSelect = "SELECT intPassengerID, strFirstName + ' ' + strLastName as FullName  FROM TPassengers"

    '        ' Retrieve all the records 
    '        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
    '        drSourceTable = cmdSelect.ExecuteReader

    '        'loads the result set into the cbo field 
    '        dtPassengers.Load(drSourceTable)


    '        'the index of what is being showed to the user and what the programmer user to do other things with the user input

    '        cboPassenger.ValueMember = "intPassengerID"

    '        'is what is being displayed in the combo box for the user to interact with
    '        cboPassenger.DisplayMember = "FullName"

    '        'fills the combo box with data passed into it

    '        cboPassenger.DataSource = dtPassengers

    '        'selects the first item in the list by default
    '        If cboPassenger.Items.Count > 0 Then
    '            cboPassenger.SelectedIndex = 0
    '        End If

    '        'Clean up
    '        drSourceTable.Close()

    '        ' close the database connection
    '        CloseDatabaseConnection()

    '    Catch excError As Exception

    '        ' Log and display error message
    '        MessageBox.Show(excError.Message)

    '    End Try
    'End Sub

    Private Sub btnNewCustomer_Click(sender As Object, e As EventArgs) Handles btnNewCustomer.Click
        'creating form variable
        Dim frmCustomerSignup As New CustomerSignup

        'opens the form in its own instance
        frmCustomerSignup.ShowDialog()
    End Sub

    Public Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim cmdSelect As New OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim cmdPWSelect As New OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim cmdSelectCustomerID As New OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtPassengers As DataTable = New DataTable            ' this is the table we will load from our reader
        Dim dtStates As DataTable = New DataTable            ' this is the table we will load from our reader
        Dim strUserID As String
        Dim strUserPw As String
        Dim intRowsAffected As Integer
        Dim frmCustomerMainMenu As New frmCustomerMainMenu



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


        Try
            If txtCustomerID.Text = String.Empty Then
                MessageBox.Show("Please enter your user ID")

                If txtCustomerPassword.Text = String.Empty Then
                    MessageBox.Show("Please enter your user password")

                    Exit Try
                End If

            Else
                'grabs what is in the text fields
                strUserID = txtCustomerID.Text
                strUserPw = txtCustomerPassword.Text

                'uses the sql string and the connection object to talk with the database
                cmdSelect.CommandText = "EXECUTE CustomerLogin '" & strUserID & "'"
                cmdSelect.CommandType = CommandType.StoredProcedure

                'call stored proc which will insert the record
                cmdSelect = New OleDb.OleDbCommand(cmdSelect.CommandText, m_conAdministrator)

                'save the number of rows affected to an variable
                intRowsAffected = cmdSelect.ExecuteNonQuery()

                ' Did it work?
                If intRowsAffected = -1 Then

                    ' Yes, success if it equals -1
                    intRowsAffected = 0

                    'uses the sql string and the connection object to talk with the database
                    cmdPWSelect.CommandText = "EXECUTE CustomerLoginPAssword '" & strUserPw & "'"
                    cmdPWSelect.CommandType = CommandType.StoredProcedure

                    'call stored proc which will insert the record
                    cmdPWSelect = New OleDb.OleDbCommand(cmdPWSelect.CommandText, m_conAdministrator)

                    'save the number of rows affected to an variable
                    intRowsAffected = cmdPWSelect.ExecuteNonQuery()

                    'did it find the password?
                    If intRowsAffected = -1 Then

                        'yes it worked

                        'uses the sql string and the connection object to talk with the database
                        cmdSelectCustomerID.CommandText = "EXECUTE CustomerID '" & strUserID & "'" & "," & "'" & strUserPw & "'"
                        cmdSelectCustomerID.CommandType = CommandType.StoredProcedure


                        'call stored proc which will insert the record
                        cmdSelectCustomerID = New OleDb.OleDbCommand(cmdSelectCustomerID.CommandText, m_conAdministrator)

                        intCustomerID = cmdSelectCustomerID.ExecuteScalar()

                        'opens up the customer main menu
                        frmCustomerMainMenu.ShowDialog()


                    Else
                        MessageBox.Show("ID and/or Password are not Valid")
                    End If


                Else
                    MessageBox.Show("ID and/or Password are not Valid")

                End If


                ''saves the curent user ID to the customer variable
                'intCustomerID = cboPassenger.SelectedValue

                ''creating form variable
                'Dim frmCustomerMainMenu As New frmCustomerMainMenu

                ''opens the form in its own instance
                'frmCustomerMainMenu.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class