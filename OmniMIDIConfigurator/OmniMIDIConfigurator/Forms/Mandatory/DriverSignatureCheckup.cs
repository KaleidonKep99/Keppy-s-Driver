﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OmniMIDIConfigurator
{
    public partial class DriverSignatureCheckup : Form
    {
        Boolean Is32BitMatch = true;
        Boolean Is64BitMatch = true;
        Boolean IsNewVerAvailable = false;
        IntPtr WOW64Value = IntPtr.Zero;

        public DriverSignatureCheckup(String SHA25632, String SHA25664, String NewSHA25632, String NewSHA25664, Boolean Is64Bit)
        {
            InitializeComponent();

            var sha32 = new SHA256Managed();
            var DLL32bit = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + "\\OmniMIDI\\OmniMIDI.dll", FileMode.OpenOrCreate, FileAccess.Read);
            byte[] checksum32 = sha32.ComputeHash(DLL32bit);
            String Driver32SHA256 = BitConverter.ToString(checksum32).Replace("-", String.Empty);
            String Driver64SHA256 = null;

            Driver32Current.Text = Driver32SHA256;
            Driver32Expected.Text = SHA25632;

            if (Driver32SHA256 != SHA25632)
            {
                if (!object.Equals(SHA25664, NewSHA25664))
                {
                    Driver32Status.Image = OmniMIDIConfigurator.Properties.Resources.erroriconupd;
                }
                else
                {
                    Driver32Status.Image = OmniMIDIConfigurator.Properties.Resources.erroricon;
                }
                Is32BitMatch = false;
            }
            else
            {
                if (!object.Equals(SHA25664, NewSHA25664))
                {
                    Driver32Status.Image = OmniMIDIConfigurator.Properties.Resources.successiconupd;
                }
                else
                {
                    Driver32Status.Image = OmniMIDIConfigurator.Properties.Resources.successicon;
                }
                Is32BitMatch = true;
            }

            if (Environment.Is64BitOperatingSystem)
            {
                Functions.Wow64DisableWow64FsRedirection(ref WOW64Value);
                var sha64 = new SHA256Managed();
                var DLL64bit = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\OmniMIDI\\OmniMIDI.dll", FileMode.OpenOrCreate, FileAccess.Read);
                byte[] checksum64 = sha64.ComputeHash(DLL64bit);
                Driver64SHA256 = BitConverter.ToString(checksum64).Replace("-", String.Empty);
                Functions.Wow64RevertWow64FsRedirection(WOW64Value);

                Driver64Current.Text = Driver64SHA256;
                Driver64Expected.Text = SHA25664;

                if (Driver64SHA256 != SHA25664)
                {
                    if (!object.Equals(SHA25664, NewSHA25664))
                    {
                        Driver64Status.Image = OmniMIDIConfigurator.Properties.Resources.erroriconupd;
                    }
                    else
                    {
                        Driver64Status.Image = OmniMIDIConfigurator.Properties.Resources.erroricon;
                    }
                    Is64BitMatch = false;
                }
                else
                {
                    if (!object.Equals(SHA25664, NewSHA25664))
                    {
                        Driver64Status.Image = OmniMIDIConfigurator.Properties.Resources.successiconupd;
                    }
                    else
                    {
                        Driver64Status.Image = OmniMIDIConfigurator.Properties.Resources.successicon;
                    }
                    Is64BitMatch = true;
                }
            }

            String OriginalRelease = "{0} not the original from GitHub. Click here to download the original release.";
            String LatestRelease = "{0} not the original from GitHub.\nThere's also an update, click here to download the latest release.";
            String EverythingFine = "Both drivers are the originals from GitHub. Everything's good, click OK to close the dialog.";
            String EverythingFineUpd = "Both drivers are the originals from GitHub, but newer versions are available.\nClick here to download the latest release.";
            
            if (!Is32BitMatch && !Is64BitMatch)
            {
                if (!object.Equals(SHA25632, NewSHA25632) || !object.Equals(SHA25664, NewSHA25664))
                {
                    BothDriverStatus.Text = String.Format(LatestRelease, "Both drivers are");
                    BothDriverStatus.ForeColor = Color.DarkRed;
                    BothDriverStatus.Cursor = Cursors.Hand;
                    BothDriverStatus.Font = new Font(BothDriverStatus.Font.FontFamily, BothDriverStatus.Font.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    IsNewVerAvailable = true;
                }
                else
                {
                    BothDriverStatus.Text = String.Format(OriginalRelease, "Both drivers are");
                    BothDriverStatus.ForeColor = Color.DarkRed;
                    BothDriverStatus.Cursor = Cursors.Hand;
                    BothDriverStatus.Font = new Font(BothDriverStatus.Font.FontFamily, BothDriverStatus.Font.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            else if (!Is32BitMatch)
            {
                if (!object.Equals(SHA25632, NewSHA25632) || !object.Equals(SHA25664, NewSHA25664))
                {
                    BothDriverStatus.Text = String.Format(LatestRelease, "The 32-bit driver is");
                    BothDriverStatus.ForeColor = Color.Peru;
                    BothDriverStatus.Cursor = Cursors.Hand;
                    BothDriverStatus.Font = new Font(BothDriverStatus.Font.FontFamily, BothDriverStatus.Font.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    IsNewVerAvailable = true;
                }
                else
                {
                    BothDriverStatus.Text = String.Format(OriginalRelease, "The 32-bit driver is");
                    BothDriverStatus.ForeColor = Color.Peru;
                    BothDriverStatus.Cursor = Cursors.Hand;
                    BothDriverStatus.Font = new Font(BothDriverStatus.Font.FontFamily, BothDriverStatus.Font.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            else if (!Is64BitMatch)
            {
                if (!object.Equals(SHA25632, NewSHA25632) || !object.Equals(SHA25664, NewSHA25664))
                {
                    BothDriverStatus.Text = String.Format(LatestRelease, "The 64-bit driver is");
                    BothDriverStatus.ForeColor = Color.Peru;
                    BothDriverStatus.Cursor = Cursors.Hand;
                    BothDriverStatus.Font = new Font(BothDriverStatus.Font.FontFamily, BothDriverStatus.Font.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    IsNewVerAvailable = true;
                }
                else
                {
                    BothDriverStatus.Text = String.Format(OriginalRelease, "The 64-bit driver is");
                    BothDriverStatus.ForeColor = Color.Peru;
                    BothDriverStatus.Cursor = Cursors.Hand;
                    BothDriverStatus.Font = new Font(BothDriverStatus.Font.FontFamily, BothDriverStatus.Font.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            else
            {
                if (!object.Equals(Driver32SHA256, NewSHA25632) || !object.Equals(Driver64SHA256, NewSHA25664))
                {
                    BothDriverStatus.Text = EverythingFineUpd;
                    BothDriverStatus.ForeColor = Color.Blue;
                    BothDriverStatus.Cursor = Cursors.Hand;
                    BothDriverStatus.Font = new Font(BothDriverStatus.Font.FontFamily, BothDriverStatus.Font.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    IsNewVerAvailable = true;
                }
                else
                {
                    BothDriverStatus.Text = EverythingFine;
                    BothDriverStatus.ForeColor = Color.Green;
                    BothDriverStatus.Cursor = Cursors.Arrow;
                    BothDriverStatus.Font = new Font(BothDriverStatus.Font.FontFamily, BothDriverStatus.Font.Size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void DriverSignatureCheckup_Load(object sender, EventArgs e)
        {
            if (!Is32BitMatch && !Is64BitMatch)
            {
                SystemSounds.Hand.Play();
            }
            else if (!Is32BitMatch || !Is64BitMatch)
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void ClosePls_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BothDriverStatus_Click(object sender, EventArgs e)
        {
            if (!Is32BitMatch || !Is64BitMatch || IsNewVerAvailable)
            {
                UpdateSystem.CheckForUpdates(false, false, false);
            }
        }
    }
}
