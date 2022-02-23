using System.Text;

public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        var lines = new List<IList<string>>();
        var lineLength = 0;
        var lineWords = new List<string>();
        var lineLengths = new List<int>();
        foreach (var word in words)
        {
            if (lineLength == 0)
            {
                lineWords.Add(word);
                lineLength += word.Length;
                continue;
            }
            
            var newLength = lineLength + word.Length;
            if (newLength + lineWords.Count <= maxWidth)
            {
                lineWords.Add(word);
                lineLength = newLength;
            }
            else
            {
                lines.Add(lineWords);
                lineLengths.Add(lineLength);
                lineLength = word.Length;
                lineWords = new List<string> { word };
            }
        }

        if (lineLength > 0)
        {
            lines.Add(lineWords);
            lineLengths.Add(lineLength);
        }
        
        var result = new List<string>();

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            var sb = new StringBuilder();
            sb.Append(line[0]);

            var spaces = maxWidth - lineLengths[i];

            for (var j = 1; j < line.Count; j++)
            {
                var space = 1;
                if (i != lines.Count - 1)
                {
                    var remaining = line.Count - j;
                    space = (spaces + remaining - 1) / remaining;
                }

                sb.Append(new string(' ', space));
                sb.Append(line[j]);
                spaces -= space;
            }

            sb.Append(new string(' ', spaces));
            
            result.Add(sb.ToString());
        }
        
        return result;
    }
}
