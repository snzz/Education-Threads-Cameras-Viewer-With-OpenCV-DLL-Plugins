using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Reflection;
using System.Drawing.Imaging;

namespace SoftEngineering_lab_2
{
    //API in short:
    //GetPluginFunctionName - Возвращает названия функции в плагине
    //GetFunctionType - Возвращает тип возвращаемый функцией и количество, типы её параметров
    //GetGUIComponentsNames - Возвращает имена графических компонентов, необходимых для работы плагина
    //GetGUISettings - Параметры для создания графических компонентов

    static class PluginsEditor
    {
        static public string[] currentGUIComponents = new string[0];
        static private string[] currentGUISettings = new string[0];
        static private int valuesComponentsCount;

        static public bool LoadPluginsInListBox(string path, ListBox listBox)
        {
            string[] filesNames = Directory.GetFiles(path, "*.dll");

            for (int i = 0; i < filesNames.Length; i++)
                if (IsPluginCorrect(filesNames[i]))
                    listBox.Items.Add(Path.GetFileName(filesNames[i]));

            if (filesNames.Length != 0) return true; 
            return false;
        }

        static public void DrawPluginGUI(string pluginName, GroupBox pluginGUIPanel)
        {
            IntPtr hLib = LoadLibrary(pluginName);

            IntPtr pProc = GetProcAddress(hLib, "GetGUIComponentsNames");
            ApiFunctionType_void_StringBuilder getComponentsNames =
                (ApiFunctionType_void_StringBuilder)Marshal.GetDelegateForFunctionPointer(
                            pProc, typeof(ApiFunctionType_void_StringBuilder));
            var sb = new StringBuilder(1000);
            getComponentsNames(sb);
            currentGUIComponents = sb.ToString().Split(';');

            pProc = GetProcAddress(hLib, "GetGUISettings");
            ApiFunctionType_void_StringBuilder getSettings =
                (ApiFunctionType_void_StringBuilder)Marshal.GetDelegateForFunctionPointer(
                            pProc, typeof(ApiFunctionType_void_StringBuilder));
            getSettings(sb);
            currentGUISettings = sb.ToString().Split('|');
            valuesComponentsCount = 0;

            for (int i = 0; i < currentGUIComponents.Length; i++)
            {
                string[] settings = currentGUISettings[i].Split(';');

                switch (currentGUIComponents[i])
                {
                    case "TextBox":
                        {
                            TextBox tb = new TextBox();
                            int x = Convert.ToInt32(settings[0]),
                                y = Convert.ToInt32(settings[1]);
                            pluginGUIPanel.Controls.Add(tb);
                            tb.Location = new System.Drawing.Point(x, y);
                            tb.Name = "PluginTextBox" + i.ToString();
                            valuesComponentsCount++;

                            break;
                        }
                    case "TrackBar":
                        {
                            TrackBar trb = new TrackBar();
                            int x = Convert.ToInt32(settings[0]),
                                y = Convert.ToInt32(settings[1]);
                            pluginGUIPanel.Controls.Add(trb);
                            trb.Location = new System.Drawing.Point(x, y);
                            trb.Minimum = Convert.ToInt32(settings[2]);
                            trb.Maximum = Convert.ToInt32(settings[3]);
                            trb.TickFrequency = Convert.ToInt32(settings[4]);
                            trb.Width = Convert.ToInt32(settings[5]);
                            trb.Height = Convert.ToInt32(settings[6]);
                            trb.LargeChange = Convert.ToInt32(settings[7]);
                            trb.Name = "PluginTrackBar" + i.ToString();
                            valuesComponentsCount++;

                            break;
                        }
                    case "Label":
                        {
                            Label l = new Label();
                            int x = Convert.ToInt32(settings[0]),
                                y = Convert.ToInt32(settings[1]);
                            pluginGUIPanel.Controls.Add(l);
                            l.Location = new System.Drawing.Point(x, y);
                            l.Text = settings[2];
                            l.Name = "PluginLabel" + i.ToString();

                            break;
                        }
                    case "RadioButton":
                        {
                            RadioButton rb = new RadioButton();
                            int x = Convert.ToInt32(settings[0]),
                                y = Convert.ToInt32(settings[1]);
                            pluginGUIPanel.Controls.Add(rb);
                            rb.Location = new System.Drawing.Point(x, y);
                            rb.Text = settings[2];
                            rb.Name = "PluginRadioButton" + i.ToString();
                            valuesComponentsCount++;

                            break;
                        }
                    case "CheckBox":
                        {
                            CheckBox cb = new CheckBox();
                            int x = Convert.ToInt32(settings[0]),
                                y = Convert.ToInt32(settings[1]);
                            pluginGUIPanel.Controls.Add(cb);
                            cb.Location = new System.Drawing.Point(x, y);
                            cb.Text = settings[2];
                            cb.Name = "PluginCheckBox" + i.ToString();
                            valuesComponentsCount++;

                            break;
                        }
                }
            }
        }

