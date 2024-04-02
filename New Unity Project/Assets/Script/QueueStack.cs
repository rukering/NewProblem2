using System;
using UnityEngine;
using System.Collections.Generic;

public class QueueStack<T>
{
    private Queue<T> mainQueue;
    private Queue<T> tempQueue;

    // ������
    public QueueStack()
    {
        mainQueue = new Queue<T>();
        tempQueue = new Queue<T>();
    }

    // Push
    public void Push(T data)
    {
        mainQueue.Enqueue(data);
    }

    // Pop
    public T Pop()
    {
        if (mainQueue.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        // mainQueue���� ��Ҹ� tempQueue�� �ű�
        while (mainQueue.Count > 1)
        {
            tempQueue.Enqueue(mainQueue.Dequeue());
        }

        // mainQueue���� ������ ��Ҹ� �����Ͽ� ��ȯ
        T popped = mainQueue.Dequeue();

        // tempQueue�� mainQueue�� ��ȯ
        SwapQueues();

        return popped;
    }

    // Peek
    public T Peek()
    {
        if (mainQueue.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        // mainQueue���� ��Ҹ� tempQueue�� �ű�
        while (mainQueue.Count > 1)
        {
            tempQueue.Enqueue(mainQueue.Dequeue());
        }

        // mainQueue���� ������ ��Ҹ� ������
        T peeked = mainQueue.Peek();

        // mainQueue�� tempQueue�� ��ȯ
        SwapQueues();

        return peeked;
    }

    // Count
    public int Count
    {
        get { return mainQueue.Count; }
    }

    // mainQueue�� tempQueue�� ��ȯ�ϴ� �޼���
    private void SwapQueues()
    {
        Queue<T> temp = mainQueue;
        mainQueue = tempQueue;
        tempQueue = temp;
    }
}
