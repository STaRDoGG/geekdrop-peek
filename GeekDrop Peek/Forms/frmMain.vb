Imports Microsoft.Win32

Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' First things first, make sure the engine that makes this all work exists
        If FileIO.FileSystem.FileExists(strStringsExePath) = False Then
            ' Nope!
            ' Possibly the first time this has been run, so lets install Strings for them
            If MessageBox.Show("Welcome to " & strAppname & "." & Environment.NewLine & Environment.NewLine & "Let's get this party started by first installing the latest Engine required to make this all work." & Environment.NewLine & Environment.NewLine & "Click OK to begin.", "Have we met?", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
                Download_and_Unpack_Strings()
            End If
        Else
            ' Yep! Lets just display it's version then
            Get_Strings_Versions()
        End If

        If FileIO.FileSystem.FileExists(Application.StartupPath & "\NoShellExtension.dat") = False Then
            ' First check if user has already "installed" the advanced method (command-line only, no real shell extension).
            ' If not, then continue as usual; if yes, then skip it and continue to the normal command-line param handling.

            Try
                If Registry.ClassesRoot.OpenSubKey("*\shell\" & strAppname & "\command") IsNot Nothing Then
                    ' Shell extension key WAS found

                    ' Change button to "Uninstall"
                    Toggle_Install_State_Indicators(True, False)

                    ' And set the other label as well
                    Toggle_Call_Method_Labels(False)
                Else
                    ' Shell extension key WASN'T found either. Ath this point neither the ShellEx OR the Cline method was found, so we need to call the 'install' function.

                    ' Set the button to show the option to Install the app
                    Toggle_Install_State_Indicators(False, False)

                    ' Alert the user that the shell extension needs to be installed, which afterall, IS what the program is all about.
                    ' Call the ShellEx/CLine Installation
                    Calling_Method_Installation()
                End If
            Finally
                Registry.ClassesRoot.Close()
            End Try
        Else
            ' Since the command-line method was used (and found) just Change button to "Uninstall"
            Toggle_Install_State_Indicators(True, False)

            ' And set the other label as well
            Toggle_Call_Method_Labels(True)
        End If

        ' Check for a command-line param to our app
        If My.Application.CommandLineArgs.Count > 0 Then

            For Each argument As String In My.Application.CommandLineArgs
                If My.Computer.FileSystem.FileExists(argument) Then
                    ' It's a file and it's been passed via the Shell Extension (or command-line), so run it through Strings.exe.
                    Run_Strings(argument)
                    ' All done with processing it, now just open the resulting file in a text viewer.
                    Open_Strings_Result()
                    ' We're all done here! Let's GTFO!
                    Close_App()
                End If
            Next
        Else
            ' Show the app since it wasn't run via the Shell Extension
            lblTitle.Text = strAppname

            If Environment.Is64BitProcess = True Then
                ' If this app is running as 64 Bit, add that to the label. This is mainly just for informational purposes.
                lblTitle.Text += " x64"
            End If

            Me.Opacity = 100%
        End If

    End Sub

    Private Sub btnInstall_Uninstall_Click(sender As Object, e As EventArgs) Handles btnInstall_Uninstall.Click

        If btnInstall_Uninstall.Text.Contains("UNINSTALL") Then
            ' Uninstall

            Try
                ' Delete the RegKey(s)
                tsLabel.Text = "Removing Shell Extension Keys ..."

                Using key As RegistryKey = My.Computer.Registry.ClassesRoot.OpenSubKey("*\\shell", True)
                    key.DeleteSubKeyTree(strAppname)
                End Using

            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            Try

                If FileIO.FileSystem.FileExists(Application.StartupPath & "\NoShellExtension.dat") = True Then
                    ' Delete the NoShellExtension.dat file
                    tsLabel.Text = "Removing the 'No Shell Extension' file ..."
                    FileIO.FileSystem.DeleteFile(Application.StartupPath & "\NoShellExtension.dat")
                End If

                If FileIO.FileSystem.FileExists(strStringsExePath) = True Then
                    ' Finally, delete the Strings.exe file, for a complete uninstallation.
                    tsLabel.Text = "Removing the Engine ..."
                    FileIO.FileSystem.DeleteFile(strStringsExePath)
                End If

            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            ' Reset the button to show the option to Install the app.
            Toggle_Install_State_Indicators(False, True)
            Toggle_Call_Method_Labels(False, False)
            tsLabel.Text = ""

            ' Alert user all is done
            MessageBox.Show(strAppname & " has been completely removed from your system." _
                            & Environment.NewLine & Environment.NewLine & _
                            "If you'd like to re-install it, click the 'Install' button.", _
                            "You're free to leave.", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            ' Install
            Calling_Method_Installation()

            If FileIO.FileSystem.FileExists(strStringsExePath) = False Then

                lblState2.Text = "Not Installed"

                ' No Strings.exe found. Probably manually clicked the Button after doing an uninstall, so let's let them know we need to install it as well.
                If MessageBox.Show("We now need to download & install the Engine as well. Click OK to begin.", _
                                   "Just one more second, partner.", _
                                   MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK _
                Then
                    ' Get Strings.
                    Download_and_Unpack_Strings()
                    ' Show it's version
                    Get_Strings_Versions()
                End If
            End If

            ' Reset the button to show the option to Uninstall the app.
            Toggle_Install_State_Indicators(True, True)

            ' Select the correct instructions based on the type of calling method the user chose
            Dim strInstructions As String = String.Empty

            If lblCallviaMethod.Text.Contains("Direct") Then
                strInstructions = "call " & strAppname & ".exe with the full path to the file(s) you want to Peek into, as a parameter. If any path has spaces in it be sure to wrap it in quotes."
            Else
                strInstructions = "just right-click on any file, and then click '" & strAppname & "'."
            End If

            If MessageBox.Show(strAppname & " all setup and ready to rock!" _
                               & Environment.NewLine & Environment.NewLine & _
                               "From now on in order to use it, " & strInstructions _
                               & Environment.NewLine & Environment.NewLine & _
                               "If you ever want to uninstall it, just run this app again manually and click the Uninstall button." _
                               & Environment.NewLine & Environment.NewLine & _
                               "This app will now close once you click the OK button.", _
                               "You're good to go.", _
                               MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK _
            Then
                Close_App()
            End If

        End If

    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        ' Shows the "About" window
        frmAbout.ShowDialog()
    End Sub

    Private Sub tsLabel_Click(sender As Object, e As EventArgs) Handles tsLabel.Click
        ' If user clicks the label, confirm that it says there's a Strings upgrade available, then send to the download/install sub

        Try
            If tsLabel.Text.Contains("Newer Engine Available!") Then
                ' Delete the current one first, so we don't encounter an error unzipping the downloaded one
                FileIO.FileSystem.DeleteFile(strStringsExePath)
                ' Now just send to the usual download/install
                Download_and_Unpack_Strings()
            End If
        Catch ex As Exception
            MessageBox.Show("Problem removing the crusty old Engine, shouldn't be a big deal though, it probably still works just fine.", "Newer isn't always better.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.Print(ex.Message)
        End Try

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close_App()
    End Sub

    Private Sub llGD_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llGD.LinkClicked
        NavigateToGd()
    End Sub

    Private Sub picLogo_MouseDown(sender As Object, e As MouseEventArgs) Handles picLogo.MouseDown
        ' For the form moving code
        GetMouseOffset(e)
    End Sub

    Private Sub picLogo_MouseMove(sender As Object, e As MouseEventArgs) Handles picLogo.MouseMove
        ' For the form moving code. Allows moving the form via dragging the logo image
        Move_Form(e, Me)
    End Sub

    Private Sub Toggle_Install_State_Indicators(bInstalled As Boolean, bIncludeStringsStateLabel As Boolean)
        ' Provides a single place to toggle all Strings.exe installed/uninstalled indicators
        ' bIncludeStringsStateLabel can be set to False to JUST change the Buttons and not the Strings Installed State label.

        If bInstalled = True Then
            ' Set all indicators to Installed
            With btnInstall_Uninstall
                .Image = My.Resources.arrow_red
                .Text = "UNINSTALL " & strAppname.ToUpper
            End With

            If bIncludeStringsStateLabel = True Then lblState2.Text = "Installed"
        Else
            ' Set all indicators to Not Installed
            With btnInstall_Uninstall
                .Image = My.Resources.arrow
                .Text = "INSTALL " & strAppname.ToUpper
            End With

            If bIncludeStringsStateLabel = True Then lblState2.Text = "Not Installed"
        End If

    End Sub

    Private Sub Toggle_Call_Method_Labels(bCommandLine As Boolean, Optional bVisible As Boolean = True)
        ' Sub toggles the labels that indicate whether they are visible or not, & if so, the detected method of calling GD Peek to do it's business.
        ' If bVisible is set to False, then they are set not visible and the bCommandLine value is ignored, so it doesn't matter whethers it's called as True or False.

        If bVisible = False Then
            ' Hide the labels
            lblCallvia.Visible = False
            lblCallviaMethod.Visible = False
        Else
            ' Show the labels
            lblCallvia.Visible = True
            lblCallviaMethod.Visible = True

            ' Set the label to display the detected calling method
            If bCommandLine = True Then
                lblCallviaMethod.Text = "Direct Command-Line"
            Else
                lblCallviaMethod.Text = "Windows' Shell Extension"
            End If
        End If

    End Sub

    Private Sub Calling_Method_Installation()

        Dim result As DialogResult = MessageBox.Show("Looks like you don't have the Shell Extension installed on your system yet." _
                                     & Environment.NewLine & Environment.NewLine & _
                                     "Since having that is the ENTIRE point of this app, let's get that installed for you right now." _
                                     & Environment.NewLine & Environment.NewLine & _
                                     "Here you have 2 options:" _
                                     & Environment.NewLine & Environment.NewLine & _
                                     "1). Install as usual. Installs a '" & strAppname & "' item in your Windows Context-Menu." _
                                     & Environment.NewLine & _
                                     "(Click 'Yes') (Recommended)" _
                                     & Environment.NewLine & Environment.NewLine & _
                                     "2). Don't install the Windows Shell Extension and call " & strAppname & " entirely via the command-line yourself. This is an advanced feature that requires you to know what you're doing, or odd things can happen." _
                                     & Environment.NewLine & _
                                     "(Click 'No')", _
                                     "Well, this is awkward.", _
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Installing the default way, of a normal shell extension.
            tsLabel.Text = "Installing Shell Extension Keys ..."
            Toggle_Call_Method_Labels(False, True)

            ' Install the Shell Extension (context-menu) regkey
            My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\*\shell\" & strAppname & "\command", "", """" & Application.ExecutablePath & """" & " ""%1""")

        ElseIf result = DialogResult.No Then
            ' User chose to use GD Peek via command-line only, so let's create a file in the same folder for checking upon app startup. This is basically a "flag".
            tsLabel.Text = "Creating the 'No Shell Extension' file ..."
            Toggle_Call_Method_Labels(True, True)

            System.IO.File.Create(Application.StartupPath & "\NoShellExtension.dat")
        Else
            ' User clicked Cancel
            Toggle_Call_Method_Labels(True, False)
            Close_App()
        End If

        tsLabel.Text = ""

        ' Reset the button to show the option to uninstall it
        Toggle_Install_State_Indicators(True, False)

    End Sub

End Class
