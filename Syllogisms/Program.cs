namespace Syllogisms
{
    internal class Program
    {
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
            string sentence;

            for (int i = 1; i < 4; i++)
            {
                sentence = GeneratePartialSentence("cats", "animals", "mammals", 1, i);
                Console.WriteLine(sentence);
                string fullSentence = GenerateFullSentence(sentence, 'A');
                Console.WriteLine(fullSentence);
            }
        }
    }
}