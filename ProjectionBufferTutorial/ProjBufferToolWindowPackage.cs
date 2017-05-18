using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;

namespace ProjectionBufferTutorial
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ProjBufferToolWindow))]
    [Guid(ProjBufferToolWindowPackage.PackageGuidString)]
    public sealed class ProjBufferToolWindowPackage : Package
    {
        public const string PackageGuidString = "1c4c82af-4508-4dde-9c56-1437492bff5d";

        public ProjBufferToolWindowPackage()
        {
        }

        protected override void Initialize()
        {
            ProjBufferToolWindowCommand.Initialize(this);
            base.Initialize();

            VisualStudioServices.ServiceProvider = this;
            VisualStudioServices.OLEServiceProvider = (Microsoft.VisualStudio.OLE.Interop.IServiceProvider)VisualStudioServices.ServiceProvider.GetService(typeof(Microsoft.VisualStudio.OLE.Interop.IServiceProvider));
        }
    }
}
