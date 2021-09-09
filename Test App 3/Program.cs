using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'toolchanger' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING_ARRAY tools
     *  2. INTEGER startIndex
     *  3. STRING target
     */
    public static int toolchanger(List<string> tools, int startIndex, string target)
    {
        if (tools[startIndex] == target)
        {
            return 0;
        }

        int actualStartIndex = startIndex;
        int maxToolsIndex = tools.Count - 1;
        if (actualStartIndex > maxToolsIndex)
        {
            actualStartIndex = maxToolsIndex - startIndex;
        }

        int indexOfNearestToolRight = -1;
        int indexOfNearestToolLeft = -1;
        for (int i = 0; i < tools.Count; i++)
        {
            // moving right
            if (indexOfNearestToolRight == -1)
            {
                int rightIndex = actualStartIndex + i;
                if (rightIndex > maxToolsIndex)
                {
                    rightIndex =- tools.Count;
                }
                if (tools[rightIndex] == target)
                {
                    indexOfNearestToolRight = rightIndex;
                }
            }


            // moving left
            if (indexOfNearestToolLeft == -1)
            {
                int leftIndex = actualStartIndex - i;
                if (leftIndex < 0)
                {
                    leftIndex =+ tools.Count;
                }
                if (tools[leftIndex] == target)
                {
                    indexOfNearestToolLeft = leftIndex;
                }
            }

        }

        if (indexOfNearestToolRight == indexOfNearestToolLeft)
        {
            return Math.Abs(actualStartIndex - indexOfNearestToolRight);
        }
        else
        {
            int distanceToRight = tools.Count;
            if (indexOfNearestToolRight != -1)
            {
                distanceToRight = Math.Abs(actualStartIndex - indexOfNearestToolRight);
            }

            int distanceToLeft = tools.Count;
            if (indexOfNearestToolLeft != -1)
            {
                distanceToLeft = Math.Abs(actualStartIndex - indexOfNearestToolLeft);
            }

            return Math.Min(distanceToLeft, distanceToRight);

        }
    }
    /*
    public static int toolchanger(List<string> tools, int startIndex, string target)
    {
        if (tools[startIndex] == target)
        {
            return 0;
        }

        if (startIndex > tools.Count - 1)
        {
            startIndex = startIndex - tools.Count;
        }


        int minMovesToGetToTool = 0;
        // Move Right
        for (int i = startIndex; i < tools.Count; i++)
        {
            if (tools[i] == target)
            {
                minMovesToGetToTool = i - startIndex;
                break;
            }
        }

        // Move Left
        for (int i = startIndex; i < tools.Count; i++)
        {
            int indexToCheck = startIndex - i;
            if (indexToCheck < 0)
            {
                indexToCheck = Math.Abs((tools.Count - 1) - i);
            }

            if (tools[indexToCheck] == target)
            {
                int distanceBetweenIndexes = Math.Abs(startIndex - i);
                if (minMovesToGetToTool == 0 || distanceBetweenIndexes < minMovesToGetToTool)
                {
                    minMovesToGetToTool = distanceBetweenIndexes;
                }

                break;
            }
        }



        return minMovesToGetToTool;
    }
    */
    /*
    public static int toolchanger(List<string> tools, int startIndex, string target)
    {
        if (tools[startIndex] == target)
        {
            return 0;
        }

        if (startIndex > tools.Count - 1)
        {
            startIndex = (tools.Count - 1) - startIndex;
        }


        int indexOfNearestToolRight = -1;
        // count up
        for (int i = startIndex; i < tools.Count; i++)
        {
            if (tools[i] == target)
            {
                indexOfNearestToolRight = i;
                break;
            }
        }

        // count down
        int indexOfNearestToolLeft = -1;
        for (int i = startIndex - 1; i >= 0; i--)
        {
            if (tools[i] == target)
            {
                indexOfNearestToolLeft = i;
                break;
            }
        }


        int distanceToNearestRight = -1;
        if (indexOfNearestToolRight != -1)
        {
            distanceToNearestRight = Math.Min(indexOfNearestToolRight - startIndex,((tools.Count - 1) - startIndex) + indexOfNearestToolRight);
        }

        int distanceToNearestLeft = -1;
        if (indexOfNearestToolLeft != -1)
        {
            distanceToNearestLeft = Math.Min(startIndex - indexOfNearestToolLeft, ((tools.Count - 1) - indexOfNearestToolLeft) + startIndex);
        }

        int minMovesToGetToTool = 0;
        if (distanceToNearestLeft != -1 && distanceToNearestRight != -1)
        {
            minMovesToGetToTool = Math.Min(distanceToNearestRight, distanceToNearestLeft);
        }
        else
        {
            minMovesToGetToTool = Math.Max(distanceToNearestRight, distanceToNearestLeft);
        }
        
        

        return minMovesToGetToTool;
    }
    */
}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int toolsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> tools = new List<string>();

        for (int i = 0; i < toolsCount; i++)
        {
            string toolsItem = Console.ReadLine();
            tools.Add(toolsItem);
        }

        int startIndex = Convert.ToInt32(Console.ReadLine().Trim());

        string target = Console.ReadLine();

        int result = Result.toolchanger(tools, startIndex, target);

        Console.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}




