Public Class colorpanel
    Private Sub color_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDoubleClick
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        ElseIf Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        End If
    End Sub
    Private Sub color_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'nothing
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ChangeSizeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChangeSizeToolStripMenuItem.Click
        colorpanelsize.ShowDialog()
    End Sub
    Private Sub NormalSizeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NormalSizeToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub MaximizeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MaximizeToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If ToolStripMenuItem1.Checked = True Then
            Me.TopMost = True
        ElseIf ToolStripMenuItem1.Checked = False Then
            Me.TopMost = False
        Else
            'nothing
        End If
    End Sub
    Private Sub BorderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BorderToolStripMenuItem.Click
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
    End Sub
    Private Sub NoBorderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NoBorderToolStripMenuItem.Click
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    End Sub
End Class