using System.Text;

public static class RunLengthEncoding
{
  public static string Encode(string input)
{
    if (string.IsNullOrEmpty(input)) return "";

    StringBuilder result = new StringBuilder();
    int count = 1;

    for (int i = 0; i < input.Length; i++)
    {
        if (i + 1 < input.Length && input[i] == input[i + 1])
        {
            count++;
        }
        else
        {
            if (count > 1)
            {
                result.Append(count);
            }
            result.Append(input[i]);
            count = 1; 
        }
    }

    return result.ToString();
}

  public static string Decode(string input)
{
    StringBuilder result = new StringBuilder();
    string digits = "";

    foreach (char c in input)
    {
        if (char.IsDigit(c))
        {
            digits += c;
        }
        else
        {
            int count = string.IsNullOrEmpty(digits) ? 1 : int.Parse(digits);
        
            result.Append(c, count);
            digits = "";
        }
    }

    return result.ToString();
}
}
