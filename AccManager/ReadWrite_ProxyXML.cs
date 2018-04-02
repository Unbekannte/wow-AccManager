using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static AccManager.Logg;
using static AccManager.myProxy;

namespace AccManager
{
    class ReadWrite_ProxyXML
    {
        static public void deleteTop_Rule_Ever_and_hisProxy(XDocument doc)
        {
            if (checkTop_Rule_Ever(doc))
            {
                IEnumerable<XElement> rules = doc.Root.Elements("RuleList").Descendants("Rule").Where(t => t.Element("Name").Value == "Top_Rule_Ever").ToList();
                foreach (XElement t in rules)
                {
                    try
                    {
                        XElement prox = doc.Root.Element("ProxyList").Elements("Proxy").Where(a => a.Attribute("id").Value == t.Element("Action").Value).First();
                        prox.Remove();
                    }
                    catch (Exception)
                    {
                        Log("связанные с этим правилом прокси не найдены");
                    }
                    t.Remove();
                }
                deleteCrap_Defaults(doc);
                //doc.Save(path);
            }
        }

        static public void deleteProxyes777(XDocument doc)
        {
            IEnumerable<XElement> rules = doc.Root.Elements("ProxyList").Descendants("Proxy").Where(t => t.Attribute("id").Value == "777").ToList();
            foreach (XElement t in rules)
            {
                t.Remove();
            }
            //doc.Save(path);
        }

        static public void deleteTop_Rule_Ever(XDocument doc)
        {
            if (checkTop_Rule_Ever(doc))
            {
                IEnumerable<XElement> rules = doc.Root.Elements("RuleList").Descendants("Rule").Where(t => t.Element("Name").Value == "Top_Rule_Ever").ToList();
                foreach (XElement t in rules)
                {
                    t.Remove();
                }
                deleteCrap_Defaults(doc);
                //doc.Save(path);
            }
        }

        static public void deleteCrap_Defaults(XDocument doc)
        {
            IEnumerable<XElement> rules = doc.Root.Elements("RuleList").Descendants("Rule").Where(t => t.Element("Name").Value == "Default").ToList();
            foreach (XElement t in rules)
            {
                try
                {
                    t.Remove();
                }
                catch (Exception)
                {

                    //throw;
                }
            }
        }


        static public void printNameId_value(XDocument doc)
        {
            // richTextBox1.Clear();
            //XDocument doc = XDocument.Load(path);
            Log("Proxies :");
            foreach (XElement el in doc.Root.Elements("ProxyList").Elements("Proxy"))
            {
                //   var sss = el.FirstNode.ToString();
                Log($"id = {el.Attribute("id").Value} \t {el.Element("Address").Value} \t" + findRules(doc, el.Attribute("id").Value));
            }
            /*Log("Rules :");
            foreach (XElement el in doc.Root.Elements("RuleList").Elements("Rule"))
            {
                try { Log($"id = {el.Element("Action").Value} \t <{el.Element("Name").Value}> \t {el.Element("Applications").Value}"); }
                catch (Exception) {}
            }*/
        }

        static public string findRules(XDocument doc, string _id)
        {
            var result = "";
            var rulesARR = doc.Root.Elements("RuleList").Elements("Rule");
            foreach (var el in rulesARR)
            {
                if (el.Element("Action").Value == _id)
                {
                    result += "\t>> ";
                    if (!string.IsNullOrEmpty(result))
                        result += "  ";
                    result += el.Element("Applications").Value;
                }

            }
            return result;
        }

        static public bool checkTop_Rule_Ever(XDocument doc)
        {
            //XDocument doc = XDocument.Load(path);

            foreach (XElement el in doc.Root.Elements("RuleList").Elements("Rule"))
            {
                if (el.Element("Name").Value == "Top_Rule_Ever")
                    return true;
            }
            return false;
        }

        static public bool checkProxyServerByAdress(XDocument doc, string address)
        {
            //XDocument doc = XDocument.Load(path);

            foreach (XElement el in doc.Root.Elements("ProxyList").Elements("Proxy"))
            {
                if (el.Element("Address").Value == address)
                    return true;
            }
            return false;
        }


        static public string getProxyID_byAddress(XDocument doc, string address)
        {
            return doc.Root.Element("ProxyList").Elements("Proxy").Where(a => a.Element("Address").Value == address).First().Attribute("id").Value;
        }

        //true - если добавил, false - если уже существует
        static public bool addProxy(XDocument doc, myProxy proxx, string _id = "777", string options = "48")
        {
            if (!checkProxyServerByAdress(doc, proxx.Adress))
            {
                // XDocument doc = XDocument.Load(path);
                XElement proxList = doc.Root.Element("ProxyList"); // new XElement("ProxyList");
                //int maxId = doc.Root.Elements("track").Max(t => Int32.Parse(t.Attribute("id").Value));
                XElement prox = new XElement("Proxy",
                    new XAttribute("id", _id),
                    new XAttribute("type", proxx.ProxyType),
                    new XElement("Address", proxx.Adress),
                    new XElement("Port", proxx.Port),
                    new XElement("Options", options),
                    new XElement("Authentication", new XAttribute("enabled", proxx.Auth),
                        new XElement("Username", proxx.Login), new XElement("Password", proxx.Password)));
                proxList.Add(prox);
                //doc.Root.Add();.Elements("ProxyList").Add();
                // doc.Save(path);
                return true;
            }
            else return false;
        }

        static public bool addRule(XDocument doc, string progName = "chrome.exe", string _id = "777")
        {
            //  XDocument doc = XDocument.Load(path);
            XElement ruleList = doc.Root.Element("RuleList");// new XElement("ProxyList");
                                                             //int maxId = doc.Root.Elements("track").Max(t => Int32.Parse(t.Attribute("id").Value));
            XElement rule = new XElement("Rule",
                new XAttribute("enabled", "true"),
                new XElement("Name", "Top_Rule_Ever"),
                new XElement("Applications", progName),
                new XElement("Action", new XAttribute("type", "Proxy"), _id));
            ruleList.Add(rule);
            //doc.Root.Add();.Elements("ProxyList").Add();
            // doc.Save(path);
            return true;
        }
    }
}
