using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace API_ZeDelivery.Pages
{
    public class ApiPage
    {
        public class APIPage
        {
            public static int id;
            public static string clima;
            public static string descricao;
            public static string txtClima;
            public static string txtDescricao;
            public static string nomeCidade;
            public static int idCidade;
            public static int statusCode;
            public List<Rootobject> rootobjects { get; set; }
            public class Rootobject
            {
                public Coord coord { get; set; }
                public Weather[] weather { get; set; }
                public string _base { get; set; }
                public Main main { get; set; }
                public int visibility { get; set; }
                public Wind wind { get; set; }
                public Rain rain { get; set; }
                public Clouds clouds { get; set; }
                public int dt { get; set; }
                public Sys sys { get; set; }
                public int timezone { get; set; }
                public int id { get; set; }
                public string name { get; set; }
                public int cod { get; set; }
            }

            public class Coord
            {
                public float lon { get; set; }
                public float lat { get; set; }
            }

            public class Main
            {
                public float temp { get; set; }
                public float feels_like { get; set; }
                public float temp_min { get; set; }
                public float temp_max { get; set; }
                public int pressure { get; set; }
                public int humidity { get; set; }
            }

            public class Wind
            {
                public float speed { get; set; }
                public int deg { get; set; }
            }

            public class Rain
            {
                public float _1h { get; set; }
            }

            public class Clouds
            {
                public int all { get; set; }
            }

            public class Sys
            {
                public int type { get; set; }
                public int id { get; set; }
                public string country { get; set; }
                public int sunrise { get; set; }
                public int sunset { get; set; }
            }

            public class Weather
            {
                public int id { get; set; }
                public string main { get; set; }
                public string description { get; set; }
                public string icon { get; set; }
            }
            public void ValidaStatusAPICoordGeografica(string nomeCidades, int idCidades)
            {
                Assert.AreEqual(nomeCidades, nomeCidade);
                Assert.AreEqual(idCidades, idCidade);
                Assert.AreEqual(txtClima, clima);
                Assert.AreEqual(txtDescricao, descricao);
            }

            public void ValidacaoStatusAPI(int status)
            {
                Assert.AreEqual(statusCode, status);
            }
            public void ValidacaoRetornoAPICidade(string nomeCidades)
            {
                Assert.AreEqual(nomeCidades, nomeCidade);
                Assert.AreEqual(txtClima, clima);
                Assert.AreEqual(txtDescricao, descricao);
            }
            public void ValidacaoRetornoAPIIDCidade()
            {
                Assert.AreEqual(txtClima, clima);
                Assert.AreEqual(txtDescricao, descricao);
            }
            public void LerArquivoIdClima()
            {
                var valores = File.ReadAllLines("ID_CLIMA.txt")
                      .Where(l => l.StartsWith(Convert.ToString(id)))
                      .Select(l => l.Substring(l.IndexOf(";") + 1))
                      .ToList();
                string split = Convert.ToString(valores[0]);
                var txtSplit = split.Split(";");
                txtClima = txtSplit[0];
                txtDescricao = txtSplit[1];

            }
        }
    }
}
