using System;
using System.IO;
using Virtum.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(Helper))]
namespace Virtum.Droid
{
    public class Helper : IHelper
    {
        public string GetFilePath(string file)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, file);
        }
    }
}