        static public void ClearPluginGui(GroupBox pluginGUIPanel)
        {
            for (int i = 0; i < currentGUIComponents.Length; i++)
            {
                switch (currentGUIComponents[i])
                {
                    case "TextBox":
                        {
                            TextBox tb = pluginGUIPanel.Controls["PluginTextBox" + 
                                i.ToString()] as TextBox;
                            pluginGUIPanel.Controls.Remove(tb);
                            tb.Dispose();

                            break;
                        }
                    case "TrackBar":
                        {
                            TrackBar trb = pluginGUIPanel.Controls["PluginTrackBar" + 
                                i.ToString()] as TrackBar;
                            pluginGUIPanel.Controls.Remove(trb);
                            trb.Dispose();

                            break;
                        }
                    case "Label":
                        {
                            Label l = pluginGUIPanel.Controls["PluginLabel" + 
                                i.ToString()] as Label;
                            pluginGUIPanel.Controls.Remove(l);
                            l.Dispose();

                            break;
                        }
                    case "RadioButton":
                        {
                            RadioButton rb = pluginGUIPanel.Controls["PluginRadioButton" + 
                                i.ToString()] as RadioButton;
                            pluginGUIPanel.Controls.Remove(rb);
                            rb.Dispose();

                            break;
                        }
                    case "CheckBox":
                        {
                            CheckBox cb = pluginGUIPanel.Controls["PluginCheckBox" +
                                i.ToString()] as CheckBox;
                            pluginGUIPanel.Controls.Remove(cb);
                            cb.Dispose();

                            break;
                        }
                }
            }
        }

        static public Image ApplyPluginAction(string pluginName, Image image, GroupBox pluginGUIPanel)
        {
            IntPtr hLib = LoadLibrary(pluginName);
            var sb = new StringBuilder(1000);

            IntPtr pProc = GetProcAddress(hLib, "GetPluginFunctionName");
            ApiFunctionType_void_StringBuilder getFunctionName = 
                (ApiFunctionType_void_StringBuilder)Marshal.GetDelegateForFunctionPointer(
                            pProc, typeof(ApiFunctionType_void_StringBuilder));
            getFunctionName(sb);
            string name = sb.ToString();

            pProc = GetProcAddress(hLib, "GetFunctionType");
            ApiFunctionType_void_StringBuilder getFunctionType =
                (ApiFunctionType_void_StringBuilder)Marshal.GetDelegateForFunctionPointer(
                            pProc, typeof(ApiFunctionType_void_StringBuilder));
            getFunctionType(sb);
            string type = sb.ToString();

            pProc = GetProcAddress(hLib, name);
            string[] values = GetValuesFromPluginGUI(pluginGUIPanel);

            switch(type)
            {
                case "2":
                    {
                        using (var ms = new MemoryStream(ImageToByte(image)))
                        {
                            Bitmap bm = new Bitmap(Image.FromStream(ms));
                            var ms2 = new MemoryStream();
                            bm.Save(ms2, ImageFormat.Bmp);

                            byte[] ms2_byte = ms2.ToArray();
                            string size = ms2_byte.Length.ToString();

                            var funct = (PluginFunctionType_Two)Marshal.GetDelegateForFunctionPointer(
                                pProc, typeof(PluginFunctionType_Two));
                            IntPtr result = funct(ms2_byte, size);
                            ms2.Close();

                            return Image.FromHbitmap(result);
                        }
                    }
                case "3":
                    {
                        using (var ms = new MemoryStream(ImageToByte(image)))
                        {
                            Bitmap bm = new Bitmap(Image.FromStream(ms));
                            var ms2 = new MemoryStream();
                            bm.Save(ms2, ImageFormat.Bmp);

                            byte[] ms2_byte = ms2.ToArray();
                            string size = ms2_byte.Length.ToString();

                            var funct = (PluginFunctionType_Tree)Marshal.GetDelegateForFunctionPointer(
                                pProc, typeof(PluginFunctionType_Tree));
                            IntPtr result = funct(ms2_byte, size, values[0]);
                            ms2.Close();

                            return Image.FromHbitmap(result);
                        }
                    }
                case "4A":
                    {
                        using (var ms = new MemoryStream(ImageToByte(image)))
                        {
                            Bitmap bm = new Bitmap(Image.FromStream(ms));
                            var ms2 = new MemoryStream();
                            bm.Save(ms2, ImageFormat.Bmp);

                            byte[] ms2_byte = ms2.ToArray();
                            string size = ms2_byte.Length.ToString();
                            
                            var funct = (PluginFunctionType_FourA)Marshal.GetDelegateForFunctionPointer(
                                pProc, typeof(PluginFunctionType_FourA));
                            IntPtr result = funct(ms2_byte, size, values[0], values[1]);
                            ms2.Close();

                            return Image.FromHbitmap(result);
                        }
                    }
                case "4B":
                    {
                        using (var ms = new MemoryStream(ImageToByte(image)))
                        {
                            Bitmap bm = new Bitmap(Image.FromStream(ms));
                            var ms2 = new MemoryStream();
                            bm.Save(ms2, ImageFormat.Bmp);

                            byte[] ms2_byte = ms2.ToArray();
                            string size = ms2_byte.Length.ToString();

                            var funct = (PluginFunctionType_FourB)Marshal.GetDelegateForFunctionPointer(
                                pProc, typeof(PluginFunctionType_FourB));
                            IntPtr result = funct(ms2_byte, size, values[0], values[1]);
                            ms2.Close();

                            return Image.FromHbitmap(result);
                        }
                    }
            }

            return image;
        }

