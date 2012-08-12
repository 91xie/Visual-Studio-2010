Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.Text = "NO"

        Dim options(5)



        For Each x In options
            Dim y
            y = x
            ListBox1.Items.Add(y)
        Next

        Dim abitof
        abitof = "hello"
        ListBox1.Items.Add(abitof)
        ListBox1.Refresh()

    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Add("another item")
    End Sub

    
End Class
