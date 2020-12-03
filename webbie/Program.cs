using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Drawing; 

namespace webbie
{

    class Program
    {

        public static void SaveImageToFile(string prefix, string uriPath)
        {
            Console.WriteLine("Saving image to file");            
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            Directory.CreateDirectory(Path.Combine(startupPath, @$"sample-images\{prefix}\"));
            string randName = Path.GetRandomFileName();           
            string outputFile = Path.Combine(startupPath, @$"sample-images\{prefix}\" + randName.Substring(0,randName.IndexOf(".")) + ".jpeg");
            using (var http = new HttpClient())
            {                
                http.DefaultRequestHeaders.Add("Accept", "*/*");

                //Hush hush we are acting as regular users browser...
                http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.67 Safari/537.36 Edg/87.0.664.47");

                var response = http.GetAsync(uriPath).Result;                                
                var data = response.Content.ReadAsStreamAsync().Result;
                try
                {
                    using (Image image = Image.FromStream(data))
                    {
                        image.Save(outputFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                catch
                {
                    Console.WriteLine($"Unexpected error saving JPEG image file. {uriPath}");
                }
               
            }            
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program.");
            Console.WriteLine("Enter discogs url: ");
            string url = Console.ReadLine();

            string startupPath = System.IO.Directory.GetCurrentDirectory();
            Directory.CreateDirectory(Path.Combine(startupPath, @"html-source\"));
            string inputTitle = $"discogs-{Guid.NewGuid().ToString().Substring(0, 4)}"; 
            string inputFile = Path.Combine(startupPath, @$"html-source\{inputTitle}.txt"); 

            using (var http = new HttpClient())
            {
                Console.WriteLine($"Fetching data from {url}.");
                var response = http.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                using (StreamWriter streamWriter = new StreamWriter(inputFile, false, System.Text.Encoding.UTF8, content.Length))
                {
                    streamWriter.Write(content);
                    streamWriter.Flush();
                }
                Console.WriteLine($"Data saved to file {inputFile}");
            }

            using (StreamReader streamReader = new StreamReader(inputFile))
            {
                var content = streamReader.ReadToEndAsync().Result;
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(content);

                Console.WriteLine("Analyzing html...");
                IEnumerable<string> imageSources = new List<string>(); 
                var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='search_results'][1]");
                var imageElements = htmlBody.SelectNodes("//img");
                foreach (var i in imageElements)
                {
                    var attrs = i.GetAttributes("data-src");
                    if(attrs != null)
                    {
                        var imgs = attrs.Where(a => a != null).Select(a => a.Value).ToList();
                        imageSources = imageSources.Concat(imgs);
                    }                        
                }
                var imageArray = imageSources.ToArray(); 
                Console.WriteLine("Number of images found: " + imageArray.Length);
                
                for(int i = 0; i < imageArray.Length; i++)
                {
                    SaveImageToFile(inputTitle, imageArray[i]);
                    Console.WriteLine(i + ": " + imageArray[i]);
                }                
                
            }
        }
    }
}
