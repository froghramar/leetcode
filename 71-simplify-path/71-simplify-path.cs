public class Solution {
    public string SimplifyPath(string path)
    {
        var parts = path.Replace("//", "/").Split('/', StringSplitOptions.RemoveEmptyEntries);
        var st = new Stack<string>();
        foreach (var part in parts)
        {
            switch (part)
            {
                case ".":
                    break;
                case "..":
                    st.TryPop(out _);
                    break;
                default:
                    st.Push(part);
                    break;
            }
        }

        return "/" + string.Join('/', st.Reverse());
    }
}