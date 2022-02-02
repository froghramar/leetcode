using System.Text.Json;

public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        return JsonSerializer.Serialize(root, new JsonSerializerOptions
        {
            IncludeFields = true,
            MaxDepth = int.MaxValue
        });
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        return JsonSerializer.Deserialize<TreeNode>(data, new JsonSerializerOptions
        {
            IncludeFields = true,
            MaxDepth = int.MaxValue
        });
    }
}