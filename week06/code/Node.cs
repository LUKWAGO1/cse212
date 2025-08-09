public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Avoid inserting duplicates
        if (value == Data)
        {
            return; // Do nothing if value already exists
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data)
        {
            return Left?.Contains(value) ?? false;
        }
        else
        {
            return Right?.Contains(value) ?? false;
        }
    }

    public int GetHeight()
    {
        // Get the height of the left and right subtrees
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // The height of the current node is the larger of the two heights plus one
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}