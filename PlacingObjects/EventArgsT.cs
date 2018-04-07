﻿using System;
namespace ARLingo
{
    public class EventArgsT<T> : EventArgs
    {
        public T Value { get; }

        public EventArgsT(T val)
        {
            this.Value = val;
        }
    }

}
