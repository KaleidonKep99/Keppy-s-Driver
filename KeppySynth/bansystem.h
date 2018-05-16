/*
Keppy's Synthesizer blacklist system
*/

BOOL CheckXP(){
	DWORD version = GetVersion();
	DWORD major = (DWORD)(LOBYTE(LOWORD(version)));
	return (major < 6);
}

BOOL BlackListSystem(){
	// If the user tries to run the driver on XP, immediately return 0 and quit
	if (CheckXP()) {
		return 0x0;
	}
	// Blacklist system init
	TCHAR defaultstring[MAX_PATH];
	TCHAR userstring[MAX_PATH];
	TCHAR defaultblacklistdirectory[MAX_PATH];
	TCHAR userblacklistdirectory[MAX_PATH];
	TCHAR modulename[MAX_PATH];
	TCHAR fullmodulename[MAX_PATH];
	// Clears all the tchars
	ZeroMemory(defaultstring, MAX_PATH);
	ZeroMemory(userstring, MAX_PATH);
	ZeroMemory(defaultblacklistdirectory, MAX_PATH);
	ZeroMemory(userblacklistdirectory, MAX_PATH);
	ZeroMemory(modulename, MAX_PATH);
	ZeroMemory(fullmodulename,MAX_PATH);
	// Start the system
	SHGetFolderPath(NULL, CSIDL_SYSTEMX86, NULL, 0, defaultblacklistdirectory);
	_tcscat(defaultblacklistdirectory, L"\\keppysynth\\keppysynth.dbl");
	GetModuleFileName(NULL, modulename, MAX_PATH);
	GetModuleFileName(NULL, fullmodulename, MAX_PATH);
	PathStripPath(modulename);
	try {
		if (PathFileExists(defaultblacklistdirectory)) {
			std::wifstream file(defaultblacklistdirectory);
			if (file) {
				// The default blacklist exists, continue
				OutputDebugString(defaultblacklistdirectory);
				while (file.getline(defaultstring, sizeof(defaultstring) / sizeof(*defaultstring)))
				{
					if (_tcsicmp(modulename, defaultstring) == 0) {
						return 0x0;
					}
				}
			}
			else {
				MessageBox(NULL, L"The default blacklist is missing, or the driver is not installed properly!\nFatal error, can not continue!\n\nPress OK to quit.", L"Keppy's Synthesizer - FATAL ERROR", MB_OK | MB_ICONERROR | MB_SYSTEMMODAL);
				exit(0);
			}
		}
		else {
			MessageBox(NULL, L"The default blacklist is missing, or the driver is not installed properly!\nFatal error, can not continue!\n\nPress OK to qu'it.", L"Keppy's Synthesizer - FATAL ERROR", MB_OK | MB_ICONERROR | MB_SYSTEMMODAL);
			exit(0);
		}
		if (SUCCEEDED(SHGetFolderPath(NULL, CSIDL_PROFILE, NULL, 0, userblacklistdirectory))) {
			HKEY hKey;
			long lResult;
			DWORD dwType = REG_DWORD;
			DWORD dwSize = sizeof(DWORD);
			lResult = RegOpenKeyEx(HKEY_CURRENT_USER, L"Software\\Keppy's Synthesizer\\Settings", 0, KEY_ALL_ACCESS, &hKey);
			RegQueryValueEx(hKey, L"noblacklistmsg", NULL, &dwType, (LPBYTE)&noblacklistmsg, &dwSize);
			RegCloseKey(hKey);

			PathAppend(userblacklistdirectory, _T("\\Keppy's Synthesizer\\blacklist\\keppymididrv.blacklist"));
			std::wifstream file(userblacklistdirectory);
			OutputDebugString(userblacklistdirectory);
			while (file.getline(userstring, sizeof(userstring) / sizeof(*userstring)))
			{
				if (_tcsicmp(modulename, userstring) == 0 || _tcsicmp(fullmodulename, userstring) == 0) {
					if (noblacklistmsg != 1) {
						std::wstring modulenamelpcwstr(modulename);
						std::wstring concatted_stdstr = L"Keppy's Synthesizer - " + modulenamelpcwstr + L" is blacklisted";
						LPCWSTR messageboxtitle = concatted_stdstr.c_str();
						MessageBox(NULL, L"This program has been manually blacklisted.\nThe driver will be automatically unloaded.\n\nPress OK to continue.", messageboxtitle, MB_OK | MB_ICONEXCLAMATION | MB_SYSTEMMODAL);
					}
					return 0x0;
				}
			}
		}
		return 0x1;
	}
	catch (...) {
		CrashMessage(L"BlackListCheckUp");
		throw;
	}
}

