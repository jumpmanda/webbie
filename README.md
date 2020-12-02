# webbie

### .NET Core 3.1 Console app to web crawl for images



 Enter Discogs search results page URL and retrieve image source URLs
 
```
 Example output: 
 
  Starting program.
  Enter discogs url:
  https://www.discogs.com/search/?q=kacey+musgraves+golden+hour&type=all
  Fetching data from https://www.discogs.com/search/?q=kacey+musgraves+golden+hour&type=all.
  Data saved to file C:\Users\amand\source\repos\webbie\webbie\bin\Debug\netcoreapp3.1\image-sources\discogs-2d63.txt
  Analyzing html...
  Number of images found: 19
  https://img.discogs.com/6FbuAJqyghOFaOnhi7rCFFlnAFk=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-11776682-1546028719-8940.jpeg.jpg
  https://img.discogs.com/osuBzJwXxStcPGXa511x7kPHhm8=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-11781019-1524873763-6182.jpeg.jpg
  https://img.discogs.com/4LtqblbdZ3GMwqZmNYBqPGspCu8=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-11960013-1525524294-2732.jpeg.jpg
  https://img.discogs.com/tsvDxaf6CIM-DymprovuIRNnj5Y=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-14172023-1569195943-7366.jpeg.jpg
  https://img.discogs.com/j0GYzz-Pwv7B4dzxICLlxOyOapo=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-14163755-1585045990-6858.jpeg.jpg
  https://img.discogs.com/6FbuAJqyghOFaOnhi7rCFFlnAFk=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-11776682-1546028719-8940.jpeg.jpg
  https://img.discogs.com/uGuYYceBQGu8ONzUKDUUB7iZfjs=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-12761740-1541445761-8806.jpeg.jpg
  https://img.discogs.com/IBmqXtAdFbu-E1xONZd0DA2T6So=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-13867130-1562913798-1199.jpeg.jpg
  https://img.discogs.com/_Aae-hL4gl0x_KwrThmqUTDB5XQ=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-12241081-1531225705-4713.jpeg.jpg
  https://img.discogs.com/whCpjzv00Jm56UIjAlhy3X5u29U=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-12665167-1539625447-4128.png.jpg
  https://img.discogs.com/JrPO0wlT4u2RXM0EmyIo9qpC7YA=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-14163440-1598659829-1363.jpeg.jpg
  https://img.discogs.com/3Weayt-t-dlCIS1ngTQ85kEfBTk=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-12275414-1532184232-1154.jpeg.jpg
  https://img.discogs.com/1JhG-NwxjMpzufIDfLOq3aVDD9U=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-13212415-1550042855-8712.jpeg.jpg
  https://img.discogs.com/YvaKGGrdhdvDiyxf0NDt_ri2Zy8=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-11788669-1522437020-1739.jpeg.jpg
  https://img.discogs.com/2oDRw8UJjJoFJi_DPWQ7R3il0OY=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-12004897-1526405086-1872.jpeg.jpg
  https://img.discogs.com/oA02hy2g94-mvBb7FV_DHL0I1CY=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-12779761-1541792067-3852.jpeg.jpg
  https://img.discogs.com/N2f-Hh0nY1K3rGhw6XUtFBIUAYc=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-11790643-1522435461-5597.jpeg.jpg
  https://img.discogs.com/kaM2xlINdm3mwip8_eaNYqBZSHE=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-12126316-1541067013-6396.jpeg.jpg
  https://img.discogs.com/tQq4XKi8h_xTNnaX_7WrZalrIPE=/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-16107694-1603554358-5311.jpeg.jpg
  ```
