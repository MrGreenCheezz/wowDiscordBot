using Discord.Commands;
using HtmlAgilityPack;
using System.Windows.Form;


namespace DiscordBot
{
    public class GetStats : ModuleBase<SocketCommandContext>
    {

        [Command("guide")]
        [Summary("Get guide for character")]
        public async Task GetGuide(string CharClass, string specialization)
        {
            await GetStatsPage(CharClass, specialization);
        }

        //html request to get stats
        public async Task GetStatsPage(string CharClass, string specialization)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.murlok.io/" + CharClass + "/" + specialization + "/mm+#stats");
            //HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//div[@class='heading']").ToArray();
            Console.WriteLine(doc.Text);
            // foreach (HtmlNode item in nodes)
            // {
            //     Console.WriteLine(item.InnerHtml);
            // }
        }

        private void LoadHtmlWithBrowser(String url)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(url);

            waitTillLoad(this.webBrowser1);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            var documentAsIHtmlDocument3 = (mshtml.IHTMLDocument3)webBrowser1.Document.DomDocument;
            StringReader sr = new StringReader(documentAsIHtmlDocument3.documentElement.outerHTML);
            doc.Load(sr);
        }

        private void waitTillLoad(WebBrowser webBrControl)
        {
            WebBrowserReadyState loadStatus;
            int waittime = 100000;
            int counter = 0;
            while (true)
            {
                loadStatus = webBrControl.ReadyState;
                Application.DoEvents();
                if ((counter > waittime) || (loadStatus == WebBrowserReadyState.Uninitialized) || (loadStatus == WebBrowserReadyState.Loading) || (loadStatus == WebBrowserReadyState.Interactive))
                {
                    break;
                }
                counter++;
            }

            counter = 0;
            while (true)
            {
                loadStatus = webBrControl.ReadyState;
                Application.DoEvents();
                if (loadStatus == WebBrowserReadyState.Complete && webBrControl.IsBusy != true)
                {
                    break;
                }
                counter++;
            }
        }


    }
}