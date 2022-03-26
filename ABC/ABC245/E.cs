using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
    {
        public static void Main()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (N, M) = Scanner.Scan<int, int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var B = Scanner.ScanEnumerable<int>().ToArray();
            var C = Scanner.ScanEnumerable<int>().ToArray();
            var D = Scanner.ScanEnumerable<int>().ToArray();

            var chocos = A.Zip(B).Select(x => new Element(0, x.First, x.Second));
            var cases = C.Zip(D).Select(x => new Element(1, x.First, x.Second));
            var list = chocos.Concat(cases).ToList();
            list.Sort((x, y) =>
            {
                var result = y.H.CompareTo(x.H);
                return result != 0 ? result : y.Type.CompareTo(x.Type);
            });

            var set = new RandomizedBinarySearchTree<int>();
            foreach (var e in list)
            {
                if (e.Type == 0)
                {
                    var lb = set.LowerBound(e.W);
                    if (lb < 0 || set.Count <= lb)
                    {
                        Console.WriteLine("No");
                        return;
                    }

                    set.RemoveAt(lb);
                }
                else
                {
                    set.Insert(e.W);
                }
            }

            Console.WriteLine("Yes");
        }

        public class RandomizedBinarySearchTree<T> : IReadOnlyCollection<T>
        {
            private readonly Comparison<T> _comparison;
            private readonly Random _random;
            private Node _root;
            public RandomizedBinarySearchTree(int seed = 0) : this(comparer: null, seed) { }
            public RandomizedBinarySearchTree(Comparer<T> comparer, int seed = 0) : this(
                (comparer ?? Comparer<T>.Default).Compare, seed)
            {
            }
            public RandomizedBinarySearchTree(Comparison<T> comparison, int seed = 0)
            {
                _comparison = comparison;
                _random = new Random(seed);
            }
            public void Insert(T value)
            {
                if (_root is null) _root = new Node(value);
                else InsertAt(LowerBound(value), value);
            }
            public bool Remove(T value)
            {
                var index = LowerBound(value);
                if (index < 0) return false;
                RemoveAt(index);
                return true;
            }
            public T ElementAt(int index)
            {
                if (index < 0 || Count <= index) throw new ArgumentOutOfRangeException(nameof(index));
                var node = _root;
                var idx = CountOf(node) - CountOf(node.R) - 1;
                while (node is { })
                {
                    if (idx == index) return node.Value;
                    if (idx > index)
                    {
                        node = node.L;
                        idx -= CountOf(node?.R) + 1;
                    }
                    else
                    {
                        node = node.R;
                        idx += CountOf(node?.L) + 1;
                    }
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            public bool Contains(T value)
            {
                return Find(value) is { };
            }
            public int Count => CountOf(_root);
            public IEnumerator<T> GetEnumerator() => Enumerate(_root).GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public int UpperBound(T value) => Bound(value, (x, y) => _comparison(x, y) > 0);
            public int LowerBound(T value) => Bound(value, (x, y) => _comparison(x, y) >= 0);
            public int Bound(T value, Func<T, T, bool> compare)
            {
                var node = _root;
                if (node is null) return -1;
                var bound = CountOf(node);
                var idx = bound - CountOf(node.R) - 1;
                while (node is { })
                {
                    if (compare(node.Value, value))
                    {
                        node = node.L;
                        bound = Math.Min(bound, idx);
                        idx -= CountOf(node?.R) + 1;
                    }
                    else
                    {
                        node = node.R;
                        idx += CountOf(node?.L) + 1;
                    }
                }
                return bound;
            }
            private double GetProbability() => _random.NextDouble();
            private void InsertAt(int index, T value)
            {
                var (l, r) = Split(_root, index);
                _root = Merge(Merge(l, new Node(value)), r);
            }
            public void RemoveAt(int index)
            {
                var (l, r1) = Split(_root, index);
                var (_, r2) = Split(r1, 1);
                _root = Merge(l, r2);
            }
            private Node Merge(Node l, Node r)
            {
                if (l is null || r is null) return l ?? r;
                var (n, m) = (CountOf(l), CountOf(r));
                if ((double)n / (n + m) > GetProbability())
                {
                    l.R = Merge(l.R, r);
                    return l;
                }
                else
                {
                    r.L = Merge(l, r.L);
                    return r;
                }
            }
            private (Node, Node) Split(Node node, int k)
            {
                if (node is null) return (null, null);
                if (k <= CountOf(node.L))
                {
                    var (l, r) = Split(node.L, k);
                    node.L = r;
                    return (l, node);
                }
                else
                {
                    var (l, r) = Split(node.R, k - CountOf(node.L) - 1);
                    node.R = l;
                    return (node, r);
                }
            }
            private Node Find(T value)
            {
                var node = _root;
                while (node is { })
                {
                    var cmp = _comparison(node.Value, value);
                    if (cmp > 0) node = node.L;
                    else if (cmp < 0) node = node.R;
                    else break;
                }
                return node;
            }
            private static int CountOf(Node node) => node?.Count ?? 0;
            private static IEnumerable<T> Enumerate(Node node = null)
            {
                if (node is null) yield break;
                foreach (var value in Enumerate(node.L)) yield return value;
                yield return node.Value;
                foreach (var value in Enumerate(node.R)) yield return value;
            }
            private class Node
            {
                internal T Value { get; }
                internal Node L
                {
                    get => _l;
                    set
                    {
                        _l = value;
                        UpdateCount();
                    }
                }
                internal Node R
                {
                    get => _r;
                    set
                    {
                        _r = value;
                        UpdateCount();
                    }
                }
                internal int Count { get; private set; }
                private Node _l;
                private Node _r;
                internal Node(T value)
                {
                    Value = value;
                    Count = 1;
                }
                private void UpdateCount()
                {
                    Count = (L?.Count ?? 0) + (R?.Count ?? 0) + 1;
                }
            }
        }


        public struct Element : IEquatable<Element>
        {
            public int Type { get; }
            public int H { get; }
            public int W { get; }
            public Element(int type, int h, int w) => (Type, H, W) = (type, h, w);

            public bool Equals(Element other)
            {
                return (Type, H, W) == (other.Type, other.H, other.W);
            }
        }

        public static class Scanner
        {
            public static string ScanLine() => Console.ReadLine()?.Trim() ?? string.Empty;
            public static string[] Scan() => ScanLine().Split(' ');
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
