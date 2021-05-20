using System;
using System.IO;

namespace teacherData
{
    class Classformat
    {
        public string ID, Name, Class, Section;

        public void storeData()
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                 fs = new FileStream("/Users/raghad/Desktop/teacherData.txt", FileMode.Create, FileAccess.Write);
                 sw = new StreamWriter(fs);
                Console.Write("Please Enter The Data ");
                Console.Write("ID :");
                this.ID = Console.ReadLine();
                Console.Write("Name :");
                this.Name = Console.ReadLine();
                Console.Write("Class :");
                this.Class = Console.ReadLine();
                Console.Write("Section :");
                this.Section = Console.ReadLine();


                sw.WriteLine(ID + " , " + Name + " , " + Class + " , " + Section);
                Console.WriteLine("The Data written successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                sw.Close();
                fs.Close();
            }
           
        }


        public void updateData()
        {

            try
            {
                string path = "/Users/raghad/Desktop/teacherData.txt";
            if (File.Exists(path))
            {
                    string content = File.ReadAllText(path);
                    Console.WriteLine("Current Data:");
                    Console.WriteLine(content);
                  ////////////////////////////////////////////////////////////////
                               //new Data
                    Console.WriteLine("\nPlease enter the new Data");
                    Console.Write("ID :");
                    this.ID = Console.ReadLine();
                    Console.Write("Name :");
                    this.Name = Console.ReadLine();
                    Console.Write("Class :");
                    this.Class = Console.ReadLine();
                    Console.Write("Section :");
                    this.Section = Console.ReadLine();

                    string newContent = ID + " , " + Name + " , " + Class + " , " + Section;
                    File.WriteAllText(path, newContent);
                    Console.WriteLine("The Data updated successfully.");

                }

            }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }


}



public void retrieveData()
    {
        FileStream fs = null;
        StreamReader sr = null;
        try
        {
            fs = new FileStream("/Users/raghad/Desktop/teacherData.txt",FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
                Console.WriteLine("The Data retrieved successfully.");

            }
            catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            sr.Close();
            fs.Close();
        }
    }


}//end class

class MainClass
    {
        public static void Main(string[] args)
        {
            Classformat teacherData =new Classformat();
            Console.WriteLine("Now, You will to store the data");
            teacherData.storeData();

            Console.WriteLine("Now, You will to update the data");
            teacherData.updateData();

            Console.WriteLine("Now, You will to retrive the data");
            teacherData.retrieveData();

            Console.ReadKey();

        }
    }
}
