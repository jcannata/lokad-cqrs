﻿#region (c) 2010-2011 Lokad - CQRS for Windows Azure - New BSD License 

// Copyright (c) Lokad 2010-2011, http://www.lokad.com
// This code is released as Open Source under the terms of the New BSD Licence

#endregion

using System;
using System.Collections.Generic;

namespace Lokad.Cqrs
{
    //[DebuggerDisplay("{MappedType.Name} with {")]
    public sealed class ImmutableMessage
    {
        public readonly Type MappedType;
        public readonly object Content;
        public readonly int Index;
        readonly IDictionary<string, string> _attributes;

        public ICollection<KeyValuePair<string, string>> GetAllAttributes()
        {
            return _attributes;
        }

        public bool TryGetAttribute(string name, out string result)
        {
            return _attributes.TryGetValue(name, out result);
        }

        public string GetAttribute(string name, string defaultValue)
        {
            string value;
            if (_attributes.TryGetValue(name, out value))
            {
                return value;
            }
            return defaultValue;
        }


        public ImmutableMessage(Type mappedType, object content, IDictionary<string, string> attributes, int index)
        {
            MappedType = mappedType;
            Index = index;
            Content = content;
            _attributes = attributes;
        }

        public override string ToString()
        {
            return string.Format("[{0}]", Content.ToString());
        }
    }
}