using System;
using System.IO;
using System.Text.RegularExpressions;

namespace oneTwoTree.ConvertJsonToObject
{
    public class JsonToObjectCSharp
    {
        public static void Executor(dynamic JsonData)
        {
            using (StreamReader r = new StreamReader(JsonData))
            {
                string json = r.ReadToEnd();
                var elemensJson = json.Split(",");
                string newJsonData = "{";

                // WIP - to duplicate name of class list in other objects in flow structure.
                foreach (var element in elemensJson)
                {
                    int countAsps = CountAllAsps(element);
                    _ = countAsps;

                    var boolContainClass = element.Contains(": {");
                    var boolContainOpenerList = element.Contains(": [");
                    var boolContainClosedList = element.Contains("]");
                    _ = boolContainOpenerList;

                    if (countAsps >= 4)
                    {
                        var newElementToUpperString = UpperCaseString(element);
                        if (boolContainClass == true)
                        {
                            var elementWithClassMethod = ContainClassMthod(newElementToUpperString);
                            _ = elementWithClassMethod;
                            var elementsTypesStringFromRemove = RemoveFirstsAsps(elementWithClassMethod);

                            var ifCountainsDoublePointsInString = elementsTypesStringFromRemove.Contains(":");
                            _ = ifCountainsDoublePointsInString;
                            
                            var elementTypeString = elementsTypesStringFromRemove.Replace(":", " =");
                            newJsonData += $"{elementTypeString},";
                            
                        }
                        else if (boolContainOpenerList == true)
                        {
                            var elementWithListMethod = ContainListMthod(newElementToUpperString);
                            _ = elementWithListMethod;
                            string elementsTypesOthersFromRegex = Regex.Replace(elementWithListMethod, @"[""]", string.Empty);

                            var ifCountainsDoublePointsInOthers = elementsTypesOthersFromRegex.Contains(":");
                            _ = ifCountainsDoublePointsInOthers;
                            var elementTypeOthers = elementsTypesOthersFromRegex.Replace(":", " =");
                            newJsonData += $"{elementTypeOthers},";
                        }
                        else
                        {
                            var elementsTypesStringFromRemove = RemoveFirstsAsps(newElementToUpperString);

                            var ifCountainsDoublePointsInString = elementsTypesStringFromRemove.Contains(":");
                            _ = ifCountainsDoublePointsInString;

                            int countDots = 0;
                            foreach (var dots in elementsTypesStringFromRemove)
                            {
                                if (dots == ':')
                                {
                                    countDots += 1;
                                }
                            }

                            if (countDots > 1)
                            {
                                string newElementData = Regex.Replace(elementsTypesStringFromRemove, @":\s", " = ");
                                newJsonData += $"{newElementData},";

                            }
                            else
                            {
                                var elementTypeString = elementsTypesStringFromRemove.Replace(":", " =");
                                newJsonData += $"{elementTypeString},";
                            }
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
                            newJsonData += $"{elementTypeOthers},";
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
                            newJsonData += $"{elementTypeOthers},";
                        }
                    }
                }
                // principal response
                Console.WriteLine(newJsonData);
            }

            Console.WriteLine($"\nFinish Process!!");
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
                        newElementWithClass += $" = new {className}\r\n ";
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
                        newElementWithClass += $" = new List<{className}> \r\n";
                        newElementWithClass += $"  "+"{"+$" \r\n    new {className}";
                        countDoublePoint += 1;
                    }
                    else
                    {
                        if (element[i] == '[')
                        {
                            newElementWithClass += "";
                        }
                        else
                        {
                            newElementWithClass += element[i];
                        }
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

        private static string ClosedListMethod(string element)
        {
            string newExitElement = "";
            for (int i = 1; i <= element.Length; i++)
            {
                try
                {
                    if (element[i] == ']')
                    {
                        newExitElement += "}";
                    }
                    else
                    {
                        newExitElement += element[i];
                    }
                }
                catch (Exception ex)
                {
                    _ = ex;
                    continue;
                }
            }

            return newExitElement;
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
