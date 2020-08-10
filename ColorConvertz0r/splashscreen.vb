Public NotInheritable Class splashscreen
    Private Sub splashscreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.TransparencyKey = Color.FromKnownColor(KnownColor.ActiveCaption)
        Me.BackColor = Me.TransparencyKey

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, _
                                            My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        'Wait for splashscreen - LOL
        Timer1.Start()
        Timer1.Interval = 1000

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If time.Text = 0 Then
            Timer1.Stop()
            Me.Hide()
            main.Show()
        Else
            time.Text = time.Text - 1
        End If

    End Sub
End Class