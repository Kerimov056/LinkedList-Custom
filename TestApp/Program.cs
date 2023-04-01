using Collections.Collections;


LinkedList<int> list = new LinkedList<int>();
list.AddFirst(1);
list.AddFirst(2);
list.AddFirst(3);

list.Remove(3);
foreach (var item in list)
{
    Console.WriteLine(item);
}


Console.WriteLine("**************************");
Console.WriteLine("*********(MyList)*********");
Console.WriteLine("**************************");




CustomLinkedList<int> Mylist = new CustomLinkedList<int>();
Mylist.AddFirst(1);
Mylist.AddFirst(2);
Mylist.AddFirst(3);

Mylist.Remove(3);
foreach (var item in Mylist)
{
    Console.WriteLine(item);
}





