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

        public static void SaveImageToFile(string uriPath)
        {
            Console.WriteLine("Saving image to file");
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string randName = Path.GetRandomFileName();           
            string inputFile = Path.Combine(startupPath, @"sample-images\" + randName.Substring(0,randName.IndexOf(".")) + ".jpeg");
            using (var http = new HttpClient())
            {

                var response = http.GetAsync(uriPath).Result;                                
                var data = response.Content.ReadAsByteArrayAsync().Result;
                
                //TODO: Save data to image file.
                //using (MemoryStream stream = new MemoryStream(data)) {
                //    Image image = Image.FromStream(stream,true,true);
                //    image.Save(inputFile, System.Drawing.Imaging.ImageFormat.Jpeg); 
                //}

            }            
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program.");
            Console.WriteLine("Enter discogs url: ");
            string url = Console.ReadLine();

            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string inputFile = Path.Combine(startupPath, @$"image-sources\discogs-{Guid.NewGuid().ToString().Substring(0,4)}.txt"); 

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
                Console.WriteLine("Number of images found: " + imageSources.Count());

                Directory.CreateDirectory(Path.Combine(startupPath, @"sample-images\"));
                foreach (var s in imageSources)
                {
                    //SaveImageToFile(imageSources.ToArray()[0]);
                    Console.WriteLine(s);
                }                
                
            }
        }
    }
}
