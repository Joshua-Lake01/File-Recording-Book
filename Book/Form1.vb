Imports System.IO

Public Class Form1
    Dim cp As Integer = 1
    Dim contacts(50, 3) As String



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Load data button
        Dim datafile As System.IO.StreamReader
        Dim datafilename As String = "myfile.txt"

        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            datafilename = OpenFileDialog1.FileName

            Try

                datafile = My.Computer.FileSystem.OpenTextFileReader(datafilename)
                For x = 1 To 50
                    contacts(x, 1) = datafile.ReadLine
                    contacts(x, 2) = datafile.ReadLine
                    contacts(x, 3) = datafile.ReadLine
                Next x
                datafile.Close()
                cp = 1
                Label2.Text = cp
                TextBox1.Text = contacts(cp, 1)
                TextBox2.Text = contacts(cp, 2)
                TextBox3.Text = contacts(cp, 3)


            Catch ex As Exception
                MsgBox("file doesn't exist")
            End Try
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Forward button
        If cp < 50 Then

            contacts(cp, 1) = TextBox1.Text
            contacts(cp, 2) = TextBox2.Text
            contacts(cp, 3) = TextBox3.Text

            cp = cp + 1
            Label2.Text = cp


            TextBox1.Text = contacts(cp, 1)
            TextBox2.Text = contacts(cp, 2)
            TextBox3.Text = contacts(cp, 3)
        End If
        


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Back Button
        If cp > 1 Then
            contacts(cp, 1) = TextBox1.Text
            contacts(cp, 2) = TextBox2.Text
            contacts(cp, 3) = TextBox3.Text

            cp = cp - 1
            Label2.Text = cp

            TextBox1.Text = contacts(cp, 1)
            TextBox2.Text = contacts(cp, 2)
            TextBox3.Text = contacts(cp, 3)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Save data button

        Dim x As Integer
        Dim datafile As System.IO.StreamWriter
        Dim datafilename As String

        SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            datafilename = SaveFileDialog1.FileName


            datafile = My.Computer.FileSystem.OpenTextFileWriter(datafilename, False)

            For x = 1 To 50
                datafile.WriteLine(contacts(x, 1))
                datafile.WriteLine(contacts(x, 2))
                datafile.WriteLine(contacts(x, 3))
            Next x

            datafile.Close()


        End If

    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
