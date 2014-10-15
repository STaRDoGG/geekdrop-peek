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

        Try
            If Registry.ClassesRoot.OpenSubKey("*\shell\" & strAppname & "\command") IsNot Nothing Then
                ' Shell extension key successfully found

                ' Change button to "Uninstall"
                With btnInstall_Uninstall
                    .Image = My.Resources.arrow_red
                    .Text = "Uninstall " & strAppname
                End With

            Else
                ' Registry Key for the shell extension wasn't found ... 

                ' Set the button to show the option to install it
                With btnInstall_Uninstall
                    .Image = My.Resources.arrow
                    .Text = "Install Shell Extension"
                End With

                ' Alert the user that the shell extension needs to be installed, which afterall, IS what the program is all about.
                If MessageBox.Show("Looks like you don't have the Shell Extension installed on your system yet." & Environment.NewLine & Environment.NewLine & "Since having that is the ENTIRE point of this app, let's get that installed for you right now." & Environment.NewLine & Environment.NewLine & "Click OK to install it.", "Well, this is awkward.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                    btnInstall_Uninstall.PerformClick()
                Else
                    ' User clicked Cancel
                    Close_App()
                End If
            End If
        Finally
            Registry.ClassesRoot.Close()
        End Try

        ' Check for a command-line param to our app
        If My.Application.CommandLineArgs.Count > 0 Then

            For Each argument As String In My.Application.CommandLineArgs
                If My.Computer.FileSystem.FileExists(argument) Then
                    ' It's a file and it's been passed via the Shell Extension, so run it through Strings.exe.
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
            Me.Opacity = 100%
        End If

    End Sub

    Private Sub btnInstall_Uninstall_Click(sender As Object, e As EventArgs) Handles btnInstall_Uninstall.Click

        If btnInstall_Uninstall.Text.Contains("Uninstall") Then
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
                ' Delete the Strings.exe file, to do a complete uninstallation
                tsLabel.Text = "Removing the Engine ..."

                If FileIO.FileSystem.FileExists(strStringsExePath) = True Then
                    FileIO.FileSystem.DeleteFile(strStringsExePath)
                End If
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            ' Reset the button to show the option to install it.
            Toggle_Install_State_Indicators(False)
            tsLabel.Text = ""

            ' Alert user all is done
            MessageBox.Show(strAppname & " has been completely removed from your system." & Environment.NewLine & Environment.NewLine & "If you'd like to re-install it, click the 'Install Shell Extension' button.", "You're free to leave.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            ' Install

            tsLabel.Text = "Installing Shell Extension Keys ..."

            ' Install the Shell Extension (context-menu) regkey
            My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\*\shell\" & strAppname & "\command", "", """" & Application.ExecutablePath & """" & " ""%1""")

            tsLabel.Text = ""

            If FileIO.FileSystem.FileExists(strStringsExePath) = False Then

                lblState2.Text = "Not Installed"

                ' No Strings.exe found. Probably manually clicked the Button after doing an uninstall, so let's let them know we need to install it as well.
                If MessageBox.Show("We now need to download & install the Engine as well. Click OK to begin.", "Just one more second, partner.", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
                    ' Get Strings.
                    Download_and_Unpack_Strings()
                    ' Show it's version
                    Get_Strings_Versions()
                End If
            End If

            ' Reset the button to show the option to uninstall it.
            Toggle_Install_State_Indicators(True)

            If MessageBox.Show(strAppname & " all setup and ready to rock!" & Environment.NewLine & Environment.NewLine & "From now on in order to use it, just right-click on any file, and then click '" & strAppname & "'." & Environment.NewLine & Environment.NewLine & "If you ever want to uninstall it, just run this app again manually and click the Uninstall button." & Environment.NewLine & Environment.NewLine & "This app will now close once you click the OK button.", "You're good to go.", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
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

    Private Sub Toggle_Install_State_Indicators(bInstalled As Boolean)
        ' Provides a single place to toggle all Strings.exe installed/uninstalled indicators

        If bInstalled = True Then
            ' Set all indicators to Installed
            With btnInstall_Uninstall
                .Image = My.Resources.arrow_red
                .Text = "Uninstall Shell Extension"
            End With

            lblState2.Text = "Installed"
        Else
            ' Set all indicators to Not Installed
            With btnInstall_Uninstall
                .Image = My.Resources.arrow
                .Text = "Install Shell Extension"
            End With

            lblState2.Text = "Not Installed"
        End If

    End Sub

End Class
