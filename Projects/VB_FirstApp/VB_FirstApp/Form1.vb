Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim consolewrite
        consolewrite = ""

        Button1.Text = "Change"

        Label1.Text = "Text"

        Dim options(5)

        For x = 0 To options.Length - 1
            options(x) = "Option" + x.ToString()
        Next

        For Each x In options
            ListBox1.Items.Add(x)
        Next




    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListBox1.SelectedIndex > -1 Then
            ListBox2.Items.Add(ListBox1.Items.Item(ListBox1.SelectedIndex))
        End If



    End Sub

    
End Class