BOOL BlackListInit(){
	// First, the VMS blacklist system, then the main one
	TCHAR modulename[MAX_PATH];
	TCHAR sndvol[MAX_PATH];
	TCHAR bassmididrv[MAX_PATH];
	TCHAR vmidisynthdll[MAX_PATH];
	TCHAR vmidisynth2exe[MAX_PATH];
	// Clears all the tchars
	ZeroMemory(modulename, sizeof(TCHAR) * MAX_PATH);
	ZeroMemory(sndvol, sizeof(TCHAR) * MAX_PATH);
	ZeroMemory(bassmididrv, sizeof(TCHAR) * MAX_PATH);
	ZeroMemory(vmidisynthdll, sizeof(TCHAR) * MAX_PATH);
	ZeroMemory(vmidisynth2exe, sizeof(TCHAR) * MAX_PATH);
	// Here we go
#if defined(_WIN64)
	SHGetFolderPath(NULL, CSIDL_SYSTEM, NULL, 0, bassmididrv);
	SHGetFolderPath(NULL, CSIDL_SYSTEM, NULL, 0, vmidisynthdll);
	SHGetFolderPath(NULL, CSIDL_SYSTEMX86, NULL, 0, vmidisynth2exe);
#elif defined(_WIN32)
	SHGetFolderPath(NULL, CSIDL_SYSTEMX86, NULL, 0, bassmididrv);
	SHGetFolderPath(NULL, CSIDL_SYSTEMX86, NULL, 0, vmidisynthdll);
	SHGetFolderPath(NULL, CSIDL_SYSTEMX86, NULL, 0, vmidisynth2exe);
#endif
	PathAppend(bassmididrv, _T("\\bassmididrv\\bassmididrv.dll"));
	PathAppend(vmidisynthdll, _T("\\VirtualMIDISynth\\VirtualMIDISynth.dll"));
	PathAppend(vmidisynth2exe, _T("\\VirtualMIDISynth\\VirtualMIDISynth.exe"));
	GetModuleFileName(NULL, modulename, MAX_PATH);
	PathStripPath(modulename);
	// Lel stuff
	_tcscpy_s(sndvol, _countof(sndvol), _T("sndvol.exe"));
	try {
		if (PathFileExists(vmidisynthdll)) {
			if (PathFileExists(vmidisynth2exe)) {
				return BlackListSystem();
			}
			else {
				if (!_tcsicmp(modulename, sndvol)) {
					return 0x0;
				}
				else {
					if (MessageBox(0, L"Please uninstall VirtualMIDISynth 1.x before using this driver.\n\nPress No if you want to use Keppy's Synthesizer anyway, or Yes to unload it from the application.\n\n(VirtualMIDISynth's outdated DLLs could cause performance degradation while using Keppy's Synthesizer)", L"Keppy's Synthesizer", MB_YESNO | MB_ICONWARNING | MB_SYSTEMMODAL) == IDYES)
					{
						return 0x0;
					}
					else {
						return BlackListSystem();
					}
				}
			}
		}
		else if (PathFileExists(bassmididrv)) {
			MessageBox(0, L"Keppy's Synthesizer can NOT work while BASSMIDI Driver is installed.\nThe driver will not work until you uninstall BASSMIDI Driver.\n\nClick OK to continue.", L"Keppy's Synthesizer", MB_OK | MB_ICONERROR | MB_SYSTEMMODAL);
			return 0x0;
		}
		else {
			return BlackListSystem();
		}
		return 0x0;
	}
	catch (...) {
		CrashMessage(L"VMSBlackListedCheckUp");
		throw;
	}
}

BOOL BannedSystemProcess() {
	// These processes are PERMANENTLY banned because of some internal bugs inside them.
	TCHAR bannedbattlenet[MAX_PATH];
	TCHAR bannedconsent[MAX_PATH];
	TCHAR bannedcsrss[MAX_PATH];
	TCHAR bannedexplorer[MAX_PATH];
	TCHAR bannedmstsc[MAX_PATH];
	TCHAR bannedrust[MAX_PATH];
	TCHAR bannedshare[MAX_PATH];
	TCHAR bannedshellinfrastructure[MAX_PATH];
	TCHAR bannedsndvol[MAX_PATH];
	TCHAR bannedvmware[MAX_PATH];

	TCHAR modulename[MAX_PATH];

	_tcscpy_s(bannedbattlenet, _countof(bannedbattlenet), _T("Battle.net Launcher.exe"));
	_tcscpy_s(bannedconsent, _countof(bannedconsent), _T("consent.exe"));
	_tcscpy_s(bannedcsrss, _countof(bannedcsrss), _T("csrss.exe"));
	_tcscpy_s(bannedexplorer, _countof(bannedexplorer), _T("explorer.exe"));
	_tcscpy_s(bannedmstsc, _countof(bannedmstsc), _T("mstsc.exe"));
	_tcscpy_s(bannedrust, _countof(bannedrust), _T("RustClient.exe"));
	_tcscpy_s(bannedshare, _countof(bannedshare), _T("NVIDIA Share.exe"));
	_tcscpy_s(bannedshellinfrastructure, _countof(bannedshellinfrastructure), _T("ShellExperienceHost.exe"));
	_tcscpy_s(bannedsndvol, _countof(bannedsndvol), _T("SndVol.exe"));
	_tcscpy_s(bannedvmware, _countof(bannedvmware), _T("vmware-hostd.exe"));

	GetModuleFileName(NULL, modulename, MAX_PATH);
	PathStripPath(modulename);
	if (!_tcsicmp(modulename, bannedbattlenet) |
		!_tcsicmp(modulename, bannedconsent) |
		!_tcsicmp(modulename, bannedcsrss) |
		!_tcsicmp(modulename, bannedexplorer) |
		!_tcsicmp(modulename, bannedmstsc) |
		!_tcsicmp(modulename, bannedrust) |
		!_tcsicmp(modulename, bannedshare) |
		!_tcsicmp(modulename, bannedshellinfrastructure) |
		!_tcsicmp(modulename, bannedsndvol) |
		!_tcsicmp(modulename, bannedvmware)) {
		return TRUE;
		// It's a blacklisted process, so it can NOT create a BASS audio stream.
	}
	else {
		return FALSE;
		// It's not a blacklisted process, so it can create a BASS audio stream.
	}
}