/*
public static int toolchanger(List<string> tools, int startIndex, string target)
    {
        if (tools[startIndex] == target)
        {
            return 1;
        }


        int minMovesToGetToTool = 0;
        // count up
        for (int i = startIndex; i < tools.Count; i++)
        {
            if (tools[i] == target)
            {
                minMovesToGetToTool = i - startIndex;
                break;
            }
        }
        
        // count down
        for (int i = startIndex - 1; i >= 0; i--)
        {
            if (tools[i] == target)
            {
                int distanceBetweenIndexes = startIndex - i;
                if (minMovesToGetToTool == 0 || distanceBetweenIndexes < minMovesToGetToTool)
                {
                    minMovesToGetToTool = distanceBetweenIndexes;
                }
                
                break;
            }
        }

        return minMovesToGetToTool;
    }
*/
/*
11
rphfmwevhwlezohyeehbrcewjxvceziftiqtntfsr
ugtiznorvonzjfeacg
ayapwlmbzitzszhzkosvnknberbltlkggdgpljfisyltmmfvhybljvkypcflsaqevcijcyrgmqirzniaxakholawoydvc
eigttxwpukzj
xbrtspfttotafsngqvoijxuvqbztvaalsehzxbshnrvbykjq
zzfmlvyoshiktodnsjjpqplciklzqrxloqxrudygjtyzleizmeainxslwhhjwslqendjvxjyghrveuvp
nqtsdtwxcktmwwwsdthzmlmbhjkmo
pbqurqfxgqlojmwsomowsjvpvhznbsilhhdkbdxqgrgedpzchrgefeukmcow
znwhpiiduxdnnlbnmyjyssbsococdzcuunkrfduvouaghhcyvmlkzaajpfpyljtyjjpyn
efxiswjutenuycpbcnmhfuqmmidmvknyxmywegmtunodvuzygvguxtrdsdfzfssmeluodjgdgzfmrazvndtaurdkugsbdpawxit
dubbqeonycaegxfjkklrfkraoheucsvpiteqrswgkaaaohxxzhqjtkqaqhkwberbpmglbjipnujywogwcz
10
efxiswjutenuycpbcnmhfuqmmidmvknyxmywegmtunodvuzygvguxtrdsdfzfssmeluodjgdgzfmrazvndtaurdkugsbdpawxit




12
rphfmwevhwlezohyeehbrcewjxvceziftiqtntfsr
ugtiznorvonzjfeacg
efxiswjutenuycpbcnmhfuqmmidmvknyxmywegmtunodvuzygvguxtrdsdfzfssmeluodjgdgzfmrazvndtaurdkugsbdpawxit
ayapwlmbzitzszhzkosvnknberbltlkggdgpljfisyltmmfvhybljvkypcflsaqevcijcyrgmqirzniaxakholawoydvc
eigttxwpukzj
xbrtspfttotafsngqvoijxuvqbztvaalsehzxbshnrvbykjq
zzfmlvyoshiktodnsjjpqplciklzqrxloqxrudygjtyzleizmeainxslwhhjwslqendjvxjyghrveuvp
nqtsdtwxcktmwwwsdthzmlmbhjkmo
pbqurqfxgqlojmwsomowsjvpvhznbsilhhdkbdxqgrgedpzchrgefeukmcow
efxiswjutenuycpbcnmhfuqmmidmvknyxmywegmtunodvuzygvguxtrdsdfzfssmeluodjgdgzfmrazvndtaurdkugsbdpawxit
znwhpiiduxdnnlbnmyjyssbsococdzcuunkrfduvouaghhcyvmlkzaajpfpyljtyjjpyn
dubbqeonycaegxfjkklrfkraoheucsvpiteqrswgkaaaohxxzhqjtkqaqhkwberbpmglbjipnujywogwcz
0
efxiswjutenuycpbcnmhfuqmmidmvknyxmywegmtunodvuzygvguxtrdsdfzfssmeluodjgdgzfmrazvndtaurdkugsbdpawxit
*/