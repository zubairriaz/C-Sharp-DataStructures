using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.HashtablePractises
{
    public class HashTablePractise
    {
        public static void HashTableFunctions()
        {
            Hashtable phoneBook = new Hashtable();
            phoneBook.Add("Zubair", "03234088785");
            phoneBook["Zubair"] = "03234088";
            try
            {
                phoneBook.Add("Zubair", "03234088785");
               

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            finally{
                phoneBook.Add("Bilal", "03234088785");
                phoneBook.Add("Umair", "03234088785");
            }


            foreach (DictionaryEntry entry in phoneBook)
            {
                Console.WriteLine($"{entry.Key}-{entry.Value}");
            }




        }
    }
}
