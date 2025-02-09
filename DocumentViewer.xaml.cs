﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _20241203Wpf
{
    /// <summary>
    /// MyDocumentViewer.xaml 的互動邏輯
    /// </summary>
    public partial class DocumentViewer : Window
    {
        Color fontColor = Colors.Black;
        public DocumentViewer()
        {
            InitializeComponent();
            fontColorPicker.SelectedColor = fontColor;

            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                fontFamilyComboBox.Items.Add(fontFamily.Source);
            }
            fontFamilyComboBox.SelectedIndex = 13;

            fontSizeComboBox.ItemsSource = new List<double>() { 8, 9, 10, 12, 14, 16, 18, 20, 22, 24, 32, 40, 50, 60, 80, 100 };
            fontSizeComboBox.SelectedIndex = 3;
        }

        private void NewCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            DocumentViewer DocumentViewer = new DocumentViewer();
            DocumentViewer.Show();
        }

        private void OpenCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            openFileDialog.DefaultExt = ".rtf";
            openFileDialog.AddExtension = true;

            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
                fileStream.Close();
            }
        }

        private void SaveCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".rtf";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                range.Save(fileStream, DataFormats.Rtf);
                fileStream.Close();
            }
        }

        private void fontColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            fontColor = (Color)e.NewValue;
            SolidColorBrush fontBrush = new SolidColorBrush(fontColor);
            rtbEditor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, fontBrush);
        }

        private void fontSizeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (fontSizeComboBox.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, fontSizeComboBox.SelectedItem);
            }
        }

        private void fontFamilyComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (fontFamilyComboBox.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, fontFamilyComboBox.SelectedItem);
            }
        }

        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var property_bold = rtbEditor.Selection.GetPropertyValue(TextElement.FontWeightProperty);
            boldButton.IsChecked = (property_bold != DependencyProperty.UnsetValue) && (property_bold.Equals(FontWeights.Bold));

            var property_italic = rtbEditor.Selection.GetPropertyValue(TextElement.FontStyleProperty);
            italicButton.IsChecked = (property_italic != DependencyProperty.UnsetValue) && (property_italic.Equals(FontStyles.Italic));

            var property_underline = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underlineButton.IsChecked = (property_underline != DependencyProperty.UnsetValue) && (property_underline.Equals(TextDecorations.Underline));

            var property_fontFamily = rtbEditor.Selection.GetPropertyValue(TextElement.FontFamilyProperty);
            fontFamilyComboBox.SelectedItem = property_fontFamily.ToString();

            var property_fontSize = rtbEditor.Selection.GetPropertyValue(TextElement.FontSizeProperty);
            fontSizeComboBox.SelectedItem = property_fontSize;

            var property_fontColor = rtbEditor.Selection.GetPropertyValue(TextElement.ForegroundProperty);
            fontColorPicker.SelectedColor = ((SolidColorBrush)property_fontColor).Color;
        }

        private void trashButton_Click(object sender, RoutedEventArgs e)
        {
            rtbEditor.Document.Blocks.Clear();
        }
    }
}
