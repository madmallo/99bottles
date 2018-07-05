using System;
using System.IO;
using System.Threading.Tasks;

namespace _99bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamWriter generatedLyricsFileWriter = File.CreateText("generatedFile.txt"))
                {
                    string generatedLyrics = String.Empty;
                    for (var i = 99; i >= 0; i--)
                    {
                        string bottlesOnTheWall = i == 0 ? "no more" : i.ToString();
                        string wordOfCurrentBottles = i == 1 ? "bottle" : "bottles";
                        string sentenceOfSecondVerse = i == 0 ? "Go to the store and buy some more" : "Take one down and pass it around";
                        string nextBottlesOnTheWall = i == 1 ? "no more" : i == 0 ? "99" : (i - 1).ToString();
                        string wordOfNextBottles = i == 2 ? "bottle" : "bottles";

                        generatedLyricsFileWriter.WriteLine(String.Format("{0} {1} of beer on the wall, {2} {1} of beer.", bottlesOnTheWall.Substring(0, 1).ToUpper() + bottlesOnTheWall.Substring(1), wordOfCurrentBottles, bottlesOnTheWall));
                        generatedLyricsFileWriter.WriteLine(String.Format("{0}, {1} {2} of beer on the wall.", sentenceOfSecondVerse, nextBottlesOnTheWall, wordOfNextBottles));
                        generatedLyricsFileWriter.WriteLine();
                    }
                }

                FileInfo songLyricsFile = new FileInfo(@"C:\Users\fabio\source\repos\99bottles\99bottles\99bottles.txt");
                using (FileStream songLyricsFileStream = songLyricsFile.OpenRead())
                using (StreamReader songLyricsFileReader = new StreamReader(songLyricsFileStream))
                using (StreamReader generatedLyricsFileReader = File.OpenText("generatedFile.txt"))
                {
                    if (songLyricsFileReader.ReadToEnd() == generatedLyricsFileReader.ReadToEnd())
                    {
                        Console.Write("Canzone generata correttamente!");
                    }
                    else
                    {
                        Console.Write("Canzone NON UGUALE!");
                    }
                }
            }
            catch(IOException e)
            {
                Console.Write(e);
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
