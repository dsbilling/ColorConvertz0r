Public Class colorpanelsize
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        colorpanel.Height = TextBox1.Text
        colorpanel.Width = TextBox2.Text
        Me.Close()
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text >= 7000 Then
            TextBox2.Text = 7000
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text >= 7000 Then
            TextBox1.Text = 7000
        End If
    End Sub
    Private Overloads Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            'Put whatever you want here.
            Button1.PerformClick()
        End If
    End Sub
    Private Sub colorpanelsize_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class