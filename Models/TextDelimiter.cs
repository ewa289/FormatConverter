namespace FormatConverter.Models;

public class TextDelimiter
{
    public int FirstIndex { get; set; }
    public int SecondIndex { get; set; }
    public int ThirdIndex { get; set; }

    public TextDelimiter(string text)
    {
        FirstIndex = text.IndexOf('|');

        if (FirstIndex > 0)
            SecondIndex = text.IndexOf('|', FirstIndex + 1);

        if (SecondIndex > 0)
            ThirdIndex = text.IndexOf('|', SecondIndex + 1);
    }
}
