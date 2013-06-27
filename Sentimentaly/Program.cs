using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentimentaly
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> results = new List<string>();
            results.Add("O Hotel Sheraton Lisboa é siplesmente maravilhoso: ótima localização, funcionários extremamente prestativos e simpáticos, café da manhã de sonhos e conforto nota 1.000!!! O quarto te convida para relaxamento total!!! Infelizmente, minhas férias acabaram... fiquei triste de ter que abandonar toda esta mordomia e voltar para vida real!!! Com certeza, assim que voltar á lisboa, me hospedarei, sem pestanejar, no Sheraton. parabéns à equipe sensacional deste hotel dos sonhos!!!");
            results.Add("Os Quartos não tinham aquecimento e a lareira deitava fumo. Não havia ninguém na receção quando a central de incerndio disparou. Cozinha mal equipada.");
            results.Add("O espaço envolvente, a piscina e o tamanho das casas");
            results.Add("A recepção fechada à noite não possibilitando o usufruto do Bar/sala de convívio.");
            results.Add("Tudo bastante bom.");
            results.Add("As vivendas são de estilo moderno e bastante recentes. Estão decoradas de uma forma simples, mas com gosto. A janela da sala abre-se para o jardim, onde se pode manter o contacto com a natureza e ao mesmo tempo ter alguma privacidade. O resort é ideal para quem pretende passar um fim de samana ou férias tranquilas e com pouca confusão. A praia fica a cerca de 15m a pé e por isso, quem tem crianças será aconselhável levar transporte.");
            results.Add("Apenas dizer que os quartos standard ,são pouco espaçosos. Mas ,têm o conforto qb.");
            results.Add("De todo");
            results.Add("De tudo. O acolhimento foi muito bom. E o pequeno almoço excelente.");
            results.Add("Os preços do Mini-Bar são incomportáveis penso que deveriam ser cobrados valores em conformidade com o mercado normal, com os preços existentes é impossível consumir qualquer coisa do mesmo, se os preços se dirigem aos estrangeiros então deveria haver preços para os portugueses diferentes");
            results.Add("O hotel é realmente o que mostram as fotos. É lindo, confortável, com muitas atividades como spa, vários restaurantes/bar, piscina, lindos lugares para relaxamento. A vista dos quartos de frente para o mar é maravilhosa. A praia a qual o hotel oferece acesso é linda e tem um ótimo restaurante. Não é preciso sair do hotel para se divertir. Café da manhã maravilhoso. Recomendadíssimo.");
            results.Add("Penso que nos dias de hoje, com as temperaturas do Algarve, é inadmissível não haver um pequeno frigorífico nos quartos. Mesmo sabendo quje estava num 3 estrelas, entendo que os preços são de 4 estrelas, pelo que deveriam melhorar qualitativamente os pequenos almoços. No tempo de generalização da televisão por cabo, não se entende que estejam tão limitados em termos de canais disponíveis nas televisões dos quartos.");
            
            SentimentalAnalyser analyzer = new SentimentalAnalyser();
            SentimentalInfo info;

            foreach (var item in results)
            {
                info = analyzer.Analyze(item);

                Console.WriteLine("");
                Console.WriteLine(item);
                Console.WriteLine("Sore: " + info.Score);
                Console.WriteLine("Comparative: " + info.Comparative);

                if (info.Comparative == 0)
                {
                    Console.WriteLine("Resultado: Neutro");
                }
                else
                {
                    if (info.Comparative > 0)
                    {
                        Console.WriteLine("Resultado: Positivo");
                    }
                    else
                    {
                        Console.WriteLine("Resultado: Negativo");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
