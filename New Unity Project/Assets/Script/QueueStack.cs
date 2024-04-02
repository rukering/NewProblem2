using System;
using UnityEngine;
using System.Collections.Generic;

public class QueueStack<T>
{
    private Queue<T> mainQueue;
    private Queue<T> tempQueue;

    // 생성자
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

        // mainQueue에서 요소를 tempQueue로 옮김
        while (mainQueue.Count > 1)
        {
            tempQueue.Enqueue(mainQueue.Dequeue());
        }

        // mainQueue에서 마지막 요소를 제거하여 반환
        T popped = mainQueue.Dequeue();

        // tempQueue와 mainQueue를 교환
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

        // mainQueue에서 요소를 tempQueue로 옮김
        while (mainQueue.Count > 1)
        {
            tempQueue.Enqueue(mainQueue.Dequeue());
        }

        // mainQueue에서 마지막 요소를 가져옴
        T peeked = mainQueue.Peek();

        // mainQueue와 tempQueue를 교환
        SwapQueues();

        return peeked;
    }

    // Count
    public int Count
    {
        get { return mainQueue.Count; }
    }

    // mainQueue와 tempQueue를 교환하는 메서드
    private void SwapQueues()
    {
        Queue<T> temp = mainQueue;
        mainQueue = tempQueue;
        tempQueue = temp;
    }
}
