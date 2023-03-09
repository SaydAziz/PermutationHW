//HELPED AND TUTORED BY DUNCAN
using System.Data;
using System.Runtime.CompilerServices;

string input;
int rValue;


//Prompt input for Permutations
Console.WriteLine("Enter a string of 5 characters to show its permutations: ");
input = Console.ReadLine();
Console.WriteLine("Enter the value of \"r\": ");
rValue = Convert.ToInt32(Console.ReadLine());

//Iterate and print through list returned from do Permutations method
List<string> permutationList = doPerms(input, rValue);
Console.WriteLine(" ");
foreach (var x in permutationList)
{
    Console.WriteLine(x);
}

Console.WriteLine("Count of Permutations: " + permutationList.Count);


Console.WriteLine("\nPress any key to continue.");
Console.ReadKey();
Console.Clear();

//Prompt input for Ordered Partitions
Console.WriteLine("Enter a string of 5 characters to show its Ordered Partitions: ");
input = Console.ReadLine();

//Iterate and print through list returned from doPerms while removing any identical variations
List<string> partitionList = doPerms(input, 5).Distinct().ToList();
Console.WriteLine(" ");
foreach (var x in partitionList)
{
    Console.WriteLine(x);
}

Console.WriteLine("Count of Ordered Partitions: " + partitionList.Count);

Console.WriteLine("\nPress any key to continue.");
Console.ReadKey();
Console.Clear();

//Prompt input for Combinations
Console.WriteLine("Enter a string of 5 characters to show its Combinations: ");
input = Console.ReadLine();

Console.WriteLine("Enter the value of \"r\": ");
rValue = Convert.ToInt32(Console.ReadLine());


//Iterate and print through list of combinations
List<string> combinationList = new List<string>();
doCombinations(input, "", combinationList);
Console.WriteLine(" ");

int comboCount = 0;

foreach (var x in combinationList)
{
    if (x.Length == rValue)
    {
        Console.WriteLine(x);
        comboCount++;
    }
}
Console.WriteLine("Count of Combinations: " + comboCount);




//Method to return all permutations
List<string> doPerms(string str, int rVal)
{
    //Create list to add new permutations to.
    List<string> variations = new List<string>();


    //Iterate through each character as fixed character
    for (int i = 0; i < str.Length; i++)
    {
        //Fix character at index i.
        string fixedChar = str[i].ToString();
        //Store a new string without the fixed letter
        string cutString = str.Remove(i, 1);


        if (rVal == 1)
        {
            variations.Add(fixedChar);
        }
        else
        {
            //find each variation of the string without the "first" character
            List<string> currentPerm = doPerms(cutString, rVal - 1);

            //Add each variation of letters of the cutstring to the fixed letter
            for (int x = 0; x < currentPerm.Count; x++)
            {
                string permutation = fixedChar + currentPerm[x].ToString();
                variations.Add(permutation);
            }
        }
    }
    return variations;
}

//Combination code inspired by Duncan, StackOverflow, and Youtube Professor, 


void doCombinations(string str, string currentCombo, List<string> comboList)
{

    if (currentCombo.Length > 0)
    {
        comboList.Add(currentCombo);
    }

    //Iterate through each character
    for (int i = 0; i < str.Length; i++)
    {
        //Adds character at index i to the combo
        string newCombo = currentCombo + str[i];
        //Cuts out first character from the string
        string cutStr = str.Remove(i, 1);
        doCombinations(cutStr, newCombo, comboList);
    }
}