        static public string GetPluginDescription(string pluginName)
        {
            IntPtr hLib = LoadLibrary(pluginName);
            var sb = new StringBuilder(1000);

            IntPtr pProc = GetProcAddress(hLib, "GetPluginDescription");
            ApiFunctionType_void_StringBuilder getFunctionName =
                (ApiFunctionType_void_StringBuilder)Marshal.GetDelegateForFunctionPointer(
                            pProc, typeof(ApiFunctionType_void_StringBuilder));
            getFunctionName(sb);

            return sb.ToString();
        }

        static private string[] GetValuesFromPluginGUI(GroupBox pluginGUIPanel)
        {
            string[] values = new string[valuesComponentsCount];
            int valuesComps = 0;

            for (int i = 0; i < currentGUIComponents.Length && 
                valuesComps != valuesComponentsCount; i++)
            {
                switch (currentGUIComponents[i])
                {
                    case "TextBox":
                        {
                            TextBox tb = pluginGUIPanel.Controls["PluginTextBox" +
                                i.ToString()] as TextBox;
                            values[valuesComps] = tb.Text;
                            valuesComps++;

                            break;
                        }
                    case "TrackBar":
                        {
                            TrackBar trb = pluginGUIPanel.Controls["PluginTrackBar" +
                                i.ToString()] as TrackBar;
                            values[valuesComps] = trb.Value.ToString();
                            valuesComps++;

                            break;
                        }
                    case "RadioButton":
                        {
                            RadioButton rb = pluginGUIPanel.Controls["PluginRadioButton" +
                                i.ToString()] as RadioButton;
                            values[valuesComps] = rb.Checked.ToString();
                            valuesComps++;

                            break;
                        }
                    case "CheckBox":
                        {
                            CheckBox cb = pluginGUIPanel.Controls["PluginCheckBox" +
                                i.ToString()] as CheckBox;
                            values[valuesComps] = cb.Checked.ToString();
                            valuesComps++;

                            break;
                        }
                }
            }

            return values;
        }

        static private bool IsPluginCorrect(string pluginName)
        {
            IntPtr hLib = LoadLibrary(pluginName);
            if (hLib == IntPtr.Zero) MessageBox.Show(pluginName);
            IntPtr pProc = GetProcAddress(hLib, "GetPluginFunctionName");
            if (pProc == IntPtr.Zero) return false;
            
            return true;
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        //API Types
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int ApiFunctionType_int_nothing();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate string ApiFunctionType_string_nothing();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate string ApiFunctionType_string_string();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate string[] ApiFunctionType_stringArray_nothing();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate void ApiFunctionType_void_StringBuilder(StringBuilder str);

        //Plugin main function types
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PluginFunctionType_Two(byte[] image, string dataLen);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PluginFunctionType_Tree(byte[] image, string dataLen, string str);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PluginFunctionType_FourA(byte[] image, string dataLen, string str1, string str2);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PluginFunctionType_FourB(byte[] image, string dataLen, string str, string flag);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(
            out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(
            out long lpFrequency);

        [DllImport("kernel32")]
        public static extern IntPtr LoadLibrary(
            string path);

        [DllImport("kernel32")]
        public static extern IntPtr GetProcAddress(
            IntPtr libraryHandle,
            string symbolName);

        [DllImport("kernel32")]
        public static extern bool FreeLibrary(
            IntPtr libraryHandle);
    }
}
