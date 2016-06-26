Imports System.Text.RegularExpressions
Imports System.ComponentModel

Public Class MainForm

    Private Download As Boolean = False
    Private PlaySound As Boolean = True
    Private ProcessInfo As ProcessStartInfo
    Private Process As Process
    Private Delegate Sub InvokeWithString(ByVal Text As String)

    Private Sub DownloadButton_Click(sender As Object, e As EventArgs) Handles DownloadButton.Click

        DownloadVideo()

    End Sub

    Private Sub LinkTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles LinkTextBox.KeyUp

        If e.KeyCode = Keys.Enter Then
            DownloadVideo()
        End If

    End Sub

    Private Sub LinkTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LinkTextBox.KeyPress

        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
        End If

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        CheckUpdate()

    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click

        CheckUpdate()

    End Sub

    Private Sub DownloadVideo()

        If LinkTextBox.Text = Nothing Then
            MsgBox("網址欄位不能留空！", MsgBoxStyle.Exclamation, "警告")
            LinkTextBox.Focus()
        ElseIf Not Regex.IsMatch(LinkTextBox.Text, "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?") Then
            MsgBox("網址無效！", MsgBoxStyle.Critical, "錯誤")
            LinkTextBox.Focus()
            LinkTextBox.SelectAll()
        Else
            Download = True
            PlaySound = True
            DownloadButton.Enabled = False
            LinkTextBox.Enabled = False
            UpdateButton.Enabled = False
            DownloadButton.Text = "正在下載影片"
            YouTubeDL("--format ""best[ext=mp4]/best[ext=flv]/best"" " & LinkTextBox.Text)
        End If

    End Sub

    Private Sub CheckUpdate()

        LinkTextBox.Enabled = False
        DownloadButton.Enabled = False
        UpdateButton.Enabled = False
        UpdateButton.Text = "正在檢查更新"
        YouTubeDL("--update")

    End Sub

    Private Sub YouTubeDL(Arguments As String)

        Try
            Process.Kill()
        Catch ex As Exception
        End Try
        OutputTextBox.Clear()
        'Try
        ProcessInfo = New ProcessStartInfo("youtube-dl.exe", Arguments)
        Dim SystemEncoding As System.Text.Encoding
        System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage)
        With ProcessInfo
            .UseShellExecute = False
            .RedirectStandardError = True
            .RedirectStandardOutput = True
            .RedirectStandardInput = True
            .CreateNoWindow = True
            .StandardOutputEncoding = SystemEncoding
            .StandardErrorEncoding = SystemEncoding
        End With
        Process = New Process With {.StartInfo = ProcessInfo, .EnableRaisingEvents = True}
        AddHandler Process.ErrorDataReceived, AddressOf AsyncDataReceived
        AddHandler Process.OutputDataReceived, AddressOf AsyncDataReceived
        Process.Start()
        Process.BeginOutputReadLine()
        Process.BeginErrorReadLine()
        'Catch ex As Win32Exception
        'MsgBox(ex.Message, MsgBoxStyle.Critical, "錯誤")
        'Environment.Exit(ex.NativeErrorCode)
        'End Try

    End Sub

    Private Sub AsyncDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)

        Me.Invoke(New InvokeWithString(AddressOf SyncOutput), e.Data)

    End Sub

    Private Sub SyncOutput(ByVal Text As String)

        OutputTextBox.AppendText(Text & Environment.NewLine)
        OutputTextBox.ScrollToCaret()

        StatusCheck(Text)

    End Sub

    Private Sub StatusCheck(ByVal Text As String)

        Try
            If Text.Contains("ERROR: Unsupported URL") Then
                PlaySound = False
                MsgBox("網址不支援！", MsgBoxStyle.Critical, "錯誤")
            ElseIf Text.Contains("ERROR: Unable to download webpage") Then
                PlaySound = False
                MsgBox("無法下載影片！", MsgBoxStyle.Critical, "錯誤")
            End If
        Catch ex As Exception
        End Try

        If Process.HasExited Then
            If Download Then
                If PlaySound Then
                    My.Computer.Audio.Play(My.Resources.Finish, AudioPlayMode.Background)
                End If
                Download = False
            End If
            LinkTextBox.Enabled = True
            DownloadButton.Enabled = True
            UpdateButton.Enabled = True
            DownloadButton.Text = "下載影片"
            UpdateButton.Text = "檢查更新"
            LinkTextBox.Focus()
            LinkTextBox.SelectAll()
        End If

    End Sub

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click

        MsgBox("Program developed by Jason Kwok" & vbCrLf & _
               "Source code available on GitHub" & vbCrLf & _
               vbCrLf & _
               "Special thanks:" & vbCrLf & _
               "youtube-dl by Ricardo Garcia" & vbCrLf & _
               "Show DOS Output by Anonymous", MsgBoxStyle.OkOnly, "關於「簡易影片下載器」")

    End Sub
End Class
