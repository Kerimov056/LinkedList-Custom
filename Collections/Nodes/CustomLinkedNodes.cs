namespace Collections.Nodes;

public class CustomLinkedNodes<T>
{
    public T Value { get; private set; }

	public CustomLinkedNodes<T>? Next { get; set; }
	public CustomLinkedNodes<T>? Previous { get; set; }
	public CustomLinkedNodes(T value)
	{
		Value= value;
	}
}
