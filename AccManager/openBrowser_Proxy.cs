using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static AccManager.Logg;
using static AccManager.ReadWrite_ProxyXML;

namespace AccManager
{
    class openBrowser_Proxy
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);


        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(
        string lpSymlinkFileName, string lpTargetFileName, SymbolicLink dwFlags);

        enum SymbolicLink
        {
            File = 0,
            Directory = 1
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, IntPtr lpSecurityAttributes);

        private const uint WM_COMMAND = 0x0111;
        private const int BN_CLICKED = 0x00f5;
        private const int BN_QUIT = 0x0012;
        private const int IDOK = 1;
        private const uint WM_CLOSE = 0x0010;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;

        static private void Click_OK_Proxifier()
        {
            Log("");

            if (FindWindow("#32770", "Proxifier") == IntPtr.Zero)
            {
                Log("wait for window...");
                Thread.Sleep(500);
            }

            bool flag = false;

            while (!flag)
            {
                IntPtr hWnd = FindWindow("#32770", "Proxifier"); //  #32770 - класс окна как сказал инспектор
                if (hWnd != IntPtr.Zero)
                {
                    SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    IntPtr hwndChild = FindWindowEx((IntPtr)hWnd, IntPtr.Zero, "Button", "&Да");
                    SendMessage(hwndChild, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
                    SendMessage(hwndChild, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
                    Log("clicked OK!");
                    flag = true;
                }
                Thread.Sleep(500);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string chromeUserData_path = $@"C:\Users\{Environment.UserName}\AppData\Local\Google\Chrome\User Data";
            //чистим юзердату
            if (Directory.Exists(chromeUserData_path))
            {
                Directory.Delete(chromeUserData_path, true);
                Log("folder deleted");
            }
        }

        private void button2_Click(object sender, EventArgs e)  //открыть браузер с прокси
        {
            string Proxifier_Settings_File = $@"C:\Users\{Environment.UserName}\AppData\Roaming\Proxifier\Profiles\Default.ppx";
            XDocument doc = XDocument.Load(Proxifier_Settings_File);
            //собственно само открытие браузера /* openChrome_viaProxy(doc, textBox1.Text, textBox2.Text, Proxifier_Settings_File);*/
        }


        public static void openChrome_viaProxy(XDocument doc, string accMail, myProxy proxx, string Proxifier_Settings_File)
        {
            var deleteProxyFlag = true;

            string chrome_UserData_path = $@"C:\Users\{Environment.UserName}\AppData\Local\Google\Chrome\User Data";
            string acc_UserData_path = $@"C:\Users\{Environment.UserName}\AppData\Local\Google\Chrome\" + accMail + @"\User Data";

            //создать папку почты если ее нет
            if (!Directory.Exists(acc_UserData_path))
            {
                Directory.CreateDirectory(acc_UserData_path);
                Log("mail folder created");
            }

            //чистим юзердату
            if (Directory.Exists(chrome_UserData_path))
            {
                DirectoryInfo di = new DirectoryInfo(chrome_UserData_path);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                Thread.Sleep(50);
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                    }
                    catch (Exception)
                    {
                       // throw;
                    }
                }

                Directory.Delete(chrome_UserData_path, true);
                Log("folder deleted");
            }
            //  string accMail = @"el.pet@ya.ru";       // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //если уже существует юзердата для аккаунта, то перемещаем ее на место юзердаты
            if (Directory.Exists(acc_UserData_path))
            {
                Directory.Move(acc_UserData_path, chrome_UserData_path);
                Log("folder moved");
            }

            //ставим прокси для хрома
            deleteProxyFlag = setProxyServer_and_Rule1(doc, proxx, Proxifier_Settings_File);
            Process.Start($@"C:\Users\{Environment.UserName}\AppData\Roaming\Proxifier\Profiles\Default.ppx");

            Click_OK_Proxifier();   //принимает изменение настроек

            //тпепрь откроем хром
            Log("opening chrome...");
            Process chromeProcess = new Process();
            chromeProcess.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            chromeProcess.Start();
            //и ждем пока нами закроется браузер
            chromeProcess.WaitForExit();
            Log("browser closed, deleting proxy server and rule...");

            //если прокси существовал до нас, то не трогаем его. если прокси добавили мы, то удалим его.
            removeProxyServer_and_Rule(doc, deleteProxyFlag, Proxifier_Settings_File);
            Process.Start($@"C:\Users\{Environment.UserName}\AppData\Roaming\Proxifier\Profiles\Default.ppx");
            Click_OK_Proxifier();   //принимает изменение настроек

            //если есть юзердата в папке хрома, то перемещаем ее на место юзердаты аккаунта
            if (Directory.Exists(chrome_UserData_path))
            {
                try
                {
                    Directory.Move(chrome_UserData_path, acc_UserData_path);
                    Log("folder moved");
                }
                catch (Exception ex)
                {
                    //throw;
                }
                
            }
        }

        public static void openChrome_mainIP(XDocument doc, string accMail, string Proxifier_Settings_File)
        {
            var deleteProxyFlag = true;

            string chrome_UserData_path = $@"C:\Users\{Environment.UserName}\AppData\Local\Google\Chrome\User Data";
            string acc_UserData_path = $@"C:\Users\{Environment.UserName}\AppData\Local\Google\Chrome\" + accMail + @"\User Data";

            //создать папку почты если ее нет
            if (!Directory.Exists(acc_UserData_path))
            {
                Directory.CreateDirectory(acc_UserData_path);
                Log("mail folder created");
            }

            //чистим юзердату
            if (Directory.Exists(chrome_UserData_path))
            {
                DirectoryInfo di = new DirectoryInfo(chrome_UserData_path);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                Thread.Sleep(50);
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                    }
                    catch (Exception)
                    {
                        // throw;
                    }
                }

                Directory.Delete(chrome_UserData_path, true);
                Log("folder deleted");
            }
            //  string accMail = @"el.pet@ya.ru";       // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //если уже существует юзердата для аккаунта, то перемещаем ее на место юзердаты
            if (Directory.Exists(acc_UserData_path))
            {
                Directory.Move(acc_UserData_path, chrome_UserData_path);
                Log("folder moved");
            }
            
            //тпепрь откроем хром
            Log("opening chrome...");
            Process chromeProcess = new Process();
            chromeProcess.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            chromeProcess.Start();
            //и ждем пока нами закроется браузер
            chromeProcess.WaitForExit();
            Log("browser closed, deleting proxy server and rule...");
            
            //если есть юзердата в папке хрома, то перемещаем ее на место юзердаты аккаунта
            if (Directory.Exists(chrome_UserData_path))
            {
                Directory.Move(chrome_UserData_path, acc_UserData_path);
                Log("folder moved");
            }
        }
        /*
        static void openCrome_MainIP(string accMail)
        {
            string chromeUserData_path = $@"C:\Users\{Environment.UserName}\AppData\Local\Google\Chrome\User Data";
            //чистим юзердату
            if (Directory.Exists(chromeUserData_path))
            {
                Directory.Delete(chromeUserData_path, true);
                Log("folder deleted");
            }
            // string accMail = @"herrma";       // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            string accUserData_path = $@"C:\Users\{Environment.UserName}\AppData\Local\Google\Chrome\" + accMail + @"\User Data";

            //если уже существует юзердата для аккаунта, то перемещаем ее на место юзердаты
            if (Directory.Exists(accUserData_path))
            {
                Directory.Move(accUserData_path, chromeUserData_path);
                Log("folder moved");
            }

            //тпепрь откроем хром
            Log("opening chrome...");
            Process chromeProcess = new Process();
            chromeProcess.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            chromeProcess.Start();
            //и ждем пока нами закроется браузер
            chromeProcess.WaitForExit();
            Log("browser closed...");

            Thread.Sleep(3000);

            //если есть юзердата в папке хрома, то перемещаем ее на место юзердаты аккаунта
            if (Directory.Exists(chromeUserData_path))
            {
                Directory.Move(chromeUserData_path, accUserData_path);
                Log("folder moved");
            }
        }
        */
        static bool setProxyServer_and_Rule1(XDocument doc, myProxy proxx, string Proxifier_Settings_File) //true - потом УДАЛЯТЬ ПРОКСИ ; false - потом НЕ УДАЛЯТЬ
        {
            // XDocument doc = XDocument.Load(Proxifier_Settings_File);

            deleteTop_Rule_Ever(doc);
            deleteProxyes777(doc);
           // deleteTop_Rule_Ever_and_hisProxy(doc);
            deleteCrap_Defaults(doc);

            var deleteProxyFLAG = false;
            if (!checkTop_Rule_Ever(doc))
            {

                if (!checkProxyServerByAdress(doc, proxx.Adress))
                {
                    addProxy(doc, proxx, "777");
                    addRule(doc, "chrome.exe", "777");
                    deleteProxyFLAG = true;
                }
                else
                {
                    addRule(doc, "chrome.exe", getProxyID_byAddress(doc, proxx.Adress));
                    deleteProxyFLAG = false;
                }
                doc.Save(Proxifier_Settings_File);
                LogSUCCESSFUL();
                printNameId_value(doc);
            }
            else
            {
                Log("уже записано или еще чета");
                Log("!!!!!! была ошибка    ОБЯЗАТЕЛЬНО ВПРОВЕРИТЬ НАСТРОЙКИ ПРОКСИФАЕРА");
                Log("!!!!!! была ошибка    ОБЯЗАТЕЛЬНО ВПРОВЕРИТЬ НАСТРОЙКИ ПРОКСИФАЕРА");
                Log("!!!!!! была ошибка    ОБЯЗАТЕЛЬНО ВПРОВЕРИТЬ НАСТРОЙКИ ПРОКСИФАЕРА");
                return false;
            }
            return deleteProxyFLAG;
        }
        /*
                bool setProxyServer_and_Rule(string Proxifier_Settings_File, string address)//true - потом УДАЛЯТЬ ПРОКСИ ; false - потом НЕ УДАЛЯТЬ
                {
                    XDocument doc = XDocument.Load(Proxifier_Settings_File);

                    //  removeProxyServer_and_Rule(doc, true); НЕ БУДЕТ РАБОТАЬ БЕЗ ЭТОГО

                    var flag = true;
                    if (!checkTop_Rule_Ever(doc))
                    {
                        bool flagg = addProxy(doc, address, "777");//true - если добавил, false - если уже существует
                        if (flagg)
                        {
                            Log("Log proxy added");
                            addRule(doc, "chrome.exe", "777");
                            flag = true;   //удалять прокси потом
                        }
                        else
                        {//просто добавим правило
                            Log("proxy server alredy exists, trying add the rule for this server...");
                            var proxies = doc.Root.Element("ProxyList").Elements("Proxy");
                            string proxID;
                            foreach (var prox in proxies)
                            {
                                try
                                {
                                    if (prox.Element("Address").Value == address)
                                    {
                                        proxID = prox.Attribute("id").Value;
                                        addRule(doc, "chrome.exe", proxID);
                                        Log("rule created");

                                        break;
                                    }
                                    //proxID = doc.Root.Element("ProxyList").Elements("Proxy").Where(a => a.Element("Address").Value == address).First().Attribute("id").Value;

                                }
                                catch (Exception)
                                {
                                    LogERROR();
                                    // throw;
                                }
                            }

                            flag = false; //не удалять прокси потом
                        }
                        doc.Save(Proxifier_Settings_File);
                        LogSUCCESSFUL();
                        printNameId_value(doc);
                        return flagg;
                    }
                    else
                    {
                        Log("уже записано или еще чета");
                        Log("!!!!!! была ошибка    ОБЯЗАТЕЛЬНО ВПРОВЕРИТЬ НАСТРОЙКИ ПРОКСИФАЕРА");
                        Log("!!!!!! была ошибка    ОБЯЗАТЕЛЬНО ВПРОВЕРИТЬ НАСТРОЙКИ ПРОКСИФАЕРА");
                        Log("!!!!!! была ошибка    ОБЯЗАТЕЛЬНО ВПРОВЕРИТЬ НАСТРОЙКИ ПРОКСИФАЕРА");
                        Log("!!!!!! была ошибка    ОБЯЗАТЕЛЬНО ВПРОВЕРИТЬ НАСТРОЙКИ ПРОКСИФАЕРА");
                        return true;
                    }
                }
                */
        static bool removeProxyServer_and_Rule(XDocument doc, bool deleteProxyFlag, string Proxifier_Settings_File)
        {


            if (checkTop_Rule_Ever(doc))
            {
                if (deleteProxyFlag)
                {
                    deleteTop_Rule_Ever_and_hisProxy(doc);
                    Log("удалено");
                }
                else
                {
                    deleteTop_Rule_Ever(doc);
                    Log("удалено");
                }
                deleteCrap_Defaults(doc);
                printNameId_value(doc);
                doc.Save(Proxifier_Settings_File);
                return true;
            }
            else
            {
                Log("не найдено");
                return false;
            }
        }

    }
}
