using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace oneTwoTree.ConvertJsonToObject
{
    public class JsonToObjectCSharp
    {
        public static void Executor()
        {
            List<dynamic> data = new List<dynamic>();
            using (StreamReader r = new StreamReader("C:\\Users\\uriel_batista\\source\\repos\\ConversorJsonToObject\\ConversorJsonToObject\\ConvertJsonToObjectCSharp\\WeatherForecast.json"))
            {
                string json = r.ReadToEnd();
                var elemensJson = json.Split(",");
                string newJsonData = "{";
                foreach (var element in elemensJson)
                {
                    int countAsps = CountAllAsps(element);
                    _ = countAsps;

                    var boolContainClass = element.Contains(": {");
                    var boolContainList = element.Contains(": [");
                    _ = boolContainList;

                    if (countAsps >= 4)
                    {
                        var newElementToUpperString = UpperCaseString(element);
                        if (boolContainClass == true)
                        {
                            var elementWithClassMethod = ContainClassMthod(newElementToUpperString);
                            _ = elementWithClassMethod;
                            var elementsTypesStringFromRemove = RemoveFirstsAsps(elementWithClassMethod);
                            var elementTypeString = elementsTypesStringFromRemove.Replace(":", " =");
                            newJsonData += elementTypeString;
                        }
                        //else if (boolContainList == true)
                        //{
                        //    var elementWithListMethod = ContainListMthod(newElementToUpperString);
                        //    _ = elementWithListMethod;
                        //    string elementsTypesOthersFromRegex = Regex.Replace(elementWithListMethod, @"[""]", string.Empty);
                        //    var elementTypeOthers = elementsTypesOthersFromRegex.Replace(":", " =");
                        //    newJsonData += elementTypeOthers;
                        //}
                        else
                        {
                            var elementsTypesStringFromRemove = RemoveFirstsAsps(newElementToUpperString);
                            var elementTypeString = elementsTypesStringFromRemove.Replace(":", " =");
                            newJsonData += elementTypeString;
                        }
                    }
                    else
                    {
                        var newElementFirstLetterUpperOthers = UpperCaseOthers(element);
                        if (boolContainClass == true)
                        {
                            var elementWithClassMethod = ContainClassMthod(newElementFirstLetterUpperOthers);
                            _ = elementWithClassMethod;
                            string elementsTypesOthersFromRegex = Regex.Replace(elementWithClassMethod, @"[""]", string.Empty);
                            var elementTypeOthers = elementsTypesOthersFromRegex.Replace(":", " =");
                            newJsonData += elementTypeOthers;
                        }
                        //else if (boolContainList == true)
                        //{
                        //    var elementWithListMethod = ContainListMthod(newElementFirstLetterUpperOthers);
                        //    _ = elementWithListMethod;
                        //    string elementsTypesOthersFromRegex = Regex.Replace(elementWithListMethod, @"[""]", string.Empty);
                        //    var elementTypeOthers = elementsTypesOthersFromRegex.Replace(":", " =");
                        //    newJsonData += elementTypeOthers;
                        //}
                        else
                        {
                            string elementsTypesOthersFromRegex = Regex.Replace(newElementFirstLetterUpperOthers, @"[""]", string.Empty);
                            var elementTypeOthers = elementsTypesOthersFromRegex.Replace(":", " =");
                            newJsonData += elementTypeOthers;
                        }
                    }
                }
                // principal response
                Console.WriteLine(newJsonData);
            }

            Console.WriteLine("Finish Process!!");
        }

        private static string ContainClassMthod(string element)
        {
            int countAsps = 0;
            int countDoublePoint = 0;
            string newElementWithClass = "";
            string className = "";
            for (int i = 1; i <= element.Length; i++)
            {
                try
                {
                    if (element[i] == '"')
                    {
                        countAsps += 1;
                    }
                    if (countAsps == 1 && countAsps < 2)
                    {
                        if (element[i] == '\"')
                        {
                            className += "";
                        }
                        else
                        {
                            className += element[i];
                        }
                    }


                    if (element[i] == ':')
                    {
                        countDoublePoint += 1;
                    }
                    if (countDoublePoint == 1)
                    {
                        newElementWithClass += $" = new {className}";
                        countDoublePoint += 1;
                    }
                    else
                    {
                        newElementWithClass += element[i];
                    }
                }
                catch (Exception ex)
                {
                    _ = ex;
                    continue;
                }
            }

            return newElementWithClass;
        }

        private static string ContainListMthod(string element)
        {
            int countAsps = 0;
            int countDoublePoint = 0;
            string newElementWithClass = "";
            string className = "";
            for (int i = 1; i <= element.Length; i++)
            {
                try
                {
                    if (element[i] == '"')
                    {
                        countAsps += 1;
                    }
                    if (countAsps == 1 && countAsps < 2)
                    {
                        if (element[i] == '\"')
                        {
                            className += "";
                        }
                        else
                        {
                            className += element[i];
                        }
                    }


                    if (element[i] == ':')
                    {
                        countDoublePoint += 1;
                    }
                    if (countDoublePoint == 1)
                    {
                        newElementWithClass += $" = new List<{className}>";
                        countDoublePoint += 1;
                    }
                    else
                    {
                        newElementWithClass += element[i];
                    }
                }
                catch (Exception ex)
                {
                    _ = ex;
                    continue;
                }
            }

            return newElementWithClass;
        }

        private static string UpperCaseOthers(string element)
        {
            int countAsp = 0;
            string newElementUpperCase = "";
            for (int i = 1; i <= element.Length; i++)
            {
                try
                {
                    if (countAsp == 1)
                    {
                        newElementUpperCase += char.ToUpper(element[i]);
                        countAsp = 0;
                    }
                    else
                    {
                        newElementUpperCase += element[i];
                    }

                    if (element[i] == '"')
                    {
                        countAsp += 1;
                    }
                }
                catch (Exception ex)
                {
                    _ = ex;
                    continue;
                }
            }

            return newElementUpperCase;
        }

        private static string UpperCaseString(string element)
        {
            int countAsp = 0;
            string newElementUpperCase = "\r";
            for (int i = 1; i <= element.Length; i++)
            {
                try
                {
                    if (countAsp == 1)
                    {
                        newElementUpperCase += char.ToUpper(element[i]);
                        countAsp = 0;
                    }
                    else
                    {
                        newElementUpperCase += element[i];
                    }

                    if (element[i] == '"')
                    {
                        countAsp += 1;
                    }
                }
                catch (Exception ex)
                {
                    _ = ex;
                    continue;
                }
            }

            return newElementUpperCase;
        }

        private static int CountAllAsps(string element)
        {
            int countAsp = 0;
            for (int i = 1; i <= element.Length; i++)
            {
                try
                {
                    if (element[i] == '"')
                    {
                        countAsp += 1;
                    }
                }
                catch (Exception ex)
                {
                    _ = ex;
                    continue;
                }
            }

            return countAsp;
        }

        private static string RemoveFirstsAsps(string element)
        {
            int countAsp = 0;
            for (int i = 1; i <= element.Length; i++)
            {
                try
                {
                    if (element[i] == '"')
                    {
                        countAsp += 1;
                    }
                }
                catch (Exception ex)
                {
                    _ = ex;
                    continue;
                }
            }
            string newElement = "";
            if (countAsp >= 4)
            {
                int countAspTwo = 0;
                for (int i = 1; i <= element.Length; i++)
                {
                    try
                    {
                        if (countAspTwo == 2)
                        {
                            newElement += element[i];
                            continue;
                        }
                        if (element[i] == '\"')
                        {
                            newElement += "";
                            countAspTwo += 1;
                        }
                        else
                        {
                            newElement += element[i];
                        }
                    }
                    catch (Exception ex)
                    {
                        _ = ex;
                        continue;
                    }
                }
            }
            return newElement;
        }

    }
}
