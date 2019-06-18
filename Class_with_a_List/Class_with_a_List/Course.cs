using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_with_a_List
{
    public enum Session { Winter, Spring, Summer, Fall };
    class Course
    {
        private string _courseNumber;
        private Session _session;
        private List<int> gradeList; // must be created internally and NOT accessible from outside
        public Course() { }
        public Course(string courseNumber, Session session)
        {
            _courseNumber = courseNumber;
            _session = session;
            // create the gradeList
            gradeList = new List<int>();
        }
        // Properties
        public string CourseNumber { get { return _courseNumber; } }
        public Session Session { get { return _session; } }
        // prop to return number of items in gradeList
        public int Count { get { return gradeList.Count; } }
        // Indexer
        public int this[int i]
        {   // caller/user will NEVER get the array/list itself just the values one index at a time
            get
            {   // field is now an entire array so just return the indexed value, one at a time
                if (i < 0 || i > gradeList.Count)
                {
                    throw new IndexOutOfRangeException("Unable to retreive a value from an invalid index");
                }
                else
                {
                    return gradeList[i];
                }
            }
            //set
            //{   // this would allow bulk-loading of the array - use the AddGrade Method() instead
            //    gradeList[i] = value;
            //}
        }
        // Methods()
        // define a Method() that allows us to add a grade to the gradeList
        public void AddGrade(int grade)
        {   // because gradeList is an object, we need to use a Method() to avoid supplying a REF to the caller/user
            if (grade < 0 || grade > 100)
            {
                InvalidOperationException exception = new InvalidOperationException("Invalid grade value. Must be between 0 and 100");
                throw (exception);
            }
            // now that grade is known to be valid, add grade to the list
            gradeList.Add(grade); // use the Add Method()
        }
        public bool RemoveGrade(int grade)
        {   // because gradeList is an object, we need to use a Method() to avoid supplying a REF to the caller/user
            // true = success/false = failed
            bool done = gradeList.Remove(grade); // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.remove?view=netframework-4.8
            return done;
        }
        public double GetAverageGrade()
        {
            return gradeList.Average();
        }
        public int GetMaxGrade()
        {
            return gradeList.Max();
        }
        public int GetMinGrade()
        {
            return gradeList.Min();
        }
    }
}
