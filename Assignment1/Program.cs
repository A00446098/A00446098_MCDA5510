using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Linq;


namespace A00446098_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string outfile = @"/Users/james/Downloads/Assignment1/output/WriteFile.txt";
            string skipped = @"/Users/james/Downloads/Assignment1/output/skipped.txt";
            string log = @"/Users/james/Downloads/Assignment1/output/log.txt";
            DirWalker fw = new DirWalker();
           
            using (StreamWriter outputFile = new StreamWriter(outfile, true))
            {
                 
                outputFile.WriteLine("First Name,Last Name,Street Number,Street,City,Province,Postal Code,Country,Phone Number,email Address");

            }
            fw.walk(@"/Users/james/Downloads/Assignment1/Sample Data");
            
            foreach (string i in globalvars.valid)
            {
                using (StreamWriter outputFile = new StreamWriter(outfile, true))
                {

                    outputFile.WriteLine(i);

                }
            }
            foreach (string j in globalvars.skipped)
            {
                using (StreamWriter skipfile = new StreamWriter(skipped, true))
                {

                    skipfile.WriteLine(j);

                }
            }
            int count_size = File.ReadAllLines(outfile).Length;

            int no_of_skipped_rows = File.ReadAllLines(skipped).Length;

            using (StreamWriter outp = new StreamWriter(log))
            {

                outp.WriteLine("total number of valid rows. :" + count_size);
                outp.WriteLine("total number of skipped rows. :" + no_of_skipped_rows);





            }
            watch.Stop();
            string elapsedMs = watch.ElapsedMilliseconds.ToString();
            int g = Convert.ToInt32(elapsedMs);
            int ti = g / 1000;
            using (StreamWriter outp = new StreamWriter(log, true))
            {

                outp.WriteLine("time is :" + ti);





            }

        }
    }
    class DirWalker

    {    
        


        public void walk(String path)

        {



            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                }
            }

            SimpleCSVParser parser = new SimpleCSVParser();

            string[] fileList = Directory.GetFiles(path);
            
            
            foreach (string filepath in fileList)
            {


                int a=File.ReadAllLines(filepath).Length;
                
                parser.parse(filepath);



            }
           
            
            
        }
        
    }


    public class SimpleCSVParser
    {


        public void parse(String fileName)
        {
            //C:\Users\James\Desktop\SMUclg\soft\A00446098_Assignment1\datasample\Sample Data
            
            try
            {

                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    
                    parser.SetDelimiters(",");
                    parser.TextFieldType = FieldType.Delimited;
                    TextFieldParser new_parser = new TextFieldParser(fileName);
                    
                    string[] fields1 = parser.ReadFields();
                    string complete_row1 = new_parser.ReadLine();

                    while (!parser.EndOfData)
                    {



                        string[] fields = parser.ReadFields();
                        string complete_row = new_parser.ReadLine();


                        int count = 0;


                        foreach (string col in fields)
                        {
                            if (col == "" || fields.Length < 10)
                            {
                                count = 1;

                                break;

                            }
                        }

                        if (count == 0)
                        {


                            {

                                globalvars.valid.Add(complete_row);


                            }

                        }
                        else
                        {
                            {

                                globalvars.skipped.Add(complete_row);

                            }
                        }

                    }


                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
                Console.WriteLine("its an error");
            }

            

        }


    }

    static class globalvars
    {
        public static List<string> valid = new List<string>();
        public static List<string> skipped = new List<string>();
    }


}
