# Consecutive Number Algorithm

Code challenge from Kip at BTS

I'm admittedly not the [HackerRank Greedy Algorithm guru](https://www.hackerrank.com/domains/algorithms?filters%5Bsubdomains%5D%5B%5D=greedy).  I've certainly had to create some algorithms over the course of my career, but generally speaking, very rarely experienced performance issues that a user found noticeable enough for a rewrite.  Most performance issues would be something like not indexing a database table correctly for example.

Q&A From Email:


>What pros/cons do you see with your solution?


The pros I see is that my solution works, and looks like reasonable tight clean code solution.

The cons I see are the possible use of Linq.  When I have done some algorithms on HackerRank, it seems using code as close to assembly language as possible, whatever that would mean (i.e. arrary []), or what have you to reduce time.  And techniques like recursion instead of for and foreach.


>Suppose this needed to run on a machine with tight memory constraints. How could you reduce your memory consumption?


I think I tried to address this already by using LinkedList instead of List.  From some basic research in [this SO thread](https://stackoverflow.com/questions/169973/when-should-i-use-a-list-vs-a-linkedlist) it sounds like List will have to keep expanding array size behind the scene as the data grows, which starts using more memory than LinkedList.  If I did have to focus on memory constraints, I would look for a diagnostic tool to give feedback.


>Suppose the system needs to support multiple sources of input e.g. an in memory list or an input file. How would you implement that?


I would create separate "front end" jobs that gather the respective data (one for reading memory list and another reading in file data), and have each "front end" job call this as a backend service to support DRY principles.


>Suppose the list of numbers is streaming in from an external source (such as console input), and you should be able to look at any time and see the current list. Does your solution change and if so, what changes need to be made to allow for this?


No, I would use it as is.  I created two methods that accept input to continue to add to the LinkedList of integers.  The method is AddToLinkedList with signature ovveride allowing a single integer to be added, or a range of integer values.
