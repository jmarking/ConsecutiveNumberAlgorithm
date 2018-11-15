using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConsecutiveNumberAlgorithm
{
    class Program
    {
        private enum LinkedListPosition
        {
            First,
            Last
        }

        private static readonly LinkedList<int> _linkedList = new LinkedList<int>();

        static void Main(string[] args)
        {
            WriteLine("Creating test data...");
            var testData = CreateTestData();

            WriteLine("Adding new integers to sorted linked list...");
            AddToLinkedList(testData);

            WriteLine("Generating consecutive number runs...");
            var setOfRuns = SetOfRuns();

            WriteLine("Starting output display...\n");
            DisplaySetOfRuns(setOfRuns);

            // Pause to see output.
            ReadKey();
        }
        /// <summary>
        /// Creates a linkedlist altering integers front to back creating unordered list.
        /// </summary>
        /// <returns>Unordered list of integers</returns>
        private static IEnumerable<int> CreateTestData()
        {
            var linkedList = new LinkedList<int>();
            var firstOrLast = LinkedListPosition.Last;

            for (var i = 1; i <= 10000; i++)
            {
                if (i % 7 == 0)
                {
                    firstOrLast = firstOrLast == LinkedListPosition.Last ? LinkedListPosition.First : LinkedListPosition.Last;
                }
                else
                {
                    if (firstOrLast == LinkedListPosition.Last)
                        linkedList.AddLast(i);
                    else
                        linkedList.AddFirst(i);
                }
            }
            return linkedList;
        }
        /// <summary>
        /// Insert integer value into consecutive numbers linkedlist maintaining ascending sort order.
        /// </summary>
        /// <param name="value">Integer value</param>
        private static void AddToLinkedList(int value)
        {
            if (_linkedList.Count() == 0)
            {
                _linkedList.AddFirst(value);
            }
            else if (_linkedList.Find(value) == null)
            {
                if (value < _linkedList.First.Value)
                    _linkedList.AddFirst(value);
                else if (value > _linkedList.Last.Value)
                    _linkedList.AddLast(value);
                else
                {
                    var preceedingValue = _linkedList.Where(v => v < value).Max();
                    var preceedingValueNode = _linkedList.Find(preceedingValue);
                    _linkedList.AddAfter(preceedingValueNode, value);
                }
            }
        }
        /// <summary>
        /// Inserting range of integer values into consecutive numbers linkedlist
        /// maintaining ascending sort order.
        /// </summary>
        /// <param name="values">list of integer values</param>
        private static void AddToLinkedList(IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                AddToLinkedList(value);
            }
        }
        /// <summary>
        /// Generates the lists of consecutive number runs.
        /// </summary>
        /// <returns>List of lists integers</returns>
        private static List<List<int>> SetOfRuns()
        {
            var setOfRuns = new List<List<int>>();
            var run = new List<int> { _linkedList.First.Value };

            for (var i = 1; i < _linkedList.Count; i++)
            {
                if (_linkedList.ElementAt(i) - run.Last() == 1)
                {
                    run.Add(_linkedList.ElementAt(i));
                }
                else
                {
                    setOfRuns.Add(run);
                    run = new List<int> { _linkedList.ElementAt(i) };
                }
            }
            return setOfRuns;
        }
        private static void DisplaySetOfRuns(List<List<int>> setOfRuns)
        {
            foreach(var run in setOfRuns)
            {
                WriteLine($"{{{string.Join(",", run)}}},");
            }
        }
    }
}
