using ClosedXML.Excel;
using Sgml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace SampleApplication
{

    public static class XLCellExtension
    {

        public static IXLCell SetHtmlValue(this IXLCell target, string html)
        {
            var reader = new SgmlReader();
            reader.DocType = "HTML";
            reader.WhitespaceHandling = WhitespaceHandling.None;
            reader.InputStream = new StringReader(html);
            var xmlRoot = new XmlDocument();
            xmlRoot.Load(reader);
            target.SetValue(xmlRoot.InnerText);
            var rootText = xmlRoot.InnerXml;
            var spanIndex = 0;
            foreach (var item in xmlRoot.GetElementsByTagName("span").Cast<XmlElement>())
            {
                var itemText = item.OuterXml;
                var rawStart = rootText.IndexOf(itemText, spanIndex);
                var rawLength = itemText.Length;
                var trimStart = Regex.Replace(rootText.Substring(0, rawStart), "<.+?>", "").Length;
                var trimLength = item.InnerText.Length;
                var richText = target.RichText.Substring(trimStart, trimLength);
                richText.SetCssStyle(item);
                spanIndex = rawStart + rawLength;
            }
            var strongIndex = 0;
            foreach (var item in xmlRoot.GetElementsByTagName("strong").Cast<XmlElement>())
            {
                var itemText = item.OuterXml;
                var rawStart = rootText.IndexOf(itemText, strongIndex);
                var rawLength = itemText.Length;
                var trimStart = Regex.Replace(rootText.Substring(0, rawStart), "<.+?>", "").Length;
                var trimLength = item.InnerText.Length;
                var richText = target.RichText.Substring(trimStart, trimLength);
                richText.SetBold();
                richText.SetCssStyle(item);
                strongIndex = rawStart + rawLength;
            }
            return target;
        }

        private static void SetCssStyle<T>(this IXLFormattedText<T> richText, XmlElement element)
        {
            var xmlStyle = element.GetAttribute("style");
            if (string.IsNullOrEmpty(xmlStyle) != true)
            {
                var cssStyles = xmlStyle.Split(';').Select(str =>
                {
                    var pair = str.Split(':');
                    pair[0] = pair[0].Trim();
                    pair[1] = pair[1].Trim();
                    return Tuple.Create(pair[0], pair[1]);
                });
                var cssColor = cssStyles.FirstOrDefault(pair => pair.Item1 == "color");
                if (cssColor != null)
                {
                    richText.SetFontColor(XLColor.FromHtml(cssColor.Item2));
                }
            }
        }

    }

}
