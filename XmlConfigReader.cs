/* $Workfile: XmlConfigReader.cs $
 * $Author: Yang $
 * $Date: 15/03/09 11:25a $ 
 * Copyright Soony
 */
using System;
using System.Text;
using System.Xml;


namespace eBookFilter
{
    /// <summary>
    /// XMLConfigReader reads and parses configurations in xml files.
    /// 
    /// Usage:
    /// 
    /*         
            XmlDocument config = new XmlDocument();
            // DO NOT FORGET TO SET 'COPY ALWAYS' TO THE COFNIG FILE
            config.Load("MyConfig.xml");
            XmlNode botNode = config.SelectSingleNode("//config/MySector1");

            string name = XmlConfigReader.GetString(botNode, "name", "songyang1");
            string gender = XmlConfigReader.GetString(botNode, "gender", "songyang2");
            int age = XmlConfigReader.GetInt(botNode, "age", 100);
    */   
    ///  
    /// </summary>
    public class XmlConfigReader
    {
        /// <summary>
        /// Private Constructor
        /// </summary>
        private XmlConfigReader()
        {

        }


        #region Public Static Methods
        /// <summary>
        /// Get a mandatory attribute.
        /// </summary>
        /// <param name="node">Source xml node.</param>
        /// <param name="name">Attribute name.</param>
        /// <returns>Extracted value.</returns>
        public static string GetValue(XmlNode node, string name)
        {
            XmlAttribute att = node.Attributes[name];

            if (att == null)
                throw new Exception("Missing mandatory attribute: " + name + Environment.NewLine + " at: " + Environment.NewLine + node.OuterXml);

            return att.Value;
        }


        /// <summary>
        /// Get an optional attribute.
        /// </summary>
        /// <param name="node">Source xml node.</param>
        /// <param name="name">Attribute name.</param>
        /// <param name="defaultValue">Value returned in case there is no such attribute.</param>
        /// <returns>Extracted value.</returns>
        public static string GetString(XmlNode node, string name, string defaultValue)
        {
            XmlAttribute att = node.Attributes[name];

            if (att == null)
                return defaultValue;

            return att.Value;
        }

        /// <summary>
		/// Get a mandatory attribute.
		/// </summary>
		/// <param name="node">Source xml node.</param>
		/// <param name="name">Attribute name.</param>
        public static string GetFolderName(XmlNode node, string name)
        {
            XmlAttribute att = node.Attributes[name];

            if (att == null)
                throw new Exception("Missing mandatory folder: " + name + Environment.NewLine + " at: " + Environment.NewLine + node.OuterXml);

            string folderName = att.Value;

            if (folderName.EndsWith("\\"))
                return folderName;

            return folderName + "\\";
        }

