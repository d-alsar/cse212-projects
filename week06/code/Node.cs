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
        // Ensure unique values only
        if (value == Data)
        {
            return; // Ignore duplicate values
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
        {
            return true; // Value found
        }
        else if (value < Data && Left != null)
        {
            return Left.Contains(value); // Search in the left subtree
        }
        else if (value > Data && Right != null)
        {
            return Right.Contains(value); // Search in the right subtree
        }
        
        return false; // Value not found
    }


public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }

    public void TraverseBackward(Action<int> action)
    {
        if (Right != null)
        {
            Right.TraverseBackward(action);
        }

        action(Data);

        if (Left != null)
        {
            Left.TraverseBackward(action);
        }
    }
}