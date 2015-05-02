using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Hosting;
using Microsoft.Runtime.Hosting;
using Microsoft.Runtime.Hosting.Interop;

namespace AircraftSerializer
{
    public static class PluginVerification
    {
        public static bool Verify(Assembly assembly, String publicKeyFilePath)
        {
            //verifying the assembly's strong name signature
            /*var host = HostingInteropHelper.GetClrMetaHost<IClrMetaHost>();
            var bufferSize = 100;
            var version = new StringBuilder(bufferSize);
            var result = host.GetVersionFromFile(Assembly.GetExecutingAssembly().Location, version, ref bufferSize);
            IClrRuntimeInfo info = host.GetRuntime(version.ToString(), new Guid(IID.IClrRuntimeInfo)) as IClrRuntimeInfo;
            ICLRStrongName sn = info.GetInterface(new Guid(CLSID.ClrStrongName), new Guid(IID.IClrStrongName)) as ICLRStrongName;
            if (sn.StrongNameSignatureVerificationEx(assembly.Location, Convert.ToByte(true)) != 0)
            {
                return false;
            }*/

            //looking for sn.exe
            String[] snPaths = { };
            try
            {
                snPaths = Directory.GetFiles(Path.GetPathRoot(Environment.SystemDirectory) + "Program Files\\Microsoft SDKs\\Windows\\", "sn.exe", SearchOption.AllDirectories);
            }
            catch
            {
                try
                {
                    snPaths = Directory.GetFiles(Path.GetPathRoot(Environment.SystemDirectory) + "Program Files (x86)\\Microsoft SDKs\\Windows\\", "sn.exe", SearchOption.AllDirectories);
                }
                catch
                {
                    MessageBox.Show("Could not load plugins: assembly verification failed because sn.exe is missing.");
                    return false;
                }
            }
            if (snPaths.Count() < 1)
            {
                MessageBox.Show("Could not load plugins: assembly verification failed because sn.exe is missing.");
                return false;
            }

            var processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;

            var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();

            process.StandardInput.AutoFlush = true;
            process.StandardInput.WriteLine("\"" + snPaths.Last() + "\"" + " -tp " + "\"" + publicKeyFilePath + "\"");
            process.StandardInput.Close();
            var convertedOutput = (new StreamReader(process.StandardOutput.BaseStream, true)).ReadToEnd();
            var publicKeyToken = convertedOutput.Substring(convertedOutput.LastIndexOf(": ") + 2);
            publicKeyToken = publicKeyToken.Substring(0, publicKeyToken.IndexOf(Environment.NewLine));

            var pluginAssemblyPublicKeyToken = assembly.FullName.Substring(assembly.FullName.IndexOf("PublicKeyToken=") + 15);
            if (pluginAssemblyPublicKeyToken == publicKeyToken)
                return true;
            else
                return false;
        }

        public static class IID
        {
            public const string IClrRuntimeInfo = "BD39D1D2-BA2F-486A-89B0-B4B0CB466891";
            public const string IClrMetaHost = "D332DB9E-B9B3-4125-8207-A14884F53216";
            public const string IClrStrongName = "9FD93CCF-3280-4391-B3A9-96E1CDE77C8D";
            public const string IEnumUnknown = "00000100-0000-0000-C000-000000000046";
        }

        public static class CLSID
        {
            public const string ClrStrongName = "B79B0ACD-F5CD-409b-B5A5-A16244610B92";
        }
    }
}
