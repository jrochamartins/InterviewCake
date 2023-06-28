/*
 https://www.interviewcake.com/question/python/largest-stack?utm_source=weekly_email&utm_source=drip&utm_campaign=weekly_email&utm_campaign=Interview%20Cake%20Weekly%20Problem%20%23455:%20Largest%20Stack&utm_medium=email&utm_medium=email
You want to be able to access the largest element in a stack.
 */

using System.Collections.Generic;
using Xunit;

namespace Solutions
{
    public class MaxStack
    {
        private readonly Stack<int> _stack = new();
        private readonly Stack<int> _maxesStack = new();

        public void Push(int item)
        {
            _stack.Push(item);
            if (_maxesStack.Count == 0 || item >= _maxesStack.Peek())
                _maxesStack.Push(item);
        }

        public int Pop()
        {
            var item = _stack.Pop();
            if (item == _maxesStack.Peek())
                _maxesStack.Pop();
            return item;
        }

        public int GetMax()
        {
            return _maxesStack.Peek();
        }
    }

    public class MaxStackTests
    {
        [Fact]
        public void MaxStackTest()
        {
            var s = new MaxStack();
            s.Push(5);
            Assert.Equal(5, s.GetMax());

            s.Push(3);
            s.Push(4);
            s.Push(7);
            s.Push(7);
            s.Push(8);

            Assert.Equal(8, s.GetMax());
            Assert.Equal(8, s.Pop());
            Assert.Equal(7, s.GetMax());
            Assert.Equal(7, s.Pop());
            Assert.Equal(7, s.GetMax());
            Assert.Equal(7, s.Pop());

            Assert.Equal(5, s.GetMax());
            Assert.Equal(4, s.Pop());
            Assert.Equal(5, s.GetMax());
            Assert.Equal(3, s.Pop());
            Assert.Equal(5, s.GetMax());
            Assert.Equal(5, s.Pop());
        }
    }
}