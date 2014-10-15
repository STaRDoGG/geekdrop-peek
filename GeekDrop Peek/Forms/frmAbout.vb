Public Class frmAbout

    Private Sub llStringsWebsite_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llStringsWebsite.LinkClicked
        ' Launch the Strings website
        Process.Start(strStringsSite)
    End Sub

    Private Sub llJSE_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llJSE.LinkClicked
        ' Launch the GD website
        NavigateToGd()
    End Sub

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim strAbout As String = "About " & strAppname & " v" & Application.ProductVersion & " [ßeta]"

        Me.Text = strAbout
        lblTitle.Text = strAbout
        llJSE.Text = strAppname & " created by J. Scott Elblein"

        Try
            ' Save the RTF file from our Resources to the Temp foler
            IO.File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & strAppname & ".rtf", My.Resources.Test)

            ' Load that saved RTF file into the RichTextBox
            rtbDescription.LoadFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & strAppname & ".rtf")
        Catch ex As Exception
            Debug.Print(ex.Message)
            rtbDescription.Text = "Woops! I couldn't seem to load the text into this box. Sorry!"
        End Try

    End Sub

    Private Sub picLogo_MouseDown(sender As Object, e As MouseEventArgs) Handles picLogo.MouseDown
        ' For the form moving code
        GetMouseOffset(e)
    End Sub

    Private Sub picLogo_MouseMove(sender As Object, e As MouseEventArgs) Handles picLogo.MouseMove
        ' For the form moving code. Allows moving the form via dragging the logo image
        Move_Form(e, Me)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close_Window(Me)
    End Sub

End Class