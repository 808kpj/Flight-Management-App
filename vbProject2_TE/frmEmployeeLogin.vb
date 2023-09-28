Public Class frmEmployeeLogin
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim cmdSelect As New OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim cmdPWSelect As New OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim cmdSelectEmployeeID As New OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim cmdSelectPilotID As New OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim cmdSelectAttendentID As New OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtPassengers As DataTable = New DataTable            ' this is the table we will load from our reader
        Dim dtStates As DataTable = New DataTable            ' this is the table we will load from our reader
        Dim strUserID As String
        Dim strRoleSelection As String
        Dim strUserPw As String
        Dim strRole As String
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
            If txtEmployeeID.Text = String.Empty Then
                MessageBox.Show("Please enter your employee ID")

                If txtEmployeePassword.Text = String.Empty Then
                    MessageBox.Show("Please enter your employee password")

                    Exit Try
                End If

            Else
                'grabs what is in the text fields
                strUserID = txtEmployeeID.Text
                strUserPw = txtEmployeePassword.Text

                'uses the sql string and the connection object to talk with the database
                cmdSelect.CommandText = "EXECUTE EmployeeLogin '" & strUserID & "'"
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
                    cmdPWSelect.CommandText = "EXECUTE EmployeePasswprdLogin '" & strUserPw & "'"
                    cmdPWSelect.CommandType = CommandType.StoredProcedure

                    'call stored proc which will insert the record
                    cmdPWSelect = New OleDb.OleDbCommand(cmdPWSelect.CommandText, m_conAdministrator)

                    'save the number of rows affected to an variable
                    intRowsAffected = cmdPWSelect.ExecuteNonQuery()

                    'did it find the password?
                    If intRowsAffected = -1 Then

                        'yes it worked

                        'uses the sql string and the connection object to talk with the database
                        cmdSelectEmployeeID.CommandText = "EXECUTE EmployeeID '" & strUserID & "'" & "," & "'" & strUserPw & "'"
                        cmdSelectEmployeeID.CommandType = CommandType.StoredProcedure


                        'call stored proc which will insert the record
                        cmdSelectEmployeeID = New OleDb.OleDbCommand(cmdSelectEmployeeID.CommandText, m_conAdministrator)

                        'drSourceTable = cmdSelectEmployeeID.ExecuteReader
                        'strRole.Load(drSourceTable)
                        strRole = cmdSelectEmployeeID.ExecuteScalar()


                        Select Case strRole.ToLower
                            Case = "admin"
                                'take them to the admin page
                                Dim frmAdminPage As New frmAdminPage

                                frmAdminPage.ShowDialog()

                            Case = "pilot"

                                'uses the sql string and the connection object to talk with the database
                                cmdSelectPilotID.CommandText = "EXECUTE PilotEmployeeID '" & strUserID & "'" & "," & "'" & strUserPw & "'"
                                cmdSelectPilotID.CommandType = CommandType.StoredProcedure

                                'call stored proc which will insert the record
                                cmdSelectPilotID = New OleDb.OleDbCommand(cmdSelectPilotID.CommandText, m_conAdministrator)

                                'returns the Pilot ID to sign in
                                intPilotID = cmdSelectPilotID.ExecuteScalar()

                                'goin to the the pilot main menu
                                Dim frmPilotsMainMenu As New frmPilotsMainMenu

                                frmPilotsMainMenu.ShowDialog()
                            Case = "attendant"

                                'uses the sql string and the connection object to talk with the database
                                cmdSelectAttendentID.CommandText = "EXECUTE AttendentEmployeeID '" & strUserID & "'" & "," & "'" & strUserPw & "'"
                                cmdSelectAttendentID.CommandType = CommandType.StoredProcedure

                                'call stored proc which will insert the record
                                cmdSelectAttendentID = New OleDb.OleDbCommand(cmdSelectAttendentID.CommandText, m_conAdministrator)

                                'returns the Attendent ID to sign in
                                intAttendentID = cmdSelectAttendentID.ExecuteScalar()

                                'goin to the the attendent main menu
                                Dim frmAttendentsMainMenu As New frmAttendentsMainMenu

                                frmAttendentsMainMenu.ShowDialog()

                            Case Else
                                MessageBox.Show("Something went wrong in the select statement")
                        End Select



                        'intPilotID = drSourceTable("")

                        'opens up the customer main menu
                        'frmCustomerMainMenu.ShowDialog()


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