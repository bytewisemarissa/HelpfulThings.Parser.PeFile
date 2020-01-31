using System;
using System.Collections;
using System.Collections.Generic;

namespace HelpfulThings.Parser.PeFile.Exceptions
{
    public class ExceptionCollector : IList<ParserException>
    {
        private readonly ParserExceptionOption _option;
        private readonly List<ParserException> _exceptions;

        public ExceptionCollector(ParserExceptionOption option)
        {
            _exceptions = new List<ParserException>();
            _option = option;
        }

        public IEnumerator<ParserException> GetEnumerator()
        {
            return _exceptions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ParserException item)
        {
            if(item == null)
                throw new NullReferenceException("A null value was passed to the exception collector.");

            _exceptions.Add(item);

            bool throwException = false;
            switch (_option)
            {
                case ParserExceptionOption.StopOnFirstException:
                    throwException = true;
                    break;
                case ParserExceptionOption.ContinueSafely:
                    if (item.Level >= ExceptionLevel.Problem)
                    {
                        throwException = true;
                    }
                    break;
                case ParserExceptionOption.Force: //Explicitly define force behavior, you're welcome reader. I me, future me. 
                    break;
            }

            if (throwException)
            {
                throw item;
            }
        }

        public void Clear()
        {
            _exceptions.Clear();
        }

        public bool Contains(ParserException item)
        {
            return _exceptions.Contains(item);
        }

        public void CopyTo(ParserException[] array, int arrayIndex)
        {
            _exceptions.CopyTo(array, arrayIndex);
        }

        public bool Remove(ParserException item)
        {
            return _exceptions.Remove(item);
        }

        public int Count => _exceptions.Count;
        public bool IsReadOnly => false;
        public int IndexOf(ParserException item)
        {
            return _exceptions.IndexOf(item);
        }

        public void Insert(int index, ParserException item)
        {
            _exceptions.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _exceptions.RemoveAt(index);
        }

        public ParserException this[int index]
        {
            get => _exceptions[index];
            set => _exceptions[index] = value;
        }
    }
}
