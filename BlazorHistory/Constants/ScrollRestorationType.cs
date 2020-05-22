using System;
using System.Collections.Generic;

namespace BlazorHistory
{
    public sealed class ScrollRestorationType
    {
        private static readonly Dictionary<string, ScrollRestorationType> Instance = new Dictionary<string, ScrollRestorationType>();
        private readonly string name;

        private ScrollRestorationType(string name)
        {
            this.name = name;
            Instance[name] = this;
        }

        public static implicit operator ScrollRestorationType(string str)
        {
            return $"{FromString(str)}";
        }

        public static ScrollRestorationType FromString(string str)
        {
            if (Instance.TryGetValue(str, out ScrollRestorationType result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"{nameof(ScrollRestorationType)} must be one of the followings: auto or manual");
            }
        }

        public override string ToString()
        {
            return $"{this.name}";
        }

        public static readonly ScrollRestorationType Auto = new ScrollRestorationType("auto");
        public static readonly ScrollRestorationType Manual = new ScrollRestorationType("manual");

    }
}
