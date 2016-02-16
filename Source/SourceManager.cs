﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public enum SourceLocation { Web17k, Web69, WebPiaoTian, WebWuxiaWorld };
    /*
    public class PlugInFactory<T>
    {
        public T CreatePlugin(string path)
        {
            foreach(string file in Directory.GetFiles(path, "*.dll"))
            {
                foreach (Type assemblyType in Assembly.LoadFrom(file).GetTypes())
                {
                    Type interfaceType = assemblyType.GetInterface(typeof(T).FullName);
                    if (interfaceType != null)
                    {
                        Console.WriteLine("Interface: " + assemblyType.FullName);
                        return (T)Activator.CreateInstance(assemblyType);
                    }
                }
            }
            return default(T);
        }
    }
    */
    public class SourceManager
    {
        /*
        //public static List<string> locations;

        public static void LoadSources()
        {
            //locations = new List<string>();
            //PlugInFactory<NovelSource> loader = new PlugInFactory<NovelSource>();
            //NovelSource instance = loader.CreatePlugin(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SourceDLL"));
        }
        */
        public static NovelSource GetSource(SourceLocation s, string sourceID)
        {
            switch (s)
            {
                case SourceLocation.Web17k:
                    return new Source17k(sourceID);
                case SourceLocation.Web69:
                    return new SourceWeb69(sourceID);
                case SourceLocation.WebPiaoTian:
                    return new SourcePiaoTian(sourceID);
                case SourceLocation.WebWuxiaWorld:
                    return new SourceWuxiaWorld(sourceID);
                default:
                    return null;
            }
        }

        public static string GetSourceURL(SourceLocation s)
        {
            switch (s)
            {
                case SourceLocation.Web17k:
                    return new Source17k(null).BaseURL;
                case SourceLocation.Web69:
                    return new SourceWeb69(null).BaseURL;
                case SourceLocation.WebPiaoTian:
                    return new SourcePiaoTian(null).BaseURL;
                case SourceLocation.WebWuxiaWorld:
                    return new SourceWuxiaWorld(null).BaseURL;
                default:
                    return null;
            }
        }
    }
}
