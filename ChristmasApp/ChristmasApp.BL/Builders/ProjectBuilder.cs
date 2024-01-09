using Microsoft.Build.Evaluation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.BL.Builders
{
    public static class ProjectBuilder
    {
        public static string GetProjectDLL(string projectPath)
        {
            var projectName = Path.GetFileNameWithoutExtension(projectPath);
            var outputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dllPath = Path.Combine(outputPath!, $"{projectName}.dll");

            return dllPath;
        }
    }
}