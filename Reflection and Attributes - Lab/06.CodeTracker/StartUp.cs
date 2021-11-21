using System;

namespace AuthorProblem
{
    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("AuthorProblem.Hacker");
            Console.WriteLine(result);
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }

}
