using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.Json;
using System.Xml.Linq;

namespace WcfRestClient
{
    class Program
    {
        public static string JsonTextSerializer(string unPrettyJson)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

            return JsonSerializer.Serialize(jsonElement, options);
        }

        private static string XmlTextSerializer(string unPrettyXml)
        {
            try
            {
                XDocument doc = XDocument.Parse(unPrettyXml);
                return doc.ToString();
            }
            catch (Exception)
            {
                return unPrettyXml;
            }
        }

        static void Main(string[] args)
        {
            do
            {
                try
                {
                    WriteLine("Podaj URL Serwisu:");
                    string url = ReadLine();
                    

                    WriteLine("Dostępne opcje (podaj nazwe):");
                    WriteLine("1. - CREATE - dodawanie nowej ksiazki");
                    WriteLine("2. - READ - sprawdzanie danych na temat ksiazki");
                    WriteLine("3. - UPDATE - dodawanie nowej ksiazki");
                    WriteLine("4. - DELETE - usuwanie ksiazki z bazy");
                    string method = ReadLine();

                    WriteLine("Podaj format (xml lub json):");
                    string format = ReadLine();
                    

                    HttpWebRequest req;

                    switch (method.ToUpper())
                    {
                        case "READ":
                            WriteLine("Podaj id interesującej ksiązki lub 'all': ");
                            string id = ReadLine();
                            string uri;
                            if (format.ToLower() == "xml")
                            {
                                if (id == "all")
                                {
                                    uri = url + "/Books";
                                }
                                else
                                {
                                    uri = url + "/Books/" + id;
                                }
                                req = WebRequest.Create(uri) as HttpWebRequest;
                                req.ContentType = "text/xml";
                            }
                            else
                            {
                                if (id == "all")
                                {
                                    uri = url + "/json/Books";
                                }
                                else
                                {
                                    uri = url + "/json/Books/" + id;
                                }
                                req = WebRequest.Create(uri) as HttpWebRequest;
                                req.ContentType = "application/json";
                            }
                            req.KeepAlive = false;
                            req.Method = "GET";
                            if (format.ToLower() == "xml")
                                req.ContentType = "text/xml";
                            else 
                            {
                                req.ContentType = "application/json";
                            };
                            break;
                        case "CREATE":
                            if (format.ToLower() == "xml")
                            {
                                uri = url + "/Books";
                                req = WebRequest.Create(uri) as HttpWebRequest;
                                req.ContentType = "text/xml";
                            }
                            else
                            {
                                uri = url + "/json/Books";
                                req = WebRequest.Create(uri) as HttpWebRequest;
                                req.ContentType = "application/json";
                            };
                            req.Credentials = new NetworkCredential("username", "password");
                            WriteLine("Wklej zawartosc XML-a lub JSON-a (w jednej linii !)");
                            string dane = ReadLine();

                            byte[] bufor = Encoding.UTF8.GetBytes(dane);
                            req.ContentLength = bufor.Length;
                            Stream postData = req.GetRequestStream();
                            postData.Write(bufor, 0, bufor.Length);
                            postData.Close();

                            req.KeepAlive = false;
                            req.Method = "POST";
                            if (format.ToLower() == "xml")
                                req.ContentType = "text/xml";
                            else
                            {
                                req.ContentType = "application/json";
                            };
                            break;
                        case "UPDATE":
                            WriteLine("Podaj id interesującej ksiązki do zmiany: ");
                            id = ReadLine();
                            if (format.ToLower() == "xml")
                            {
                                uri = url + "/Books/" + id;
                                req = WebRequest.Create(uri) as HttpWebRequest;
                                req.ContentType = "text/xml";
                            }
                            else
                            {
                                uri = url + "/json/Books/" + id;
                                req = WebRequest.Create(uri) as HttpWebRequest;
                                req.ContentType = "application/json";
                            };
                            req.Credentials = new NetworkCredential("username", "password");
                            WriteLine("Wklej zawartosc XML-a lub JSON-a (w jednej linii!)");
                            dane = ReadLine();

                            bufor = Encoding.UTF8.GetBytes(dane);
                            req.ContentLength = bufor.Length;
                            req.KeepAlive = false;
                            req.Method = "PUT";
                            Stream putData = req.GetRequestStream();
                            putData.Write(bufor, 0, bufor.Length);
                            putData.Close();
                            break;
                        case "DELETE":
                            WriteLine("Podaj id książki do usunięcia: ");
                            id = ReadLine();
                            if (format.ToLower() == "xml")
                            {
                                uri = url + "/Books/" + id;
                                req = WebRequest.Create(uri) as HttpWebRequest;
                                req.ContentType = "text/xml";
                            }
                            else
                            {
                                uri = url + "/json/Books/" + id;
                                req = WebRequest.Create(uri) as HttpWebRequest;
                                req.ContentType = "application/json";
                            };
                            req.Method = "DELETE";
                            req.Credentials = new NetworkCredential("username", "password");
                            break;
                        default:
                            req = WebRequest.Create(url) as HttpWebRequest;
                            break;
                    }

                    HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                    Encoding enc = System.Text.Encoding.GetEncoding(1252);
                    StreamReader responseStream = new StreamReader(resp.GetResponseStream(), enc);
                    string responseString = responseStream.ReadToEnd();
                    responseStream.Close();
                    resp.Close();
                    if(format.ToLower() == "xml")
                    {
                        WriteLine(XmlTextSerializer(responseString));
                    } 
                    else
                    {
                        WriteLine(JsonTextSerializer(responseString));
                    }
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
                WriteLine("\nDo you want to continue?");
            } while (ReadLine().ToUpper() == "Y");
        }

    }
}
