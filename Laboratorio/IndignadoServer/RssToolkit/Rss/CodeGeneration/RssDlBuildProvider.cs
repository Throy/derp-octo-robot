/*=======================================================================
  Copyright (C) Microsoft Corporation.  All rights reserved.

  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
=======================================================================*/

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Xml;
using RssToolkit.Rss;

namespace RssToolkit.Rss.CodeGeneration
{
    /// <summary>
    ///  build provider for .rssdl type - to automatically generate strongly typed
    /// classes for channels from URLs defined in .rssdl file
    /// </summary>
    [BuildProviderAppliesTo(BuildProviderAppliesTo.Code)]
    public sealed class RssdlBuildProvider : BuildProvider
    {
        /// <summary>
        /// Generates source code for the virtual path of the build provider, and adds the source code to a specified assembly builder.
        /// </summary>
        /// <param name="assemblyBuilder">The assembly builder that references the source code generated by the build provider.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "System.IO.InvalidDataException.#ctor(System.String)")]
        public override void GenerateCode(AssemblyBuilder assemblyBuilder)
        {
            if (assemblyBuilder == null)
            {
                throw new ArgumentNullException("assemblyBuilder");
            }

            // load as XML
            XmlDocument doc = new XmlDocument();
            using (Stream s = OpenStream(VirtualPath))
            {
                doc.Load(s);
            }

            // validate root rssdl node
            XmlNode root = doc.DocumentElement;

            if (root.Name != "rssdl")
            {
                throw new InvalidDataException(string.Format(CultureInfo.InvariantCulture, "Unexpected root node '{0}' -- expected root 'rssdl' node", root.Name));
            }

            // iterate through rss nodes
            for (XmlNode n = root.FirstChild; n != null; n = n.NextSibling)
            {
                if (n.NodeType != XmlNodeType.Element)
                {
                    continue;
                }

                if (n.Name != "rss")
                {
                    throw new InvalidDataException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "Unexpected node '{0}' -- expected root 'rss' node",
                            root.Name));
                }

                string file = string.Empty;
                string url = string.Empty;
                string classNamePrefix = string.Empty;
                string namespaceName = string.Empty;

                foreach (XmlAttribute attr in n.Attributes)
                {
                    switch (attr.Name)
                    {
                        case "name":
                            classNamePrefix = attr.Value;
                            break;
                        case "url":
                            url = attr.Value;
                            break;
                        case "file":
                            file = VirtualPathUtility.Combine(VirtualPathUtility.GetDirectory(VirtualPath), attr.Value);
                            break;
                        case "namespace":
                            namespaceName = attr.Value;
                            break;
                        default:
                            throw new InvalidDataException(
                                string.Format(CultureInfo.InvariantCulture, "Unexpected attribute '{0}'", attr.Name));
                    }
                }

                if (string.IsNullOrEmpty(classNamePrefix))
                {
                    throw new InvalidDataException("Missing 'name' attribute");
                }

                if (string.IsNullOrEmpty(url) && string.IsNullOrEmpty(file))
                {
                    throw new InvalidDataException("Missing 'url' or 'file' attribute - one must be specified");
                }

                if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(file))
                {
                    throw new InvalidDataException("Only one of 'file' and 'url' can be specified");
                }

                // compile channel
                CodeCompileUnit ccu = new CodeCompileUnit();

                if (!string.IsNullOrEmpty(url))
                {
                    // load RssDocument
                    using (Stream feedStream = DownloadManager.GetFeed(url))
                    {
                        using (XmlTextReader reader = new XmlTextReader(feedStream))
                        {
                            string codeString = RssXmlHelper.ConvertToRssXml(reader);
                            RssCodeGenerator.GenerateCodeDomTree(codeString, url, namespaceName, classNamePrefix, ccu, true);
                        }
                    }
                }
                else
                {
                    using (XmlTextReader reader = new XmlTextReader(file))
                    {
                        string codeString = RssXmlHelper.ConvertToRssXml(reader);
                        RssCodeGenerator.GenerateCodeDomTree(codeString, url, namespaceName, classNamePrefix, ccu, true);
                    }
                }

                assemblyBuilder.AddCodeCompileUnit(this, ccu);
            }
        }
    }
}
