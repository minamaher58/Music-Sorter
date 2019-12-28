using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.Write("Enter the file name you need to search: ");
            //  String fileName = Console.ReadLine();
            string Path = @"C:\Users\hp\Desktop\MuSic-SoRteR\MuSic SoRteR\Lab10\tony";
            while (true)
            {
               
            //int count = 0;
            Console.WriteLine("Sort by Name Press 1 ");
            Console.WriteLine("Sort by Size Press 2 ");
            Console.WriteLine("Sort by Title Press 3 ");
            Console.WriteLine("Sort by Artist Press 4 ");
            Console.WriteLine("Sort by Album Press 5 ");

            //Console.Write("Select Range to Work With x y :  ");
            //string x1 = Console.ReadLine(),y1=Console.ReadLine();
            //int x = Int32.Parse(x1),y=Int32.Parse(y1);
         

                Sort_Class S = new Sort_Class(Path);
                string z = Console.ReadLine();

                if (z == "1")
                {
                    Console.Clear();
                    S.SortByName();
                }
                else if (z == "2")
                {
                    Console.Clear();
                    S.SortBySize();


                    //var Sort = file.OrderBy(x => x.);

                }
                else if (z == "3")
                {
                    Console.Clear();
                    S.SortByTitle();
                }

                else if (z == "4")
                {
                    Console.Clear();
                    S.SortByArtist();
                }
                else if (z == "5")
                {
                    Console.Clear();
                    S.SortByAlbum();
                }
                else if(z !="1" && z!="2" && z!="3" && z!="4" && z!="5") {
                    Console.WriteLine("please Enter Correct Number .");
                    continue;
                }
            }
            //foreach (string i in file)
            //{
            //    if (File.Exists(i) && count >= x && count <= y)
            //    {

            //        MP3Reader m = new MP3Reader(i);
            //        MP3Tag c = m.getTag();
            //        c.displayTag();
            //    }
            //    if (count == y)
            //        break;
            //    count++;
            //}
      
            //foreach (string i in file)
            //{
            //    Console.WriteLine(i);
            //}

            //DirectoryInfo dirInfo = new DirectoryInfo(@"E:\Sem 2\Files Organization\Labs\Lab 04\Lab04\Lab10\bin\Debug");
            //var dirs = dirInfo.EnumerateDirectories().OrderBy(d => d.Name);


                //string[] files = Directory.GetFiles(@"E:\Sem 2\Files Organization\Labs\Lab 04\Lab04\Lab10\bin\Debug");
                // Array.Sort(files);

                //var sort = from fi in files
                //           orderby new FileInfo(fi).Length descending
                //           select fi;

                //var files = Directory.EnumerateFiles(@"E:\Sem 2\Files Organization\Labs\Lab 04\Lab04\Lab10\bin\Debug")
                //         .OrderByDescending(filename => filename);

                //var files = new DirectoryInfo(@"E:\Sem 2\Files Organization\Labs\Lab 04\Lab04\Lab10\bin\Debug\New folder").GetFiles()
                //                                      .OrderBy(f => f.Name)
                //                                      .ToList();

                ////  string fileName, destFile;

                //int count = 1;

                //foreach (var i in files)
                //{


                //    //fileName = System.IO.Path.GetFileName(i);
                //    //destFile = System.IO.Path.Combine(@"E:\Sem 2\Files Organization\Labs\Lab 04\Lab04\Lab10\bin\Debug", @"E:\Sem 2\Files Organization\Labs\Lab 04\Lab04\Lab10\bin\Debug\New folder");
                //    File.Copy(i.ToString(), @"E:\Sem 2\Files Organization\Labs\Lab 04\Lab04\Lab10\bin\Debug\Sorted\" + Path.GetFileName(i.ToString()));
                //    Console.WriteLine("  "+count.ToString()+"----->  "+i);
                //    count++;
                //}



                //File.Copy(files[i], "c:\\anotherFolder\\" + Path.GetFileName(s[i]));




                //static void displayArtistInfo(String artist)
                //{
                //   //write your code here

        }
    }
    }
