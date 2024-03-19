using System.Collections.Generic;

public class Node<T>
{
    public T data;
    public Node<T> next;

    public Node(T data)
    {
        this.data = data;
        this.next = null;
    }
}

public class MyQueue<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int count;

    // »ý¼ºÀÚ
    public MyQueue()
    {
        head = null;
        tail = null;
        count = 0;
    }

    // Enqueue
    public void Enqueue(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (tail == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }
        count++;
    }

    // Dequeue
    public T Dequeue()
    {
        if (head == null)
        {
            
        }

        T data = head.data;
        head = head.next;
        if (head == null)
        {
            tail = null;
        }
        count--;
        return data;
    }

    // Count
    public int Count
    {
        get { return count; }
    }
}
