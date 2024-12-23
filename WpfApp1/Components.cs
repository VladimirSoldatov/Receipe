using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Receipt
{
    public interface IDataErrorInfo
    {
        string Error { get; }
        string this[string columnName] { get; }
    }
    public class ReceiptClass:IDataErrorInfo
    {
        public string Name { set; get; } = String.Empty;
        public ObservableCollection<string> Components { set; get; } = new ObservableCollection<string>();
        public string Description { set; get; } = String.Empty;

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if ((Name.Length < 1))
                        {
                            error = "Неверное название";
                        }
                        break;
                    case "Description":
                        if ((Description.Length < 1))
                        {
                            error = "Нет описания";
                        }
                        break;
                    case "Components":
                        if ((Components.Count < 1))
                        {
                            error = "Нет компанентов";
                        }
                        break;
                }
                return error;
            }
        }
        public ReceiptClass(){}
        public ReceiptClass(string name, ObservableCollection<string> components, string description)
        {
            Name = name;
            Components = components;
            Description = description;
        }

        static public string getStringFromRTF(RichTextBox rtf)
        {
            TextRange textRange = new TextRange(rtf.Document.ContentStart, rtf.Document.ContentEnd);
            return textRange.Text;
        }

    }
    public class RichTextBoxHelper : DependencyObject
    {
        public static string GetDocumentXaml(DependencyObject obj)
        {
            return (string)obj.GetValue(DocumentXamlProperty);
        }

        public static void SetDocumentXaml(DependencyObject obj, string value)
        {
            obj.SetValue(DocumentXamlProperty, value);
        }

        public static readonly DependencyProperty DocumentXamlProperty =
            DependencyProperty.RegisterAttached(
                "DocumentXaml",
                typeof(string),
                typeof(RichTextBoxHelper),
                new FrameworkPropertyMetadata
                {
                    BindsTwoWayByDefault = true,
                    PropertyChangedCallback = (obj, e) =>
                    {
                        var richTextBox = (RichTextBox)obj;

                        // Parse the XAML to a document (or use XamlReader.Parse())
                        var xaml = GetDocumentXaml(richTextBox);
                        var doc = new FlowDocument();
                        var range = new TextRange(doc.ContentStart, doc.ContentEnd);

                        range.Load(new MemoryStream(Encoding.UTF8.GetBytes(xaml)),
                              DataFormats.Xaml);

                        // Set the document
                        richTextBox.Document = doc;

                        // When the document changes update the source
                        range.Changed += (obj2, e2) =>
                        {
                            if (richTextBox.Document == doc)
                            {
                                MemoryStream buffer = new MemoryStream();
                                range.Save(buffer, DataFormats.Xaml);
                                SetDocumentXaml(richTextBox,
                                    Encoding.UTF8.GetString(buffer.ToArray()));
                            }
                        };
                    }
                });
    }

}
