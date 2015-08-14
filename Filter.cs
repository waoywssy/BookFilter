using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace eBookFilter
{
    class Filter
    {
        private String targetPath;
        private String sourcePath;
        private String patten;

        public Filter() {
            XmlDocument config = new XmlDocument();
            // DO NOT FORGET TO SET 'COPY ALWAYS' TO THE COFNIG FILE
            config.Load(Path.Combine(Environment.CurrentDirectory, "MyConfig.xml"));
            XmlNode botNode = config.SelectSingleNode("//config/Filter");

            targetPath = XmlConfigReader.GetString(botNode, "targetPath", @"C:\");
            sourcePath = XmlConfigReader.GetString(botNode, "sourcePath", Environment.CurrentDirectory);
            patten = XmlConfigReader.GetString(botNode, "patten", @"*.azw3");
        }

        public void Move()
        {
            if (!Directory.Exists(sourcePath))
            {
                Console.WriteLine("Incorrect source path, please confirm.");
                return;
            }
            DirectoryInfo dir = new DirectoryInfo(sourcePath);
            
            FileInfo[] files = dir.GetFiles(patten, SearchOption.AllDirectories);

            Log.Info("Start to move...");
            Int32 count = 0;
            foreach (FileInfo file in files)
            {
                try
                {
                    File.Copy(file.FullName, Path.Combine(targetPath, file.Name));
                    count++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Log.Error("Error moving file; " + ex.ToString());
                }
            }
            Log.Info("Jobs done! " + count.ToString() + " files moved.");
        }
    }
}
