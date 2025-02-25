using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using System.Globalization;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;
using doeArenaAPI.Model;


namespace doeArenaAPI.Services
{
    public interface IdoeArenaService
    {
        Task<List<DoeArena>> doeArenaValores();

    }
    public class doeArenaService : IdoeArenaService
    {
        private long moneyToLong(string valorSujo)
        {
            string valorLimpo = valorSujo.Replace("R$", "").Trim(); // Remove "R$"
            valorLimpo = valorLimpo.Replace(
                ".", "").Replace(",", "."); // Ajusta separadores

            decimal valorDecimal = decimal.Parse(valorLimpo, CultureInfo.InvariantCulture);
            return (long)(valorDecimal * 100); // Converte para centavos
        }

        private string longToMoney(long longzin)
        {
            string valorFormatado = $"R$ {(longzin / 100.0).ToString("N2", new CultureInfo("pt-BR"))}";
            return valorFormatado;
        }

        public async Task<List<DoeArena>> doeArenaValores()
        {
            string valorAtual;
            string proximaAtualizacao = "";
            string ultimaAtualizacao = "";

            ChromeOptions options = new ChromeOptions();
            // Roda em modo invisível
            options.AddArgument("--headless");
            // Evita detecção como bot
            options.AddArgument("--disable-blink-features=AutomationControlled");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://www.doearenacorinthians.com.br");

                System.Threading.Thread.Sleep(5000);

                string html = driver.PageSource;

                driver.Quit();

                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'goal-raised__moment')]");
                string valorSujo = node.InnerText;
                valorAtual = Regex.Replace(valorSujo, @"\&nbsp;", "").Trim();


                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'goal-raise__update')]/p");

                if (nodes != null && nodes.Count >= 2)
                {
                    ultimaAtualizacao = nodes[0].InnerText.Trim();
                    proximaAtualizacao = nodes[1].InnerText.Trim();
                }

            }
            long metaLong = 70000000000;
            long quantoFaltaLong = metaLong - (moneyToLong(valorAtual));

            List<DoeArena> list = new List<DoeArena>();

            DoeArena doeArena = new ()
            {
                arrecadadoAtual = valorAtual,
                dataAtualizacao = ultimaAtualizacao,
                dataProximaAtualizacao = proximaAtualizacao,
                meta = longToMoney(metaLong),
                quantoFalta = longToMoney(quantoFaltaLong)
            
            };

            list.Add(doeArena);

            return list;

        }
        
    }
}
