using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;

namespace Syllogisms
{
    internal class Program
    {
        public static void AcceptUserInput()
        {
            Console.Write("Enter syllogism type: ");
            string input = Console.ReadLine();
            string pattern = @"(?i)([aeio]{3})([1-4])";
            var match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string chars = match.Groups[1].Value;
                int digit = int.Parse(match.Groups[2].Value);
                string subjectTerm = GetRandomWord();
                string middleTerm = GetRandomWord();
                string predicateTerm = GetRandomWord();

                for (int i = 0; i < chars.Length; i++)
                {
                    char mood = char.ToUpper(chars[i]);
                    string partialSentence = GeneratePartialSentence(subjectTerm, middleTerm, predicateTerm, digit, i + 1);
                    string fullSentence = GenerateFullSentence(partialSentence, mood);
                    Console.WriteLine(fullSentence);
                }
            }
            else
            {
                Environment.Exit(1);
            }
        }

        public static string GetRandomWord()
        {
            var wordlist = new List<string>()
            {
                "cats", "animals", "mammals", "pets", "people",
                "chairs", "mortal", "immortal", "alive", "inanimate",
                "stones", "warm", "cold", "big", "small"
            };

            var rnd = new Random();
            string pickedWord = "";

            if (wordlist.Count > 0)
            {
                int rndIndex = rnd.Next(0, wordlist.Count);
                pickedWord = wordlist[rndIndex];
                wordlist.RemoveAt(rndIndex);
            }

            return pickedWord;
        }

        public static string GeneratePartialSentence(string subjectTerm, string middleTerm, string predicateTerm,
            int figure, int order)
        {
            string sentence = "";

            switch (figure)
            {
                case 1:
                    switch (order)
                    {
                        case 1:
                            sentence = $"{middleTerm} {predicateTerm}";
                            break;
                        case 2:
                            sentence = $"{subjectTerm} {middleTerm}";
                            break;
                        case 3:
                            sentence = $"{subjectTerm} {predicateTerm}";
                            break;
                        default:
                            throw new ArgumentException("Invalid order value. Expected 1, 2, or 3.");
                    }

                    break;

                case 2:
                    switch (order)
                    {
                        case 1:
                            sentence = $"{predicateTerm} {middleTerm}";
                            break;
                        case 2:
                            sentence = $"{subjectTerm} {middleTerm}";
                            break;
                        case 3:
                            sentence = $"{subjectTerm} {predicateTerm}";
                            break;
                        default:
                            throw new ArgumentException("Invalid order value. Expected 1, 2, or 3.");
                    }

                    break;

                case 3:
                    switch (order)
                    {
                        case 1:
                            sentence = $"{middleTerm} {predicateTerm}";
                            break;
                        case 2:
                            sentence = $"{middleTerm} {subjectTerm}";
                            break;
                        case 3:
                            sentence = $"{subjectTerm} {predicateTerm}";
                            break;
                        default:
                            throw new ArgumentException("Invalid order value. Expected 1, 2, or 3.");
                    }

                    break;

                case 4:
                    switch (order)
                    {
                        case 1:
                            sentence = $"{predicateTerm} {middleTerm}";
                            break;
                        case 2:
                            sentence = $"{middleTerm} {subjectTerm}";
                            break;
                        case 3:
                            sentence = $"{subjectTerm} {predicateTerm}";
                            break;
                        default:
                            throw new ArgumentException("Invalid order value. Expected 1, 2, or 3.");
                    }

                    break;

                default:
                    throw new ArgumentException("Invalid figure value. Expected 1, 2, 3, or 4.");
            }

            return sentence;
        }

        public static string GenerateFullSentence(string sentence, char mood)
        {
            string fullSentence = "";
            var words = sentence.Split(' ');
            if (mood == 'A') fullSentence = $"All {words[0]} are {words[1]}.";
            if (mood == 'E') fullSentence = $"No {words[0]} are {words[1]}.";
            if (mood == 'I') fullSentence = $"Some {words[0]} are {words[1]}.";
            if (mood == 'O') fullSentence = $"Some {words[0]} are not {words[1]}.";
            return fullSentence;
        }

        static void Main(string[] args)
        {
            AcceptUserInput();
        }
    }
}