        /// <summary>
        /// Get a mandatory attribute in int value.
        /// </summary>
        /// <param name="node">Source xml node.</param>
        /// <param name="name">Attribute name.</param>
        /// <returns>Extracted value.</returns>
        public static int GetInt(XmlNode node, string name)
        {
            XmlAttribute att = node.Attributes[name];

            if (att == null)
                throw new Exception("Missing mandatory attribute: " + name + Environment.NewLine + " at: " + Environment.NewLine + node.OuterXml);

            try
            {
                return int.Parse(att.Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse integer attribute: " + name + " at: " + Environment.NewLine + node.OuterXml, ex);
            }
        }

        /// <summary>
        /// Get an optional attribute in int.
        /// </summary>
        /// <param name="node">Source xml node.</param>
        /// <param name="name">Attribute name.</param>
        /// <param name="defaultValue">Value returned in case there is no such attribute.</param>
        /// <returns>Extracted value.</returns>
        public static int GetInt(XmlNode node, string name, int defaultValue)
        {
            XmlAttribute att = node.Attributes[name];

            if (att == null)
                return defaultValue;

            try
            {
                return int.Parse(att.Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse integer attribute: " + name + " at: " + Environment.NewLine + node.OuterXml, ex);
            }
        }

        /// <summary>
        /// Get a mandatory attribute in long
        /// </summary>
        /// <param name="node">Source xml node.</param>
        /// <param name="name">Attribute name.</param>
        /// <returns>extracted value.</returns>
        public static long GetLong(XmlNode node, string name)
        {
            XmlAttribute att = node.Attributes[name];

            if (att == null)
                throw new Exception("Missing mandatory attribute: " + name + Environment.NewLine + " at: " + Environment.NewLine + node.OuterXml);

            try
            {
                return long.Parse(att.Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse long attribute: " + name + " at: " + Environment.NewLine + node.OuterXml, ex);
            }
        }

        /// <summary>
        /// Get an optional attribute in long
        /// </summary>
        /// <param name="node">Source xml node.</param>
        /// <param name="name">Attribute name.</param>
        /// <param name="defaultValue">Value returned in case there is no such attribute.</param>
        /// <returns>Extracted value.</returns>
        public static long GetLong(XmlNode node, string name, long defaultValue)
        {
            XmlAttribute att = node.Attributes[name];

            if (att == null)
                return defaultValue;

            try
            {
                return long.Parse(att.Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse long attribute: " + name + " at: " + Environment.NewLine + node.OuterXml, ex);
            }
        }

        /// <summary>
        /// Get an attribute in datetime
        /// </summary>
        /// <param name="node">Source xml node.</param>
        /// <param name="name">Attribute name.</param>
        /// <param name="format">Expected format.</param>
        /// <param name="defaultValue">Value returned in case there is no such attribute.</param>
        /// <returns>Extracted value.</returns>
        public static DateTime GetDateTime(XmlNode node, string name, string format, DateTime defaultValue)
        {
            DateTime result = defaultValue;

            XmlAttribute att = node.Attributes[name];

            if (att != null && att.Value.Length != 0)
            {
                try
                {
                    return DateTime.ParseExact(att.Value, format, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to parse a DateTime(\"" + format + "\") attribute: " + name + " at: " + Environment.NewLine + node.OuterXml, ex);
                }
            }
            return result; 
        }

        /// <summary>
        /// Get a mandatory attribute in datetime.
        /// </summary>
        /// <param name="node">Source xml node.</param>
        /// <param name="name">Attribute name.</param>
        /// <param name="format">Expected format.</param>
        /// <returns>Extracted value.</returns>
        public static DateTime GetDateTime(XmlNode node, string name, string format)
        {
            XmlAttribute att = node.Attributes[name];

            if (att == null)
                throw new Exception("Missing mandatory attribute: " + name + Environment.NewLine + " at: " + Environment.NewLine + node.OuterXml);

            try
            {
                return DateTime.ParseExact(att.Value, format, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse a DateTime(\"" + format + "\") attribute: " + name + " at: " + Environment.NewLine + node.OuterXml, ex);
            }
        }

        /// <summary>
        /// Get a mandatory attribute.
        /// </summary>
        /// <param name="node">Source xml node.</param>
        /// <param name="name">Attribute name.</param>
        /// <returns>Extracted value.</returns>
        public static bool GetBool(XmlNode node, string name)
        {
            XmlAttribute att = node.Attributes[name];

            if (att == null)
                throw new Exception("Missing mandatory attribute: " + name + Environment.NewLine + " at: " + Environment.NewLine + node.OuterXml);

            try
            {
                return bool.Parse(att.Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse boolean attribute: " + name + " at: " + Environment.NewLine + node.OuterXml, ex);
            }
        }

        /// <summary>
        /// Get an optional attribute.
        /// </summary>
        /// <param name="node">Source xml node.</param>
        /// <param name="name">Attribute name.</param>
        /// <param name="defaultValue">Value returned in case there is no such attribute.</param>
        /// <returns>Extracted value.</returns>
        public static bool GetBool(XmlNode node, string name, bool defaultValue)
        {
            XmlAttribute att = node.Attributes[name];

            if (att == null)
                return defaultValue;

            try
            {
                return bool.Parse(att.Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse boolen attribute: " + name + " at: " + Environment.NewLine + node.OuterXml, ex);
            }
        }
        #endregion
    }
}
