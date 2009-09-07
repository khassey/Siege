﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Siege.ServiceLocation
{
    public interface IContext
    {
    }
    public class Context : IContext
    {
        public Context(object contextItem)
        {
            Value = contextItem;
        }

        public object Value { get; set; }
    }

    public class Context<T> : Context
    {
        public Context(object contextItem) : base(contextItem)
        {
        }

        public new T Value { get; set; }
    }

    public interface IUseCase { }

    public interface IUseCase<TBaseType> : IUseCase
    {
        TBaseType Resolve(IServiceLocator locator, IList<object> context, IDictionary dictionary);
        Type GetBoundType();
    }
}