﻿namespace DirectoryTraversal
{
    using System;
    using System.IO;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);

        }

        public static string TraverseDirectory(string inputFolderPath)
        {

        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {

        }

    }
}
