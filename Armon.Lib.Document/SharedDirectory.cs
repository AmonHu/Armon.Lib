using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Armon.Lib.Document
{
    public class User
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }

    public class SharedDirectory : IDisposable
    {
        private readonly string path;
        public SharedDirectory(string path, User user)
        {
            this.path = path;
            this.ConnectShared(user);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private Process CreateCommand()
        {
            return new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                }
            };
        }


        private void Exit(Process p)
        {
            p.StandardInput.WriteLine("exit");
            while (!p.HasExited)
            {
                p.WaitForExit(1000);
            }
        }



        private void ClearConnect(Process p)
        {
            var cmd = $"net use {this.path} /delete";
            Console.WriteLine(cmd);
            p.StandardInput.WriteLine(cmd);
            this.Exit(p);

            p.StandardError.ReadToEnd();
        }

        private bool Connect(Process p, User user)
        {
            var cmd = $"net use {this.path} {user.Password} /user:{user.Id}";
            Console.WriteLine(cmd);
            p.StandardInput.WriteLine(cmd);
            this.Exit(p);

            var error = p.StandardError.ReadToEnd();
            p.StandardError.Close();

            if (!string.IsNullOrWhiteSpace(error))
            {
                throw new Exception(error);
            }
            return true;
        }

        private bool ConnectShared(User user)
        {
            using (var p = CreateCommand())
            {
                p.Start();
                ClearConnect(p);
                return Connect(p, user);
            }
        }

        public IEnumerable<string> EnumerateFiles(string searchPattern)
        {
            return Directory.EnumerateFiles(path, searchPattern);
        }

        public bool Exists()
        {
            return Directory.Exists(this.path);
        }

        public string[] GetDirectories(string searchPattern, System.IO.SearchOption searchOption)
        {
            return Directory.GetDirectories(path, searchPattern, searchOption);
        }

        public string[] GetDirectories(string searchPattern)
        {
            return Directory.GetDirectories(path, searchPattern);
        }
    }
}
