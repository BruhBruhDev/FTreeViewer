using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTreeViewer
{
    static partial class Data
    {

        public static int
            _size = 50,
            _maxEntities = 100;
        
        public static Person[] People;
        private static int iPeople;
        public static void NEW()
        {
            People = new Person[_maxEntities];
            iPeople = -1;
            Node.DeleteAll();
        }
        private static void ResetPositions()
        {
            for (int i = 0; i < iPeople + 1; i++)
            {
                People[i].undefinedPos = true;
                People[i].Pos = (0, 0);
            }
        }
        public static int CreatePerson(string firstName, string fullName)
        {
            /// TODO Exception will occur on i overflow
            int id = ++iPeople;
            People[id] = new Person(id, firstName, fullName);
            People[id].id = id;
            return id;
        }
        public static void SetFather(int idPerson, int idFather)
        {    
            People[idPerson].ParentDad = idFather == -1 ? null : People[idFather];
        }
        public static void SetMother(int idPerson, int idMother)
        {
            People[idPerson].ParentMom = idMother == -1 ? null : People[idMother];
        }
        public static int GetIdFather(int idPerson)
        {
            return People[idPerson].ParentDad == null ? -1 : People[idPerson].ParentDad.id;
        }
        public static int GetIdMother(int idPerson)
        {
            return People[idPerson].ParentMom == null ? -1 : People[idPerson].ParentMom.id;
        }
        public static int GetAmountPeople()
        {
            return iPeople+1;
        }
        public static void CalculatePositioning()
        {
            if (iPeople == -1) return;
            ResetPositions();

            Node.InherentConnectionNodesFromPerson();
            Node.GetAmountNodesPerConnection(People[0].n);

            int[][] x = new int[20][];
            for (int iP = 0; iP < x.Length; iP++)
            {
                x[iP] = Node.GetAmountNodesPerConnection(People[iP].n);
                Node.Reset();
                People[iP].numConnecting.Clear();
                People[iP].numConnecting.AddRange(x[iP]);
                if (People[iP].numConnecting.Count < 2) People[iP].centrality = 1000;
                else
                {
                    // subtracts the smallest. So the values are adjusted for relative difference. Avg is calculated afterwards
                    int _smallest = People[iP].numConnecting[0], sum = 0;
                    for (int i = 1; i < People[iP].numConnecting.Count; i++)
                        if (People[iP].numConnecting[i] < _smallest)
                            _smallest = People[iP].numConnecting[i];
                    for (int i = 0; i < People[iP].numConnecting.Count; i++)
                        sum += People[iP].numConnecting[i] - _smallest;
                    People[iP].centrality = (double)sum / People[iP].numConnecting.Count;
                }
            }
            Person rootP = People[1];
            double smallest = rootP.centrality;
            if (false)
            {
                for (int iP = 1; iP < x.Length; iP++)
                    if (People[iP].centrality < smallest)
                    {
                        rootP = People[iP];
                        smallest = People[iP].centrality;
                    }
            }
            rootP.Pos = (0, -100);
            rootP.undefinedPos = false;
            Node.Reset();
            Node.Flag(rootP);
            List<Person> placedPeople = new List<Person>() { rootP };
            List<Node[]> nodes = new List<Node[]>();
            List<Person> selectedNodes = new List<Person>() { rootP };

            int counterA = 0;
            while (counterA++ < 1000)
            {
                nodes.Clear();
                // add next (not flagged) nodes
                for (int i = 0; i < selectedNodes.Count(); i++)
                {
                    nodes.Add(Node.Next(selectedNodes[i].n));
                }
                
                // cleanup
                List<(int x, int y)> entry = new List<(int x, int y)>();
                for (int iList = 0; iList < nodes.Count(); iList++)
                {
                    for (int i = 0; i < nodes[iList].Length; i++)
                    {
                        Node n = nodes[iList][i];
                        for (int _iList = iList + 1; _iList < selectedNodes.Count(); _iList++)
                        {
                            Node n2 = selectedNodes[_iList].n;
                            if (n == n2)
                            {
                                entry.Add((iList, i));
                            }
                        }
                    }
                }
                for (int i = 0; i < entry.Count(); i++)
                {
                    nodes[entry[i].x][entry[i].y] = null;
                }
                //sort for parents first
                for (int iList = 0; iList < nodes.Count(); iList++)
                {
                    List<Node> listA = new List<Node>(), listB = new List<Node>();
                    for (int i = 0; i < nodes[iList].Length; i++)
                    {
                        Person p = selectedNodes[iList];
                        if (p.ParentDad != null && nodes[iList][i] == p.ParentDad.n
                            || p.ParentMom != null && nodes[iList][i] == p.ParentMom.n)
                            listA.Add(nodes[iList][i]);
                        else
                            listB.Add(nodes[iList][i]);
                    }
                    listA.AddRange(listB);
                    nodes[iList] = listA.ToArray();
                }
                // calculate and place
                for (int iList = 0; iList < selectedNodes.Count(); iList++)
                {
                    for (int i = 0; i < nodes[iList].Length; i++)
                    {
                        if (nodes[iList][i] == null) continue;
                        Person p = Node.GetLinkedPerson(nodes[iList][i]);
                        p.Pos = ((int X, int Y))QuickMaths.CreatePosition(placedPeople, selectedNodes[iList]);
                        p.undefinedPos = false;
                        placedPeople.Add(p);
                        //System.Threading.Thread.Sleep(1000);
                    }
                }
                // get next selected nodes
                selectedNodes.Clear();
                for(int iList = 0; iList < nodes.Count(); iList++)
                {
                    for (int i = 0; i < nodes[iList].Length; i++)
                    {
                        if (nodes[iList][i] == null) continue;
                        selectedNodes.Add(Node.GetLinkedPerson(nodes[iList][i]));
                    }
                }
                for (int iList = 0; iList < selectedNodes.Count(); iList++)
                {
                    Node.Flag(selectedNodes[iList]);
                }
                for (int iList = 0; iList < selectedNodes.Count(); iList++)
                {
                    Person p = selectedNodes[iList];
                    if (p == null) continue;
                    for (int _iList = iList + 1; _iList < selectedNodes.Count(); _iList++)
                    {
                        if (p == selectedNodes[_iList])
                            selectedNodes[_iList] = null;
                    }
                }
                for (int iList = selectedNodes.Count() - 1; iList >= 0; iList--)
                {
                    if (selectedNodes[iList] == null)
                        selectedNodes.RemoveAt(iList);
                }
                if (selectedNodes.Count() == 0) break;
            }
            SetUndefinedPosPeople();

        }
        public static Random rand = new Random(0);
        static class QuickMaths
        {
            public static (double X, double Y) CreatePosition(List<Person> people, Person origin)
            {
                double minDistRequ = 50, sensivity = 4;

                (double X, double Y) bestPosition = NewRandPosition(origin, 30);
                double bestDistance = -1;
                for (int Trys = 0; Trys < 100; Trys++)
                {
                    var pos = NewRandPosition(origin, 80+20*Node.GetNumConnections(origin.n));
                    double cc = 0;
                    for (int i = 0; i < people.Count; i++)
                    {
                        Person p = people[i];
                        if (p == origin) continue;
                        double dist = GetVectDist(pos.X, pos.Y, p.Pos.X, p.Pos.Y);
                        dist = dist - dist * Math.Pow(Math.Max(0,minDistRequ-dist), sensivity);
                        cc += dist;
                    }
                    if (cc > bestDistance)
                    {
                        bestPosition = pos;
                        bestDistance = cc;
                    }
                }
                return bestPosition;
            }
            private static (double X, double Y) NewRandPosition(Person origin, int radius)
            {
                var pos = origin.Pos;
                double rad = rand.NextDouble()*2*Math.PI;
                return (pos.X + radius * Math.Cos(rad), pos.Y + radius * Math.Sin(rad)); 
            }
            private static double GetVectLen(double x, double y)
            {
                return Math.Sqrt(x*x + y*y);
            }
            private static double GetVectDist(double x, double y, double x2, double y2)
            {
                return GetVectLen(x-x2,y-y2);
            }
            
        }
        private static Person NavigateToAncestor(List<bool> dir, Person person)
        {
            if (dir.Count == 0) return null;
            int i = 0;
            Person p = person;
            while (i < dir.Count)
            {
                if (p == null) break;
                p = dir[i++] ? p.ParentDad : p.ParentMom;
            }
            return p;
        }
        private static void SetUndefinedPosPeople()
        {
            int cc = 0;
            for (int i = 0; i < iPeople+1; i++)
            {
                if (!People[i].undefinedPos) continue;
                People[i].Pos = (-500, 1000);
                People[i].Pos.X += 100 * (cc % 10);
                People[i].Pos.Y -= 100 * (cc++ / 10);
            }
        }

    }

    class Person
    {
        public List<int> numConnecting = new List<int>();
        public double centrality;

        public double radius;

        public bool undefinedPos = true;
        public int id;
        public Node n;
        private Person parentMom, parentDad;
        private List<Person> children = new List<Person>();
        public string FirstName, FullName;
        public (int X, int Y) Pos = (0,0);
        public Person(int id, string firstName, string fullName, Person mom = null, Person dad = null)
        {
            this.id = id; FirstName = firstName; FullName = fullName; ParentMom = mom; ParentDad = dad;
            n = Node.New(this);
        }
        public Person ParentMom
        {
            get { return parentMom; }
            set {
                if (parentMom != null)
                    parentMom.children.Remove(this);
                parentMom = value;
                if (parentMom != null)
                    parentMom.children.Add(this);
            }
        }
        public Person ParentDad
        {
            get { return parentDad; }
            set {
                if (parentDad != null)
                    parentDad.children.Remove(this);
                parentDad = value;
                if (parentDad != null) 
                    parentDad.children.Add(this);
            }
        }
        public List<Person> Children
        {
            get { return children; }
        }

    }
    class Node // the abstract model of the Person class (for simplification in development of structure)
        // have to be stored in an array in order to efficiently be able to reset
    {
        Person p;

        static Node[] nodes = new Node[100];
        static int iNodes = -1;
        static bool considerIncest = true;
        Node[] connections = new Node[0];
        bool flag = false;
        bool shared = false;
        int myNum = -1;
        public Node(Person p)
        {
            this.p = p;
        }
        public static Node New(Person p)
        {
            nodes[++iNodes] = new Node(p);
            return nodes[iNodes];
        }
        public static void Flag(Person p)
        {
            p.n.flag = true;
        }
        public static void DeFlag(Person p)
        {
            p.n.flag = false;
        }
        public static Node[] Next(Node n)
        {
            int cc = 0;
            for (int i = 0; i < n.connections.Count(); i++)
                if (!n.connections[i].flag) cc++;
            Node[] arr = new Node[cc];
            cc = 0;
            for (int i = 0; i < n.connections.Count(); i++)
                if (!n.connections[i].flag)
                    arr[cc++] = n.connections[i];
            return arr;
        }
        public static int GetNumConnections(Node n)
        {
            return n.connections.Length;
        }
        public static Person GetLinkedPerson(Node n)
        {
            return n.p;
        }
        public static void DeleteAll()
        {
            nodes = new Node[100];
            iNodes = -1;
        }
        public static void Reset()
        {
            for (int i = 0; i <= iNodes; i++)
            {
                Node n = nodes[i];
                n.flag = false; n.myNum = -1; n.shared = false;
            }
        }
        public static void InherentConnectionNodesFromPerson()
        {
            for (int i = 0; i < iNodes; i++)
            {
                bool b1 = nodes[i].p.ParentMom == null, b2 = nodes[i].p.ParentDad == null;
                Node[] arr = new Node[nodes[i].p.Children.Count + (b1 ? 0 : 1) + (b2 ? 0 : 1)];
                for (int i2 = 0; i2 < nodes[i].p.Children.Count; i2++)
                    arr[i2] = nodes[i].p.Children[i2].n;
                if (!b1) arr[arr.Length - 1] = nodes[i].p.ParentMom.n;
                if (!b2) arr[arr.Length - (b1 ? 1 : 2)] = nodes[i].p.ParentDad.n;
                nodes[i].connections = arr;
            }
        }
        public static int[] GetAmountNodesPerConnection(Node node)
        {
            int[] numNodes = new int[node.connections.Length];
            int[] numSharedNodes = new int[node.connections.Length];

            Node[][] connectingNodes = new Node[node.connections.Length][];
            Node[][] selectedNodes = new Node[node.connections.Length][];
            node.flag = true;
            for (int i = 0; i < node.connections.Length; i++)
            {
                selectedNodes[i] = new Node[] { node.connections[i] };
                node.connections[i].flag = true;
                connectingNodes[i] = null;
                numNodes[i] = 1;
                numSharedNodes[i] = 0;
            }
            
            while (true) // iterates in tree depth
            {
                for (int iDirection = 0; iDirection < selectedNodes.Length; iDirection++) // iterates through every direction of the inital node
                {
                    // gather the connecting nodes from the selected nodes of a direction
                    int cc = 0;
                    for (int i = 0; i < selectedNodes[iDirection].Length; i++)
                        cc += selectedNodes[iDirection][i].connections.Length;
                    connectingNodes[iDirection] = new Node[cc];
                    cc = 0;
                    for (int i = 0; i < selectedNodes[iDirection].Length; i++)
                    {
                        selectedNodes[iDirection][i].connections.CopyTo(connectingNodes[iDirection], cc);
                        cc += selectedNodes[iDirection][i].connections.Length;
                    }
                }
                // break condition (once every connectingNode is flagged, meaning end node)
                bool quit = true;
                for (int iDirection = 0; iDirection < connectingNodes.Length; iDirection++)
                {
                    if (connectingNodes[iDirection].Length == 0) continue;
                    quit = false;
                }
                if (quit) break;
                if (considerIncest) // is heavy to compute [something like O(n^2)]
                {
                    for (int iDirection = 0; iDirection < connectingNodes.Length; iDirection++)
                        for (int _iDirection = iDirection+1; _iDirection < connectingNodes.Length; _iDirection++)
                            for (int i = 0; i < connectingNodes[iDirection].Length; i++)
                            {
                                Node n = connectingNodes[iDirection][i];
                                if (n.flag) continue;
                                for (int i2 = 0; i2 < connectingNodes[_iDirection].Length; i2++)
                                {
                                    Node n2 = connectingNodes[_iDirection][i2];
                                    if (n2.flag) continue;
                                    if (n == n2) // incest! yay
                                        n.shared = true;
                                }
                            }
                }
                for (int iDirection = 0; iDirection < connectingNodes.Length; iDirection++) // iterates through every direction of the inital node
                {
                    // evaluate the connections
                    for (int i = 0; i < connectingNodes[iDirection].Length; i++)
                    {
                        Node n = connectingNodes[iDirection][i];
                        if (n.flag) continue;
                        if (n.shared) numSharedNodes[iDirection] += 1;
                        else numNodes[iDirection] += 1;
                    }
                }
                for (int iDirection = 0; iDirection < connectingNodes.Length; iDirection++) // iterates through every direction of the inital node
                {
                    // throw selected nodes away; replace with filtered connection nodes
                    selectedNodes[iDirection] = null;
                    var tList = new List<Node>();
                    for (int i = 0; i < connectingNodes[iDirection].Length; i++)
                        if (!connectingNodes[iDirection][i].flag)
                        {
                            connectingNodes[iDirection][i].flag = true;
                            tList.Add(connectingNodes[iDirection][i]);
                        }
                    connectingNodes[iDirection] = null;
                    selectedNodes[iDirection] = tList.ToArray();
                }
            }
            return numNodes;
        }
    }
}
