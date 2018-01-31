using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.GenAlgorithm
{
    public class LektorWeightCoefficient
    {
        public double[] coefficients { get; set; }
        public int CountOfSubjects { get; set; }

        public string SubjectName { get; set; }
    }
    public static class GenAlgorithm
    {

        public static double[] LektorWeightCoefs1 = new double[] { 0.25, 0.1, 0.3, 0.2, 0.15 }; //БД 3 пари
        public static double[] LektorWeightCoefs2 = new double[] { 0.25, 0.1, 0.3, 0.25, 0.1 }; //Дискретка 2 пари
        public static double[] LektorWeightCoefs3 = new double[] { 0.3, 0.1, 0.3, 0.2, 0.1   }; //Теорія алгоритмів 3 пари
        public static double[] LektorWeightCoefs4 = new double[] { 0.2, 0.3, 0.3, 0.1, 0.1  }; //Веб-верверне 5 пари
        public static double[] LektorWeightCoefs5 = new double[] { 0.25, 0.2, 0.3, 0.1, 0.15 }; //Веб-дизайн 4 пари

        public static string generated_sheduler = "";

        public static List<LektorWeightCoefficient> lektors = new List<LektorWeightCoefficient>() {
            new LektorWeightCoefficient{ coefficients =LektorWeightCoefs1, CountOfSubjects = 3 ,SubjectName = "БД"},
            new LektorWeightCoefficient{ coefficients =LektorWeightCoefs2, CountOfSubjects = 2, SubjectName = "Дискретка"},
            new LektorWeightCoefficient{ coefficients =LektorWeightCoefs3, CountOfSubjects = 3, SubjectName = "Теорія алгоритмів"},
            new LektorWeightCoefficient{ coefficients =LektorWeightCoefs4, CountOfSubjects = 5, SubjectName = "Веб-верверне програмування"},
            new LektorWeightCoefficient{ coefficients =LektorWeightCoefs5, CountOfSubjects = 4, SubjectName = "Веб-дизайн"}
        };

        public static double[] GroupWeightCoefs = new double[] { 0.2, 0.3, 0.4, 0.5, 0.2 };
        public static int[] GroupWindowsCount = new int[] { 2, 2, 1, 1, 2 }; //17 пар тиждень із них 8 вікна

        public static string[] result = new string[25];
     


        public static int[] Capabilities = new int[25];
        public static Perfect perfect = null;


        private static double Fitnes(Data data)
        {
            return (data.LektorKof * data.BinaryQ * data.GroupKof) / data.CountOfWindows;
        }

        private static void GetCapabilities()
        {
            Capabilities = new int[] { 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1 };

            //початкове співвідношення груп та викладачів.
            //оскільки всі викладчі вільні, то на засіданні кафедри було вирішено, що перша група матиме наступні заняття
            //17 пар тиждень із них 13 вікна - встановлена норма мін.освіти
            //в майбутньому це береться із БД
        }


        public static void Run()
        {
            GetCapabilities(); // запит в БД

            for (int l = 0; l < 25; l++)
            {
                result[l] = "";
            }

            string _days = "";            
            Data data = null;
            double res = 0;

            
            foreach (LektorWeightCoefficient lektor in lektors)
            {
                for (int countOfSubjects = 0; countOfSubjects < lektor.CountOfSubjects; countOfSubjects++)
                {
                    double bestEstimate = 0;
                    for (int iterator = 0; iterator < 25; iterator++)
                    {

                        int day = Convert.ToInt32(Math.Ceiling((double)iterator / 5));
                        _days +=  " " + day.ToString();


                        if (day < 5)
                        {

                            data = new Data { BinaryQ = Capabilities[iterator], CountOfWindows = GroupWindowsCount[day], GroupKof = GroupWeightCoefs[day], LektorKof = lektor.coefficients[day] };

                        }
                        else if(day == 5)
                        {
                            data = new Data { BinaryQ = Capabilities[iterator], CountOfWindows = GroupWindowsCount[day-1], GroupKof = GroupWeightCoefs[day-1], LektorKof = lektor.coefficients[day-1] };

                        }
                        res = Fitnes(data);

                        if (res > bestEstimate && day < 6)
                        {
                            bestEstimate = res;
                            perfect = new Perfect { Capability = iterator, Subject = lektor.SubjectName };
                        }

                    }
                    Capabilities[perfect.Capability] = 0;
                    result[perfect.Capability] = perfect.Subject;
                }
            }
        }

    }

    public class Data
    {
        public double LektorKof { get; set; }
        public int BinaryQ { get; set; }
        public double GroupKof { get; set; }
        public int CountOfWindows { get; set; }
    }

    public class Perfect
    {
        public int Day { get; set; }
        public string Subject { get; set; }

        public int Capability { get; set; }

    }
}

