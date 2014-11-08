#Region "Imports"

Imports System.IO.Compression
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions

#End Region

Module modStrings

#Region "Global Variables"

    ' These vars are used throughout the app so that I can change them in a single place (here) & it'll change them everywhere.

    ' This one is mainly here for me so that I can name it just "Peek" for my own computer, & "GeekDrop Peek" for public consumption in order to get my site's name out.
    ' IMPORTANT NOTE: When changed here, it also changes the actual Registry Key name as well as the Windows Context-menu name.
    Public strAppname As String = "GeekDrop Peek"

    ' Contains the full path of this app + Strings.exe
    Public strStringsExePath As String = Application.StartupPath & "\Strings.exe"

    ' The .txt file we're writing the Strings.exe output to + the path to the local temp folder
    Public strTempFileName As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & strAppname & ".txt"

    ' This is the URL to the official Strings web PAGE. Used for scraping the latest version as well as a credit link.
    Public strStringsSite As String = "http://technet.microsoft.com/en-us/sysinternals/bb897439.aspx"

    ' This is the URL to the official Strings FILE. Used for fetching & installing the latest version locally.
    Public strStringsFile As String = "http://download.sysinternals.com/files/Strings.zip"

#End Region

    Public Sub Run_Strings(strFile As String, Optional strArguments As String = "")
        ' This function is the first step of 2 to do what this app is meant for.
        '
        ' It takes as a param, a path to a file on the system, runs Strings.exe with it's own params, saves it's output to the system temp folder as a .txt file & waits for it's process to exit.

        ' Before we proceed, lets make another check that strings.exe is there, JUSt in case the user somehow managed to delete it while the app was already running.
        ' Unlikely, but just to be a smart programmer ...
        If My.Computer.FileSystem.FileExists(strStringsExePath) Then

            ' This is the default argument's setting for this app, however, I have included the ability to pass different
            ' arguments to the Strings.exe since it takes all kinds of them, and in the future I may add the ability to let
            ' user customize it's output if they so choose.
            If strArguments.Length = 0 Then strArguments = "-o -q"

            ' Create the Strings.exe process object
            Dim pStrings As New Process()

            ' Set it to run hidden from user, so it appears smoother.
            With pStrings.StartInfo
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .FileName = strStringsExePath
                .Arguments = strArguments & " " & """" & strFile
                .UseShellExecute = False
                .CreateNoWindow = True
            End With

            pStrings.Start()

            ' Save all Strings.exe output to the variable "output"
            Dim output As String = pStrings.StandardOutput.ReadToEnd()

            ' Wait for Strings.exe to finish before we handle it's output
            pStrings.WaitForExit()

            ' Clean it up a bit
            output = Add_Spacer(output)

            ' At this point all kinds of options are available to do with the output, for example, you could:
            '   Code in options to save the output to clipboard
            '   Code up an internal viewer so it's all viewed within this app itself, including highlighting options, searches, etc.
            '   Write the output to a file
            '   Whatever else could come to mind. In this case, as in the original "Peek" software, we're going to write it to an external file for opening in
            '   an external text editor.

            ' Write output to file, never appended, always new.
            My.Computer.FileSystem.WriteAllText(strTempFileName, output, False)

        End If

    End Sub

    Public Sub Open_Strings_Result(Optional strViewer As String = "Notepad.exe")
        ' Opens the result from Strings in a viewer.
        '
        ' Defaults to Notepad, so we don't need a full path for that; if user wants a different viewer (i.e. UltraEdit, Notepad++) they have to pass the full path to it.
        ' Currently, support for the latter hasn't been added, since good ol' notepad is good enough for me.

        ' Create the Strings.exe process object
        Dim pStrings As New Process()

        ' Set it to run hidden from user, so it appears smoother.
        With pStrings.StartInfo
            .RedirectStandardOutput = True
            .RedirectStandardError = True
            .FileName = strViewer
            .Arguments = strTempFileName
            .UseShellExecute = False
            .CreateNoWindow = True
        End With

        pStrings.Start()

        ' Wait for Strings.exe to finish before we handle it's output
        pStrings.WaitForExit()
    End Sub

    Public Sub Download_and_Unpack_Strings()

        ' Path of this app
        Dim strPath As String = Application.StartupPath

        Try

            ' This is here basically to reset the color if we were sent here via the upgrade
            With frmMain.tsLabel
                .Text = "Downloading Latest Strings.zip ..."
                .ForeColor = Color.White
            End With

            ' Download the latest Strings.zip from the official website, using a 60 second timeout, and showing the download GUI (which will probably just flash since it's just a tiny file).
            My.Computer.Network.DownloadFile(strStringsFile, strPath & "\Strings.zip", Nothing, Nothing, True, 60000, True)
        Catch ex As Exception
            frmMain.tsLabel.Text = "Failed Downloading Latest Strings.zip!"
            MessageBox.Show(ex.Message, "Error Opening Strings.zip File!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            ' First, make sure Strings.zip exists before we try to unzip it
            If FileIO.FileSystem.FileExists(strPath & "\Strings.zip") = True Then

                frmMain.tsLabel.Text = "Extracting Strings.exe from Strings.zip ..."

                ' Extract Strings.exe from the downloaded zip file
                ZipFile.ExtractToDirectory(strPath & "\Strings.zip", strPath)

                ' Double-check that Strings.exe is extracted and there
                If FileIO.FileSystem.FileExists(strStringsExePath) = True Then

                    Try
                        frmMain.tsLabel.Text = "Cleaning up ..."

                        ' Finally, clean up the dl'd and extracted stuff
                        FileIO.FileSystem.DeleteFile(strPath & "\Strings.zip")
                        FileIO.FileSystem.DeleteFile(strPath & "\Eula.txt")

                    Catch ex As Exception
                        Debug.Print("Error cleaning up!")
                    End Try

                    frmMain.lblState2.Text = "Installed"
                    frmMain.tsLabel.Text = "Latest Engine has been installed!"
                End If

            End If

        End Try

    End Sub

    Public Sub Get_Strings_Versions()
        ' Sub gets, displays the currently installed Strings.exe version from the file itself, then scrapes the Strings website for the latest version info,
        ' if newer versions found, alert user.

        Try
            ' Get and display the current Strings.exe version
            Dim strCurrentVer As String = FileVersionInfo.GetVersionInfo(strStringsExePath).FileMajorPart.ToString & "." & FileVersionInfo.GetVersionInfo(strStringsExePath).FileMinorPart.ToString

            With frmMain
                .lblState2.Text = "Installed"
                .tsLabel.Text = "Engine: v" & strCurrentVer
            End With

            ' Store the current Strings.exe version as a Version object for later comparison
            Dim oCurrent As New Version(strCurrentVer)

            ' Get the latest Strings version from the website
            Dim strLatest As String = Scrape_Latest_Version()

            ' Store the scraped, latest Strings.exe version as a Version object for later comparison
            ' NOTE: if running the this app for the first time and it's Scrape_Version() check gets blocked by a firewall, the following line coughs up an exception.
            Dim oLatest As New Version(strLatest)

            ' Do the version compare
            Dim intCompare As Int32 = oCurrent.CompareTo(oLatest)

            If intCompare < 0 Then

                With frmMain.tsLabel
                    .Text = "Newer Engine Available! (v" & strLatest & "). Click here to install it!"
                    .ForeColor = Color.FromArgb(255, 255, 128)
                End With

            End If
        Catch ex As Exception
            Debug.Print(ex.Message)

            ' Something BAYAD happened, lets just present an empty label
            With frmMain.tsLabel
                .Text = "Failed getting installed Engine version! Did ya block me with your firewall?"
                .ForeColor = Color.DarkRed
            End With
        End Try

    End Sub

    Private Function Scrape_Latest_Version() As String
        ' Fetches the Strings web page, then scrapes it for the latest version, then returns the scraped version as the result
        '
        ' Note: I'm not much of a fan of scraping pages, since it's so easily susceptible to breaking with even the slightes change by the website owner, but
        '       I don't know of any safer way for this app, as of right now.
        '
        ' TODO: To really tighten up, we SHOULD confirm that the parsed out result really does contain a number. If not, (maybe they changed the page source?)
        '       then return something we can test against.
        '
        ' <h1>Strings v2.52</h1>

        Scrape_Latest_Version = String.Empty

        Try
            Dim strRequest As WebRequest = WebRequest.Create(strStringsSite)
            Dim strResponse As WebResponse = strRequest.GetResponse
            Dim rs As StreamReader = New StreamReader(strResponse.GetResponseStream())
            Dim strSource As String = rs.ReadToEnd

            ' Parse out all html to the left of ...
            Dim strParse As String = strSource.Substring(0, strSource.IndexOf("</h1>"))
            ' Now Parse out the version to the right of ...
            strParse = strParse.Substring(strParse.IndexOf("<h1>Strings v") + 13)

            ' Save it
            Scrape_Latest_Version = strParse

        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

        Return Scrape_Latest_Version

    End Function

    Private Function Add_Spacer(strInput As String) As String
        ' This function adds a space between the semi-colon and the rest of the line, at the beginning of each line. This is a personal preference of mine in order to make it a bit easier
        ' to read, especially when slimming, as the Strings.exe app itself doesn't add the space, there's no option to do so as a param of it, and I've email the author requesting it
        ' many versions ago and it's gone ignored.

        ' Pattern to find: Looks for a minimum of 4 NUMBERS + a semicolon. Strings.exe always has a min of 4 digits (and never hex).
        Dim strPattern As String = "([0-9]){4,}:"

        ' Replace with the matching string plus a single space
        Dim strReplacement As String = "$& "

        Dim rgx As New Regex(strPattern)

        ' Replace and return the result
        Return rgx.Replace(strInput, strReplacement)

    End Function

End Module